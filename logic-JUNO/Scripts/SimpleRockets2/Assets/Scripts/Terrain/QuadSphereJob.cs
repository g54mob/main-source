namespace Assets.Scripts.Terrain
{
	public abstract class QuadSphereJob
	{
		public abstract void Complete();

		public abstract void Process();

		public abstract void CancelJob(bool isMainThread);
	}
}
