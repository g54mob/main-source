using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Use Circumstantial Missions")]
	public class LevelSettingsCircumstantialMissions : LevelSetting
	{
		[field: SerializeField]
		public bool UseMissions { get; set; } = true;

		public override void Apply()
		{
			ComponentGetter.GetComponentSingleSingleton(typeof(CircumstantialQuestsManager))?.Cast<CircumstantialQuestsManager>().gameObject.SetActive(UseMissions);
		}
	}
}
