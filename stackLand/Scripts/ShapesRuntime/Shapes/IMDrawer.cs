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
			Text = 1
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

		public IMDrawer(MetaMpb metaMpb, Material sourceMat, Mesh sourceMesh, int submesh = 0, DrawType drawType = DrawType.Shape, bool allowInstancing = true)
		{
			mtx = Draw.Matrix;
			this.metaMpb = metaMpb;
			this.allowInstancing = allowInstancing && ShapesConfig.Instance.useImmediateModeInstancing;
			if (DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				Draw.style.renderState.shader = sourceMat.shader;
				Draw.style.renderState.keywords = GetMaterialKeywords(sourceMat);
				bool num = drawType == DrawType.Text;
				bool flag = drawType == DrawType.Text;
				if (num)
				{
					drawState.mat = UnityEngine.Object.Instantiate(sourceMat);
					if (drawType == DrawType.Text)
					{
						ApplyGlobalPropertiesTMP(drawState.mat);
					}
					else
					{
						ApplyGlobalProperties(drawState.mat);
					}
					DrawCommand.CurrentWritingCommandBuffer.cachedAssets.Add(drawState.mat);
				}
				else
				{
					drawState.mat = IMMaterialPool.GetMaterial(ref Draw.style.renderState);
				}
				if (flag)
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
					DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(metaMpb.ExtractDrawCall());
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
				ApplyGlobalProperties(drawState.mat);
			}
		}

		private static void ApplyGlobalProperties(Material m)
		{
			if (!DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				m.SetFloat(ShapesMaterialUtils.propZTest, (float)Draw.ZTest);
				m.SetFloat(ShapesMaterialUtils.propZOffsetFactor, Draw.ZOffsetFactor);
				m.SetFloat(ShapesMaterialUtils.propZOffsetUnits, Draw.ZOffsetUnits);
				m.SetFloat(ShapesMaterialUtils.propStencilComp, (float)Draw.StencilComp);
				m.SetFloat(ShapesMaterialUtils.propStencilOpPass, (float)Draw.StencilOpPass);
				m.SetFloat(ShapesMaterialUtils.propStencilID, (int)Draw.StencilRefID);
				m.SetFloat(ShapesMaterialUtils.propStencilReadMask, (int)Draw.StencilReadMask);
				m.SetFloat(ShapesMaterialUtils.propStencilWriteMask, (int)Draw.StencilWriteMask);
			}
		}

		private static void ApplyGlobalPropertiesTMP(Material m)
		{
			m.SetInt(ShapesMaterialUtils.propZTestTMP, (int)Draw.ZTest);
			m.SetInt(ShapesMaterialUtils.propStencilComp, (int)Draw.StencilComp);
			m.SetInt(ShapesMaterialUtils.propStencilOpPass, (int)Draw.StencilOpPass);
			m.SetInt(ShapesMaterialUtils.propStencilIDTMP, Draw.StencilRefID);
			m.SetInt(ShapesMaterialUtils.propStencilReadMask, Draw.StencilReadMask);
			m.SetInt(ShapesMaterialUtils.propStencilWriteMask, Draw.StencilWriteMask);
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
				DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(metaMpb.ExtractDrawCall());
			}
		}
	}
}
