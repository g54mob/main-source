using System;

namespace XRL.World
{
	public abstract class IEffectExtension<T> : Effect where T : Effect
	{
		public Guid ParentEffectID;

		[NonSerialized]
		public T ParentEffect;

		public override bool WantEvent(int ID, int Cascade)
		{
			if (!base.WantEvent(ID, Cascade))
			{
				return ID == EffectRemovedEvent.ID;
			}
			return true;
		}

		public override bool HandleEvent(EffectRemovedEvent E)
		{
			if (E.Effect == ParentEffect)
			{
				base.Object.RemoveEffect(this);
			}
			return base.HandleEvent(E);
		}

		public override void FinalizeRead(SerializationReader Reader)
		{
			if (!base.Object.TryGetEffect<T>(ParentEffectID, out ParentEffect))
			{
				MetricsManager.LogAssemblyWarning(GetType(), "Lost parent effect reference, removing " + GetType().GetName() + " from " + base.Object.DebugName);
				base.Object.RemoveEffect(this);
			}
		}
	}
}
