using Trivial.Mono.CompilerServices.SymbolWriter;

namespace Trivial.Mono.Cecil.Mdb
{
	internal static class MethodEntryExtensions
	{
		public static bool HasColumnInfo(this MethodEntry entry)
		{
			return (entry.MethodFlags & MethodEntry.Flags.ColumnsInfoIncluded) != 0;
		}

		public static bool HasEndInfo(this MethodEntry entry)
		{
			return (entry.MethodFlags & MethodEntry.Flags.EndInfoIncluded) != 0;
		}
	}
}
