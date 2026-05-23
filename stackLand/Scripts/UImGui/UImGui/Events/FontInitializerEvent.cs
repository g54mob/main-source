using System;
using ImGuiNET;
using UnityEngine.Events;

namespace UImGui.Events
{
	[Serializable]
	public class FontInitializerEvent : UnityEvent<ImGuiIOPtr>
	{
	}
}
