using System;
using System.Runtime.CompilerServices;
using System.Text;
using ImGuiNET;
using UnityEngine;

namespace UImGui
{
	internal static class Utils
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Vector2 ScreenToImGui(in Vector2 point)
		{
			return new Vector2(point.x, ImGui.GetIO().DisplaySize.y - point.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Vector2 ImGuiToScreen(in Vector2 point)
		{
			return new Vector2(point.x, ImGui.GetIO().DisplaySize.y - point.y);
		}

		internal unsafe static string StringFromPtr(byte* ptr)
		{
			int i;
			for (i = 0; ptr[i] != 0; i++)
			{
			}
			return Encoding.UTF8.GetString(ptr, i);
		}

		internal unsafe static int GetUtf8(string text, byte* utf8Bytes, int utf8ByteCount)
		{
			fixed (char* chars = text)
			{
				return Encoding.UTF8.GetBytes(chars, text.Length, utf8Bytes, utf8ByteCount);
			}
		}

		internal unsafe static int GetUtf8(string text, int start, int length, byte* utf8Bytes, int utf8ByteCount)
		{
			if (start < 0 || length < 0 || start + length > text.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			fixed (char* ptr = text)
			{
				return Encoding.UTF8.GetBytes(ptr + start, length, utf8Bytes, utf8ByteCount);
			}
		}
	}
}
