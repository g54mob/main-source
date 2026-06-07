using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class CraftingPropInfoPanel : PropInfoPanel
	{
		[SerializeField]
		private InventoryItemUIElement _outputItem;

		[SerializeField]
		private GameObject _noOutputItemStateParent;

		public override void Start()
		{
		}

		public override void Refresh()
		{
		}
	}
}
