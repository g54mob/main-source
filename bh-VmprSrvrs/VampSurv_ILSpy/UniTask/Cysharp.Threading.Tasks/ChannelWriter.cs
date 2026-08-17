using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public abstract class ChannelWriter<T>
{
	public abstract bool TryWrite(T item);

	public abstract bool TryComplete(Exception error = null);

	public void Complete(Exception error = null)
	{
		//IL_0005: Expected I, but got O
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4 @ r8_v1 (Il2CppClass<Cysharp.Threading.Tasks.ChannelWriter`1<T>>)+188] (should have been resolved before IL gen)");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		ChannelClosedException ex = new ChannelClosedException();
		throw ex;
	}
}
