using ImGuiNET;
using UnityEngine;

namespace UImGui.Platform
{
	internal interface IPlatform
	{
		bool Initialize(ImGuiIOPtr io, UIOConfig config, string platformName);

		void Shutdown(ImGuiIOPtr io);

		void PrepareFrame(ImGuiIOPtr io, Rect displayRect);
	}
}
