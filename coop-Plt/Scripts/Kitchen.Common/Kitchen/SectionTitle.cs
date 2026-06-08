using System.Runtime.InteropServices;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SectionTitle
	{
		public const string Configuration = "Configuration";

		public const string References = "References";

		public const string State = "State";
	}
}
