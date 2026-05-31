using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Anim_Scanning_Alpha : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFadeInElements_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Anim_Scanning_Alpha _003C_003E4__this;

		private TextMeshProUGUI[] _003Ctexts_003E5__2;

		private Image[] _003Cimages_003E5__3;

		private float _003Ctimer_003E5__4;

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
		public _003CFadeInElements_003Ed__2(int _003C_003E1__state)
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

	public float fadeDuration;

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeInElements_003Ed__2))]
	private IEnumerator FadeInElements()
	{
		return null;
	}

	private void SetTextAlpha(TextMeshProUGUI text, float alpha)
	{
	}

	private void SetImageAlpha(Image img, float alpha)
	{
	}
}
