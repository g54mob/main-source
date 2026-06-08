using System;
using ImGuiNET;
using UImGui.Texture;
using UnityEngine;

namespace UImGui
{
	public static class UImGuiUtility
	{
		internal static Context Context;

		public static event Action<UImGui> Layout;

		public static event Action<UImGui> OnInitialize;

		public static event Action<UImGui> OnDeinitialize;

		public static IntPtr GetTextureId(UnityEngine.Texture texture)
		{
			return Context?.TextureManager.GetTextureId(texture) ?? IntPtr.Zero;
		}

		internal static SpriteInfo GetSpriteInfo(Sprite sprite)
		{
			return Context?.TextureManager.GetSpriteInfo(sprite) ?? null;
		}

		internal static void DoLayout(UImGui uimgui)
		{
			UImGuiUtility.Layout?.Invoke(uimgui);
		}

		internal static void DoOnInitialize(UImGui uimgui)
		{
			UImGuiUtility.OnInitialize?.Invoke(uimgui);
		}

		internal static void DoOnDeinitialize(UImGui uimgui)
		{
			UImGuiUtility.OnDeinitialize?.Invoke(uimgui);
		}

		internal static Context CreateContext()
		{
			return new Context
			{
				ImGuiContext = ImGui.CreateContext(),
				TextureManager = new TextureManager()
			};
		}

		internal static void DestroyContext(Context context)
		{
			ImGui.DestroyContext(context.ImGuiContext);
		}

		internal static void SetCurrentContext(Context context)
		{
			Context = context;
			ImGui.SetCurrentContext(context?.ImGuiContext ?? IntPtr.Zero);
		}
	}
}
