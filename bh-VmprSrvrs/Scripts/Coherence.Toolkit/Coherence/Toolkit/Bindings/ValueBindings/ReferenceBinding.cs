using Coherence.Entities;
using UnityEngine;

namespace Coherence.Toolkit.Bindings.ValueBindings
{
	public class ReferenceBinding : ValueBinding<Entity>
	{
		public override Entity Value
		{
			get
			{
				return default(Entity);
			}
			set
			{
			}
		}

		protected ReferenceBinding()
		{
		}

		public ReferenceBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		public override void InvokeValueSyncCallback()
		{
		}

		private Entity MapToEntityId(object target)
		{
			return default(Entity);
		}

		private object MapToUnityObject(Entity entityID)
		{
			return null;
		}

		protected override bool DiffersFrom(Entity first, Entity second)
		{
			return false;
		}
	}
}
