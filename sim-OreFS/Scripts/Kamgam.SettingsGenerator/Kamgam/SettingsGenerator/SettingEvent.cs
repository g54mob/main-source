using System;
using UnityEngine;
using UnityEngine.Events;

namespace Kamgam.SettingsGenerator
{
	public abstract class SettingEvent : SettingResolver
	{
		public bool TriggerOnStart = true;

		public bool TriggerOnEnable;

		[Tooltip("If set to false then this event will not trigger if the gameobject or component is disabled.\n\nNOTICE: The event registers itself in OnEnable() so if the object starts disabled then it will NEVER be triggered not matter what this was set to.")]
		public bool TriggerIfDisabled;

		[NonSerialized]
		protected SettingData.DataType[] _supportedDataTypes;

		public abstract override SettingData.DataType[] GetSupportedDataTypes();

		public ISetting GetSetting()
		{
			if (HasActiveSettingForID(ID))
			{
				return SettingsProvider.Settings.GetSetting(ID);
			}
			return null;
		}

		public override void Start()
		{
			base.Start();
			if (TriggerOnStart)
			{
				TriggerEvent();
			}
		}

		public override void OnEnable()
		{
			base.OnEnable();
			Register();
			if (TriggerOnEnable)
			{
				TriggerEvent();
			}
		}

		public override void OnDisable()
		{
			UnRegister();
		}

		public void Register()
		{
			if (HasActiveSettingForID(ID))
			{
				GetSetting().OnSettingChanged += onChanged;
			}
		}

		public void UnRegister()
		{
			if (HasActiveSettingForID(ID))
			{
				GetSetting().OnSettingChanged -= onChanged;
			}
		}

		protected virtual void onChanged(ISetting setting)
		{
			if (shoudTrigger())
			{
				TriggerEvent();
			}
		}

		public override void Refresh()
		{
			TriggerEvent();
		}

		public virtual bool shoudTrigger()
		{
			if (TriggerIfDisabled)
			{
				return true;
			}
			if (base.gameObject != null && base.gameObject.activeInHierarchy)
			{
				return base.isActiveAndEnabled;
			}
			return false;
		}

		public abstract void TriggerEvent();
	}
	public abstract class SettingEvent<T> : SettingEvent
	{
		[Space(10f)]
		public UnityEvent<T> OnValueChanged;

		public void Log(T value)
		{
			Debug.Log(value);
		}
	}
}
