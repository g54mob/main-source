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

		public static readonly int DilateShiftHash;

		public static readonly int ColorMaskHash;

		public static readonly int OutlineRefHash;

		public static readonly int RefHash;

		public static readonly int ZWriteHash;

		public static readonly int EffectSizeHash;

		public static readonly int CullHash;

		public static readonly int ZTestHash;

		public static readonly int ColorHash;

		public static readonly int ScaleHash;

		public static readonly int ShiftHash;

		public static readonly int InitialTexHash;

		public static readonly int InfoBufferHash;

		public static readonly int ComparisonHash;

		public static readonly int ReadMaskHash;

		public static readonly int WriteMaskHash;

		public static readonly int OperationHash;

		public static readonly int CutoutThresholdHash;

		public static readonly int CutoutMaskHash;

		public static readonly int TextureIndexHash;

		public static readonly int CutoutTextureHash;

		public static readonly int CutoutTextureSTHash;

		public static readonly int SrcBlendHash;

		public static readonly int DstBlendHash;

		public static readonly int TargetHash;

		public static readonly int InfoTargetHash;

		public static readonly int PrimaryBufferHash;

		public static readonly int HelperBufferHash;

		public static readonly int PrimaryInfoBufferHash;

		public static readonly int HelperInfoBufferHash;

		private static Material TransparentBlitMaterial;

		private static Material EmptyFillMaterial;

		private static Material OutlineMaterial;

		private static Material PartialBlitMaterial;

		private static Material ObstacleMaterial;

		private static Material FillMaskMaterial;

		private static Material ZPrepassMaterial;

		private static Material OutlineMaskMaterial;

		private static Material DilateMaterial;

		private static Material BlurMaterial;

		private static Material FinalBlitMaterial;

		private static Material BasicBlitMaterial;

		private static Material ClearStencilMaterial;

		private static List<OutlineTargetGroup> targets;

		private static List<string> keywords;

		public static Material LoadMaterial(string shaderName)
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitMaterials()
		{
		}

		private static void Postprocess(OutlineParameters parameters, int first, int second, Material material, int iterations, bool additionalShift, float shiftValue, ref int stencil, Rect viewport, float scale)
		{
		}

		private static void Blit(OutlineParameters parameters, RenderTargetIdentifier source, RenderTargetIdentifier destination, RenderTargetIdentifier destinationDepth, Material material, float effectSize, CommandBuffer buffer, int pass = -1, Rect? viewport = null)
		{
		}

		private static float GetBlurShift(BlurType blurType, int iterrationsCount)
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

		private static void DrawFill(OutlineParameters parameters, RenderTargetIdentifier targetSurface)
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
