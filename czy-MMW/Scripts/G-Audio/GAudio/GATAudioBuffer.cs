using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GAudio
{
	public class GATAudioBuffer : MonoBehaviour
	{
		private static GCHandle __bufferHandle;

		private static IntPtr __bufferPointer;

		private static bool __wasAdded;

		private static bool __didInitialize;

		public static IntPtr AudioBufferPointer => __bufferPointer;

		public static GATData AudioBuffer { get; protected set; }

		public static bool ShouldBeAdded => !__wasAdded;

		private void Awake()
		{
			if (__wasAdded)
			{
				Debug.LogWarning("GATAudioBuffer needs to be added to one GATPlayer only.");
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				__wasAdded = true;
			}
		}

		private void OnAudioFilterRead(float[] data, int nbOfChannels)
		{
			if (!__didInitialize)
			{
				__bufferHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
				__bufferPointer = __bufferHandle.AddrOfPinnedObject();
				AudioBuffer = new GATData(data);
				__didInitialize = true;
			}
		}

		private void Update()
		{
			if (__didInitialize)
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		public static void CleanUpStatics()
		{
			if (__didInitialize)
			{
				__bufferHandle.Free();
				__bufferPointer = IntPtr.Zero;
				__didInitialize = false;
				__wasAdded = false;
				AudioBuffer = null;
			}
		}
	}
}
