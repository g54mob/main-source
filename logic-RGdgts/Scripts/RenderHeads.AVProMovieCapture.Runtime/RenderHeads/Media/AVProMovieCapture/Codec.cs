namespace RenderHeads.Media.AVProMovieCapture
{
	public class Codec : IMediaApiItem
	{
		private CodecType _codecType;

		private int _index;

		private string _name;

		private bool _hasConfigWindow;

		private MediaApi _api;

		public CodecType CodecType => default(CodecType);

		public int Index => 0;

		public string Name => null;

		public MediaApi MediaApi => default(MediaApi);

		public bool HasConfigwindow => false;

		public void ShowConfigWindow()
		{
		}

		internal Codec(CodecType codecType, int index, string name, MediaApi api, bool hasConfigWindow = false)
		{
		}
	}
}
