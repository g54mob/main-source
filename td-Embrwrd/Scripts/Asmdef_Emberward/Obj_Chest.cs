using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_Chest : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CCR_OpenChest_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_Chest _003C_003E4__this;

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
		public _003CCR_OpenChest_003Ed__15(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_OpenChest_ScrapMaster_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_Chest _003C_003E4__this;

		private Obj_ScrapMasterMachine _003CscrapMasterMachine_003E5__2;

		private int _003Clv1ExpCount_003E5__3;

		private int _003Clv2ExpCount_003E5__4;

		private float _003Cspeed_003E5__5;

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
		public _003CCR_OpenChest_ScrapMaster_003Ed__17(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private ParticleSystem particle_GlowRay;

	[SerializeField]
	private bool activateOnStart;

	[SerializeField]
	private string soundKey_Show;

	[SerializeField]
	private string soundKey_Open;

	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private DiscoverRewardHandler.eDiscoverRewardType rewardType;

	private List<DiscoverRewardData> list_Reward;

	private bool isClickable;

	private bool isYellowOutlineOn;

	private bool isBlueOutlineOn;

	private bool isTooltipOn;

	private void Start()
	{
	}

	private void OnMouseDown()
	{
	}

	public void Initialize(bool fastForward = false, bool isAirdrop = false)
	{
	}

	public void OpenChest()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_OpenChest_003Ed__15))]
	private IEnumerator CR_OpenChest(List<DiscoverRewardData> list_Data)
	{
		return null;
	}

	public void OpenChest_ScrapMaster()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_OpenChest_ScrapMaster_003Ed__17))]
	private IEnumerator CR_OpenChest_ScrapMaster()
	{
		return null;
	}

	private void RemoveChest()
	{
	}

	private bool DoChestTypeDiscoverCard(DiscoverRewardHandler.eDiscoverRewardType type)
	{
		return false;
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayClickDown()
	{
	}
}
