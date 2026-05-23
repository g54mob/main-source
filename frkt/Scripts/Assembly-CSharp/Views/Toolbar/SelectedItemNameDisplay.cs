using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Views.Generic;

namespace Views.Toolbar
{
	public class SelectedItemNameDisplay : MonoBehaviour
	{
		private sealed class et : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int psx;

			private object psy;

			public SelectedItemNameDisplay psz;

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
			public et(int a)
			{
			}

			[DebuggerHidden]
			private void dsq()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dsq
				this.dsq();
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
			private void dss()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dss
				this.dss();
			}
		}

		[SerializeField]
		private TextMeshProUGUI m_nameText;

		[SerializeField]
		private Highlighter m_highlighter;

		[SerializeField]
		private float m_delayBeforeShowOn;

		[SerializeField]
		private float m_delayBeforeShowOff;

		private Coroutine pta;

		public void dsu(string a)
		{
		}

		public void dsv()
		{
		}

		[IteratorStateMachine(typeof(et))]
		private IEnumerator dsw()
		{
			return null;
		}
	}
}
