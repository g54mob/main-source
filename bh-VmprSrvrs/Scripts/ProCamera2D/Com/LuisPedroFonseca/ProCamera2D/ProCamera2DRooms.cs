using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-rooms/")]
	public class ProCamera2DRooms : BasePC2D, IPositionOverrider, ISizeOverrider
	{
		[CompilerGenerated]
		private sealed class _003CTestRoomRoutine_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DRooms _003C_003E4__this;

			private WaitForSeconds _003CwaitForSeconds_003E5__2;

			private WaitForSecondsRealtime _003CwaitForSecondsRealtime_003E5__3;

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
			public _003CTestRoomRoutine_003Ed__56(int _003C_003E1__state)
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
		private sealed class _003CTransitionRoutine_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DRooms _003C_003E4__this;

			public float transitionDuration;

			public float targetSize;

			public EaseType transitionEaseType;

			public NumericBoundariesSettings numericBoundariesSettings;

			private float _003CinitialSize_003E5__2;

			private float _003CinitialCamPosH_003E5__3;

			private float _003CinitialCamPosV_003E5__4;

			private float _003Ct_003E5__5;

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
			public _003CTransitionRoutine_003Ed__58(int _003C_003E1__state)
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

		public const string ExtensionName = "Rooms";

		private int _currentRoomIndex;

		private int _previousRoomIndex;

		public List<Room> Rooms;

		public float UpdateInterval;

		public bool UseTargetsMidPoint;

		public Transform TriggerTarget;

		public bool TransitionInstanlyOnStart;

		public bool RestoreOnRoomExit;

		public float RestoreDuration;

		public EaseType RestoreEaseType;

		public bool AutomaticRoomActivation;

		public bool UseRelativePosition;

		public RoomEvent OnStartedTransition;

		public RoomEvent OnFinishedTransition;

		public UnityEvent OnExitedAllRooms;

		private ProCamera2DNumericBoundaries _numericBoundaries;

		private NumericBoundariesSettings _defaultNumericBoundariesSettings;

		private bool _transitioning;

		private Vector3 _newPos;

		private float _newSize;

		private Coroutine _transitionRoutine;

		private int _currentRoomID;

		private int _poOrder;

		private int _soOrder;

		public int CurrentRoomIndex => 0;

		public int PreviousRoomIndex => 0;

		public Room CurrentRoom => null;

		public float OriginalSize { get; private set; }

		public int POOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SOOrder
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

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
		{
			return default(Vector3);
		}

		public float OverrideSize(float deltaTime, float originalSize)
		{
			return 0f;
		}

		public void TestRoom()
		{
		}

		public int ComputeCurrentRoom(Vector3 targetPos)
		{
			return 0;
		}

		public void EnterRoom(int roomIndex, bool useTransition = true, bool forceEntrance = false)
		{
		}

		public void EnterRoom(string roomID, bool useTransition = true, bool forceEntrance = false)
		{
		}

		public void ExitRoom()
		{
		}

		public void AddRoom(float roomX, float roomY, float roomWidth, float roomHeight, float transitionDuration = 1f, EaseType transitionEaseType = EaseType.EaseInOut, bool scaleToFit = false, bool zoom = false, float zoomScale = 1.5f, string id = "")
		{
		}

		public void RemoveRoom(string roomName)
		{
		}

		public void SetDefaultNumericBoundariesSettings(NumericBoundariesSettings settings)
		{
		}

		public Room GetRoom(string roomID)
		{
			return null;
		}

		public float GetCameraSizeForRoom(Rect roomRect)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CTestRoomRoutine_003Ed__56))]
		private IEnumerator TestRoomRoutine()
		{
			return null;
		}

		private void TransitionToRoom(Room room, bool useTransition = true)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionRoutine_003Ed__58))]
		private IEnumerator TransitionRoutine(NumericBoundariesSettings numericBoundariesSettings, float targetSize, float transitionDuration = 1f, EaseType transitionEaseType = EaseType.EaseOut)
		{
			return null;
		}

		private void LimitToNumericBoundaries(ref float horizontalPos, ref float verticalPos, float halfCameraWidth, float halfCameraHeight, NumericBoundariesSettings numericBoundaries)
		{
		}
	}
}
