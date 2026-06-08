using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct StbTexteditRowPtr
	{
		public unsafe StbTexteditRow* NativePtr { get; }

		public unsafe ref float x0 => ref Unsafe.AsRef<float>(&NativePtr->x0);

		public unsafe ref float x1 => ref Unsafe.AsRef<float>(&NativePtr->x1);

		public unsafe ref float baseline_y_delta => ref Unsafe.AsRef<float>(&NativePtr->baseline_y_delta);

		public unsafe ref float ymin => ref Unsafe.AsRef<float>(&NativePtr->ymin);

		public unsafe ref float ymax => ref Unsafe.AsRef<float>(&NativePtr->ymax);

		public unsafe ref int num_chars => ref Unsafe.AsRef<int>(&NativePtr->num_chars);

		public unsafe StbTexteditRowPtr(StbTexteditRow* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe StbTexteditRowPtr(IntPtr nativePtr)
		{
			NativePtr = (StbTexteditRow*)(void*)nativePtr;
		}

		public unsafe static implicit operator StbTexteditRowPtr(StbTexteditRow* nativePtr)
		{
			return new StbTexteditRowPtr(nativePtr);
		}

		public unsafe static implicit operator StbTexteditRow*(StbTexteditRowPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator StbTexteditRowPtr(IntPtr nativePtr)
		{
			return new StbTexteditRowPtr(nativePtr);
		}
	}
}
