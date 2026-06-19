using System.Drawing;
using System.Runtime.InteropServices;

namespace IdSharp.ComInterop.Utils
{
	[Guid("00B18C39-5C2C-4364-B3EE-3DB8F944CCD5")]
	[ComVisible(true)]
	public interface IPictureUtils
	{
		object GetIPictureDispFromImage(Image image);

		object GetIPictureDispFromByteArray(byte[] image);
	}
}
