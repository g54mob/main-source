namespace GRP
{
	public abstract class ProgressTask
	{
		public abstract string GetInfo();

		public abstract float GetProgress();

		public abstract bool IsActive();
	}
}
