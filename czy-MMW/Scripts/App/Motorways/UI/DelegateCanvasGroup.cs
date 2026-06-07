using System;
using UnityEngine;
using UnityEngine.Events;

namespace Motorways.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class DelegateCanvasGroup : MonoBehaviour
	{
		[Serializable]
		public class FieldToggledEvent : UnityEvent<bool>
		{
		}

		private CanvasGroup _canvasGroup;

		[SerializeField]
		private FieldToggledEvent _onInteractableToggled = new FieldToggledEvent();

		[SerializeField]
		private FieldToggledEvent _onBlocksRaycastsToggled = new FieldToggledEvent();

		public CanvasGroup CanvasGroup
		{
			get
			{
				if (_canvasGroup == null)
				{
					_canvasGroup = GetComponent<CanvasGroup>();
				}
				return _canvasGroup;
			}
		}

		public float Alpha
		{
			get
			{
				return CanvasGroup.alpha;
			}
			set
			{
				CanvasGroup.alpha = value;
			}
		}

		public void SetInteractable(bool isInteractable)
		{
			CanvasGroup.interactable = isInteractable;
			if (_onInteractableToggled != null)
			{
				_onInteractableToggled.Invoke(isInteractable);
			}
		}

		public void SetBlocksRaycasts(bool doesBlockRaycasts)
		{
			CanvasGroup.blocksRaycasts = doesBlockRaycasts;
			if (_onInteractableToggled != null)
			{
				_onBlocksRaycastsToggled.Invoke(doesBlockRaycasts);
			}
		}
	}
}
