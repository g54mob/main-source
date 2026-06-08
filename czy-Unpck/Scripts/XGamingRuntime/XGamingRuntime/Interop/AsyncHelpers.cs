using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal class AsyncHelpers
	{
		internal static XAsyncBlockPtr WrapAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback)
		{
			UnmanagedCallback<XAsyncCompletionRoutine, XAsyncCompletionRoutine> unmanagedCallback = new UnmanagedCallback<XAsyncCompletionRoutine, XAsyncCompletionRoutine>
			{
				directCallback = AsyncBlockCallback,
				userCallback = callback
			};
			GCHandle value = GCHandle.Alloc(unmanagedCallback);
			XAsyncBlock structure = new XAsyncBlock
			{
				queue = queue,
				context = GCHandle.ToIntPtr(value),
				callback = Marshal.GetFunctionPointerForDelegate(unmanagedCallback.directCallback)
			};
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
			return new XAsyncBlockPtr(intPtr);
		}

		internal static void CleanupAsyncBlock(XAsyncBlockPtr block)
		{
			GCHandle.FromIntPtr(((XAsyncBlock)Marshal.PtrToStructure(block.IntPtr, typeof(XAsyncBlock))).context).Free();
			Marshal.FreeHGlobal(block.IntPtr);
		}

		[MonoPInvokeCallback]
		private static void AsyncBlockCallback(XAsyncBlockPtr block)
		{
			GCHandle gCHandle = GCHandle.FromIntPtr(((XAsyncBlock)Marshal.PtrToStructure(block.IntPtr, typeof(XAsyncBlock))).context);
			(gCHandle.Target as UnmanagedCallback<XAsyncCompletionRoutine, XAsyncCompletionRoutine>).userCallback(block);
			gCHandle.Free();
			Marshal.FreeHGlobal(block.IntPtr);
		}
	}
}
