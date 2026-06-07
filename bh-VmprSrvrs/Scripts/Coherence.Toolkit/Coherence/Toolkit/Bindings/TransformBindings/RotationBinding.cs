using System;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings.TransformBindings
{
	[Serializable]
	public class RotationBinding : QuaternionBinding
	{
		public override string CoherenceComponentName => null;

		public override string MemberNameInComponentData => null;

		public override string MemberNameInUnityComponent => null;

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

		protected RotationBinding()
		{
		}

		public RotationBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		public void RotateSamples(Quaternion delta, bool transformLastSampleToo)
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
