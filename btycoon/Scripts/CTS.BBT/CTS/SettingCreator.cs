using CTS.ScriptableSettings;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public abstract class SettingCreator : ScriptableObject
	{
		public abstract UISetting Spawn(Transform parent);
	}
	public abstract class SettingCreator<T> : SettingCreator
	{
		public SettingObject<T> Setting { get; private set; }

		public LocalizedString SettingName { get; private set; }
	}
}
