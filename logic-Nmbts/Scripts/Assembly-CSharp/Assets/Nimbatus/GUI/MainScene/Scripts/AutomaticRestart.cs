using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class AutomaticRestart : MonoBehaviour
	{
		public UILabel CountDownLabel;

		public int CountDownTime;

		private bool _hasStarted;

		public void Update()
		{
			if (!_hasStarted && RuntimeGlobals.IsGameOver)
			{
				_hasStarted = true;
				StartCoroutine(CountDown());
			}
		}

		private IEnumerator CountDown()
		{
			int counter = CountDownTime;
			while (counter > 0)
			{
				counter--;
				CountDownLabel.text = counter.ToString();
				yield return new WaitForSeconds(1f);
			}
			WorldController.Seed = Random.Range(0, 1000);
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			NimbatusSceneManager.ReloadCurrentScene();
		}
	}
}
