using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class UICanvasGroup : UIObject
	{
		private CanvasGroup _canvasGroup;

		protected override void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			base.Awake();
		}

		protected override bool GetAwakeActive()
		{
			return _canvasGroup.alpha > 0.5f;
		}

		protected override void OnUIEnabled()
		{
			_canvasGroup.alpha = 1f;
			_canvasGroup.interactable = true;
			_canvasGroup.blocksRaycasts = true;
		}

		protected override void OnUIDisabled()
		{
			_canvasGroup.alpha = 0f;
			_canvasGroup.interactable = false;
			_canvasGroup.blocksRaycasts = false;
		}
	}
}
