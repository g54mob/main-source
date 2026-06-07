using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings.TransformBindings
{
	[Serializable]
	public class DeepPositionBinding : Vector3Binding
	{
		public override string BakedSyncScriptGetter => null;

		public override string BakedSyncScriptSetter => null;

		public override Vector3 Value
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		protected DeepPositionBinding()
		{
		}

		public DeepPositionBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		internal override (bool, string) IsBindingValid()
		{
			return default((bool, string));
		}
	}
}
