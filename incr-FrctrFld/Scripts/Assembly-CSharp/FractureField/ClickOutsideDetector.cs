using UnityEngine;
using UnityEngine.Events;

namespace FractureField
{
	public class ClickOutsideDetector : MonoBehaviour
	{
		public RectTransform targetRectTransform;

		public Canvas canvas;

		public UnityEvent onClickedOutside;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
