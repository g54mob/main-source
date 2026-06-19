using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using TMPro;
using UnityEngine;

public class TextAnimations : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTypeLetterAnimation_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TextMeshProUGUI textmesh;

		public string fullText;

		public float interval;

		public EventReference textSound;

		private int _003CvisibleCharCount_003E5__2;

		private bool _003CinsideTag_003E5__3;

		private string _003CcurrentTag_003E5__4;

		private int _003CwriteCount_003E5__5;

		private int _003Ci_003E5__6;

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
		public _003CTypeLetterAnimation_003Ed__0(int _003C_003E1__state)
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

	[IteratorStateMachine(typeof(_003CTypeLetterAnimation_003Ed__0))]
	public static IEnumerator TypeLetterAnimation(TextMeshProUGUI textmesh, string fullText, float interval, EventReference textSound)
	{
		return null;
	}
}
