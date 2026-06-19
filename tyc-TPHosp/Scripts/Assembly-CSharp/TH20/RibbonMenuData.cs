using UnityEngine;

namespace TH20
{
	public class RibbonMenuData : MonoBehaviour
	{
		public RibbonMenu.RibbonMenuSettings RibbonMenuSettings;

		[Header("Sub Menu Settings")]
		public RibbonMenuBuildState.Settings BuildStateSettings;

		public RibbonMenuItemsState.Settings ItemsStateSettings;

		public RibbonMenuHireState.Settings HireStateSettings;

		public RibbonMenuRoomsState.Settings RoomsStateSettings;
	}
}
