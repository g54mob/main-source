using System;
using UnityEngine;

namespace NSEipix.View.UI
{
	[Serializable]
	public class TradingSortArrowImages : MonoBehaviour
	{
		[SerializeField]
		private GameObject arrowUp;

		[SerializeField]
		private GameObject arrowUpOn;

		[SerializeField]
		private GameObject arrowDown;

		[SerializeField]
		private GameObject arrowDownOn;

		public void SetArrows(bool upDown, bool isOn)
		{
			GameObject gameObject = null;
			gameObject = ((!isOn) ? (upDown ? arrowUp : arrowDown) : (upDown ? arrowUpOn : arrowDownOn));
			arrowUp.SetActive(gameObject == arrowUp);
			arrowUpOn.SetActive(gameObject == arrowUpOn);
			arrowDown.SetActive(gameObject == arrowDown);
			arrowDownOn.SetActive(gameObject == arrowDownOn);
		}
	}
}
