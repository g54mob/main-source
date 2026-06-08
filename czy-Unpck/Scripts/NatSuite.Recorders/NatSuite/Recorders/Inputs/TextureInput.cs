using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace NatSuite.Recorders.Inputs
{
	public sealed class TextureInput : ITextureInput, IDisposable
	{
		private readonly IMediaRecorder recorder;

		private readonly Texture2D readbackBuffer;

		(int, int) ITextureInput.frameSize => recorder.frameSize;

		public TextureInput(IMediaRecorder recorder)
		{
			this.recorder = recorder;
			readbackBuffer = new Texture2D(recorder.frameSize.width, recorder.frameSize.height, TextureFormat.RGBA32, mipChain: false, linear: false);
		}

		public unsafe void CommitFrame(Texture texture, long timestamp)
		{
			(int width, int height) frameSize = recorder.frameSize;
			int item = frameSize.width;
			int item2 = frameSize.height;
			RenderTexture temporary = RenderTexture.GetTemporary(item, item2, 24, RenderTextureFormat.ARGB32);
			Graphics.Blit(texture, temporary);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			readbackBuffer.ReadPixels(new Rect(0f, 0f, item, item2), 0, 0, recalculateMipMaps: false);
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			recorder.CommitFrame(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(readbackBuffer.GetRawTextureData<byte>()), timestamp);
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(readbackBuffer);
		}
	}
}
