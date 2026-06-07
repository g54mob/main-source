namespace XGamingRuntime.Interop
{
	internal struct XStoreImage
	{
		internal readonly UTF8StringPtr uri;

		internal readonly uint height;

		internal readonly uint width;

		internal readonly UTF8StringPtr caption;

		internal readonly UTF8StringPtr imagePurposeTag;

		internal XStoreImage(XGamingRuntime.XStoreImage publicObject, DisposableCollection disposableCollection)
		{
			uri = default(UTF8StringPtr);
			height = 0u;
			width = 0u;
			caption = default(UTF8StringPtr);
			imagePurposeTag = default(UTF8StringPtr);
		}
	}
}
