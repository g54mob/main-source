using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public static class Blitter
	{
		private static Mesh fullscreenTriangle;

		private static Mesh FullscreenTriangle
		{
			get
			{
				if (fullscreenTriangle != null)
				{
					return fullscreenTriangle;
				}
				fullscreenTriangle = new Mesh
				{
					name = "Fullscreen Triangle"
				};
				fullscreenTriangle.SetVertices(new List<Vector3>
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(-1f, 3f, 0f),
					new Vector3(3f, -1f, 0f)
				});
				fullscreenTriangle.SetIndices(new int[3] { 0, 1, 2 }, MeshTopology.Triangles, 0, calculateBounds: false);
				fullscreenTriangle.UploadMeshData(markNoLongerReadable: false);
				return fullscreenTriangle;
			}
		}

		public static void Blit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material, int passIndex, MaterialPropertyBlock propertyBlock = null, Rect viewport = default(Rect))
		{
			cmd.SetGlobalTexture(ShaderID.MAIN_TEX, source);
			cmd.SetRenderTarget(new RenderTargetIdentifier(destination, 0, CubemapFace.Unknown, -1), RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.DontCare);
			if (viewport.width != 0f)
			{
				cmd.SetViewport(viewport);
			}
			if (SystemInfo.graphicsShaderLevel >= 30)
			{
				cmd.DrawProcedural(Matrix4x4.identity, material, passIndex, MeshTopology.Triangles, 3, 1, propertyBlock);
			}
			else
			{
				cmd.DrawMesh(FullscreenTriangle, Matrix4x4.identity, material, 0, passIndex, propertyBlock);
			}
		}
	}
}
