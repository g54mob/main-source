using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Data;
using __Project__.Scripts.Janitor.Interfaces;

public class Dirt : MonoBehaviourPunCallbacks, IInteractable, IPunInstantiateMagicCallback, ICleanable
{
	[CompilerGenerated]
	private sealed class _003CFadeIn_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Dirt _003C_003E4__this;

		public float fadeDuration;

		private float _003CelapsedTime_003E5__2;

		private float _003CAlienAlphaMax_003E5__3;

		private float _003CAlienAlphaMin_003E5__4;

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
		public _003CFadeIn_003Ed__53(int _003C_003E1__state)
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
	private List<Material> m_DirtMaterials;

	[SerializeField]
	private Material m_AlienDirtMaterial;

	[SerializeField]
	private MeshRenderer m_DirtRenderer;

	[SerializeField]
	private float m_FadeInDuration;

	[SerializeField]
	private float m_AlphaMax;

	[SerializeField]
	private float m_AlphaMin;

	[SerializeField]
	private float m_OrthoCamSmoothness;

	private Transform m_player;

	private ParticleSystem m_BubbleParticle;

	[HideInInspector]
	public float m_CurrentAlpha;

	public GameObject m_Indicator;

	public DirtSaveData dirtSaveData;

	private MopInteraction m_MopInteraction => null;

	public int MaterialIndex { get; set; }

	public List<Material> DirtMaterials => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public float AlphaMin
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float AlphaMax
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

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

	private void Start()
	{
	}

	private new void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void Setup(int materialId, float alpha = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeIn_003Ed__53))]
	public IEnumerator FadeIn(float fadeDuration)
	{
		return null;
	}

	public void Cleaning()
	{
	}

	public void CleaningWithPlayerInteraction()
	{
	}

	public void AddProgress(float progress)
	{
	}

	public void AddProgressWithPlayerInteraction(float progress)
	{
	}

	public void SpawnBubbleParticle()
	{
	}

	private void SpawnBubbleParticle_Internal()
	{
	}

	[PunRPC]
	private void ToggleBubbleParticle_Broadcast(bool value)
	{
	}

	public void StopCleaningEffect()
	{
	}

	private void StopCleaningEffect_Internal()
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	public int GetRandomMaterialIndex()
	{
		return 0;
	}
}
