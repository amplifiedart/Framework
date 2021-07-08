using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.System
{
	public interface IRange<T> : IComparable
	{
		T Start { get; set; }
		T End { get; set; }

		bool Contains(T value);
	}
}
