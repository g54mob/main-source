namespace Aggro.Core
{
	public class AggroManagerBase<T> : EntityBehaviourBase, IAggroManager where T : AggroManagerBase<T>
	{
		public static T instance { get; private set; }

		public void SetAsManager()
		{
			instance = (T)this;
		}

		public static bool ManagerExists()
		{
			return instance != null;
		}
	}
}
