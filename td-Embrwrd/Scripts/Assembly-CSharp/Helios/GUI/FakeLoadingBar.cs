using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI
{
	public class FakeLoadingBar : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFakeLoading_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FakeLoadingBar _003C_003E4__this;

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
			public _003CFakeLoading_003Ed__5(int _003C_003E1__state)
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
		private Slider _sdLoadingBar;

		[SerializeField]
		private GameObject _objNextScreen;

		[SerializeField]
		private TMP_Text _txtLoadingPercent;

		[SerializeField]
		private GameObject[] _arrNextPopup;

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CFakeLoading_003Ed__5))]
		private IEnumerator FakeLoading()
		{
			return null;
		}
	}
}
