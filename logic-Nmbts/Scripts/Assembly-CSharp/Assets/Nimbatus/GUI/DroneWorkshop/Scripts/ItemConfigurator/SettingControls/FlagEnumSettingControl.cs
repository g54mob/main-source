using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.SettingControls
{
	public class FlagEnumSettingControl : MonoBehaviour
	{
		public UILabel Name;

		public UILabel ButtonLabel;

		public GameObject Options;

		public UIGrid Optionsgrid;

		public UISprite OptionsBackground;

		public EnumFlagItem ItemPrefab;

		private FieldInfo _fieldInfo;

		private UndoManager.EStoreReason _storeReason;

		private List<EnumFlagItem> _items;

		private List<DronePart> _parentObjects;

		public void Init(string title, FieldInfo fieldInfo, List<DronePart> parentObjects, UndoManager.EStoreReason storeReason, int rows)
		{
			_items = new List<EnumFlagItem>();
			Type fieldType = fieldInfo.FieldType;
			Enum keys = (Enum)fieldInfo.GetValue(parentObjects[0]);
			_fieldInfo = fieldInfo;
			_parentObjects = parentObjects;
			_storeReason = storeReason;
			Optionsgrid.cellHeight = ItemPrefab.Label.height;
			if (rows > 0)
			{
				Optionsgrid.maxPerLine = rows;
			}
			int num = 0;
			foreach (Enum enumValue in Enum.GetValues(fieldType))
			{
				if (EnumHelper.Popcount(Convert.ToInt32(enumValue)) <= 1)
				{
					EnumFlagItem enumFlagItem = UnityEngine.Object.Instantiate(ItemPrefab);
					bool hasFlag = keys.Contains(enumValue);
					bool isUnkown = !_parentObjects.TrueForAll((DronePart i) => IsActive(i, enumValue) == hasFlag);
					enumFlagItem.Init(this, enumValue, hasFlag, isUnkown);
					enumFlagItem.transform.parent = Optionsgrid.transform;
					enumFlagItem.transform.localScale = Vector3.one;
					_items.Add(enumFlagItem);
					num++;
				}
			}
			Options.SetActive(false);
			int num2 = ((num > Optionsgrid.maxPerLine) ? Optionsgrid.maxPerLine : num);
			OptionsBackground.height = (int)((float)(num2 * ItemPrefab.Label.height) + (float)ItemPrefab.Label.height / 2f);
			OptionsBackground.width = ((num > Optionsgrid.maxPerLine) ? (OptionsBackground.width * 2) : OptionsBackground.width);
			Optionsgrid.Reposition();
			Name.text = title + ":";
			UpdateButtonLabel();
		}

		public void OnDisable()
		{
			if (Options.activeSelf)
			{
				Options.SetActive(false);
			}
		}

		public void OnTooltip(bool show)
		{
			if (Name.processedText != Name.text)
			{
				NimbatusToolTip.Show(Name.text, show);
			}
		}

		private void UpdateButtonLabel()
		{
			int num = 0;
			Type fieldType = _fieldInfo.FieldType;
			Enum keys = (Enum)_fieldInfo.GetValue(_parentObjects[0]);
			foreach (Enum enumValue in Enum.GetValues(fieldType))
			{
				bool hasFlag = keys.Contains(enumValue);
				if (!_parentObjects.TrueForAll((DronePart i) => IsActive(i, enumValue) == hasFlag))
				{
					ButtonLabel.text = "?";
					break;
				}
				if (EnumHelper.Popcount(Convert.ToInt32(enumValue)) <= 1 && hasFlag)
				{
					if (num == 0)
					{
						ButtonLabel.text = enumValue.ToLocalizationString();
					}
					else
					{
						UILabel buttonLabel = ButtonLabel;
						buttonLabel.text = buttonLabel.text + " | " + enumValue.ToLocalizationString();
					}
					num++;
				}
			}
			ButtonLabel.UpdateNGUIText();
		}

		public void ToggleOptions()
		{
			bool active = !Options.activeInHierarchy;
			Options.SetActive(active);
		}

		public bool IsToggled()
		{
			return Options.activeInHierarchy;
		}

		public void SetActive(Enum value, bool isActive)
		{
			foreach (DronePart parentObject in _parentObjects)
			{
				if (Convert.ToUInt32(value) == 0 && isActive)
				{
					_fieldInfo.SetValue(parentObject, 0);
					continue;
				}
				object value2 = ((Enum)_fieldInfo.GetValue(parentObject)).SetFlag(value, isActive);
				_fieldInfo.SetValue(parentObject, value2);
			}
			if (_parentObjects.Count == 1)
			{
				BaseSingleton<UndoManager>.Instance.Store(_storeReason, _parentObjects[0]);
			}
			else
			{
				BaseSingleton<UndoManager>.Instance.Store(_storeReason);
			}
			UpdateButtonLabel();
			foreach (EnumFlagItem item in _items)
			{
				bool active = IsActive(_parentObjects[0], item.EnumValue);
				bool unknown = !_parentObjects.TrueForAll((DronePart i) => IsActive(i, item.EnumValue) == active);
				item.UpdateCheckmark(active, unknown);
			}
		}

		private bool IsActive(DronePart part, Enum value)
		{
			return ((Enum)_fieldInfo.GetValue(part)).Contains(value);
		}
	}
}
