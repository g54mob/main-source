using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/core/")]
	[RequireComponent(typeof(Camera))]
	public class ProCamera2D : MonoBehaviour, ISerializationCallbackReceiver
	{
		[CompilerGenerated]
		private sealed class _003CAdjustTargetInfluenceRoutine_003Ed__134 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CameraTarget cameraTarget;

			public ProCamera2D _003C_003E4__this;

			public float duration;

			public float influenceH;

			public float influenceV;

			public bool removeIfZeroInfluence;

			private float _003CstartInfluenceH_003E5__2;

			private float _003CstartInfluenceV_003E5__3;

			private float _003Ct_003E5__4;

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
			public _003CAdjustTargetInfluenceRoutine_003Ed__134(int _003C_003E1__state)
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
		private sealed class _003CApplyInfluenceTimedRoutine_003Ed__133 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public ProCamera2D _003C_003E4__this;

			public Vector2 influence;

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
			public _003CApplyInfluenceTimedRoutine_003Ed__133(int _003C_003E1__state)
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
		private sealed class _003CApplyInfluencesTimedRoutine_003Ed__132 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float[] durations;

			public ProCamera2D _003C_003E4__this;

			public IList<Vector2> influences;

			private int _003Ccount_003E5__2;

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
			public _003CApplyInfluencesTimedRoutine_003Ed__132(int _003C_003E1__state)
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
		private sealed class _003CDollyZoomRoutine_003Ed__136 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2D _003C_003E4__this;

			public float duration;

			public float finalFOV;

			public EaseType easeType;

			private float _003CstartFOV_003E5__2;

			private float _003CnewFOV_003E5__3;

			private float _003Ct_003E5__4;

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
			public _003CDollyZoomRoutine_003Ed__136(int _003C_003E1__state)
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
		private sealed class _003CUpdateScreenSizeRoutine_003Ed__135 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2D _003C_003E4__this;

			public float duration;

			public float finalSize;

			public EaseType easeType;

			private float _003CstartSize_003E5__2;

			private float _003CnewSize_003E5__3;

			private float _003Ct_003E5__4;

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
			public _003CUpdateScreenSizeRoutine_003Ed__135(int _003C_003E1__state)
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

		public const string Title = "Pro Camera 2D";

		public static readonly Version Version;

		public List<CameraTarget> CameraTargets;

		public bool CenterTargetOnStart;

		public MovementAxis Axis;

		public UpdateType UpdateType;

		public bool FollowHorizontal;

		public float HorizontalFollowSmoothness;

		public bool FollowVertical;

		public float VerticalFollowSmoothness;

		[Range(-1f, 1f)]
		public float OffsetX;

		[Range(-1f, 1f)]
		public float OffsetY;

		public bool IsRelativeOffset;

		public bool ZoomWithFOV;

		public bool IgnoreTimeScale;

		private static ProCamera2D _instance;

		private float _cameraTargetHorizontalPositionSmoothed;

		private float _cameraTargetVerticalPositionSmoothed;

		private Vector3 _influencesSum;

		public Action<float> PreMoveUpdate;

		public Action<float> PostMoveUpdate;

		public Action<Vector2> OnCameraResize;

		public Action<float> OnUpdateScreenSizeFinished;

		public Action<float> OnDollyZoomFinished;

		public Action OnReset;

		public Vector3? ExclusiveTargetPosition;

		public int CurrentZoomTriggerID;

		public bool IsCameraPositionLeftBounded;

		public bool IsCameraPositionRightBounded;

		public bool IsCameraPositionTopBounded;

		public bool IsCameraPositionBottomBounded;

		public Camera GameCamera;

		private Func<Vector3, float> Vector3H;

		private Func<Vector3, float> Vector3V;

		private Func<Vector3, float> Vector3D;

		private Func<float, float, Vector3> VectorHV;

		private Func<float, float, float, Vector3> VectorHVD;

		private Coroutine _updateScreenSizeCoroutine;

		private Coroutine _dollyZoomRoutine;

		private List<Vector3> _influences;

		private float _originalCameraDepthSign;

		private float _previousCameraTargetHorizontalPositionSmoothed;

		private float _previousCameraTargetVerticalPositionSmoothed;

		private int _previousScreenWidth;

		private int _previousScreenHeight;

		private Vector3 _previousCameraPosition;

		private WaitForFixedUpdate _waitForFixedUpdate;

		private Transform _transform;

		private List<IPreMover> _preMovers;

		private List<IPositionDeltaChanger> _positionDeltaChangers;

		private List<IPositionOverrider> _positionOverriders;

		private List<ISizeDeltaChanger> _sizeDeltaChangers;

		private List<ISizeOverrider> _sizeOverriders;

		private List<IPostMover> _postMovers;

		public static ProCamera2D Instance => null;

		public static bool Exists => false;

		public bool IsMoving => false;

		public Rect Rect
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public Vector2 CameraTargetPositionSmoothed
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector3 LocalPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector2 StartScreenSizeInWorldCoordinates { get; private set; }

		public Vector2 ScreenSizeInWorldCoordinates { get; private set; }

		public Vector3 PreviousTargetsMidPoint { get; private set; }

		public Vector3 TargetsMidPoint { get; private set; }

		public Vector3 CameraTargetPosition { get; private set; }

		public float DeltaTime { get; private set; }

		public Vector3 ParentPosition { get; private set; }

		public Vector3 InfluencesSum => default(Vector3);

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public float GetOffsetX()
		{
			return 0f;
		}

		public float GetOffsetY()
		{
			return 0f;
		}

		public void ApplyInfluence(Vector2 influence)
		{
		}

		public Coroutine ApplyInfluencesTimed(Vector2[] influences, float[] durations)
		{
			return null;
		}

		public CameraTarget AddCameraTarget(Transform targetTransform, float targetInfluenceH = 1f, float targetInfluenceV = 1f, float duration = 0f, Vector2 targetOffset = default(Vector2))
		{
			return null;
		}

		public void AddCameraTargets(IList<Transform> targetsTransforms, float targetsInfluenceH = 1f, float targetsInfluenceV = 1f, float duration = 0f, Vector2 targetOffset = default(Vector2))
		{
		}

		public void AddCameraTargets(IList<CameraTarget> cameraTargets)
		{
		}

		public CameraTarget GetCameraTarget(Transform targetTransform)
		{
			return null;
		}

		public void RemoveCameraTarget(Transform targetTransform, float duration = 0f)
		{
		}

		public void RemoveAllCameraTargets(float duration = 0f)
		{
		}

		public Coroutine AdjustCameraTargetInfluence(CameraTarget cameraTarget, float targetInfluenceH, float targetInfluenceV, float duration = 0f)
		{
			return null;
		}

		public Coroutine AdjustCameraTargetInfluence(Transform cameraTargetTransf, float targetInfluenceH, float targetInfluenceV, float duration = 0f)
		{
			return null;
		}

		public void TranslateCamera(Vector2 translateAmount)
		{
		}

		public void MoveCameraInstantlyToPosition(Vector2 cameraPos)
		{
		}

		public void Reset(bool centerOnTargets = true, bool resetSize = true, bool resetExtensions = true)
		{
		}

		public void ResetMovement()
		{
		}

		public void ResetSize()
		{
		}

		public void ResetStartSize(Vector2 newSize = default(Vector2))
		{
		}

		public void ResetExtensions()
		{
		}

		public void CenterOnTargets()
		{
		}

		public void UpdateScreenSize(float newSize, float duration = 0f, EaseType easeType = EaseType.EaseInOut)
		{
		}

		public void CalculateScreenSize()
		{
		}

		public void Zoom(float zoomAmount, float duration = 0f, EaseType easeType = EaseType.EaseInOut)
		{
		}

		public void DollyZoom(float targetFOV, float duration = 1f, EaseType easeType = EaseType.EaseInOut)
		{
		}

		public void Move(float deltaTime)
		{
		}

		internal YieldInstruction GetYield()
		{
			return null;
		}

		private void ResetAxisFunctions()
		{
		}

		private Vector3 GetTargetsWeightedMidPoint(ref List<CameraTarget> targets)
		{
			return default(Vector3);
		}

		[IteratorStateMachine(typeof(_003CApplyInfluencesTimedRoutine_003Ed__132))]
		private IEnumerator ApplyInfluencesTimedRoutine(IList<Vector2> influences, float[] durations)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CApplyInfluenceTimedRoutine_003Ed__133))]
		private IEnumerator ApplyInfluenceTimedRoutine(Vector2 influence, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAdjustTargetInfluenceRoutine_003Ed__134))]
		private IEnumerator AdjustTargetInfluenceRoutine(CameraTarget cameraTarget, float influenceH, float influenceV, float duration, bool removeIfZeroInfluence = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CUpdateScreenSizeRoutine_003Ed__135))]
		private IEnumerator UpdateScreenSizeRoutine(float finalSize, float duration, EaseType easeType)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDollyZoomRoutine_003Ed__136))]
		private IEnumerator DollyZoomRoutine(float finalFOV, float duration, EaseType easeType)
		{
			return null;
		}

		private void SetScreenSize(float newSize)
		{
		}

		private float GetCameraDistanceForFOV(float fov, float cameraHeight)
		{
			return 0f;
		}

		public void AddPreMover(IPreMover mover)
		{
		}

		public void RemovePreMover(IPreMover mover)
		{
		}

		public void SortPreMovers()
		{
		}

		public void AddPositionDeltaChanger(IPositionDeltaChanger changer)
		{
		}

		public void RemovePositionDeltaChanger(IPositionDeltaChanger changer)
		{
		}

		public void SortPositionDeltaChangers()
		{
		}

		public void AddPositionOverrider(IPositionOverrider overrider)
		{
		}

		public void RemovePositionOverrider(IPositionOverrider overrider)
		{
		}

		public void SortPositionOverriders()
		{
		}

		public void AddSizeDeltaChanger(ISizeDeltaChanger changer)
		{
		}

		public void RemoveSizeDeltaChanger(ISizeDeltaChanger changer)
		{
		}

		public void SortSizeDeltaChangers()
		{
		}

		public void AddSizeOverrider(ISizeOverrider overrider)
		{
		}

		public void RemoveSizeOverrider(ISizeOverrider overrider)
		{
		}

		public void SortSizeOverriders()
		{
		}

		public void AddPostMover(IPostMover mover)
		{
		}

		public void RemovePostMover(IPostMover mover)
		{
		}

		public void SortPostMovers()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
