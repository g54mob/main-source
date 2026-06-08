using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ImGuiNET;
using UImGui.Assets;
using UImGui.Events;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace UImGui.Texture
{
	internal class TextureManager
	{
		private Texture2D _atlasTexture;

		private readonly Dictionary<IntPtr, UnityEngine.Texture> _textures = new Dictionary<IntPtr, UnityEngine.Texture>();

		private readonly Dictionary<UnityEngine.Texture, IntPtr> _textureIds = new Dictionary<UnityEngine.Texture, IntPtr>();

		private readonly Dictionary<Sprite, SpriteInfo> _spriteData = new Dictionary<Sprite, SpriteInfo>();

		private readonly HashSet<IntPtr> _allocatedGlyphRangeArrays = new HashSet<IntPtr>();

		public unsafe void Initialize(ImGuiIOPtr io)
		{
			io.Fonts.GetTexDataAsRGBA32(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel);
			_atlasTexture = new Texture2D(out_width, out_height, TextureFormat.RGBA32, mipChain: false, linear: false)
			{
				filterMode = FilterMode.Point
			};
			NativeArray<byte> src = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(out_pixels, out_width * out_height * out_bytes_per_pixel, Allocator.None);
			NativeArray<byte> rawTextureData = _atlasTexture.GetRawTextureData<byte>();
			int num = out_width * out_bytes_per_pixel;
			for (int i = 0; i < out_height; i++)
			{
				NativeArray<byte>.Copy(src, i * num, rawTextureData, (out_height - i - 1) * num, num);
			}
			_atlasTexture.Apply();
		}

		public void Shutdown()
		{
			_textures.Clear();
			_textureIds.Clear();
			_spriteData.Clear();
			if (_atlasTexture != null)
			{
				UnityEngine.Object.Destroy(_atlasTexture);
				_atlasTexture = null;
			}
		}

		public void PrepareFrame(ImGuiIOPtr io)
		{
			IntPtr texID = RegisterTexture(_atlasTexture);
			io.Fonts.SetTexID(texID);
		}

		public bool TryGetTexture(IntPtr id, out UnityEngine.Texture texture)
		{
			return _textures.TryGetValue(id, out texture);
		}

		public IntPtr GetTextureId(UnityEngine.Texture texture)
		{
			if (!_textureIds.TryGetValue(texture, out var value))
			{
				return RegisterTexture(texture);
			}
			return value;
		}

		public SpriteInfo GetSpriteInfo(Sprite sprite)
		{
			if (!_spriteData.TryGetValue(sprite, out var value))
			{
				Dictionary<Sprite, SpriteInfo> spriteData = _spriteData;
				SpriteInfo obj = new SpriteInfo
				{
					Texture = sprite.texture,
					Size = sprite.rect.size,
					UV0 = sprite.uv[0],
					UV1 = sprite.uv[1]
				};
				value = obj;
				spriteData[sprite] = obj;
			}
			return value;
		}

		private IntPtr RegisterTexture(UnityEngine.Texture texture)
		{
			IntPtr nativeTexturePtr = texture.GetNativeTexturePtr();
			_textures[nativeTexturePtr] = texture;
			_textureIds[texture] = nativeTexturePtr;
			return nativeTexturePtr;
		}

		public unsafe void BuildFontAtlas(ImGuiIOPtr io, in FontAtlasConfigAsset settings, FontInitializerEvent custom)
		{
			ImFontAtlasPtr fonts = io.Fonts;
			if (fonts.IsBuilt())
			{
				DestroyFontAtlas(io);
			}
			if (!io.MouseDrawCursor)
			{
				fonts = io.Fonts;
				fonts.Flags |= ImFontAtlasFlags.NoMouseCursors;
			}
			if (settings == null)
			{
				if (custom.GetPersistentEventCount() > 0)
				{
					custom.Invoke(io);
				}
				else
				{
					fonts = io.Fonts;
					fonts.AddFontDefault();
				}
				fonts = io.Fonts;
				fonts.Build();
				return;
			}
			for (int i = 0; i < settings.Fonts.Length; i++)
			{
				FontDefinition fontDefinition = settings.Fonts[i];
				string text = Path.Combine(Application.streamingAssetsPath, fontDefinition.Path);
				if (!File.Exists(text))
				{
					Debug.Log("Font file not found: " + text);
					continue;
				}
				ImFontConfig imFontConfig = default(ImFontConfig);
				ImFontConfigPtr imFontConfigPtr = new ImFontConfigPtr(&imFontConfig);
				fontDefinition.Config.ApplyTo(imFontConfigPtr);
				imFontConfigPtr.GlyphRanges = AllocateGlyphRangeArray(in fontDefinition.Config);
				fonts = io.Fonts;
				fonts.AddFontFromFileTTF(text, fontDefinition.Config.SizeInPixels, imFontConfigPtr);
			}
			fonts = io.Fonts;
			if (fonts.Fonts.Size == 0)
			{
				fonts = io.Fonts;
				fonts.AddFontDefault();
			}
			fonts = io.Fonts;
			fonts.Build();
		}

		public unsafe void DestroyFontAtlas(ImGuiIOPtr io)
		{
			FreeGlyphRangeArrays();
			io.Fonts.Clear();
			io.NativePtr->FontDefault = default(ImFont*);
		}

		private unsafe IntPtr AllocateGlyphRangeArray(in FontConfig fontConfig)
		{
			List<ushort> list = fontConfig.BuildRanges();
			if (list.Count == 0)
			{
				return IntPtr.Zero;
			}
			ushort* ptr = (ushort*)(void*)Marshal.AllocHGlobal(2 * (list.Count + 1));
			_allocatedGlyphRangeArrays.Add((IntPtr)ptr);
			for (int i = 0; i < list.Count; i++)
			{
				ptr[i] = list[i];
			}
			ptr[list.Count] = 0;
			return (IntPtr)ptr;
		}

		private void FreeGlyphRangeArrays()
		{
			foreach (IntPtr allocatedGlyphRangeArray in _allocatedGlyphRangeArrays)
			{
				Marshal.FreeHGlobal(allocatedGlyphRangeArray);
			}
			_allocatedGlyphRangeArrays.Clear();
		}
	}
}
