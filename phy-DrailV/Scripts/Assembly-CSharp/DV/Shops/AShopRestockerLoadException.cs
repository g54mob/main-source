using UnityEngine;

namespace DV.Shops
{
	[DisallowMultipleComponent]
	public abstract class AShopRestockerLoadException : MonoBehaviour
	{
		protected ShopItemData data;

		public virtual void Initialize(ShopItemData data)
		{
			this.data = data;
		}

		public virtual void Uninitialize()
		{
			data = null;
		}

		public abstract void ModifyAmount();
	}
}
