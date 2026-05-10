using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TinyGiantStudio.Modules;
using UnityEngine;

namespace TinyGiantStudio.Text.Example
{
	public class DamageText : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CApplyModules_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DamageText _003C_003E4__this;

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
			public _003CApplyModules_003Ed__7(int _003C_003E1__state)
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

		public Modular3DText modular3DText;

		public Transform textHolder;

		public Module module;

		public void UpdateText(string str)
		{
		}

		public void UpdateText(float number)
		{
		}

		public void UpdateText(int number)
		{
		}

		private void ResetTransform()
		{
		}

		[IteratorStateMachine(typeof(_003CApplyModules_003Ed__7))]
		private IEnumerator ApplyModules()
		{
			return null;
		}
	}
}
