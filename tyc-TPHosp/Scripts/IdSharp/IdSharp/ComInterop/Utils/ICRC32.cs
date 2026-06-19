using System.IO;
using System.Runtime.InteropServices;

namespace IdSharp.ComInterop.Utils
{
	[ComVisible(true)]
	[Guid("EE232085-9186-4e54-9203-5A8C7888489B")]
	public interface ICRC32
	{
		[DispId(1)]
		string CalculateFromFile(string path);

		[DispId(2)]
		string CalculateFromStream(Stream stream);

		[DispId(3)]
		string CalculateFromByteArray(byte[] data);

		[DispId(4)]
		int CalculateInt32FromFile(string path);

		[DispId(5)]
		int CalculateInt32FromStream(Stream stream);

		[DispId(6)]
		int CalculateInt32FromByteArray(byte[] data);
	}
}
