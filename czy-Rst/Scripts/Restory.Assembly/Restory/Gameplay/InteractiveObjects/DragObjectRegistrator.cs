using System;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class DragObjectRegistrator : IDisposable
	{
		private InteractiveObject draggingObject;

		public InteractiveObject DraggingObject => draggingObject;

		public event Action OnInteractiveObjectStartDrag;

		public event Action OnTrashObjectStartDrag;

		public event Action<PersonalObjectBase> OnPersonalObjectStartDrag;

		public event Action OnInteractiveObjectStopDrag;

		public void RegisterDraggingObject(InteractiveObject draggingObject)
		{
			if (!draggingObject)
			{
				Debug.LogError("draggingObject is null on RegisterDraggingObject");
				return;
			}
			this.draggingObject = draggingObject;
			this.OnInteractiveObjectStartDrag?.Invoke();
			if (this.draggingObject.TryGetComponent<TrashObject>(out var _))
			{
				this.OnTrashObjectStartDrag?.Invoke();
			}
			if (this.draggingObject.TryGetComponent<PersonalObjectBase>(out var component2))
			{
				this.OnPersonalObjectStartDrag?.Invoke(component2);
			}
		}

		public void UnregisterDraggingObject()
		{
			draggingObject = null;
			this.OnInteractiveObjectStopDrag?.Invoke();
		}

		public void Dispose()
		{
			draggingObject = null;
			this.OnInteractiveObjectStartDrag = null;
			this.OnTrashObjectStartDrag = null;
			this.OnPersonalObjectStartDrag = null;
			this.OnInteractiveObjectStopDrag = null;
		}
	}
}
