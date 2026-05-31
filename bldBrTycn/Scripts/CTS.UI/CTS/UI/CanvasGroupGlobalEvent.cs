using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Events;

namespace CTS.UI
{
	public class CanvasGroupGlobalEvent : CTSBehaviour
	{
		[SerializeField]
		private List<StringKey> _key;

		[SerializeField]
		private UnityEvent _canvasOpening;

		[SerializeField]
		private UnityEvent _canvasClosed;

		[SerializeField]
		private UnityEvent _onDestroy;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CanvasGroupController.SlidingPanel += OnCanvasShowing;
			CanvasGroupController.PanelSlided += OnCanvasShowed;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			CanvasGroupController.SlidingPanel -= OnCanvasShowing;
			CanvasGroupController.PanelSlided -= OnCanvasShowed;
		}

		private void OnDestroy()
		{
			_onDestroy?.Invoke();
		}

		private void OnCanvasShowing(CanvasGroupController canvasGroupController, bool value)
		{
			if (_key.Contains(canvasGroupController.IdKey) && value)
			{
				_canvasOpening.Invoke();
			}
		}

		private void OnCanvasShowed(CanvasGroupController canvasGroupController, bool value)
		{
			if (_key.Contains(canvasGroupController.IdKey) && !value)
			{
				_canvasClosed.Invoke();
			}
		}
	}
}
