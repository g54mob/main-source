using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.States
{
	[Serializable]
	public class BehaviourState
	{
		public EState State = EState.Idle;

		[OdinSerialize]
		protected internal List<CoreBehaviour> CoreBehaviours = new List<CoreBehaviour>();

		[OdinSerialize]
		protected List<EventReaction> EventReactions = new List<EventReaction>();

		[NonSerialized]
		[HideInInspector]
		protected internal NimbatusBehaviour Behaviour;

		private bool _wasInit;

		public void Init(NimbatusBehaviour behaviour, InteractiveWorldObject worldObject)
		{
			Behaviour = behaviour;
			foreach (CoreBehaviour coreBehaviour in CoreBehaviours)
			{
				coreBehaviour.Init(behaviour, worldObject);
			}
			foreach (EventReaction eventReaction in EventReactions)
			{
				eventReaction.Init(behaviour, worldObject);
			}
			_wasInit = true;
		}

		public void Release()
		{
			if (!_wasInit)
			{
				return;
			}
			foreach (CoreBehaviour coreBehaviour in CoreBehaviours)
			{
				coreBehaviour.Release();
			}
			foreach (EventReaction eventReaction in EventReactions)
			{
				eventReaction.Release();
			}
			_wasInit = false;
		}
	}
}
