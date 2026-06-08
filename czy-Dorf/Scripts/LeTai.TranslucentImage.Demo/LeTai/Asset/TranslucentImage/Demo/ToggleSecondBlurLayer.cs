using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace LeTai.Asset.TranslucentImage.Demo
{
	public class ToggleSecondBlurLayer : MonoBehaviour
	{
		private sealed class _003CDisableSource_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ToggleSecondBlurLayer _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CDisableSource_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				ToggleSecondBlurLayer toggleSecondBlurLayer = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					toggleSecondBlurLayer.changer.SetUpdateRate(0f);
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public ChangeBlurConfig changer;

		public Slider updateRateInput;

		private void Start()
		{
			StartCoroutine(DisableSource());
		}

		private IEnumerator DisableSource()
		{
			return new _003CDisableSource_003Ed__3(0)
			{
				_003C_003E4__this = this
			};
		}

		public void Toggle()
		{
			if (Mathf.Approximately(changer.GetUpdateRate(), 0f))
			{
				changer.SetUpdateRate(updateRateInput.value);
			}
			else
			{
				changer.SetUpdateRate(0f);
			}
		}
	}
}
