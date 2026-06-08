using System;
using System.Runtime.InteropServices;
using AOT;
using ImGuiNET;
using UnityEngine;

namespace UImGui.Platform
{
	internal class PlatformCallbacks
	{
		private static GetClipboardTextCallback _getClipboardText;

		private static SetClipboardTextCallback _setClipboardText;

		public unsafe static GetClipboardTextSafeCallback GetClipboardText
		{
			set
			{
				_getClipboardText = delegate(void* user_data)
				{
					try
					{
						return value(new IntPtr(user_data));
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						return (string)null;
					}
				};
			}
		}

		public unsafe static SetClipboardTextSafeCallback SetClipboardText
		{
			set
			{
				_setClipboardText = delegate(void* user_data, byte* text)
				{
					try
					{
						value(new IntPtr(user_data), Utils.StringFromPtr(text));
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				};
			}
		}

		[MonoPInvokeCallback(typeof(GetClipboardTextCallback))]
		public unsafe static string GetClipboardTextCallback(void* user_data)
		{
			return GUIUtility.systemCopyBuffer;
		}

		[MonoPInvokeCallback(typeof(SetClipboardTextCallback))]
		public unsafe static void SetClipboardTextCallback(void* user_data, byte* text)
		{
			GUIUtility.systemCopyBuffer = Utils.StringFromPtr(text);
		}

		[MonoPInvokeCallback(typeof(ImeSetInputScreenPosCallback))]
		public static void ImeSetInputScreenPosCallback(int x, int y)
		{
			Input.compositionCursorPos = new Vector2(x, y);
		}

		public static void SetClipboardFunctions(GetClipboardTextCallback getCb, SetClipboardTextCallback setCb)
		{
			_getClipboardText = getCb;
			_setClipboardText = setCb;
		}

		public void Assign(ImGuiIOPtr io)
		{
			io.SetClipboardTextFn = Marshal.GetFunctionPointerForDelegate(_setClipboardText);
			io.GetClipboardTextFn = Marshal.GetFunctionPointerForDelegate(_getClipboardText);
		}

		public void Unset(ImGuiIOPtr io)
		{
			io.SetClipboardTextFn = IntPtr.Zero;
			io.GetClipboardTextFn = IntPtr.Zero;
		}
	}
}
