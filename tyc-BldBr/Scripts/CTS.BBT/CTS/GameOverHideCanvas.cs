using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class GameOverHideCanvas : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupFader _canvasGroup;

		protected override void OnAwake()
		{
			base.OnAwake();
			GameOver.GameOverTriggered += OnGameOverTriggered;
		}

		private void OnDestroy()
		{
			GameOver.GameOverTriggered -= OnGameOverTriggered;
			_canvasGroup.RemoveFade(this);
		}

		private void OnGameOverTriggered(GameOverUIData obj)
		{
			GameOver.GameOverTriggered -= OnGameOverTriggered;
			_canvasGroup.AddFade(this, 0f);
		}
	}
}
