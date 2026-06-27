using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Storages;
using UnityEngine;

namespace Restory.Gameplay.Work.Dragging
{
	public class DragObjectInitialDataHolder
	{
		public Transform Parent { get; private set; }

		public DevicesStorage DevicesStorage { get; private set; }

		public InteractiveObjectState State { get; private set; }

		public Vector3 Position { get; private set; }

		public Quaternion Rotation { get; private set; }

		public bool IsNonStorableObject { get; private set; }

		public bool IsTrashObject { get; private set; }

		public void Init(InteractiveObject draggedObject)
		{
			Parent = draggedObject.transform.parent;
			DevicesStorage = Parent.GetComponentInParent<DevicesStorage>();
			State = draggedObject.State;
			Position = draggedObject.transform.position;
			Rotation = draggedObject.transform.rotation;
			IsNonStorableObject = CheckIfNonStorableObject(draggedObject);
			IsTrashObject = CheckIfTrashObject(draggedObject);
		}

		private bool CheckIfNonStorableObject(InteractiveObject interactiveObject)
		{
			NonStorableObject component;
			return interactiveObject.TryGetComponent<NonStorableObject>(out component);
		}

		private bool CheckIfTrashObject(InteractiveObject interactiveObject)
		{
			TrashObject component;
			return interactiveObject.TryGetComponent<TrashObject>(out component);
		}

		public void Cleanup()
		{
			Parent = null;
			DevicesStorage = null;
		}
	}
}
