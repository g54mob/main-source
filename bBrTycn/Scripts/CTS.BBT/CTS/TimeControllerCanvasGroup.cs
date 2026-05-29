using CTS.BBT;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class TimeControllerCanvasGroup : MonoBehaviour
	{
		private CanvasGroupController _controller;

		private void Awake()
		{
			_controller = GetComponent<CanvasGroupController>();
		}

		private void OnEnable()
		{
			TimeController.OnTimeScaleChanged += OnTimeScaleChanged;
		}

		private void OnDisable()
		{
			TimeController.OnTimeScaleChanged -= OnTimeScaleChanged;
		}

		private void OnTimeScaleChanged(float value)
		{
			if (value <= 0f)
			{
				_controller.QuickShow();
			}
			else
			{
				_controller.QuickHide();
			}
		}
	}
}
