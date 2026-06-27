using System.Diagnostics;

namespace FluentAssertions
{
	[DebuggerNonUserCode]
	public class AndConstraint<TParent>
	{
		public TParent And { get; }

		public AndConstraint(TParent parent)
		{
			And = parent;
		}
	}
}
