using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IdSharp.ComInterop.Utils
{
	[ComVisible(true)]
	[Guid("8698B0BF-63DB-4314-9E5E-6E7B0A7D03CF")]
	[ClassInterface(ClassInterfaceType.None)]
	public class PictureUtils : IPictureUtils
	{
		public object GetIPictureDispFromByteArray(byte[] image)
		{
			MethodInfo method = typeof(AxHost).GetMethod("GetIPictureDispFromPicture", BindingFlags.Static | BindingFlags.NonPublic);
			return method.Invoke(null, new object[1] { Image.FromStream(new MemoryStream(image)) });
		}

		public object GetIPictureDispFromImage(Image image)
		{
			MethodInfo method = typeof(AxHost).GetMethod("GetIPictureDispFromPicture", BindingFlags.Static | BindingFlags.NonPublic);
			return method.Invoke(null, new object[1] { image });
		}
	}
}
