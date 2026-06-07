using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class TutorialEndScreen : MonoBehaviour
	{
		private TweenPosition _tween;

		public void Awake()
		{
			_tween = GetComponent<TweenPosition>();
		}

		public void Update()
		{
			if (GenericTutorialLogic.Instance != null)
			{
				if (GenericTutorialLogic.Instance.TutorialFinished)
				{
					_tween.PlayForward();
				}
				else
				{
					_tween.PlayReverse();
				}
			}
		}
	}
}
