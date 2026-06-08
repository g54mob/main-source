using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class IMDrawer : IDisposable
	{
		internal static MetaMpb metaMpbPrevious;

		private MetaMpb metaMpb;

		private ShapeDrawState drawState;

		private Matrix4x4 mtx;

		private static Matrix4x4 GetDrawingMatrix(Vector3 pos, Quaternion rot)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(pos, rot, Vector3.one);
			if (Draw.HasCustomMatrix)
			{
				matrix4x = Draw.Matrix * matrix4x;
			}
			return matrix4x;
		}

		public IMDrawer(MetaMpb metaMpb, Material sourceMat, Mesh sourceMesh, int submesh = 0, bool cachedTMP = false)
			: this(metaMpb, sourceMat, sourceMesh, Draw.Matrix, submesh, cachedTMP)
		{
		}

		public IMDrawer(MetaMpb metaMpb, Material sourceMat, Mesh sourceMesh, Vector3 pos, Quaternion rot, int submesh = 0, bool cachedTMP = false)
			: this(metaMpb, sourceMat, sourceMesh, GetDrawingMatrix(pos, rot), submesh, cachedTMP)
		{
		}

		public IMDrawer(MetaMpb metaMpb, Material sourceMat, Mesh sourceMesh, Matrix4x4 mtx, int submesh = 0, bool cachedTMP = false)
		{
			this.mtx = mtx;
			this.metaMpb = metaMpb;
			if (DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				Draw.renderState.shader = sourceMat.shader;
				Draw.renderState.keywords = sourceMat.shaderKeywords;
				drawState.mat = (cachedTMP ? sourceMat : IMMaterialPool.GetMaterial(ref Draw.renderState));
				if (cachedTMP)
				{
					drawState.mesh = UnityEngine.Object.Instantiate(sourceMesh);
					drawState.mat = UnityEngine.Object.Instantiate(sourceMat);
					ApplyGlobalPropertiesTMP(drawState.mat);
					List<UnityEngine.Object> cachedAssets = DrawCommand.CurrentWritingCommandBuffer.cachedAssets;
					cachedAssets.Add(drawState.mesh);
					cachedAssets.Add(drawState.mat);
				}
				else
				{
					drawState.mat = sourceMat;
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
				ApplyGlobalProperties();
			}
		}

		private void ApplyGlobalProperties()
		{
			if (!DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				drawState.mat.SetFloat(ShapesMaterialUtils.propZTest, (float)Draw.ZTest);
				drawState.mat.SetFloat(ShapesMaterialUtils.propZOffsetFactor, Draw.ZOffsetFactor);
				drawState.mat.SetFloat(ShapesMaterialUtils.propZOffsetUnits, Draw.ZOffsetUnits);
				drawState.mat.SetFloat(ShapesMaterialUtils.propStencilComp, (float)Draw.StencilComp);
				drawState.mat.SetFloat(ShapesMaterialUtils.propStencilOpPass, (float)Draw.StencilOpPass);
				drawState.mat.SetFloat(ShapesMaterialUtils.propStencilID, (int)Draw.StencilRefID);
				drawState.mat.SetFloat(ShapesMaterialUtils.propStencilReadMask, (int)Draw.StencilReadMask);
				drawState.mat.SetFloat(ShapesMaterialUtils.propStencilWriteMask, (int)Draw.StencilWriteMask);
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
			else if (!ShapesConfig.Instance.useImmediateModeInstancing)
			{
				DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(metaMpb.ExtractDrawCall());
			}
		}
	}
}
