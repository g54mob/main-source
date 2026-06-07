using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace FFmpegOut
{
	public sealed class FFmpegSession : IDisposable
	{
		private FFmpegPipe _pipe;

		private Material _blitMaterial;

		private List<AsyncGPUReadbackRequest> _readbackQueue = new List<AsyncGPUReadbackRequest>(4);

		public static FFmpegSession Create(string name, int width, int height, float frameRate, FFmpegPreset preset)
		{
			name += DateTime.Now.ToString(" yyyy MMdd HHmmss");
			return CreateWithOutputPath(name.Replace(" ", "_") + preset.GetSuffix(), width, height, frameRate, preset);
		}

		public static FFmpegSession CreateWithOutputPath(string outputPath, int width, int height, float frameRate, FFmpegPreset preset)
		{
			return new FFmpegSession("-y -f rawvideo -vcodec rawvideo -pixel_format rgba -colorspace bt709 -video_size " + width + "x" + height + " -framerate " + frameRate + " -loglevel warning -i - " + preset.GetOptions() + " \"" + outputPath + "\"");
		}

		public static FFmpegSession CreateWithArguments(string arguments)
		{
			return new FFmpegSession(arguments);
		}

		public void PushFrame(Texture source)
		{
			if (_pipe != null)
			{
				ProcessQueue();
				if (source != null)
				{
					QueueFrame(source);
				}
			}
		}

		public void CompletePushFrames()
		{
			_pipe?.SyncFrameData();
		}

		public void Close()
		{
			if (_pipe != null)
			{
				string text = _pipe.CloseAndGetOutput();
				if (!string.IsNullOrEmpty(text))
				{
					Debug.LogWarning("FFmpeg returned with warning/error messages. See the following lines for details:\n" + text);
				}
				_pipe.Dispose();
				_pipe = null;
			}
			if (_blitMaterial != null)
			{
				UnityEngine.Object.Destroy(_blitMaterial);
				_blitMaterial = null;
			}
		}

		public void Dispose()
		{
			Close();
		}

		private FFmpegSession(string arguments)
		{
			if (!FFmpegPipe.IsAvailable)
			{
				Debug.LogWarning("Failed to initialize an FFmpeg session due to missing executable file. Please check FFmpeg installation.");
			}
			else if (!SystemInfo.supportsAsyncGPUReadback)
			{
				Debug.LogWarning("Failed to initialize an FFmpeg session due to lack of async GPU readback support. Please try changing graphics API to readback-enabled one.");
			}
			else
			{
				_pipe = new FFmpegPipe(arguments);
			}
		}

		~FFmpegSession()
		{
			if (_pipe != null)
			{
				Debug.LogError("An unfinalized FFmpegCapture object was detected. It should be explicitly closed or disposed before being garbage-collected.");
			}
		}

		private void QueueFrame(Texture source)
		{
			if (_readbackQueue.Count > 6)
			{
				Debug.LogWarning("Too many GPU readback requests.");
				return;
			}
			if (_blitMaterial == null)
			{
				Shader shader = Shader.Find("Hidden/FFmpegOut/Preprocess");
				_blitMaterial = new Material(shader);
			}
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
			Graphics.Blit(source, temporary, _blitMaterial, 0);
			_readbackQueue.Add(AsyncGPUReadback.Request(temporary));
			RenderTexture.ReleaseTemporary(temporary);
		}

		private void ProcessQueue()
		{
			while (_readbackQueue.Count > 0)
			{
				if (!_readbackQueue[0].done)
				{
					if (_readbackQueue.Count <= 1 || !_readbackQueue[1].done)
					{
						break;
					}
					_readbackQueue[0].WaitForCompletion();
				}
				AsyncGPUReadbackRequest asyncGPUReadbackRequest = _readbackQueue[0];
				_readbackQueue.RemoveAt(0);
				if (asyncGPUReadbackRequest.hasError)
				{
					Debug.LogWarning("GPU readback error was detected.");
				}
				else
				{
					_pipe.PushFrameData(asyncGPUReadbackRequest.GetData<byte>());
				}
			}
		}
	}
}
