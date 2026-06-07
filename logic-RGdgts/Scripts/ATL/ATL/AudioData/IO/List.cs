using System.IO;

namespace ATL.AudioData.IO
{
	internal static class List
	{
		public static string FromStream(Stream source, MetaDataIO meta, MetaDataIO.ReadTagParams readTagParams, long chunkSize)
		{
			return null;
		}

		private static void readInfoPurpose(Stream source, MetaDataIO meta, MetaDataIO.ReadTagParams readTagParams, long chunkSize, long maxPos)
		{
		}

		private static void readDataListPurpose(Stream source, MetaDataIO meta, MetaDataIO.ReadTagParams readTagParams, long maxPos)
		{
		}

		private static void readLabelSubChunk(Stream source, MetaDataIO meta, int position, int size, MetaDataIO.ReadTagParams readTagParams)
		{
		}

		private static void readLabeledTextSubChunk(Stream source, MetaDataIO meta, int position, int size, MetaDataIO.ReadTagParams readTagParams)
		{
		}
	}
}
