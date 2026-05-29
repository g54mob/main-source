using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;
using UnityEngine.UI;

public class InteractableMicrowave : BaseInteractable
{
	[CompilerGenerated]
	private sealed class _003CCookItem_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteractableMicrowave _003C_003E4__this;

		public EItem itemToCreate;

		private float _003Ctimer_003E5__2;

		private float _003CcookTime_003E5__3;

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
		public _003CCookItem_003Ed__36(int _003C_003E1__state)
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

	public Material matCommon;

	public Material matRare;

	public Material matEpic;

	public Material matLegendary;

	public Renderer meshRenderer;

	public static InteractableMicrowave currentlyInteracting;

	public Animator animator;

	public AudioSource sfxStart;

	public AudioSource sfxFinish;

	public GameObject particles;

	public GameObject explosion;

	public RawImage itemIcon;

	public Transform microwaveCenterTransform;

	public GameObject exclamationMark;

	public GameObject progressBar;

	public GameObject minimapIcon;

	public GameObject cookingParticles;

	public RawImage progressBarProgress;

	public static Action<EItem> A_Used;

	public static Action A_Exploded;

	private float readyAtTime;

	private bool hasItem;

	private EItem newItem;

	public static string debugName;

	public EItemRarity rarity { get; private set; }

	public int usesLeft { get; private set; }

	public bool isCooking { get; private set; }

	private new void Start()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	public void UseMicrowave(EItem eItemToCreate)
	{
	}

	[IteratorStateMachine(typeof(_003CCookItem_003Ed__36))]
	private IEnumerator CookItem(EItem itemToCreate)
	{
		return null;
	}

	private float GetCookTime()
	{
		return 0f;
	}

	private void Explode()
	{
	}

	public override bool CanInteract()
	{
		return false;
	}

	public override string GetInteractString()
	{
		return null;
	}

	public int GetPrice()
	{
		return 0;
	}

	private int GetUses(EItemRarity itemRarity)
	{
		return 0;
	}

	public override bool ShowInDebug()
	{
		return false;
	}

	public override string GetDebugName()
	{
		return null;
	}
}
