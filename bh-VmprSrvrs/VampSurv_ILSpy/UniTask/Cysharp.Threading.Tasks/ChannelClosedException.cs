using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public class ChannelClosedException : InvalidOperationException
{
	public ChannelClosedException()
	{
		//IL_004d: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992DB0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((SystemException)this)._002Ector("Channel is already closed.");
		((Exception)this)._HResult = -2146233079;
	}

	public ChannelClosedException(string message)
	{
		//IL_0019: Expected I4, but got I8
		((SystemException)this)._002Ector(message);
		((Exception)this)._HResult = -2146233079;
	}

	public ChannelClosedException(Exception innerException)
	{
		//IL_0051: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992DB1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((SystemException)this)._002Ector("Channel is already closed", innerException);
		((Exception)this)._HResult = -2146233079;
	}

	public ChannelClosedException(string message, Exception innerException)
	{
		//IL_001d: Expected I4, but got I8
		((SystemException)this)._002Ector(message, innerException);
		((Exception)this)._HResult = -2146233079;
	}
}
