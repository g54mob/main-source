namespace KitchenData
{
	public readonly struct ApplianceProcessPair
	{
		public readonly int Process;

		public readonly bool IsAutomatic;

		public readonly float Speed;

		public readonly bool IsBad;

		public ApplianceProcessPair(int process, bool is_automatic, float speed, bool is_bad)
		{
			Process = process;
			IsAutomatic = is_automatic;
			Speed = speed;
			IsBad = is_bad;
		}
	}
}
