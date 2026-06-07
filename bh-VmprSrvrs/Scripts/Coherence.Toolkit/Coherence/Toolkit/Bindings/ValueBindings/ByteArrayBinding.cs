using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class ByteArrayBinding : ValueBinding<byte[]>
	{
		public override byte[] Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected ByteArrayBinding()
		{
		}

		public ByteArrayBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(byte[] first, byte[] second)
		{
			return false;
		}
	}
}
