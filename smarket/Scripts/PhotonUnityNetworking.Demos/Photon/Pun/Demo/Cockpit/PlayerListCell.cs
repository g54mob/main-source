using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class PlayerListCell : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAdd_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerListCell _003C_003E4__this;

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
			public _003CAdd_003Ed__16(int _003C_003E1__state)
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
		private sealed class _003CRemove_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerListCell _003C_003E4__this;

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
			public _003CRemove_003Ed__17(int _003C_003E1__state)
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

		public PlayerListView ListManager;

		public Text NumberText;

		public Text NameText;

		public Image ActiveFlag;

		public Color InactiveColor;

		public Color ActiveColor;

		public Text isLocalText;

		public Image isMasterFlag;

		public LayoutElement LayoutElement;

		private Player _player;

		public bool isInactiveCache;

		public void RefreshInfo(ExitGames.Client.Photon.Hashtable changedProps)
		{
		}

		public void AddToList(Player info, bool animate = false)
		{
		}

		public void RemoveFromList()
		{
		}

		public void OnClick()
		{
		}

		private void UpdateInfo()
		{
		}

		[IteratorStateMachine(typeof(_003CAdd_003Ed__16))]
		private IEnumerator Add()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRemove_003Ed__17))]
		private IEnumerator Remove()
		{
			return null;
		}
	}
}
