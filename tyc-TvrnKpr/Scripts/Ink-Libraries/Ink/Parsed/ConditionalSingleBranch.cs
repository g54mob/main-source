using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class ConditionalSingleBranch : Object
	{
		private Container _contentContainer;

		private Ink.Runtime.Divert _conditionalDivert;

		private Expression _ownExpression;

		private Weave _innerWeave;

		public bool isTrueBranch { get; set; }

		public Expression ownExpression
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool matchingEquality { get; set; }

		public bool isElse { get; set; }

		public bool isInline { get; set; }

		public Ink.Runtime.Divert returnDivert { get; protected set; }

		public ConditionalSingleBranch(List<Object> content)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		private Container GenerateRuntimeForContent()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
