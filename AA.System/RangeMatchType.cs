using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.System
{
	/// <summary>
	/// This enumeration provides the matching types of one range against the other
	/// It also applies for Value Matches by using the StartBefore, StartEqual, EndEqual, EndAfter enumerates.
	/// </summary>
	[Flags]
	public enum RangeMatchType : int
	{
		/// <summary>
		/// The range could not be matched.
		/// </summary>
		None = 0,
		/// <summary>
		/// The start of the range lies before the other range start
		/// <code>
		///	Given Range&nbsp;&nbsp; : ....[######]....<br />
		/// Matched Value : ..X.............
		/// </code>
		/// </summary>
		StartBefore = 1,
		/// <summary>
		/// The start of the range is equal to the other range start
		/// </summary>
		StartEqual = 2,
		/// <summary>
		/// The start of the range is larger then the other range start but is equal or lies before the other range end
		/// </summary>
		StartAfter = 4,
		/// <summary>
		/// The start of the range is larger then the other range start and also is larger then the other range end
		/// </summary>
		StartAfterEnd = 8,
		/// <summary>
		/// The end of the range lies before the other range end and also lies before the other range start
		/// </summary>
		EndBeforeStart = 16,
		/// <summary>
		/// The end lies before the other range end but lies equal or beyond the other range start
		/// </summary>
		EndBefore = 32,
		/// <summary>
		/// The end is equal to the other range end
		/// </summary>
		EndEqual = 64,
		/// <summary>
		/// The end lies after the other range end
		/// </summary>
		EndAfter = 128,
		/// <summary>
		/// The range starts befor and end after the other range
		/// </summary>
		Overlap = StartBefore | EndAfter,
		/// <summary>
		/// The range starts and ends before the start of the other range
		/// </summary>
		OutsideBefore = StartBefore | EndBeforeStart,
		/// <summary>
		/// The range start and ends after the end of the other range
		/// </summary>
		OutsideAfter = StartAfterEnd | EndAfter,
		/// <summary>
		/// The range start before and ends in the other range
		/// </summary>
		EndsIn = StartBefore | EndBefore,
		/// <summary>
		/// The range start equal and ends in the other range
		/// </summary>
		Head = StartEqual | EndBefore,
		/// <summary>
		/// The the range is equal to the other range
		/// </summary>
		Equal = StartEqual | EndEqual,
		/// <summary>
		/// The range start in and ends equal to the other range
		/// </summary>
		Tail = StartAfter | EndEqual,
		/// <summary>
		/// The range starts in and ends after the other range
		/// </summary>
		StartsIn = StartAfter | EndAfter,
		/// <summary>
		/// The range is part of the other range
		/// </summary>
		PartOf = StartAfter | EndBefore
	}
}
