using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTurnOnCharacterControllerDelayed_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CTurnOnCharacterControllerDelayed_003Ed__10(int _003C_003E1__state)
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

	public float money;

	public float reputation;

	public float xp;

	private float previousCoins;

	public Transform targetSpawn;

	public InputController inputctrl;

	private Vector3 respawnPos;

	private void Start()
	{
	}

	private void CheckFallsThroughMap()
	{
	}

	public void LoadPlayer(PlayerData data)
	{
	}

	[IteratorStateMachine(typeof(_003CTurnOnCharacterControllerDelayed_003Ed__10))]
	private IEnumerator TurnOnCharacterControllerDelayed()
	{
		return null;
	}

	public bool UpdateCoin(float _coinChhangeAmount, bool withoutSound = false)
	{
		return false;
	}

	public void DropAllItems()
	{
	}

	public void WarpPlayer(Vector3 _position, Quaternion _rotation)
	{
	}

	public void UpdateReputation(float amount)
	{
	}

	public bool UpdateXP(float amount)
	{
		return false;
	}
}
