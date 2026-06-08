using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NatSuite.Recorders.Internal;
using UnityEngine;

namespace NatSuite.Recorders
{
	public sealed class JPGRecorder : IMediaRecorder
	{
		private readonly Texture2D frameBuffer;

		private readonly string recordingPath;

		private readonly List<Task> writeTasks;

		private int frameCount;

		public (int width, int height) frameSize => (width: frameBuffer.width, height: frameBuffer.height);

		public JPGRecorder(int width, int height)
		{
			frameBuffer = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false, linear: false);
			writeTasks = new List<Task>();
			recordingPath = Utility.GetPath(string.Empty);
			Directory.CreateDirectory(recordingPath);
		}

		public unsafe void CommitFrame<T>(T[] pixelBuffer, long timestamp = 0L) where T : unmanaged
		{
			fixed (T* nativeBuffer = pixelBuffer)
			{
				CommitFrame(nativeBuffer, timestamp);
			}
		}

		public unsafe void CommitFrame(void* nativeBuffer, long timestamp = 0L)
		{
			frameBuffer.LoadRawTextureData((IntPtr)nativeBuffer, frameBuffer.width * frameBuffer.height * 4);
			byte[] frameData = frameBuffer.EncodeToJPG();
			int frameIndex = ++frameCount;
			Task item = Task.Run(delegate
			{
				File.WriteAllBytes(Path.Combine(recordingPath, $"{frameIndex}.jpg"), frameData);
			});
			writeTasks.Add(item);
		}

		public async Task<string> FinishWriting()
		{
			UnityEngine.Object.Destroy(frameBuffer);
			await Task.WhenAll(writeTasks);
			return recordingPath;
		}

		unsafe void IMediaRecorder.CommitSamples(float[] sampleBuffer, long timestamp)
		{
			fixed (float* nativeBuffer = sampleBuffer)
			{
				((IMediaRecorder)this).CommitSamples(nativeBuffer, sampleBuffer.Length, timestamp);
			}
		}

		unsafe void IMediaRecorder.CommitSamples(float* sampleBuffer, int sampleCount, long timestamp)
		{
			Debug.LogError("NatCorder Error: JPGRecorder does not support committing audio samples");
		}
	}
}
