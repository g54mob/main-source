using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class QualityConnection : ConnectionWithOptions<string>, IConnectionWithSettingsAccess
	{
		public Settings Settings;

		protected List<string> _labels;

		protected List<int> _values;

		private List<QualityConnectionSO.PresetConnectionEntry> _presetEntries;

		[Obsolete("QualityConnection(Settings settings) constuctor is deprecated. Use the default constructor and SetSettings(Settings settings) instead.")]
		public QualityConnection(Settings settings)
		{
			Settings = settings;
		}

		public QualityConnection()
		{
		}

		public void SetPresetEntries(List<QualityConnectionSO.PresetConnectionEntry> entries)
		{
			_presetEntries = entries;
		}

		public override int GetOrder()
		{
			return base.GetOrder() - 1;
		}

		public override int Get()
		{
			return QualitySettings.names.Length - 1 - QualitySettings.GetQualityLevel();
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = QualitySettings.names.Reverse().ToList();
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels == null || optionLabels.Count != QualitySettings.names.Length)
			{
				Debug.LogError("Invalid new labels for QualityConnection. Need to be " + QualitySettings.names.Length + ".");
			}
			else
			{
				_labels = new List<string>(optionLabels);
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override void Set(int value)
		{
			QualitySettings.GetQualityLevel();
			QualityPresets.RestoreCurrentLevel();
			int qualityLevel = QualitySettings.names.Length - 1 - value;
			QualitySettings.SetQualityLevel(qualityLevel);
			QualityPresets.RestoreCurrentLevel();
			QualityPresets.AddCurrentLevel();
			Settings.OnQualityChanged(qualityLevel, excludeChanged: true);
			Settings.PullFromQualityConnections(exceptUnapplied: true);
			Settings.RefreshRegisteredResolvers();
			ApplyPresetOverrides(qualityLevel);
			NotifyListenersIfChanged(value);
		}

		private void ApplyPresetOverrides(int qualityLevel)
		{
			if (_presetEntries == null || _presetEntries.Count == 0)
			{
				return;
			}
			foreach (QualityConnectionSO.PresetConnectionEntry presetEntry in _presetEntries)
			{
				if (!(presetEntry.Connection == null))
				{
					IConnection<bool> connection = presetEntry.Connection.GetConnection();
					if (connection != null)
					{
						bool value = presetEntry.GetValue(qualityLevel);
						connection.Set(value);
						Settings.PullFromConnection(connection);
					}
				}
			}
			Settings.RefreshRegisteredResolvers();
			Debug.Log($"[QualityConnection] Preset overrides applied for quality level: {qualityLevel}");
		}

		public void SetSettings(Settings settings)
		{
			Settings = settings;
		}

		public Settings GetSettings()
		{
			return Settings;
		}
	}
}
