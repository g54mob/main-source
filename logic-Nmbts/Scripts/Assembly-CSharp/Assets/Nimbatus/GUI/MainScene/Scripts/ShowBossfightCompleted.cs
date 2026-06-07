using System.Collections;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowBossfightCompleted : MonoBehaviour
	{
		public TweenPosition MissionCompletedTween;

		public UILabel MissionLabel;

		public UITexture Background;

		public float ShowDuration;

		public string MissionCompleteSound;

		public void Activate(BossFight fight, bool completed)
		{
			StartCoroutine(Show(fight, completed));
		}

		private IEnumerator Show(BossFight fight, bool completed)
		{
			string translation = (completed ? LocalizationManager.GetTermTranslation("MainScene/MissionXCompleted") : LocalizationManager.GetTermTranslation("MainScene/MissionXFailed"));
			LocalizationManager.ApplyLocalizationParams(ref translation, "MissionName", fight.Name.GetTranslation());
			MissionLabel.text = translation;
			Background.height = MissionLabel.height + 40;
			MissionCompletedTween.PlayForward();
			if (completed && !string.IsNullOrEmpty(MissionCompleteSound))
			{
				AudioController.Play(MissionCompleteSound);
			}
			yield return new WaitForSecondsRealtime(MissionCompletedTween.duration);
			yield return new WaitForSecondsRealtime(ShowDuration);
			MissionCompletedTween.PlayReverse();
		}
	}
}
