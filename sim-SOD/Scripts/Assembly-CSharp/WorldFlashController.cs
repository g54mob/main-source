using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WorldFlashController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CFlashColour_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WorldFlashController _003C_003E4__this;

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
		public _003CFlashColour_003Ed__8(int _003C_003E1__state)
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

	public InteractableController controller;

	public MeshRenderer rend;

	public Material offMaterial;

	public Material onMaterial;

	public float speed;

	public bool flashActive;

	private int repeat;

	public void Flash(int newRepeat)
	{
	}

	[IteratorStateMachine(typeof(_003CFlashColour_003Ed__8))]
	public IEnumerator FlashColour(int newRepeat)
	{
		return null;
	}

	private void OnDisable()
	{
	}
}
