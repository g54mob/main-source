using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class CharBinding : ValueBinding<char>
	{
		public override char Value
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		protected CharBinding()
		{
		}

		public CharBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(char first, char second)
		{
			return false;
		}
	}
}
