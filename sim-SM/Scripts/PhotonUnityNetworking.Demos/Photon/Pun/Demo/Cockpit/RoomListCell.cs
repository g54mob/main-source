using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class RoomListCell : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateAddition_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RoomListCell _003C_003E4__this;

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
			public _003CAnimateAddition_003Ed__11(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CAnimateRemove_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RoomListCell _003C_003E4__this;

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
			public _003CAnimateRemove_003Ed__12(int _003C_003E1__state)
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

		public RoomListView ListManager;

		public Text RoomNameText;

		public Text PlayerCountText;

		public Text OpenText;

		public CanvasGroup JoinButtonCanvasGroup;

		public LayoutElement LayoutElement;

		public RoomInfo info;

		public void RefreshInfo(RoomInfo info)
		{
		}

		public void OnJoinRoomButtonClick()
		{
		}

		public void AddToList(RoomInfo info, bool animate = false)
		{
		}

		public void RemoveFromList()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateAddition_003Ed__11))]
		private IEnumerator AnimateAddition()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateRemove_003Ed__12))]
		private IEnumerator AnimateRemove()
		{
			return null;
		}
	}
}
