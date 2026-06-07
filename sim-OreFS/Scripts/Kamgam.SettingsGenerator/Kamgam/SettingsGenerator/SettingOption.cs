using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingOption : SettingWithValue<int>, ISettingWithOptions<string>, ISettingWithConnection<int>, ISettingWithValue<int>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		public const SettingData.DataType DataType = SettingData.DataType.Option;

		[SerializeField]
		[Tooltip("The names of the options.\nThese define which options the user can choose from. The resulting value will the index of the selected option label (index is starting with 0).\nThese are IGNORED if a connection is set.")]
		protected List<string> _optionLabels;

		[SerializeField]
		[Tooltip("Should the option labels be taken from the static ones defined here even if a connection is set?\n\nUsually if a connection is set then the labels are fetched dynamically from the connection.\nBe aware that if you set the labels here then the number of labels has to match the connection options. Otherwise this will have no effect.")]
		[DisableIf("ConnectionObject", null, DisableIfAttribute.BehaviourType.Disable, false, null, null)]
		protected bool _overrideConnectionLabels;

		[NonSerialized]
		public IConnectionWithOptions<string> Connection;

		[SerializeField]
		[Tooltip("The connection which is used to dynamically fill the option names and value.\nIf this is set then the OptionLabels and DefaultIndex fields are ignored.\nYou can override this by enabling 'overrideConnectionLabels'.")]
		private OptionConnectionSO ConnectionObject;

		[NonSerialized]
		protected int _selectedIndex;

		protected bool _valueInitialized;

		public event Action<SettingOption> OnSettingOptionChanged;

		public event Action<int> OnValueChanged;

		public override ConnectionSO GetConnectionSO()
		{
			return ConnectionObject;
		}

		public override void SetConnectionSO(ConnectionSO connectionSO)
		{
			ConnectionObject = connectionSO as OptionConnectionSO;
		}

		public override int GetValue()
		{
			return _selectedIndex;
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

		public SettingOption(SettingData data, List<string> groups = null, List<string> optionNames = null)
			: base(data, groups)
		{
			_optionLabels = optionNames;
		}

		public SettingOption(string path, int selectedIndex, List<string> groups = null, List<string> optionNames = null)
			: base(path, groups)
		{
			SetValue(selectedIndex);
			_optionLabels = optionNames;
		}

		protected override void triggerOnSettingChanged()
		{
			base.triggerOnSettingChanged();
			this.OnSettingOptionChanged?.Invoke(this);
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
					Connection.SetOptionLabels(_optionLabels);
				}
				else
				{
					Connection.RefreshOptionLabels();
					_optionLabels = Connection.GetOptionLabels();
				}
				invokePulledFromConnectionListeners();
			}
		}

		protected void initLabelOverridesAfterNewConnection()
		{
			if (Connection != null && _overrideConnectionLabels)
			{
				Connection.SetOptionLabels(_optionLabels);
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

		public bool HasOptions()
		{
			if (HasConnection())
			{
				return Connection.HasOptions();
			}
			if (_optionLabels != null)
			{
				return _optionLabels.Count > 0;
			}
			return false;
		}

		public List<string> GetOptionLabels()
		{
			if (HasConnection())
			{
				return Connection.GetOptionLabels();
			}
			return _optionLabels;
		}

		public void SetOptionLabels(List<string> options)
		{
			if (options != _optionLabels)
			{
				ClearOptionLabels();
			}
			if (options != null)
			{
				AddOptionLabels(options);
				SetOverrideConnectionLabels(_overrideConnectionLabels);
			}
		}

		public void ClearOptionLabels()
		{
			if (_optionLabels != null)
			{
				_optionLabels.Clear();
			}
		}

		public void AddOptionLabels(IEnumerable<string> optionsToAdd)
		{
			if (_optionLabels == null)
			{
				_optionLabels = new List<string>();
			}
			_optionLabels.AddRange(optionsToAdd);
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
			return SettingData.DataType.Option;
		}

		public override SettingData SerializeValueToData()
		{
			SettingData settingData = new SettingData(ID, SettingData.DataType.Option);
			settingData.IntValues = new int[1] { GetValue() };
			return settingData;
		}

		public override void DeserializeValueFromData(SettingData data)
		{
			if (checkDataType(data.Type, SettingData.DataType.Option))
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
			IConnectionSO<IConnectionWithOptions<string>> connectionObject = ConnectionObject;
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
				ClearOptionLabels();
				List<string> optionLabels = Connection.GetOptionLabels();
				if (optionLabels != null)
				{
					AddOptionLabels(optionLabels);
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

		public void SetConnection(IConnectionWithOptions<string> connection)
		{
			Connection = connection;
			if (connection != null)
			{
				InitializeConnection();
				initLabelOverridesAfterNewConnection();
			}
		}

		public void SetConnection(IConnection<int> connection)
		{
			throw new Exception("IConnectionWithOptions<string> required but IConnection<int> given.");
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
