namespace XGamingRuntime.Interop
{
	internal struct XStoreVideo
	{
		internal readonly UTF8StringPtr uri;

		internal readonly uint height;

		internal readonly uint width;

		internal readonly UTF8StringPtr caption;

		internal readonly UTF8StringPtr videoPurposeTag;

		internal readonly XStoreImage previewImage;

		internal XStoreVideo(XGamingRuntime.XStoreVideo publicObject, DisposableCollection disposableCollection)
		{
			uri = default(UTF8StringPtr);
			height = 0u;
			width = 0u;
			caption = default(UTF8StringPtr);
			videoPurposeTag = default(UTF8StringPtr);
			previewImage = default(XStoreImage);
		}
	}
}
