using UnityEngine;

namespace Water2D
{
	public class cameraManip : MonoBehaviour
	{
		[SerializeField]
		private bool scrolling;

		[SerializeField]
		private bool focus;

		[SerializeField]
		private float scrollingSpeed;

		[SerializeField]
		private Transform objF;

		[SerializeField]
		private float baseFocus;

		private float cachedSize;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
