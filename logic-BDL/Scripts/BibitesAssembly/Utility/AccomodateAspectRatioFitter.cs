using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Utility
{
	[ExecuteAlways]
	public class AccomodateAspectRatioFitter : UIBehaviour
	{
		[SerializeField]
		private RectTransform siblingToAccomodate;

		[SerializeField]
		private SideControlled sideControlled = SideControlled.Width;

		private RectTransform m_rt;

		private RectTransform m_parentRT;

		private HorizontalOrVerticalLayoutGroup m_parentLayoutGroup;

		private RectTransform rt
		{
			get
			{
				if (m_rt == null)
				{
					m_rt = GetComponent<RectTransform>();
				}
				return m_rt;
			}
		}

		private RectTransform parentRT
		{
			get
			{
				if (m_parentRT == null)
				{
					m_parentRT = base.transform.parent.GetComponent<RectTransform>();
				}
				return m_parentRT;
			}
		}

		private HorizontalOrVerticalLayoutGroup parentLayoutGroup
		{
			get
			{
				if (m_parentLayoutGroup == null)
				{
					m_parentLayoutGroup = base.transform.parent.GetComponent<HorizontalOrVerticalLayoutGroup>();
				}
				return m_parentLayoutGroup;
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UpdateSide();
		}

		private void UpdateSide()
		{
			if (sideControlled == SideControlled.Height)
			{
				float num = parentRT.rect.height - (float)parentLayoutGroup.padding.top - (float)parentLayoutGroup.padding.bottom - parentLayoutGroup.spacing;
				rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num - siblingToAccomodate.rect.height);
			}
			else
			{
				float num2 = parentRT.rect.width - (float)parentLayoutGroup.padding.left - (float)parentLayoutGroup.padding.right - parentLayoutGroup.spacing;
				rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 - siblingToAccomodate.rect.width);
			}
		}
	}
}
