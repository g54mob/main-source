using System;
using System.Runtime.InteropServices;
using Noesis;
using UnityEngine;
using UnityEngine.Rendering;

public class NoesisRenderer
{
	private enum EventId
	{
		UpdateRenderTree = 25670,
		RenderOffscreen = 25671,
		RenderOnscreen = 25672,
		RenderOnscreenFlipY = 25673
	}

	private static uint _nextShaderId;

	private static CommandBuffer _commands;

	private static IntPtr _renderRegisterCallback;

	private static IntPtr _updateRenderTreeCallback;

	private static IntPtr _renderOffscreenCallback;

	private static IntPtr _renderOnscreenCallback;

	private static IntPtr _invalidateStateCallback;

	private static IntPtr _renderClearShadersCallback;

	private static IntPtr _renderCreateShaderCallback;

	private static IntPtr _renderUnregisterCallback;

	private static Material _dummyMaterial;

	private static Mesh _dummyMesh;

	public static void RegisterView(View view, CommandBuffer commands)
	{
	}

	public static void UpdateRenderTree(View view, CommandBuffer commands)
	{
	}

	public static void RenderOffscreen(View view, CommandBuffer commands)
	{
	}

	public static void RenderOnscreen(View view, bool flipY, CommandBuffer commands)
	{
	}

	public static void InvalidateState(CommandBuffer commands)
	{
	}

	public static IntPtr CreatePixelShader(byte shader, byte[] bytes)
	{
		return (IntPtr)0;
	}

	public static void UnregisterView(View view, CommandBuffer commands)
	{
	}

	public static void SetRenderSettings()
	{
	}

	[PreserveSig]
	private static extern IntPtr Noesis_GetRenderRegisterCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_GetUpdateRenderTreeCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_GetRenderOffscreenCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_GetRenderOnscreenCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_GetInvalidateStateCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_AllocateNative(int size);

	[PreserveSig]
	private static extern IntPtr Noesis_GetRenderClearShadersCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_GetRenderCreateShaderCallback();

	[PreserveSig]
	private static extern IntPtr Noesis_GetRenderUnregisterCallback();

	[PreserveSig]
	private static extern void Noesis_RendererSettings(bool linearSpaceRendering, int offscreenSampleCount, uint offscreenDefaultNumSurfaces, uint offscreenMaxNumSurfaces, int glyphCacheTextureWidth, int glyphCacheTextureHeight);

	private static Mesh CreateDummyMesh()
	{
		return null;
	}
}
