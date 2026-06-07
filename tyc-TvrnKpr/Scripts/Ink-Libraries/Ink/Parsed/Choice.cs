using Ink.Runtime;

namespace Ink.Parsed
{
	public class Choice : Object, IWeavePoint, INamedContent
	{
		private ChoicePoint _runtimeChoice;

		private Container _innerContentContainer;

		private Container _outerContainer;

		private Container _startContentRuntimeContainer;

		private Ink.Runtime.Divert _divertToStartContentOuter;

		private Ink.Runtime.Divert _divertToStartContentInner;

		private Container _r1Label;

		private Container _r2Label;

		private DivertTargetValue _returnToR1;

		private DivertTargetValue _returnToR2;

		private Expression _condition;

		public ContentList startContent { get; protected set; }

		public ContentList choiceOnlyContent { get; protected set; }

		public ContentList innerContent { get; protected set; }

		public string name { get; set; }

		public Expression condition
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool onceOnly { get; set; }

		public bool isInvisibleDefault { get; set; }

		public int indentationDepth { get; set; }

		public bool hasWeaveStyleInlineBrackets { get; set; }

		public Container runtimeContainer => null;

		public Container innerContentContainer => null;

		public override Container containerForCounting => null;

		public override Ink.Runtime.Path runtimePath => null;

		public Choice(ContentList startContent, ContentList choiceOnlyContent, ContentList innerContent)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
