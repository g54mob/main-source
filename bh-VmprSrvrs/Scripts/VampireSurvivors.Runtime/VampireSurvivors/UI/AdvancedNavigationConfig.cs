using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class AdvancedNavigationConfig : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		[CompilerGenerated]
		private sealed class _003CWaitAFrame_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AdvancedNavigationConfig _003C_003E4__this;

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
			public _003CWaitAFrame_003Ed__8(int _003C_003E1__state)
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

		private Selectable _selectable;

		[SerializeField]
		private List<Selectable> _OnUp;

		[SerializeField]
		private List<Selectable> _OnDown;

		[SerializeField]
		private List<Selectable> _OnLeft;

		[SerializeField]
		private List<Selectable> _OnRight;

		private void Awake()
		{
		}

		private void UpdateConfig()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAFrame_003Ed__8))]
		private IEnumerator WaitAFrame()
		{
			return null;
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}
	}
}
