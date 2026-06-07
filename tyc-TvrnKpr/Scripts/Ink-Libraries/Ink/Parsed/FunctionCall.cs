using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class FunctionCall : Expression
	{
		public bool shouldPopReturnedValue;

		private Divert _proxyDivert;

		private DivertTarget _divertTargetToCount;

		private VariableReference _variableReferenceToCount;

		public string name => null;

		public List<Expression> arguments => null;

		public Ink.Runtime.Divert runtimeDivert => null;

		public bool isChoiceCount => false;

		public bool isTurns => false;

		public bool isTurnsSince => false;

		public bool isRandom => false;

		public bool isSeedRandom => false;

		public bool isListRange => false;

		public bool isListRandom => false;

		public bool isReadCount => false;

		public FunctionCall(string functionName, List<Expression> arguments)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		public static bool IsBuiltIn(string name)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
