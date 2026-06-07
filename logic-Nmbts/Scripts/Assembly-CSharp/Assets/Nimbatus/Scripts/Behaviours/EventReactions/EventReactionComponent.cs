using System;
using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions
{
	[Serializable]
	public abstract class EventReactionComponent
	{
		protected NimbatusBehaviour Behaviour;

		protected EventReaction EventReaction;

		protected InteractiveWorldObject OwnWorldObject;

		public void Init(NimbatusBehaviour behaviour, EventReaction reaction, InteractiveWorldObject worldObject)
		{
			Behaviour = behaviour;
			EventReaction = reaction;
			OwnWorldObject = worldObject;
			OnInit();
		}

		public void Release()
		{
			OnRelease();
		}

		protected virtual void OnInit()
		{
		}

		protected virtual void OnRelease()
		{
		}
	}
}
