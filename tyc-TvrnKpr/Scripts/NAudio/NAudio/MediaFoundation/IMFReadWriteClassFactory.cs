using System;
using System.Runtime.InteropServices;

namespace NAudio.MediaFoundation
{
	[ComImport]
	[Guid("E7FE2E12-661C-40DA-92F9-4F002AB67627")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMFReadWriteClassFactory
	{
		void CreateInstanceFromURL([In] Guid clsid, [In] string pwszURL, [In] IMFAttributes pAttributes, [In] Guid riid, out object ppvObject);

		void CreateInstanceFromObject([In] Guid clsid, [In] object punkObject, [In] IMFAttributes pAttributes, [In] Guid riid, out object ppvObject);
	}
}
