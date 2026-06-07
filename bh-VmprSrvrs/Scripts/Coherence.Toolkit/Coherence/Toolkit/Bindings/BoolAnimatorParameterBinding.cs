using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	[Serializable]
	public class BoolAnimatorParameterBinding : BoolBinding
	{
		private AnimatorDescriptor castedDescriptor;

		public override string BakedSyncScriptGetter => null;

		public override string BakedSyncScriptSetter => null;

		protected AnimatorDescriptor CastedDescriptor => null;

		public override bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected BoolAnimatorParameterBinding()
		{
		}

		public BoolAnimatorParameterBinding(Descriptor descriptor, Component unityComponent)
		{
		}
	}
}
