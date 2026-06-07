using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CTS
{
	public class CocktailCrafter : MonoBehaviour
	{
		[SerializeField]
		private IngredientSlot[] _slots;

		[SerializeField]
		private TMP_Text _debugText;

		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private TMP_InputField _nameTextField;

		[SerializeField]
		private Button _confirmButton;

		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private List<string> _invalidCocktailsNames;

		[SerializeField]
		private Color _validNameColor;

		[SerializeField]
		private Color _invalidNameColor;

		private List<StockItemSO> _itemList = new List<StockItemSO>();

		private List<Cocktail> createdCocktails = new List<Cocktail>();

		public static event Action<List<StockItemSO>> OnItemListchanged;

		public static event Action<bool> OnCrafterOpen;

		private void Start()
		{
			for (int i = 0; i < _slots.Length; i++)
			{
				_slots[i].OnItemSlotChanged += OnItemSlotChanged;
			}
			UnlockButton(p_unlock: false, _confirmButton, OnConfirmCraft);
			UnlockButton(p_unlock: false, _resetButton, OnResetCraft);
			_nameTextField.onValueChanged.AddListener(OnEditName);
			_nameTextField.onSelect.AddListener(LockCamera);
			_nameTextField.onDeselect.AddListener(UnlockCamera);
		}

		private void OnEnable()
		{
			CocktailCrafter.OnCrafterOpen?.Invoke(obj: true);
		}

		private void OnDisable()
		{
			CocktailCrafter.OnCrafterOpen?.Invoke(obj: false);
		}

		private void OnDestroy()
		{
			for (int i = 0; i < _slots.Length; i++)
			{
				_slots[i].OnItemSlotChanged -= OnItemSlotChanged;
			}
		}

		private void LockCamera(string _p)
		{
			MonoSingleton<CameraTravelingHandler>.Instance.LockAll(p_toLockAll: true);
		}

		private void UnlockCamera(string _p)
		{
			MonoSingleton<CameraTravelingHandler>.Instance.LockAll(p_toLockAll: false);
		}

		private void OnItemSlotChanged(bool p_added, SlotableItem p_slotableItem)
		{
			if (p_added)
			{
				if (!_itemList.Contains(p_slotableItem.Item))
				{
					_itemList.Add(p_slotableItem.Item);
				}
			}
			else if (_itemList.Contains(p_slotableItem.Item))
			{
				_itemList.Remove(p_slotableItem.Item);
			}
			UnlockButton(_itemList.Count >= 2, _confirmButton, OnConfirmCraft);
			UnlockButton(_itemList.Count > 0, _resetButton, OnResetCraft);
			UpdateDebugText();
			CocktailCrafter.OnItemListchanged?.Invoke(_itemList);
		}

		private void UpdateDebugText()
		{
			string text = "";
			for (int i = 0; i < _itemList.Count; i++)
			{
				text = text + _itemList[i].Name + "\n";
			}
			_debugText.text = text;
		}

		private void UnlockButton(bool p_unlock, Button p_button, UnityAction p_buttonEvent)
		{
			p_button.interactable = p_unlock;
			if (p_unlock)
			{
				p_button.onClick.AddListener(p_buttonEvent);
				p_button.GetComponentInChildren<TMP_Text>().color = Color.white;
			}
			else
			{
				p_button.onClick.RemoveListener(p_buttonEvent);
				p_button.GetComponentInChildren<TMP_Text>().color = new Color(0.18f, 0.18f, 0.18f);
			}
		}

		private void OnConfirmCraft()
		{
			if (ConfirmName(_nameText.text))
			{
				Cocktail item = new Cocktail
				{
					Name = _nameText.text,
					Composition = _itemList.ToArray()
				};
				createdCocktails.Add(item);
			}
		}

		private void OnEditName(string p_nameEdit)
		{
			if (ConfirmName(p_nameEdit))
			{
				_nameText.color = _validNameColor;
			}
			else
			{
				_nameText.color = _invalidNameColor;
			}
		}

		private bool ConfirmName(string p_name)
		{
			if (string.IsNullOrEmpty(p_name))
			{
				ShowWarning("Empty name");
				return false;
			}
			if (_invalidCocktailsNames.Contains(p_name.ToUpper()))
			{
				ShowWarning("Invalid Name");
				return false;
			}
			for (int i = 0; i < createdCocktails.Count; i++)
			{
				if (createdCocktails[i].Name == p_name)
				{
					ShowWarning("Name was already used");
					return false;
				}
			}
			return true;
		}

		private void ShowWarning(string _text)
		{
			Debug.Log(_text);
		}

		private void OnResetCraft()
		{
			for (int i = 0; i < _slots.Length; i++)
			{
				_slots[i].ItemSlotted?.DropSlotable();
			}
		}
	}
}
