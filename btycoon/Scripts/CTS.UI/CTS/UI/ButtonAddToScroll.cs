using CTS.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS.UI
{
	public class ButtonAddToScroll : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private ClickAndHoldButton _button;

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private Vector2 _valueChange;

		private PointerEventData _dummyData;

		protected override void OnAwake()
		{
			base.OnAwake();
			_dummyData = new PointerEventData(EventSystem.current);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_button.HeldTick += OnButtonTick;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_button.HeldTick -= OnButtonTick;
		}

		private void OnButtonTick()
		{
			_dummyData.scrollDelta = _valueChange;
			_scrollRect.OnScroll(_dummyData);
		}
	}
}
