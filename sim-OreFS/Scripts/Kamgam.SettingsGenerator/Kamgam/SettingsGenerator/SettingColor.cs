using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingColor : SettingWithValue<Color>, ISettingWithConnection<Color>, ISettingWithValue<Color>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.Color;

		[NonSerialized]
		public IConnection<Color> Connection;

		[SerializeField]
		private ColorConnectionSO ConnectionObject;

		[NonSerialized]
		protected Color _color;

		protected bool _valueInitialized;

		public event Action<SettingColor> OnSettingColorChanged;

		public event Action<Color> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as ColorConnectionSO;
		}

		public override Color GetValue()
		{
			return _color;
		}

		public override void SetValue(Color color, bool propagateChange = true)
		{
			if (_color == color && _valueInitialized)
			{
				return;
			}
			_valueInitialized = true;
			_color = color;
			if (propagateChange)
			{
				OnChanged();
				if (ApplyImmediately)
				{
					PushToConnection();
				}
			}
		}

		public SettingColor(SettingData data, List<string> groups = null)
			: base(data, groups)
		{
		}

		public SettingColor(string path, Color value, List<string> groups = null)
			: base(path, groups)
		{
			SetValue(value);
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingColorChanged?.Invoke(this);
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
			SetValue((Color)value, propagateChange);
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.Color;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.Color);
			Color value = GetValue();
			settingData.FloatValues = new float[4] { value.r, value.g, value.b, value.a };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.Color))
			{
				SetValue(new Color(data.FloatValues[0], data.FloatValues[1], data.FloatValues[2], data.FloatValues[3]), propagateChange: false);
			}
		}

		protected void extractConnectionFromObject()
		{
			if (Connection == null && ConnectionObject != null)
			{
				IConnectionSO<IConnection<Color>> connectionObject = ConnectionObject;
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

		public void SetConnection(IConnection<Color> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
			}
		}

		public IConnection<Color> GetConnection()
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
