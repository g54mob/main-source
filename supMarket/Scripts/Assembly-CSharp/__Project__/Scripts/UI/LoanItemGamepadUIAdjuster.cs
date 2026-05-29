using UnityEngine;

namespace __Project__.Scripts.UI
{
	public class LoanItemGamepadUIAdjuster : MonoBehaviour
	{
		[SerializeField]
		private RectTransform m_LoanSliderRectTransform;

		[SerializeField]
		private RectTransform m_ApproveRectTransform;

		[SerializeField]
		private Vector2 m_sliderGamepadPosition;

		[SerializeField]
		private Vector2 m_sliderKeyboardPosition;

		[SerializeField]
		private Vector2 m_buttonGamepadPosition;

		[SerializeField]
		private Vector2 m_buttonKeyboardPosition;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
