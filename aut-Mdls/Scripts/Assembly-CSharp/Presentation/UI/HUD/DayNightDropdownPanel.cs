using UnityEngine;

namespace Presentation.UI.HUD
{
	public class DayNightDropdownPanel : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private DayNightDropdown _dropdown;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, Input.mousePosition, null))
			{
				_dropdown.OpenDropdown(open: false);
			}
		}
	}
}
