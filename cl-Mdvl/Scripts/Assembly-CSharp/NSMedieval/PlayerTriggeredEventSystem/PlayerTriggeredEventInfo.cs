namespace NSMedieval.PlayerTriggeredEventSystem
{
	public readonly struct PlayerTriggeredEventInfo
	{
		public string Label { get; }

		public string Status { get; }

		public string Points { get; }

		public PlayerTriggeredEventInfo(string label, string status, string points)
		{
			Label = label;
			Status = status;
			Points = points;
		}
	}
}
