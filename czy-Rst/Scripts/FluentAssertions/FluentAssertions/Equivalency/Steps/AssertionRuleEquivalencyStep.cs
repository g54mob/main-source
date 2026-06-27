using System;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Equivalency.Execution;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class AssertionRuleEquivalencyStep<TSubject> : IEquivalencyStep
	{
		private readonly Func<IObjectInfo, bool> predicate;

		private readonly string description;

		private readonly Action<IAssertionContext<TSubject>> assertionAction;

		private readonly AutoConversionStep converter = new AutoConversionStep();

		public AssertionRuleEquivalencyStep(Expression<Func<IObjectInfo, bool>> predicate, Action<IAssertionContext<TSubject>> assertionAction)
		{
			this.predicate = predicate.Compile();
			this.assertionAction = assertionAction;
			description = predicate.ToString();
		}

		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			bool flag = false;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				if (AppliesTo(comparands, context.CurrentNode))
				{
					flag = ExecuteAssertion(comparands, context);
				}
				bool flag2 = false;
				if (!flag && context.Options.ConversionSelector.RequiresConversion(comparands, context.CurrentNode))
				{
					context = context.Clone();
					converter.Handle(comparands, context, valueChildNodes);
					flag2 = true;
				}
				if (flag2 && AppliesTo(comparands, context.CurrentNode))
				{
					flag = ExecuteAssertion(comparands, context);
					if (flag)
					{
						assertionScope.Discard();
					}
				}
			}
			if (!flag)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private bool AppliesTo(Comparands comparands, INode currentNode)
		{
			return predicate(new ObjectInfo(comparands, currentNode));
		}

		private bool ExecuteAssertion(Comparands comparands, IEquivalencyValidationContext context)
		{
			bool flag = comparands.Subject == null;
			bool flag2 = comparands.Expectation == null;
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			assertionChain.ForCondition(flag || comparands.Subject.GetType().IsSameOrInherits(typeof(TSubject))).FailWith("Expected {0} from subject to be a {1}{reason}, but found a {2}.", context.CurrentNode.Subject.AsNonFormattable(), typeof(TSubject), comparands.Subject?.GetType()).Then.ForCondition(flag2 || comparands.Expectation.GetType().IsSameOrInherits(typeof(TSubject))).FailWith("Expected {0} from expectation to be a {1}{reason}, but found a {2}.", context.CurrentNode.Subject.AsNonFormattable(), typeof(TSubject), comparands.Expectation?.GetType());
			if (assertionChain.Succeeded)
			{
				if ((flag || flag2) && !CanBeNull<TSubject>())
				{
					return false;
				}
				string callerIdentifier = context.CurrentNode.Subject.ToString();
				assertionChain.OverrideCallerIdentifier(() => callerIdentifier);
				assertionChain.ReuseOnce();
				assertionAction(AssertionContext<TSubject>.CreateFrom(comparands, context));
				return true;
			}
			return false;
		}

		private static bool CanBeNull<T>()
		{
			if (typeof(T).IsValueType)
			{
				return (object)Nullable.GetUnderlyingType(typeof(T)) != null;
			}
			return true;
		}

		public override string ToString()
		{
			return "Invoke Action<" + typeof(TSubject).Name + "> when " + description;
		}
	}
}
