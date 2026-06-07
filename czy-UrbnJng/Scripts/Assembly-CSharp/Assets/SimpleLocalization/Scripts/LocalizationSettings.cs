using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.SimpleLocalization.Scripts
{
	[CreateAssetMenu(fileName = "LocalizationSettings", menuName = "◆ Simple Localization/Settings")]
	public class LocalizationSettings : ScriptableObject
	{
		public string TableId;

		public List<Sheet> Sheets = new List<Sheet>();

		public UnityEngine.Object SaveFolder;

		public static string UrlPattern = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&gid={1}";

		public static DateTime Timestamp;

		private static LocalizationSettings _instance;

		public static LocalizationSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = LoadSettings();
				}
				return _instance;
			}
		}

		public static event Action OnRunEditor;

		private static LocalizationSettings LoadSettings()
		{
			LocalizationSettings localizationSettings = Resources.Load<LocalizationSettings>(Path.GetFileNameWithoutExtension("Assets/SimpleLocalization/Resources/LocalizationSettings.asset"));
			if (localizationSettings != null)
			{
				return localizationSettings;
			}
			throw new Exception("Localization settings not found: Assets/SimpleLocalization/Resources/LocalizationSettings.asset");
		}

		static LocalizationSettings()
		{
			LocalizationSettings.OnRunEditor = delegate
			{
			};
		}
	}
}
