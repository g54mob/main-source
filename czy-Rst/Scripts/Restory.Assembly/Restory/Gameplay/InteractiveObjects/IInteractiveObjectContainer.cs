namespace Restory.Gameplay.InteractiveObjects
{
	public interface IInteractiveObjectContainer
	{
		bool IsEmpty { get; }

		InteractiveObject GetContainedObject();
	}
}
