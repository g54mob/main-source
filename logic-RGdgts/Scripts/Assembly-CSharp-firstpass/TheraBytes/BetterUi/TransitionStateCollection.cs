using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	public abstract class TransitionStateCollection<T> : TransitionStateCollection
	{
		[Serializable]
		public abstract class TransitionState : TransitionStateBase
		{
			public T StateObject;

			public TransitionState(string name, T stateObject)
				: base(null)
			{
			}
		}

		protected TransitionStateCollection(string[] stateNames)
		{
		}

		public IEnumerable<TransitionState> GetStates()
		{
			return null;
		}

		public override void Apply(string stateName, bool instant)
		{
		}

		protected abstract IEnumerable<TransitionState> GetTransitionStates();

		protected abstract void ApplyState(TransitionState state, bool instant);

		internal abstract void AddStateObject(string stateName);
	}
	[Serializable]
	public abstract class TransitionStateCollection
	{
		[Serializable]
		public abstract class TransitionStateBase
		{
			public string Name;

			public TransitionStateBase(string name)
			{
			}
		}

		public abstract UnityEngine.Object Target { get; }

		public abstract void Apply(string stateName, bool instant);

		internal abstract void SortStates(string[] sortedOrder);

		protected void SortStatesLogic<T>(List<T> states, string[] sortedOrder) where T : TransitionStateBase
		{
		}
	}
}
