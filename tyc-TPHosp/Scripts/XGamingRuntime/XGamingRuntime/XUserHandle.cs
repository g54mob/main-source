using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XUserHandle
	{
		internal XGamingRuntime.Interop.XUserHandle InteropHandle { get; private set; }

		internal XUserHandle(XGamingRuntime.Interop.XUserHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapAndReturnHResult(int hresult, XGamingRuntime.Interop.XUserHandle interopHandle, out XUserHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XUserHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		internal void ClearInteropHandle()
		{
			InteropHandle = default(XGamingRuntime.Interop.XUserHandle);
		}

		public override bool Equals(object obj)
		{
			if (obj is XUserHandle xUserHandle)
			{
				return InteropHandle.Ptr == xUserHandle.InteropHandle.Ptr;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return InteropHandle.Ptr.GetHashCode();
		}

		public static bool operator ==(XUserHandle handle1, XUserHandle handle2)
		{
			return handle1?.Equals(handle2) ?? ((object)handle2 == null);
		}

		public static bool operator !=(XUserHandle handle1, XUserHandle handle2)
		{
			return !(handle1 == handle2);
		}
	}
}
