using Kamgam.LocalizationForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public abstract class SettingResolver : MonoBehaviour, ISettingResolver
	{
		[Tooltip("The global settings provider asset.")]
		public SettingsProvider SettingsProvider;

		[Tooltip("The global localization provider asset.")]
		public LocalizationProvider LocalizationProvider;

		[Tooltip("The ID of the setting within the Settings asset.")]
		public string ID;

		public string GetID()
		{
			return ID;
		}

		public abstract SettingData.DataType[] GetSupportedDataTypes();

		public virtual void Start()
		{
			RegisterAsActivated();
		}

		public virtual void OnEnable()
		{
			Refresh();
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnDestroy()
		{
			if (SettingsProvider != null && SettingsProvider.HasSettings())
			{
				SettingsProvider.Settings.UnregisterResolver(this);
				SettingsProvider.Settings.GetSetting(ID)?.RemovePulledFromConnectionListener(Refresh);
			}
		}

		public bool HasValidSettingForID(string id, params SettingData.DataType[] allowedTypes)
		{
			if (SettingsProvider == null || SettingsProvider.Settings == null)
			{
				Logger.LogError("SGSettingResolver: Settings or SettingsProvider is NULL (on Object: '" + base.gameObject.name + "', ID: '" + id + "').", this);
				return false;
			}
			if (string.IsNullOrEmpty(id))
			{
				return false;
			}
			bool flag = SettingsProvider.Settings.HasID(id);
			if (!flag)
			{
				Logger.LogWarning("SGSettingResolver: No setting with ID '" + id + "' found in '" + base.name + "'. This setting will NOT be saved!", this);
			}
			if (allowedTypes != null && allowedTypes.Length != 0)
			{
				ISetting setting = SettingsProvider.Settings.GetSetting(id);
				if (setting != null && !setting.MatchesAnyDataType(allowedTypes))
				{
					return false;
				}
			}
			return flag;
		}

		public bool HasSettingForID(string id)
		{
			return SettingsProvider.Settings.HasID(id);
		}

		public bool HasActiveSettingForID(string id)
		{
			return SettingsProvider.Settings.HasActiveID(id);
		}

		public SettingData.DataType GetDataType()
		{
			if (SettingsProvider == null || SettingsProvider.Settings == null)
			{
				return SettingData.DataType.Unknown;
			}
			return SettingsProvider.Settings.GetSetting(ID)?.GetDataType() ?? SettingData.DataType.Unknown;
		}

		public void RegisterAsActivated()
		{
			if (!(SettingsProvider == null) && !(SettingsProvider.Settings == null))
			{
				SettingsProvider.Settings.RegisterResolver(GetComponent<ISettingResolver>());
			}
		}

		public void Unregister()
		{
			if (!(SettingsProvider == null) && !(SettingsProvider.Settings == null))
			{
				SettingsProvider.Settings.UnregisterResolver(GetComponent<ISettingResolver>());
			}
		}

		public abstract void Refresh();
	}
}
