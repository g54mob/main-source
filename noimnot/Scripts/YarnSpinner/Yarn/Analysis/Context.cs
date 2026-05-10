using System;
using System.Collections.Generic;

namespace Yarn.Analysis
{
	public class Context
	{
		private IEnumerable<Type> _defaultAnalyserClasses;

		private List<CompiledProgramAnalyser> analysers;

		internal IEnumerable<Type> defaultAnalyserClasses => null;

		public Context()
		{
		}

		public Context(params Type[] types)
		{
		}

		internal void AddProgramToAnalysis(Program program)
		{
		}

		public IEnumerable<Diagnosis> FinishAnalysis()
		{
			return null;
		}
	}
}
