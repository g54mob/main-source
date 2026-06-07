using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NAudio.MediaFoundation
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("2CD2D921-C447-44A7-A13C-4ADABFC247E3")]
	public interface IMFAttributes
	{
		void GetItem([In] Guid guidKey, [In][Out] IntPtr pValue);

		void GetItemType([In] Guid guidKey, out int pType);

		void CompareItem([In] Guid guidKey, IntPtr value, out bool pbResult);

		void Compare(IMFAttributes pTheirs, int matchType, out bool pbResult);

		void GetUINT32([In] Guid guidKey, out int punValue);

		void GetUINT64([In] Guid guidKey, out long punValue);

		void GetDouble([In] Guid guidKey, out double pfValue);

		void GetGUID([In] Guid guidKey, out Guid pguidValue);

		void GetStringLength([In] Guid guidKey, out int pcchLength);

		void GetString([In] Guid guidKey, [Out] StringBuilder pwszValue, int cchBufSize, out int pcchLength);

		void GetAllocatedString([In] Guid guidKey, out string ppwszValue, out int pcchLength);

		void GetBlobSize([In] Guid guidKey, out int pcbBlobSize);

		void GetBlob([In] Guid guidKey, [Out] byte[] pBuf, int cbBufSize, out int pcbBlobSize);

		void GetAllocatedBlob([In] Guid guidKey, out IntPtr ip, out int pcbSize);

		void GetUnknown([In] Guid guidKey, [In] Guid riid, out object ppv);

		void SetItem([In] Guid guidKey, IntPtr Value);

		void DeleteItem([In] Guid guidKey);

		void DeleteAllItems();

		void SetUINT32([In] Guid guidKey, int unValue);

		void SetUINT64([In] Guid guidKey, long unValue);

		void SetDouble([In] Guid guidKey, double fValue);

		void SetGUID([In] Guid guidKey, [In] Guid guidValue);

		void SetString([In] Guid guidKey, [In] string wszValue);

		void SetBlob([In] Guid guidKey, [In] byte[] pBuf, int cbBufSize);

		void SetUnknown(Guid guidKey, [In] object pUnknown);

		void LockStore();

		void UnlockStore();

		void GetCount(out int pcItems);

		void GetItemByIndex(int unIndex, out Guid pGuidKey, [In][Out] IntPtr pValue);

		void CopyAllItems([In] IMFAttributes pDest);
	}
}
