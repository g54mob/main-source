using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Camera/Third Person Follow Target (Cinemachine)")]
	public class ThirdPersonFollowTarget : MonoBehaviour
	{
		public static HashSet<ThirdPersonFollowTarget> TPFCameras;

		[Tooltip("Cinemachine Brain Camera")]
		public CinemachineBrain Brain;

		[Tooltip("The Camera can rotate independent of the Game Time")]
		public BoolReference unscaledTime = new BoolReference(value: true);

		[Tooltip("Default Priority of this Cinemachine camera")]
		public int priority = 10;

		[Tooltip("Changes the Camera Side parameter on the Third Person Camera")]
		[Range(0f, 1f)]
		[SerializeField]
		private float cameraSide = 1f;

		[Tooltip("Default Camera Distance set to the Third Person Cinemachine Camera")]
		public FloatReference CameraDistance = new FloatReference(6f);

		[Tooltip("What object to follow")]
		public TransformReference Target;

		[Tooltip("Camera Input Values (Look X:Horizontal, Look Y: Vertical)")]
		public Vector2Reference look = new Vector2Reference();

		[SerializeField]
		private bool useUpVector;

		[Hide("useUpVector")]
		[Tooltip("Reference of a Transform to get the Up Vector, so the camera can be aligned with it vector")]
		public TransformReference upVector;

		[Header("Camera Properties")]
		[Tooltip("Sensitivity to rotate the X Axis")]
		public FloatReference XMultiplier = new FloatReference(1f);

		[Tooltip("Sensitivity to rotate the Y Axis")]
		public FloatReference YMultiplier = new FloatReference(1f);

		[Tooltip("How far in degrees can you move the camera up")]
		public FloatReference TopClamp = new FloatReference(70f);

		[Tooltip("How far in degrees can you move the camera down")]
		public FloatReference BottomClamp = new FloatReference(-30f);

		[Tooltip("Lerp Rotation to smooth out the movement of the camera while rotating.")]
		public FloatReference LerpRotation = new FloatReference(15f);

		[Tooltip("Lerp Position to smooth out the movement of the camera while following the target.")]
		public FloatReference lerpPosition = new FloatReference(0f);

		[Tooltip("Invert X Axis of the Look Vector")]
		public BoolReference invertX = new BoolReference();

		[Tooltip("Invert Y Axis of the Look Vector")]
		public BoolReference invertY = new BoolReference();

		[Header("Mouse Keyboard and GamePad")]
		public StringReference CurrentDevice = new StringReference("Mouse");

		[Tooltip("Is the camera using Mouse Input (true) or a Gamepad (False)")]
		public BoolReference UsingMouse = new BoolReference(value: true);

		[Tooltip("Extra Multiplier for the Rotation sensitivity when using a gamepad")]
		public FloatReference GamepadMult = new FloatReference(1000f);

		public BoolEvent OnActiveCamera = new BoolEvent();

		private ICinemachineCamera ThisCamera;

		private Cinemachine3rdPersonFollow CM3PFollow;

		[Disable]
		public float _cinemachineTargetYaw;

		[Disable]
		public float _cinemachineTargetPitch;

		private const float _threshold = 1E-05f;

		private float InvertX => (!invertX.Value) ? 1 : (-1);

		private float InvertY => invertY.Value ? 1 : (-1);

		public float XSensibility
		{
			get
			{
				return XMultiplier;
			}
			set
			{
				XMultiplier.Value = value;
			}
		}

		public float YSensibility
		{
			get
			{
				return YMultiplier;
			}
			set
			{
				YMultiplier.Value = value;
			}
		}

		public float LerpPosition
		{
			get
			{
				return lerpPosition;
			}
			set
			{
				lerpPosition.Value = value;
			}
		}

		public Transform UpVector
		{
			get
			{
				return upVector;
			}
			set
			{
				upVector.Value = value;
			}
		}

		public bool UnScaledTime
		{
			get
			{
				return unscaledTime;
			}
			set
			{
				unscaledTime.Value = value;
			}
		}

		public Transform CamPivot { get; set; }

		public float CameraSide
		{
			get
			{
				return cameraSide;
			}
			set
			{
				cameraSide = value;
			}
		}

		public bool LastThirdPersonCamera { get; set; }

		public ICinemachineCamera ActiveCM_NOT3rdPerson { get; set; }

		private ICinemachineCamera BrainActiveCamera { get; set; }

		private bool Active { get; set; }

		public bool UseUpVector
		{
			get
			{
				return useUpVector;
			}
			set
			{
				useUpVector = value;
			}
		}

		public void SetMouse(bool value)
		{
			UsingMouse.Value = value;
		}

		public bool SetInvertX(bool value)
		{
			return invertX.Value = value;
		}

		public bool SetInvertY(bool value)
		{
			return invertY.Value = value;
		}

		private void Awake()
		{
			if (Brain == null)
			{
				Brain = UnityEngine.Object.FindFirstObjectByType<CinemachineBrain>();
			}
			CM3PFollow = this.FindComponent<Cinemachine3rdPersonFollow>();
			CM3PFollow.CameraDistance = CameraDistance;
			CM3PFollow.CameraSide = CameraSide;
			UsingMouse.Value = true;
		}

		private void OnEnable()
		{
			if (TPFCameras == null)
			{
				TPFCameras = new HashSet<ThirdPersonFollowTarget>();
			}
			TPFCameras.Add(this);
			CreateCameraPivot();
			if (TryGetComponent<ICinemachineCamera>(out ThisCamera) && ThisCamera.Follow == null)
			{
				ThisCamera.Follow = CamPivot.transform;
			}
			this.Delay_Action(1, delegate
			{
				Brain.m_WorldUpOverride = UpVector;
			});
			CinemachineCore.CameraUpdatedEvent.AddListener(UpdateCameraEvent);
			CameraMove(0f, 0f);
			StartCoroutine(ICameraRotation());
			if (CurrentDevice.Variable != null)
			{
				StringVar variable = CurrentDevice.Variable;
				variable.OnValueChanged = (Action<string>)Delegate.Combine(variable.OnValueChanged, new Action<string>(SetMouseFromDevice));
			}
		}

		private void OnDisable()
		{
			CinemachineCore.CameraUpdatedEvent.RemoveListener(UpdateCameraEvent);
			StopAllCoroutines();
			TPFCameras.Remove(this);
			if (CurrentDevice.Variable != null)
			{
				StringVar variable = CurrentDevice.Variable;
				variable.OnValueChanged = (Action<string>)Delegate.Remove(variable.OnValueChanged, new Action<string>(SetMouseFromDevice));
			}
		}

		private void SetMouseFromDevice(string deviceName)
		{
			UsingMouse.Value = deviceName.Contains(CurrentDevice.ConstantValue);
		}

		private void CreateCameraPivot()
		{
			if (CamPivot == null)
			{
				foreach (ThirdPersonFollowTarget tPFCamera in TPFCameras)
				{
					if (!(tPFCamera == this) && tPFCamera.Target.Value == Target.Value && tPFCamera.CamPivot != null)
					{
						CamPivot = tPFCamera.CamPivot;
						break;
					}
				}
			}
			if (CamPivot == null)
			{
				CamPivot = new GameObject("CamPivot - [" + ((Target.Value != null) ? Target.Value.name : base.name) + "]").transform;
				CamPivot.ResetLocal();
				CamPivot.parent = null;
			}
		}

		private void UpdateCameraEvent(CinemachineBrain camBrain)
		{
			if (!(Brain == camBrain))
			{
				return;
			}
			if (camBrain.ActiveVirtualCamera != BrainActiveCamera)
			{
				BrainActiveCamera = camBrain.ActiveVirtualCamera;
				if (BrainActiveCamera == null)
				{
					ActiveCM_NOT3rdPerson = null;
				}
				else
				{
					ThirdPersonFollowTarget component = (BrainActiveCamera as CinemachineVirtualCameraBase).GetComponent<ThirdPersonFollowTarget>();
					ActiveCM_NOT3rdPerson = ((component == null) ? BrainActiveCamera : null);
				}
			}
			if (Brain.m_UpdateMethod == CinemachineBrain.UpdateMethod.LateUpdate)
			{
				CameraPos(UnScaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			}
			else
			{
				CameraPos(UnScaledTime ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime);
			}
		}

		private IEnumerator ICameraRotation()
		{
			while (true)
			{
				CameraRotation(UnScaledTime ? Time.unscaledDeltaTime : Time.deltaTime, LerpRotation);
				yield return null;
			}
		}

		private void CameraPos(float deltaTime)
		{
			if (ThisCamera == Brain.ActiveVirtualCamera)
			{
				if (!Active)
				{
					Active = true;
					OnActiveCamera.Invoke(Active);
					CameraMove(LerpPosition, deltaTime);
					LastThirdPersonCamera = false;
					return;
				}
			}
			else if (Active)
			{
				LastThirdPersonCamera = true;
				Active = false;
				OnActiveCamera.Invoke(Active);
			}
			if (Active)
			{
				if (!UnScaledTime && Time.timeScale == 0f)
				{
					look.Value = Vector2.zero;
					return;
				}
				CameraMove(LerpPosition, deltaTime);
				SetCameraSide(CameraSide);
			}
		}

		private void CameraMove(float lerp, float deltatime)
		{
			if (!(Target.Value == null))
			{
				if (lerp == 0f)
				{
					CamPivot.transform.position = Target.position;
				}
				else
				{
					CamPivot.transform.position = Vector3.Lerp(CamPivot.transform.position, Target.position, lerp * deltatime);
				}
			}
		}

		private void CameraRotation(float deltaTime, float lerp)
		{
			if (Active)
			{
				if (look.Value.sqrMagnitude >= 1E-05f)
				{
					float num = (UsingMouse ? 1f : (deltaTime * (float)GamepadMult));
					_cinemachineTargetYaw += look.x * InvertX * (float)XMultiplier * num;
					_cinemachineTargetPitch += look.y * InvertY * (float)YMultiplier * num;
				}
				_cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
				_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);
				Quaternion quaternion = Quaternion.Euler(_cinemachineTargetPitch, _cinemachineTargetYaw, 0f);
				if (UseUpVector && (bool)UpVector)
				{
					quaternion = Quaternion.FromToRotation(Vector3.up, UpVector.up) * quaternion;
				}
				if (lerp > 0f)
				{
					CamPivot.rotation = Quaternion.Lerp(CamPivot.rotation, quaternion, deltaTime * lerp);
				}
				else
				{
					CamPivot.rotation = quaternion;
				}
				UpdateAllCamerasYawPitch();
			}
			else if (ActiveCM_NOT3rdPerson != null && !Brain.IsBlending)
			{
				_cinemachineTargetYaw = 0f - Vector3.SignedAngle(Brain.transform.forward, Vector3.forward, Vector3.up);
				_cinemachineTargetPitch = 0f - Vector3.SignedAngle(Brain.transform.up, Vector3.up, Brain.transform.right);
				if (LastThirdPersonCamera)
				{
					CamPivot.SetPositionAndRotation(Target.Value.position, Brain.transform.rotation);
				}
			}
		}

		private void UpdateAllCamerasYawPitch()
		{
			foreach (ThirdPersonFollowTarget tPFCamera in TPFCameras)
			{
				if (!(tPFCamera.Target.Value != Target.Value) && !(tPFCamera.Brain != Brain) && !tPFCamera.Active)
				{
					tPFCamera._cinemachineTargetYaw = _cinemachineTargetYaw;
					tPFCamera._cinemachineTargetPitch = _cinemachineTargetPitch;
				}
			}
		}

		public void SetLookX(float x)
		{
			look.x = x;
		}

		public void SetLookY(float y)
		{
			look.y = y;
		}

		public void SetLook(Vector2 look)
		{
			this.look.Value = look;
		}

		public void SetTarget(Transform target)
		{
			Target.Value = target;
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f)
			{
				lfAngle += 360f;
			}
			if (lfAngle > 360f)
			{
				lfAngle -= 360f;
			}
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}

		public void SetPriority(bool value)
		{
			if (TryGetComponent<ICinemachineCamera>(out ThisCamera))
			{
				ThisCamera.Priority = (value ? priority : (-1));
			}
		}

		public void SetCameraSide(bool value)
		{
			SetCameraSide(value ? 1 : 0);
		}

		public virtual void SetCameraDistance(float newDistance)
		{
			CameraDistance.Value = newDistance;
			if (CM3PFollow != null)
			{
				CM3PFollow.CameraDistance = CameraDistance;
			}
		}

		public void SetCameraSide(int value)
		{
			SetCameraSide((float)value);
		}

		public void SetCameraSide(float value)
		{
			if (CameraSide != value)
			{
				CameraSide = value;
				CM3PFollow.CameraSide = CameraSide;
			}
		}

		public void TargetTeleport()
		{
			TargetTeleport(BehindTarget: false);
		}

		public void TargetTeleport(bool BehindTarget)
		{
			Vector3 OldDamp = CM3PFollow.Damping;
			CM3PFollow.Damping = Vector3.zero;
			CameraMove(0f, 0f);
			this.Delay_Action(5, delegate
			{
				CM3PFollow.Damping = OldDamp;
			});
			if (BehindTarget)
			{
				YawBehindTarget();
			}
		}

		public void YawBehindTarget()
		{
			if (Target.Value != null)
			{
				_cinemachineTargetYaw = Vector3.SignedAngle(Vector3.forward, Target.Value.forward, (UpVector != null) ? UpVector.up : Vector3.up);
				Debug.DrawRay(Target.Value.position, Target.Value.forward * 10f, Color.green, 2f);
				CameraRotation(0f, 0f);
			}
		}
	}
}
