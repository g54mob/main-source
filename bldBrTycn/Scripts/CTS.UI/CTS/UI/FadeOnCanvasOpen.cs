using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public class FadeOnCanvasOpen : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupFader _fader;

		[SerializeField]
		[Range(0f, 1f)]
		private float _fadeValue;

		[SerializeField]
		private List<StringKey> _key;

		private readonly HashSet<CanvasGroupController> _controllers = new HashSet<CanvasGroupController>();

		protected override void OnAwake()
		{
			base.OnAwake();
			CanvasGroupController.SlidingPanel += OnCanvasShowing;
			CanvasGroupController.PanelSlided += OnCanvasShowed;
		}

		private void OnDestroy()
		{
			CanvasGroupController.SlidingPanel -= OnCanvasShowing;
			CanvasGroupController.PanelSlided -= OnCanvasShowed;
			foreach (CanvasGroupController controller in _controllers)
			{
				_fader.RemoveFade(controller);
			}
			_controllers.Clear();
		}

		private void OnCanvasShowing(CanvasGroupController canvasGroupController, bool value)
		{
			if (_key.Contains(canvasGroupController.IdKey) && value)
			{
				_controllers.Add(canvasGroupController);
				_fader.AddFade(canvasGroupController, _fadeValue);
			}
		}

		private void OnCanvasShowed(CanvasGroupController canvasGroupController, bool value)
		{
			if (_key.Contains(canvasGroupController.IdKey) && !value)
			{
				_controllers.Remove(canvasGroupController);
				_fader.RemoveFade(canvasGroupController);
			}
		}
	}
}
