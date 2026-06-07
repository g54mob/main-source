using System;
using Events;
using Events.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI
{
	public abstract class InfoPanelContent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private ShowInfoPanelEvent showInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[SerializeField]
		protected bool _moveToTop;

		private bool _isOpen;

		public bool IsOpen => _isOpen;

		public event Action OnShow = delegate
		{
		};

		public event Action OnHide = delegate
		{
		};

		private void OnDestroy()
		{
			HideInfoPanel();
		}

		protected virtual void OnDisable()
		{
			HideInfoPanel();
		}

		private void HideInfoPanel()
		{
			if (_isOpen)
			{
				_hideInfoPanelEvent.Fire();
				_isOpen = false;
				this.OnHide();
			}
		}

		public void ForceUpdate()
		{
			if (_isOpen)
			{
				InfoPanelDto infoPanelDto = GetInfoPanelDto();
				infoPanelDto.MoveToTop = _moveToTop;
				_isOpen = true;
				showInfoPanelEvent.Fire(infoPanelDto);
				this.OnShow();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			InfoPanelDto infoPanelDto = GetInfoPanelDto();
			if (infoPanelDto != null)
			{
				infoPanelDto.MoveToTop = _moveToTop;
				_isOpen = true;
				showInfoPanelEvent.Fire(infoPanelDto);
				this.OnShow();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			HideInfoPanel();
		}

		protected abstract InfoPanelDto GetInfoPanelDto();
	}
}
