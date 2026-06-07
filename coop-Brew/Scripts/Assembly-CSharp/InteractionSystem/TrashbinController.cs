using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Items;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class TrashbinController : NetworkBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CAutoCloseDoorsCoroutine_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TrashbinController _003C_003E4__this;

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
			public _003CAutoCloseDoorsCoroutine_003Ed__59(int _003C_003E1__state)
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
		private sealed class _003CCloseDoorsCoroutine_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TrashbinController _003C_003E4__this;

			public int randomSeed;

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
			public _003CCloseDoorsCoroutine_003Ed__61(int _003C_003E1__state)
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
		private sealed class _003CFadeAndDestroyTrash_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject trash;

			public TrashbinController _003C_003E4__this;

			private Renderer[] _003Crenderers_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CFadeAndDestroyTrash_003Ed__65(int _003C_003E1__state)
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
		private sealed class _003CReboundDoor_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform door;

			public TrashbinController _003C_003E4__this;

			public Vector3 closedRotation;

			public float reboundDegrees;

			public float wobbleStrength;

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
			public _003CReboundDoor_003Ed__62(int _003C_003E1__state)
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
		private sealed class _003CShakeDumpster_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TrashbinController _003C_003E4__this;

			private Vector3 _003CoriginalPosition_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CShakeDumpster_003Ed__67(int _003C_003E1__state)
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
		private sealed class _003CThrowGarbageCoroutine_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TrashbinController _003C_003E4__this;

			public int randomSeed;

			public bool openDoors;

			public Vector3 playerPosition;

			private Vector3 _003CstartPos_003E5__2;

			private Vector3 _003CendPos_003E5__3;

			private GameObject _003CbagVisual_003E5__4;

			private Vector3 _003CmidPoint_003E5__5;

			private float _003Celapsed_003E5__6;

			private Vector3 _003CstartRotation_003E5__7;

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
			public _003CThrowGarbageCoroutine_003Ed__58(int _003C_003E1__state)
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
		private sealed class _003CWobbleDoor_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform door;

			public TrashbinController _003C_003E4__this;

			public Vector3 targetRotation;

			private float _003Celapsed_003E5__2;

			private Vector3 _003CoriginalRotation_003E5__3;

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
			public _003CWobbleDoor_003Ed__64(int _003C_003E1__state)
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
		private sealed class _003CWobbleDoorWithIntensity_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform door;

			public float intensity;

			public Vector3 targetRotation;

			public TrashbinController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private Vector3 _003CoriginalRotation_003E5__3;

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
			public _003CWobbleDoorWithIntensity_003Ed__63(int _003C_003E1__state)
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

		[Header("References")]
		[Tooltip("The door/lid transforms to animate (supports multiple doors)")]
		[SerializeField]
		private Transform[] doorTransforms;

		[Tooltip("Point where garbage lands inside the bin")]
		[SerializeField]
		private Transform landingPoint;

		[Tooltip("Prefab to spawn for the thrown garbage visual")]
		[SerializeField]
		private GameObject garbageBagPrefab;

		[Tooltip("The garbage item type that can be disposed")]
		[SerializeField]
		private GarbageItem garbageItemType;

		[Header("Door Animation - Positions")]
		[Tooltip("Rotation when doors are closed (local euler angles). Use array for per-door values, or single value for all.")]
		[SerializeField]
		private Vector3[] doorClosedRotations;

		[Tooltip("Rotation when doors are open (local euler angles). Use array for per-door values, or single value for all.")]
		[SerializeField]
		private Vector3[] doorOpenRotations;

		[Header("Door Animation - Timing")]
		[Tooltip("Duration of door opening animation")]
		[SerializeField]
		private float doorOpenDuration;

		[Tooltip("Duration of door closing animation")]
		[SerializeField]
		private float doorCloseDuration;

		[Tooltip("Delay between each door starting to animate (stagger effect)")]
		[SerializeField]
		private float doorStaggerDelay;

		[Tooltip("Random variation added to stagger delay (0-1 multiplier)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float staggerRandomness;

		[Header("Door Animation - Easing")]
		[Tooltip("Use custom animation curves instead of preset easing")]
		[SerializeField]
		private bool useCustomCurves;

		[Tooltip("Ease type for door opening (ignored if useCustomCurves)")]
		[SerializeField]
		private LeanTweenType doorOpenEaseType;

		[Tooltip("Ease type for door closing (ignored if useCustomCurves)")]
		[SerializeField]
		private LeanTweenType doorCloseEaseType;

		[Tooltip("Custom curve for door opening (if useCustomCurves). X=time(0-1), Y=progress(0-1+overshoot)")]
		[SerializeField]
		private AnimationCurve doorOpenCurve;

		[Tooltip("Custom curve for door closing (if useCustomCurves). X=time(0-1), Y=progress(0-1+bounce)")]
		[SerializeField]
		private AnimationCurve doorCloseCurve;

		[Header("Door Animation - Polish")]
		[Tooltip("Add slight wobble when doors reach target position")]
		[SerializeField]
		private bool addWobble;

		[Tooltip("Wobble intensity in degrees")]
		[SerializeField]
		[Range(0f, 10f)]
		private float wobbleIntensity;

		[Tooltip("Wobble duration in seconds")]
		[SerializeField]
		private float wobbleDuration;

		[Header("Door Animation - Close Variation")]
		[Tooltip("Random variation in close duration per door (0-1 multiplier)")]
		[SerializeField]
		[Range(0f, 0.5f)]
		private float closeDurationVariation;

		[Tooltip("Chance each door will rebound after closing (0-1)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float reboundChance;

		[Tooltip("How far the door bounces back open after closing (degrees)")]
		[SerializeField]
		[Range(0f, 30f)]
		private float reboundAmount;

		[Tooltip("Random variation in rebound amount (0-1 multiplier)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float reboundVariation;

		[Tooltip("Duration of rebound animation")]
		[SerializeField]
		private float reboundDuration;

		[Header("Throw Animation")]
		[Tooltip("Duration of the throw arc animation")]
		[SerializeField]
		private float throwDuration;

		[Tooltip("Height of the throw arc (world units above start/end)")]
		[SerializeField]
		private float throwArcHeight;

		[Tooltip("Scale of the garbage bag visual when thrown")]
		[SerializeField]
		private float thrownBagScale;

		[Tooltip("Minimum time between throws (cooldown)")]
		[SerializeField]
		private float throwCooldown;

		[Tooltip("Time to wait for additional throws before auto-closing doors")]
		[SerializeField]
		private float autoCloseDelay;

		[Header("Garbage Bag Behavior")]
		[Tooltip("How long garbage bags stay in the bin before disappearing")]
		[SerializeField]
		private float trashLingerTime;

		[Tooltip("Duration of fade-out before garbage disappears")]
		[SerializeField]
		private float trashFadeOutDuration;

		[Tooltip("Enable physics on garbage bags after landing")]
		[SerializeField]
		private bool enableTrashPhysics;

		[Header("Impact Shake")]
		[Tooltip("Enable subtle shake when garbage lands")]
		[SerializeField]
		private bool enableImpactShake;

		[Tooltip("How much the dumpster shakes (world units)")]
		[SerializeField]
		[Range(0f, 0.1f)]
		private float shakeIntensity;

		[Tooltip("Duration of the shake effect")]
		[SerializeField]
		private float shakeDuration;

		[Tooltip("Frequency of shake oscillations")]
		[SerializeField]
		private float shakeFrequency;

		[Header("Interaction")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI")]
		[Tooltip("Transform for world-space UI positioning")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> areDoorsOpen;

		private NetworkVariable<double> lastThrowTime;

		private int[] doorTweenIds;

		private Coroutine[] doorEffectCoroutines;

		private int animationGeneration;

		private Coroutine autoCloseCoroutine;

		private bool isClosingDoors;

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		[ClientRpc]
		private void PlayDisposeAnimationClientRpc(Vector3 playerPosition, bool openDoors, int randomSeed, ulong throwingClientId)
		{
		}

		private void TriggerPlayerThrowAnimation()
		{
		}

		[IteratorStateMachine(typeof(_003CThrowGarbageCoroutine_003Ed__58))]
		private IEnumerator ThrowGarbageCoroutine(Vector3 playerPosition, bool openDoors, int randomSeed)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAutoCloseDoorsCoroutine_003Ed__59))]
		private IEnumerator AutoCloseDoorsCoroutine()
		{
			return null;
		}

		[ClientRpc]
		private void CloseDoorsClientRpc(int randomSeed)
		{
		}

		[IteratorStateMachine(typeof(_003CCloseDoorsCoroutine_003Ed__61))]
		private IEnumerator CloseDoorsCoroutine(int randomSeed)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CReboundDoor_003Ed__62))]
		private IEnumerator ReboundDoor(Transform door, Vector3 closedRotation, float reboundDegrees, float wobbleStrength)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWobbleDoorWithIntensity_003Ed__63))]
		private IEnumerator WobbleDoorWithIntensity(Transform door, Vector3 targetRotation, float intensity)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWobbleDoor_003Ed__64))]
		private IEnumerator WobbleDoor(Transform door, Vector3 targetRotation)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeAndDestroyTrash_003Ed__65))]
		private IEnumerator FadeAndDestroyTrash(GameObject trash)
		{
			return null;
		}

		private void CancelAllDoorTweens()
		{
		}

		[IteratorStateMachine(typeof(_003CShakeDumpster_003Ed__67))]
		private IEnumerator ShakeDumpster()
		{
			return null;
		}

		private InventoryManager GetLocalPlayerInventory()
		{
			return null;
		}

		private InventoryManager GetInventoryForClient(ulong clientId)
		{
			return null;
		}

		private Vector3 GetPlayerPosition(ulong clientId)
		{
			return default(Vector3);
		}

		private (int, GarbageMetadata?) FindGarbageInInventory(InventoryManager inventory)
		{
			return default((int, GarbageMetadata?));
		}

		private void Awake()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2855694818(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4244610895(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
