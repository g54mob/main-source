using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Execution;
using FluentAssertions.Formatting;

namespace FluentAssertions
{
	public class AndWhichConstraint<TParent, TSubject> : AndConstraint<TParent>
	{
		private readonly AssertionChain assertionChain;

		private readonly string pathPostfix;

		private readonly Lazy<TSubject> getSubject;

		public TSubject Subject => Which;

		public TSubject Which
		{
			get
			{
				string text = pathPostfix;
				if (text != null && !(text == ""))
				{
					assertionChain.WithCallerPostfix(pathPostfix).ReuseOnce();
				}
				else
				{
					assertionChain?.AdvanceToNextIdentifier();
					assertionChain?.ReuseOnce();
				}
				return getSubject.Value;
			}
		}

		public AndWhichConstraint(TParent parent, TSubject subject)
			: base(parent)
		{
			getSubject = new Lazy<TSubject>(() => subject);
		}

		public AndWhichConstraint(TParent parent, TSubject subject, AssertionChain assertionChain, string pathPostfix = "")
			: base(parent)
		{
			getSubject = new Lazy<TSubject>(() => subject);
			this.assertionChain = assertionChain;
			this.pathPostfix = pathPostfix;
		}

		public AndWhichConstraint(TParent parent, IEnumerable<TSubject> subjects)
			: base(parent)
		{
			getSubject = new Lazy<TSubject>(() => Single(subjects));
		}

		public AndWhichConstraint(TParent parent, IEnumerable<TSubject> subjects, AssertionChain assertionChain)
			: base(parent)
		{
			getSubject = new Lazy<TSubject>(() => Single(subjects));
			this.assertionChain = assertionChain;
		}

		public AndWhichConstraint(TParent parent, IEnumerable<TSubject> subjects, AssertionChain assertionChain, string pathPostfix)
			: base(parent)
		{
			getSubject = new Lazy<TSubject>(() => Single(subjects));
			this.assertionChain = assertionChain;
			this.pathPostfix = pathPostfix;
		}

		private static TSubject Single(IEnumerable<TSubject> subjects)
		{
			TSubject[] array = subjects.ToArray();
			if (array.Length > 1)
			{
				string text = string.Join(Environment.NewLine, array.Select((TSubject ele) => "\t" + Formatter.ToString(ele)));
				string message = "More than one object found.  FluentAssertions cannot determine which object is meant.  Found objects:" + Environment.NewLine + text;
				AssertionEngine.TestFramework.Throw(message);
			}
			return array.Single();
		}
	}
}
