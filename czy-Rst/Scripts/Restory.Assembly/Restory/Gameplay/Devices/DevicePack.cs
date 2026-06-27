using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public abstract class DevicePack : InteractiveObject, IDevicePackage
	{
		public override bool IsPlaceable => true;

		public DeviceContainer DeviceContainer { get; protected set; }

		public virtual void Clear()
		{
			DeviceContainer = null;
		}

		public override void SetState(InteractiveObjectState state)
		{
			base.SetState(state);
			if (!DeviceContainer)
			{
				Debug.LogError("Failed to find DeviceContainer");
				return;
			}
			SetPackState();
			DeviceContainer.SetState(state);
		}

		public override void CompleteDrag()
		{
			base.CompleteDrag();
			if ((bool)DeviceContainer)
			{
				DeviceContainer.CompleteDrag();
			}
		}

		protected virtual void SetPackState()
		{
		}
	}
}
