using Restory.Gameplay.InteractiveObjects;
using Zenject;

namespace Restory.Gameplay.Shipment
{
	public class DecorPacker
	{
		private readonly ShipmentPackFactory shipmentPackFactory;

		[Inject]
		public DecorPacker(ShipmentPackFactory shipmentPackFactory)
		{
			this.shipmentPackFactory = shipmentPackFactory;
		}

		public DecorShipmentPack PackDecor(DecorObject decorObject)
		{
			DecorShipmentPack decorShipmentPack = shipmentPackFactory.CreatePack(decorObject.transform.parent);
			decorShipmentPack.Init(decorObject);
			decorShipmentPack.SetState(InteractiveObjectState.Stored);
			return decorShipmentPack;
		}

		public DecorObject UnpackDecor(DecorShipmentPack decorPack)
		{
			DecorObject decorObject = decorPack.DecorObject;
			decorObject.transform.SetParent(decorPack.transform.parent);
			decorObject.gameObject.SetActive(value: true);
			decorPack.Clear();
			shipmentPackFactory.DestroyPack(decorPack);
			return decorObject;
		}
	}
}
