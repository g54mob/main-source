using System;
using CTS.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[Obsolete("This class is deprecated and has been reworked (Check MachineUI)")]
	public class UIProgress : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _controller;

		[SerializeField]
		private Image _fill;

		[SerializeField]
		private Image _icon;

		public void SetVisibility(bool visible)
		{
			_controller.ShowCanvasGroup(visible, 0.1f);
		}

		public void SetupProgress()
		{
			_fill.DOKill();
			_fill.fillAmount = 0f;
			_fill.DOFade(1f, 0f);
		}

		public void SetProgress(float normalizedProgress)
		{
			_fill.fillAmount = normalizedProgress;
		}

		public void HideProgress()
		{
			_fill.DOFade(0f, 0.5f);
		}

		public void SetIcon(Sprite sprite)
		{
			_icon.sprite = sprite;
		}
	}
}
