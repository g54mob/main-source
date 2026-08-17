using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.SteamworksIntegration;

public class SteamworksCloudStorage : IPlatformSaveUtils, ILastErrorProvider
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public StorageOperationCompleteWithData onComplete;

		internal void _003CGetBlobsAsync_003Eb__0(byte[] bytes)
		{
			StorageOperationCompleteWithData storageOperationCompleteWithData = onComplete;
			bool flag = bytes == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public StorageOperationComplete onComplete;

		internal void _003CCommitAsync_003Eb__0(bool success)
		{
			//IL_001d: Expected O, but got I4
			StorageOperationComplete storageOperationComplete = onComplete;
			object obj = (success ? 1 : 0) ^ 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private bool _003CContinuePlayingWithoutSaving_003Ek__BackingField;

	private bool m_IsReady;

	private ErroInfo m_LastError;

	private byte[] m_LastBlobData;

	private string m_LastBlobFilename;

	public bool IsReady => m_IsReady;

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

	public unsafe ErroInfo LastError
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected O, but got I
			//IL_001f: Expected native int or pointer, but got O
			ErroInfo erroInfo = default(ErroInfo);
			((ErroInfo*)(nint)erroInfo)->NativeErrorCode = (int)m_LastError;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Framework.Platforms.SteamworksIntegration.SteamworksCloudStorage)+28]");
			System.Runtime.CompilerServices.Unsafe.Write(&((ErroInfo*)(nint)erroInfo)->Message, (string)0);
			return erroInfo;
		}
	}

	private void FailWithLastError(StorageResult result, string msg, StorageOperationComplete callback)
	{
		//IL_0042: Expected O, but got I8
		m_LastError = (ErroInfo)4294967295L;
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: callback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Close()
	{
		m_IsReady = false;
	}

	public unsafe void EraseAllAsync(StorageOperationComplete onComplete)
	{
		//IL_023f: Expected I4, but got I8
		//IL_000d: Expected O, but got Ref
		//IL_00f1: Expected O, but got I8
		SteamRemoteStorage._003Cget_Files_003Ed__30 obj = null;
		obj._003C_003E1__state = -2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
		int num = default(int);
		obj._003C_003El__initialThreadId = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj3 = default(object);
		object obj2 = (object)(&obj3);
		nint num2 = 0;
		object obj4 = default(object);
		IntPtr intPtr = default(IntPtr);
		object obj6 = default(object);
		while (true)
		{
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj4 != null)
				{
					bool flag = obj3 == null;
					num2 = 0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						Steamworks.ISteamRemoteStorage steamRemoteStorage = SteamRemoteStorage.Internal;
						bool flag2 = steamRemoteStorage == null;
						num2 = 0;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899826E0]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
								object obj5 = 6570565192L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7F80");
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [1899826E0] (should have been resolved before IL gen)");
							if (intPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [187A21838] (should have been resolved before IL gen)");
							}
							if (obj6 == null)
							{
								if (onComplete == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								return;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass15_0();
		StorageOperationCompleteWithData onComplete2 = default(StorageOperationCompleteWithData);
		CS_0024_003C_003E8__locals3.onComplete = onComplete2;
		Steamworks.ISteamRemoteStorage steamRemoteStorage = SteamRemoteStorage.Internal;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982720]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7F80");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [189982720] (should have been resolved before IL gen)");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [187A21838] (should have been resolved before IL gen)");
		}
		object obj2 = default(object);
		if (obj2 != null)
		{
			string text = default(string);
			string message = "[Steamworks.NET] - Starting steam remote storage FileReadAsync of " + text;
			Debug.Log(message);
			Action<byte[]> onComplete3 = delegate(byte[] bytes)
			{
				StorageOperationCompleteWithData onComplete5 = CS_0024_003C_003E8__locals3.onComplete;
				bool flag = bytes == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			SteamRemoteStorage.FileReadAsync(text, onComplete3);
		}
		else
		{
			StorageOperationCompleteWithData onComplete4 = CS_0024_003C_003E8__locals3.onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v104.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void InitAsync(string containerName, string containerDisplayName, StorageOperationComplete onComplete)
	{
		if (!m_IsReady)
		{
			m_IsReady = true;
		}
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public StorageResult SetBlob(string blobName, byte[] data)
	{
		if (m_IsReady)
		{
			m_LastBlobData = data;
			m_LastBlobFilename = blobName;
			return StorageResult.Successful;
		}
		return StorageResult.StorageNotInitialized;
	}

	public void CommitAsync(StorageOperationComplete onComplete, CommitOptions options = CommitOptions.Default, bool createBackup = false)
	{
		//IL_00ed: Expected I4, but got O
		_003C_003Ec__DisplayClass19_0 obj = new _003C_003Ec__DisplayClass19_0();
		obj.onComplete = onComplete;
		StorageOperationComplete onComplete2;
		StorageResult result;
		string msg;
		if (m_IsReady)
		{
			if (m_LastBlobData != null)
			{
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int num = default(int);
				string text = num.ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				Debug.Log(message);
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass19_0)(object)action)._003CCommitAsync_003Eb__0((byte)(int)obj != 0);
				SteamRemoteStorage.FileWriteAsync(m_LastBlobFilename, m_LastBlobData, action);
				return;
			}
			onComplete2 = obj.onComplete;
			result = StorageResult.NothingToCommit;
			msg = "[Steamworks.NET] - Nothing to commit!";
		}
		else
		{
			onComplete2 = obj.onComplete;
			result = StorageResult.StorageNotInitialized;
			msg = "[Steamworks.NET] - Storage was not successfully initialized yet.";
		}
		FailWithLastError(result, msg, onComplete2);
	}

	public SteamworksCloudStorage()
	{
		//IL_0014: Expected I, but got O
		nint num = (nint)typeof(ErroInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.Platforms.ErroInfo>)+B8]");
		nint num2 = 0;
		m_LastError = ErroInfo.NonError;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (Il2CppStaticFields<VampireSurvivors.Framework.Platforms.ErroInfo>)+10]");
		_ = 0;
	}
}
