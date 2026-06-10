using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public class OutlineParameters : IDisposable
	{
		public readonly RTHandlePool RTHandlePool = new RTHandlePool();

		public readonly MeshPool MeshPool = new MeshPool();

		public readonly Handles Handles = new Handles();

		public Camera Camera;

		public RTHandle Target;

		public RTHandle DepthTarget;

		public CommandBufferWrapper Buffer;

		public DilateQuality DilateQuality;

		public int DilateIterations = 2;

		public int BlurIterations = 5;

		public Vector2 Scale = Vector2.one;

		public Rect Viewport;

		public long OutlineLayerMask = -1L;

		public int TargetWidth;

		public int TargetHeight;

		public int ScaledBufferWidth;

		public int ScaledBufferHeight;

		public float BlurShift = 1f;

		public float DilateShift = 1f;

		public bool UseHDR;

		public bool UseInfoBuffer;

		public bool IsEditorCamera;

		public BufferSizeMode PrimaryBufferSizeMode;

		public int PrimaryBufferSizeReference;

		public float PrimaryBufferScale = 0.1f;

		public StereoTargetEyeMask EyeMask;

		public int Antialiasing = 1;

		public BlurType BlurType = BlurType.Gaussian13x13;

		public LayerMask Mask = -1;

		public Mesh BlitMesh;

		public List<Outlinable> OutlinablesToRender = new List<Outlinable>();

		public readonly Dictionary<Texture, RTHandle> TextureHandleMap = new Dictionary<Texture, RTHandle>();

		public (int ScaledWidth, int ScaledHeight) ScaledSize
		{
			get
			{
				int num = TargetWidth;
				int num2 = TargetHeight;
				switch (PrimaryBufferSizeMode)
				{
				case BufferSizeMode.WidthControlsHeight:
					num = PrimaryBufferSizeReference;
					num2 = (int)((float)PrimaryBufferSizeReference / ((float)TargetWidth / (float)TargetHeight));
					break;
				case BufferSizeMode.HeightControlsWidth:
					num = (int)((float)PrimaryBufferSizeReference / ((float)TargetHeight / (float)TargetWidth));
					num2 = PrimaryBufferSizeReference;
					break;
				case BufferSizeMode.Scaled:
					num = (int)((float)TargetWidth * PrimaryBufferScale);
					num2 = (int)((float)TargetHeight * PrimaryBufferScale);
					break;
				}
				if (EyeMask == StereoTargetEyeMask.None)
				{
					return (ScaledWidth: num, ScaledHeight: num2);
				}
				if (num % 2 != 0)
				{
					num++;
				}
				if (num2 % 2 != 0)
				{
					num2++;
				}
				return (ScaledWidth: num, ScaledHeight: num2);
			}
		}

		public OutlineParameters(CommandBufferWrapper wrapper)
		{
			Buffer = wrapper;
		}

		public void Prepare()
		{
			if (OutlinablesToRender.Count == 0)
			{
				return;
			}
			UseInfoBuffer = OutlinablesToRender.Find((Outlinable x) => x != null && ((x.DrawingMode & (OutlinableDrawingMode.Obstacle | OutlinableDrawingMode.Mask)) != 0 || x.ComplexMaskingMode != ComplexMaskingMode.None)) != null;
			if (UseInfoBuffer)
			{
				return;
			}
			foreach (Outlinable item in OutlinablesToRender)
			{
				if ((item.DrawingMode & OutlinableDrawingMode.Normal) != 0 && CheckDiffers(item))
				{
					UseInfoBuffer = true;
					break;
				}
			}
		}

		private static bool CheckDiffers(Outlinable outlinable)
		{
			if (outlinable.RenderStyle == RenderStyle.Single)
			{
				return CheckIfNotUnit(outlinable.OutlineParameters);
			}
			if (!CheckIfNotUnit(outlinable.FrontParameters))
			{
				return CheckIfNotUnit(outlinable.BackParameters);
			}
			return true;
		}

		private static bool CheckIfNotUnit(Outlinable.OutlineProperties parameters)
		{
			if (Mathf.Approximately(parameters.BlurShift, 1f))
			{
				return !Mathf.Approximately(parameters.DilateShift, 1f);
			}
			return true;
		}

		public void Dispose()
		{
			if (Buffer is IDisposable disposable)
			{
				disposable.Dispose();
			}
			UnityEngine.Object.DestroyImmediate(BlitMesh);
			MeshPool?.Dispose();
			RTHandlePool?.Dispose();
		}
	}
}
