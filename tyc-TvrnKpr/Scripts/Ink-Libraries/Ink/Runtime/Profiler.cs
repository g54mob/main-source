using System.Collections.Generic;
using System.Diagnostics;

namespace Ink.Runtime
{
	public class Profiler
	{
		private struct StepDetails
		{
			public string type;

			public Object obj;

			public double time;
		}

		private Stopwatch _continueWatch;

		private Stopwatch _stepWatch;

		private Stopwatch _snapWatch;

		private double _continueTotal;

		private double _snapTotal;

		private double _stepTotal;

		private string[] _currStepStack;

		private StepDetails _currStepDetails;

		private ProfileNode _rootNode;

		private int _numContinues;

		private List<StepDetails> _stepDetails;

		private static double _millisecsPerTick;

		public ProfileNode rootNode => null;

		public string Report()
		{
			return null;
		}

		public void PreContinue()
		{
		}

		public void PostContinue()
		{
		}

		public void PreStep()
		{
		}

		public void Step(CallStack callstack)
		{
		}

		public void PostStep()
		{
		}

		public string StepLengthReport()
		{
			return null;
		}

		public string Megalog()
		{
			return null;
		}

		public void PreSnapshot()
		{
		}

		public void PostSnapshot()
		{
		}

		private double Millisecs(Stopwatch watch)
		{
			return 0.0;
		}

		public static string FormatMillisecs(double num)
		{
			return null;
		}
	}
}
