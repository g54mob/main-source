using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.StateMachines
{
	[GraphInfo(packageName = "NodeCanvas", docsURL = "https://nodecanvas.paradoxnotion.com/documentation/", resourcesURL = "https://nodecanvas.paradoxnotion.com/downloads/", forumsURL = "https://nodecanvas.paradoxnotion.com/forums-page/")]
	[CreateAssetMenu(menuName = "ParadoxNotion/NodeCanvas/FSM Asset")]
	public class FSM : Graph
	{
		public enum TransitionCallMode
		{
			Normal = 0,
			Stacked = 1,
			Clean = 2
		}

		private List<IUpdatable> updatableNodes;

		private IStateCallbackReceiver[] callbackReceivers;

		private Stack<FSMState> stateStack;

		private bool enterStartStateFlag;

		public FSMState currentState { get; private set; }

		public FSMState previousState { get; private set; }

		public string currentStateName => null;

		public string previousStateName => null;

		public override Type baseNodeType => null;

		public override bool requiresAgent => false;

		public override bool requiresPrimeNode => false;

		public override bool isTree => false;

		public override bool allowBlackboardOverrides => false;

		public sealed override bool canAcceptVariableDrops => false;

		public sealed override PlanarDirection flowDirection => default(PlanarDirection);

		public event Action<IState> onStateEnter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IState> onStateUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IState> onStateExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IState> onStateTransition
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void OnGraphInitialize()
		{
		}

		protected override void OnGraphStarted()
		{
		}

		protected override void OnGraphUpdate()
		{
		}

		protected override void OnGraphStoped()
		{
		}

		public bool EnterState(FSMState newState, TransitionCallMode callMode)
		{
			return false;
		}

		public FSMState TriggerState(string stateName, TransitionCallMode callMode)
		{
			return null;
		}

		public string[] GetStateNames()
		{
			return null;
		}

		public FSMState GetStateWithName(string name)
		{
			return null;
		}

		private void GatherCallbackReceivers()
		{
		}

		public FSMState PeekStack()
		{
			return null;
		}
	}
}
