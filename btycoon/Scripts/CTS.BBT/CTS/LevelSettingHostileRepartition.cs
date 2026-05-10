using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Hostile Repartition")]
	public class LevelSettingHostileRepartition : LevelSetting
	{
		[SerializeField]
		private PercentageList<StringKey> _hostiles = new PercentageList<StringKey>();

		public override void Apply()
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.SetRepartition(_hostiles);
		}
	}
}
