using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class InventoryElement : MonoBehaviour
	{
		[SerializeField]
		protected Transform[] _itemParents;

		[SerializeField]
		protected InventoryItemUIElement _inventoryItemUIElementPrefab;

		[SerializeField]
		protected BaseInteractable3DUIView _emptyPrefab;

		protected GameObjectX _gox;

		protected List<Action<int>> _clickActions;

		[SerializeField]
		protected GameObject _reservedIconPrefab;

		protected GameObject[] _reservedIcon;

		public virtual GameObjectX Gox
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

		public virtual void UpdateInventory()
		{
		}

		public void AddItemClickEventHandler(Action<int> clickAction)
		{
		}

		private void ClearVisual(Transform parent, int index)
		{
		}

		protected void CreateVisual(Transform parent, GameItem gameItem, int index)
		{
		}

		public void SetReserved(int slot, GameItemTemplate item)
		{
		}
	}
}
