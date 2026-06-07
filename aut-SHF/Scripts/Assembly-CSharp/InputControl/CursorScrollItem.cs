using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace InputControl
{
	public class CursorScrollItem : CursorUIBase
	{
		[SerializeField]
		private Scrollbar _scrollBar;

		[SerializeField]
		private float _stepSize;

		[SerializeField]
		private bool _isHorizontal;

		private OverridePadInput _overridePadInput;

		private bool _isPushed;

		private void Awake()
		{
		}

		private void CreateOverridePadInput()
		{
		}

		private void OnScrollChange(InputAction.CallbackContext context)
		{
		}

		private void OnScrollCancel(InputAction.CallbackContext context)
		{
		}

		public override void OnDecide()
		{
		}

		private void HighlightScrollbar(bool highlight)
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
