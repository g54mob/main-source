using System;
using Coherence.Entities;
using Coherence.SimulationFrame;
using Coherence.Toolkit.Bindings.ValueBindings;
using UnityEngine;

namespace Coherence.Toolkit.Bindings.TransformBindings
{
	[Serializable]
	public class PositionBinding : Vector3Binding
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

		protected PositionBinding()
		{
		}

		public PositionBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		protected override (Vector3, AbsoluteSimulationFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			return default((Vector3, AbsoluteSimulationFrame));
		}

		public void ShiftSamples(Vector3 delta)
		{
		}

		public void TransformSamples(Matrix4x4 transform, bool transformLastSampleToo)
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
