using System.Collections;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Camera/Free Look Camera")]
	public class MFreeLookCamera : MonoBehaviour
	{
		[HideInInspector]
		public string PlayerID = "Player0";

		[Space]
		public TransformReference m_Target;

		public UpdateType updateType;

		internal UpdateType defaultUpdate;

		public float m_MoveSpeed = 10f;

		[Range(0f, 10f)]
		public float m_TurnSpeed = 10f;

		public float m_TurnSmoothing = 10f;

		public float m_TiltMax = 75f;

		public float m_TiltMin = 45f;

		[Header("Camera Input Axis")]
		public InputAxis Vertical = new InputAxis("Mouse Y", active: true, isRaw: false);

		public InputAxis Horizontal = new InputAxis("Mouse X", active: true, isRaw: false);

		public Vector2Reference MovementAxis = new Vector2Reference();

		private IGravity TargetGravity;

		[Space]
		public FreeLockCameraManager manager;

		public FreeLookCameraState DefaultState;

		[HideInInspector]
		public UnityEvent OnStateChange = new UnityEvent();

		[Space]
		[Header("Sprint Field of View")]
		[Tooltip("Additional FOV when Sprinting")]
		public FloatReference SprintFOV = new FloatReference(10f);

		[Tooltip("Additional FOV when Sprinting")]
		public FloatReference FOVTransition = new FloatReference(1f);

		private float m_LookAngle;

		private float m_TiltAngle;

		private Vector3 m_PivotEulers;

		private Vector3 m_UpVector;

		private Quaternion m_PivotTargetRot;

		private Quaternion m_TransformTargetRot;

		protected FreeLookCameraState NextState;

		protected FreeLookCameraState currentState;

		private IEnumerator IChangeStates;

		private IEnumerator IChange_FOV;

		private IInputSystem inputSystem;

		public Transform DefaultTarget { get; set; }

		public Transform Target
		{
			get
			{
				return m_Target.Value;
			}
			set
			{
				m_Target.Value = value;
				GetTargetGravity();
			}
		}

		public Camera Cam { get; private set; }

		public Transform CamT { get; private set; }

		public Transform Pivot { get; private set; }

		public float ActiveFOV { get; internal set; }

		protected void Awake()
		{
			Cam = GetComponentInChildren<Camera>();
			CamT = Cam.transform;
			Pivot = Cam.transform.parent;
			currentState = null;
			NextState = null;
			if ((bool)manager)
			{
				manager.SetCamera(this);
			}
			if ((bool)DefaultState)
			{
				Set_State(DefaultState);
			}
			m_PivotEulers = Pivot.rotation.eulerAngles;
			m_PivotTargetRot = Pivot.transform.localRotation;
			m_TransformTargetRot = base.transform.localRotation;
			ActiveFOV = Cam.fieldOfView;
			this.inputSystem = DefaultInput.GetInputSystem(PlayerID);
			InputAxis horizontal = Horizontal;
			IInputSystem inputSystem = (Vertical.InputSystem = this.inputSystem);
			horizontal.InputSystem = inputSystem;
			defaultUpdate = updateType;
			if (DefaultState == null)
			{
				DefaultState = ScriptableObject.CreateInstance<FreeLookCameraState>();
				DefaultState.CamFOV = Cam.fieldOfView;
				DefaultState.PivotPos = Pivot.localPosition;
				DefaultState.CamPos = CamT.localPosition;
				DefaultState.name = "Default State";
				OnStateChange.Invoke();
			}
			MovementAxis = Vector2.zero;
		}

		private void Start()
		{
			GetTargetGravity();
		}

		private void GetTargetGravity()
		{
			if ((bool)Target)
			{
				TargetGravity = Target.gameObject.FindInterface<IGravity>();
			}
		}

		public virtual void Set_State(FreeLookCameraState state)
		{
			Pivot.localPosition = state.PivotPos;
			Cam.transform.localPosition = state.CamPos;
			Camera cam = Cam;
			float fieldOfView = (ActiveFOV = state.CamFOV);
			cam.fieldOfView = fieldOfView;
			OnStateChange.Invoke();
		}

		protected void FollowTarget(float deltaTime)
		{
			if (!(Target == null))
			{
				base.transform.position = Vector3.Lerp(base.transform.position, Target.position, deltaTime * m_MoveSpeed);
			}
		}

		internal void UpdateState(FreeLookCameraState state)
		{
			if (!(state == null) && base.enabled)
			{
				Pivot.localPosition = state.PivotPos;
				CamT.localPosition = state.CamPos;
				Camera cam = Cam;
				float fieldOfView = (ActiveFOV = state.CamFOV);
				cam.fieldOfView = fieldOfView;
				OnStateChange.Invoke();
			}
		}

		public void EnableInput(bool value)
		{
			Vertical.active = value;
			Horizontal.active = value;
		}

		public virtual void SetInputAxis(Vector2 input)
		{
			MovementAxis.Value = input;
		}

		private void HandleRotationMovement(float time)
		{
			if (!(Time.timeScale < float.Epsilon))
			{
				if (Horizontal.active)
				{
					MovementAxis.x = Horizontal.GetAxis;
				}
				if (Vertical.active)
				{
					MovementAxis.y = Vertical.GetAxis;
				}
				m_LookAngle += MovementAxis.x * m_TurnSpeed;
				if (TargetGravity != null)
				{
					m_UpVector = Vector3.Slerp(m_UpVector, TargetGravity.UpVector, time * 15f);
				}
				m_TransformTargetRot = Quaternion.FromToRotation(base.transform.up, m_UpVector) * Quaternion.Euler(0f, m_LookAngle, 0f);
				m_TransformTargetRot = Quaternion.Euler(0f, m_LookAngle, 0f);
				m_TiltAngle -= MovementAxis.y * m_TurnSpeed;
				m_TiltAngle = Mathf.Clamp(m_TiltAngle, 0f - m_TiltMin, m_TiltMax);
				m_PivotTargetRot = Quaternion.Euler(m_TiltAngle, m_PivotEulers.y, m_PivotEulers.z);
				Pivot.localRotation = Quaternion.Slerp(Pivot.localRotation, m_PivotTargetRot, m_TurnSmoothing * time);
				base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, m_TransformTargetRot, m_TurnSmoothing * time);
			}
		}

		private void FixedUpdate()
		{
			if (updateType == UpdateType.FixedUpdate)
			{
				FollowTarget(Time.fixedDeltaTime);
				HandleRotationMovement(Time.fixedDeltaTime);
			}
		}

		private void LateUpdate()
		{
			if (updateType == UpdateType.LateUpdate)
			{
				FollowTarget(Time.deltaTime);
				HandleRotationMovement(Time.deltaTime);
			}
		}

		public void Set_State_Smooth(FreeLookCameraState state)
		{
			SetState(state, temporal: false);
		}

		public void Set_State_Temporal(FreeLookCameraState state)
		{
			SetState(state, temporal: true);
		}

		internal void SetState_Instant(FreeLookCameraState state, bool temporal)
		{
			if (!(state == null) && (!currentState || !(state == currentState)))
			{
				NextState = state;
				if (IChangeStates != null)
				{
					StopCoroutine(IChangeStates);
				}
				if (!temporal)
				{
					DefaultState = state;
				}
				UpdateState(state);
			}
		}

		internal void SetState(FreeLookCameraState state, bool temporal)
		{
			if (!(state == null) && (!currentState || !(state == currentState)))
			{
				NextState = state;
				if (IChangeStates != null)
				{
					StopCoroutine(IChangeStates);
				}
				if (!temporal)
				{
					DefaultState = state;
				}
				IChangeStates = StateTransition(state.transition);
				StartCoroutine(IChangeStates);
			}
		}

		public void Set_State_Default_Smooth()
		{
			SetState(DefaultState, temporal: true);
		}

		public void Set_State_Default()
		{
			Set_State(DefaultState);
		}

		public void ToggleSprintFOV(bool val)
		{
			ChangeFOV(val ? (ActiveFOV + SprintFOV.Value) : ActiveFOV);
		}

		public void ChangeFOV(float newFOV)
		{
			if (IChange_FOV != null)
			{
				StopCoroutine(IChange_FOV);
			}
			IChange_FOV = C_SprintFOV(newFOV, FOVTransition);
			StartCoroutine(IChange_FOV);
		}

		private IEnumerator StateTransition(float time)
		{
			float elapsedTime = 0f;
			currentState = NextState;
			while (elapsedTime < time)
			{
				Pivot.localPosition = Vector3.Lerp(Pivot.localPosition, NextState.PivotPos, Mathf.SmoothStep(0f, 1f, elapsedTime / time));
				CamT.localPosition = Vector3.Lerp(CamT.localPosition, NextState.CamPos, Mathf.SmoothStep(0f, 1f, elapsedTime / time));
				Camera cam = Cam;
				float fieldOfView = (ActiveFOV = Mathf.Lerp(Cam.fieldOfView, NextState.CamFOV, Mathf.SmoothStep(0f, 1f, elapsedTime / time)));
				cam.fieldOfView = fieldOfView;
				OnStateChange.Invoke();
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			UpdateState(NextState);
			NextState = null;
			yield return null;
		}

		private IEnumerator C_SprintFOV(float newFOV, float time)
		{
			float elapsedTime = 0f;
			float startFOV = Cam.fieldOfView;
			while (elapsedTime < time)
			{
				Cam.fieldOfView = Mathf.Lerp(startFOV, newFOV, Mathf.SmoothStep(0f, 1f, elapsedTime / time));
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Cam.fieldOfView = newFOV;
			yield return null;
		}

		public virtual void Target_Set(Transform newTransform)
		{
			Transform target = (DefaultTarget = newTransform);
			Target = target;
		}

		public virtual void Target_Set_Temporal(Transform newTransform)
		{
			Target = newTransform;
		}

		public virtual void Target_Restore()
		{
			Target = DefaultTarget;
		}

		public virtual void Target_Set(GameObject newGO)
		{
			Target_Set(newGO.transform);
		}

		public virtual void Target_Set_Temporal(GameObject newGO)
		{
			Target_Set_Temporal(newGO.transform);
		}

		public virtual void ForceUpdateMode(bool val)
		{
			updateType = (val ? UpdateType.LateUpdate : defaultUpdate);
		}
	}
}
