using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImGuiSizeCallbackDataPtr
	{
		public unsafe ImGuiSizeCallbackData* NativePtr { get; }

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

		public unsafe ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&NativePtr->Pos);

		public unsafe ref Vector2 CurrentSize => ref Unsafe.AsRef<Vector2>(&NativePtr->CurrentSize);

		public unsafe ref Vector2 DesiredSize => ref Unsafe.AsRef<Vector2>(&NativePtr->DesiredSize);

		public unsafe ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiSizeCallbackDataPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiSizeCallbackData*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiSizeCallbackDataPtr(ImGuiSizeCallbackData* nativePtr)
		{
			return new ImGuiSizeCallbackDataPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiSizeCallbackData*(ImGuiSizeCallbackDataPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiSizeCallbackDataPtr(IntPtr nativePtr)
		{
			return new ImGuiSizeCallbackDataPtr(nativePtr);
		}
	}
}
