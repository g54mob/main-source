using System;
using System.Collections;

namespace NUnit.Framework.Constraints
{
	public abstract class CollectionConstraint : Constraint
	{
		protected CollectionConstraint()
		{
		}

		protected CollectionConstraint(object arg)
			: base(arg)
		{
		}

		protected static bool IsEmpty(IEnumerable enumerable)
		{
			if (enumerable is ICollection collection)
			{
				return collection.Count == 0;
			}
			IEnumerator enumerator = enumerable.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					return false;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return true;
		}

		public override ConstraintResult ApplyTo(object actual)
		{
			if (!(actual is IEnumerable collection))
			{
				throw new ArgumentException("The actual value must be an IEnumerable", "actual");
			}
			return new ConstraintResult(this, actual, Matches(collection));
		}

		protected abstract bool Matches(IEnumerable collection);
	}
}
