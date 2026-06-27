using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shipment
{
	public class ShipmentPackFactory
	{
		private readonly DragShipmentPackCustomPool dragPackPool;

		private readonly DecorShipmentPackPool decorPackPool;

		[Inject]
		public ShipmentPackFactory(DragShipmentPackCustomPool dragPackPool, DecorShipmentPackPool decorPackPool)
		{
			this.dragPackPool = dragPackPool;
			this.decorPackPool = decorPackPool;
		}

		public DragShipmentPack CreatePack()
		{
			return dragPackPool.GetPack();
		}

		public DecorShipmentPack CreatePack(Transform parent)
		{
			return decorPackPool.Get<DecorShipmentPack>(parent);
		}

		public void DestroyPack(DragShipmentPack pack)
		{
			dragPackPool.ReleasePack(pack);
		}

		public void DestroyPack(DecorShipmentPack pack)
		{
			decorPackPool.Release(pack);
		}
	}
}
