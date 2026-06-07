using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions
{
	[Serializable]
	public class EventReaction
	{
		[OdinSerialize]
		protected List<NimbatusEvent> Events = new List<NimbatusEvent>();

		[OdinSerialize]
		protected List<NimbatusCondition> Conditions = new List<NimbatusCondition>();

		[OdinSerialize]
		protected List<NimbatusAction> Actions = new List<NimbatusAction>();

		[NonSerialized]
		[HideInInspector]
		protected internal NimbatusBehaviour Behaviour;

		public void Init(NimbatusBehaviour behaviour, InteractiveWorldObject worldObject)
		{
			Behaviour = behaviour;
			foreach (NimbatusAction action in Actions)
			{
				action.Init(behaviour, this, worldObject);
			}
			foreach (NimbatusCondition condition in Conditions)
			{
				condition.Init(behaviour, this, worldObject);
			}
			foreach (NimbatusEvent @event in Events)
			{
				@event.Init(behaviour, this, worldObject);
			}
		}

		public void Release()
		{
			foreach (NimbatusEvent @event in Events)
			{
				@event.Release();
			}
			foreach (NimbatusCondition condition in Conditions)
			{
				condition.Release();
			}
			foreach (NimbatusAction action in Actions)
			{
				action.Release();
			}
		}

		public void ExecuteEvent()
		{
			foreach (NimbatusCondition condition in Conditions)
			{
				if (!condition.IsTrue())
				{
					return;
				}
			}
			foreach (NimbatusAction action in Actions)
			{
				action.Execute();
			}
		}
	}
}
