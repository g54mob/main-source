using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	public sealed class PlayerDataStorageInterface : Handle
	{
		public const int CopyfilemetadataatindexoptionsApiLatest = 1;

		public const int CopyfilemetadatabyfilenameoptionsApiLatest = 1;

		public const int DeletecacheoptionsApiLatest = 1;

		public const int DeletefileoptionsApiLatest = 1;

		public const int DuplicatefileoptionsApiLatest = 1;

		public const int FileMaxSizeBytes = 67108864;

		public const int FilemetadataApiLatest = 3;

		public const int FilenameMaxLengthBytes = 64;

		public const int GetfilemetadatacountoptionsApiLatest = 1;

		public const int QueryfilelistoptionsApiLatest = 1;

		public const int QueryfileoptionsApiLatest = 1;

		public const int ReadfileoptionsApiLatest = 1;

		public const int WritefileoptionsApiLatest = 1;

		public PlayerDataStorageInterface()
		{
		}

		public PlayerDataStorageInterface(IntPtr innerHandle)
		{
		}

		public Result CopyFileMetadataAtIndex(CopyFileMetadataAtIndexOptions copyFileMetadataOptions, out FileMetadata outMetadata)
		{
			outMetadata = null;
			return default(Result);
		}

		public Result CopyFileMetadataByFilename(CopyFileMetadataByFilenameOptions copyFileMetadataOptions, out FileMetadata outMetadata)
		{
			outMetadata = null;
			return default(Result);
		}

		public Result DeleteCache(DeleteCacheOptions options, object clientData, OnDeleteCacheCompleteCallback completionCallback)
		{
			return default(Result);
		}

		public void DeleteFile(DeleteFileOptions deleteOptions, object clientData, OnDeleteFileCompleteCallback completionCallback)
		{
		}

		public void DuplicateFile(DuplicateFileOptions duplicateOptions, object clientData, OnDuplicateFileCompleteCallback completionCallback)
		{
		}

		public Result GetFileMetadataCount(GetFileMetadataCountOptions getFileMetadataCountOptions, out int outFileMetadataCount)
		{
			outFileMetadataCount = default(int);
			return default(Result);
		}

		public void QueryFile(QueryFileOptions queryFileOptions, object clientData, OnQueryFileCompleteCallback completionCallback)
		{
		}

		public void QueryFileList(QueryFileListOptions queryFileListOptions, object clientData, OnQueryFileListCompleteCallback completionCallback)
		{
		}

		public PlayerDataStorageFileTransferRequest ReadFile(ReadFileOptions readOptions, object clientData, OnReadFileCompleteCallback completionCallback)
		{
			return null;
		}

		public PlayerDataStorageFileTransferRequest WriteFile(WriteFileOptions writeOptions, object clientData, OnWriteFileCompleteCallback completionCallback)
		{
			return null;
		}

		internal static void OnDeleteCacheCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnDeleteFileCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnDuplicateFileCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnFileTransferProgressCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryFileCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryFileListCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnReadFileCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static ReadResult OnReadFileDataCallbackInternalImplementation(IntPtr data)
		{
			return default(ReadResult);
		}

		internal static void OnWriteFileCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static WriteResult OnWriteFileDataCallbackInternalImplementation(IntPtr data, IntPtr outDataBuffer, ref uint outDataWritten)
		{
			return default(WriteResult);
		}

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorage_CopyFileMetadataAtIndex(IntPtr handle, IntPtr copyFileMetadataOptions, ref IntPtr outMetadata);

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorage_CopyFileMetadataByFilename(IntPtr handle, IntPtr copyFileMetadataOptions, ref IntPtr outMetadata);

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorage_DeleteCache(IntPtr handle, IntPtr options, IntPtr clientData, OnDeleteCacheCompleteCallbackInternal completionCallback);

		[PreserveSig]
		internal static extern void EOS_PlayerDataStorage_DeleteFile(IntPtr handle, IntPtr deleteOptions, IntPtr clientData, OnDeleteFileCompleteCallbackInternal completionCallback);

		[PreserveSig]
		internal static extern void EOS_PlayerDataStorage_DuplicateFile(IntPtr handle, IntPtr duplicateOptions, IntPtr clientData, OnDuplicateFileCompleteCallbackInternal completionCallback);

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorage_GetFileMetadataCount(IntPtr handle, IntPtr getFileMetadataCountOptions, ref int outFileMetadataCount);

		[PreserveSig]
		internal static extern void EOS_PlayerDataStorage_QueryFile(IntPtr handle, IntPtr queryFileOptions, IntPtr clientData, OnQueryFileCompleteCallbackInternal completionCallback);

		[PreserveSig]
		internal static extern void EOS_PlayerDataStorage_QueryFileList(IntPtr handle, IntPtr queryFileListOptions, IntPtr clientData, OnQueryFileListCompleteCallbackInternal completionCallback);

		[PreserveSig]
		internal static extern IntPtr EOS_PlayerDataStorage_ReadFile(IntPtr handle, IntPtr readOptions, IntPtr clientData, OnReadFileCompleteCallbackInternal completionCallback);

		[PreserveSig]
		internal static extern void EOS_PlayerDataStorage_FileMetadata_Release(IntPtr fileMetadata);

		[PreserveSig]
		internal static extern IntPtr EOS_PlayerDataStorage_WriteFile(IntPtr handle, IntPtr writeOptions, IntPtr clientData, OnWriteFileCompleteCallbackInternal completionCallback);
	}
}
