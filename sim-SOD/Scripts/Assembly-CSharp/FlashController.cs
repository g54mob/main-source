using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class FlashController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFlashColour_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FlashController _003C_003E4__this;

		public int newRepeat;

		private int _003Ccycle_003E5__2;

		private float _003Cprogress_003E5__3;

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
		public _003CFlashColour_003Ed__9(int _003C_003E1__state)
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

	public List<Image> colourCodeElements;

	public bool getNormalColourAtStart;

	public Color normalColour;

	public Color flashColour;

	public float speed;

	private bool flashActive;

	private int repeat;

	private void Start()
	{
	}

	public void Flash(int newRepeat)
	{
	}

	[IteratorStateMachine(typeof(_003CFlashColour_003Ed__9))]
	public IEnumerator FlashColour(int newRepeat)
	{
		return null;
	}

	private void OnDisable()
	{
	}
}
