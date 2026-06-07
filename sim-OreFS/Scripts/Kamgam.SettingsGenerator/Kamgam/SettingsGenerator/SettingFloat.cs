using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingFloat : SettingWithValue<float>, ISettingWithConnection<float>, ISettingWithValue<float>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.Float;

		[NonSerialized]
		public IConnection<float> Connection;

		[SerializeField]
		private FloatConnectionSO ConnectionObject;

		[NonSerialized]
		protected float _value;

		protected bool _valueInitialized;

		public event Action<SettingFloat> OnSettingFloatChanged;

		public event Action<float> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as FloatConnectionSO;
		}

		public override float GetValue()
		{
			return _value;
		}

		public override void SetValue(float value, bool propagateChange = true)
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

		public SettingFloat(SettingData data, List<string> groups = null)
			: base(data, groups)
		{
		}

		public SettingFloat(string path, float value, List<string> groups = null)
			: base(path, groups)
		{
			SetValue(value);
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingFloatChanged?.Invoke(this);
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
			SetValue((float)value, propagateChange);
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.Float;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.Float);
			settingData.FloatValues = new float[1] { GetValue() };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.Float))
			{
				SetValue(data.FloatValues[0], propagateChange: false);
			}
		}

		protected void extractConnectionFromObject()
		{
			if (Connection == null && ConnectionObject != null)
			{
				FloatConnectionSO connectionObject = ConnectionObject;
				if ((object)connectionObject != null)
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

		public void SetConnection(IConnection<float> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
			}
		}

		public IConnection<float> GetConnection()
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
