using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

[StructLayout((LayoutKind)0, Size = 1)]
public struct AsyncUnit : IEquatable<AsyncUnit>
{
	public static readonly AsyncUnit Default;

	public override int GetHashCode()
	{
		return 0;
	}

	public bool Equals(AsyncUnit other)
	{
		return true;
	}

	public override string ToString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992D95]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "()";
	}
}
