using System;
using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public static class MarshalHelpers
	{
		public delegate int GetContextFunc<InteropHandle>(InteropHandle handle, out IntPtr context);

		public delegate int GetHandlesFun<InputInteropHandle>(InputInteropHandle input, out uint count, out IntPtr handles);

		public static int GetCustomContext<InteropHandle>(GetContextFunc<InteropHandle> getContextFunc, InteropHandle handle, out object customContext)
		{
			customContext = null;
			IntPtr context;
			int num = getContextFunc(handle, out context);
			if (LobbyError.SUCCEEDED(num) && context != IntPtr.Zero)
			{
				customContext = GCHandle.FromIntPtr(context).Target;
			}
			return num;
		}

		public static int SetCustomContext<InteropHandle>(GetContextFunc<InteropHandle> getContextFunc, Func<InteropHandle, IntPtr, int> setContextFunc, InteropHandle handle, object customContext)
		{
			IntPtr context;
			int num = getContextFunc(handle, out context);
			if (LobbyError.SUCCEEDED(num))
			{
				IntPtr intPtr = IntPtr.Zero;
				if (customContext != null)
				{
					intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(customContext));
				}
				num = setContextFunc(handle, intPtr);
				if (LobbyError.SUCCEEDED(num))
				{
					if (context != IntPtr.Zero)
					{
						GCHandle.FromIntPtr(context).Free();
					}
				}
				else if (intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
			}
			return num;
		}

		public static int GetArrayOfObjects<InputInteropHandle, IntermediaObject, OutputObject>(GetHandlesFun<InputInteropHandle> getHandlesFun, Func<IntermediaObject, OutputObject> ctorFun, InputInteropHandle inputHandle, out OutputObject[] outputHandles)
		{
			outputHandles = null;
			uint count;
			IntPtr handles;
			int num = getHandlesFun(inputHandle, out count, out handles);
			if (LobbyError.SUCCEEDED(num))
			{
				outputHandles = Converters.PtrToClassArray(handles, count, ctorFun);
			}
			return num;
		}
	}
}
