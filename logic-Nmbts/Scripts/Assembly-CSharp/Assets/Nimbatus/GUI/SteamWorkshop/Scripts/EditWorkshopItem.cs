using Assets.Nimbatus.Scripts.Workshop;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class EditWorkshopItem : MonoBehaviour
	{
		private WorkshopItemResult _item;

		private DroneWorkshopInformation _parent;

		private bool _hover;

		public void Init(DroneWorkshopInformation parent, WorkshopItemResult item)
		{
			_item = item;
			_parent = parent;
		}

		public void OnClick()
		{
			_parent.EditItem(_item);
		}
	}
}
