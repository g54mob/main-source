using System;
using System.Runtime.InteropServices;

namespace SQLite
{
	public static class SQLite3
	{
		public enum Result
		{
			OK = 0,
			Error = 1,
			Internal = 2,
			Perm = 3,
			Abort = 4,
			Busy = 5,
			Locked = 6,
			NoMem = 7,
			ReadOnly = 8,
			Interrupt = 9,
			IOError = 10,
			Corrupt = 11,
			NotFound = 12,
			Full = 13,
			CannotOpen = 14,
			LockErr = 15,
			Empty = 16,
			SchemaChngd = 17,
			TooBig = 18,
			Constraint = 19,
			Mismatch = 20,
			Misuse = 21,
			NotImplementedLFS = 22,
			AccessDenied = 23,
			Format = 24,
			Range = 25,
			NonDBFile = 26,
			Notice = 27,
			Warning = 28,
			Row = 100,
			Done = 101
		}

		public enum ExtendedResult
		{
			IOErrorRead = 266,
			IOErrorShortRead = 522,
			IOErrorWrite = 778,
			IOErrorFsync = 1034,
			IOErrorDirFSync = 1290,
			IOErrorTruncate = 1546,
			IOErrorFStat = 1802,
			IOErrorUnlock = 2058,
			IOErrorRdlock = 2314,
			IOErrorDelete = 2570,
			IOErrorBlocked = 2826,
			IOErrorNoMem = 3082,
			IOErrorAccess = 3338,
			IOErrorCheckReservedLock = 3594,
			IOErrorLock = 3850,
			IOErrorClose = 4106,
			IOErrorDirClose = 4362,
			IOErrorSHMOpen = 4618,
			IOErrorSHMSize = 4874,
			IOErrorSHMLock = 5130,
			IOErrorSHMMap = 5386,
			IOErrorSeek = 5642,
			IOErrorDeleteNoEnt = 5898,
			IOErrorMMap = 6154,
			LockedSharedcache = 262,
			BusyRecovery = 261,
			CannottOpenNoTempDir = 270,
			CannotOpenIsDir = 526,
			CannotOpenFullPath = 782,
			CorruptVTab = 267,
			ReadonlyRecovery = 264,
			ReadonlyCannotLock = 520,
			ReadonlyRollback = 776,
			AbortRollback = 516,
			ConstraintCheck = 275,
			ConstraintCommitHook = 531,
			ConstraintForeignKey = 787,
			ConstraintFunction = 1043,
			ConstraintNotNull = 1299,
			ConstraintPrimaryKey = 1555,
			ConstraintTrigger = 1811,
			ConstraintUnique = 2067,
			ConstraintVTab = 2323,
			NoticeRecoverWAL = 283,
			NoticeRecoverRollback = 539
		}

		public enum ConfigOption
		{
			SingleThread = 1,
			MultiThread = 2,
			Serialized = 3
		}

		public enum ColType
		{
			Integer = 1,
			Float = 2,
			Text = 3,
			Blob = 4,
			Null = 5
		}

		[Flags]
		public enum SerializeFlags : uint
		{
			None = 0u,
			NoCopy = 1u
		}

		[Flags]
		public enum DeserializeFlags : uint
		{
			None = 0u,
			FreeOnClose = 1u,
			Resizeable = 2u,
			ReadOnly = 4u
		}

		public const string LibraryPath = "gilzoide-sqlite-net";

		[PreserveSig]
		public static extern int Threadsafe();

		[PreserveSig]
		public static extern Result Open(string filename, out IntPtr db);

		[PreserveSig]
		public static extern Result Open(string filename, out IntPtr db, int flags, string zvfs);

		[PreserveSig]
		public static extern Result Open(byte[] filename, out IntPtr db, int flags, string zvfs);

		[PreserveSig]
		public static extern Result Open16(string filename, out IntPtr db);

		[PreserveSig]
		public static extern Result EnableLoadExtension(IntPtr db, int onoff);

		[PreserveSig]
		public static extern Result Close(IntPtr db);

		[PreserveSig]
		public static extern Result Close2(IntPtr db);

		[PreserveSig]
		public static extern Result Initialize();

		[PreserveSig]
		public static extern Result Shutdown();

		[PreserveSig]
		public static extern Result Config(ConfigOption option);

		[PreserveSig]
		public static extern int SetDirectory(uint directoryType, string directoryPath);

		[PreserveSig]
		public static extern Result BusyTimeout(IntPtr db, int milliseconds);

		[PreserveSig]
		public static extern int Changes(IntPtr db);

		[PreserveSig]
		public static extern Result Prepare2(IntPtr db, string sql, int numBytes, out IntPtr stmt, IntPtr pzTail);

		public static IntPtr Prepare2(IntPtr db, string query)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		public static extern Result Step(IntPtr stmt);

		[PreserveSig]
		public static extern Result Reset(IntPtr stmt);

		[PreserveSig]
		public static extern Result Finalize(IntPtr stmt);

		[PreserveSig]
		public static extern long LastInsertRowid(IntPtr db);

		[PreserveSig]
		public static extern IntPtr Errmsg(IntPtr db);

		public static string GetErrmsg(IntPtr db)
		{
			return null;
		}

		[PreserveSig]
		public static extern int BindParameterIndex(IntPtr stmt, string name);

		[PreserveSig]
		public static extern int BindNull(IntPtr stmt, int index);

		[PreserveSig]
		public static extern int BindInt(IntPtr stmt, int index, int val);

		[PreserveSig]
		public static extern int BindInt64(IntPtr stmt, int index, long val);

		[PreserveSig]
		public static extern int BindDouble(IntPtr stmt, int index, double val);

		[PreserveSig]
		public static extern int BindText(IntPtr stmt, int index, string val, int n, IntPtr free);

		[PreserveSig]
		public static extern int BindBlob(IntPtr stmt, int index, byte[] val, int n, IntPtr free);

		[PreserveSig]
		public static extern int ColumnCount(IntPtr stmt);

		[PreserveSig]
		public static extern IntPtr ColumnName(IntPtr stmt, int index);

		[PreserveSig]
		private static extern IntPtr ColumnName16Internal(IntPtr stmt, int index);

		public static string ColumnName16(IntPtr stmt, int index)
		{
			return null;
		}

		[PreserveSig]
		public static extern ColType ColumnType(IntPtr stmt, int index);

		[PreserveSig]
		public static extern int ColumnInt(IntPtr stmt, int index);

		[PreserveSig]
		public static extern long ColumnInt64(IntPtr stmt, int index);

		[PreserveSig]
		public static extern double ColumnDouble(IntPtr stmt, int index);

		[PreserveSig]
		public static extern IntPtr ColumnText(IntPtr stmt, int index);

		[PreserveSig]
		public static extern IntPtr ColumnText16(IntPtr stmt, int index);

		[PreserveSig]
		public static extern IntPtr ColumnBlob(IntPtr stmt, int index);

		[PreserveSig]
		public static extern int ColumnBytes(IntPtr stmt, int index);

		public static string ColumnString(IntPtr stmt, int index)
		{
			return null;
		}

		public static byte[] ColumnByteArray(IntPtr stmt, int index)
		{
			return null;
		}

		[PreserveSig]
		public static extern Result GetResult(IntPtr db);

		[PreserveSig]
		public static extern ExtendedResult ExtendedErrCode(IntPtr db);

		[PreserveSig]
		public static extern int LibVersionNumber();

		[PreserveSig]
		public static extern IntPtr BackupInit(IntPtr destDb, string destName, IntPtr sourceDb, string sourceName);

		[PreserveSig]
		public static extern Result BackupStep(IntPtr backup, int numPages);

		[PreserveSig]
		public static extern Result BackupFinish(IntPtr backup);

		[PreserveSig]
		public static extern IntPtr Serialize(IntPtr db, string zSchema, out long piSize, SerializeFlags mFlags);

		[PreserveSig]
		public static extern Result Deserialize(IntPtr db, string zSchema, byte[] pData, long szDb, long szBuf, DeserializeFlags mFlags);

		[PreserveSig]
		public unsafe static extern Result Deserialize(IntPtr db, string zSchema, void* pData, long szDb, long szBuf, DeserializeFlags mFlags);

		[PreserveSig]
		public static extern IntPtr Malloc(int size);

		[PreserveSig]
		public static extern IntPtr Malloc(long size);

		[PreserveSig]
		public static extern IntPtr Realloc(IntPtr ptr, int size);

		[PreserveSig]
		public static extern IntPtr Realloc(IntPtr ptr, long size);

		[PreserveSig]
		public static extern void Free(IntPtr ptr);

		[PreserveSig]
		public static extern int ColumnBytes16(IntPtr stmt, int index);

		static SQLite3()
		{
		}
	}
}
