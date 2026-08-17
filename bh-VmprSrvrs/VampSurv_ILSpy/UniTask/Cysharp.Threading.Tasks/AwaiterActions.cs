using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

internal static class AwaiterActions
{
	internal static readonly Action<object> InvokeContinuationDelegate;

	[MethodImpl((MethodImplOptions)256)]
	private static void Continuation(object state)
	{
		bool flag = (object)state.GetType() != typeof(Action);
		object obj = null;
		if (!flag)
		{
			obj = state;
		}
		if (obj != null)
		{
			bool flag2 = (object)state.GetType() != typeof(Action);
			object obj2 = null;
			if (!flag2)
			{
				obj2 = state;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v94 @ r8_v3 (System.Object)+18] (should have been resolved before IL gen)");
			return;
		}
		throw new InvalidCastException();
	}

	static AwaiterActions()
	{
		Action<object> invokeContinuationDelegate = Continuation;
		InvokeContinuationDelegate = invokeContinuationDelegate;
	}
}
