using System;
using System.Collections.Generic;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public class CancellationTokenEqualityComparer : IEqualityComparer<CancellationToken>
{
	public static readonly IEqualityComparer<CancellationToken> Default;

	public bool Equals(CancellationToken x, CancellationToken y)
	{
		object obj = (object)x - (object)y;
		return obj == null;
	}

	public int GetHashCode(CancellationToken obj)
	{
		//IL_002c: Expected O, but got I
		//IL_003c: Expected O, but got I
		//IL_0054: Expected I4, but got O
		bool flag = (object)obj != null;
		CancellationToken cancellationToken = obj;
		if (!flag)
		{
			cancellationToken = (CancellationToken)CancellationTokenSource.s_neverCanceledSource;
			if (CancellationTokenSource.s_neverCanceledSource == null)
			{
				goto IL_0046;
			}
		}
		CancellationTokenSource source = cancellationToken._source;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v1 (System.Threading.CancellationTokenSource)+158]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v1 (System.Threading.CancellationTokenSource)+160]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ rax_v5 (should have been resolved before IL gen)");
		goto IL_0046;
		IL_0046:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	static CancellationTokenEqualityComparer()
	{
		CancellationTokenEqualityComparer cancellationTokenEqualityComparer = new CancellationTokenEqualityComparer();
		Default = cancellationTokenEqualityComparer;
	}
}
