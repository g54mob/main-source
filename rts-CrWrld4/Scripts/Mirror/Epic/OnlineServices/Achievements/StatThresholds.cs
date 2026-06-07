namespace Epic.OnlineServices.Achievements
{
	public class StatThresholds : ISettable
	{
		public string Name { get; set; }

		public int Threshold { get; set; }

		internal void Set(StatThresholdsInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
