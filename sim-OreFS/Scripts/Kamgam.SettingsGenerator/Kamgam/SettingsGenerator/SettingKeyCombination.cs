using System;
using System.Collections.Generic;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingKeyCombination : SettingWithValue<KeyCombination>, ISettingWithConnection<KeyCombination>, ISettingWithValue<KeyCombination>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.KeyCombination;

		[NonSerialized]
		public IConnection<KeyCombination> Connection;

		[SerializeField]
		private KeyCombinationConnectionSO ConnectionObject;

		[NonSerialized]
		protected KeyCombination _keyCombination;

		protected bool _valueInitialized;

		public event Action<SettingKeyCombination> OnSettingKeyCombinationChanged;

		public event Action<KeyCombination> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as KeyCombinationConnectionSO;
		}

		public override KeyCombination GetValue()
		{
			return _keyCombination;
		}

		public override void SetValue(KeyCombination keyCombination, bool propagateChange = true)
		{
			if (_keyCombination.Equals(keyCombination) && _valueInitialized)
			{
				return;
			}
			_valueInitialized = true;
			_keyCombination = keyCombination;
			if (propagateChange)
			{
				OnChanged();
				if (ApplyImmediately)
				{
					PushToConnection();
				}
			}
		}

		public SettingKeyCombination(SettingData data, List<string> groups = null)
			: base(data, groups)
		{
		}

		public SettingKeyCombination(string path, KeyCombination keyCombination, List<string> groups = null)
			: base(path, groups)
		{
			_defaultValue = keyCombination;
			SetValue(keyCombination);
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingKeyCombinationChanged?.Invoke(this);
			this.OnValueChanged?.Invoke(GetValue());
		}

		public override void ResetToDefault()
		{
			SetValue(_defaultValue);
			if (HasConnection() && ApplyImmediately)
			{
				PushToConnection();
			}
		}

		public override object GetValueAsObject()
		{
			return GetValue();
		}

		public override void SetValueFromObject(object value, bool propagateChange = true)
		{
			SetValue((KeyCombination)value, propagateChange);
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.KeyCombination;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.KeyCombination);
			KeyCombination value = GetValue();
			settingData.IntValues = new int[2]
			{
				(int)value.Key,
				(int)value.ModifierKey
			};
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.KeyCombination))
			{
				KeyCombination value = new KeyCombination((UniversalKeyCode)data.IntValues[0], (UniversalKeyCode)data.IntValues[1]);
				SetValue(value, propagateChange: false);
			}
		}

		public override bool HasConnection()
		{
			return Connection != null;
		}

		public override bool HasConnectionObject()
		{
			return ConnectionObject != null;
		}

		public override void PullFromConnection()
		{
			PullFromConnection(propagateChange: false);
		}

		public override void PullFromConnection(bool propagateChange)
		{
			if (HasConnection())
			{
				SetValue(Connection.Get(), propagateChange);
				invokePulledFromConnectionListeners();
			}
		}

		public override void PushToConnection()
		{
			base.PushToConnection();
			if (HasConnection())
			{
				Connection.Set(GetValue());
			}
		}

		public override int GetConnectionOrder()
		{
			if (HasConnection())
			{
				return Connection.GetOrder();
			}
			return 0;
		}

		public void SetConnection(IConnection<KeyCombination> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
			}
		}

		public IConnection<KeyCombination> GetConnection()
		{
			return Connection;
		}

		public override IConnection GetConnectionInterface()
		{
			return Connection;
		}

		public override void OnQualityChanged(int qualityLevel)
		{
			if (HasConnection())
			{
				Connection.OnQualityChanged(qualityLevel);
			}
		}
	}
}
