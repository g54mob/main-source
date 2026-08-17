using System;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public interface IUniTaskSource : IValueTaskSource
{
	new UniTaskStatus GetStatus(short token);

	void OnCompleted(Action<object> continuation, object state, short token);

	new void GetResult(short token);

	UniTaskStatus UnsafeGetStatus();

	private virtual ValueTaskSourceStatus System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_002EGetStatus(short token)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
		ValueTaskSourceStatus result = default(ValueTaskSourceStatus);
		return result;
	}

	private virtual void System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_002EGetResult(short token)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
	}

	private virtual void System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_002EOnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D14B0");
	}
}
public interface IUniTaskSource<out T> : IUniTaskSource, IValueTaskSource, IValueTaskSource<T>
{
	new T GetResult(short token);

	new UniTaskStatus GetStatus(short token)
	{
		//IL_0022: Expected I4, but got O
		if (this != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
			UniTaskStatus result = default(UniTaskStatus);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (UniTaskStatus)ex;
	}

	new void OnCompleted(Action<object> continuation, object state, short token)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D14B0");
	}

	private virtual ValueTaskSourceStatus System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_003CT_003E_002EGetStatus(short token)
	{
		//IL_0022: Expected I4, but got O
		if (this != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
			ValueTaskSourceStatus result = default(ValueTaskSourceStatus);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (ValueTaskSourceStatus)ex;
	}

	private virtual T System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_003CT_003E_002EGetResult(short token)
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ r9+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rax_v1+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050B9F0");
		object obj3 = default(object);
		IUniTaskSource<T> uniTaskSource = (IUniTaskSource<T>)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v4+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v4+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v4+30]");
		_ = 0;
		return (T)this;
	}

	private virtual void System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_003CT_003E_002EOnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D14B0");
	}
}
