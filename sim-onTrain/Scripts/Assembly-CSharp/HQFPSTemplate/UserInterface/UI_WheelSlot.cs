using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_WheelSlot : UI_ItemSlotInterface
	{
		public enum SelectionGraphicState
		{
			Normal = 0,
			Highlighted = 1
		}

		[BHeader("Item Wheel Slot", true)]
		[SerializeField]
		[MinMax(0f, 360f, true)]
		private Vector2 m_AngleCoverage = Vector2.zero;

		[Space]
		[SerializeField]
		private Image m_SelectionGraphic;

		[SerializeField]
		private Color m_SelectionGraphicColor = Color.gray;

		[SerializeField]
		private Color m_SelectionGraphicSelectedColor = Color.white;

		[SerializeField]
		private Color m_SelectionGraphicHighlightedColor = Color.gray;

		[Space]
		[SerializeField]
		private SoundPlayer m_HighlightAudio;

		public Vector2 AngleCoverage => m_AngleCoverage;

		public override void Select()
		{
			base.Select();
			if (base.UIManager.ItemWheel.Active)
			{
				m_HighlightAudio.Play2D();
			}
		}

		public void SetSlotHighlights(SelectionGraphicState state)
		{
			switch (state)
			{
			case SelectionGraphicState.Normal:
				if (m_Selected)
				{
					m_SelectionGraphic.color = m_SelectionGraphicSelectedColor;
				}
				else
				{
					m_SelectionGraphic.color = m_SelectionGraphicColor;
				}
				break;
			case SelectionGraphicState.Highlighted:
				m_SelectionGraphic.color = m_SelectionGraphicHighlightedColor;
				break;
			}
		}
	}
}
