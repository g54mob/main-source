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
				Outlinable = outlinable;
				Target = target;
			}
		}

		public static readonly int FillRefHash = Shader.PropertyToID("_FillRef");

		public static readonly int ColorMaskHash = Shader.PropertyToID("_ColorMask");

		public static readonly int OutlineRefHash = Shader.PropertyToID("_OutlineRef");

		public static readonly int RefHash = Shader.PropertyToID("_Ref");

		public static readonly int EffectSizeHash = Shader.PropertyToID("_EffectSize");

		public static readonly int CullHash = Shader.PropertyToID("_Cull");

		public static readonly int ZTestHash = Shader.PropertyToID("_ZTest");

		public static readonly int ColorHash = Shader.PropertyToID("_EPOColor");

		public static readonly int ScaleHash = Shader.PropertyToID("_Scale");

		public static readonly int ShiftHash = Shader.PropertyToID("_Shift");

		public static readonly int InfoBufferHash = Shader.PropertyToID("_InfoBuffer");

		public static readonly int ComparisonHash = Shader.PropertyToID("_Comparison");

		public static readonly int ReadMaskHash = Shader.PropertyToID("_ReadMask");

		public static readonly int OperationHash = Shader.PropertyToID("_Operation");

		public static readonly int CutoutThresholdHash = Shader.PropertyToID("_CutoutThreshold");

		public static readonly int CutoutMaskHash = Shader.PropertyToID("_CutoutMask");

		public static readonly int TextureIndexHash = Shader.PropertyToID("_TextureIndex");

		public static readonly int CutoutTextureHash = Shader.PropertyToID("_CutoutTexture");

		public static readonly int CutoutTextureSTHash = Shader.PropertyToID("_CutoutTexture_ST");

		public static readonly int SrcBlendHash = Shader.PropertyToID("_SrcBlend");

		public static readonly int DstBlendHash = Shader.PropertyToID("_DstBlend");

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

		private static List<OutlineTargetGroup> targets = new List<OutlineTargetGroup>();

		private static List<string> keywords = new List<string>();

		public static RTHandleSystem HandleSystem
		{
			get
			{
				if (system != null)
				{
					return system;
				}
				system = new RTHandleSystem();
				system.Initialize(1, 1);
				return system;
			}
		}

		private static Material LoadMaterial(string shaderName)
		{
			Material material = new Material(Resources.Load<Shader>($"Easy performant outline/Shaders/{shaderName}"));
			if (SystemInfo.supportsInstancing)
			{
				material.enableInstancing = true;
			}
			return material;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitMaterials()
		{
			if (ObstacleMaterial == null)
			{
				ObstacleMaterial = LoadMaterial("Obstacle");
			}
			if (OutlineMaterial == null)
			{
				OutlineMaterial = LoadMaterial("Outline");
			}
			if (ZPrepassMaterial == null)
			{
				ZPrepassMaterial = LoadMaterial("ZPrepass");
			}
			if (DilateMaterial == null)
			{
				DilateMaterial = LoadMaterial("Dilate");
			}
			if (BlurMaterial == null)
			{
				BlurMaterial = LoadMaterial("Blur");
			}
			if (FinalBlitMaterial == null)
			{
				FinalBlitMaterial = LoadMaterial("FinalBlit");
			}
			if (BasicBlitMaterial == null)
			{
				BasicBlitMaterial = LoadMaterial("BasicBlit");
			}
			if (FillMaskMaterial == null)
			{
				FillMaskMaterial = LoadMaterial("Fills/FillMask");
			}
			if (ClearStencilMaterial == null)
			{
				ClearStencilMaterial = LoadMaterial("ClearStencil");
			}
		}

		private static void Postprocess(OutlineParameters parameters, RTHandle first, RTHandle second, Material material, int iterations, int eyeSlice, bool additionalShift, float shiftValue, ref int stencil, Rect viewport, float scale)
		{
			if (iterations > 0)
			{
				parameters.Buffer.SetGlobalInt(ComparisonHash, 3);
				for (int i = 1; i <= iterations; i++)
				{
					parameters.Buffer.SetGlobalInt(RefHash, stencil);
					float num = (additionalShift ? ((float)i) : 1f);
					parameters.Buffer.SetGlobalVector(ShiftHash, new Vector4(num * scale, 0f));
					Blit(parameters, first, second, first, material, shiftValue, eyeSlice, -1, viewport);
					stencil = (stencil + 1) % 255;
					parameters.Buffer.SetGlobalInt(RefHash, stencil);
					parameters.Buffer.SetGlobalVector(ShiftHash, new Vector4(0f, num * scale));
					Blit(parameters, second, first, first, material, shiftValue, eyeSlice, -1, viewport);
					stencil = (stencil + 1) % 255;
				}
			}
		}

		private static void Blit(OutlineParameters parameters, RTHandle source, RTHandle destination, RTHandle destinationDepth, Material material, float effectSize, int eyeSlice, int pass = -1, Rect? viewport = null)
		{
			parameters.Buffer.SetGlobalFloat(EffectSizeHash, effectSize);
			BlitUtility.Blit(parameters, source, destination, destinationDepth, eyeSlice, material, pass, viewport);
		}

		private static void Draw(OutlineParameters parameters, RTHandle destination, RTHandle destinationDepth, Material material, float effectSize, int eyeSlice, int pass = -1, Rect? viewport = null)
		{
			parameters.Buffer.SetGlobalFloat(EffectSizeHash, effectSize);
			BlitUtility.Draw(parameters, destination, destinationDepth, eyeSlice, material, pass, viewport);
		}

		private static float GetBlurShift(BlurType blurType, int iterationsCount)
		{
			return blurType switch
			{
				BlurType.Box => (float)iterationsCount * 0.65f + 1f, 
				BlurType.Gaussian5x5 => 3f * (float)iterationsCount, 
				BlurType.Gaussian9x9 => 5f + (float)iterationsCount, 
				BlurType.Gaussian13x13 => 7f + (float)iterationsCount, 
				_ => throw new ArgumentException("Unknown blur type"), 
			};
		}

		private static float GetMaskingValueForMode(OutlinableDrawingMode mode)
		{
			if ((mode & OutlinableDrawingMode.Mask) != 0)
			{
				return 0.6f;
			}
			if ((mode & OutlinableDrawingMode.Obstacle) == 0)
			{
				return 1f;
			}
			return 0.25f;
		}

		private static float ComputeEffectShift(OutlineParameters parameters)
		{
			return (GetBlurShift(parameters.BlurType, parameters.BlurIterations) * parameters.BlurShift + (float)parameters.DilateIterations * 4f * parameters.DilateShift) * 1.1f;
		}

		private static void PrepareTargets(OutlineParameters parameters)
		{
			targets.Clear();
			foreach (Outlinable item in parameters.OutlinablesToRender)
			{
				for (int i = 0; i < item.OutlineTargets.Count; i++)
				{
					OutlineTarget outlineTarget = item.OutlineTargets[i];
					Renderer renderer = outlineTarget.Renderer;
					if (outlineTarget.IsVisible || ((item.DrawingMode & OutlinableDrawingMode.GenericMask) != 0 && !(renderer == null)))
					{
						targets.Add(new OutlineTargetGroup(item, outlineTarget));
					}
				}
			}
		}

		public static void SetupOutline(OutlineParameters parameters)
		{
			parameters.Buffer.SetRenderTarget(parameters.Handles.Target, -1);
			parameters.Buffer.ClearRenderTarget(depth: true, color: true, Color.clear);
			parameters.Buffer.SetGlobalVector(ScaleHash, parameters.Scale);
			PrepareTargets(parameters);
			InitMaterials();
			float num = ComputeEffectShift(parameters);
			float num2 = num + 3f;
			float effectSize = num;
			int depthSliceForEye = RenderTargetUtility.GetDepthSliceForEye(parameters.EyeMask);
			parameters.Buffer.SetRenderTarget(parameters.Handles.PrimaryTarget, -1);
			parameters.Buffer.ClearRenderTarget(depth: true, color: true, Color.clear);
			parameters.Buffer.SetRenderTarget(parameters.Handles.SecondaryTarget, -1);
			parameters.Buffer.ClearRenderTarget(depth: true, color: true, Color.clear);
			if (parameters.UseInfoBuffer)
			{
				parameters.Buffer.SetRenderTarget(parameters.Handles.InfoTarget, -1);
				parameters.Buffer.ClearRenderTarget(depth: true, color: true, Color.clear);
				parameters.Buffer.SetRenderTarget(parameters.Handles.PrimaryInfoBufferTarget, -1);
				parameters.Buffer.ClearRenderTarget(depth: true, color: true, Color.clear);
				parameters.Buffer.SetRenderTarget(parameters.Handles.SecondaryInfoBufferTarget, -1);
				parameters.Buffer.ClearRenderTarget(depth: true, color: true, Color.clear);
			}
			parameters.Buffer.SetGlobalInt(SrcBlendHash, 1);
			parameters.Buffer.SetGlobalInt(DstBlendHash, 0);
			int value = 1;
			parameters.Buffer.SetGlobalInt(OutlineRefHash, value);
			SetupDilateKeyword(parameters);
			Vector2Int vector2Int = new Vector2Int(parameters.ScaledBufferWidth, parameters.ScaledBufferHeight);
			BlitUtility.PrepareForRendering(parameters);
			parameters.Buffer.SetRenderTarget(parameters.Handles.Target, parameters.DepthTarget, depthSliceForEye);
			parameters.Buffer.ClearRenderTarget(depth: false, color: true, Color.clear);
			parameters.Buffer.SetViewport(parameters.Viewport);
			DrawOutlineables(parameters, CompareFunction.LessEqual, (Outlinable x) => true, (Outlinable x) => Color.clear, (Outlinable x) => ZPrepassMaterial, (RenderStyle)3, OutlinableDrawingMode.ZOnly);
			parameters.Buffer.DisableShaderKeyword(KeywordsUtility.GetEnabledInfoBufferKeyword());
			if (parameters.UseInfoBuffer)
			{
				parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetInfoBufferStageKeyword());
				parameters.Buffer.SetRenderTarget(parameters.Handles.InfoTarget, parameters.DepthTarget, depthSliceForEye);
				parameters.Buffer.ClearRenderTarget(depth: false, color: true, Color.clear);
				parameters.Buffer.SetViewport(parameters.Viewport);
				DrawOutlineables(parameters, CompareFunction.Always, (Outlinable x) => x.OutlineParameters.Enabled, (Outlinable x) => new Color(x.OutlineParameters.DilateShift, x.OutlineParameters.BlurShift, 0f, 1f), (Outlinable x) => OutlineMaterial, RenderStyle.Single);
				DrawOutlineables(parameters, CompareFunction.NotEqual, (Outlinable x) => x.BackParameters.Enabled, (Outlinable x) => new Color(x.BackParameters.DilateShift, x.BackParameters.BlurShift, 0f, 1f), (Outlinable x) => OutlineMaterial, RenderStyle.FrontBack);
				DrawOutlineables(parameters, CompareFunction.LessEqual, (Outlinable x) => x.FrontParameters.Enabled, (Outlinable x) => new Color(x.FrontParameters.DilateShift, x.FrontParameters.BlurShift, 0f, 1f), (Outlinable x) => OutlineMaterial, RenderStyle.FrontBack);
				DrawOutlineables(parameters, CompareFunction.LessEqual, (Outlinable x) => true, (Outlinable x) => new Color(0f, 0f, GetMaskingValueForMode(x.DrawingMode), 1f), (Outlinable x) => ObstacleMaterial, (RenderStyle)3, OutlinableDrawingMode.Obstacle | OutlinableDrawingMode.Mask);
				parameters.Buffer.SetGlobalInt(ComparisonHash, 8);
				parameters.Buffer.SetGlobalInt(OperationHash, 0);
				Blit(parameters, parameters.Handles.InfoTarget, parameters.Handles.PrimaryInfoBufferTarget, parameters.Handles.PrimaryInfoBufferTarget, BasicBlitMaterial, num2, -1, -1, new Rect(0f, 0f, vector2Int.x, vector2Int.y));
				int iterations = ((parameters.DilateQuality == DilateQuality.Base) ? parameters.DilateIterations : (parameters.DilateIterations * 2)) + parameters.BlurIterations;
				int stencil = 0;
				Postprocess(parameters, parameters.Handles.PrimaryInfoBufferTarget, parameters.Handles.SecondaryInfoBufferTarget, DilateMaterial, iterations, depthSliceForEye, additionalShift: true, num2, ref stencil, new Rect(0f, 0f, vector2Int.x, vector2Int.y), 1f);
				parameters.Buffer.SetRenderTarget(parameters.Handles.InfoTarget, parameters.DepthTarget, depthSliceForEye);
				parameters.Buffer.SetViewport(parameters.Viewport);
				parameters.Buffer.SetGlobalTexture(InfoBufferHash, parameters.Handles.PrimaryInfoBufferTarget);
				parameters.Buffer.DisableShaderKeyword(KeywordsUtility.GetInfoBufferStageKeyword());
			}
			if (parameters.UseInfoBuffer)
			{
				parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetEnabledInfoBufferKeyword());
			}
			parameters.Buffer.SetRenderTarget(parameters.Handles.Target, parameters.DepthTarget, depthSliceForEye);
			parameters.Buffer.ClearRenderTarget(depth: false, color: true, Color.clear);
			parameters.Buffer.SetViewport(parameters.Viewport);
			int num3 = 0 + DrawOutlineables(parameters, CompareFunction.Always, (Outlinable x) => x.OutlineParameters.Enabled, (Outlinable x) => x.OutlineParameters.Color, (Outlinable x) => OutlineMaterial, RenderStyle.Single) + DrawOutlineables(parameters, CompareFunction.NotEqual, (Outlinable x) => x.BackParameters.Enabled, (Outlinable x) => x.BackParameters.Color, (Outlinable x) => OutlineMaterial, RenderStyle.FrontBack) + DrawOutlineables(parameters, CompareFunction.LessEqual, (Outlinable x) => x.FrontParameters.Enabled, (Outlinable x) => x.FrontParameters.Color, (Outlinable x) => OutlineMaterial, RenderStyle.FrontBack);
			int stencil2 = 0;
			if (num3 > 0)
			{
				parameters.Buffer.SetGlobalInt(ComparisonHash, 8);
				parameters.Buffer.SetGlobalInt(OperationHash, 0);
				Blit(parameters, parameters.Handles.Target, parameters.Handles.PrimaryTarget, parameters.Handles.PrimaryTarget, BasicBlitMaterial, num2, depthSliceForEye, -1, new Rect(0f, 0f, vector2Int.x, vector2Int.y));
				Postprocess(parameters, parameters.Handles.PrimaryTarget, parameters.Handles.SecondaryTarget, DilateMaterial, parameters.DilateIterations, depthSliceForEye, additionalShift: false, num2, ref stencil2, new Rect(0f, 0f, vector2Int.x, vector2Int.y), parameters.DilateShift);
			}
			parameters.Buffer.SetViewport(parameters.Viewport);
			if (num3 > 0)
			{
				SetupBlurKeyword(parameters);
				Postprocess(parameters, parameters.Handles.PrimaryTarget, parameters.Handles.SecondaryTarget, BlurMaterial, parameters.BlurIterations, depthSliceForEye, additionalShift: false, num2, ref stencil2, new Rect(0f, 0f, vector2Int.x, vector2Int.y), parameters.BlurShift);
			}
			parameters.Buffer.SetGlobalTexture(Shader.PropertyToID("_Mask"), parameters.Handles.Target);
			Blit(parameters, parameters.Handles.PrimaryTarget, parameters.Target, parameters.DepthTarget, FinalBlitMaterial, effectSize, depthSliceForEye, -1, parameters.Viewport);
			DrawFill(parameters, parameters.Target);
			Draw(parameters, parameters.Target, parameters.DepthTarget, ClearStencilMaterial, effectSize, depthSliceForEye, -1, parameters.Viewport);
		}

		private static void SetupDilateKeyword(OutlineParameters parameters)
		{
			KeywordsUtility.GetAllDilateKeywords(keywords);
			foreach (string keyword in keywords)
			{
				parameters.Buffer.DisableShaderKeyword(keyword);
			}
			parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetDilateQualityKeyword(parameters.DilateQuality));
		}

		private static void SetupBlurKeyword(OutlineParameters parameters)
		{
			KeywordsUtility.GetAllBlurKeywords(keywords);
			foreach (string keyword in keywords)
			{
				parameters.Buffer.DisableShaderKeyword(keyword);
			}
			parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetBlurKeyword(parameters.BlurType));
		}

		private static int DrawOutlineables(OutlineParameters parameters, CompareFunction function, Func<Outlinable, bool> shouldRender, Func<Outlinable, Color> colorProvider, Func<Outlinable, Material> materialProvider, RenderStyle styleMask, OutlinableDrawingMode modeMask = OutlinableDrawingMode.Normal)
		{
			int num = 0;
			parameters.Buffer.SetGlobalInt(ZTestHash, (int)function);
			SetMaskingMasking(parameters.Buffer, ComplexMaskingMode.None);
			ComplexMaskingMode complexMaskingMode = ComplexMaskingMode.None;
			foreach (OutlineTargetGroup target2 in targets)
			{
				Outlinable outlinable = target2.Outlinable;
				if ((outlinable.RenderStyle & styleMask) != 0 && (outlinable.DrawingMode & modeMask) != 0)
				{
					if ((function == CompareFunction.NotEqual || function == CompareFunction.Always) && outlinable.ComplexMaskingMode != complexMaskingMode)
					{
						SetMaskingMasking(parameters.Buffer, outlinable.ComplexMaskingMode);
						complexMaskingMode = outlinable.ComplexMaskingMode;
					}
					Color color = (shouldRender(outlinable) ? colorProvider(outlinable) : Color.clear);
					parameters.Buffer.SetGlobalColor(ColorHash, color);
					OutlineTarget target = target2.Target;
					parameters.Buffer.SetGlobalInt(ColorMaskHash, 255);
					SetupCutout(parameters, target);
					SetupCull(parameters, target);
					num++;
					Material material = materialProvider(outlinable);
					parameters.Buffer.DrawRenderer(target.Renderer, material, target.ShiftedSubmeshIndex);
				}
			}
			SetMaskingMasking(parameters.Buffer, ComplexMaskingMode.None);
			return num;
		}

		private static void SetMaskingMasking(CommandBufferWrapper buffer, ComplexMaskingMode maskingMode)
		{
			buffer.DisableShaderKeyword(KeywordsUtility.GetBackKeyword(ComplexMaskingMode.MaskingMode));
			buffer.DisableShaderKeyword(KeywordsUtility.GetBackKeyword(ComplexMaskingMode.ObstaclesMode));
			if (maskingMode != ComplexMaskingMode.None)
			{
				buffer.EnableShaderKeyword(KeywordsUtility.GetBackKeyword(maskingMode));
			}
		}

		private static void DrawFill(OutlineParameters parameters, RTHandle targetSurface)
		{
			int depthSliceForEye = RenderTargetUtility.GetDepthSliceForEye(parameters.EyeMask);
			parameters.Buffer.SetRenderTarget(targetSurface, parameters.DepthTarget, depthSliceForEye);
			parameters.Buffer.SetViewport(parameters.Viewport);
			int value = 1;
			int value2 = 2;
			int value3 = 3;
			parameters.Buffer.SetGlobalInt(ZTestHash, 5);
			parameters.Buffer.SetGlobalInt(FillRefHash, value3);
			foreach (Outlinable item in parameters.OutlinablesToRender)
			{
				if ((item.DrawingMode & OutlinableDrawingMode.Normal) == 0)
				{
					continue;
				}
				for (int i = 0; i < item.OutlineTargets.Count; i++)
				{
					OutlineTarget outlineTarget = item.OutlineTargets[i];
					if (outlineTarget.IsVisible)
					{
						Renderer renderer = outlineTarget.Renderer;
						if (item.NeedsFillMask)
						{
							SetupCutout(parameters, outlineTarget);
							SetupCull(parameters, outlineTarget);
							parameters.Buffer.DrawRenderer(renderer, FillMaskMaterial, outlineTarget.ShiftedSubmeshIndex);
						}
					}
				}
			}
			parameters.Buffer.SetGlobalInt(ZTestHash, 4);
			parameters.Buffer.SetGlobalInt(FillRefHash, value2);
			foreach (Outlinable item2 in parameters.OutlinablesToRender)
			{
				if ((item2.DrawingMode & OutlinableDrawingMode.Normal) == 0)
				{
					continue;
				}
				for (int j = 0; j < item2.OutlineTargets.Count; j++)
				{
					OutlineTarget outlineTarget2 = item2.OutlineTargets[j];
					if (outlineTarget2.IsVisible && item2.NeedsFillMask)
					{
						Renderer renderer2 = outlineTarget2.Renderer;
						SetupCutout(parameters, outlineTarget2);
						SetupCull(parameters, outlineTarget2);
						parameters.Buffer.DrawRenderer(renderer2, FillMaskMaterial, outlineTarget2.ShiftedSubmeshIndex);
					}
				}
			}
			ComplexMaskingMode complexMaskingMode = ComplexMaskingMode.None;
			SetMaskingMasking(parameters.Buffer, ComplexMaskingMode.None);
			foreach (Outlinable item3 in parameters.OutlinablesToRender)
			{
				if ((item3.DrawingMode & OutlinableDrawingMode.Normal) == 0)
				{
					continue;
				}
				if (item3.ComplexMaskingMode != complexMaskingMode)
				{
					SetMaskingMasking(parameters.Buffer, item3.ComplexMaskingMode);
					complexMaskingMode = ComplexMaskingMode.None;
				}
				if (item3.RenderStyle == RenderStyle.FrontBack)
				{
					if ((item3.BackParameters.FillPass.Material == null || !item3.BackParameters.Enabled) && (item3.FrontParameters.FillPass.Material == null || !item3.FrontParameters.Enabled))
					{
						continue;
					}
					Material material = item3.FrontParameters.FillPass.Material;
					parameters.Buffer.SetGlobalInt(FillRefHash, value2);
					if (material != null && item3.FrontParameters.Enabled)
					{
						for (int k = 0; k < item3.OutlineTargets.Count; k++)
						{
							OutlineTarget outlineTarget3 = item3.OutlineTargets[k];
							if (outlineTarget3.IsVisible)
							{
								Renderer renderer3 = outlineTarget3.Renderer;
								SetupCutout(parameters, outlineTarget3);
								SetupCull(parameters, outlineTarget3);
								parameters.Buffer.DrawRenderer(renderer3, material, outlineTarget3.ShiftedSubmeshIndex);
							}
						}
					}
					Material material2 = item3.BackParameters.FillPass.Material;
					parameters.Buffer.SetGlobalInt(FillRefHash, value3);
					if (material2 == null || !item3.BackParameters.Enabled)
					{
						continue;
					}
					for (int l = 0; l < item3.OutlineTargets.Count; l++)
					{
						OutlineTarget outlineTarget4 = item3.OutlineTargets[l];
						if (outlineTarget4.IsVisible)
						{
							Renderer renderer4 = outlineTarget4.Renderer;
							SetupCutout(parameters, outlineTarget4);
							SetupCull(parameters, outlineTarget4);
							parameters.Buffer.DrawRenderer(renderer4, material2, outlineTarget4.ShiftedSubmeshIndex);
						}
					}
				}
				else
				{
					if (item3.OutlineParameters.FillPass.Material == null || !item3.OutlineParameters.Enabled)
					{
						continue;
					}
					parameters.Buffer.SetGlobalInt(ZTestHash, 8);
					parameters.Buffer.SetGlobalInt(FillRefHash, value);
					Material material3 = item3.OutlineParameters.FillPass.Material;
					for (int m = 0; m < item3.OutlineTargets.Count; m++)
					{
						OutlineTarget outlineTarget5 = item3.OutlineTargets[m];
						if (outlineTarget5.IsVisible)
						{
							Renderer renderer5 = outlineTarget5.Renderer;
							SetupCutout(parameters, outlineTarget5);
							SetupCull(parameters, outlineTarget5);
							parameters.Buffer.DrawRenderer(renderer5, material3, outlineTarget5.ShiftedSubmeshIndex);
						}
					}
				}
				if (item3.ComplexMaskingMode != ComplexMaskingMode.None)
				{
					SetMaskingMasking(parameters.Buffer, ComplexMaskingMode.None);
				}
			}
		}

		private static void SetupCutout(OutlineParameters parameters, OutlineTarget target)
		{
			if (target.Renderer == null)
			{
				return;
			}
			Vector4 value = new Vector4(((target.CutoutMask & ColorMask.R) != ColorMask.None) ? 1f : 0f, ((target.CutoutMask & ColorMask.G) != ColorMask.None) ? 1f : 0f, ((target.CutoutMask & ColorMask.B) != ColorMask.None) ? 1f : 0f, ((target.CutoutMask & ColorMask.A) != ColorMask.None) ? 1f : 0f);
			parameters.Buffer.SetGlobalVector(CutoutMaskHash, value);
			if (target.Renderer is SpriteRenderer { sprite: var sprite } spriteRenderer)
			{
				if (sprite == null || sprite.texture == null)
				{
					parameters.Buffer.DisableShaderKeyword(KeywordsUtility.GetCutoutKeyword());
					return;
				}
				parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetCutoutKeyword());
				parameters.Buffer.SetGlobalFloat(CutoutThresholdHash, target.CutoutThreshold);
				RTHandle texture = parameters.TextureHandleMap[spriteRenderer.sprite.texture];
				parameters.Buffer.SetGlobalTexture(CutoutTextureHash, texture);
			}
			else if (target.IsValidForCutout)
			{
				Material sharedMaterial = target.SharedMaterial;
				parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetCutoutKeyword());
				parameters.Buffer.SetGlobalFloat(CutoutThresholdHash, target.CutoutThreshold);
				Vector2 textureOffset = sharedMaterial.GetTextureOffset(target.CutoutTextureId);
				Vector2 textureScale = sharedMaterial.GetTextureScale(target.CutoutTextureId);
				parameters.Buffer.SetGlobalVector(CutoutTextureSTHash, new Vector4(textureScale.x, textureScale.y, textureOffset.x, textureOffset.y));
				Texture cutoutTexture = target.CutoutTexture;
				if (cutoutTexture == null || cutoutTexture.dimension != TextureDimension.Tex2DArray)
				{
					parameters.Buffer.DisableShaderKeyword(KeywordsUtility.GetTextureArrayCutoutKeyword());
				}
				else
				{
					parameters.Buffer.SetGlobalFloat(TextureIndexHash, target.CutoutTextureIndex);
					parameters.Buffer.EnableShaderKeyword(KeywordsUtility.GetTextureArrayCutoutKeyword());
				}
				parameters.Buffer.SetGlobalTexture(CutoutTextureHash, parameters.TextureHandleMap[cutoutTexture]);
			}
			else
			{
				parameters.Buffer.DisableShaderKeyword(KeywordsUtility.GetCutoutKeyword());
			}
		}

		private static void SetupCull(OutlineParameters parameters, OutlineTarget target)
		{
			parameters.Buffer.SetGlobalInt(CullHash, (int)target.CullMode);
		}
	}
}
