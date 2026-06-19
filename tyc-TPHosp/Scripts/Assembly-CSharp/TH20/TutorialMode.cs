namespace TH20
{
	public abstract class TutorialMode : MustCallDestroy
	{
		protected Level Level;

		public void SetLevel(Level level)
		{
			Level = level;
		}

		public virtual void Enter()
		{
		}

		public virtual void Update()
		{
		}
	}
}
