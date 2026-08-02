using System;
using UnityEngine;

namespace JUTPS.CameraSystems
{
	public class JUCameraController : MonoBehaviour
	{
		[HideInInspector]
		public bool Aiming;

		[HideInInspector]
		public bool IsTransitioningToCustomState;

		[HideInInspector]
		public bool IsTargetInForward;

		[HideInInspector]
		public Camera mCamera;

		[Header("Camera Settings")]
		public Transform TargetToFollow;

		public LayerMask CameraCollisionLayerMask;

		public LayerMask CrosshairRaycastLayerMask;

		public bool LockCursor = true;

		public bool HideCursor = true;

		public CameraState[] CustomCameraStates = new CameraState[1]
		{
			new CameraState("Example State", 2f, 15f, 80f)
		};

		private CameraState CurrentCameraState = new CameraState("Standard Camera State");

		private TSPlayerController playerController;

		[Header("Camera Rotation")]
		[Range(0f, 5f)]
		public float GeneralSensibility = 1f;

		[Range(0f, 5f)]
		public float GeneralVerticalSensibility = 1f;

		[HideInInspector]
		public float rotX;

		[HideInInspector]
		public float rotY;

		[HideInInspector]
		public float rotxtarget;

		[HideInInspector]
		public float rotytarget;

		[Header("Camera Recoil Reaction")]
		public bool CameraRecoilReaction = true;

		public bool RecoilRotateCamera;

		[Range(0f, 2f)]
		public float CameraRecoilSensibility = 0.5f;

		public CameraState GetCurrentCameraState => CurrentCameraState;

		public static event Action event_OnCameraRotate;

		public static event Action event_OnCameraMove;

		public static event Action event_OnCameraStateChange;

		protected virtual void OnEnable()
		{
			playerController = GetComponentInParent<TSPlayerController>();
			event_OnCameraRotate += OnCameraRotate;
			event_OnCameraMove += OnCameraMove;
			event_OnCameraStateChange += OnCameraStateChange;
		}

		protected virtual void OnDestroy()
		{
			event_OnCameraRotate -= OnCameraRotate;
			event_OnCameraMove -= OnCameraMove;
			event_OnCameraStateChange -= OnCameraStateChange;
		}

		protected virtual void Start()
		{
			mCamera = base.gameObject.GetComponentInChildren<Camera>();
			GameObject gameObject = playerController.gameObject;
			if (TargetToFollow == null && gameObject != null)
			{
				TargetToFollow = gameObject.transform;
			}
			if (TargetToFollow != null)
			{
				SetCameraRotation(0f, TargetToFollow.eulerAngles.y, SmoothRotate: false);
			}
			LockMouse(LockCursor, HideCursor);
			Time.fixedDeltaTime = 0.015f;
		}

		protected virtual void OnCameraRotate()
		{
		}

		protected virtual void OnCameraMove()
		{
		}

		protected virtual void OnCameraStateChange()
		{
		}

		public void SetCameraStateTransition(CameraState current, CameraState target, float speed = 8f, bool lerp = true)
		{
			if (speed != -1f)
			{
				if (lerp)
				{
					current.Distance = Mathf.Lerp(current.Distance, target.Distance, speed * Time.deltaTime);
					current.MovementSpeed = Mathf.Lerp(current.MovementSpeed, target.MovementSpeed, speed * Time.deltaTime);
					current.UpTargetOffset = Mathf.Lerp(current.UpTargetOffset, target.UpTargetOffset, speed * Time.deltaTime);
					current.ForwardTargetOffset = Mathf.Lerp(current.ForwardTargetOffset, target.ForwardTargetOffset, speed * Time.deltaTime);
					current.RightTargetOffset = Mathf.Lerp(current.RightTargetOffset, target.RightTargetOffset, speed * Time.deltaTime);
					current.CameraFieldOfView = Mathf.Lerp(current.CameraFieldOfView, target.CameraFieldOfView, speed * Time.deltaTime);
					current.RightCameraOffset = Mathf.Lerp(current.RightCameraOffset, target.RightCameraOffset, speed * Time.deltaTime);
					current.UpCameraOffset = Mathf.Lerp(current.UpCameraOffset, target.UpCameraOffset, speed * Time.deltaTime);
					current.ForwardCameraOffset = Mathf.Lerp(current.ForwardCameraOffset, target.ForwardCameraOffset, speed * Time.deltaTime);
					current.RotationSensibility = Mathf.Lerp(current.RotationSensibility, target.RotationSensibility, speed * Time.deltaTime);
					current.VerticalRotationSensibility = Mathf.Lerp(current.VerticalRotationSensibility, target.VerticalRotationSensibility, speed * Time.deltaTime);
					current.MaxRotation = Mathf.Lerp(current.MaxRotation, target.MaxRotation, speed * Time.deltaTime);
					current.MinRotation = Mathf.Lerp(current.MinRotation, target.MinRotation, speed * Time.deltaTime);
				}
				else
				{
					current.Distance = Mathf.MoveTowards(current.Distance, target.Distance, speed * Time.deltaTime);
					current.MovementSpeed = Mathf.MoveTowards(current.MovementSpeed, target.MovementSpeed, speed * Time.deltaTime);
					current.UpTargetOffset = Mathf.MoveTowards(current.UpTargetOffset, target.UpTargetOffset, speed * Time.deltaTime);
					current.ForwardTargetOffset = Mathf.MoveTowards(current.ForwardTargetOffset, target.ForwardTargetOffset, speed * Time.deltaTime);
					current.RightTargetOffset = Mathf.MoveTowards(current.RightTargetOffset, target.RightTargetOffset, speed * Time.deltaTime);
					current.CameraFieldOfView = Mathf.MoveTowards(current.CameraFieldOfView, target.CameraFieldOfView, speed * Time.deltaTime);
					current.RightCameraOffset = Mathf.MoveTowards(current.RightCameraOffset, target.RightCameraOffset, speed * Time.deltaTime);
					current.UpCameraOffset = Mathf.MoveTowards(current.UpCameraOffset, target.UpCameraOffset, speed * Time.deltaTime);
					current.ForwardCameraOffset = Mathf.MoveTowards(current.ForwardCameraOffset, target.ForwardCameraOffset, speed * Time.deltaTime);
					current.RotationSensibility = Mathf.MoveTowards(current.RotationSensibility, target.RotationSensibility, speed * Time.deltaTime);
					current.VerticalRotationSensibility = Mathf.MoveTowards(current.VerticalRotationSensibility, target.VerticalRotationSensibility, speed * Time.deltaTime);
					current.MaxRotation = Mathf.MoveTowards(current.MaxRotation, target.MaxRotation, speed * Time.deltaTime);
					current.MinRotation = Mathf.MoveTowards(current.MinRotation, target.MinRotation, speed * Time.deltaTime);
				}
			}
			else
			{
				current.Distance = target.Distance;
				current.MovementSpeed = target.MovementSpeed;
				current.UpTargetOffset = target.UpTargetOffset;
				current.ForwardTargetOffset = target.ForwardTargetOffset;
				current.RightTargetOffset = target.RightTargetOffset;
				current.CameraFieldOfView = target.CameraFieldOfView;
				current.RightCameraOffset = target.RightCameraOffset;
				current.UpCameraOffset = target.UpCameraOffset;
				current.ForwardCameraOffset = target.ForwardCameraOffset;
				current.RotationSensibility = target.RotationSensibility;
				current.VerticalRotationSensibility = target.RotationSensibility;
				current.MaxRotation = target.MaxRotation;
				current.MinRotation = target.MinRotation;
			}
			if (current.Distance == target.Distance && current.MovementSpeed == target.MovementSpeed && current.SettingsIDName != target.SettingsIDName)
			{
				OnCameraStateChange();
				current.SettingsIDName = target.SettingsIDName;
			}
			current.CollisionLayers = target.CollisionLayers;
		}

		public void SetCustomCameraStateTransition(CameraState current, string customCameraStateName, float speed = 8f)
		{
			CameraState cameraState = null;
			CameraState[] customCameraStates = CustomCameraStates;
			foreach (CameraState cameraState2 in customCameraStates)
			{
				if (cameraState2.StateName == customCameraStateName)
				{
					cameraState = cameraState2;
				}
			}
			if (cameraState == null)
			{
				Debug.LogWarning("Unable to find a Camera State with this name, please check if the name is correct", base.gameObject);
				return;
			}
			SetCameraStateTransition(current, cameraState, speed);
			IsTransitioningToCustomState = true;
		}

		public void DisableCustomStateTransitioningState()
		{
			IsTransitioningToCustomState = false;
		}

		public virtual void SetPivotCameraPosition(Vector3 TargetPosition, bool SmoothMove = true, float Speed = 0f)
		{
			if (base.transform.position != TargetPosition)
			{
				OnCameraMove();
			}
			if (SmoothMove)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, TargetPosition, (Speed != 0f) ? (Speed * Time.fixedDeltaTime) : (CurrentCameraState.MovementSpeed * Time.fixedDeltaTime));
			}
			else
			{
				base.transform.position = TargetPosition;
			}
		}

		public virtual void SetCameraPosition(Vector3 TargetPosition, bool SmoothMove = true, float Speed = 0f)
		{
			if (mCamera.transform.position != TargetPosition)
			{
				OnCameraMove();
			}
			if (SmoothMove)
			{
				mCamera.transform.position = Vector3.Lerp(base.transform.position, TargetPosition, (Speed != 0f) ? Speed : (CurrentCameraState.MovementSpeed * Time.fixedDeltaTime));
			}
			else
			{
				mCamera.transform.position = TargetPosition;
			}
		}

		public virtual void RotateCamera(float VerticalAxis, float HorizonalAxis, float LerpSpeed = 30f, Vector3 upward = default(Vector3), Transform AlternativeTargetToCalculate = null, bool UseTimeScale = true)
		{
			if (VerticalAxis != 0f && HorizonalAxis != 0f)
			{
				OnCameraRotate();
			}
			rotxtarget -= (UseTimeScale ? Time.timeScale : 1f) * GeneralVerticalSensibility * VerticalAxis * CurrentCameraState.RotationSensibility;
			rotytarget += (UseTimeScale ? Time.timeScale : 1f) * GeneralSensibility * HorizonalAxis * CurrentCameraState.RotationSensibility;
			rotxtarget = Mathf.Clamp(rotxtarget, CurrentCameraState.MinRotation, CurrentCameraState.MaxRotation);
			rotX = Mathf.Lerp(rotX, rotxtarget, LerpSpeed * Time.fixedDeltaTime * (UseTimeScale ? Time.timeScale : 1f));
			rotY = Mathf.Lerp(rotY, rotytarget, LerpSpeed * Time.fixedDeltaTime * (UseTimeScale ? Time.timeScale : 1f));
			Quaternion quaternion = Quaternion.Euler(new Vector3(rotX, rotY, 0f));
			if (AlternativeTargetToCalculate == null)
			{
				Quaternion rotation = TargetToFollow.root.rotation;
				rotation = Quaternion.AngleAxis(rotY, base.transform.up);
				rotation = Quaternion.AngleAxis(0f, base.transform.forward);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, rotation, 50f * Time.deltaTime);
			}
			else
			{
				Quaternion rotation2 = AlternativeTargetToCalculate.rotation;
				rotation2 = Quaternion.AngleAxis(rotY, base.transform.up);
				rotation2 = Quaternion.AngleAxis(0f, base.transform.forward);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, rotation2, 50f * Time.deltaTime);
			}
			mCamera.transform.parent.localRotation = Quaternion.FromToRotation(base.transform.up, upward) * quaternion;
		}

		public virtual void SetCameraRotation(float Xtarget, float Ytarget, bool SmoothRotate = true)
		{
			if (SmoothRotate)
			{
				rotxtarget = Xtarget;
				rotytarget = Ytarget;
			}
			else
			{
				rotxtarget = Xtarget;
				rotytarget = Ytarget;
				rotX = Xtarget;
				rotY = Ytarget;
			}
			if (rotX != Xtarget && rotY != Ytarget)
			{
				OnCameraRotate();
			}
		}

		public virtual void SetCameraCollision(LayerMask CollisionLayer, bool Enabled = true)
		{
			if (Enabled && Physics.Linecast(base.transform.position, mCamera.transform.position, out var hitInfo, CollisionLayer))
			{
				mCamera.transform.position = hitInfo.point + hitInfo.normal * 0.05f;
			}
		}

		public virtual void SetFieldOfView(float FOV)
		{
			if (mCamera.orthographic)
			{
				mCamera.orthographicSize = FOV / 10f;
				mCamera.fieldOfView = FOV;
			}
			else
			{
				mCamera.fieldOfView = FOV;
			}
		}

		public virtual void RecoilReaction(float Force)
		{
			if (CameraRecoilReaction)
			{
				if (RecoilRotateCamera)
				{
					rotxtarget -= CameraRecoilSensibility * Force;
					rotX -= CameraRecoilSensibility * Force;
					rotytarget += CameraRecoilSensibility * UnityEngine.Random.Range(0f - Force, Force);
				}
				else
				{
					rotX -= CameraRecoilSensibility * Force;
				}
			}
		}

		public static void LockMouse(bool Lock = true, bool Hide = true)
		{
			Cursor.lockState = (Lock ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !Hide;
		}

		public RaycastHit[] GetAllObjectsOnCameraCenter(float MaxCameraDistance, LayerMask Layer)
		{
			return Physics.RaycastAll(base.transform.position, base.transform.forward, MaxCameraDistance, Layer);
		}

		public GameObject GetObjectOnCameraCenter(float MaxCameraDistance, LayerMask Layer)
		{
			Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out var hitInfo, MaxCameraDistance, Layer);
			if (!(hitInfo.collider == null))
			{
				return hitInfo.collider.gameObject;
			}
			return null;
		}

		protected virtual void OnDrawGizmos()
		{
			if (mCamera == null)
			{
				if (base.gameObject.GetComponentInChildren<Camera>() != null)
				{
					mCamera = base.gameObject.GetComponentInChildren<Camera>();
				}
				return;
			}
			float num = mCamera.nearClipPlane + 0.015f;
			Vector3 vector = mCamera.transform.position + mCamera.transform.forward * num;
			Color color = new Color(1f, 1f, 1f, 0.5f);
			Gizmos.color = Color.white;
			Gizmos.DrawLine(base.transform.position, vector);
			Gizmos.DrawWireSphere(mCamera.transform.position, 0.01f);
			Gizmos.DrawWireSphere(base.transform.position, 0.03f);
			Gizmos.color = color;
			Gizmos.DrawSphere(base.transform.position, 0.03f);
			Gizmos.color = new Color(1f, 1f, 1f, 0.1f);
			Gizmos.DrawLine(vector + mCamera.transform.right * num, vector - mCamera.transform.right * num);
			Gizmos.DrawLine(vector + mCamera.transform.up * num, vector - mCamera.transform.up * num);
		}
	}
}
