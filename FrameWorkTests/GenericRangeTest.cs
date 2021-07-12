using AA.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrameWorkTests
{
	[TestClass]
	public class GenericRangeTest
	{
		[TestMethod]
		public void RangeCompareTest()
		{
			GenericRange<int> firstRange = new GenericRange<int>(5, 10);
			GenericRange<int> secondRange = new GenericRange<int>(3, 7);

			// The first range is larger then the second range (1)
			Assert.AreEqual(firstRange.CompareTo(secondRange), 1, "5-10 v.s. 3-7");

			// The second range is smaller then the second range (-1)
			Assert.AreEqual(secondRange.CompareTo(firstRange), -1, "3-7 vs 5-10");

			secondRange = new GenericRange<int>(5, 10);
			// The first Range is equal to the second range (0)
			Assert.AreEqual(firstRange.CompareTo(secondRange), 0, "5-10 vs 5-10");

			secondRange = new GenericRange<int>(3, 10);
			// the first Range is starting after the second range (-1)
			Assert.AreEqual(firstRange.CompareTo(secondRange), 1, "5-10 vs 3-10");

			secondRange = new GenericRange<int>(5, 8);
			// the first Range is starting after the second range (-1)
			Assert.AreEqual(firstRange.CompareTo(secondRange), 1, "5-10 vs 5-8");

			secondRange = new GenericRange<int>(5, 11);
			// the first Range is starting after the second range (-1)
			Assert.AreEqual(firstRange.CompareTo(secondRange), -1, "5-10 vs 5-11");

			secondRange = new GenericRange<int>(6, 8);
			// the first Range is starting after the second range (-1)
			Assert.AreEqual(firstRange.CompareTo(secondRange), -1, "5-10 vs 6-8");

		}
	}
}
