using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Sentry.Internal
{
	internal static class AotHelper
	{
		private class AotTester
		{
			public void Test()
			{
			}
		}

		internal const string SuppressionJustification = "Non-trimmable code is avoided at runtime";

		internal const bool IsNativeAot = false;

		internal static bool IsTrimmed { get; }

		[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Non-trimmable code is avoided at runtime")]
		static AotHelper()
		{
			IsTrimmed = (object)new StackTrace(fNeedFileInfo: false).GetFrame(0)?.GetMethod() == null;
		}
	}
}
