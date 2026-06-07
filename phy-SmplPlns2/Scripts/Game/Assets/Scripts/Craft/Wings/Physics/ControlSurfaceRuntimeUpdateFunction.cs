using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.Craft.Wings.Runtime;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct ControlSurfaceRuntimeUpdateFunction
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void RuntimeUpdateDelegate(ref ControlSurfaceRuntimeArgs args, void* runtimeData);

		private FunctionPointer<RuntimeUpdateDelegate> _functionPointer;

		private unsafe void* _data;

		public unsafe static ControlSurfaceRuntimeUpdateFunction Create<T>(FunctionPointer<RuntimeUpdateDelegate> function, T instance, List<IntPtr> mallocPtrs) where T : unmanaged
		{
			int num = UnsafeUtility.SizeOf<T>();
			void* ptr = UnsafeUtility.Malloc(num, UnsafeUtility.AlignOf<T>(), Allocator.Persistent);
			mallocPtrs.Add((IntPtr)ptr);
			UnsafeUtility.MemCpy(ptr, &instance, num);
			return new ControlSurfaceRuntimeUpdateFunction
			{
				_functionPointer = function,
				_data = ptr
			};
		}

		internal unsafe readonly void Invoke(ref ControlSurfaceRuntimeArgs args)
		{
			_functionPointer.Invoke(ref args, _data);
		}
	}
}
