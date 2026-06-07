using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding.Examples
{
	[RequireComponent(typeof(SingleNodeBlocker))]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_turn_based_door.php")]
	[RequireComponent(typeof(Animator))]
	public class TurnBasedDoor : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndClose_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TurnBasedDoor _003C_003E4__this;

			private List<SingleNodeBlocker> _003Cselector_003E5__2;

			private GraphNode _003Cnode_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndClose_003Ed__6(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private Animator animator;

		private SingleNodeBlocker blocker;

		private bool open;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Close()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndClose_003Ed__6))]
		private IEnumerator WaitAndClose()
		{
			return null;
		}

		public void Open()
		{
		}

		public void Toggle()
		{
		}
	}
}
