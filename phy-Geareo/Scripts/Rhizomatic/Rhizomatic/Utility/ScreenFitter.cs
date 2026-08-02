using UnityEngine;

namespace Rhizomatic.Utility
{
	public class ScreenFitter : MonoBehaviour
	{
		public RectTransform screen;

		public RectTransform rect;

		public RectTransform read;

		private Vector3[] screenCorners;

		private Vector3[] rectCorners;

		private void LateUpdate()
		{
		}
	}
}
