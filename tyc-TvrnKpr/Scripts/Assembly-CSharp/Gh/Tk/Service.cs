namespace Gh.Tk
{
	public abstract class Service : AttachedBehaviour
	{
		public bool isServiceEnabled;

		public virtual bool CanUse(Actor actor)
		{
			return false;
		}
	}
}
