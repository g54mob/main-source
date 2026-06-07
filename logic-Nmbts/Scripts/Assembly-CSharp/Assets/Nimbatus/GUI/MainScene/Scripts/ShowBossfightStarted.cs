using System.Collections;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowBossfightStarted : MonoBehaviour
	{
		public TweenPosition MissionStartTween;

		public UILabel MissionStartLabel;

		public UITexture Background;

		public float ShowDuration;

		public void Activate(BossFight fight)
		{
			StartCoroutine(ShowMission(fight));
		}

		private IEnumerator ShowMission(BossFight fight)
		{
			string translation = fight.Name.GetTranslation();
			MissionStartLabel.text = translation;
			Background.height = MissionStartLabel.height + 40;
			MissionStartTween.PlayForward();
			yield return new WaitForSecondsRealtime(MissionStartTween.duration);
			yield return new WaitForSecondsRealtime(ShowDuration);
			MissionStartTween.PlayReverse();
		}
	}
}
