using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FirstPersonItemController : MonoBehaviour
{
	[Serializable]
	public class InventorySlot
	{
		public enum StaticSlot
		{
			nonStatic = 0,
			holster = 1,
			watch = 2,
			fists = 3,
			coin = 4,
			printReader = 5
		}

		public int index;

		public int interactableID;

		public string debugName;

		public string hotkey;

		public StaticSlot isStatic;

		[NonSerialized]
		public InventorySquareController spawnedSegment;

		public void SetSegmentContent(Interactable newI)
		{
		}

		public Interactable GetInteractable()
		{
			return null;
		}

		public FirstPersonItem GetFirstPersonItem()
		{
			return null;
		}

		public void SetHotKey(string newHotkey)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSmokingToke_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FirstPersonItemController _003C_003E4__this;

		private float _003CsmokingTokeProgress_003E5__2;

		private Material _003CactiveCigMat_003E5__3;

		private ParticleSystem _003CsmokingExhale_003E5__4;

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
		public _003CSmokingToke_003Ed__58(int _003C_003E1__state)
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
	private sealed class _003CHideCig_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool triggerAnimations;

		public float preDelay;

		public float delay;

		public FirstPersonItemController _003C_003E4__this;

		public bool destroy;

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
		public _003CHideCig_003Ed__59(int _003C_003E1__state)
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
	private sealed class _003CTakeOneExecute_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FirstPersonItemController _003C_003E4__this;

		private float _003Cprogress_003E5__2;

		private Interactable _003Cconsumable_003E5__3;

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
		public _003CTakeOneExecute_003Ed__93(int _003C_003E1__state)
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
	private sealed class _003CAnimateFlash_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private float _003Ctimer_003E5__2;

		private Light _003Cflash_003E5__3;

		private HDAdditionalLightData _003ChdData_003E5__4;

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
		public _003CAnimateFlash_003Ed__101(int _003C_003E1__state)
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

	[Header("Slots")]
	public List<InventorySlot> slots;

	public int inventorySlots;

	[Header("First Person Items")]
	public bool enableItemSelection;

	public Transform lagPivotTransform;

	public FirstPersonItem previousItem;

	public FirstPersonItem currentItem;

	public FirstPersonItem drawnItem;

	public bool finishedDrawingItem;

	public float attackMainDelay;

	public float attackSecondaryDelay;

	public Transform leftHandObjectParent;

	public Transform rightHandObjectParent;

	public AnimationClip nothingClip;

	private GameObject rightPrefabReference;

	private GameObject leftPrefabReference;

	private float equipSoundDelay;

	private float holsterSoundDelay;

	private Material fistMaterial;

	private Material fingerUpperMaterial;

	private Material fingerLowerMaterial;

	private Material fingerTipMaterial;

	private Material thumbJointMaterial;

	public bool forceHolstered;

	public InventorySlot selectedWhenForceHolstered;

	public bool listenForHolster;

	public bool listenForDrawFinish;

	[Header("Interactions")]
	public Dictionary<InteractablePreset.InteractionKey, Interactable.InteractableCurrentAction> currentActions;

	public bool isConsuming;

	public bool isRaised;

	private bool takeOneActive;

	[Header("Flashlight")]
	public bool flashlight;

	public GameObject flashLightObject;

	public GameObject captureLightObject;

	public GameObject fingerprintLights;

	public Light printScannerPulseLight;

	public bool cameraFlash;

	public FingerprintScannerController activeScanner;

	[Header("Other Interaction")]
	public bool umbrellaUp;

	public int smokingActive;

	public float smokingProgress;

	public GameObject smokingObject;

	public bool smokingTokeActive;

	[Header("Print Scanner")]
	[Tooltip("Point of raycast impact")]
	public Vector3 scannerRayPoint;

	[Tooltip("Radius of detection")]
	public float printDetectionRadius;

	[Header("Items")]
	public InteractablePreset worldCoin;

	[Header("Audio")]
	public AudioController.LoopingSoundInfo activeLoop;

	public AudioController.LoopingSoundInfo consumeLoop;

	private Actor counterAttackActor;

	private Vector3 counterAttackPoint;

	private int updateInteractionCounter;

	private static FirstPersonItemController _instance;

	public static FirstPersonItemController Instance => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void StartSmokeToke()
	{
	}

	[IteratorStateMachine(typeof(_003CSmokingToke_003Ed__58))]
	private IEnumerator SmokingToke()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CHideCig_003Ed__59))]
	private IEnumerator HideCig(float delay, bool destroy = false, float preDelay = 0f, bool triggerAnimations = true)
	{
		return null;
	}

	private void OnConsumableFinished(Interactable consumableFinished)
	{
	}

	private void LateUpdate()
	{
	}

	public void SetSlotSize(int newSize)
	{
	}

	public InventorySlot AddSpecificStaticSlot(InventorySlot.StaticSlot staticItem)
	{
		return null;
	}

	public void RemoveSpecificStaticSlot(InventorySlot.StaticSlot staticItem)
	{
	}

	public void PlayerMoneyCheck()
	{
	}

	public bool PickUpItem(Interactable pickUpThis, bool switchToNew = false, bool allowSwap = false, bool enableFullMessage = true, bool enablePickupMessage = true, bool playSound = true)
	{
		return false;
	}

	public bool IsSlotAvailable()
	{
		return false;
	}

	public void EmptySlot(InventorySlot emptySlot, bool throwObject = false, bool destroyObject = false, bool removeStolenFine = true, bool playSound = true)
	{
	}

	public void UpdateCurrentActions()
	{
	}

	public void OnHolster()
	{
	}

	public void RefreshHeldObjects()
	{
	}

	private GameObject GetLeftHandPrefab(out Vector3 spawnScaleModifier)
	{
		spawnScaleModifier = default(Vector3);
		return null;
	}

	private GameObject GetRightHandPrefab(out Vector3 spawnScaleModifier)
	{
		spawnScaleModifier = default(Vector3);
		return null;
	}

	public void GenerateSkinColourMaterials()
	{
	}

	public void SetFirstPersonItem(FirstPersonItem newItem, bool forceSwitch = true)
	{
	}

	public void SetFirstPersonSkinColour()
	{
	}

	public void ReadyNewItemDraw()
	{
	}

	public void FinishedDrawingNewItem()
	{
	}

	public void OnInteraction(InteractablePreset.InteractionKey input)
	{
	}

	public void ForceHolster()
	{
	}

	public void RestoreItemSelection()
	{
	}

	public void SetEnableFirstPersonItemSelection(bool val)
	{
	}

	public void SetFlashlight(bool val)
	{
	}

	public void ToggleFlashlight()
	{
	}

	public void MeleeAttack()
	{
	}

	public void Block()
	{
	}

	public void CounterAttack()
	{
	}

	public void ThrowCoin()
	{
	}

	public void Handcuff()
	{
	}

	public void Takedown()
	{
	}

	public void SetConsuming(bool val)
	{
	}

	public void TakeOne()
	{
	}

	[IteratorStateMachine(typeof(_003CTakeOneExecute_003Ed__93))]
	private IEnumerator TakeOneExecute()
	{
		return null;
	}

	public void Smoke()
	{
	}

	public void ForceCanelSmoking()
	{
	}

	public void SetRaised(bool val)
	{
	}

	public void PutDown()
	{
	}

	public void ThrowFood()
	{
	}

	public void ThrowGrenade()
	{
	}

	public void TakePicture()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateFlash_003Ed__101))]
	private IEnumerator AnimateFlash()
	{
		return null;
	}

	public void PlaceCodebreaker()
	{
	}

	public void PlaceDoorWedge()
	{
	}

	public void PlaceTracker()
	{
	}

	public void PlaceGrenade(InteractablePreset activeGrenade)
	{
	}

	public void PlaceFurniture()
	{
	}

	public void PlaceFurnitureConfirm()
	{
	}

	public void PlaceFurnitureCancel()
	{
	}

	public void CancelFurniture()
	{
	}

	public void Give()
	{
	}

	private void OnDestroy()
	{
	}
}
