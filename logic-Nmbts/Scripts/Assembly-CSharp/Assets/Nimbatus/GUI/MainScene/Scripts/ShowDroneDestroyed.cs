using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowDroneDestroyed : MonoBehaviour
	{
		public TweenPosition Tween;

		public float ShowDuration;

		public bool ExitSceneAutomatically;

		[ShowIf("ExitSceneAutomatically", true)]
		public string SceneName;

		private bool _hasPlayed;

		public void Update()
		{
			if (!_hasPlayed && RuntimeGlobals.IsGameOver && !RuntimeGlobals.IsGamePaused)
			{
				StartCoroutine(ShowEndScreen());
				_hasPlayed = true;
			}
		}

		private IEnumerator ShowEndScreen()
		{
			Tween.PlayForward();
			yield return new WaitForSecondsRealtime(Tween.duration);
			yield return new WaitForSecondsRealtime(ShowDuration);
			Tween.PlayReverse();
			if (ExitSceneAutomatically)
			{
				NimbatusSceneManager.SetReturnScene("MissionRewardScene", SceneName);
				NimbatusSceneManager.LoadScene("MissionRewardScene");
			}
		}
	}
}
