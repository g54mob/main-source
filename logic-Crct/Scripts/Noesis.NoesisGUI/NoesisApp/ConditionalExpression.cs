using System;
using Noesis;

namespace NoesisApp
{
	[ContentProperty("Conditions")]
	public class ConditionalExpression : Animatable, ICondition
	{
		public static readonly DependencyProperty ForwardChainingProperty;

		public static readonly DependencyProperty ConditionsProperty;

		public ForwardChaining ForwardChaining
		{
			get
			{
				return default(ForwardChaining);
			}
			set
			{
			}
		}

		public ConditionCollection Conditions => null;

		bool ICondition.Evaluate()
		{
			return false;
		}

		public ConditionalExpression()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
