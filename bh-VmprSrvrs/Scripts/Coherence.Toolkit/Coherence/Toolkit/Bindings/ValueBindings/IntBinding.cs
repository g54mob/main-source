using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class IntBinding : ValueBinding<int>
	{
		public override int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected IntBinding()
		{
		}

		public IntBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override int ClampToRange(in int value, long minRange, long maxRange)
		{
			return 0;
		}

		protected override bool DiffersFrom(int first, int second)
		{
			return false;
		}
	}
}
