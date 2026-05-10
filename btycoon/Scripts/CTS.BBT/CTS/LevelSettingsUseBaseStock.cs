using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LevelSettingsUseBaseStock : LevelSetting
	{
		[field: SerializeField]
		public bool UseBaseStorage { get; set; } = true;

		public override void Apply()
		{
			CTSSingleton<LevelParameters>.Instance.UseBaseStorage = UseBaseStorage;
		}
	}
}
