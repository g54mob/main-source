using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	[Serializable]
	public class IntAnimatorParameterBinding : IntBinding
	{
		private AnimatorDescriptor castedDescriptor;

		public override string BakedSyncScriptGetter => null;

		public override string BakedSyncScriptSetter => null;

		protected AnimatorDescriptor CastedDescriptor => null;

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

		protected IntAnimatorParameterBinding()
		{
		}

		public IntAnimatorParameterBinding(Descriptor descriptor, Component unityComponent)
		{
		}
	}
}
