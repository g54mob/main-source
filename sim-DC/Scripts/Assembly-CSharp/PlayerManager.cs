using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GogoGaga.OptimizedRopesAndCables;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour
{
	public delegate void OnBuyingWall();

	public enum ObjectInHand
	{
		None = 0,
		Server1U = 1,
		Server2U = 2,
		Server3U = 3,
		Switch = 4,
		Rack = 5,
		CableSpinner = 6,
		PatchPanel = 7,
		SFPModule = 8,
		SFPBox = 9,
		ModItem = 10
	}

	[CompilerGenerated]
	private sealed class _003CWaitForActionToFinish_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerManager _003C_003E4__this;

		public float _time;

		public Vector3 _position;

		private int _003Ci_003E5__2;

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
		public _003CWaitForActionToFinish_003Ed__30(int _003C_003E1__state)
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

	public static PlayerManager instance;

	public Player playerClass;

	public CharacterController cc;

	public FirstPersonController fpc;

	public GameObject playerGO;

	public AudioSource audioSource;

	public bool enabledMouseMovement;

	public bool enabledPlayerMovement;

	public CinemachineCamera vcam;

	[SerializeField]
	private Image imageWaitForAction;

	public Rope rope;

	public Transform moveItemPosition;

	public bool enabledRayLookInteract;

	public bool isGamePaused;

	public bool playerIsSitting;

	[SerializeField]
	private ParticleSystem iopsGainParticleSystem;

	public ObjectInHand objectInHand;

	public GameObject objectInHandPositionGO;

	public GameObject[] objectInHandGO;

	public int numberOfObjectsInHand;

	[SerializeField]
	private GameObject defaultActionDustParticle;

	[SerializeField]
	private AudioClip defaultActionAudioClip;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void ConfinedCursorforUI()
	{
	}

	public void PlayerStopMovement()
	{
	}

	public void LockedCursorForPlayerMovement()
	{
	}

	public void DefaultActionEffect(Vector3 _position, float _time)
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForActionToFinish_003Ed__30))]
	private IEnumerator WaitForActionToFinish(Vector3 _position, float _time)
	{
		return null;
	}

	public void GainIOPSEffect()
	{
	}
}
