using System.Collections.Generic;

namespace Yarn.Analysis
{
	internal class UnusedVariableChecker : CompiledProgramAnalyser
	{
		private HashSet<string> readVariables;

		private HashSet<string> writtenVariables;

		public override void Diagnose(Program program)
		{
		}

		public override IEnumerable<Diagnosis> GatherDiagnoses()
		{
			return null;
		}
	}
}
