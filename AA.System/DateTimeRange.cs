using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.System
{
	public class Period : GenericRange<DateTime>
	{
		public Period(DateTime start, DateTime end) : base(start, end)
		{
		}

		public static Period FullDay(DateTime date)
		{
			return new Period(new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0),
				new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999));
		}
	}
}
