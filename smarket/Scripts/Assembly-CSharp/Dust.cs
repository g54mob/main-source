using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.Data;
using __Project__.Scripts.Janitor;
using __Project__.Scripts.Janitor.Interfaces;

public class Dust : MonoBehaviour, IInteractable, ICleanable
{
	[CompilerGenerated]
	private sealed class _003CCleaningForJanitorCoroutine_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Dust _003C_003E4__this;

		public Janitor janitor;

		private float _003CelapsedTime_003E5__2;

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
		public _003CCleaningForJanitorCoroutine_003Ed__55(int _003C_003E1__state)
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
	private List<GameObject> m_DustList;

	[SerializeField]
	private GameObject m_JanitorCleaningPosition;

	[SerializeField]
	private float m_AlphaMax;

	[SerializeField]
	private float m_AlphaMin;

	[SerializeField]
	private float m_ParticleScaleMultiplier;

	[SerializeField]
	private int m_DustExp;

	[SerializeField]
	private ParticleSystem m_BubbleParticle;

	private static readonly int AlphaClip;

	private List<ParticleSystem> m_BubbleParticles;

	private float m_DustCleaningMultiplier;

	private bool m_IsClean;

	private bool m_IsCleaning;

	public int dustId;

	public DustingSaveData dustingSaveData;

	public float m_CurrentAlpha;

	public float CurrentDustPercentage => 0f;

	public bool IsClean => false;

	public bool IsCleaning
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Coroutine CleaningCoroutine { get; private set; }

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public GameObject JanitorCleaningPosition => null;

	public Action OnCleaned { get; set; }

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void Setup(DustingSaveData saveData)
	{
	}

	public void Dusting()
	{
	}

	public void Cleaning()
	{
	}

	public void CleaningForJanitor(Janitor janitor)
	{
	}

	[IteratorStateMachine(typeof(_003CCleaningForJanitorCoroutine_003Ed__55))]
	private IEnumerator CleaningForJanitorCoroutine(Janitor janitor)
	{
		return null;
	}

	public void StopCleaningEffect()
	{
	}

	private void PlayCleanEffect()
	{
	}

	public void SaveCleaning()
	{
	}
}
