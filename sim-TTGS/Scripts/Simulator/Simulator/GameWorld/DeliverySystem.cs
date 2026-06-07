using UnityEngine;

namespace Simulator.GameWorld
{
	public class DeliverySystem : WorldManager
	{
		[SerializeField]
		private Transform m_deliveryPoint;

		[SerializeField]
		private float m_radius;

		public void Deliver(int uid, int quantity = 1)
		{
			if (TryGetShopBoxDataByUID(uid, out var data))
			{
				Deliver(data, quantity);
			}
		}

		public void Deliver(BaseShopBoxData data, int quantity)
		{
			if (!(data != null))
			{
				return;
			}
			if (data is ExtensionShopBoxData extensionShopBoxData)
			{
				if (extensionShopBoxData.ShopExtension)
				{
					ShopExtensionSystem.BuyNextShopExtension();
				}
				else if (extensionShopBoxData.ReserveExtension)
				{
					ShopExtensionSystem.BuyNextReserveExtension();
				}
			}
			else if (data.Prefab != null)
			{
				for (int i = 0; i < quantity; i++)
				{
					Object.Instantiate(data.Prefab, GetRandomDeliveryPosition(), Quaternion.identity).GetComponent<BaseBox>().Init(data);
				}
			}
		}

		public void DeliverBoxOfFurniture(Furniture furniture, int quantity)
		{
			foreach (FurnitureShopBoxData item in MarketStoreDatabase.Enumerate<FurnitureShopBoxData>())
			{
				if (item != null && item.Furniture != null && item.Furniture.UID == furniture.UID)
				{
					Deliver(item, quantity);
				}
			}
		}

		private bool TryGetShopBoxDataByUID(int uid, out BaseShopBoxData data)
		{
			return MarketStoreDatabase.TryGet(uid, out data);
		}

		private Vector3 GetRandomDeliveryPosition()
		{
			Vector3 position = m_deliveryPoint.position;
			return new Vector3(position.x + Random.Range(0f - m_radius, m_radius), position.y + Random.Range(0f - m_radius, m_radius), position.z + Random.Range(0f - m_radius, m_radius));
		}
	}
}
