using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class ULongBinding : ValueBinding<ulong>
	{
		public override ulong Value
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		protected ULongBinding()
		{
		}

		public ULongBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(ulong first, ulong second)
		{
			return false;
		}
	}
}
