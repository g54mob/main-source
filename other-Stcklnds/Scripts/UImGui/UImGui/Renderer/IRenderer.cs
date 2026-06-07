using ImGuiNET;
using UnityEngine.Rendering;

namespace UImGui.Renderer
{
	internal interface IRenderer
	{
		void Initialize(ImGuiIOPtr io);

		void Shutdown(ImGuiIOPtr io);

		void RenderDrawLists(CommandBuffer commandBuffer, ImDrawDataPtr drawData);
	}
}
