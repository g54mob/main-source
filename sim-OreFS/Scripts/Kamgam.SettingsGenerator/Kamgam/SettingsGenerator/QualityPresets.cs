using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class QualityPresets
	{
		public static Dictionary<int, QualityPreset> Presets = new Dictionary<int, QualityPreset>();

		public static void AddAllLevels()
		{
			int qualityLevel = QualitySettings.GetQualityLevel();
			for (int i = 0; i < QualitySettings.names.Length; i++)
			{
				QualitySettings.SetQualityLevel(i, applyExpensiveChanges: false);
				AddCurrentLevel();
			}
			QualitySettings.SetQualityLevel(qualityLevel);
		}

		public static void AddCurrentLevel()
		{
			int qualityLevel = QualitySettings.GetQualityLevel();
			if (!Presets.ContainsKey(qualityLevel))
			{
				Presets.Add(qualityLevel, QualityPreset.CreateFromCurrentLevel());
			}
		}

		public static void RestoreCurrentLevel()
		{
			RestoreCurrentFrom(QualitySettings.GetQualityLevel());
		}

		public static void RestoreCurrentFrom(int level)
		{
			if (Presets.ContainsKey(level))
			{
				Presets[level].ApplyToCurrentLevel();
			}
		}

		public static QualityPreset GetPreset(int level)
		{
			if (Presets.ContainsKey(level))
			{
				return Presets[level];
			}
			return null;
		}

		public static List<QualityPreset> GetPresetList()
		{
			List<QualityPreset> list = new List<QualityPreset>();
			int num = Presets.Max((KeyValuePair<int, QualityPreset> kv) => kv.Key);
			for (int num2 = 0; num2 < num; num2++)
			{
				if (Presets.ContainsKey(num2))
				{
					list.Add(GetPreset(num2));
				}
			}
			return list;
		}
	}
}
