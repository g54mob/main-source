using System.Collections.Generic;
using System.IO;

namespace ATL.AudioData.IO
{
	internal static class WavHelper
	{
		public static IList<string> getEligibleKeys(string prefix, ICollection<string> keys)
		{
			return null;
		}

		public static int readInt32(Stream source, MetaDataIO meta, string fieldName, byte[] buffer, bool readAllMetaFrames)
		{
			return 0;
		}

		public static void readInt16(Stream source, MetaDataIO meta, string fieldName, byte[] buffer, bool readAllMetaFrames)
		{
		}

		public static void skipEndPadding(Stream s, long maxPos)
		{
		}
	}
}
