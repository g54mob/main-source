using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class XStore
	{
		[PreserveSig]
		internal static extern int XStoreShowProductPageUIAsync(XStoreContextHandle storeContextHandle, byte[] storeId, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XStoreShowProductPageUIResult(XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XStoreShowAssociatedProductsUIAsync(XStoreContextHandle storeContextHandle, byte[] storeId, XStoreProductKind productKinds, XAsyncBlockPtr async);

		[PreserveSig]
		internal static extern int XStoreShowAssociatedProductsUIResult(XAsyncBlockPtr async);
	}
}
