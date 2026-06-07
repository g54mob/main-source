using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class UShortBinding : ValueBinding<ushort>
	{
		public override ushort Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected UShortBinding()
		{
		}

		public UShortBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(ushort first, ushort second)
		{
			return false;
		}
	}
}
