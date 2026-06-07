using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Missions;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowMissionCompleted : MonoBehaviour
	{
		public TweenPosition MissionCompletedTween;

		public UILabel MissionLabel;

		public UITexture Background;

		public float ShowDuration;

		public string MissionCompleteSound;

		public void OnEnable()
		{
			MissionManager.OnMissionCompleted += MissionManager_MissionCompleted;
			MissionManager.OnMissionFailed += MissionManager_MissionFailed;
		}

		public void OnDisable()
		{
			MissionManager.OnMissionCompleted -= MissionManager_MissionCompleted;
			MissionManager.OnMissionFailed -= MissionManager_MissionFailed;
		}

		private void MissionManager_MissionCompleted(NimbatusMission obj)
		{
			StartCoroutine(Show(obj, true));
		}

		private void MissionManager_MissionFailed(NimbatusMission obj)
		{
			StartCoroutine(Show(obj, false));
		}

		private IEnumerator Show(NimbatusMission mission, bool completed)
		{
			string translation = (completed ? LocalizationManager.GetTermTranslation("MainScene/MissionXCompleted") : LocalizationManager.GetTermTranslation("MainScene/MissionXFailed"));
			LocalizationManager.ApplyLocalizationParams(ref translation, "MissionName", mission.GetTitle());
			MissionLabel.text = translation;
			Background.height = MissionLabel.height + 40;
			MissionCompletedTween.PlayForward();
			if (completed && !string.IsNullOrEmpty(MissionCompleteSound))
			{
				AudioController.Play(MissionCompleteSound);
			}
			yield return new WaitForSecondsRealtime(MissionCompletedTween.duration);
			yield return new WaitForSecondsRealtime(ShowDuration);
			if (mission.ExitOnFinish)
			{
				yield return new WaitForSecondsRealtime(MissionCompletedTween.duration);
				NimbatusSceneManager.LoadScene("MissionRewardScene");
			}
			else
			{
				MissionCompletedTween.PlayReverse();
			}
		}
	}
}
