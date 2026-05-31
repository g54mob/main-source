using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public class OutlineParameters : IDisposable
	{
		public readonly RTHandlePool RTHandlePool;

		public readonly MeshPool MeshPool;

		public readonly Handles Handles;

		public Camera Camera;

		public RTHandle Target;

		public RTHandle DepthTarget;

		public CommandBufferWrapper Buffer;

		public DilateQuality DilateQuality;

		public int DilateIterations;

		public int BlurIterations;

		public Vector2 Scale;

		public Rect Viewport;

		public long OutlineLayerMask;

		public int TargetWidth;

		public int TargetHeight;

		public int ScaledBufferWidth;

		public int ScaledBufferHeight;

		public float BlurShift;

		public float DilateShift;

		public bool UseHDR;

		public bool UseInfoBuffer;

		public bool IsEditorCamera;

		public BufferSizeMode PrimaryBufferSizeMode;

		public int PrimaryBufferSizeReference;

		public float PrimaryBufferScale;

		public StereoTargetEyeMask EyeMask;

		public int Antialiasing;

		public BlurType BlurType;

		public LayerMask Mask;

		public Mesh BlitMesh;

		public List<Outlinable> OutlinablesToRender;

		public readonly Dictionary<Texture, RTHandle> TextureHandleMap;

		public (int ScaledWidth, int ScaledHeight) ScaledSize => default((int, int));

		public OutlineParameters(CommandBufferWrapper wrapper)
		{
		}

		public void Prepare()
		{
		}

		private static bool CheckDiffers(Outlinable outlinable)
		{
			return false;
		}

		private static bool CheckIfNotUnit(Outlinable.OutlineProperties parameters)
		{
			return false;
		}

		public void Dispose()
		{
		}
	}
}
