namespace Assets.Scripts.Terrain
{
	public class QuadSphereStats
	{
		public double QuadGenerationTimeAverage { get; set; }

		public double QuadGenerationTimeMax { get; set; }

		public double QuadGenerationTimeMin { get; set; }

		public int QuadsCreated { get; set; }

		public int QuadsDrawn { get; set; }

		public int QuadsLoaded { get; set; }

		public int[] QuadsLoadedPerLevel { get; set; }
	}
}
