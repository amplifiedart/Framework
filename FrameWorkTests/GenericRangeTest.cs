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

		[TestMethod]
		public void RangeMatchRangeTest()
		{
			GenericRange<int> target = new GenericRange<int>(6, 14);

			GenericRange<int>[] testRanges = SetUpTestRanges();

			Assert.AreEqual(target.Match(testRanges[0]), RangeMatchType.OutsideBefore, "(1,4) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[1]), RangeMatchType.EndsIn, "(3,7) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[2]), RangeMatchType.Head, "(6,10) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[3]), RangeMatchType.Equal, "(6,14) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[4]), RangeMatchType.PartOf, "(8,12) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[5]), RangeMatchType.Tail, "(10,14) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[6]), RangeMatchType.StartsIn, "(12,17) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[7]), RangeMatchType.OutsideAfter, "(16,19) is outside and before (6,14)");
			Assert.AreEqual(target.Match(testRanges[8]), RangeMatchType.Overlap, "(1,19) is outside and before (6,14)");
		}

		[TestMethod]
		public void RangeMatchValueTest()
		{
			GenericRange<int> target = new GenericRange<int>(6, 14);

			Assert.AreEqual(target.Match(2), RangeMatchType.OutsideBefore, "2 is outside and before (6,14)");
			Assert.AreEqual(target.Match(6), RangeMatchType.Head, "6 is part of (6,14)");
			Assert.AreEqual(target.Match(9), RangeMatchType.PartOf, "9 is part of (6,14)");
			Assert.AreEqual(target.Match(14), RangeMatchType.Tail, "14 is part of (6,14)");
			Assert.AreEqual(target.Match(17), RangeMatchType.OutsideAfter, "17 is outside and after (6,14)");
		}

		private GenericRange<int>[] SetUpTestRanges()
		{
			GenericRange<int>[] result = new GenericRange<int>[]
			{
				new GenericRange<int>(1,4),
				new GenericRange<int>(3,7),
				new GenericRange<int>(6,10),
				new GenericRange<int>(6,14),
				new GenericRange<int>(8,12),
				new GenericRange<int>(10,14),
				new GenericRange<int>(12,17),
				new GenericRange<int>(16,19),
				new GenericRange<int>(1,19)
			};

			return result;
		}
	}
}
