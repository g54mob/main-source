using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-pan-and-zoom/")]
	public class ProCamera2DPanAndZoom : BasePC2D, IPreMover
	{
		public enum MouseButton
		{
			Left = 0,
			Right = 1,
			Middle = 2
		}

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DPanAndZoom _003C_003E4__this;

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
			public _003CStart_003Ed__52(int _003C_003E1__state)
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

		public static string ExtensionName;

		public Action OnPanStarted;

		public Action OnPanFinished;

		public bool AutomaticInputDetection;

		public bool UseMouseInput;

		public bool UseTouchInput;

		public bool DisableOverUGUI;

		public bool AllowZoom;

		public float MouseZoomSpeed;

		public float PinchZoomSpeed;

		[Range(0f, 2f)]
		public float ZoomSmoothness;

		public float MaxZoomInAmount;

		public float MaxZoomOutAmount;

		public bool ZoomToInputCenter;

		[HideInInspector]
		public bool IsZooming;

		private float _zoomAmount;

		private float _initialCamSize;

		private bool _zoomStarted;

		private float _origFollowSmoothnessX;

		private float _origFollowSmoothnessY;

		private float _prevZoomAmount;

		private float _zoomVelocity;

		private Vector3 _zoomPoint;

		private float _touchZoomTime;

		public bool AllowPan;

		public bool UsePanByDrag;

		[Range(0f, 1f)]
		public float StopSpeedOnDragStart;

		public Rect DraggableAreaRect;

		public Vector2 DragPanSpeedMultiplier;

		public bool UsePanByMoveToEdges;

		public Vector2 EdgesPanSpeed;

		[Range(0f, 0.99f)]
		public float TopPanEdge;

		[Range(0f, 0.99f)]
		public float BottomPanEdge;

		[Range(0f, 0.99f)]
		public float LeftPanEdge;

		[Range(0f, 0.99f)]
		public float RightPanEdge;

		public MouseButton PanMouseButton;

		public float MinPanAmount;

		[HideInInspector]
		public bool ResetPrevPanPoint;

		[HideInInspector]
		public bool IsPanning;

		private Vector2 _panDelta;

		private Transform _panTarget;

		private Vector3 _prevMousePosition;

		private Vector3 _prevTouchPosition;

		private int _prevTouchId;

		private bool _onMaxZoom;

		private bool _onMinZoom;

		private EventSystem _eventSystem;

		private bool _skip;

		private Vector3 _startPanWorldPos;

		private int _prmOrder;

		public int PrMOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__52))]
		private IEnumerator Start()
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void PreMove(float deltaTime)
		{
		}

		private void Pan(float deltaTime)
		{
		}

		private void StartPanning()
		{
		}

		private void StopPanning()
		{
		}

		private void Zoom(float deltaTime)
		{
		}

		public void UpdateCurrentFollowSmoothness()
		{
		}

		public void CenterPanTargetOnCamera(float interpolant = 1f)
		{
		}

		private void CancelZoom()
		{
		}

		private void RestoreFollowSmoothness()
		{
		}

		private void RemoveFollowSmoothness()
		{
		}

		private bool InsideDraggableArea(Vector2 normalizedInput)
		{
			return false;
		}
	}
}
