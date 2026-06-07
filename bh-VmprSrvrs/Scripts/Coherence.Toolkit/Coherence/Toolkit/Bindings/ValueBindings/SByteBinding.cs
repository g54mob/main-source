using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class SByteBinding : ValueBinding<sbyte>
	{
		public override sbyte Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected SByteBinding()
		{
		}

		public SByteBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(sbyte first, sbyte second)
		{
			return false;
		}
	}
}
