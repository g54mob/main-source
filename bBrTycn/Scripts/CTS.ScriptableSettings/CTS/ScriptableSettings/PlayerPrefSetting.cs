using UnityEngine;

namespace CTS.ScriptableSettings
{
	public abstract class PlayerPrefSetting<T> : SettingObject<T>
	{
		[SerializeField]
		protected string _prefKey;
	}
}
