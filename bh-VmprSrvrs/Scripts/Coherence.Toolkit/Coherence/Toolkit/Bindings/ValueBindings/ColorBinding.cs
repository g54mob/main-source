using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class ColorBinding : ValueBinding<Color>
	{
		public override Color Value
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		protected ColorBinding()
		{
		}

		public ColorBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(Color first, Color second)
		{
			return false;
		}

		protected override Color GetCompressedValue(Color value)
		{
			return default(Color);
		}
	}
}
