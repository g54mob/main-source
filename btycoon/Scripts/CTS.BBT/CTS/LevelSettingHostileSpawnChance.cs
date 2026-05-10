using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Hostile Spawn Chance")]
	public class LevelSettingHostileSpawnChance : LevelSetting
	{
		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _spawnChance = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public override void Apply()
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.SetSpawnChance(_spawnChance);
		}
	}
}
