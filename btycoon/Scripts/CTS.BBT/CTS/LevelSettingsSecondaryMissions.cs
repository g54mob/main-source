using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Use Secondary Missions")]
	public class LevelSettingsSecondaryMissions : LevelSetting
	{
		[field: SerializeField]
		public bool UseMissions { get; set; } = true;

		public override void Apply()
		{
			ComponentGetter.GetComponentSingleSingleton(typeof(SecondaryQuestsManager))?.Cast<SecondaryQuestsManager>().gameObject.SetActive(UseMissions);
		}
	}
}
