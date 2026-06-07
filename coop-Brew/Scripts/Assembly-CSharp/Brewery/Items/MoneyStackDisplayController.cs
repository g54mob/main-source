using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Items
{
	public class MoneyStackDisplayController : MonoBehaviour
	{
		[Header("Animation")]
		[SerializeField]
		private float animationDuration;

		[SerializeField]
		private float staggerDelay;

		[SerializeField]
		private float scaleOvershoot;

		[SerializeField]
		private float dropHeight;

		private List<Transform> stackChildren;

		private List<Vector3> originalScales;

		private int currentVisibleCount;

		private bool initialized;

		private bool firstUpdate;

		private void EnsureInitialized()
		{
		}

		private void Awake()
		{
		}

		public void UpdateDisplay(int totalCurrency, int currencyPerChild)
		{
		}

		public void ClearDisplay()
		{
		}

		private void AnimateChildIn(Transform child, float delay)
		{
		}

		private void AnimateChildOut(Transform child, float delay)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
