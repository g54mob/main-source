using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingInt : SettingWithValue<int>, ISettingWithConnection<int>, ISettingWithValue<int>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.Int;

		[NonSerialized]
		public IConnection<int> Connection;

		[SerializeField]
		private IntConnectionSO ConnectionObject;

		[NonSerialized]
		protected int _value;

		protected bool _valueInitialized;

		public event Action<SettingInt> OnSettingIntChanged;

		public event Action<int> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as IntConnectionSO;
		}

		public override int GetValue()
		{
			return _value;
		}

		public override void SetValue(int value, bool propagateChange = true)
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

		public SettingInt(SettingData data, List<string> groups = null)
			: base(data, groups)
		{
		}

		public SettingInt(string path, int value, List<string> groups = null)
			: base(path, groups)
		{
			SetValue(value);
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingIntChanged?.Invoke(this);
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
			SetValue((int)value, propagateChange);
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.Int;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.Int);
			settingData.IntValues = new int[1] { GetValue() };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.Int))
			{
				SetValue(data.IntValues[0], propagateChange: false);
			}
		}

		protected void extractConnectionFromObject()
		{
			if (Connection == null && ConnectionObject != null)
			{
				IConnectionSO<IConnection<int>> connectionObject = ConnectionObject;
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

		public void SetConnection(IConnection<int> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
			}
		}

		public IConnection<int> GetConnection()
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
