using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal static class Error
{
	[MethodImpl((MethodImplOptions)256)]
	public static void ThrowArgumentNullException<T>(T value, string paramName) where T : class
	{
		if (value == null)
		{
			ThrowArgumentNullExceptionCore(paramName);
		}
	}

	[MethodImpl((MethodImplOptions)8)]
	private static void ThrowArgumentNullExceptionCore(string paramName)
	{
		ArgumentNullException ex = new ArgumentNullException(paramName);
		throw ex;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Exception ArgumentOutOfRange(string paramName)
	{
		//IL_005d: Expected I4, but got I8
		ArgumentOutOfRangeException ex = (ArgumentOutOfRangeException)new ArgumentException("Specified argument was out of the range of valid values.", paramName);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2D7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((Exception)ex)._HResult = -2146233086;
		return ex;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Exception NoElements()
	{
		//IL_0026: Expected I4, but got I8
		InvalidOperationException ex = (InvalidOperationException)new SystemException("Source sequence doesn't contain any elements.");
		((Exception)ex)._HResult = -2146233079;
		return ex;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Exception MoreThanOneElement()
	{
		//IL_0026: Expected I4, but got I8
		InvalidOperationException ex = (InvalidOperationException)new SystemException("Source sequence contains more than one element.");
		((Exception)ex)._HResult = -2146233079;
		return ex;
	}

	[MethodImpl((MethodImplOptions)8)]
	public static void ThrowArgumentException(string message)
	{
		object obj = new ArgumentException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
		throw obj;
	}

	[MethodImpl((MethodImplOptions)8)]
	public static void ThrowNotYetCompleted()
	{
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	[MethodImpl((MethodImplOptions)8)]
	public static T ThrowNotYetCompleted<T>()
	{
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static void ThrowWhenContinuationIsAlreadyRegistered<T>(T continuationField) where T : class
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899839CE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (continuationField != null)
		{
			ThrowInvalidOperationExceptionCore("continuation is already registered.");
		}
	}

	[MethodImpl((MethodImplOptions)8)]
	private static void ThrowInvalidOperationExceptionCore(string message)
	{
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	[MethodImpl((MethodImplOptions)8)]
	public static void ThrowOperationCanceledException()
	{
		OperationCanceledException ex = new OperationCanceledException();
		throw ex;
	}
}
