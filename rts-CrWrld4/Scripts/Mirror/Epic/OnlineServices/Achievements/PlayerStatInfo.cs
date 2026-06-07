namespace Epic.OnlineServices.Achievements
{
	public class PlayerStatInfo : ISettable
	{
		public string Name { get; set; }

		public int CurrentValue { get; set; }

		public int ThresholdValue { get; set; }

		internal void Set(PlayerStatInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
