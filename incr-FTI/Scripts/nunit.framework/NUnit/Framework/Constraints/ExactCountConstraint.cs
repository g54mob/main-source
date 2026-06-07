using System;
using System.Collections;

namespace NUnit.Framework.Constraints
{
	public class ExactCountConstraint : PrefixConstraint
	{
		private int expectedCount;

		public ExactCountConstraint(int expectedCount, IConstraint itemConstraint)
			: base(itemConstraint)
		{
			this.expectedCount = expectedCount;
			base.DescriptionPrefix = expectedCount switch
			{
				1 => "exactly one item", 
				0 => "no item", 
				_ => $"exactly {expectedCount} items", 
			};
		}

		public override ConstraintResult ApplyTo(object actual)
		{
			if (!(actual is IEnumerable))
			{
				throw new ArgumentException("The actual value must be an IEnumerable", "actual");
			}
			int num = 0;
			foreach (object item in (IEnumerable)actual)
			{
				if (base.BaseConstraint.ApplyTo(item).IsSuccess)
				{
					num++;
				}
			}
			return new ConstraintResult(this, actual, num == expectedCount);
		}
	}
}
