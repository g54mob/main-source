using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "QualityConnection", menuName = "SettingsGenerator/Connection/QualityConnection", order = 4)]
	public class QualityConnectionSO : OptionConnectionSO
	{
		[Serializable]
		public class PresetConnectionEntry
		{
			public BoolConnectionSO Connection;

			public bool VeryLow;

			public bool Low;

			public bool Medium;

			public bool High;

			public bool GetValue(int qualityLevel)
			{
				return qualityLevel switch
				{
					0 => High, 
					1 => Medium, 
					2 => Low, 
					3 => VeryLow, 
					_ => false, 
				};
			}
		}

		[NonSerialized]
		[Obsolete("BUGFIX: The settings are now handed over automatically via the IConnectionWithSettingsAccess.SetSettings(Settings settings) method. This is no longer used and has no effect.")]
		[HideInInspector]
		public SettingsProvider SettingsProvider;

		[Header("Preset Connection Overrides")]
		public List<PresetConnectionEntry> PresetEntries = new List<PresetConnectionEntry>();

		protected QualityConnection _connection;

		public override IConnectionWithOptions<string> GetConnection()
		{
			if (_connection == null)
			{
				Create();
			}
			return _connection;
		}

		public void Create()
		{
			_connection = new QualityConnection();
			_connection.SetPresetEntries(PresetEntries);
		}

		public override void DestroyConnection()
		{
			if (_connection != null)
			{
				_connection.Destroy();
			}
			_connection = null;
		}
	}
}
