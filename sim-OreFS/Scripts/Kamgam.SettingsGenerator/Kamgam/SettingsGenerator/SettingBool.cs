using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingBool : SettingWithValue<bool>, ISettingWithConnection<bool>, ISettingWithValue<bool>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.Bool;

		[NonSerialized]
		public IConnection<bool> Connection;

		[SerializeField]
		private BoolConnectionSO ConnectionObject;

		[NonSerialized]
		protected bool _value;

		protected bool _valueInitialized;

		public event Action<SettingBool> OnSettingBoolChanged;

		public event Action<bool> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as BoolConnectionSO;
		}

		public override bool GetValue()
		{
			return _value;
		}

		public override void SetValue(bool value, bool propagateChange = true)
		{
			if (_value == value && _valueInitialized)
			{
				return;
			}
			_valueInitialized = true;
			_value = value;
			if (propagateChange)
			{
				OnChanged();
				if (ApplyImmediately)
				{
					PushToConnection();
				}
			}
		}

		public SettingBool(SettingData data, List<string> groups = null)
			: base(data, groups)
		{
		}

		public SettingBool(string path, bool value, List<string> groups = null)
			: base(path, groups)
		{
			SetValue(value);
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingBoolChanged?.Invoke(this);
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
			SetValue((bool)value, propagateChange);
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.Bool;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.Bool);
			settingData.IntValues = new int[1] { GetValue() ? 1 : 0 };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.Bool))
			{
				SetValue(data.IntValues[0] == 1, propagateChange: false);
			}
		}

		protected void extractConnectionFromObject()
		{
			if (Connection == null && ConnectionObject != null)
			{
				IConnectionSO<IConnection<bool>> connectionObject = ConnectionObject;
				if (connectionObject != null)
				{
					Connection = connectionObject.GetConnection();
				}
			}
		}

		public override bool HasConnection()
		{
			extractConnectionFromObject();
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
				SetValue(Connection.Get(), propagateChange: false);
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

		public void SetConnection(IConnection<bool> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
			}
		}

		public IConnection<bool> GetConnection()
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
