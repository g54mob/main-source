using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Noesis;
using UnityEngine;

public class NoesisTextureProvider : TextureProvider
{
	public struct Value
	{
		public int refs;

		public UnityEngine.Texture texture;
	}

	public static NoesisTextureProvider instance;

	private Dictionary<string, Value> _textures;

	private NoesisTextureProvider()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	public void Register(string uri, UnityEngine.Texture texture)
	{
	}

	public void Unregister(string uri)
	{
	}

	public override void GetTextureInfo(Uri uri, out uint width_, out uint height_)
	{
		width_ = default(uint);
		height_ = default(uint);
	}

	internal new static IntPtr Extend(string typeName)
	{
		return (IntPtr)0;
	}

	[PreserveSig]
	private static extern IntPtr Noesis_TextureProviderExtend(IntPtr typeName);

	[PreserveSig]
	private static extern void Noesis_TextureProviderStoreTextureInfo(IntPtr cPtr, string filename, int width, int height, int numLevels, IntPtr nativePtr);
}
