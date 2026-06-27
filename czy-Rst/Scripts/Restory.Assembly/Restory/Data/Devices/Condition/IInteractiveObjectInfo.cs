using Restory.Gameplay.InteractiveObjects;

namespace Restory.Data.Devices.Condition
{
	public interface IInteractiveObjectInfo
	{
		string ID { get; }

		InteractiveObject Prefab { get; }
	}
}
