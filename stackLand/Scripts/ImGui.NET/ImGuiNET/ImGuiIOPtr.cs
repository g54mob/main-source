using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImGuiIOPtr
	{
		public unsafe ImGuiIO* NativePtr { get; }

		public unsafe ref ImGuiConfigFlags ConfigFlags => ref Unsafe.AsRef<ImGuiConfigFlags>(&NativePtr->ConfigFlags);

		public unsafe ref ImGuiBackendFlags BackendFlags => ref Unsafe.AsRef<ImGuiBackendFlags>(&NativePtr->BackendFlags);

		public unsafe ref Vector2 DisplaySize => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySize);

		public unsafe ref float DeltaTime => ref Unsafe.AsRef<float>(&NativePtr->DeltaTime);

		public unsafe ref float IniSavingRate => ref Unsafe.AsRef<float>(&NativePtr->IniSavingRate);

		public unsafe NullTerminatedString IniFilename => new NullTerminatedString(NativePtr->IniFilename);

		public unsafe NullTerminatedString LogFilename => new NullTerminatedString(NativePtr->LogFilename);

		public unsafe ref float MouseDoubleClickTime => ref Unsafe.AsRef<float>(&NativePtr->MouseDoubleClickTime);

		public unsafe ref float MouseDoubleClickMaxDist => ref Unsafe.AsRef<float>(&NativePtr->MouseDoubleClickMaxDist);

		public unsafe ref float MouseDragThreshold => ref Unsafe.AsRef<float>(&NativePtr->MouseDragThreshold);

		public unsafe ref float KeyRepeatDelay => ref Unsafe.AsRef<float>(&NativePtr->KeyRepeatDelay);

		public unsafe ref float KeyRepeatRate => ref Unsafe.AsRef<float>(&NativePtr->KeyRepeatRate);

		public unsafe ref float HoverDelayNormal => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayNormal);

		public unsafe ref float HoverDelayShort => ref Unsafe.AsRef<float>(&NativePtr->HoverDelayShort);

		public unsafe IntPtr UserData
		{
			get
			{
				return (IntPtr)NativePtr->UserData;
			}
			set
			{
				NativePtr->UserData = (void*)value;
			}
		}

		public unsafe ImFontAtlasPtr Fonts => new ImFontAtlasPtr(NativePtr->Fonts);

		public unsafe ref float FontGlobalScale => ref Unsafe.AsRef<float>(&NativePtr->FontGlobalScale);

		public unsafe ref bool FontAllowUserScaling => ref Unsafe.AsRef<bool>(&NativePtr->FontAllowUserScaling);

		public unsafe ImFontPtr FontDefault => new ImFontPtr(NativePtr->FontDefault);

		public unsafe ref Vector2 DisplayFramebufferScale => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayFramebufferScale);

		public unsafe ref bool ConfigDockingNoSplit => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingNoSplit);

		public unsafe ref bool ConfigDockingWithShift => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingWithShift);

		public unsafe ref bool ConfigDockingAlwaysTabBar => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingAlwaysTabBar);

		public unsafe ref bool ConfigDockingTransparentPayload => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDockingTransparentPayload);

		public unsafe ref bool ConfigViewportsNoAutoMerge => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoAutoMerge);

		public unsafe ref bool ConfigViewportsNoTaskBarIcon => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoTaskBarIcon);

		public unsafe ref bool ConfigViewportsNoDecoration => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoDecoration);

		public unsafe ref bool ConfigViewportsNoDefaultParent => ref Unsafe.AsRef<bool>(&NativePtr->ConfigViewportsNoDefaultParent);

		public unsafe ref bool MouseDrawCursor => ref Unsafe.AsRef<bool>(&NativePtr->MouseDrawCursor);

		public unsafe ref bool ConfigMacOSXBehaviors => ref Unsafe.AsRef<bool>(&NativePtr->ConfigMacOSXBehaviors);

		public unsafe ref bool ConfigInputTrickleEventQueue => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTrickleEventQueue);

		public unsafe ref bool ConfigInputTextCursorBlink => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTextCursorBlink);

		public unsafe ref bool ConfigInputTextEnterKeepActive => ref Unsafe.AsRef<bool>(&NativePtr->ConfigInputTextEnterKeepActive);

		public unsafe ref bool ConfigDragClickToInputText => ref Unsafe.AsRef<bool>(&NativePtr->ConfigDragClickToInputText);

		public unsafe ref bool ConfigWindowsResizeFromEdges => ref Unsafe.AsRef<bool>(&NativePtr->ConfigWindowsResizeFromEdges);

		public unsafe ref bool ConfigWindowsMoveFromTitleBarOnly => ref Unsafe.AsRef<bool>(&NativePtr->ConfigWindowsMoveFromTitleBarOnly);

		public unsafe ref float ConfigMemoryCompactTimer => ref Unsafe.AsRef<float>(&NativePtr->ConfigMemoryCompactTimer);

		public unsafe NullTerminatedString BackendPlatformName => new NullTerminatedString(NativePtr->BackendPlatformName);

		public unsafe NullTerminatedString BackendRendererName => new NullTerminatedString(NativePtr->BackendRendererName);

		public unsafe IntPtr BackendPlatformUserData
		{
			get
			{
				return (IntPtr)NativePtr->BackendPlatformUserData;
			}
			set
			{
				NativePtr->BackendPlatformUserData = (void*)value;
			}
		}

		public unsafe IntPtr BackendRendererUserData
		{
			get
			{
				return (IntPtr)NativePtr->BackendRendererUserData;
			}
			set
			{
				NativePtr->BackendRendererUserData = (void*)value;
			}
		}

		public unsafe IntPtr BackendLanguageUserData
		{
			get
			{
				return (IntPtr)NativePtr->BackendLanguageUserData;
			}
			set
			{
				NativePtr->BackendLanguageUserData = (void*)value;
			}
		}

		public unsafe ref IntPtr GetClipboardTextFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->GetClipboardTextFn);

		public unsafe ref IntPtr SetClipboardTextFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->SetClipboardTextFn);

		public unsafe IntPtr ClipboardUserData
		{
			get
			{
				return (IntPtr)NativePtr->ClipboardUserData;
			}
			set
			{
				NativePtr->ClipboardUserData = (void*)value;
			}
		}

		public unsafe ref IntPtr SetPlatformImeDataFn => ref Unsafe.AsRef<IntPtr>(&NativePtr->SetPlatformImeDataFn);

		public unsafe IntPtr _UnusedPadding
		{
			get
			{
				return (IntPtr)NativePtr->_UnusedPadding;
			}
			set
			{
				NativePtr->_UnusedPadding = (void*)value;
			}
		}

		public unsafe ref bool WantCaptureMouse => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureMouse);

		public unsafe ref bool WantCaptureKeyboard => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureKeyboard);

		public unsafe ref bool WantTextInput => ref Unsafe.AsRef<bool>(&NativePtr->WantTextInput);

		public unsafe ref bool WantSetMousePos => ref Unsafe.AsRef<bool>(&NativePtr->WantSetMousePos);

		public unsafe ref bool WantSaveIniSettings => ref Unsafe.AsRef<bool>(&NativePtr->WantSaveIniSettings);

		public unsafe ref bool NavActive => ref Unsafe.AsRef<bool>(&NativePtr->NavActive);

		public unsafe ref bool NavVisible => ref Unsafe.AsRef<bool>(&NativePtr->NavVisible);

		public unsafe ref float Framerate => ref Unsafe.AsRef<float>(&NativePtr->Framerate);

		public unsafe ref int MetricsRenderVertices => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderVertices);

		public unsafe ref int MetricsRenderIndices => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderIndices);

		public unsafe ref int MetricsRenderWindows => ref Unsafe.AsRef<int>(&NativePtr->MetricsRenderWindows);

		public unsafe ref int MetricsActiveWindows => ref Unsafe.AsRef<int>(&NativePtr->MetricsActiveWindows);

		public unsafe ref int MetricsActiveAllocations => ref Unsafe.AsRef<int>(&NativePtr->MetricsActiveAllocations);

		public unsafe ref Vector2 MouseDelta => ref Unsafe.AsRef<Vector2>(&NativePtr->MouseDelta);

		public unsafe RangeAccessor<int> KeyMap => new RangeAccessor<int>(NativePtr->KeyMap, 652);

		public unsafe RangeAccessor<bool> KeysDown => new RangeAccessor<bool>(NativePtr->KeysDown, 652);

		public unsafe RangeAccessor<float> NavInputs => new RangeAccessor<float>(NativePtr->NavInputs, 16);

		public unsafe ref Vector2 MousePos => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePos);

		public unsafe RangeAccessor<bool> MouseDown => new RangeAccessor<bool>(NativePtr->MouseDown, 5);

		public unsafe ref float MouseWheel => ref Unsafe.AsRef<float>(&NativePtr->MouseWheel);

		public unsafe ref float MouseWheelH => ref Unsafe.AsRef<float>(&NativePtr->MouseWheelH);

		public unsafe ref uint MouseHoveredViewport => ref Unsafe.AsRef<uint>(&NativePtr->MouseHoveredViewport);

		public unsafe ref bool KeyCtrl => ref Unsafe.AsRef<bool>(&NativePtr->KeyCtrl);

		public unsafe ref bool KeyShift => ref Unsafe.AsRef<bool>(&NativePtr->KeyShift);

		public unsafe ref bool KeyAlt => ref Unsafe.AsRef<bool>(&NativePtr->KeyAlt);

		public unsafe ref bool KeySuper => ref Unsafe.AsRef<bool>(&NativePtr->KeySuper);

		public unsafe ref ImGuiKey KeyMods => ref Unsafe.AsRef<ImGuiKey>(&NativePtr->KeyMods);

		public unsafe RangeAccessor<ImGuiKeyData> KeysData => new RangeAccessor<ImGuiKeyData>(&NativePtr->KeysData_0, 652);

		public unsafe ref bool WantCaptureMouseUnlessPopupClose => ref Unsafe.AsRef<bool>(&NativePtr->WantCaptureMouseUnlessPopupClose);

		public unsafe ref Vector2 MousePosPrev => ref Unsafe.AsRef<Vector2>(&NativePtr->MousePosPrev);

		public unsafe RangeAccessor<Vector2> MouseClickedPos => new RangeAccessor<Vector2>(&NativePtr->MouseClickedPos_0, 5);

		public unsafe RangeAccessor<double> MouseClickedTime => new RangeAccessor<double>(NativePtr->MouseClickedTime, 5);

		public unsafe RangeAccessor<bool> MouseClicked => new RangeAccessor<bool>(NativePtr->MouseClicked, 5);

		public unsafe RangeAccessor<bool> MouseDoubleClicked => new RangeAccessor<bool>(NativePtr->MouseDoubleClicked, 5);

		public unsafe RangeAccessor<ushort> MouseClickedCount => new RangeAccessor<ushort>(NativePtr->MouseClickedCount, 5);

		public unsafe RangeAccessor<ushort> MouseClickedLastCount => new RangeAccessor<ushort>(NativePtr->MouseClickedLastCount, 5);

		public unsafe RangeAccessor<bool> MouseReleased => new RangeAccessor<bool>(NativePtr->MouseReleased, 5);

		public unsafe RangeAccessor<bool> MouseDownOwned => new RangeAccessor<bool>(NativePtr->MouseDownOwned, 5);

		public unsafe RangeAccessor<bool> MouseDownOwnedUnlessPopupClose => new RangeAccessor<bool>(NativePtr->MouseDownOwnedUnlessPopupClose, 5);

		public unsafe RangeAccessor<float> MouseDownDuration => new RangeAccessor<float>(NativePtr->MouseDownDuration, 5);

		public unsafe RangeAccessor<float> MouseDownDurationPrev => new RangeAccessor<float>(NativePtr->MouseDownDurationPrev, 5);

		public unsafe RangeAccessor<Vector2> MouseDragMaxDistanceAbs => new RangeAccessor<Vector2>(&NativePtr->MouseDragMaxDistanceAbs_0, 5);

		public unsafe RangeAccessor<float> MouseDragMaxDistanceSqr => new RangeAccessor<float>(NativePtr->MouseDragMaxDistanceSqr, 5);

		public unsafe ref float PenPressure => ref Unsafe.AsRef<float>(&NativePtr->PenPressure);

		public unsafe ref bool AppFocusLost => ref Unsafe.AsRef<bool>(&NativePtr->AppFocusLost);

		public unsafe ref bool AppAcceptingEvents => ref Unsafe.AsRef<bool>(&NativePtr->AppAcceptingEvents);

		public unsafe ref sbyte BackendUsingLegacyKeyArrays => ref Unsafe.AsRef<sbyte>(&NativePtr->BackendUsingLegacyKeyArrays);

		public unsafe ref bool BackendUsingLegacyNavInputArray => ref Unsafe.AsRef<bool>(&NativePtr->BackendUsingLegacyNavInputArray);

		public unsafe ref ushort InputQueueSurrogate => ref Unsafe.AsRef<ushort>(&NativePtr->InputQueueSurrogate);

		public unsafe ImVector<ushort> InputQueueCharacters => new ImVector<ushort>(NativePtr->InputQueueCharacters);

		public unsafe ImGuiIOPtr(ImGuiIO* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiIOPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiIO*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiIOPtr(ImGuiIO* nativePtr)
		{
			return new ImGuiIOPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiIO*(ImGuiIOPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiIOPtr(IntPtr nativePtr)
		{
			return new ImGuiIOPtr(nativePtr);
		}

		public unsafe void AddFocusEvent(bool focused)
		{
			byte focused2 = (byte)(focused ? 1 : 0);
			ImGuiNative.ImGuiIO_AddFocusEvent(NativePtr, focused2);
		}

		public unsafe void AddInputCharacter(uint c)
		{
			ImGuiNative.ImGuiIO_AddInputCharacter(NativePtr, c);
		}

		public unsafe void AddInputCharactersUTF8(string str)
		{
			int num = 0;
			byte* ptr;
			if (str != null)
			{
				num = Encoding.UTF8.GetByteCount(str);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.ImGuiIO_AddInputCharactersUTF8(NativePtr, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe void AddInputCharacterUTF16(ushort c)
		{
			ImGuiNative.ImGuiIO_AddInputCharacterUTF16(NativePtr, c);
		}

		public unsafe void AddKeyAnalogEvent(ImGuiKey key, bool down, float v)
		{
			byte down2 = (byte)(down ? 1 : 0);
			ImGuiNative.ImGuiIO_AddKeyAnalogEvent(NativePtr, key, down2, v);
		}

		public unsafe void AddKeyEvent(ImGuiKey key, bool down)
		{
			byte down2 = (byte)(down ? 1 : 0);
			ImGuiNative.ImGuiIO_AddKeyEvent(NativePtr, key, down2);
		}

		public unsafe void AddMouseButtonEvent(int button, bool down)
		{
			byte down2 = (byte)(down ? 1 : 0);
			ImGuiNative.ImGuiIO_AddMouseButtonEvent(NativePtr, button, down2);
		}

		public unsafe void AddMousePosEvent(float x, float y)
		{
			ImGuiNative.ImGuiIO_AddMousePosEvent(NativePtr, x, y);
		}

		public unsafe void AddMouseViewportEvent(uint id)
		{
			ImGuiNative.ImGuiIO_AddMouseViewportEvent(NativePtr, id);
		}

		public unsafe void AddMouseWheelEvent(float wh_x, float wh_y)
		{
			ImGuiNative.ImGuiIO_AddMouseWheelEvent(NativePtr, wh_x, wh_y);
		}

		public unsafe void ClearInputCharacters()
		{
			ImGuiNative.ImGuiIO_ClearInputCharacters(NativePtr);
		}

		public unsafe void ClearInputKeys()
		{
			ImGuiNative.ImGuiIO_ClearInputKeys(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiIO_destroy(NativePtr);
		}

		public unsafe void SetAppAcceptingEvents(bool accepting_events)
		{
			byte accepting_events2 = (byte)(accepting_events ? 1 : 0);
			ImGuiNative.ImGuiIO_SetAppAcceptingEvents(NativePtr, accepting_events2);
		}

		public unsafe void SetKeyEventNativeData(ImGuiKey key, int native_keycode, int native_scancode)
		{
			int native_legacy_index = -1;
			ImGuiNative.ImGuiIO_SetKeyEventNativeData(NativePtr, key, native_keycode, native_scancode, native_legacy_index);
		}

		public unsafe void SetKeyEventNativeData(ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index)
		{
			ImGuiNative.ImGuiIO_SetKeyEventNativeData(NativePtr, key, native_keycode, native_scancode, native_legacy_index);
		}
	}
}
