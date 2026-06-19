using UnityEngine;

namespace SimplySVG
{
	public class GlobalSettings : ScriptableObject
	{
		private static GlobalSettings current;

		private static string[] searchPaths = new string[1] { "Assets" };

		public ImportSettings defaultImportSettings;

		public Material defaultMaterial;

		public LogLevel levelOfLog;

		public int maxUnsupportedFeatureWarningCount = 5;

		public bool extraDevelopementChecks;

		public int logLevelInteger
		{
			get
			{
				switch (levelOfLog)
				{
				case LogLevel.CRITICALS:
					return 0;
				case LogLevel.ERRORS:
					return 1;
				case LogLevel.ERRORS_AND_WARNINGS:
					return 2;
				case LogLevel.ERRORS_WARNINGS_AND_INFO:
					return 3;
				default:
					return 2;
				}
			}
		}

		public static GlobalSettings Get()
		{
			if (current == null)
			{
				Debug.LogWarning("GlobalSettings instance has not been set. Default settings will be used.");
				current = ScriptableObject.CreateInstance<GlobalSettings>();
			}
			return current;
		}
	}
}
