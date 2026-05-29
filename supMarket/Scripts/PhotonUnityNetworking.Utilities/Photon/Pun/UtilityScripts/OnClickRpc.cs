using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Photon.Pun.UtilityScripts
{
	public class OnClickRpc : MonoBehaviourPun, IPointerClickHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003CClickFlash_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OnClickRpc _003C_003E4__this;

			private bool _003CwasEmissive_003E5__2;

			private float _003Cf_003E5__3;

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
			public _003CClickFlash_003Ed__8(int _003C_003E1__state)
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

		public RpcTarget Target;

		private Material originalMaterial;

		private Color originalColor;

		private bool isFlashing;

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		public void ClickRpc()
		{
		}

		[IteratorStateMachine(typeof(_003CClickFlash_003Ed__8))]
		public IEnumerator ClickFlash()
		{
			return null;
		}
	}
}
