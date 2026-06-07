using System.Collections;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CodecList : IEnumerable
	{
		private Codec[] _codecs;

		public Codec[] Codecs => null;

		public int Count => 0;

		internal CodecList(Codec[] codecs)
		{
		}

		public Codec FindCodec(string name, MediaApi mediaApi = MediaApi.Unknown)
		{
			return null;
		}

		public Codec GetFirstWithMediaApi(MediaApi api)
		{
			return null;
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}
	}
}
