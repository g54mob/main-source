using Cpp2ILInjected;

namespace Doozy.Engine;

public static class MessageExtensions
{
	public static void Send<T>(T self) where T : Message
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Message.Send(self);
	}
}
