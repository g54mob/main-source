using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class NavSlider : InteractableNavElement
	{
		[Header("Slider")]
		[SerializeField]
		private Slider m_slider;

		private float m_value
		{
			get
			{
				return m_slider.value;
			}
			set
			{
				m_slider.value = value;
			}
		}

		private float m_stepSize
		{
			get
			{
				if (!m_slider.wholeNumbers)
				{
					return (m_slider.maxValue - m_slider.minValue) * 0.1f;
				}
				return 1f;
			}
		}

		private bool m_reverseValue
		{
			get
			{
				Slider.Direction direction = m_slider.direction;
				return direction == Slider.Direction.RightToLeft || direction == Slider.Direction.TopToBottom;
			}
		}

		protected override IEnumerable<Selectable> GetChildSelectables()
		{
			if (m_slider != null)
			{
				yield return m_slider;
			}
			foreach (Selectable childSelectable in base.GetChildSelectables())
			{
				yield return childSelectable;
			}
		}

		public override void OnMove(AxisEventData eventData)
		{
			base.OnMove(eventData);
			Slider.Direction direction = m_slider.direction;
			RectTransform.Axis axis = ((direction != Slider.Direction.LeftToRight && direction != Slider.Direction.RightToLeft) ? RectTransform.Axis.Vertical : RectTransform.Axis.Horizontal);
			switch (eventData.moveDir)
			{
			case MoveDirection.Left:
				if (axis == RectTransform.Axis.Horizontal)
				{
					m_value = (m_reverseValue ? (m_value + m_stepSize) : (m_value - m_stepSize));
				}
				break;
			case MoveDirection.Right:
				if (axis == RectTransform.Axis.Horizontal)
				{
					m_slider.value = (m_reverseValue ? (m_value - m_stepSize) : (m_value + m_stepSize));
				}
				break;
			}
		}
	}
}
