using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreQueryResult
	{
		internal XStoreProductQueryHandle QueryHandle { get; }

		public bool HasMorePages { get; }

		public XStoreProduct[] PageItems { get; }

		internal XStoreQueryResult(XStoreProductQueryHandle queryHandle, XStoreProduct[] pageItems, bool hasMorePages)
		{
			QueryHandle = queryHandle;
			PageItems = pageItems;
			HasMorePages = hasMorePages;
		}
	}
}
