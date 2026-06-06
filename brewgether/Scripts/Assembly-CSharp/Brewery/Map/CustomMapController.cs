using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Map.Controllers;
using MyStuff.Graphics;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UI.Core;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Brewery.Map
{
	[RequireComponent(typeof(NetworkObject))]
	public class CustomMapController : NetworkBehaviour, IUIPanel, IMapController
	{
		private struct CameraState
		{
			public Vector3 position;

			public Quaternion rotation;

			public float fieldOfView;

			public float orthographicSize;

			public bool isOrthographic;
		}

		[CompilerGenerated]
		private sealed class _003CRecenterOnPlayer_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomMapController _003C_003E4__this;

			private float _003CrecenterDuration_003E5__2;

			private float _003Celapsed_003E5__3;

			private Vector3 _003CstartPos_003E5__4;

			private Vector3 _003CtargetPos_003E5__5;

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
			public _003CRecenterOnPlayer_003Ed__108(int _003C_003E1__state)
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
		private sealed class _003CTransitionToMap_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomMapController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private Vector3 _003CstartPos_003E5__3;

			private Quaternion _003CstartRot_003E5__4;

			private float _003CstartFOV_003E5__5;

			private float _003CstartOrthoSize_003E5__6;

			private Vector3 _003CtargetPos_003E5__7;

			private Quaternion _003CtargetRot_003E5__8;

			private float _003CtargetFOV_003E5__9;

			private float _003CstartFogDensity_003E5__10;

			private float _003CstartFogStart_003E5__11;

			private float _003CstartFogEnd_003E5__12;

			private FogMode _003CfogMode_003E5__13;

			private Color _003CstartAmbientSky_003E5__14;

			private Color _003CstartAmbientEquator_003E5__15;

			private Color _003CstartAmbientGround_003E5__16;

			private Color _003CtargetAmbientSky_003E5__17;

			private Color _003CtargetAmbientEquator_003E5__18;

			private Color _003CtargetAmbientGround_003E5__19;

			private float _003CequivalentFOV_003E5__20;

			private bool _003CwasMotionBlurActive_003E5__21;

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
			public _003CTransitionToMap_003Ed__111(int _003C_003E1__state)
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
		private sealed class _003CTransitionToPlayer_003Ed__112 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomMapController _003C_003E4__this;

			private Color _003CanimStartAmbientSky_003E5__2;

			private Color _003CanimStartAmbientEquator_003E5__3;

			private Color _003CanimStartAmbientGround_003E5__4;

			private Color _003CanimTargetAmbientSky_003E5__5;

			private Color _003CanimTargetAmbientEquator_003E5__6;

			private Color _003CanimTargetAmbientGround_003E5__7;

			private float _003Celapsed_003E5__8;

			private Vector3 _003CstartPos_003E5__9;

			private Quaternion _003CstartRot_003E5__10;

			private float _003CstartFOV_003E5__11;

			private Vector3 _003CtargetPos_003E5__12;

			private Quaternion _003CtargetRot_003E5__13;

			private float _003CtargetFOV_003E5__14;

			private float _003CequivalentFOV_003E5__15;

			private bool _003CwasMotionBlurActive_003E5__16;

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
			public _003CTransitionToPlayer_003Ed__112(int _003C_003E1__state)
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
		[SerializeField]
		private Camera playerCamera;

		[SerializeField]
		private InputReader inputReader;

		[SerializeField]
		private Volume postProcessVolume;

		[Header("Camera Controller (Optional)")]
		[Tooltip("Reference to SampleCameraController if using Synty camera system - will be auto-found if not assigned")]
		[SerializeField]
		private MonoBehaviour cameraController;

		[Tooltip("Reference to SamplePlayerAnimationController - will be auto-found if not assigned")]
		[SerializeField]
		private MonoBehaviour playerController;

		[Header("Configuration")]
		[SerializeField]
		private MapCameraSettings settings;

		[Header("Hover System")]
		[SerializeField]
		private LayerMask hoverRaycastLayers;

		[SerializeField]
		private float maxHoverDistance;

		[Header("Mouse Edge Panning")]
		[Tooltip("Enable map panning when mouse is near screen edge")]
		[SerializeField]
		private bool enableMouseEdgePanning;

		[Tooltip("Percentage of screen width/height considered 'edge' zone (0-0.2)")]
		[Range(0.02f, 0.2f)]
		[SerializeField]
		private float edgePanZonePercent;

		[Tooltip("Maximum speed of edge panning")]
		[SerializeField]
		private float edgePanSpeed;

		[Tooltip("Smooth acceleration for edge panning")]
		[Range(0.01f, 0.5f)]
		[SerializeField]
		private float edgePanAcceleration;

		[Header("Mouse Drag Panning")]
		[Tooltip("Enable map panning by left-click and drag")]
		[SerializeField]
		private bool enableMouseDragPanning;

		[Tooltip("Sensitivity multiplier for drag panning")]
		[SerializeField]
		private float dragPanSensitivity;

		private bool isMapOpen;

		private bool isTransitioning;

		private bool wasCameraControllerEnabled;

		private bool wasPlayerControllerEnabled;

		private IMapIconHoverProvider currentHoverProvider;

		private GameObject currentHoveredObject;

		private MapIcon currentHoveredIcon;

		private const float RESET_HOLD_DURATION = 1f;

		private bool isHoldingForReset;

		private float resetHoldStartTime;

		private VehicleHoverProvider currentResetTarget;

		private CameraState savedPlayerState;

		private Transform cameraRig;

		private LayerMask savedCullingMask;

		private CameraClearFlags savedClearFlags;

		private Color savedBackgroundColor;

		private float savedFarClipPlane;

		private int fogTweenId;

		private AtmosphereState _savedAtmosphere;

		private static readonly Color MAP_VIEW_AMBIENT_SKY;

		private static readonly Color MAP_VIEW_AMBIENT_EQUATOR;

		private static readonly Color MAP_VIEW_AMBIENT_GROUND;

		private Vector3 currentMapPosition;

		private float currentMapZoom;

		private float targetMapZoom;

		private float zoomVelocity;

		private Vector3 navigationVelocity;

		private Vector3 mouseEdgePanVelocity;

		private BoxCollider[] boundaryColliders;

		private Vector3 lastValidPosition;

		private MotionBlur motionBlur;

		private float originalMotionBlurIntensity;

		private Volume _dofBlockerVolume;

		private VolumeProfile _dofBlockerProfile;

		private const float CINEMATIC_MOTION_BLUR_INTENSITY = 0.85f;

		private Vector2 moveInput;

		private bool isSprintHeld;

		private bool isDraggingMap;

		private Vector2 lastDragMousePosition;

		private Transform originalCameraParent;

		private bool originalParentWasNull;

		private Vector3 originalLocalPosition;

		private Quaternion originalLocalRotation;

		private ulong ownerNetworkObjectId;

		private string ownerDebugName;

		private bool isCameraUnparented;

		private int originalSiblingIndex;

		private float unparentedTimestamp;

		private const float MAX_UNPARENTED_DURATION = 300f;

		private MapInputHandler inputHandler;

		private MapBoundaryController boundaryController;

		private MapHoverController hoverController;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static bool IsLocalPlayerInMapView { get; internal set; }

		public void Close()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void SubscribeToInputEvents()
		{
		}

		private void UnsubscribeFromInputEvents()
		{
		}

		private void Initialize()
		{
		}

		private void InitializeSubControllers()
		{
		}

		private void DiscoverBoundaryColliders()
		{
		}

		private void Update()
		{
		}

		private void HandleWaypointRightClick()
		{
		}

		private void UpdateVehicleResetHold()
		{
		}

		private void ShowResetProgressUI(string vehicleName)
		{
		}

		private void UpdateResetProgressUI(float progress)
		{
		}

		private void CancelResetHold()
		{
		}

		private void RequestVehicleReset(VehicleHoverProvider vehicleProvider)
		{
		}

		private void UpdateHoverDetection()
		{
		}

		private void HideHoverTooltip()
		{
		}

		private void CreateDoFBlocker()
		{
		}

		private void DestroyDoFBlocker()
		{
		}

		private void LogDoFState(string context)
		{
		}

		private bool SafeUnparentCamera()
		{
			return false;
		}

		private bool SafeReparentCamera()
		{
			return false;
		}

		private bool TryRecoverCamera()
		{
			return false;
		}

		private void CheckCameraUnparentTimeout()
		{
		}

		private void ForceImmediateCameraReparent()
		{
		}

		private void OnMapToggled()
		{
		}

		private void OnZoomPerformed(float scrollDelta)
		{
		}

		private void OnRecenterRequested()
		{
		}

		private void OnSprintHeld()
		{
		}

		private void OnSprintReleased()
		{
		}

		[IteratorStateMachine(typeof(_003CRecenterOnPlayer_003Ed__108))]
		private IEnumerator RecenterOnPlayer()
		{
			return null;
		}

		public void OpenMap()
		{
		}

		public void CloseMap()
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionToMap_003Ed__111))]
		private IEnumerator TransitionToMap()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionToPlayer_003Ed__112))]
		private IEnumerator TransitionToPlayer()
		{
			return null;
		}

		private void UpdateMouseEdgePanning()
		{
		}

		private void UpdateMouseDragPanning()
		{
		}

		private void NavigateMap(Vector2 input)
		{
		}

		private void ClampMapPosition()
		{
		}

		private void ClampToColliderBoundaries()
		{
		}

		private void UpdateMapSettingsRealtime()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public override void OnDestroy()
		{
		}

		public bool IsMapOpen()
		{
			return false;
		}

		public bool IsTransitioning()
		{
			return false;
		}

		public Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}

		public Camera GetCamera()
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
