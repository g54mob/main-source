namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public struct UnityDateComponents
	{
		public Calendar Calendar { get; set; }

		public long Year { get; set; }

		public long Month { get; set; }

		public long Day { get; set; }

		public long Hour { get; set; }

		public long Minute { get; set; }

		public long Second { get; set; }

		public long Nanosecond { get; set; }

		public long DayOfWeek { get; set; }

		public long WeekOfMonth { get; set; }

		public long WeekOfYear { get; set; }

		public static implicit operator UnityDateComponents(DateComponents dateComponents)
		{
			return default(UnityDateComponents);
		}

		public static implicit operator DateComponents(UnityDateComponents dateComponents)
		{
			return null;
		}
	}
}
