using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UMA.Examples
{
	public class EnvPresetChooser : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoDumpAllScreens_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnvPresetChooser _003C_003E4__this;

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
			public _003CDoDumpAllScreens_003Ed__5(int _003C_003E1__state)
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

		public Transform[] presets => null;

		public int GetActivePreset()
		{
			return 0;
		}

		public void SetActivePreset(int index)
		{
		}

		public void DumpAllScreens()
		{
		}

		[IteratorStateMachine(typeof(_003CDoDumpAllScreens_003Ed__5))]
		private IEnumerator DoDumpAllScreens()
		{
			return null;
		}
	}
}
