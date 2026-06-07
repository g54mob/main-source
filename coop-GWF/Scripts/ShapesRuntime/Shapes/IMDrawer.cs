using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal struct IMDrawer : IDisposable
	{
		public enum DrawType
		{
			Shape = 0,
			Custom = 1,
			TextAssetClone = 2,
			TextPooledAuto = 3,
			TextPooledPersistent = 4
		}

		internal static MetaMpb metaMpbPrevious;

		private static Dictionary<Material, string[]> matKeywords = new Dictionary<Material, string[]>();

		private MetaMpb metaMpb;

		private ShapeDrawState drawState;

		private Matrix4x4 mtx;

		private bool allowInstancing;

		private static string[] GetMaterialKeywords(Material m)
		{
			if (!matKeywords.TryGetValue(m, out var value))
			{
				value = (matKeywords[m] = m.shaderKeywords);
			}
			return value;
		}

		public IMDrawer(MetaMpb metaMpb, Material sourceMat, Mesh sourceMesh, int submesh = 0, DrawType drawType = DrawType.Shape, bool allowInstancing = true, int textAutoDisposeId = -1)
		{
			mtx = Draw.Matrix;
			this.metaMpb = metaMpb;
			this.allowInstancing = allowInstancing && ShapesConfig.Instance.useImmediateModeInstancing;
			if (DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				Draw.style.renderState.shader = sourceMat.shader;
				Draw.style.renderState.keywords = GetMaterialKeywords(sourceMat);
				Draw.style.renderState.isTextMaterial = drawType == DrawType.TextPooledPersistent || drawType == DrawType.TextAssetClone;
				switch (drawType)
				{
				case DrawType.TextAssetClone:
					drawState.mat = UnityEngine.Object.Instantiate(sourceMat);
					ApplyGlobalPropertiesTMP(drawState.mat);
					DrawCommand.CurrentWritingCommandBuffer.cachedAssets.Add(drawState.mat);
					break;
				case DrawType.TextPooledPersistent:
					drawState.mat = sourceMat;
					break;
				case DrawType.TextPooledAuto:
					drawState.mat = sourceMat;
					DrawCommand.CurrentWritingCommandBuffer.cachedTextIds.Add(textAutoDisposeId);
					break;
				case DrawType.Custom:
					drawState.mat = sourceMat;
					break;
				default:
					drawState.mat = IMMaterialPool.GetMaterial(ref Draw.style.renderState);
					break;
				}
				if (drawType == DrawType.TextAssetClone)
				{
					drawState.mesh = UnityEngine.Object.Instantiate(sourceMesh);
					DrawCommand.CurrentWritingCommandBuffer.cachedAssets.Add(drawState.mesh);
				}
				else
				{
					drawState.mesh = sourceMesh;
				}
				drawState.submesh = submesh;
				if (metaMpbPrevious != metaMpb && metaMpbPrevious != null && metaMpbPrevious.HasContent)
				{
					DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(metaMpbPrevious.ExtractDrawCall());
				}
				if (!metaMpb.PreAppendCheck(drawState, mtx))
				{
					ShapeDrawCall item = metaMpb.ExtractDrawCall();
					DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(item);
					if (!metaMpb.PreAppendCheck(drawState, mtx))
					{
						Debug.LogWarning("MetaMpb somehow not ready to be initialized");
					}
				}
				metaMpbPrevious = metaMpb;
			}
			else
			{
				drawState.mesh = sourceMesh;
				drawState.mat = sourceMat;
				drawState.submesh = submesh;
				if (!metaMpb.PreAppendCheck(drawState, mtx))
				{
					Debug.LogError("Somehow PreAppendCheck failed for this draw");
				}
				if (drawType != DrawType.Custom)
				{
					ApplyGlobalProperties(drawState.mat);
				}
			}
		}

		private static void ApplyGlobalProperties(Material m)
		{
			if (!DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				m.SetFloat(ShapesMaterialUtils.propZTest, (float)Draw.ZTest);
				m.SetFloat(ShapesMaterialUtils.propZOffsetFactor, Draw.ZOffsetFactor);
				m.SetFloat(ShapesMaterialUtils.propZOffsetUnits, Draw.ZOffsetUnits);
				m.SetInt_Shapes(ShapesMaterialUtils.propColorMask, (int)Draw.ColorMask);
				m.SetFloat(ShapesMaterialUtils.propStencilComp, (float)Draw.StencilComp);
				m.SetFloat(ShapesMaterialUtils.propStencilOpPass, (float)Draw.StencilOpPass);
				m.SetFloat(ShapesMaterialUtils.propStencilID, (int)Draw.StencilRefID);
				m.SetFloat(ShapesMaterialUtils.propStencilReadMask, (int)Draw.StencilReadMask);
				m.SetFloat(ShapesMaterialUtils.propStencilWriteMask, (int)Draw.StencilWriteMask);
			}
		}

		private static void ApplyGlobalPropertiesTMP(Material m)
		{
			m.SetInt_Shapes(ShapesMaterialUtils.propZTestTMP, (int)Draw.ZTest);
			m.SetInt_Shapes(ShapesMaterialUtils.propColorMask, (int)Draw.ColorMask);
			m.SetInt_Shapes(ShapesMaterialUtils.propStencilComp, (int)Draw.StencilComp);
			m.SetInt_Shapes(ShapesMaterialUtils.propStencilOpPass, (int)Draw.StencilOpPass);
			m.SetInt_Shapes(ShapesMaterialUtils.propStencilIDTMP, Draw.StencilRefID);
			m.SetInt_Shapes(ShapesMaterialUtils.propStencilReadMask, Draw.StencilReadMask);
			m.SetInt_Shapes(ShapesMaterialUtils.propStencilWriteMask, Draw.StencilWriteMask);
		}

		public void Dispose()
		{
			if (!DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				metaMpb.ApplyDirectlyToMaterial();
				drawState.mat.SetPass(0);
				Graphics.DrawMeshNow(drawState.mesh, mtx, drawState.submesh);
			}
			else if (!allowInstancing)
			{
				ShapeDrawCall item = metaMpb.ExtractDrawCall();
				DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(item);
			}
		}
	}
}
