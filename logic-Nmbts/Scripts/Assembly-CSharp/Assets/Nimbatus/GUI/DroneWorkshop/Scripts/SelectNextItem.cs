using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class SelectNextItem : MonoBehaviour
	{
		public bool Backwards;

		public UICenterOnChild Center;

		public UIGrid Grid;

		public GameObject DisplayObject;

		private ItemSlot _selectedItem;

		private int _selectedIndex;

		private int _maxIndex;

		private bool _show;

		private ItemSlot[] _items;

		public void Update()
		{
			_show = (Backwards ? (_selectedIndex != 0) : (_selectedIndex != _maxIndex));
			DisplayObject.SetActive(_show);
			_items = Grid.transform.GetComponentsInChildren<ItemSlot>();
			_maxIndex = _items.Length - 1;
			if (!(Center.centeredObject != null))
			{
				return;
			}
			_selectedItem = Center.centeredObject.GetComponent<ItemSlot>();
			for (int i = 0; i < _items.Length; i++)
			{
				if (_items[i] == _selectedItem)
				{
					_selectedIndex = i;
				}
			}
		}

		public void OnClick()
		{
			if (Center.centeredObject != null && _show)
			{
				_selectedIndex = Math.Max(0, Math.Min(Backwards ? (_selectedIndex - 1) : (_selectedIndex + 1), _maxIndex));
				Center.CenterOn(_items[_selectedIndex].transform);
			}
		}
	}
}
