using System;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.FinalStates
{
	[Serializable]
	public class CanvasGroupFinalState
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float finalAlpha = 1f;

		public void ApplySettings()
		{
			canvasGroup.alpha = finalAlpha;
		}
	}
}
