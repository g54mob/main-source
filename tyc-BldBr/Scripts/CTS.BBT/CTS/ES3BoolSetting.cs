using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/ES3/Bool Setting")]
	public class ES3BoolSetting : EasySavePersistentSetting<bool>
	{
		protected override void OnSaveCurrentValueToDisk()
		{
			ES3.Save(_key, _currentValue, GetSaveSettings());
		}

		protected override bool GetValueFromDisk()
		{
			return ES3.Load(_key, _defaultValue, GetSaveSettings());
		}
	}
}
