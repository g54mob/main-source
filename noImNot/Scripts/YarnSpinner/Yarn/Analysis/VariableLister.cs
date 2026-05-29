using System.Collections.Generic;

namespace Yarn.Analysis
{
	internal class VariableLister : CompiledProgramAnalyser
	{
		private HashSet<string> variables;

		public override void Diagnose(Program program)
		{
		}

		public override IEnumerable<Diagnosis> GatherDiagnoses()
		{
			return null;
		}
	}
}
