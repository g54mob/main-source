namespace Gilzoide.UpdateManager
{
	public static class IUpdatableExtensions
	{
		public static void RegisterInManager(this IManagedObject updatable)
		{
			UpdateManager.Instance.Register(updatable);
		}

		public static void UnregisterInManager(this IManagedObject updatable)
		{
			UpdateManager.Instance.Unregister(updatable);
		}
	}
}
