using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.System
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="System.IComparable" />
	public interface IRange<T> : IComparable
	{
		/// <summary>
		/// Gets or sets the start.
		/// </summary>
		/// <value>
		/// The start.
		/// </value>
		T Start { get; set; }
		/// <summary>
		/// Gets or sets the end.
		/// </summary>
		/// <value>
		/// The end.
		/// </value>
		T End { get; set; }

		/// <summary>
		/// Determines whether this instance contains the object.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		bool Contains(T value);

		/// <summary>
		/// Matches the specified range.
		/// </summary>
		/// <param name="range">The range.</param>
		/// <returns></returns>
		RangeMatchType Match(IRange<T> range);

		/// <summary>
		/// Matches the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		RangeMatchType Match(T value);
	}
}
