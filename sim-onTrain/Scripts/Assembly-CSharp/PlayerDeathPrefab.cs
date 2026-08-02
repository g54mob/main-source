using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

public class PlayerDeathPrefab : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDestroyAfterDelay_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerDeathPrefab _003C_003E4__this;

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
		public _003CDestroyAfterDelay_003Ed__2(int _003C_003E1__state)
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
			PlayerDeathPrefab playerDeathPrefab = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(playerDeathPrefab.destroyDelay);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (playerDeathPrefab.gameObject != null)
				{
					UnityEngine.Debug.Log("[PlayerDeathPrefab] Destroying after time limit");
					NetworkServer.Destroy(playerDeathPrefab.gameObject);
				}
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

	[SerializeField]
	private float destroyDelay = 60f;

	private void Start()
	{
		if (base.isServer)
		{
			StartCoroutine(DestroyAfterDelay());
		}
	}

	[IteratorStateMachine(typeof(_003CDestroyAfterDelay_003Ed__2))]
	[Server]
	private IEnumerator DestroyAfterDelay()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator PlayerDeathPrefab::DestroyAfterDelay()' called when server was not active");
			return null;
		}
		return new _003CDestroyAfterDelay_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	public override bool Weaved()
	{
		return true;
	}
}
