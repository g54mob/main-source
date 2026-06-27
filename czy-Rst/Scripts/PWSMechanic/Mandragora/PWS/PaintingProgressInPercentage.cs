namespace Mandragora.PWS
{
	public struct PaintingProgressInPercentage
	{
		public float PaintedArea;

		public float RedChannel;

		public float GreenChannel;

		public float BlueChannel;

		public float AverageProgress => (RedChannel + GreenChannel + BlueChannel) / 3f;

		public static PaintingProgressInPercentage ZeroProgress => new PaintingProgressInPercentage
		{
			PaintedArea = 0f,
			RedChannel = 0f,
			GreenChannel = 0f,
			BlueChannel = 0f
		};

		public static PaintingProgressInPercentage FullProgress => new PaintingProgressInPercentage
		{
			PaintedArea = 1f,
			RedChannel = 1f,
			GreenChannel = 1f,
			BlueChannel = 1f
		};

		public bool IsFullyPainted()
		{
			return PaintedArea >= 1f;
		}

		public override string ToString()
		{
			return $"Progress: PaintedArea = {PaintedArea} | RedChannel = {RedChannel} | GreenChannel = {GreenChannel} | BlueChannel = {BlueChannel} " + $"| AverageProgress = {AverageProgress} |  IsFullyPainted = {IsFullyPainted()}";
		}
	}
}
