using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class FoodWindowInventoryElement : InventoryElement
	{
		[SerializeField]
		public TextMeshPro OrderAmount;

		public override GameObjectX Gox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnInventoryChanged(object sender, EventArgs e)
		{
		}

		public new void UpdateInventory()
		{
		}
	}
}
