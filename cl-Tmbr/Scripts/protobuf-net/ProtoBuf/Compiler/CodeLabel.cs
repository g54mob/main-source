using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace ProtoBuf.Compiler
{
	[StructLayout(LayoutKind.Auto)]
	internal readonly struct CodeLabel
	{
		public readonly Label Value;

		public readonly int Index;

		public CodeLabel(Label value, int index)
		{
			Value = value;
			Index = index;
		}
	}
}
