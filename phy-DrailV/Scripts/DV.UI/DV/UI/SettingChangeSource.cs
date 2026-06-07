using System;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	[DisallowMultipleComponent]
	public abstract class SettingChangeSource : NullCheckingMonoBehaviour
	{
		[SerializeField]
		private string preferencesName;

		[SerializeField]
		protected TextMeshProUGUI labelTMPro;

		[NonSerialized]
		public object latestValue;

		protected ASettingsProvider provider;

		protected TMProAddMark labelMark;

		protected PreferenceValues prefVal;

		public virtual string PreferencesName => preferencesName;

		public event Action<SettingChangeSource> ValueChanged;

		protected override void Awake()
		{
			base.Awake();
			if (string.IsNullOrWhiteSpace(PreferencesName))
			{
				Debug.LogError("PreferencesName for '" + base.name + "' is not set", base.gameObject);
			}
			if ((bool)labelTMPro)
			{
				labelMark = labelTMPro.gameObject.AddComponent<TMProAddMark>();
			}
		}

		private void OnEnable()
		{
			if (provider != null)
			{
				OnResetOrApplied();
			}
		}

		protected void Fire()
		{
			this.ValueChanged?.Invoke(this);
		}

		public void SetProvider(ASettingsProvider provider)
		{
			if (this.provider != null)
			{
				this.provider.ResetOrApplied -= OnResetOrApplied;
				ValueChanged -= provider.AddChange;
				this.provider = null;
				if (prefVal != null)
				{
					prefVal.ImmediateEffectLatestValueChanged -= OnResetOrApplied;
					prefVal = null;
				}
			}
			this.provider = provider;
			if (!(this.provider != null))
			{
				return;
			}
			this.provider.ResetOrApplied += OnResetOrApplied;
			ValueChanged += this.provider.AddChange;
			if (base.gameObject.activeSelf)
			{
				prefVal = GetPreferenceValuesFromProvider();
				if (prefVal != null)
				{
					prefVal.ImmediateEffectLatestValueChanged += OnResetOrApplied;
				}
			}
			if (base.isActiveAndEnabled)
			{
				OnResetOrApplied();
			}
		}

		protected virtual void OnResetOrApplied()
		{
		}

		protected void UpdateLabel()
		{
			if (!(labelMark == null))
			{
				bool flag = prefVal != null && prefVal.HasChange;
				labelMark.SetMark(flag ? "*" : "");
			}
		}

		private PreferenceValues GetPreferenceValuesFromProvider()
		{
			if (provider == null)
			{
				Debug.LogError("PreferencesName doesn't have a provider assigned, couldn't get value", base.gameObject);
				return null;
			}
			if (!provider.preferenceValues.TryGetValue(PreferencesName, out var value))
			{
				Debug.LogError("PreferencesName key '" + PreferencesName + "' not present in provider", base.gameObject);
				return null;
			}
			return value;
		}
	}
	[DisallowMultipleComponent]
	public abstract class SettingChangeSource<T> : SettingChangeSource
	{
		protected virtual void UpdateAndFireEvent(T newValue)
		{
			latestValue = newValue;
			Fire();
			UpdateLabel();
		}

		public T GetLatestValueFromProvider()
		{
			return (prefVal == null) ? ((object)default(T)) : prefVal.latestValue;
		}

		protected override void OnResetOrApplied()
		{
			UpdateLabel();
		}
	}
}
