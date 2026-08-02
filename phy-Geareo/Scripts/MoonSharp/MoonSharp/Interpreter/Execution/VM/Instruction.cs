using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.Interpreter.Execution.VM
{
	internal class Instruction
	{
		internal OpCode OpCode;

		internal SymbolRef Symbol;

		internal SymbolRef[] SymbolList;

		internal string Name;

		internal DynValue Value;

		internal int NumVal;

		internal int NumVal2;

		internal SourceRef SourceCodeRef;

		internal Instruction(SourceRef sourceref)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private string PurifyFromNewLines(DynValue Value)
		{
			return null;
		}

		private string GenSpaces()
		{
			return null;
		}

		internal void WriteBinary(BinaryWriter wr, int baseAddress, Dictionary<SymbolRef, int> symbolMap)
		{
		}

		private static void WriteSymbol(BinaryWriter wr, SymbolRef symbolRef, Dictionary<SymbolRef, int> symbolMap)
		{
		}

		private static SymbolRef ReadSymbol(BinaryReader rd, SymbolRef[] deserializedSymbols)
		{
			return null;
		}

		internal static Instruction ReadBinary(SourceRef chunkRef, BinaryReader rd, int baseAddress, Table envTable, SymbolRef[] deserializedSymbols)
		{
			return null;
		}

		private static DynValue ReadValue(BinaryReader rd, Table envTable)
		{
			return null;
		}

		private void DumpValue(BinaryWriter wr, DynValue value)
		{
		}

		internal void GetSymbolReferences(out SymbolRef[] symbolList, out SymbolRef symbol)
		{
			symbolList = null;
			symbol = null;
		}
	}
}
