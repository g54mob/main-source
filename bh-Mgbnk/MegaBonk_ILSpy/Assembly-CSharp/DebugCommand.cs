using System;
using Cpp2ILInjected;

public class DebugCommand : DebugCommandBase
{
	private Action command;

	public DebugCommand(string id, string description, string format, Type commandType, Action command)
	{
		base._003CcommandId_003Ek__BackingField = id;
		base._003CcommandDescription_003Ek__BackingField = description;
		base._003CcommandFormat_003Ek__BackingField = format;
		Type type = default(Type);
		base.commandType = type;
		Action action = default(Action);
		this.command = action;
	}

	public void Invoke()
	{
		Action action = command;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}
}
public class DebugCommand<T> : DebugCommandBase
{
	private Action<T> command;

	public DebugCommand(string id, string description, string format, Type commandType, Action<T> command)
	{
		Type type = default(Type);
		base._002Ector(id, description, format, type);
	}

	public void Invoke(T value)
	{
		//IL_0010: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DebugCommand`1<T>)+30]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1+18] (should have been resolved before IL gen)");
	}
}
