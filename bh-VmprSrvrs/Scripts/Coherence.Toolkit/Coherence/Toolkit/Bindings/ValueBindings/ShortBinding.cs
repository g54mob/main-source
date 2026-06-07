using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class ShortBinding : ValueBinding<short>
	{
		public override short Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected ShortBinding()
		{
		}

		public ShortBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(short first, short second)
		{
			return false;
		}
	}
}
