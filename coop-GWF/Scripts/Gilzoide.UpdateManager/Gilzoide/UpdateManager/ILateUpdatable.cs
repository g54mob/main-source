namespace Gilzoide.UpdateManager
{
	public interface ILateUpdatable : IManagedObject
	{
		void ManagedLateUpdate();
	}
}
