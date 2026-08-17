using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.Standalone;

public class StandaloneStorage : IPlatformSaveUtils, ILastErrorProvider, IPlatformSaveBackup
{
	public class Blob
	{
		private bool _mDirtyFlag;

		private byte[] _mData;

		public bool IsDirty => _mDirtyFlag;

		public bool IsEmpty => _mData == null;

		public byte[] Data => _mData;

		public void SetData(byte[] data)
		{
			_mData = data;
			_mDirtyFlag = true;
		}

		public void ClearDirty()
		{
			_mDirtyFlag = false;
		}

		public Blob(byte[] data, bool dirtyFlag = true)
		{
			_mDirtyFlag = dirtyFlag;
			_mData = data;
		}
	}

	private const string SAV_EXTENSION = ".sav";

	private const string BAK_EXTENSION = ".bak.sav";

	private Dictionary<string, Blob> _mData;

	private string _targetPath;

	private ErroInfo _mLastError;

	private bool _mInitialized;

	private bool _003CContinuePlayingWithoutSaving_003Ek__BackingField;

	private const int HR_ERROR_HANDLE_DISK_FULL = -2147024857;

	private const int HR_ERROR_DISK_FULL = -2147024784;

	private const int HR_ERROR_SHARING_VIOLATION = -2147024864;

	public unsafe ErroInfo LastError
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected O, but got I
			//IL_001f: Expected native int or pointer, but got O
			ErroInfo erroInfo = default(ErroInfo);
			((ErroInfo*)(nint)erroInfo)->NativeErrorCode = (int)_mLastError;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Framework.Platforms.Standalone.StandaloneStorage)+30]");
			System.Runtime.CompilerServices.Unsafe.Write(&((ErroInfo*)(nint)erroInfo)->Message, (string)0);
			return erroInfo;
		}
	}

	public bool IsReady => _mInitialized;

	public bool ContinuePlayingWithoutSaving
	{
		get
		{
			return _003CContinuePlayingWithoutSaving_003Ek__BackingField;
		}
		set
		{
			_003CContinuePlayingWithoutSaving_003Ek__BackingField = value;
		}
	}

	public unsafe void EraseAllAsync(StorageOperationComplete onComplete)
	{
		//IL_02ac: Expected O, but got I8
		//IL_002b: Expected O, but got Ref
		//IL_01ad: Expected I, but got I8
		//IL_01b6: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_0266: Expected I, but got O
		//IL_009c: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_011f: Expected O, but got I
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		if (_mInitialized)
		{
			IEnumerable<string> enumerable = Directory.EnumerateFiles(_targetPath);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			object obj = (object)(&obj2);
			string text = null;
			object obj3 = default(object);
			object obj13 = default(object);
			string path = default(string);
			while (true)
			{
				object obj5;
				object obj12;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj3 == null)
					{
						break;
					}
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ r10_v5+12E]");
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ r10_v5+B0]");
						obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r8_v25+v560 @ rax_v50*8]");
							if (0 == (nint)typeof(IEnumerator<string>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ r10_v5+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_00dc;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r8_v25+8+v616 @ rcx_v33*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_0245;
					}
					goto IL_00dc;
				}
				throw new NullReferenceException();
				IL_00dc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj5 = 0;
				obj12 = obj13;
				goto IL_0245;
				IL_0245:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v621 @ rdx_v20] (should have been resolved before IL gen)");
				File.Delete(path);
				nint num = (nint)typeof(IEnumerator<string>);
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			if (onComplete == null)
			{
				return;
			}
			object obj14 = 0;
		}
		else
		{
			_mLastError = (ErroInfo)4294967295L;
			if (onComplete == null)
			{
				return;
			}
			nint num = unchecked((nint)6603577472L);
			object obj14 = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	private string GetBackupBlobName(string orgBlobName)
	{
		return Path.ChangeExtension(orgBlobName, ".bak.sav");
	}

	public unsafe void CommitAsync(StorageOperationComplete onComplete, CommitOptions options, bool createBackup = false)
	{
		//IL_03ba: Expected O, but got I8
		//IL_002b: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_0290: Expected I4, but got I8
		//IL_02a6: Expected O, but got I8
		//IL_0058: Expected O, but got Ref
		//IL_024e: Expected O, but got I4
		if (_mInitialized)
		{
			object obj = 0;
			bool flag2 = default(bool);
			bool flag = flag2;
			ErroInfo erroInfo = (ErroInfo)2;
			Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
			if (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				string text = null;
				Dictionary<object, object>.Enumerator enumerator2 = (Dictionary<object, object>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (onComplete == null)
			{
				return;
			}
			object obj2 = 0;
			string text2 = null;
		}
		else
		{
			_mLastError = (ErroInfo)4294967295L;
			if (onComplete == null)
			{
				return;
			}
			object obj2 = 1;
			bool flag = true;
			string text2 = "Storage is not initialized";
			ErroInfo erroInfo = (ErroInfo)4294967295L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	private string GetBlobPath(string blobName)
	{
		return Path.Combine(_targetPath, blobName);
	}

	public void TryRestoreBlobAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
	{
		//IL_00d4: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29BA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string orgBlobName = blobName + ".sav";
		if (_mInitialized)
		{
			string backupBlobName = GetBackupBlobName(orgBlobName);
			GetBlobsAsyncDirect(backupBlobName, onComplete, skipCache);
			return;
		}
		_mLastError = (ErroInfo)4294967295L;
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public bool BackupExists(string blobName)
	{
		string orgBlobName = blobName + ".sav";
		if (_targetPath != null)
		{
			string backupBlobName = GetBackupBlobName(orgBlobName);
			string path = Path.Combine(_targetPath, backupBlobName);
			return File.Exists(path);
		}
		Debug.LogWarning("TARGET PATH NOT SETUP");
		return false;
	}

	public void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29BC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = blobName + ".sav";
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 41 Invalid \"Jump target not found in method: 0x186B46FA0\"");
	}

	private unsafe void GetBlobsAsyncDirect(string blobNameWithExtension, StorageOperationCompleteWithData onComplete, bool skipCache = false)
	{
		//IL_0255: Expected O, but got I8
		//IL_008d: Expected O, but got Ref
		//IL_00bd: Expected O, but got I
		object key;
		object obj;
		if (_mInitialized)
		{
			bool flag = default(bool);
			if (!flag)
			{
				bool flag2 = ((Dictionary<object, object>)(object)_mData).TryGetValue((object)blobNameWithExtension, out object value);
				bool flag3 = !flag2;
				flag = false;
				if (!flag3)
				{
					if (onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_-58_v11 (System.Object)+18]");
						bool flag4 = (nint)0 == 0;
						key = blobNameWithExtension;
						obj = (object)(&value);
						object obj2 = value;
						if (!flag4)
						{
							goto IL_00a4;
						}
						goto IL_01c4;
					}
					return;
				}
			}
			string path = Path.Combine(_targetPath, blobNameWithExtension);
			bool flag5 = File.Exists(path);
			bool flag6 = !flag5;
			key = null;
			Blob blob = null;
			obj = null;
			if (!flag6)
			{
				byte[] mData = File.ReadAllBytes(path);
				Blob blob2 = null;
				blob2._mDirtyFlag = false;
				blob2._mData = mData;
				bool flag7 = ((Dictionary<object, object>)(object)_mData).TryInsert((object)blobNameWithExtension, (object)blob2, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				key = blobNameWithExtension;
				blob = blob2;
				obj = blob2;
				flag = true;
			}
			if (onComplete != null)
			{
				bool flag8 = blob != null;
				object obj2 = blob;
				if (flag8)
				{
					goto IL_00a4;
				}
				goto IL_01c4;
			}
			return;
		}
		_mLastError = (ErroInfo)4294967295L;
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return;
		IL_01c4:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		return;
		IL_00a4:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v32 (System.Object)+18]");
		bool flag9 = ((Dictionary<string, Blob>)0).TryGetValue((string)key, out *(Blob*)obj);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	public void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public StorageResult SetBlob(string containerName, byte[] data)
	{
		//IL_014b: Expected O, but got I8
		//IL_0106: Expected I4, but got O
		string key = containerName + ".sav";
		if (_mInitialized)
		{
			if (_mData != null)
			{
				if (((Dictionary<object, object>)(object)_mData).TryGetValue((object)key, out object value))
				{
					if (value != null)
					{
						_ = 1;
						return StorageResult.Successful;
					}
				}
				else
				{
					Blob blob = null;
					blob._mDirtyFlag = true;
					blob._mData = data;
					if (_mData != null)
					{
						bool flag = ((Dictionary<object, object>)(object)_mData).TryInsert((object)key, (object)blob, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
						return StorageResult.Successful;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (StorageResult)ex;
		}
		_mLastError = (ErroInfo)4294967295L;
		return StorageResult.Failed;
	}

	protected virtual string GetTargetSavePath(string containerName)
	{
		return GetTargetPath(containerName);
	}

	public static string GetTargetPath(string containerName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		string path = default(string);
		return Path.Combine(path, containerName);
	}

	public void InitAsync(string containerName, string containerDisplayName, StorageOperationComplete onComplete)
	{
		string targetSavePath = GetTargetSavePath(containerName);
		_targetPath = targetSavePath;
		DirectoryInfo directoryInfo = Directory.CreateDirectory(_targetPath);
		_mInitialized = true;
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r9 (System.String)+18] (should have been resolved before IL gen)");
		}
	}

	private StorageResult ToStorageResult(Exception ex)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		if (ex != null)
		{
			nint num = (nint)typeof(IOException);
			nint num2 = (nint)ex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<System.IO.IOException>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<System.Exception>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<System.IO.IOException>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<System.Exception>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v5+FFFFFFF8+v42 @ rax_v4*8]");
				if (0 == (nint)typeof(IOException))
				{
					if (ex._HResult == 2147942432L)
					{
						return StorageResult.TargetLocked;
					}
					if (ex._HResult != 2147942439L)
					{
						bool flag = ex._HResult != 2147942512L;
						StorageResult result = StorageResult.Failed;
						if (!flag)
						{
							result = StorageResult.NoFreeSpace;
						}
						return result;
					}
					return StorageResult.NoFreeSpace;
				}
			}
		}
		return StorageResult.Failed;
	}

	public void Close()
	{
		_mInitialized = false;
	}

	public StandaloneStorage()
	{
		Dictionary<string, Blob> mData = new Dictionary<string, Blob>();
		_mData = mData;
	}
}
