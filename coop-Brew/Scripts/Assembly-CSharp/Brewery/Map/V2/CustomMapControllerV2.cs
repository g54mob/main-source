using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Map.Controllers;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UI.Core;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Brewery.Map.V2
{
	[RequireComponent(typeof(NetworkObject))]
	public class CustomMapControllerV2 : NetworkBehaviour, IUIPanel, IMapController
	{
		[CompilerGenerated]
		private sealed class _003COpenMapCoroutine_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomMapControllerV2 _003C_003E4__this;

			private float _003CopenDur_003E5__2;

			private float _003CinkDur_003E5__3;

			private float _003CtotalDur_003E5__4;

			private float _003Celapsed_003E5__5;

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
			public _003COpenMapCoroutine_003Ed__73(int _003C_003E1__state)
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
		private sealed class _003CWarmupShaders_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomMapControllerV2 _003C_003E4__this;

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
			public _003CWarmupShaders_003Ed__46(int _003C_003E1__state)
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

		[Header("Style")]
		[SerializeField]
		private MapStyleProfile styleProfile;

		[Header("References (auto-found if empty)")]
		[SerializeField]
		private Camera playerCamera;

		[Tooltip("Optional pre-created map camera. If null, one is created at runtime.")]
		[SerializeField]
		private Camera mapCamera;

		[Header("Input")]
		[SerializeField]
		private InputReader inputReader;

		[Header("Player Controllers (auto-found)")]
		[SerializeField]
		private MonoBehaviour cameraController;

		[SerializeField]
		private MonoBehaviour playerAnimController;

		private bool _isMapOpen;

		private bool _isTransitioning;

		private bool _wasCamControllerEnabled;

		private bool _wasPlayerControllerEnabled;

		private Vector3 _mapPosition;

		private float _currentZoom;

		private float _targetZoom;

		private float _zoomVelocity;

		private Vector3 _navVelocity;

		private float _currentHeight;

		private float _targetHeight;

		private float _heightVelocity;

		private bool _isDragging;

		private Vector2 _lastDragScreenPos;

		private bool _isSprintHeld;

		private float _savedLodBias;

		private Texture2D _terrainSurfaceMask;

		private MapHoverController _hoverController;

		private MapCameraSettings _dummyHoverSettings;

		private Camera _iconOverlayCamera;

		private int _lastToggleFrame;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static bool IsLocalPlayerInMapView { get; private set; }

		public void Close()
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

		public override void OnNetworkSpawn()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private new void OnDestroy()
		{
		}

		private void Initialize()
		{
		}

		[IteratorStateMachine(typeof(_003CWarmupShaders_003Ed__46))]
		private IEnumerator WarmupShaders()
		{
			return null;
		}

		private void AutoFindController(ref MonoBehaviour target, string typeName)
		{
		}

		private void EnsureMapCamera()
		{
		}

		private void ConfigureMapCamera()
		{
		}

		private void EnsureIconOverlayCamera(int overlayMask, UniversalAdditionalCameraData baseUrpData)
		{
		}

		private void SyncIconCameraProjection()
		{
		}

		private void SubscribeInput()
		{
		}

		private void UnsubscribeInput()
		{
		}

		private void OnMapToggled()
		{
		}

		private void OnZoomPerformed(float delta)
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

		private void Update()
		{
		}

		private void UpdateNavigation()
		{
		}

		private void UpdateZoom()
		{
		}

		private void ApplyCameraTransform()
		{
		}

		private Vector3 ScreenToWorldOnMapPlane(Vector2 screenPos)
		{
			return default(Vector3);
		}

		private void RecenterOnPlayer()
		{
		}

		private void ClampMapPosition()
		{
		}

		private void BakeTerrainSurfaceMask()
		{
		}

		private void EnsureHoverController()
		{
		}

		private void UpdateHover()
		{
		}

		private void HandleWaypointRightClick()
		{
		}

		private void OpenMap()
		{
		}

		private void CloseMap()
		{
		}

		[IteratorStateMachine(typeof(_003COpenMapCoroutine_003Ed__73))]
		private IEnumerator OpenMapCoroutine()
		{
			return null;
		}

		private void ForceCloseImmediate()
		{
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
