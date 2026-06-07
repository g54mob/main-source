using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class DoubleBinding : ValueBinding<double>
	{
		public override double Value
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		protected DoubleBinding()
		{
		}

		public DoubleBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(double first, double second)
		{
			return false;
		}

		protected override double GetCompressedValue(double value)
		{
			return 0.0;
		}
	}
}
