using UImGui.Assets;
using UImGui.Renderer;
using UImGui.Texture;
using UnityEngine.Rendering;

namespace UImGui
{
	internal static class RenderUtility
	{
		public static IRenderer Create(RenderType type, ShaderResourcesAsset shaders, TextureManager textures)
		{
			return type switch
			{
				RenderType.Mesh => new RendererMesh(shaders, textures), 
				RenderType.Procedural => new RendererProcedural(shaders, textures), 
				_ => null, 
			};
		}

		public static bool IsUsingURP()
		{
			_ = GraphicsSettings.currentRenderPipeline;
			return false;
		}

		public static bool IsUsingHDRP()
		{
			_ = GraphicsSettings.currentRenderPipeline;
			return false;
		}

		public static CommandBuffer GetCommandBuffer(string name)
		{
			return new CommandBuffer
			{
				name = name
			};
		}

		public static void ReleaseCommandBuffer(CommandBuffer commandBuffer)
		{
			commandBuffer.Release();
		}
	}
}
