using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

namespace NatSuite.Recorders.Inputs
{
	public sealed class AsyncTextureInput : ITextureInput, IDisposable
	{
		private IMediaRecorder recorder;

		(int, int) ITextureInput.frameSize => recorder.frameSize;

		public AsyncTextureInput(IMediaRecorder recorder)
		{
			this.recorder = recorder;
		}

		public unsafe void CommitFrame(Texture texture, long timestamp)
		{
			(int width, int height) frameSize = recorder.frameSize;
			int item = frameSize.width;
			int item2 = frameSize.height;
			RenderTexture temporary = RenderTexture.GetTemporary(item, item2, 24, RenderTextureFormat.ARGB32);
			Graphics.Blit(texture, temporary);
			AsyncGPUReadback.Request(temporary, 0, delegate(AsyncGPUReadbackRequest request)
			{
				recorder?.CommitFrame(request.GetData<byte>().GetUnsafeReadOnlyPtr(), timestamp);
			});
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void Dispose()
		{
			recorder = null;
		}
	}
}
