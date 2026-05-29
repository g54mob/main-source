using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Photon.Pun.UtilityScripts
{
	public class OnClickDestroy : MonoBehaviourPun, IPointerClickHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003CDestroyRpc_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OnClickDestroy _003C_003E4__this;

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
			public _003CDestroyRpc_003Ed__4(int _003C_003E1__state)
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

		public PointerEventData.InputButton Button;

		public KeyCode ModifierKey;

		public bool DestroyByRpc;

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CDestroyRpc_003Ed__4))]
		public IEnumerator DestroyRpc()
		{
			return null;
		}
	}
}
