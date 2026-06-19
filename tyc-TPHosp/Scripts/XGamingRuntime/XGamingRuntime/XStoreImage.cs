using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreImage
	{
		public string Uri { get; }

		public uint Height { get; }

		public uint Width { get; }

		public string Caption { get; }

		public string ImagePurposeTag { get; }

		internal XStoreImage(XGamingRuntime.Interop.XStoreImage rawStoreImage)
		{
			Uri = rawStoreImage.uri.GetString();
			Height = rawStoreImage.height;
			Width = rawStoreImage.width;
			Caption = rawStoreImage.caption.GetString();
			ImagePurposeTag = rawStoreImage.imagePurposeTag.GetString();
		}
	}
}
