using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Vigilance Data")]
	public class LevelSettingsVigilanceData : LevelSetting
	{
		[field: SerializeField]
		[field: MaxValue(0)]
		public int ValueToDecreasePerDay { get; private set; } = -1;

		[field: SerializeField]
		[field: Min(1f)]
		public int VigilanceForRaid { get; set; } = 100;

		public override void Apply()
		{
			VigilanceHandlers.Data = this;
		}
	}
}
