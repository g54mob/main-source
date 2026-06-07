using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings.TransformBindings
{
	[Serializable]
	public class ScaleBinding : Vector3Binding
	{
		public override string CoherenceComponentName => null;

		public override string MemberNameInComponentData => null;

		public override string MemberNameInUnityComponent => null;

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

		protected ScaleBinding()
		{
		}

		public ScaleBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		public override void OnConnectedEntityChanged()
		{
		}

		internal override (bool, string) IsBindingValid()
		{
			return default((bool, string));
		}
	}
}
