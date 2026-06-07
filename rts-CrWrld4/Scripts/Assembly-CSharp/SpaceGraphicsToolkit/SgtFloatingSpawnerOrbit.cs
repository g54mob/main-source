namespace SpaceGraphicsToolkit
{
	public class SgtFloatingSpawnerOrbit : SgtFloatingSpawner
	{
		public int Count;

		public float TiltMax;

		public float OblatenessMax;

		public SgtLength RadiusMin;

		public SgtLength RadiusMax;

		protected virtual void OnEnable()
		{
		}
	}
}
