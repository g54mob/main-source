using System;
using ImGuiNET;
using UnityEngine;

namespace UImGui.Assets
{
	[CreateAssetMenu(menuName = "Dear ImGui/Cursor Shapes")]
	internal sealed class CursorShapesAsset : ScriptableObject
	{
		[Serializable]
		internal struct CursorShape
		{
			public Texture2D Texture;

			public Vector2 Hotspot;
		}

		[Tooltip("Default.")]
		public CursorShape Arrow;

		[Tooltip("When hovering over InputText, etc.")]
		public CursorShape TextInput;

		[Tooltip("(Unused by ImGui functions)")]
		public CursorShape ResizeAll;

		[Tooltip("When hovering over an horizontal border")]
		public CursorShape ResizeNS;

		[Tooltip("When hovering over a vertical border or a column")]
		public CursorShape ResizeEW;

		[Tooltip("When hovering over the bottom-left corner of a window")]
		public CursorShape ResizeNESW;

		[Tooltip("When hovering over the bottom-right corner of a window")]
		public CursorShape ResizeNWSE;

		[Tooltip("(Unused by ImGui functions. Use for e.g. hyperlinks)")]
		public CursorShape Hand;

		[Tooltip("When hovering something with disabled interaction. Usually a crossed circle.")]
		public CursorShape NotAllowed;

		public ref CursorShape this[ImGuiMouseCursor cursor] => cursor switch
		{
			ImGuiMouseCursor.Arrow => ref Arrow, 
			ImGuiMouseCursor.TextInput => ref TextInput, 
			ImGuiMouseCursor.ResizeAll => ref ResizeAll, 
			ImGuiMouseCursor.ResizeEW => ref ResizeEW, 
			ImGuiMouseCursor.ResizeNS => ref ResizeNS, 
			ImGuiMouseCursor.ResizeNESW => ref ResizeNESW, 
			ImGuiMouseCursor.ResizeNWSE => ref ResizeNWSE, 
			ImGuiMouseCursor.Hand => ref Hand, 
			ImGuiMouseCursor.NotAllowed => ref NotAllowed, 
			_ => ref Arrow, 
		};
	}
}
