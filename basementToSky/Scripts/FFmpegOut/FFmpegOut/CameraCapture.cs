using System.Collections;
using System.IO;
using UnityEngine;

namespace FFmpegOut
{
	[AddComponentMenu("FFmpegOut/Camera Capture")]
	public sealed class CameraCapture : MonoBehaviour
	{
		[HideInInspector]
		public string customPath = "";

		[SerializeField]
		private int _width = 1920;

		[SerializeField]
		private int _height = 1080;

		[SerializeField]
		private FFmpegPreset _preset;

		[SerializeField]
		private float _frameRate = 60f;

		private FFmpegSession _session;

		private RenderTexture _tempRT;

		private GameObject _blitter;

		private int _frameCount;

		private float _startTime;

		private int _frameDropCount;

		public int width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public int height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		public FFmpegPreset preset
		{
			get
			{
				return _preset;
			}
			set
			{
				_preset = value;
			}
		}

		public float frameRate
		{
			get
			{
				return _frameRate;
			}
			set
			{
				_frameRate = value;
			}
		}

		private float FrameTime => _startTime + ((float)_frameCount - 0.5f) / _frameRate;

		private RenderTextureFormat GetTargetFormat(Camera camera)
		{
			if (!camera.allowHDR)
			{
				return RenderTextureFormat.Default;
			}
			return RenderTextureFormat.DefaultHDR;
		}

		private int GetAntiAliasingLevel(Camera camera)
		{
			if (!camera.allowMSAA)
			{
				return 1;
			}
			return QualitySettings.antiAliasing;
		}

		private void WarnFrameDrop()
		{
			if (++_frameDropCount == 10)
			{
				Debug.LogWarning("Significant frame droppping was detected. This may introduce time instability into output video. Decreasing the recording frame rate is recommended.");
			}
		}

		private void OnValidate()
		{
			_width = Mathf.Max(8, _width);
			_height = Mathf.Max(8, _height);
		}

		private void OnDisable()
		{
			if (_session != null)
			{
				_session.Close();
				_session.Dispose();
				_session = null;
			}
			if (_tempRT != null)
			{
				GetComponent<Camera>().targetTexture = null;
				Object.Destroy(_tempRT);
				_tempRT = null;
			}
			if (_blitter != null)
			{
				Object.Destroy(_blitter);
				_blitter = null;
			}
		}

		private IEnumerator Start()
		{
			WaitForEndOfFrame eof = new WaitForEndOfFrame();
			while (true)
			{
				yield return eof;
				_session?.CompletePushFrames();
			}
		}

		private void Update()
		{
			Camera component = GetComponent<Camera>();
			if (_session == null)
			{
				if (component.targetTexture == null)
				{
					_tempRT = RenderTexture.GetTemporary(_width, _height, 24, GetTargetFormat(component));
					_tempRT.antiAliasing = GetAntiAliasingLevel(component);
					component.targetTexture = _tempRT;
					_blitter = Blitter.CreateInstance(component);
				}
				if (!string.IsNullOrEmpty(customPath))
				{
					_session = FFmpegSession.CreateWithOutputPath(customPath + _preset.GetSuffix(), component.targetTexture.width, component.targetTexture.height, _frameRate, _preset);
				}
				else
				{
					_session = FFmpegSession.Create(Path.Combine(Application.persistentDataPath, base.gameObject.name), component.targetTexture.width, component.targetTexture.height, _frameRate, _preset);
				}
				_startTime = Time.time;
				_frameCount = 0;
				_frameDropCount = 0;
			}
			float num = Time.time - FrameTime;
			float num2 = 1f / _frameRate;
			if (num < 0f)
			{
				_session.PushFrame(null);
			}
			else if (num < num2)
			{
				_session.PushFrame(component.targetTexture);
				_frameCount++;
			}
			else if (num < num2 * 2f)
			{
				_session.PushFrame(component.targetTexture);
				_session.PushFrame(component.targetTexture);
				_frameCount += 2;
			}
			else
			{
				_session.PushFrame(component.targetTexture);
				_frameCount += Mathf.FloorToInt(num * _frameRate);
			}
		}
	}
}
