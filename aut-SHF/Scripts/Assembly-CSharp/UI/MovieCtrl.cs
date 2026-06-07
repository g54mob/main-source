using InputControl;
using Libs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
	public class MovieCtrl : SingletonMonoBehaviour<MovieCtrl>
	{
		[SerializeField]
		private CanvasGroup fadeImage;

		[SerializeField]
		private VideoPlayerCtrl playerCtrl;

		[SerializeField]
		private EventTrigger trigger;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		private bool _isPlayed;

		private void Awake()
		{
		}

		public void PlayTrialEndMovie()
		{
		}

		public void OnPadDecide()
		{
		}

		public void OnClickAction(PointerEventData data)
		{
		}
	}
}
