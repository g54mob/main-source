using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreVideo
	{
		public string Uri { get; }

		public uint Height { get; }

		public uint Width { get; }

		public string Caption { get; }

		public string VideoPurposeTag { get; }

		public XStoreImage PreviewImage { get; }

		internal XStoreVideo(XGamingRuntime.Interop.XStoreVideo rawVideo)
		{
			Uri = rawVideo.uri.GetString();
			Height = rawVideo.height;
			Width = rawVideo.width;
			Caption = rawVideo.caption.GetString();
			VideoPurposeTag = rawVideo.videoPurposeTag.GetString();
			PreviewImage = new XStoreImage(rawVideo.previewImage);
		}
	}
}
