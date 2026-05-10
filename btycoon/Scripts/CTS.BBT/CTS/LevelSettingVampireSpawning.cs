using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Vampire Spawning")]
	public class LevelSettingVampireSpawning : LevelSetting
	{
		[SerializeField]
		private bool _canSpawn = true;

		public override void Apply()
		{
			CTSSingleton<CustomerSpawner>.Instance.SpawnsVampires = _canSpawn;
		}
	}
}
