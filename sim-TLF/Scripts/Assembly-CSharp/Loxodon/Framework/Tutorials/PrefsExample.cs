using System;
using Loxodon.Framework.Prefs;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class PrefsExample : MonoBehaviour
	{
		private void Start()
		{
			BinaryFilePreferencesFactory binaryFilePreferencesFactory = new BinaryFilePreferencesFactory();
			binaryFilePreferencesFactory.Serializer.AddTypeEncoder(new CustomDataTypeEncoder());
			Preferences.Register(binaryFilePreferencesFactory);
			Preferences globalPreferences = Preferences.GetGlobalPreferences();
			globalPreferences.SetString("username", "clark_ya@163.com");
			globalPreferences.SetString("name", "clark");
			globalPreferences.SetInt("zone", 5);
			globalPreferences.Save();
			Preferences preferences = Preferences.GetPreferences("clark@5");
			preferences.SetString("role.name", "clark");
			preferences.SetObject("role.logout.map.position", new Vector3(1f, 2f, 3f));
			preferences.SetObject("role.logout.map.forward", new Vector3(0f, 0f, 1f));
			preferences.SetObject("role.logout.time", DateTime.Now);
			preferences.SetObject("test.custom.data", new CustomData("test", "This is a test."));
			preferences.Save();
			Debug.LogFormat("username:{0}; name:{1}; zone:{2};", globalPreferences.GetString("username"), globalPreferences.GetString("name"), globalPreferences.GetInt("zone"));
			Debug.LogFormat("position:{0} forward:{1} logout time:{2}", preferences.GetObject<Vector3>("role.logout.map.position"), preferences.GetObject<Vector3>("role.logout.map.forward"), preferences.GetObject<DateTime>("role.logout.time"));
			Debug.LogFormat("CustomData name:{0}   description:{1}", preferences.GetObject<CustomData>("test.custom.data").name, preferences.GetObject<CustomData>("test.custom.data").description);
		}
	}
}
