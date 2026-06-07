using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class PointlessSlider3DUIView : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFinished_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PointlessSlider3DUIView _003C_003E4__this;

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
			public _003CFinished_003Ed__10(int _003C_003E1__state)
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

		[SerializeField]
		private Slider3DUIView _slider;

		[SerializeField]
		private TextMeshProI18n _label;

		[SerializeField]
		private Button3DUIView _resetButton;

		private int _targetNumber;

		private bool _finished;

		private static string FINISHED_TEXT;

		private void Start()
		{
		}

		private void ResetSlider()
		{
		}

		private void OnHandlePressedChanged(object sender, EventArgs e)
		{
		}

		private string GetHintText(int value)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFinished_003Ed__10))]
		private IEnumerator Finished()
		{
			return null;
		}
	}
}
