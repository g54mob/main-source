using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms;

public class DummyStorage : IPlatformSaveUtils, ILastErrorProvider, IPlatformSaveBackup
{
	private readonly ErroInfo _003CLastError_003Ek__BackingField;

	private bool _003CContinuePlayingWithoutSaving_003Ek__BackingField = true;

	public unsafe ErroInfo LastError
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected O, but got I
			//IL_001f: Expected native int or pointer, but got O
			ErroInfo erroInfo = default(ErroInfo);
			((ErroInfo*)(nint)erroInfo)->NativeErrorCode = (int)_003CLastError_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Framework.Platforms.DummyStorage)+20]");
			System.Runtime.CompilerServices.Unsafe.Write(&((ErroInfo*)(nint)erroInfo)->Message, (string)0);
			return erroInfo;
		}
	}

	public bool IsReady => true;

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

	public void InitAsync(string containerName, string containerDisplayName, StorageOperationComplete onComplete)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public StorageResult SetBlob(string blobName, byte[] data)
	{
		return StorageResult.Successful;
	}

	public void CommitAsync(StorageOperationComplete onComplete, CommitOptions options = CommitOptions.Default, bool createBackup = false)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void EraseAllAsync(StorageOperationComplete onComplete)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Close()
	{
	}

	public void TryRestoreBlobAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public bool BackupExists(string blobName)
	{
		return false;
	}
}
