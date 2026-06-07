using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class UIntBinding : ValueBinding<uint>
	{
		public override uint Value
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		protected UIntBinding()
		{
		}

		public UIntBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override uint ClampToRange(in uint value, long minRange, long maxRange)
		{
			return 0u;
		}

		protected override bool DiffersFrom(uint first, uint second)
		{
			return false;
		}
	}
}
