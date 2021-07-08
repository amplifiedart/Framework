using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.System
{
	public class GenericRange<T> : IRange<T> where T : IComparable
	{
		public GenericRange()
		{
		}

		public GenericRange(T start, T end)
		{
			Start = start;
			End = end;
		}

		public T Start { get; set; }
		public T End { get; set; }

		public int CompareTo(object obj)
		{
			if (obj.GetType() == typeof(GenericRange<T>))
				return CompareTo((GenericRange<T>)obj);
			else
				return 1;

		}

		public int CompareTo(GenericRange<T> range)
		{
			int hold = Start.CompareTo(range.Start);
			return hold == 0 ? End.CompareTo(range.End) : hold;
		}

		public bool Contains(T value)
		{
			return value.CompareTo(Start) >= 0 && value.CompareTo(End) <= 0;
		}
	}
}
