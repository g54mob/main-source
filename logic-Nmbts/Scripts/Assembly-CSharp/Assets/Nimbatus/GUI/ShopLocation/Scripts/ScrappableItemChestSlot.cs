using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class ScrappableItemChestSlot : MonoBehaviour
	{
		[HideInInspector]
		public bool Initiated;

		private ScrapableItem _item;

		public void Init(ScrapableItem item)
		{
			_item = item;
			item.transform.parent = base.transform;
			item.transform.localPosition = Vector3.zero;
			item.Background.gameObject.SetActive(false);
			Initiated = true;
		}

		public void Reset()
		{
			Object.Destroy(_item.gameObject);
			Initiated = false;
		}
	}
}
