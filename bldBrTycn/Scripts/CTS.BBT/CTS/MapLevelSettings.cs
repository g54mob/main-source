using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Map Settings")]
	public class MapLevelSettings : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<EGameMode, LevelSettingsList> _modeSettings = new SerializableDictionary<EGameMode, LevelSettingsList>();

		[field: SerializeField]
		[field: Expandable]
		public LevelSettingsList BaseSettings { get; private set; }

		public ReadOnlyDictionary<EGameMode, LevelSettingsList> ModeSettings => _modeSettings;
	}
}
