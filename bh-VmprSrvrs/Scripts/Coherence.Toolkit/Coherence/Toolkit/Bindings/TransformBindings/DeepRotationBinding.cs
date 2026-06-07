using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings.TransformBindings
{
	[Serializable]
	public class DeepRotationBinding : QuaternionBinding
	{
		public override string BakedSyncScriptGetter => null;

		public override string BakedSyncScriptSetter => null;

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

		protected DeepRotationBinding()
		{
		}

		public DeepRotationBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		internal override (bool, string) IsBindingValid()
		{
			return default((bool, string));
		}
	}
}
