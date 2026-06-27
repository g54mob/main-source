using System;
using Restory.Gameplay.DetectableObjects;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class InventoryBoxDetector : IInitializable, IDisposable, IDetectableObject
	{
		private readonly InventoryBox inventoryObject;

		public bool CanBeDetected
		{
			set
			{
				inventoryObject.Trigger.enabled = value;
			}
		}

		public bool IsDetected { get; private set; }

		public InventoryBoxDetector(InventoryBox inventoryObject)
		{
			this.inventoryObject = inventoryObject;
		}

		public void Initialize()
		{
			inventoryObject.Trigger.OnPointerEntered += ResolveCursorEnteredInventoryObject;
			inventoryObject.Trigger.OnPointerExited += ResolveCursorExitedInventoryObject;
		}

		public void Dispose()
		{
			if (inventoryObject.MonoShellExists())
			{
				inventoryObject.Trigger.OnPointerEntered -= ResolveCursorEnteredInventoryObject;
				inventoryObject.Trigger.OnPointerExited -= ResolveCursorExitedInventoryObject;
			}
		}

		private void ResolveCursorEnteredInventoryObject()
		{
			IsDetected = true;
		}

		private void ResolveCursorExitedInventoryObject()
		{
			IsDetected = false;
		}
	}
}
