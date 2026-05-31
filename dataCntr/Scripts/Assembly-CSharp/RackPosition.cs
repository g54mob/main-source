using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EPOOutline;
using UnityEngine;

public class RackPosition : Interact
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Server server;

		public NetworkSwitch networkSwitch;

		public PatchPanel patchPanel;

		public GameObject startPosGO;

		internal void _003CInsertItemInRack_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInsertItemInRack_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RackPosition _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private UsableObject _003Cuo_003E5__2;

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
		public _003CInsertItemInRack_003Ed__8(int _003C_003E1__state)
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

	private Outlinable outlineEffect;

	public Rack rack;

	public int positionIndex;

	public int rackPosGlobalUID;

	private AudioSource audioSource;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	private bool IsAllowedItem(bool checkAvailability = false)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CInsertItemInRack_003Ed__8))]
	private IEnumerator InsertItemInRack()
	{
		return null;
	}

	public void SetUsed(bool used)
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}

	public override void SecondActionOnClick()
	{
	}
}
