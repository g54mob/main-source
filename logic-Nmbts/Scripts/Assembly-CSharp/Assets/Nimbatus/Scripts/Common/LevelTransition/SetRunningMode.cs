using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.LevelTransition
{
	public class SetRunningMode : MonoBehaviour
	{
		public ERunningMode RunningMode;

		public void Awake()
		{
			RuntimeGlobals.RunningMode = RunningMode;
			RuntimeGlobals.Settings.ApplySoundSettings();
		}
	}
}
