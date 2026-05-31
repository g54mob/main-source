using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public static class OutlineEffect
	{
		private struct OutlineTargetGroup
		{
			public readonly Outlinable Outlinable;

			public readonly OutlineTarget Target;

			public OutlineTargetGroup(Outlinable outlinable, OutlineTarget target)
			{
				Outlinable = null;
				Target = null;
			}
		}

		public static readonly int FillRefHash;

		public static readonly int ColorMaskHash;

		public static readonly int OutlineRefHash;

		public static readonly int RefHash;

		public static readonly int EffectSizeHash;

		public static readonly int CullHash;

		public static readonly int ZTestHash;

		public static readonly int ColorHash;

		public static readonly int ScaleHash;

		public static readonly int ShiftHash;

		public static readonly int InfoBufferHash;

		public static readonly int ComparisonHash;

		public static readonly int ReadMaskHash;

		public static readonly int OperationHash;

		public static readonly int CutoutThresholdHash;

		public static readonly int CutoutMaskHash;

		public static readonly int TextureIndexHash;

		public static readonly int CutoutTextureHash;

		public static readonly int CutoutTextureSTHash;

		public static readonly int SrcBlendHash;

		public static readonly int DstBlendHash;

		private static Material OutlineMaterial;

		private static Material ObstacleMaterial;

		private static Material FillMaskMaterial;

		private static Material ZPrepassMaterial;

		private static Material DilateMaterial;

		private static Material BlurMaterial;

		private static Material FinalBlitMaterial;

		private static Material BasicBlitMaterial;

		private static Material ClearStencilMaterial;

		private static RTHandleSystem system;

		private static List<OutlineTargetGroup> targets;

		private static List<string> keywords;

		public static RTHandleSystem HandleSystem => null;

		private static Material LoadMaterial(string shaderName)
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitMaterials()
		{
		}

		private static void Postprocess(OutlineParameters parameters, RTHandle first, RTHandle second, Material material, int iterations, int eyeSlice, bool additionalShift, float shiftValue, ref int stencil, Rect viewport, float scale)
		{
		}

		private static void Blit(OutlineParameters parameters, RTHandle source, RTHandle destination, RTHandle destinationDepth, Material material, float effectSize, int eyeSlice, int pass = -1, Rect? viewport = null)
		{
		}

		private static void Draw(OutlineParameters parameters, RTHandle destination, RTHandle destinationDepth, Material material, float effectSize, int eyeSlice, int pass = -1, Rect? viewport = null)
		{
		}

		private static float GetBlurShift(BlurType blurType, int iterationsCount)
		{
			return 0f;
		}

		private static float GetMaskingValueForMode(OutlinableDrawingMode mode)
		{
			return 0f;
		}

		private static float ComputeEffectShift(OutlineParameters parameters)
		{
			return 0f;
		}

		private static void PrepareTargets(OutlineParameters parameters)
		{
		}

		public static void SetupOutline(OutlineParameters parameters)
		{
		}

		private static void SetupDilateKeyword(OutlineParameters parameters)
		{
		}

		private static void SetupBlurKeyword(OutlineParameters parameters)
		{
		}

		private static int DrawOutlineables(OutlineParameters parameters, CompareFunction function, Func<Outlinable, bool> shouldRender, Func<Outlinable, Color> colorProvider, Func<Outlinable, Material> materialProvider, RenderStyle styleMask, OutlinableDrawingMode modeMask = OutlinableDrawingMode.Normal)
		{
			return 0;
		}

		private static void SetMaskingMasking(CommandBufferWrapper buffer, ComplexMaskingMode maskingMode)
		{
		}

		private static void DrawFill(OutlineParameters parameters, RTHandle targetSurface)
		{
		}

		private static void SetupCutout(OutlineParameters parameters, OutlineTarget target)
		{
		}

		private static void SetupCull(OutlineParameters parameters, OutlineTarget target)
		{
		}
	}
}
