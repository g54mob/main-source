using System;
using UnityEngine;
using UnityEngine.Video;

namespace VampireSurvivors.App.Tools
{
	public class VideoPlayerHelper : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer _VideoPlayer;

		private Material _videoMat;

		private Action _onFrameReady;

		public Renderer VideoRenderer => null;

		private void Awake()
		{
		}

		public void SetClip(VideoClip clip)
		{
		}

		public void Play(Action onFrameReady = null)
		{
		}

		public void Stop()
		{
		}

		public void SetDepth(float depth)
		{
		}

		public void SetToRenderTextureMode(RenderTexture renderTexture)
		{
		}

		private void OnPrepareCompleted(VideoPlayer source)
		{
		}
	}
}
