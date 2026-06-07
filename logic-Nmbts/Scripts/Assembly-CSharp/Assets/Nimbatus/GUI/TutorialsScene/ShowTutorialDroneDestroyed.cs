using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class ShowTutorialDroneDestroyed : MonoBehaviour
	{
		private TweenPosition _tween;

		private bool _hasPlayed;

		public void Awake()
		{
			_tween = GetComponent<TweenPosition>();
		}

		public void Update()
		{
			if (!_hasPlayed && GenericTutorialLogic.Instance != null && GenericTutorialLogic.Instance.IsDroneDead && RuntimeGlobals.IsGameOver && !RuntimeGlobals.IsGamePaused)
			{
				_tween.Play(true);
				_hasPlayed = true;
			}
			if (_hasPlayed && !RuntimeGlobals.IsGameOver && (GenericTutorialLogic.Instance == null || !GenericTutorialLogic.Instance.IsDroneDead))
			{
				_tween.Play(false);
				_hasPlayed = false;
			}
		}
	}
}
