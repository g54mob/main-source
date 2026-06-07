using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class StringBinding : ValueBinding<string>
	{
		public override string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected StringBinding()
		{
		}

		public StringBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override bool DiffersFrom(string first, string second)
		{
			return false;
		}
	}
}
