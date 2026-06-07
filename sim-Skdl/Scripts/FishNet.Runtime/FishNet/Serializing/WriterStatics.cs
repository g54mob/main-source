using System.Text;
using FishNet.Documenting;

namespace FishNet.Serializing
{
	[APIExclude]
	internal class WriterStatics
	{
		private static readonly UTF8Encoding _encoding;

		private static byte[] _stringBuffer;

		public static byte[] GetStringBuffer(string str, out int size)
		{
			size = default(int);
			return null;
		}

		public static byte[] GetStringBuffer(string str)
		{
			return null;
		}
	}
}
