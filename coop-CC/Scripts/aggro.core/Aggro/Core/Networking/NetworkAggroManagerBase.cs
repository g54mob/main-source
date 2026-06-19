namespace Aggro.Core.Networking
{
	public abstract class NetworkAggroManagerBase<T> : NetworkEntityBehaviourBase, IAggroManager where T : NetworkAggroManagerBase<T>
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

		public override bool Weaved()
		{
			return true;
		}
	}
}
