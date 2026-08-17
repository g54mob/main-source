using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks;

public static class UniTaskStatusExtensions
{
	[MethodImpl((MethodImplOptions)256)]
	public static bool IsCompleted(UniTaskStatus status)
	{
		bool flag = status == UniTaskStatus.Pending;
		return !flag;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool IsCompletedSuccessfully(UniTaskStatus status)
	{
		//IL_000e: Expected O, but got I4
		object obj = status - 1;
		return obj == null;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool IsCanceled(UniTaskStatus status)
	{
		//IL_000e: Expected O, but got I4
		object obj = status - 3;
		return obj == null;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool IsFaulted(UniTaskStatus status)
	{
		//IL_000e: Expected O, but got I4
		object obj = status - 2;
		return obj == null;
	}
}
