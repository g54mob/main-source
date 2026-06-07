using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.States;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours
{
	[Serializable]
	public class NimbatusBehaviour
	{
		[FoldoutGroup("Description", false, 0)]
		[MultiLineProperty(6)]
		public string InternalDescription;

		[OdinSerialize]
		protected List<CoreBehaviour> GlobalCoreBehaviours = new List<CoreBehaviour>();

		[OdinSerialize]
		protected List<EventReaction> GlobalReactions = new List<EventReaction>();

		public bool HasStates;

		[ShowIf("HasStates", true)]
		public EState StartingState;

		[ShowIf("HasStates", true)]
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		[OdinSerialize]
		protected List<BehaviourState> States = new List<BehaviourState>();

		[NonSerialized]
		[HideInInspector]
		public BehaviourState CurrentState;

		private InteractiveWorldObject _ownWorldObject;

		private bool _wasInit;

		public event Action<EState, EState> OnStateChange;

		public void Init(InteractiveWorldObject worldObject)
		{
			_ownWorldObject = worldObject;
			foreach (CoreBehaviour globalCoreBehaviour in GlobalCoreBehaviours)
			{
				globalCoreBehaviour.Init(this, worldObject);
			}
			foreach (EventReaction globalReaction in GlobalReactions)
			{
				globalReaction.Init(this, worldObject);
			}
			_wasInit = true;
			if (HasStates)
			{
				ChangeState(StartingState);
			}
		}

		public bool IsInitialized()
		{
			return _wasInit;
		}

		public T GetCoreBehaviour<T>() where T : CoreBehaviour
		{
			T val = GlobalCoreBehaviours.OfType<T>().FirstOrDefault();
			if (val == null && CurrentState != null)
			{
				val = CurrentState.CoreBehaviours.OfType<T>().FirstOrDefault();
			}
			return val;
		}

		public void ChangeState(EState to)
		{
			EState arg = EState.None;
			if (CurrentState != null)
			{
				if (CurrentState.State == to)
				{
					return;
				}
				CurrentState.Release();
				arg = CurrentState.State;
			}
			CurrentState = States.FirstOrDefault((BehaviourState s) => s.State == to);
			if (CurrentState != null)
			{
				CurrentState.Init(this, _ownWorldObject);
				Action<EState, EState> action = this.OnStateChange;
				if (action != null)
				{
					action(arg, CurrentState.State);
				}
			}
		}

		public void Release()
		{
			if (_wasInit)
			{
				foreach (CoreBehaviour globalCoreBehaviour in GlobalCoreBehaviours)
				{
					globalCoreBehaviour.Release();
				}
				foreach (EventReaction globalReaction in GlobalReactions)
				{
					globalReaction.Release();
				}
				foreach (BehaviourState state in States)
				{
					state.Release();
				}
			}
			_wasInit = false;
		}
	}
}
