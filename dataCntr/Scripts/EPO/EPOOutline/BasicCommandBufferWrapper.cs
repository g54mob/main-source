using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public class BasicCommandBufferWrapper : CommandBufferWrapper, IUnderlyingBufferProvider, IDisposable
	{
		private CommandBuffer buffer;

		public CommandBuffer UnderlyingBuffer => null;

		private static RenderTargetIdentifier ConvertToRTI(RTHandle handle)
		{
			return default(RenderTargetIdentifier);
		}

		public BasicCommandBufferWrapper(CommandBuffer buffer)
		{
		}

		public void SetCommandBuffer(CommandBuffer buffer)
		{
		}

		public override void Clear()
		{
		}

		public override void SetGlobalInt(int hash, int value)
		{
		}

		public override void SetGlobalFloat(int hash, float value)
		{
		}

		public override void SetGlobalVector(int hash, Vector4 value)
		{
		}

		public override void SetGlobalColor(int hash, Color color)
		{
		}

		public override void SetGlobalTexture(int hash, RTHandle texture)
		{
		}

		public override void SetRenderTarget(RTHandle color, int slice)
		{
		}

		public override void SetRenderTarget(RTHandle color, RTHandle depth, int slice)
		{
		}

		public override void SetViewport(Rect rect)
		{
		}

		public override void DisableShaderKeyword(string keyword)
		{
		}

		public override void EnableShaderKeyword(string keyword)
		{
		}

		public override void ClearRenderTarget(bool depth, bool clr, Color clearColor)
		{
		}

		public override void DrawRenderer(Renderer target, Material material, int submesh)
		{
		}

		public override void DrawMeshInstanced(Mesh mesh, int submesh, Material material, int pass, Matrix4x4[] matrices, int countToDraw, MaterialPropertyBlock block)
		{
		}

		public override void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int submesh, int pass)
		{
		}

		public void Dispose()
		{
		}
	}
}
