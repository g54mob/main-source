using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public static class Channel
{
	public static Channel<T> CreateSingleConsumerUnbounded<T>()
	{
		Channel<T> result = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ r8_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		return result;
	}
}
public abstract class Channel<TWrite, TRead>
{
	private ChannelReader<TRead> _003CReader_003Ek__BackingField;

	private ChannelWriter<TWrite> _003CWriter_003Ek__BackingField;

	public ChannelReader<TRead> Reader
	{
		get
		{
			return _003CReader_003Ek__BackingField;
		}
		protected set
		{
			_003CReader_003Ek__BackingField = value;
		}
	}

	public ChannelWriter<TWrite> Writer
	{
		get
		{
			return _003CWriter_003Ek__BackingField;
		}
		protected set
		{
			_003CWriter_003Ek__BackingField = value;
		}
	}

	public static implicit operator ChannelReader<TRead>(Channel<TWrite, TRead> channel)
	{
		//IL_0038: Expected O, but got I
		//IL_005b: Expected O, but got I
		if (channel != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Channel`2>)+18]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.Channel`2>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v44 @ rsi_v1 (should have been resolved before IL gen)");
		}
		return (ChannelReader<TRead>)(object)new NullReferenceException();
	}

	public static implicit operator ChannelWriter<TWrite>(Channel<TWrite, TRead> channel)
	{
		//IL_0038: Expected O, but got I
		//IL_005b: Expected O, but got I
		if (channel != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Channel`2>)+20]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.Channel`2>)+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v44 @ rsi_v1 (should have been resolved before IL gen)");
		}
		return (ChannelWriter<TWrite>)(object)new NullReferenceException();
	}
}
public abstract class Channel<T> : Channel<T, T>
{
	protected Channel()
	{
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.Channel`1>>)] (should have been resolved before IL gen)");
	}
}
