using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine.Events;

namespace Kamgam.SettingsGenerator
{
	public class SettingKeyCombinationEvent : SettingEvent<KeyCombination>
	{
		[NonSerialized]
		protected KeyCombination _combo;

		public UnityEvent<KeyCombination> OnDown;

		public UnityEvent<KeyCombination> OnUp;

		public UnityEvent<KeyCombination> OnHold;

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			if (_supportedDataTypes == null)
			{
				_supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.KeyCombination };
			}
			return _supportedDataTypes;
		}

		public override void TriggerEvent()
		{
			if (HasActiveSettingForID(ID))
			{
				ISetting setting = GetSetting();
				if (setting != null && setting.GetDataType() == SettingData.DataType.KeyCombination)
				{
					KeyCombination value = SettingsProvider.Settings.GetKeyCombination(ID).GetValue();
					OnValueChanged?.Invoke(value);
					_combo = value;
				}
			}
		}

		public void Update()
		{
			if (OnDown != null && (InputUtils.GetUniversalKeyDown(_combo.ModifierKey) || _combo.ModifierKey == UniversalKeyCode.None || _combo.ModifierKey == UniversalKeyCode.Unknown) && InputUtils.GetUniversalKeyDown(_combo.Key))
			{
				OnDown?.Invoke(_combo);
			}
			if (OnUp != null && (InputUtils.GetUniversalKeyUp(_combo.ModifierKey) || _combo.ModifierKey == UniversalKeyCode.None || _combo.ModifierKey == UniversalKeyCode.Unknown) && InputUtils.GetUniversalKeyUp(_combo.Key))
			{
				OnUp?.Invoke(_combo);
			}
			if (OnHold != null && (InputUtils.GetUniversalKey(_combo.ModifierKey) || _combo.ModifierKey == UniversalKeyCode.None || _combo.ModifierKey == UniversalKeyCode.Unknown) && InputUtils.GetUniversalKey(_combo.Key))
			{
				OnHold?.Invoke(_combo);
			}
		}
	}
}
