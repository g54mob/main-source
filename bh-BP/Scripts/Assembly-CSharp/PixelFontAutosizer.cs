using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;

public class PixelFontAutosizer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Autosize_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PixelFontAutosizer _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_Autosize_003Ed__9(int _003C_003E1__state)
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

	public TextMeshProUGUI Txt;

	public int MaxSize;

	public float FontBaseSize;

	public Localize Loc;

	public LocalizationParamsManager Params;

	private void Reset()
	{
	}

	public void SetText(string txt)
	{
	}

	public void SetLoc(string loc)
	{
	}

	public void Autosize()
	{
	}

	[IteratorStateMachine(typeof(_003C_Autosize_003Ed__9))]
	private IEnumerator<float> _Autosize()
	{
		return null;
	}
}
