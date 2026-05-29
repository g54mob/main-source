using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Hostiles Max Naturals")]
	public class LevelSettingHostileMaxNaturals : LevelSetting
	{
		[SerializeField]
		private int _maxNaturals = 3;

		public override void Apply()
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.SetMaxNaturals(_maxNaturals);
		}
	}
}
