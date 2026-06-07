using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Utilities
{
	[DefaultExecutionOrder(10000)]
	[AddComponentMenu("Malbers/Utilities/Aiming/Aim")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/utilities/aim")]
	public class Aim : MonoBehaviour, IAim, IMLayer, IAnimatorListener
	{
		[SerializeField]
		[Tooltip("Is the Aim Active")]
		protected BoolReference m_active = new BoolReference(value: true);

		[SerializeField]
		[Tooltip("Aim Origin Reference (Required)")]
		[ContextMenuItem("Head as AimOrigin", "HeadAimOrigin")]
		[RequiredField]
		protected Transform m_aimOrigin;

		[SerializeField]
		[Tooltip("Smoothness Lerp value to change from Active to Disable")]
		protected float m_Smoothness = 10f;

		[SerializeField]
		[Tooltip("Smoothness Lerp value  change Horizontal Aim Angle from 180 to -180")]
		[Min(0f)]
		protected float horizontalLerp = 10f;

		[SerializeField]
		[Tooltip("Layers inlcuded on the Aiming Logic")]
		protected LayerReference m_aimLayer = new LayerReference(-1);

		[SerializeField]
		[Tooltip("Does the Aiming Logic ignore Colliders??")]
		protected QueryTriggerInteraction m_Triggers = QueryTriggerInteraction.Ignore;

		[SerializeField]
		[Tooltip("Forced a Target on the Aiming Logic. Calculate the Aim from the Aim Origin to a Target")]
		protected TransformReference m_AimTarget = new TransformReference();

		[Tooltip("Transform Helper that stores the position of the Hit")]
		public TransformReference m_AimPosition = new TransformReference();

		[SerializeField]
		[Tooltip("Set a Transform Hierarchy to Ignore on the Aim Ray")]
		protected TransformReference m_Ignore = new TransformReference();

		[SerializeField]
		[Tooltip("Camera Reference used for calculatin the Aim logic from the Camera Center. By Default will use the Camera.Main Transform")]
		protected TransformReference m_camera = new TransformReference();

		[SerializeField]
		[Tooltip("Cast the Camera Ray a bit forward to avoid colliding with near the camera colliders ")]
		protected FloatReference m_forwardCam = new FloatReference(0.2f);

		protected Camera cam;

		[SerializeField]
		[Tooltip("Do the raycast every X Cycles to increase performance")]
		[Min(1f)]
		protected int m_cycles = 1;

		protected int CurrentCycles;

		[SerializeField]
		[Tooltip("Default screen center")]
		protected Vector2Reference m_screenCenter = new Vector2Reference(0.5f, 0.5f);

		[Tooltip("Does the Character Requires the Camera to Find Aiming... Disable this for AI Characters")]
		public BoolReference m_UseCamera = new BoolReference(value: true);

		[SerializeField]
		[Tooltip("This Parameter is used to Change the Current Camera to the Side of which the Character is relative to Camera or the Target")]
		private AimSide m_AimSide;

		[Tooltip("Update mode for the Aim Logic")]
		public UpdateType updateMode = UpdateType.LateUpdate;

		[Tooltip("Maximun Distance from the Origin to the Possible Target")]
		public float MaxDistance = 100f;

		[SerializeField]
		[Tooltip("Use Raycasting for finding the Hit Point. Disable this if you don't need to know which was the object hitted.")]
		private BoolReference m_UseRaycasting = new BoolReference(value: true);

		[Tooltip("Radius for the Sphere Casting, if this is set to Zero they I will use a Ray Casting")]
		public FloatReference rayRadius = new FloatReference(0f);

		[Tooltip("Maximum Ray Hits for the Ray casting")]
		public int RayHits = 5;

		public TransformEvent OnAimRayTarget = new TransformEvent();

		public Vector3Event OnScreenCenter = new Vector3Event();

		public IntEvent OnAimSide = new IntEvent();

		public BoolEvent OnAiming = new BoolEvent();

		public BoolEvent OnUsingTarget = new BoolEvent();

		public TransformEvent OnHit = new TransformEvent();

		public TransformEvent OnSetTarget = new TransformEvent();

		public UnityEvent OnClearTarget = new UnityEvent();

		public bool debug;

		protected string hitName;

		protected int hitcount;

		internal int hash_AimHorizontal;

		internal int hash_AimVertical;

		public Animator m_Animator;

		public string m_AimHorizontal = "AimHorizontal";

		public string m_AimVertical = "AimVertical";

		public FloatReference AngleLerp = new FloatReference();

		protected Transform defaultOrigin;

		protected Transform OwnObjectCore;

		public IAimTarget LastAimTarget;

		protected Transform m_AimTargetAssist;

		protected Transform AimHitTransform;

		public int EditorTab1;

		private Collider LastCollider;

		public Renderer TargetRenderer { get; protected set; }

		public Vector3 TargetCenter
		{
			get
			{
				if (!(TargetRenderer != null))
				{
					return AimTarget.position;
				}
				return TargetRenderer.bounds.center;
			}
		}

		public Transform MainCamera
		{
			get
			{
				return m_camera.Value;
			}
			set
			{
				m_camera.Value = value;
			}
		}

		public bool UseCamera
		{
			get
			{
				return m_UseCamera.Value;
			}
			set
			{
				m_UseCamera.Value = value;
			}
		}

		public float ForwardCam
		{
			get
			{
				return m_forwardCam.Value;
			}
			set
			{
				m_forwardCam.Value = value;
			}
		}

		public bool UseRaycasting
		{
			get
			{
				return m_UseRaycasting.Value;
			}
			set
			{
				m_UseRaycasting.Value = value;
			}
		}

		public Transform AimOrigin
		{
			get
			{
				return m_aimOrigin;
			}
			set
			{
				if ((bool)value)
				{
					m_aimOrigin = value;
				}
				else
				{
					m_aimOrigin = defaultOrigin;
				}
			}
		}

		public Transform IgnoreTransform
		{
			get
			{
				return m_Ignore.Value;
			}
			set
			{
				m_Ignore.Value = value;
			}
		}

		public Vector3 AimDirection { get; protected set; }

		public Vector3 RawAimDirection { get; protected set; }

		public bool IsTargetAssist { get; protected set; }

		public Vector3 AimPoint { get; protected set; }

		public Vector3 RawPoint { get; protected set; }

		public float HorizontalAngle_Raw { get; set; }

		public float VerticalAngle_Raw { get; set; }

		public float HorizontalAngle { get; set; }

		public float VerticalAngle { get; set; }

		public Vector3 ScreenCenter { get; protected set; }

		public virtual bool Active
		{
			get
			{
				return m_active;
			}
			set
			{
				BoolReference active = m_active;
				bool value2 = (base.enabled = value);
				active.Value = value2;
				if (value)
				{
					EnterAim();
				}
				else
				{
					ExitAim();
				}
			}
		}

		public RaycastHit AimHit { get; protected set; }

		protected RaycastHit aimHit => AimHit;

		public virtual Transform AimRayTargetAssist
		{
			get
			{
				return m_AimTargetAssist;
			}
			set
			{
				if (m_AimTargetAssist != value)
				{
					m_AimTargetAssist = value;
					OnAimRayTarget.Invoke(value);
				}
			}
		}

		public bool AimingSide { get; protected set; }

		public virtual Transform AimTarget
		{
			get
			{
				return m_AimTarget.Value;
			}
			set
			{
				if (!(m_AimTarget.Value != value))
				{
					return;
				}
				if (value != null)
				{
					AimTarget componentInChildren = value.GetComponentInChildren<AimTarget>();
					if (componentInChildren != null)
					{
						m_AimTarget.Value = componentInChildren.AimPoint;
					}
					else
					{
						m_AimTarget.Value = value;
					}
					base.enabled = true;
				}
				else
				{
					m_AimTarget.Value = null;
					OnClearTarget.Invoke();
				}
				if (debug)
				{
					Debug.Log("<B>[" + base.name + "]</B> - New Target Set <B>[" + ((value != null) ? value.name : "Null") + "]</B>", this);
				}
				OnSetTarget.Invoke(value);
				OnUsingTarget.Invoke(value != null);
				OnAimRayTarget.Invoke(value);
			}
		}

		public Transform AimPosition
		{
			get
			{
				return m_AimPosition.Value;
			}
			set
			{
				m_AimPosition.Value = value;
			}
		}

		public LayerMask Layer
		{
			get
			{
				return m_aimLayer.Value;
			}
			set
			{
				m_aimLayer.Value = value;
			}
		}

		public QueryTriggerInteraction TriggerInteraction
		{
			get
			{
				return m_Triggers;
			}
			set
			{
				m_Triggers = value;
			}
		}

		public virtual AimSide AimSide
		{
			get
			{
				return m_AimSide;
			}
			set
			{
				m_AimSide = value;
				switch (value)
				{
				case AimSide.None:
					OnAimSide.Invoke(0);
					break;
				case AimSide.Left:
					OnAimSide.Invoke(-1);
					break;
				case AimSide.Right:
					OnAimSide.Invoke(1);
					break;
				}
			}
		}

		public RaycastHit[] ArrayHits { get; protected set; }

		Transform IAnimatorListener.transform => base.transform;

		protected virtual void Awake()
		{
			FindCamera();
			m_Animator = GetComponentInParent<Animator>();
			if ((bool)m_Animator)
			{
				hash_AimHorizontal = m_Animator.TryOptionalParameter(m_AimHorizontal);
				hash_AimVertical = m_Animator.TryOptionalParameter(m_AimVertical);
			}
			if ((bool)AimOrigin)
			{
				defaultOrigin = AimOrigin;
			}
			else
			{
				AimOrigin = (defaultOrigin = base.transform);
			}
			OwnObjectCore = base.transform.FindObjectCore();
			GetCenterScreen();
			CurrentCycles = UnityEngine.Random.Range(0, 999999);
		}

		protected virtual void FindCamera()
		{
			if (MainCamera == null)
			{
				cam = MTools.FindMainCamera();
				if ((bool)cam)
				{
					MainCamera = cam.transform;
				}
			}
			else
			{
				cam = MainCamera.GetComponent<Camera>();
			}
		}

		private void OnEnable()
		{
			CalculateAiming();
			if (AimTarget != null)
			{
				OnSetTarget.Invoke(AimTarget);
				OnUsingTarget.Invoke(AimTarget != null);
				OnAimRayTarget.Invoke(AimTarget);
			}
			else
			{
				OnClearTarget.Invoke();
			}
			if (!m_camera.UseConstant && (bool)m_camera.Variable)
			{
				TransformVar variable = m_camera.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Combine(variable.OnValueChanged, new Action<Transform>(SearchCamera));
			}
		}

		private void OnDisable()
		{
			if (!m_camera.UseConstant && (bool)m_camera.Variable)
			{
				TransformVar variable = m_camera.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Remove(variable.OnValueChanged, new Action<Transform>(SearchCamera));
			}
			LastAimTarget?.IsBeenAimed(enter: false, this);
			LastAimTarget = null;
			AimHit = default(RaycastHit);
			AimHitTransform = null;
			HorizontalAngle = 0f;
			VerticalAngle = 0f;
			OnHit.Invoke(null);
			OnAiming.Invoke(arg0: false);
			OnAimRayTarget.Invoke(null);
		}

		private void SearchCamera(Transform obj)
		{
			FindCamera();
		}

		private void FixedUpdate()
		{
			if (updateMode == UpdateType.FixedUpdate)
			{
				UpdateLogic(Time.fixedDeltaTime);
			}
		}

		private void LateUpdate()
		{
			if (updateMode == UpdateType.LateUpdate)
			{
				UpdateLogic(Time.deltaTime);
			}
		}

		private void UpdateLogic(float time)
		{
			if (Active)
			{
				CurrentCycles++;
				bool flag = UseRaycasting && CurrentCycles % m_cycles == 0;
				if (flag)
				{
					CurrentCycles = 0;
				}
				AimLogic(flag);
				SmoothValues(time);
				CalculateAngles(time);
				if ((bool)m_Animator)
				{
					TryAnimParameter(hash_AimHorizontal, HorizontalAngle);
					TryAnimParameter(hash_AimVertical, VerticalAngle);
				}
				AimDirection = Vector3.Lerp(AimDirection, RawAimDirection.normalized, m_Smoothness * time);
			}
		}

		public void EnterAim()
		{
			CalculateAiming();
			OnAiming.Invoke(arg0: true);
			if ((bool)AimPosition)
			{
				AimPosition.gameObject.SetActive(value: true);
			}
		}

		public void ExitAim()
		{
			GetCenterScreen();
			OnScreenCenter.Invoke(ScreenCenter);
			OnAimRayTarget.Invoke(null);
			AimSide = AimSide.None;
			OnAiming.Invoke(arg0: false);
			if ((bool)AimPosition)
			{
				AimPosition.gameObject.SetActive(value: false);
			}
		}

		public virtual void TryAnimParameter(int Hash, float value)
		{
			if (Hash != 0)
			{
				m_Animator.SetFloat(Hash, value);
			}
		}

		public virtual void AimLogic(bool useRaycasting)
		{
			if ((bool)AimTarget)
			{
				AimHit = DirectionFromTarget(useRaycasting);
				RawPoint = (UseRaycasting ? AimHit.point : TargetCenter);
			}
			else if (UseCamera && (bool)MainCamera && cam != null)
			{
				AimHit = DirectionFromCamera(useRaycasting);
				RawPoint = AimHit.point;
			}
			else
			{
				AimHit = DirectionFromDirection(useRaycasting);
				RawPoint = AimHit.point;
			}
			if (useRaycasting && AimHitTransform != AimHit.transform)
			{
				AimHitTransform = AimHit.transform;
				OnHit.Invoke(AimHitTransform);
			}
		}

		public void CalculateAiming()
		{
			if (Active)
			{
				AimLogic(UseRaycasting);
				SmoothValues(0f);
				CalculateAngles(0f);
			}
		}

		public void Active_Set(bool value)
		{
			Active = value;
		}

		public void Active_Toggle()
		{
			Active = !Active;
		}

		public void SetTarget(Transform target)
		{
			AimTarget = target;
		}

		public void SetTarget(TransformVar target)
		{
			AimTarget = target.Value;
		}

		public void SetTarget(GameObjectVar target)
		{
			AimTarget = target.Value.transform;
		}

		public void SetTarget(Component target)
		{
			SetTarget(target.transform);
		}

		public void SetTarget(GameObject target)
		{
			SetTarget(target.transform);
		}

		public void ClearTarget()
		{
			AimTarget = null;
		}

		public void CalculateAngles(float time)
		{
			Vector3 vector = AimPoint - OwnObjectCore.position;
			AimingSide = Vector3.Dot(vector, base.transform.right) < 0f;
			Vector3 normalized = Vector3.ProjectOnPlane(vector, Vector3.up).normalized;
			Vector3 normalized2 = Vector3.ProjectOnPlane(base.transform.forward, Vector3.up).normalized;
			HorizontalAngle_Raw = Vector3.SignedAngle(normalized2, normalized, Vector3.up);
			VerticalAngle_Raw = (Vector3.Angle(base.transform.up, AimDirection) - 90f) * -1f;
			HorizontalAngle = ((horizontalLerp > 0f) ? Mathf.Lerp(HorizontalAngle, HorizontalAngle_Raw, time * horizontalLerp) : HorizontalAngle_Raw);
			VerticalAngle = VerticalAngle_Raw;
		}

		private void SmoothValues(float time)
		{
			float num = time * m_Smoothness;
			num = Mathf.Sin(num * MathF.PI * 0.5f);
			bool flag = m_Smoothness == 0f || time == 0f;
			AimPoint = (flag ? RawPoint : Vector3.Lerp(AimPoint, RawPoint, num));
			if (AimPosition != null)
			{
				AimPosition.position = AimPoint;
				AimPosition.up = (flag ? AimHit.normal : Vector3.Lerp(AimPosition.up, AimHit.normal, num));
			}
		}

		private void GetCenterScreen()
		{
			Vector3 vector;
			if (cam != null)
			{
				vector = new Vector3((float)Screen.width * m_screenCenter.Value.x * cam.rect.width, (float)Screen.height * m_screenCenter.Value.y * cam.rect.height);
				vector += new Vector3((float)Screen.width * cam.rect.x, (float)Screen.height * cam.rect.y);
			}
			else
			{
				vector = new Vector3((float)Screen.width * m_screenCenter.Value.x, (float)Screen.height * m_screenCenter.Value.y);
			}
			if (vector != ScreenCenter)
			{
				ScreenCenter = vector;
				OnScreenCenter.Invoke(ScreenCenter);
			}
		}

		public RaycastHit DirectionFromCamera(bool useray)
		{
			RawAimDirection = cam.transform.forward;
			Ray ray;
			if (ScreenCenter != Vector3.zero)
			{
				GetCenterScreen();
				ray = cam.ScreenPointToRay(ScreenCenter);
			}
			else
			{
				ray = new Ray(cam.transform.position, cam.transform.forward);
			}
			ray.origin += cam.transform.forward * ForwardCam;
			if (debug)
			{
				Debug.DrawRay(ray.origin, cam.transform.forward * MaxDistance, Color.gray);
			}
			Vector3 point = ray.GetPoint(AimHit.distance);
			RaycastHit hit = new RaycastHit
			{
				distance = MaxDistance,
				point = point
			};
			return CalculateRayCasting(UseRaycasting, ray, ref hit);
		}

		public RaycastHit DirectionFromDirection(bool UseRaycasting)
		{
			RawAimDirection = AimOrigin.forward;
			Ray ray = new Ray(AimOrigin.position, RawAimDirection);
			RaycastHit hit = new RaycastHit
			{
				distance = MaxDistance,
				point = ray.GetPoint(MaxDistance)
			};
			return CalculateRayCasting(UseRaycasting, ray, ref hit);
		}

		public RaycastHit DirectionFromTarget(bool UseRaycasting)
		{
			Vector3 targetCenter = TargetCenter;
			RawAimDirection = AimOrigin.DirectionTo(targetCenter);
			Ray ray = new Ray(AimOrigin.position, RawAimDirection);
			RaycastHit hit = new RaycastHit
			{
				distance = MaxDistance,
				point = targetCenter
			};
			return CalculateRayCasting(UseRaycasting, ray, ref hit);
		}

		private RaycastHit CalculateRayCasting(bool UseRaycasting, Ray ray, ref RaycastHit hit)
		{
			if (UseRaycasting)
			{
				ArrayHits = new RaycastHit[RayHits];
				if ((float)rayRadius > 0f)
				{
					hitcount = Physics.SphereCastNonAlloc(ray, rayRadius, ArrayHits, MaxDistance, Layer, m_Triggers);
				}
				else
				{
					hitcount = Physics.RaycastNonAlloc(ray, ArrayHits, MaxDistance, Layer, m_Triggers);
				}
				if (hitcount > 0)
				{
					RaycastHit[] arrayHits = ArrayHits;
					for (int i = 0; i < arrayHits.Length; i++)
					{
						RaycastHit raycastHit = arrayHits[i];
						if (!(raycastHit.point == Vector3.zero))
						{
							if (raycastHit.transform == null)
							{
								break;
							}
							if (!SkipConditions(raycastHit.transform) && hit.distance > raycastHit.distance)
							{
								hit = raycastHit;
							}
						}
					}
				}
				return GetAimAssist(hit);
			}
			return hit;
		}

		private bool SkipConditions(Transform t)
		{
			if (t.SameHierarchy(IgnoreTransform))
			{
				return true;
			}
			if (t.SameHierarchy(OwnObjectCore))
			{
				return true;
			}
			if (t == OwnObjectCore)
			{
				return true;
			}
			if (t.SameHierarchy(AimOrigin))
			{
				return true;
			}
			return false;
		}

		private RaycastHit GetAimAssist(RaycastHit hit)
		{
			if (LastCollider != hit.collider)
			{
				LastCollider = hit.collider;
				IAimTarget aimTarget = ((LastCollider != null) ? hit.collider.FindInterface<IAimTarget>() : null);
				IsTargetAssist = false;
				if (aimTarget != null)
				{
					if (aimTarget.AimAssist)
					{
						IsTargetAssist = true;
						AimRayTargetAssist = aimTarget.AimPoint;
						hit.point = aimTarget.AimPoint.position;
					}
					if (aimTarget != LastAimTarget)
					{
						LastAimTarget?.IsBeenAimed(enter: false, this);
						LastAimTarget = aimTarget;
						LastAimTarget.IsBeenAimed(enter: true, this);
					}
				}
				else
				{
					LastAimTarget?.IsBeenAimed(enter: false, this);
					LastAimTarget = null;
					AimRayTargetAssist = null;
				}
			}
			return hit;
		}

		public void ClearAimAssist()
		{
			LastAimTarget = null;
			IsTargetAssist = false;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		private void HeadAimOrigin()
		{
			Animator animator = base.transform.FindComponent<Animator>();
			if ((bool)animator)
			{
				if (animator.isHuman)
				{
					Transform boneTransform = animator.GetBoneTransform(HumanBodyBones.Head);
					if ((bool)boneTransform)
					{
						AimOrigin = boneTransform;
					}
				}
				else
				{
					AimOrigin = animator.transform.FindGrandChild("Head");
				}
			}
			MTools.SetDirty(this);
		}
	}
}
