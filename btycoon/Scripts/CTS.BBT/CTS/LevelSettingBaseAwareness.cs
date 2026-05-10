using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Base Awareness")]
	public class LevelSettingBaseAwareness : LevelSetting
	{
		[field: SerializeField]
		[field: Range(0f, 100f)]
		public float Percent { get; set; }

		public override void Apply()
		{
			if (GameMode.IsNewGame)
			{
				MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(Mathf.RoundToInt(Percent * 0.01f * (float)VigilanceHandlers.MaxVigilance));
			}
		}
	}
}
