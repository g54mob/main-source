using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace InputControl
{
	public class CursorSliderItem : CursorUIBase
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private float _stepSize;

		[SerializeField]
		private GameObject _decideCursor;

		private OverridePadInput _overridePadInput;

		private bool _isPushed;

		private void Awake()
		{
		}

		private void CreateOverridePadInput()
		{
		}

		private void OnSliderLeft(InputAction.CallbackContext context)
		{
		}

		private void OnSliderRight(InputAction.CallbackContext context)
		{
		}

		private void OnSliderCancel(InputAction.CallbackContext context)
		{
		}

		public override void OnDecide()
		{
		}

		private void HighlightSlider(bool highlight)
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
