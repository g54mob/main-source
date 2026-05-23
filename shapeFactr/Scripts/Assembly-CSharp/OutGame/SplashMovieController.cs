using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

namespace OutGame
{
	public class SplashMovieController : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer _vp;

		[SerializeField]
		private string _videoClip;

		[SerializeField]
		private string _steamVideoClip;

		[SerializeField]
		private float clipLength;

		[SerializeField]
		private GameObject _blind;

		[SerializeField]
		private InputActionReference _skipMovieAction;

		private Tween _finishedMovieTween;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void VpOnerrorReceived(VideoPlayer source, string message)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnSkipMovieInput(InputAction.CallbackContext context)
		{
		}

		private void Start()
		{
		}

		public void SkipMovie()
		{
		}
	}
}
