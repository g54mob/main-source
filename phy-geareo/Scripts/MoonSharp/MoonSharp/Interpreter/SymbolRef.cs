using System.Collections.Generic;
using System.IO;

namespace MoonSharp.Interpreter
{
	public class SymbolRef
	{
		private static SymbolRef s_DefaultEnv;

		internal SymbolRefType i_Type;

		internal SymbolRef i_Env;

		internal int i_Index;

		internal string i_Name;

		public SymbolRefType Type => default(SymbolRefType);

		public int Index => 0;

		public string Name => null;

		public SymbolRef Environment => null;

		public static SymbolRef DefaultEnv => null;

		public static SymbolRef Global(string name, SymbolRef envSymbol)
		{
			return null;
		}

		internal static SymbolRef Local(string name, int index)
		{
			return null;
		}

		internal static SymbolRef Upvalue(string name, int index)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		internal void WriteBinary(BinaryWriter bw)
		{
		}

		internal static SymbolRef ReadBinary(BinaryReader br)
		{
			return null;
		}

		internal void WriteBinaryEnv(BinaryWriter bw, Dictionary<SymbolRef, int> symbolMap)
		{
		}

		internal void ReadBinaryEnv(BinaryReader br, SymbolRef[] symbolRefs)
		{
		}
	}
}
