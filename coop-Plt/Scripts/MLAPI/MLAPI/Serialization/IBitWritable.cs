using System.IO;

namespace MLAPI.Serialization
{
	public interface IBitWritable
	{
		void Read(Stream stream);

		void Write(Stream stream);
	}
}
