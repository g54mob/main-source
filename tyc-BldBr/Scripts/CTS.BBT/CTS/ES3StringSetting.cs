using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/ES3/String Setting")]
	public class ES3StringSetting : EasySavePersistentSetting<string>
	{
		protected override void OnSaveCurrentValueToDisk()
		{
			ES3.Save(_key, _currentValue, GetSaveSettings());
		}

		protected override string GetValueFromDisk()
		{
			return ES3.Load<string>(_key, _defaultValue, GetSaveSettings());
		}
	}
}
