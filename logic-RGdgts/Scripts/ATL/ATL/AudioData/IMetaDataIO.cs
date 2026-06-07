using System.IO;
using ATL.AudioData.IO;

namespace ATL.AudioData
{
	public interface IMetaDataIO : IMetaData
	{
		bool Exists { get; }

		long Size { get; }

		bool Read(Stream source, MetaDataIO.ReadTagParams readTagParams);

		void Clear();
	}
}
