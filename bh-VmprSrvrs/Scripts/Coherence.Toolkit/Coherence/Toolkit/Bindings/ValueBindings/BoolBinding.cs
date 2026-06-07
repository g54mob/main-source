using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class BoolBinding : ValueBinding<bool>
	{
		public override bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected BoolBinding()
		{
		}

		public BoolBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(bool first, bool second)
		{
			return false;
		}
	}
}
