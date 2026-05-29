using CTS.Core;
using CTS.TechTree;
using UnityEngine;

namespace CTS
{
	public class LevelSettingBaseTechPoints : LevelSetting
	{
		[field: SerializeField]
		public int Value { get; set; }

		public override void Apply()
		{
			if (GameMode.IsNewGame)
			{
				CTSSingleton<TechTreePoints>.Instance.SetPoints(Value);
			}
		}
	}
}
