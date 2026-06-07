using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiListClipperPtr
	{
		public unsafe ImGuiListClipper* NativePtr { get; }

		public unsafe ref int DisplayStart => ref Unsafe.AsRef<int>(&NativePtr->DisplayStart);

		public unsafe ref int DisplayEnd => ref Unsafe.AsRef<int>(&NativePtr->DisplayEnd);

		public unsafe ref int ItemsCount => ref Unsafe.AsRef<int>(&NativePtr->ItemsCount);

		public unsafe ref float ItemsHeight => ref Unsafe.AsRef<float>(&NativePtr->ItemsHeight);

		public unsafe ref float StartPosY => ref Unsafe.AsRef<float>(&NativePtr->StartPosY);

		public unsafe IntPtr TempData
		{
			get
			{
				return (IntPtr)NativePtr->TempData;
			}
			set
			{
				NativePtr->TempData = (void*)value;
			}
		}

		public unsafe ImGuiListClipperPtr(ImGuiListClipper* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiListClipperPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiListClipper*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiListClipperPtr(ImGuiListClipper* nativePtr)
		{
			return new ImGuiListClipperPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiListClipper*(ImGuiListClipperPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiListClipperPtr(IntPtr nativePtr)
		{
			return new ImGuiListClipperPtr(nativePtr);
		}

		public unsafe void Begin(int items_count)
		{
			float items_height = -1f;
			ImGuiNative.ImGuiListClipper_Begin(NativePtr, items_count, items_height);
		}

		public unsafe void Begin(int items_count, float items_height)
		{
			ImGuiNative.ImGuiListClipper_Begin(NativePtr, items_count, items_height);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiListClipper_destroy(NativePtr);
		}

		public unsafe void End()
		{
			ImGuiNative.ImGuiListClipper_End(NativePtr);
		}

		public unsafe void ForceDisplayRangeByIndices(int item_min, int item_max)
		{
			ImGuiNative.ImGuiListClipper_ForceDisplayRangeByIndices(NativePtr, item_min, item_max);
		}

		public unsafe bool Step()
		{
			return ImGuiNative.ImGuiListClipper_Step(NativePtr) != 0;
		}
	}
}
