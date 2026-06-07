using Rewired.Data;
using UnityEngine;

namespace PajamaLlama.Plugins.Rewired
{
	public class UserDataStore_PlayerPrefs_Versioned : UserDataStore_PlayerPrefs
	{
		private const string KEY = "RewiredUserDataStore_Version";

		[Header("Versioning")]
		[SerializeField]
		private int _version;

		[SerializeField]
		private bool _ignoreVersioning;

		public static bool HasBeenReset { get; private set; }

		protected override void OnInitialize()
		{
			if (_ignoreVersioning || (PlayerPrefs.HasKey("RewiredUserDataStore_Version") && PlayerPrefs.GetInt("RewiredUserDataStore_Version") == _version))
			{
				base.OnInitialize();
				return;
			}
			PlayerPrefs.SetInt("RewiredUserDataStore_Version", _version);
			Save();
			HasBeenReset = true;
		}
	}
}
