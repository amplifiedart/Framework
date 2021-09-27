using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.System
{
	/// <summary>
	/// Range object used to describe a range with a lower and upper value of type T.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="AA.System.IRange{T}" />
	public class GenericRange<T> : IRange<T> where T : IComparable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericRange{T}"/> class.
		/// </summary>
		public GenericRange()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericRange{T}"/> class.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		public GenericRange(T start, T end)
		{
			Start = start;
			End = end;
		}

		/// <summary>
		/// Gets or sets the start.
		/// </summary>
		/// <value>
		/// The start.
		/// </value>
		public T Start { get; set; }
		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>
		/// The end.
		/// </value>
		public T End { get; set; }

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings:
		/// Value
		/// Meaning
		/// Less than zero
		/// This instance precedes <paramref name="obj" /> in the sort order.
		/// Zero
		/// This instance occurs in the same position in the sort order as <paramref name="obj" />.
		/// Greater than zero
		/// This instance follows <paramref name="obj" /> in the sort order.
		/// </returns>
		public int CompareTo(object obj)
		{
			if (obj.GetType() == typeof(GenericRange<T>))
				return CompareTo((GenericRange<T>)obj);
			else if (obj.GetType() == typeof(T))
				return CompareTo((T)obj);
			else
				return 1;

		}

		/// <summary>
		/// Compares to.
		/// </summary>
		/// <param name="range">The range.</param>
		/// <returns></returns>
		public int CompareTo(GenericRange<T> range)
		{
			int hold = Start.CompareTo(range.Start);
			return hold == 0 ? End.CompareTo(range.End) : hold;
		}

		/// <summary>
		/// Determines whether this instance contains the object.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains(T value)
		{
			return value.CompareTo(Start) >= 0 && value.CompareTo(End) <= 0;
		}

		public IRange<T> Intersect(IRange<T> range)
		{
			int startCompare = range.Start.CompareTo(Start);
			T start = (startCompare > 0) ? range.Start : Start;

			int endCompare = range.End.CompareTo(End);
			T end = (endCompare < 0) ? range.End : End;


			if (start.CompareTo(end) > 0)
				return null;
			else
				return new GenericRange<T>(start, end);
		}

		/// <summary>
		/// Matches the specified range.
		/// </summary>
		/// <param name="range">The range.</param>
		/// <returns></returns>
		public RangeMatchType Match(IRange<T> range)
		{
			RangeMatchType result;

			int startCompare = range.Start.CompareTo(Start);
			int endCompare;
			if (startCompare > 0)
			{
				endCompare = range.Start.CompareTo(End);
				result = endCompare > 0 ? RangeMatchType.StartAfterEnd : RangeMatchType.StartAfter;
			}
			else
				result = startCompare < 0 ? RangeMatchType.StartBefore : RangeMatchType.StartEqual;

			endCompare = range.End.CompareTo(End);
			if (endCompare < 0)
			{
				startCompare = range.End.CompareTo(Start);
				result |= (startCompare < 0 ? RangeMatchType.EndBeforeStart : RangeMatchType.EndBefore);
			}
			else
				result |= (endCompare > 0 ? RangeMatchType.EndAfter : RangeMatchType.EndEqual);


			return result;
		}

		/// <summary>
		/// Matches the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public RangeMatchType Match(T value)
		{
			return Match(new GenericRange<T>(value, value));
		}

		public IRange<T> Union(IRange<T> range)
		{
			if (range.End.CompareTo( Start)<0 | range.Start.CompareTo( End)>0)
				return null;

			int startCompare = range.Start.CompareTo(Start);
			T start = (startCompare < 0) ? range.Start : Start;

			int endCompare = range.End.CompareTo(End);
			T end = (endCompare > 0) ? range.End : End;

			return new GenericRange<T>(start, end);
		}
	}
}
