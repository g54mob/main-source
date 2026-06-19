using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Sentry.Internal
{
	internal class RealStackFrame : IStackFrame
	{
		private readonly StackFrame _frame;

		public StackFrame? Frame => _frame;

		public RealStackFrame(StackFrame frame)
		{
			_frame = frame;
		}

		public override string ToString()
		{
			return _frame.ToString();
		}

		public int GetFileColumnNumber()
		{
			return _frame.GetFileColumnNumber();
		}

		public int GetFileLineNumber()
		{
			return _frame.GetFileLineNumber();
		}

		public string? GetFileName()
		{
			return _frame.GetFileName();
		}

		public int GetILOffset()
		{
			return _frame.GetILOffset();
		}

		[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Non-trimmable code is avoided at runtime")]
		public MethodBase? GetMethod()
		{
			return _frame.GetMethod();
		}

		public nint GetNativeImageBase()
		{
			return 0;
		}

		public nint GetNativeIP()
		{
			return 0;
		}

		public bool HasNativeImage()
		{
			return false;
		}
	}
}
