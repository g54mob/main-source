using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingString : SettingWithValue<string>, ISettingWithConnection<string>, ISettingWithValue<string>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.String;

		[NonSerialized]
		public IConnection<string> Connection;

		[SerializeField]
		private StringConnectionSO ConnectionObject;

		[NonSerialized]
		protected string _value;

		protected bool _valueInitialized;

		public event Action<SettingString> OnSettingStringChanged;

		public event Action<string> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as StringConnectionSO;
		}

		public override string GetValue()
		{
			return _value;
		}

		public override void SetValue(string value, bool propagateChange = true)
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

		public SettingString(SettingData data, List<string> groups = null)
			: base(data, groups)
		{
		}

		public SettingString(string path, string value, List<string> groups = null)
			: base(path, groups)
		{
			SetValue(value);
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingStringChanged?.Invoke(this);
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
			SetValue((string)value, propagateChange);
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.String;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.String);
			settingData.StringValues = new string[1] { GetValue() };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.String))
			{
				if (data.StringValues[0].Length > 65000)
				{
					Debug.LogError("SG SettingString: String is too long and will be truncated.");
					data.StringValues[0] = data.StringValues[0].Substring(0, 65000);
				}
				SetValue(data.StringValues[0], propagateChange: false);
			}
		}

		protected void extractConnectionFromObject()
		{
			if (Connection == null && ConnectionObject != null)
			{
				IConnectionSO<IConnection<string>> connectionObject = ConnectionObject;
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

		public void SetConnection(IConnection<string> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
			}
		}

		public IConnection<string> GetConnection()
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
