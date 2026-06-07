using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utilities
{
	public class WaitingAnimation : MonoBehaviour
	{
		[SerializeField]
		private List<Image> animationImages;

		private Coroutine waitingCo;

		private int i;

		public void StartWaiting()
		{
		}

		public void StopWaiting()
		{
		}

		private IEnumerator WaitingCO()
		{
			return null;
		}

		private void HideImages()
		{
		}
	}
}
