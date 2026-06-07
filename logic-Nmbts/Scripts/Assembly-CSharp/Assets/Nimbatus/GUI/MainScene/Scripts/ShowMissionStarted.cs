using System.Collections;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowMissionStarted : MonoBehaviour
	{
		public TweenPosition MissionStartTween;

		public UILabel MissionStartLabel;

		public UITexture Background;

		public float ShowDuration;

		private bool _started;

		public void Update()
		{
			if (!RuntimeGlobals.IsGameLoading && !_started)
			{
				StartCoroutine(ShowMission());
				_started = true;
			}
		}

		public IEnumerator ShowMission()
		{
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			if (activeMission != null)
			{
				string title = activeMission.GetTitle();
				MissionStartLabel.text = title;
				Background.height = MissionStartLabel.height + 40;
				MissionStartTween.PlayForward();
				yield return new WaitForSecondsRealtime(MissionStartTween.duration);
				yield return new WaitForSecondsRealtime(ShowDuration);
				MissionStartTween.PlayReverse();
			}
		}
	}
}
