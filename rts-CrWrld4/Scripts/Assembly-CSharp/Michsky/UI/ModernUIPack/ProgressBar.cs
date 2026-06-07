using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class ProgressBar : MonoBehaviour
	{
		public Transform loadingBar;

		public Transform textPercent;

		public bool isOn;

		public bool restart;

		public float currentPercent;

		public int speed;

		public bool enableSpecified;

		public bool enableLoop;

		public float specifiedValue;

		private void Update()
		{
		}
	}
}
