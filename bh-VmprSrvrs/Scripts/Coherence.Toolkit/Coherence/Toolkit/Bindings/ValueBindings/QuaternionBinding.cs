using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class QuaternionBinding : ValueBinding<Quaternion>
	{
		public override Quaternion Value
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		protected QuaternionBinding()
		{
		}

		public QuaternionBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(Quaternion first, Quaternion second)
		{
			return false;
		}

		protected override Quaternion GetCompressedValue(Quaternion value)
		{
			return default(Quaternion);
		}
	}
}
