using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Xml
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public class SimpleContentSizeFitter : UIBehaviour, ILayoutSelfController, ILayoutController, ILayoutGroup
	{
		private DrivenRectTransformTracker m_Tracker;

		private RectTransform m_rectTransform;

		private bool m_updateQueued;

		private RectTransform rectTransform
		{
			get
			{
				if (m_rectTransform == null)
				{
					m_rectTransform = GetComponent<RectTransform>();
				}
				return m_rectTransform;
			}
		}

		void ILayoutController.SetLayoutHorizontal()
		{
		}

		void ILayoutController.SetLayoutVertical()
		{
			if (!m_updateQueued)
			{
				m_updateQueued = true;
				XmlLayoutTimer.AtEndOfFrame(MatchChildDimensions, this);
			}
		}

		public void MatchChildDimensions()
		{
			m_Tracker.Clear();
			if (rectTransform.childCount > 1)
			{
				Debug.LogWarning("SimpleContentSizeFitter:: This layout element will only function correctly if this element has a single child.");
				m_updateQueued = false;
				return;
			}
			if (rectTransform.childCount != 1)
			{
				m_updateQueued = false;
				return;
			}
			RectTransform obj = rectTransform.GetChild(0) as RectTransform;
			float height = obj.rect.height;
			float width = obj.rect.width;
			m_Tracker.Add(this, rectTransform, DrivenTransformProperties.SizeDelta);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
			m_updateQueued = false;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_Tracker.Clear();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			MatchChildDimensions();
		}
	}
}
