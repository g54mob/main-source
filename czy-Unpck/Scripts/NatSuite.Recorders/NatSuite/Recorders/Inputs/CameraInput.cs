using System;
using System.Collections;
using NatSuite.Recorders.Clocks;
using UnityEngine;

namespace NatSuite.Recorders.Inputs
{
	public class CameraInput : IDisposable
	{
		private sealed class CameraInputAttachment : MonoBehaviour
		{
		}

		public int frameSkip;

		private readonly ITextureInput input;

		private readonly IClock clock;

		protected readonly Camera[] cameras;

		private readonly RenderTextureDescriptor frameDescriptor;

		private readonly CameraInputAttachment attachment;

		private int frameCount;

		public CameraInput(IMediaRecorder recorder, params Camera[] cameras)
			: this(recorder, null, cameras)
		{
		}

		public CameraInput(IMediaRecorder recorder, IClock clock, params Camera[] cameras)
			: this(CreateInput(recorder), clock, cameras)
		{
		}

		public CameraInput(ITextureInput input, params Camera[] cameras)
			: this(input, null, cameras)
		{
		}

		public CameraInput(ITextureInput input, IClock clock, params Camera[] cameras)
		{
			Array.Sort(cameras, (Camera a, Camera b) => (int)(100f * (a.depth - b.depth)));
			(int width, int height) frameSize = input.frameSize;
			int item = frameSize.width;
			int item2 = frameSize.height;
			this.input = input;
			this.clock = clock;
			this.cameras = cameras;
			frameDescriptor = new RenderTextureDescriptor(item, item2, RenderTextureFormat.ARGB32, 24)
			{
				sRGB = true,
				msaaSamples = Mathf.Max(QualitySettings.antiAliasing, 1)
			};
			attachment = new GameObject("NatCorder CameraInputAttachment").AddComponent<CameraInputAttachment>();
			attachment.StartCoroutine(CommitFrames());
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(attachment.gameObject);
			input.Dispose();
		}

		private IEnumerator CommitFrames()
		{
			WaitForEndOfFrame yielder = new WaitForEndOfFrame();
			while (true)
			{
				yield return yielder;
				if (frameCount++ % (frameSkip + 1) == 0)
				{
					RenderTexture temporary = RenderTexture.GetTemporary(frameDescriptor);
					for (int i = 0; i < cameras.Length; i++)
					{
						CommitFrame(cameras[i], temporary);
					}
					input.CommitFrame(temporary, clock?.timestamp ?? 0);
					RenderTexture.ReleaseTemporary(temporary);
				}
			}
		}

		protected virtual void CommitFrame(Camera source, RenderTexture destination)
		{
			RenderTexture targetTexture = source.targetTexture;
			source.targetTexture = destination;
			source.Render();
			source.targetTexture = targetTexture;
		}

		private static ITextureInput CreateInput(IMediaRecorder recorder)
		{
			if (SystemInfo.supportsAsyncGPUReadback)
			{
				return new AsyncTextureInput(recorder);
			}
			return new TextureInput(recorder);
		}
	}
}
