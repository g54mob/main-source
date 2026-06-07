using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class ByteBinding : ValueBinding<byte>
	{
		public override byte Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected ByteBinding()
		{
		}

		public ByteBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(byte first, byte second)
		{
			return false;
		}
	}
}
