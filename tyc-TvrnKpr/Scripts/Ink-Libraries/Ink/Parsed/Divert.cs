using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class Divert : Object
	{
		public Path target { get; protected set; }

		public Object targetContent { get; protected set; }

		public List<Expression> arguments { get; protected set; }

		public Ink.Runtime.Divert runtimeDivert { get; protected set; }

		public bool isFunctionCall { get; set; }

		public bool isEmpty { get; set; }

		public bool isTunnel { get; set; }

		public bool isThread { get; set; }

		public bool isEnd => false;

		public bool isDone => false;

		public Divert(Path target, List<Expression> arguments = null)
		{
		}

		public Divert(Object targetContent)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public string PathAsVariableName()
		{
			return null;
		}

		private void ResolveTargetContent()
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		private void CheckArgumentValidity()
		{
		}

		private void CheckExternalArgumentValidity(Story context)
		{
		}

		public override void Error(string message, Object source = null, bool isWarning = false)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
