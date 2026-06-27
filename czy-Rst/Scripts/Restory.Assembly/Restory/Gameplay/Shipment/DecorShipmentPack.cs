using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class DecorShipmentPack : InteractiveObject, IShipmentPack
	{
		[SerializeField]
		private ShipmentPackLabel packLabel;

		public override bool IsPlaceable => false;

		public DecorObject DecorObject { get; private set; }

		public Transform Transform => base.transform;

		public void Init(DecorObject decorObject)
		{
			base.transform.SetPositionAndRotation(decorObject.transform.position, decorObject.transform.rotation);
			decorObject.transform.SetParent(base.transform);
			decorObject.gameObject.SetActive(value: false);
			DecorObject = decorObject;
			packLabel.Init(decorObject.Info.Icon);
		}

		public void Clear()
		{
			DecorObject = null;
		}

		public override void SetState(InteractiveObjectState state)
		{
			base.SetState(state);
			if (!DecorObject)
			{
				Debug.LogError("Failed to find DecorObject");
			}
			else
			{
				DecorObject.InteractiveObject.SetState(state);
			}
		}

		public override void CompleteDrag()
		{
			base.CompleteDrag();
			if ((bool)DecorObject)
			{
				DecorObject.InteractiveObject.CompleteDrag();
			}
		}
	}
}
