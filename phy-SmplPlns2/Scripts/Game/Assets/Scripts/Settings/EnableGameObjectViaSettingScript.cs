using System.Reflection;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class EnableGameObjectViaSettingScript : MonoBehaviour
	{
		private BoolSetting _setting;

		private BoolSetting _setting2;

		[SerializeField]
		[Tooltip("The name of the primary setting controlling the enabled state of this game object.")]
		private string _settingName;

		[SerializeField]
		[Tooltip("The name of the secondary setting controlling the enabled state of this game object. This may be null. If this setting exists, both settings must be true for the game object to be enabled.")]
		private string _setting2Name;

		protected virtual void OnDestroy()
		{
			if (_setting != null)
			{
				_setting.Changed -= OnSettingChanged;
			}
			if (_setting2 != null)
			{
				_setting2.Changed -= OnSettingChanged;
			}
		}

		protected void Start()
		{
			_setting = FindSettingByName<BoolSetting>(Game.Instance.Settings, _settingName);
			if (_setting != null)
			{
				_setting.Changed += OnSettingChanged;
			}
			else
			{
				Debug.LogWarning("Could not find the setting '" + _settingName + "'.", base.gameObject);
			}
			if (!string.IsNullOrWhiteSpace(_setting2Name))
			{
				_setting2 = FindSettingByName<BoolSetting>(Game.Instance.Settings, _setting2Name);
				if (_setting2 != null)
				{
					_setting2.Changed += OnSettingChanged;
				}
				else
				{
					Debug.LogWarning("Could not find the setting '" + _setting2Name + "'.", base.gameObject);
				}
			}
			if (_setting != null || _setting2 != null)
			{
				UpdateFromSetting();
			}
		}

		private static T FindSettingByName<T>(SettingsManager settings, string settingName)
		{
			if (settings == null || string.IsNullOrEmpty(settingName))
			{
				return default(T);
			}
			string[] array = settingName.Split('.');
			object obj = settings;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (obj == null)
				{
					Debug.LogWarning("Unable to traverse to '" + text + "' because the parent object is null.");
					return default(T);
				}
				PropertyInfo property = obj.GetType().GetProperty(text, BindingFlags.Instance | BindingFlags.Public);
				if (property == null)
				{
					Debug.LogWarning("Property '" + text + "' not found on type '" + obj.GetType().Name + "'.");
					return default(T);
				}
				obj = property.GetValue(obj, null);
			}
			if (obj is T)
			{
				return (T)obj;
			}
			Debug.LogWarning("Found setting, but it is not of type '" + typeof(T).Name + "'. Found type: '" + obj?.GetType().Name + "'.");
			return default(T);
		}

		private void OnSettingChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateFromSetting();
		}

		private void UpdateFromSetting()
		{
			BoolSetting setting = _setting;
			bool active = (setting == null || setting.Value) && (_setting2?.Value ?? true);
			base.gameObject.SetActive(active);
		}
	}
}
