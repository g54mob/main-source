using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture.Demos
{
	public class ScreenCaptureDemo : MonoBehaviour
	{
		[SerializeField]
		private AudioClip _audioBG;

		[SerializeField]
		private AudioClip _audioHit;

		[SerializeField]
		private float _speed;

		[SerializeField]
		private CaptureBase _capture;

		[SerializeField]
		private GUISkin _guiSkin;

		[SerializeField]
		private bool _spinCamera;

		private float _timer;

		private List<FileWritingHandler> _fileWritingHandlers;

		private IEnumerator Start()
		{
			return null;
		}

		private void OnBeginFinalFileWriting(FileWritingHandler handler)
		{
		}

		private void OnCompleteFinalFileWriting(FileWritingHandler handler)
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnGUI()
		{
		}
	}
}
