using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.ModuleViewer
{
	public class ModuleViewerHoverComponent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _hoverBorder;

		public event Action OnHoverStart = delegate
		{
		};

		public event Action OnHoverEnd = delegate
		{
		};

		public void OnPointerEnter(PointerEventData eventData)
		{
			_hoverBorder.DOFade(1f, 0.2f);
			this.OnHoverStart();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_hoverBorder.DOFade(0f, 0.2f);
			this.OnHoverEnd();
		}
	}
}
