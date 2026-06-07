using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public abstract class SettingWithValue<TValue> : ISettingWithValue<TValue>, ISetting, ISerializationCallbackReceiver, IQualityChangeReceiver, ISettingWithConnectionSO
	{
		[NonSerialized]
		protected bool _hasUserData;

		[Tooltip("If a settings is disabled then the settings system will ignore it.\nThis is useful if you want to keep a setting in the list but disable it.\nYou should not change this at runtime.")]
		[SerializeField]
		protected bool _isActive = true;

		public string ID;

		public bool ApplyImmediately = true;

		[SerializeField]
		[FormerlySerializedAs("Groups")]
		protected List<string> _groups;

		[SerializeField]
		[FormerlySerializedAs("_value")]
		[DisableIf("ConnectionObject", null, DisableIfAttribute.BehaviourType.Disable, true, "IgnoreConnectionDefaults", true)]
		[Tooltip("The default value which will be used if no user setting data was found (first boot) and if no connection is set.\n\nNOTICE: If a connection is set then this will be ignored as the value will come from the connection (unless 'IgnoreConnectionDefaults' is enabled).")]
		protected TValue _defaultValue;

		[Tooltip("If enabled then the default value will NOT be fetched from the connection but will be set to the default value configured here on this setting.")]
		[DisableIf("ConnectionObject", null, DisableIfAttribute.BehaviourType.Disable, false, null, null)]
		public bool IgnoreConnectionDefaults;

		protected bool _hasChanged;

		protected Func<string, string> _translateFunc;

		protected List<Action<TValue>> _applyListeners;

		protected List<Action<TValue>> _changeListeners;

		protected List<Action<TValue>> _pulledFromConnectionListeners;

		protected List<Action> _genericPulledFromConnectionListeners;

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
				Logger.LogWarning("Changing the IsActive state of settings at runtime is not recommended.");
			}
		}

		public event Action<ISetting> OnSettingChanged;

		public virtual ConnectionSO GetConnectionSO()
		{
			return null;
		}

		public virtual void SetConnectionSO(ConnectionSO connectionSO)
		{
		}

		public virtual SettingData.DataType GetConnectionSettingDataType()
		{
			return SettingData.DataType.Unknown;
		}

		public SettingWithValue(SettingData data, List<string> groups)
		{
			ID = data.ID;
			DeserializeValueFromData(data);
			_groups = groups;
			ApplyImmediately = true;
		}

		public SettingWithValue(string id, List<string> groups)
		{
			ID = id;
			_groups = groups;
			ApplyImmediately = true;
		}

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
			ID = ID.Trim();
		}

		public virtual void InitializeConnection()
		{
			if (HasConnection())
			{
				SetDefaultFromConnection((IConnection<TValue>)GetConnectionInterface());
				if (!_hasUserData)
				{
					SetValue(_defaultValue);
				}
			}
		}

		public string GetID()
		{
			return ID;
		}

		public void SetHasUserData(bool loaded)
		{
			_hasUserData = loaded;
		}

		public bool HasUserData()
		{
			return _hasUserData;
		}

		public abstract SettingData.DataType GetDataType();

		public abstract TValue GetValue();

		public abstract void SetValue(TValue value, bool propagateChange = true);

		public abstract void SetValueFromObject(object value, bool propagateChange = true);

		public bool MatchesID(string id)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(id))
			{
				return false;
			}
			return ID == id;
		}

		public virtual void SetDefault(TValue defaultValue)
		{
			_defaultValue = defaultValue;
		}

		public virtual void SetDefaultFromConnection(IConnection<TValue> connection)
		{
			if (HasConnection() && !IgnoreConnectionDefaults)
			{
				_defaultValue = connection.GetDefault();
			}
		}

		public abstract void ResetToDefault();

		public bool MatchesAnyGroup(string[] groups)
		{
			if (groups == null || groups.Length == 0 || _groups == null || _groups.Count == 0)
			{
				return false;
			}
			foreach (string text in groups)
			{
				foreach (string group in _groups)
				{
					if (group == text)
					{
						return true;
					}
				}
			}
			return false;
		}

		public List<string> GetGroups()
		{
			return _groups;
		}

		public void SetGroups(List<string> groups)
		{
			_groups = groups;
		}

		protected bool checkDataType(SettingData.DataType serializedDataType, SettingData.DataType dataType)
		{
			if (serializedDataType != dataType)
			{
				Debug.LogError("SGSettings: The serialized data type is '" + serializedDataType.ToString() + "' instead of the expected '" + dataType.ToString() + "' for settings path '" + ID + "'.");
				return false;
			}
			return true;
		}

		public bool MatchesAnyDataType(IList<SettingData.DataType> dataTypes)
		{
			if (dataTypes == null)
			{
				return false;
			}
			int count = dataTypes.Count;
			for (int i = 0; i < count; i++)
			{
				if (dataTypes[i] == GetDataType())
				{
					return true;
				}
			}
			return false;
		}

		public abstract SettingData SerializeValueToData();

		public abstract void DeserializeValueFromData(SettingData data);

		public void AddChangeListener(Action<TValue> onChanged)
		{
			if (_changeListeners == null)
			{
				_changeListeners = new List<Action<TValue>>();
			}
			if (!_changeListeners.Contains(onChanged))
			{
				_changeListeners.Add(onChanged);
			}
		}

		public void RemoveChangeListener(Action<TValue> onChanged)
		{
			if (_changeListeners != null)
			{
				_changeListeners.Remove(onChanged);
			}
		}

		public void AddApplyListener(Action<TValue> onApplied)
		{
			if (_applyListeners == null)
			{
				_applyListeners = new List<Action<TValue>>();
			}
			if (!_applyListeners.Contains(onApplied))
			{
				_applyListeners.Add(onApplied);
			}
		}

		public void RemoveApplyListener(Action<TValue> onApplied)
		{
			if (_applyListeners != null)
			{
				_applyListeners.Remove(onApplied);
			}
		}

		protected void invokeApplyListeners()
		{
			if (_applyListeners == null)
			{
				return;
			}
			foreach (Action<TValue> applyListener in _applyListeners)
			{
				if (applyListener != null)
				{
					applyListener?.Invoke(GetValue());
				}
			}
		}

		public void Apply()
		{
			_hasChanged = false;
			if (HasConnection())
			{
				PushToConnection();
				PullFromConnection();
			}
			invokeApplyListeners();
		}

		public void OnChanged()
		{
			MarkAsChanged();
			triggerOnSettingChanged();
			if (_changeListeners == null)
			{
				return;
			}
			foreach (Action<TValue> changeListener in _changeListeners)
			{
				changeListener?.Invoke(GetValue());
			}
		}

		protected virtual void triggerOnSettingChanged()
		{
			this.OnSettingChanged?.Invoke(this);
		}

		public void MarkAsChanged()
		{
			_hasChanged = true;
		}

		public void MarkAsUnchanged()
		{
			_hasChanged = false;
		}

		public bool HasUnappliedChanges()
		{
			return _hasChanged;
		}

		public void AddPulledFromConnectionListener(Action<TValue> onApply)
		{
			if (_pulledFromConnectionListeners == null)
			{
				_pulledFromConnectionListeners = new List<Action<TValue>>();
			}
			if (!_pulledFromConnectionListeners.Contains(onApply))
			{
				_pulledFromConnectionListeners.Add(onApply);
			}
		}

		public void RemovePulledFromConnectionListener(Action<TValue> onApply)
		{
			if (_pulledFromConnectionListeners != null)
			{
				_pulledFromConnectionListeners.Remove(onApply);
			}
		}

		protected void invokePulledFromConnectionListeners()
		{
			if (HasConnection() && _pulledFromConnectionListeners != null)
			{
				foreach (Action<TValue> pulledFromConnectionListener in _pulledFromConnectionListeners)
				{
					if (pulledFromConnectionListener != null)
					{
						pulledFromConnectionListener?.Invoke(GetValue());
					}
				}
			}
			invokeGenericPulledFromConnectionListeners();
		}

		public void AddPulledFromConnectionListener(Action onApply)
		{
			if (_genericPulledFromConnectionListeners == null)
			{
				_genericPulledFromConnectionListeners = new List<Action>();
			}
			if (!_genericPulledFromConnectionListeners.Contains(onApply))
			{
				_genericPulledFromConnectionListeners.Add(onApply);
			}
		}

		public void RemovePulledFromConnectionListener(Action onApply)
		{
			if (_genericPulledFromConnectionListeners != null)
			{
				_genericPulledFromConnectionListeners.Remove(onApply);
			}
		}

		protected void invokeGenericPulledFromConnectionListeners()
		{
			if (!HasConnection() || _genericPulledFromConnectionListeners == null)
			{
				return;
			}
			foreach (Action genericPulledFromConnectionListener in _genericPulledFromConnectionListeners)
			{
				if (genericPulledFromConnectionListener != null)
				{
					genericPulledFromConnectionListener?.Invoke();
				}
			}
		}

		public void RemoveAllListeners()
		{
			_changeListeners?.Clear();
			_pulledFromConnectionListeners?.Clear();
			_genericPulledFromConnectionListeners?.Clear();
			_applyListeners?.Clear();
		}

		public abstract object GetValueAsObject();

		public abstract bool HasConnection();

		public abstract bool HasConnectionObject();

		public abstract void PullFromConnection();

		public abstract void PullFromConnection(bool propagateChange);

		public abstract IConnection GetConnectionInterface();

		public virtual void PushToConnection()
		{
			_hasChanged = false;
		}

		public abstract int GetConnectionOrder();

		public abstract void OnQualityChanged(int qualityLevel);
	}
}
