using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class AddScrappableWeapon : MonoBehaviour
	{
		private UIButton _button;

		private Collider _collider;

		private ScrapableItem _item;

		public void Awake()
		{
			_button = GetComponent<UIButton>();
			_collider = GetComponent<Collider>();
		}

		public void Init(ScrapableItem item)
		{
			_item = item;
		}

		public void OnClick()
		{
			if (!(BaseSingleton<ScrapyardManager>.Instance == null) && !(_item == null))
			{
				BaseSingleton<ScrapyardManager>.Instance.AddItemToScrapper(_item);
			}
		}

		private void Update()
		{
			if (!(_button == null) && !(_collider == null))
			{
				if (_item != null && _item.HasAvailableStacks())
				{
					_button.SetState(UIButtonColor.State.Normal, true);
					_collider.enabled = true;
				}
				else
				{
					_button.SetState(UIButtonColor.State.Disabled, true);
					_collider.enabled = false;
				}
			}
		}
	}
}
