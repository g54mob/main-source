using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class LevelSettings : CTSSingleton<LevelSettings>
	{
		[SerializeField]
		private SerializableDictionary<MapInfoSO, MapLevelSettings> _settings = new SerializableDictionary<MapInfoSO, MapLevelSettings>();

		public ReadOnlyDictionary<MapInfoSO, MapLevelSettings> Settings => _settings;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
