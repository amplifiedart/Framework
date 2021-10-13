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

		public static Period Today
		{
			get { return Period.FullDay(DateTime.Now); }
		}

		public static Period ThisWeek
		{
			get
			{
				DateTime start = DateTime.Now;
				int dow = (int)start.DayOfWeek;

				dow = dow == 0 ? -6 : -(dow - 1);
				start = start.AddDays(dow);
				start = new DateTime(start.Year, start.Month, start.Day);
				DateTime end = start.AddDays(7).AddMilliseconds(-1);

				return new Period(start, end);
			}
		}

		public static Period ThisMonth
		{
			get
			{
				DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
				DateTime end = start.AddMonths(1).AddMilliseconds(-1);

				return new Period(start, end);
			}
		}

		public override string ToString()
		{
			return string.Format("{0:yyyy-MM-dd HH:mm:ss} - {1:yyyy-MM-dd HH:mm:ss}", Start, End);
		}
	}
}
