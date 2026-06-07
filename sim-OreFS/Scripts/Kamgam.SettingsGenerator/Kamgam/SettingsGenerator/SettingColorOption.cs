using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingColorOption : SettingWithValue<int>, ISettingWithOptions<Color>, ISettingWithConnection<int>, ISettingWithValue<int>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.ColorOption;

		[SerializeField]
		[Tooltip("The color options.\nThese define which colors the user can choose from. The resulting value will the selected color.\nThese are IGNORED if a connection is set.")]
		protected List<Color> _options;

		[SerializeField]
		[Tooltip("Should the option labels be taken from the static ones defined here even if a connection is set?\n\nUsually if a connection is set then the labels are fetched dynamically from the connection.\nBe aware that if you set the labels here then the number of labels has to match the connection options. Otherwise this will have no effect.")]
		[DisableIf("ConnectionObject", null, DisableIfAttribute.BehaviourType.Disable, false, null, null)]
		protected bool _overrideConnectionLabels;

		[NonSerialized]
		public IConnectionWithOptions<Color> Connection;

		[SerializeField]
		private ColorOptionConnectionSO ConnectionObject;

		[NonSerialized]
		protected int _selectedIndex;

		protected bool _valueInitialized;

		public event Action<SettingColorOption> OnSettingColorOptionChanged;

		public event Action<int> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as ColorOptionConnectionSO;
		}

		public override int GetValue()
		{
			return _selectedIndex;
		}

		public Color GetColorValue()
		{
			return GetColorValue(Color.black);
		}

		public Color GetColorValue(Color defaultColor)
		{
			int value = GetValue();
			List<Color> optionLabels = GetOptionLabels();
			if (value < 0 || optionLabels == null || value >= optionLabels.Count)
			{
				return defaultColor;
			}
			return optionLabels[value];
		}

		public override void SetValue(int selectedIndex, bool propagateChange = true)
		{
			if (_selectedIndex == selectedIndex && _valueInitialized)
			{
				return;
			}
			_valueInitialized = true;
			_selectedIndex = selectedIndex;
			if (propagateChange)
			{
				OnChanged();
				if (ApplyImmediately)
				{
					PushToConnection();
				}
			}
		}

		public SettingColorOption(SettingData data, List<string> groups = null, List<Color> options = null)
			: base(data, groups)
		{
			_options = options;
		}

		public SettingColorOption(string path, int selectedIndex, List<string> groups = null, List<Color> options = null)
			: base(path, groups)
		{
			SetValue(selectedIndex);
			_options = options;
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingColorOptionChanged?.Invoke(this);
			this.OnValueChanged?.Invoke(GetValue());
		}

		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();
		}

		public void SetOverrideConnectionLabels(bool overrideLabels)
		{
			_overrideConnectionLabels = overrideLabels;
			if (HasConnection())
			{
				if (_overrideConnectionLabels)
				{
					Connection.SetOptionLabels(_options);
				}
				else
				{
					Connection.RefreshOptionLabels();
					_options = Connection.GetOptionLabels();
				}
				invokePulledFromConnectionListeners();
			}
		}

		protected void initLabelOverridesAfterNewConnection()
		{
			if (Connection != null && _overrideConnectionLabels)
			{
				Connection.SetOptionLabels(_options);
			}
		}

		public bool GetOverrideConnectionLabels()
		{
			return _overrideConnectionLabels;
		}

		public override void ResetToDefault()
		{
			SetValue(_defaultValue);
			if (HasConnection() && ApplyImmediately)
			{
				PushToConnection();
			}
		}

		public void SetOptionLabels(List<Color> options)
		{
			ClearOptions();
			if (options != null)
			{
				AddOptions(options);
				SetOverrideConnectionLabels(_overrideConnectionLabels);
			}
		}

		public bool HasOptions()
		{
			if (HasConnection())
			{
				return Connection.HasOptions();
			}
			if (_options != null)
			{
				return _options.Count > 0;
			}
			return false;
		}

		public List<Color> GetOptionLabels()
		{
			if (HasConnection())
			{
				return Connection.GetOptionLabels();
			}
			return _options;
		}

		public void ClearOptions()
		{
			if (_options != null)
			{
				_options.Clear();
			}
		}

		public void AddOptions(IEnumerable<Color> optionsToAdd)
		{
			if (_options == null)
			{
				_options = new List<Color>();
			}
			_options.AddRange(optionsToAdd);
		}

		public override void SetValueFromObject(object value, bool propagateChange = true)
		{
			SetValue((int)value, propagateChange);
		}

		public override object GetValueAsObject()
		{
			return GetValue();
		}

		public override SettingData.DataType GetDataType()
		{
			return SettingData.DataType.ColorOption;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.ColorOption);
			settingData.IntValues = new int[1] { GetValue() };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.ColorOption))
			{
				SetValue(data.IntValues[0], propagateChange: false);
			}
		}

		protected void extractConnectionFromObject()
		{
			if (Connection != null || !(ConnectionObject != null))
			{
				return;
			}
			IConnectionSO<IConnectionWithOptions<Color>> connectionObject = ConnectionObject;
			if (connectionObject != null)
			{
				Connection = connectionObject.GetConnection();
				if (Connection != null)
				{
					initLabelOverridesAfterNewConnection();
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
				ClearOptions();
				List<Color> optionLabels = Connection.GetOptionLabels();
				if (optionLabels != null)
				{
					AddOptions(optionLabels);
				}
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

		public void SetConnection(IConnectionWithOptions<Color> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
				initLabelOverridesAfterNewConnection();
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

		public void SetConnection(IConnection<int> connection)
		{
			throw new Exception("IConnectionWithOptions<Color> required but IConnection<int> given.");
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
