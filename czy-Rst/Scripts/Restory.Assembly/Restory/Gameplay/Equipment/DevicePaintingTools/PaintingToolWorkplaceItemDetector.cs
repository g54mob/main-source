using System;
using Restory.Gameplay.DetectableObjects;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingToolWorkplaceItemDetector : IInitializable, IDisposable, IDetectableObject
	{
		private readonly PaintingToolWorkplaceItem paintingToolWorkplaceItem;

		public bool CanBeDetected
		{
			set
			{
				paintingToolWorkplaceItem.Trigger.enabled = value;
			}
		}

		public bool IsDetected { get; private set; }

		public PaintingToolWorkplaceItemDetector(PaintingToolWorkplaceItem paintingToolWorkplaceItem)
		{
			this.paintingToolWorkplaceItem = paintingToolWorkplaceItem;
		}

		public void Initialize()
		{
			paintingToolWorkplaceItem.Trigger.OnPointerEntered += ResolveCursorEnteredInventoryObject;
			paintingToolWorkplaceItem.Trigger.OnPointerExited += ResolveCursorExitedInventoryObject;
		}

		public void Dispose()
		{
			if (paintingToolWorkplaceItem.MonoShellExists())
			{
				paintingToolWorkplaceItem.Trigger.OnPointerEntered -= ResolveCursorEnteredInventoryObject;
				paintingToolWorkplaceItem.Trigger.OnPointerExited -= ResolveCursorExitedInventoryObject;
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
