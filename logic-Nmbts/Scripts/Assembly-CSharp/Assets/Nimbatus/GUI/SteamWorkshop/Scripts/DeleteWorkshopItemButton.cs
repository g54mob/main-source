using Assets.Nimbatus.Scripts.Workshop;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class DeleteWorkshopItemButton : MonoBehaviour
	{
		private WorkshopItemResult _item;

		private DroneWorkshopInformation _parent;

		public void Init(DroneWorkshopInformation parent, WorkshopItemResult item)
		{
			_item = item;
			_parent = parent;
		}

		public void OnClick()
		{
			if (_item != null && !(_parent == null))
			{
				StartCoroutine(_parent.DeleteItem(_item));
			}
		}
	}
}
