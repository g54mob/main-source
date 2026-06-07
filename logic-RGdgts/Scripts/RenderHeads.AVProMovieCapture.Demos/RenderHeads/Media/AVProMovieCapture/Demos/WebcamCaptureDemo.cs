using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture.Demos
{
	public class WebcamCaptureDemo : MonoBehaviour
	{
		[SerializeField]
		private GUISkin _skin;

		[SerializeField]
		private GameObject _prefab;

		[SerializeField]
		private int _webcamResolutionWidth;

		[SerializeField]
		private int _webcamResolutionHeight;

		[SerializeField]
		private int _webcamFrameRate;

		private void Start()
		{
		}
	}
}
