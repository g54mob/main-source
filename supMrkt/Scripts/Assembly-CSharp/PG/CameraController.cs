using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class CameraController : InitializePlayer
	{
		[Serializable]
		public class CameraPreset
		{
			[SerializeField]
			private string PresetName;

			public bool IsFirstPerson;

			public bool CheckObstacles;

			[Header("Dependence on the size of the car")]
			[ShowInInspectorIf("IsFirstPerson")]
			public float LookingBackLimitAngle;

			[ShowInInspectorIf("IsFirstPerson")]
			public float LookingBackXOffset;

			[SerializeField]
			[HideInInspectorIf("IsFirstPerson", true)]
			private Transform MinCameraLocalPosition;

			[SerializeField]
			[HideInInspectorIf("IsFirstPerson", true)]
			private Transform MaxCameraLocalPosition;

			[HideInInspectorIf("IsFirstPerson", true)]
			public float MinTargetVehicleSize;

			[HideInInspectorIf("IsFirstPerson", true)]
			public float MaxTargetVehicleSize;

			[Header("Move Settings")]
			public float VelocityMultiplier;

			public bool EnableGForceOffset;

			[ShowInInspectorIf("EnableGForceOffset")]
			public float AccelerationGForceMultiplier;

			[ShowInInspectorIf("EnableGForceOffset")]
			public float BrakeGForceMultiplier;

			[ShowInInspectorIf("EnableGForceOffset")]
			public float GForceLerp;

			[Header("Rotation Settings")]
			public bool EnableRotation;

			[ShowInInspectorIf("EnableRotation")]
			public bool OnlyYRotation;

			[ShowInInspectorIf("EnableRotation")]
			public float MinVerticalAngle;

			[ShowInInspectorIf("EnableRotation")]
			public float MaxVerticalAngle;

			[ShowInInspectorIf("EnableRotation")]
			public float SetRotationSpeed;

			[ShowInInspectorIf("EnableRotation")]
			public float AdditionalRotationMultiplier;

			[Header("FOV Settings")]
			public float StandardFOV;

			public float BoostFOV;

			public float SpeedFOVOffset;

			public float ChangeFovSpeed;

			public float SplitScreenFOVMultiplayer;

			[Header("Shake Settings")]
			public bool EnableShake;

			[ShowInInspectorIf("EnableShake")]
			public Vector2 ShakeCameraRadius;

			[ShowInInspectorIf("EnableShake")]
			public float ShakeSpeed;

			[ShowInInspectorIf("EnableShake")]
			public float MinSpeedForStartShake;

			[ShowInInspectorIf("EnableShake")]
			public float MaxSpeedForMaxShake;

			private Vector3 GetMinLocalPosition;

			private Quaternion GetMinLocalRotation;

			private Vector3 GetMaxLocalPosition;

			private Quaternion GetMaxLocalRotation;

			public void Init()
			{
			}

			public Vector3 GetLocalPosition(float targetSize)
			{
				return default(Vector3);
			}

			public Quaternion GetLocalRotation(float targetSize)
			{
				return default(Quaternion);
			}
		}

		[CompilerGenerated]
		private sealed class _003CDoSoftMoveCamera_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CameraController _003C_003E4__this;

			public bool needCheckObstacles;

			private Transform _003CcamTR_003E5__2;

			private Vector3 _003CtargePos_003E5__3;

			private Quaternion _003CtargetRot_003E5__4;

			private Vector3 _003CcamPos_003E5__5;

			private Quaternion _003CcamRot_003E5__6;

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
			public _003CDoSoftMoveCamera_003Ed__53(int _003C_003E1__state)
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

		public CarControllerInput UserControl;

		public List<CameraPreset> CameraPresets;

		public Transform HorizontalRotation;

		public Transform VerticalRotation;

		public Transform CameraParentTransform;

		public Camera MainCamera;

		public float ChangeCameraSpeed;

		public float DellayAfterMouseMove;

		public LayerMask ObstacleMask;

		public float DistanceToObstacle;

		[Header("SplitScreen settings")]
		public Vector2 CameraRectSize;

		public Vector2 CameraRectPosP1;

		public Vector2 CameraRectPosP2;

		private int ActivePresetIndex;

		private int CurrentFrame;

		private float TimerAfterMouseMove;

		private float TargetHorizontalRotation;

		private float LimitedHorizontalRotation;

		private float TargetVerticalRotation;

		private Coroutine SoftMoveCameraCoroutine;

		private float CarSpeedDelta;

		private float PrevCarSpeed;

		private int PlayerIndex;

		private float PreInitializedFOV;

		private Vector3 _TargetPoint;

		private Vector3 LocalCameraPos;

		private Vector3 CurrentShakeCameraPos;

		private Vector3 TargetShakeCameraPos;

		private float RayDistance;

		private RaycastHit Hit;

		private RaycastHit[] Hits;

		private bool ManualRotation;

		private Vector3 TargetPoint => default(Vector3);

		public CameraPreset ActivePreset { get; private set; }

		private bool СameraWasRotatedManually => false;

		public override bool Initialize(VehicleController vehicle)
		{
			return false;
		}

		public override void Uninitialize()
		{
		}

		protected void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateEffects()
		{
		}

		public void SetNextCamera()
		{
		}

		public void SetCamera(int _index)
		{
		}

		public void SoftMoveCamera()
		{
		}

		public void SoftMoveCamera(bool needCheckObstacles)
		{
		}

		public void UpdateActiveCamera(bool fastCameraRotation)
		{
		}

		[IteratorStateMachine(typeof(_003CDoSoftMoveCamera_003Ed__53))]
		private IEnumerator DoSoftMoveCamera(bool needCheckObstacles)
		{
			return null;
		}

		private bool CheckObstacles()
		{
			return false;
		}

		private void ApplyGForce()
		{
		}

		private void OnResetCar()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
