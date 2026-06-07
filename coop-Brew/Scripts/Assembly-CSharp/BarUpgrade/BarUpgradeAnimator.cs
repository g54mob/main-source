using System;
using UnityEngine;

namespace BarUpgrade
{
	public class BarUpgradeAnimator : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool isAnimating;

		public bool IsAnimating => false;

		public void AnimateSingleUpgrade(GameObject targetObject, Action onComplete = null)
		{
		}

		public void CancelAllAnimations()
		{
		}
	}
}
