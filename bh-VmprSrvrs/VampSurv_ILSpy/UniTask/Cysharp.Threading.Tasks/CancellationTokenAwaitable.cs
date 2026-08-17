using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public struct CancellationTokenAwaitable(CancellationToken cancellationToken)
{
	public struct Awaiter(CancellationToken cancellationToken) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private CancellationToken cancellationToken = cancellationToken;

		public bool IsCompleted
		{
			get
			{
				//IL_0058: Expected O, but got I
				//IL_006e: Expected O, but got I
				//IL_007e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Expected O, but got Unknown
				if ((nint)this.cancellationToken <= 0)
				{
					return true;
				}
				if ((object)this.cancellationToken == null)
				{
					return false;
				}
				CancellationToken cancellationToken = this.cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v4 (System.Threading.CancellationToken)+20]");
				object obj = -2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v4 (System.Threading.CancellationToken)+20]");
				object obj2 = (nint)0 ^ (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v4 (System.Threading.CancellationToken)+20]");
				object obj3 = 0 ^ obj;
				object obj4 = obj2 & obj3;
				bool flag = (nint)obj4 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}

		public void GetResult()
		{
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, continuation);
		}
	}

	private CancellationToken cancellationToken = cancellationToken;

	public Awaiter GetAwaiter()
	{
		return (Awaiter)cancellationToken;
	}
}
