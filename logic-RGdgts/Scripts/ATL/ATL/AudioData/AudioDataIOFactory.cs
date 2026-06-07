using System.IO;

namespace ATL.AudioData
{
	public class AudioDataIOFactory : Factory
	{
		public static readonly int NB_CODEC_FAMILIES;

		private static AudioDataIOFactory theFactory;

		private static readonly object _lockable;

		public static AudioDataIOFactory GetInstance()
		{
			return null;
		}

		public IAudioDataIO GetFromPath(string path, int alternate = 0)
		{
			return null;
		}

		public IAudioDataIO GetFromMimeType(string mimeType, string path, int alternate = 0)
		{
			return null;
		}

		public IAudioDataIO GetFromStream(Stream s)
		{
			return null;
		}

		private IAudioDataIO getFromFormat(string path, Format theFormat)
		{
			return null;
		}
	}
}
