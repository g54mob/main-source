using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Head Size")]
	public class LevelSettingsHeadSize : LevelSetting
	{
		[field: SerializeField]
		public float HeadSize { get; set; } = 1f;

		public override void Apply()
		{
			AgentHeadSize.Size = HeadSize;
		}
	}
}
