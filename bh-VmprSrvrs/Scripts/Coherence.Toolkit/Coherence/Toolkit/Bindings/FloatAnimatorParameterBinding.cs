using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	[Serializable]
	public class FloatAnimatorParameterBinding : FloatBinding
	{
		private AnimatorDescriptor castedDescriptor;

		public override string BakedSyncScriptGetter => null;

		public override string BakedSyncScriptSetter => null;

		protected AnimatorDescriptor CastedDescriptor => null;

		public override float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected FloatAnimatorParameterBinding()
		{
		}

		public FloatAnimatorParameterBinding(Descriptor descriptor, Component unityComponent)
		{
		}
	}
}
