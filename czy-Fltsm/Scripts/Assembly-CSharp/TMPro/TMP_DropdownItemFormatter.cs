using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TMPro
{
	public abstract class TMP_DropdownItemFormatter : MonoBehaviour
	{
		[Header("Dropdown Item Formatter")]
		[SerializeField]
		private TMP_Dropdown _dropdown;

		[SerializeField]
		private LocalizedString _defaultLabel;

		[SerializeField]
		private bool _hideDefaultLabel = true;

		private List<TMP_DropdownFormatableItem> _items = new List<TMP_DropdownFormatableItem>();

		private TMP_DropdownFormatableItem _firstItem;

		private bool _updateSelected;

		public int SelectedIndex => _dropdown.value - 1;

		protected virtual void OnEnable()
		{
			_dropdown.onValueChanged.AddListener(OnValueChanged);
		}

		private void LateUpdate()
		{
			if (_updateSelected)
			{
				int selectedIndex = SelectedIndex;
				_updateSelected = false;
				if (0 <= selectedIndex && selectedIndex < _items.Count && _items[selectedIndex].IsSelected())
				{
					return;
				}
				for (int i = 0; i < _items.Count; i++)
				{
					TMP_DropdownFormatableItem tMP_DropdownFormatableItem = _items[i];
					if (tMP_DropdownFormatableItem.Interactable)
					{
						tMP_DropdownFormatableItem.Select();
						return;
					}
				}
			}
			if (_dropdown.IsExpanded && FlotsamInputManager.GetUICancel(ignoreAllowCancel: true) && !HasSelectedItem())
			{
				_dropdown.OnCancel(null);
			}
		}

		protected virtual void OnDisable()
		{
			_dropdown.onValueChanged.RemoveListener(OnValueChanged);
		}

		public void Initialize(List<string> options)
		{
			options.Insert(0, _defaultLabel);
			_dropdown.ClearOptions();
			_dropdown.AddOptions(options);
		}

		public void OnItemEnabled(TMP_DropdownFormatableItem item)
		{
			if ((bool)_firstItem)
			{
				_updateSelected = true;
				_items.Add(item);
				AddItem(item);
				return;
			}
			_firstItem = item;
			if (_hideDefaultLabel)
			{
				_firstItem.Hide();
			}
		}

		public void OnItemDisabled(TMP_DropdownFormatableItem item)
		{
			if (!(item == _firstItem))
			{
				_items.Remove(item);
				RemoveItem(item);
			}
		}

		protected abstract void AddItem(TMP_DropdownFormatableItem item);

		protected abstract void RemoveItem(TMP_DropdownFormatableItem item);

		protected void ClearSelectedIndex()
		{
			_dropdown.value = 0;
		}

		protected void SetSelectedIndexWithoutNotify(int index)
		{
			int num = index + 1;
			if (0 <= num && num < _dropdown.options.Count)
			{
				_dropdown.SetValueWithoutNotify(num);
			}
		}

		protected virtual void OnSelectedIndexChanged(int selectedIndex)
		{
		}

		private void OnValueChanged(int value)
		{
			OnSelectedIndexChanged(value - 1);
		}

		private bool HasSelectedItem()
		{
			foreach (TMP_DropdownFormatableItem item in _items)
			{
				if (item.IsSelected())
				{
					return true;
				}
			}
			return false;
		}
	}
}
