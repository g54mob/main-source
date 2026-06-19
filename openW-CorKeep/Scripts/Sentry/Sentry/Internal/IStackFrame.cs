using System.Diagnostics;
using System.Reflection;

namespace Sentry.Internal
{
	internal interface IStackFrame
	{
		StackFrame? Frame { get; }

		nint GetNativeImageBase();

		nint GetNativeIP();

		bool HasNativeImage();

		int GetFileColumnNumber();

		int GetFileLineNumber();

		string? GetFileName();

		int GetILOffset();

		MethodBase? GetMethod();

		new string ToString();
	}
}
