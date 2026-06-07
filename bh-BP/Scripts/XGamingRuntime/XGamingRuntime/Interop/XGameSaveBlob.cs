using System;

namespace XGamingRuntime.Interop
{
	internal struct XGameSaveBlob
	{
		public XGameSaveBlobInfo info;

		private IntPtr data;

		public void CopyData(byte[] buffer)
		{
		}
	}
}
