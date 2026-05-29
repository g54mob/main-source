using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public class OutlineParameters
	{
		public readonly MeshPool MeshPool;

		public Camera Camera;

		public RenderTargetIdentifier Target;

		public RenderTargetIdentifier DepthTarget;

		public CommandBuffer Buffer;

		public DilateQuality DilateQuality;

		public int DilateIterations;

		public int BlurIterations;

		public Vector2 Scale;

		public Rect? CustomViewport;

		public long OutlineLayerMask;

		public int TargetWidth;

		public int TargetHeight;

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

		private bool isInitialized;

		public Vector2Int MakeScaledVector(int x, int y)
		{
			return default(Vector2Int);
		}

		public void CheckInitialization()
		{
		}

		public void Prepare()
		{
		}

		private static bool CheckDiffers(Outlinable outlinable)
		{
			return false;
		}

		private static bool CheckIfNonOne(Outlinable.OutlineProperties parameters)
		{
			return false;
		}
	}
}
