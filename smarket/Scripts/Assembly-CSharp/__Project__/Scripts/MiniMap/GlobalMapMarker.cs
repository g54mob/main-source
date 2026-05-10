using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace __Project__.Scripts.MiniMap
{
	[RequireComponent(typeof(Button))]
	public class GlobalMapMarker : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		protected Image m_HighlightImage;

		[SerializeField]
		protected Color m_HighlightColor;

		[SerializeField]
		protected string m_PlaceName;

		protected Button m_Button;

		protected RectTransform m_RectTransform;

		protected Tweener m_ColorTween;

		[SerializeField]
		protected global::MiniMap m_MiniMap;

		public bool IsSelected { get; protected set; }

		protected virtual void Start()
		{
		}

		public virtual void Highlight()
		{
		}

		public virtual void DeHighlight()
		{
		}

		public virtual void ResetMarker()
		{
		}

		public void SwitchMarker(bool isSelected)
		{
		}

		public void SwitchTooltip(bool isOpen)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}
