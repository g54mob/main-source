using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class LongBinding : ValueBinding<long>
	{
		public override long Value
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		protected LongBinding()
		{
		}

		public LongBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(long first, long second)
		{
			return false;
		}
	}
}
