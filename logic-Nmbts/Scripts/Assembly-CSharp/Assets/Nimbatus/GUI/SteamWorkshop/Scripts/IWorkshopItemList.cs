using Assets.Nimbatus.Scripts.Workshop;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public interface IWorkshopItemList
	{
		[HideInInspector]
		WorkshopItemResult SelectedItem { get; set; }

		void SelectItem(WorkshopItemResult item);
	}
}
