using System;

namespace Castle.Core.Internal
{
	internal sealed class WeakKey : WeakReference
	{
		private readonly int hashCode;

		public override object Target
		{
			get
			{
				return base.Target;
			}
			set
			{
				throw new NotSupportedException("Dictionary keys are read-only.");
			}
		}

		public WeakKey(object target, int hashCode)
			: base(target)
		{
			this.hashCode = hashCode;
		}

		public override int GetHashCode()
		{
			return hashCode;
		}

		public override bool Equals(object other)
		{
			return WeakKeyComparer<object>.Default.Equals(this, other);
		}
	}
}
