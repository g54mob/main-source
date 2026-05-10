using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteAlways]
	public class E05_PanelUpdater : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CUpdateCoroutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public E05_PanelUpdater _003C_003E4__this;

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
			public _003CUpdateCoroutine_003Ed__4(int _003C_003E1__state)
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

		public CurvySpline Spline;

		public Text StatisticsText;

		public Slider Density;

		[UsedImplicitly]
		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateCoroutine_003Ed__4))]
		private IEnumerator UpdateCoroutine()
		{
			return null;
		}

		private void TryUpdateDisplay()
		{
		}

		public void OnSliderChange()
		{
		}
	}
}
