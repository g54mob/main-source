using System;

namespace VoxelBusters.EssentialKit
{
	public class DatePickerResult
	{
		public DateTime? SelectedDate { get; private set; }

		internal DatePickerResult(DateTime? selectedDate)
		{
		}
	}
}
