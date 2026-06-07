using System.Collections.Generic;
using CLanguage.Syntax;

namespace CLanguage.Compiler
{
	public class CompilerOptions
	{
		public readonly MachineInfo MachineInfo;

		public readonly Report Report;

		public readonly Document[] Documents;

		public CompilerOptions(MachineInfo machineInfo, Report report, IEnumerable<Document> documents)
		{
		}

		public CompilerOptions(MachineInfo machineInfo)
		{
		}

		public CompilerOptions()
		{
		}
	}
}
