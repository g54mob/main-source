using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NAudio.MediaFoundation
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("DF598932-F10C-4E39-BBA2-C308F101DAA3")]
	public interface IMFMediaEvent : IMFAttributes
	{
		new void GetItem([In] Guid guidKey, [In][Out] IntPtr pValue);

		new void GetItemType([In] Guid guidKey, out int pType);

		new void CompareItem([In] Guid guidKey, IntPtr value, out bool pbResult);

		new void Compare(IMFAttributes pTheirs, int matchType, out bool pbResult);

		new void GetUINT32([In] Guid guidKey, out int punValue);

		new void GetUINT64([In] Guid guidKey, out long punValue);

		new void GetDouble([In] Guid guidKey, out double pfValue);

		new void GetGUID([In] Guid guidKey, out Guid pguidValue);

		new void GetStringLength([In] Guid guidKey, out int pcchLength);

		new void GetString([In] Guid guidKey, [Out] StringBuilder pwszValue, int cchBufSize, out int pcchLength);

		new void GetAllocatedString([In] Guid guidKey, out string ppwszValue, out int pcchLength);

		new void GetBlobSize([In] Guid guidKey, out int pcbBlobSize);

		new void GetBlob([In] Guid guidKey, [Out] byte[] pBuf, int cbBufSize, out int pcbBlobSize);

		new void GetAllocatedBlob([In] Guid guidKey, out IntPtr ip, out int pcbSize);

		new void GetUnknown([In] Guid guidKey, [In] Guid riid, out object ppv);

		new void SetItem([In] Guid guidKey, IntPtr value);

		new void DeleteItem([In] Guid guidKey);

		new void DeleteAllItems();

		new void SetUINT32([In] Guid guidKey, int unValue);

		new void SetUINT64([In] Guid guidKey, long unValue);

		new void SetDouble([In] Guid guidKey, double fValue);

		new void SetGUID([In] Guid guidKey, [In] Guid guidValue);

		new void SetString([In] Guid guidKey, [In] string wszValue);

		new void SetBlob([In] Guid guidKey, [In] byte[] pBuf, int cbBufSize);

		new void SetUnknown(Guid guidKey, [In] object pUnknown);

		new void LockStore();

		new void UnlockStore();

		new void GetCount(out int pcItems);

		new void GetItemByIndex(int unIndex, out Guid pGuidKey, [In][Out] IntPtr pValue);

		new void CopyAllItems([In] IMFAttributes pDest);

		void GetType(out MediaEventType pmet);

		void GetExtendedType(out Guid pguidExtendedType);

		void GetStatus(out int phrStatus);

		void GetValue([Out] IntPtr pvValue);
	}
}
