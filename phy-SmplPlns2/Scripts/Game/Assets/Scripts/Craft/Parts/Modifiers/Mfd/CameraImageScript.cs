using Assets.Scripts.Flight.Cameras;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class CameraImageScript : MonoBehaviour, ICameraVideoStreamConsumer
	{
		private RawImage _cameraImage;

		private ICameraVideoStream _videoStream;

		public string Name => "Camera Image";

		public ICameraVideoStreamSource Source { get; set; }

		protected virtual void Awake()
		{
			_cameraImage = GetComponent<RawImage>();
		}

		protected virtual void OnDisable()
		{
			StopVideo();
		}

		protected virtual void Update()
		{
			ICameraVideoStreamSource source = Source;
			if (source != null && source.IsActive)
			{
				if (_videoStream == null)
				{
					StartVideo();
				}
			}
			else
			{
				StopVideo();
			}
		}

		private void OnVideoStreamReleased(ICameraVideoStream videoStream)
		{
			StopVideo();
		}

		private void StartVideo()
		{
			if (Source != null)
			{
				_videoStream = Source.RequestVideoStream(this);
				_videoStream.Released += OnVideoStreamReleased;
				_cameraImage.texture = _videoStream.RenderTexture;
			}
		}

		private void StopVideo()
		{
			if (_videoStream != null)
			{
				_videoStream.Released -= OnVideoStreamReleased;
				Source.ReleaseVideoStream(this);
				_cameraImage.texture = null;
				_videoStream = null;
			}
		}
	}
}
