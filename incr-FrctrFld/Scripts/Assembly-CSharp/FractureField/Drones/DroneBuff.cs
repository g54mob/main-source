namespace FractureField.Drones
{
	public class DroneBuff
	{
		public BuffType Type { get; set; }

		public float Multiplier { get; set; }

		public float RemainingDuration { get; set; }

		public bool IsPermanent { get; set; }

		public string Source { get; set; }

		public DroneBuffSourceType SourceType { get; set; }

		public bool IsExpired => false;

		public DroneBuff(BuffType type, float multiplier, float duration, string source, DroneBuffSourceType sourceType)
		{
		}

		public void FixedTick()
		{
		}
	}
}
