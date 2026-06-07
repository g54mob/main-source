using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImGuiViewportPtr
	{
		public unsafe ImGuiViewport* NativePtr { get; }

		public unsafe ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);

		public unsafe ref ImGuiViewportFlags Flags => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->Flags);

		public unsafe ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&NativePtr->Pos);

		public unsafe ref Vector2 Size => ref Unsafe.AsRef<Vector2>(&NativePtr->Size);

		public unsafe ref Vector2 WorkPos => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkPos);

		public unsafe ref Vector2 WorkSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkSize);

		public unsafe ref float DpiScale => ref Unsafe.AsRef<float>(&NativePtr->DpiScale);

		public unsafe ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);

		public unsafe ImDrawDataPtr DrawData => new ImDrawDataPtr(NativePtr->DrawData);

		public unsafe IntPtr RendererUserData
		{
			get
			{
				return (IntPtr)NativePtr->RendererUserData;
			}
			set
			{
				NativePtr->RendererUserData = (void*)value;
			}
		}

		public unsafe IntPtr PlatformUserData
		{
			get
			{
				return (IntPtr)NativePtr->PlatformUserData;
			}
			set
			{
				NativePtr->PlatformUserData = (void*)value;
			}
		}

		public unsafe IntPtr PlatformHandle
		{
			get
			{
				return (IntPtr)NativePtr->PlatformHandle;
			}
			set
			{
				NativePtr->PlatformHandle = (void*)value;
			}
		}

		public unsafe IntPtr PlatformHandleRaw
		{
			get
			{
				return (IntPtr)NativePtr->PlatformHandleRaw;
			}
			set
			{
				NativePtr->PlatformHandleRaw = (void*)value;
			}
		}

		public unsafe ref bool PlatformWindowCreated => ref Unsafe.AsRef<bool>(&NativePtr->PlatformWindowCreated);

		public unsafe ref bool PlatformRequestMove => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestMove);

		public unsafe ref bool PlatformRequestResize => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestResize);

		public unsafe ref bool PlatformRequestClose => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestClose);

		public unsafe ImGuiViewportPtr(ImGuiViewport* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiViewportPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiViewport*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiViewportPtr(ImGuiViewport* nativePtr)
		{
			return new ImGuiViewportPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiViewport*(ImGuiViewportPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiViewportPtr(IntPtr nativePtr)
		{
			return new ImGuiViewportPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiViewport_destroy(NativePtr);
		}

		public unsafe Vector2 GetCenter()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.ImGuiViewport_GetCenter(&result, NativePtr);
			return result;
		}

		public unsafe Vector2 GetWorkCenter()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.ImGuiViewport_GetWorkCenter(&result, NativePtr);
			return result;
		}
	}
}
