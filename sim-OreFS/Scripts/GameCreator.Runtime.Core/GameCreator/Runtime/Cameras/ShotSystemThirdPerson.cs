using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemThirdPerson : TShotSystem
	{
		[Serializable]
		public class Align
		{
			[SerializeField]
			private bool m_AutoAlign;

			[SerializeField]
			private float m_Delay = 3f;

			[SerializeField]
			private float m_SmoothTime = 3f;

			public bool AutoAlign
			{
				get
				{
					return m_AutoAlign;
				}
				set
				{
					m_AutoAlign = value;
				}
			}

			public float Delay
			{
				get
				{
					return m_Delay;
				}
				set
				{
					m_Delay = value;
				}
			}

			public float SmoothTime
			{
				get
				{
					return m_SmoothTime;
				}
				set
				{
					m_SmoothTime = value;
				}
			}
		}

		public static readonly int ID = "ShotSystemThirdPerson".GetHashCode();

		private const float MIN_RADIUS = 0.01f;

		[SerializeField]
		private PropertyGetGameObject m_Pivot = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDecimal m_Shoulder = GetDecimalDecimal.Create(0.5f);

		[SerializeField]
		private PropertyGetDecimal m_Lift = GetDecimalDecimal.Create(0.5f);

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalDecimal.Create(5f);

		[SerializeField]
		private InputPropertyValueVector2 m_InputRotate = InputValueVector2MotionSecondary.Create();

		[SerializeField]
		private PropertyGetDecimal m_SensitivityX = GetDecimalConstantOne.Create;

		[SerializeField]
		private PropertyGetDecimal m_SensitivityY = GetDecimalConstantOne.Create;

		[SerializeField]
		[Range(1f, 179f)]
		private float m_MaxPitch = 150f;

		[SerializeField]
		private EnablerAngle180 m_MaxYaw = new EnablerAngle180(isEnabled: false, 120f);

		[SerializeField]
		private PropertyGetDecimal m_SmoothTime = GetDecimalDecimal.Create(0.15f);

		[SerializeField]
		private Align m_Align = new Align();

		[NonSerialized]
		private ShotSystemZoom m_Zoom;

		[NonSerialized]
		private ThirdPersonAim m_Aim;

		[NonSerialized]
		private Vector2 m_CurrentRotation = Vector2.zero;

		[NonSerialized]
		private Vector2 m_TargetRotation = Vector2.zero;

		[NonSerialized]
		private float m_VelocityRotationX;

		[NonSerialized]
		private float m_VelocityRotationY;

		[NonSerialized]
		private float m_VelocityAlign;

		[NonSerialized]
		private float m_LastInputTime;

		public override int Id => ID;

		[field: NonSerialized]
		public GameObject Pivot { get; private set; }

		[field: NonSerialized]
		public Vector3 PivotPosition { get; private set; }

		[field: NonSerialized]
		public float Radius { get; private set; }

		public Vector2 Sensitivity
		{
			set
			{
				m_SensitivityX = new PropertyGetDecimal(value.x);
				m_SensitivityY = new PropertyGetDecimal(value.y);
			}
		}

		public float MaxPitch
		{
			get
			{
				return m_MaxPitch;
			}
			set
			{
				m_MaxPitch = value;
			}
		}

		public float Pitch
		{
			get
			{
				return m_TargetRotation.x;
			}
			set
			{
				m_TargetRotation.x = value;
			}
		}

		public float Yaw
		{
			get
			{
				return m_TargetRotation.y;
			}
			set
			{
				m_TargetRotation.y = value;
			}
		}

		public Align Alignment => m_Align;

		public void SetRotation(Vector2 rotation)
		{
			rotation.x = QuaternionUtils.Convert180(rotation.x);
			rotation.y = QuaternionUtils.Convert180(rotation.y);
			m_CurrentRotation = rotation;
			m_TargetRotation = rotation;
			m_VelocityRotationX = 0f;
			m_VelocityRotationY = 0f;
		}

		public void SetRotation(Quaternion rotation)
		{
			Vector2 rotation2 = new Vector2(rotation.eulerAngles.x, rotation.eulerAngles.y);
			SetRotation(rotation2);
		}

		public void SetDirection(Vector3 direction)
		{
			Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
			SetRotation(rotation);
		}

		public void Aim(float shoulder, float lift, float radius, float duration)
		{
			m_Aim.Switch(shoulder, lift, radius, Quaternion.identity, duration);
		}

		public void Aim(float shoulder, float lift, float radius, Vector3 focus, float duration)
		{
			if (PivotPosition == focus)
			{
				return;
			}
			Quaternion quaternion = Quaternion.Euler(m_CurrentRotation) * m_Aim.Aim;
			Vector3 rhs = quaternion * Vector3.forward;
			Vector3 normalized = Vector3.Cross(Vector3.up, rhs).normalized;
			if (!(normalized == Vector3.zero))
			{
				Vector3 pivotPosition = PivotPosition;
				pivotPosition += normalized * (shoulder - m_Aim.Shoulder);
				pivotPosition += Vector3.up * (lift - m_Aim.Lift);
				Vector3 normalized2 = (focus - pivotPosition).normalized;
				if (!(normalized2 == Vector3.zero))
				{
					Quaternion rotation = Quaternion.LookRotation(normalized2);
					SetRotation(rotation);
					Quaternion aim = quaternion * Quaternion.Inverse(rotation);
					m_Aim.Switch(shoulder, lift, radius, aim, duration);
				}
			}
		}

		public override void OnAwake(TShotType shotType)
		{
			base.OnAwake(shotType);
			m_Zoom = shotType.GetSystem(ShotSystemZoom.ID) as ShotSystemZoom;
			m_InputRotate.OnStartup();
			m_Aim = new ThirdPersonAim(shotType as ShotTypeThirdPerson);
		}

		public override void OnEnable(TShotType shotType, TCamera camera)
		{
			base.OnEnable(shotType, camera);
			SetRotation(camera.transform.rotation);
		}

		public override void OnDestroy(TShotType shotType)
		{
			base.OnDestroy(shotType);
			m_InputRotate.OnDispose();
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			m_Aim.Update((float)m_Shoulder.Get(shotType.Args), (float)m_Lift.Get(shotType.Args), (float)m_Radius.Get(shotType.Args));
			Pivot = m_Pivot.Get(shotType.Args);
			UpdateInput(shotType);
			CalculateDistance();
			CalculatePositions();
			UpdateOrbit(shotType);
			UpdateLook(shotType);
		}

		private void UpdateInput(TShotType shotType)
		{
			m_InputRotate.OnUpdate();
			if (shotType.IsActive)
			{
				double num = m_SensitivityX.Get(shotType.Args);
				double num2 = m_SensitivityY.Get(shotType.Args);
				Vector2 vector = m_InputRotate.Read();
				if (vector == Vector2.zero)
				{
					ComputeAlign(shotType);
				}
				else
				{
					ComputeInput(shotType, new Vector2(vector.x * (float)num, vector.y * (float)num2));
				}
			}
			ConstrainPitch();
			ConstrainYaw();
			float smoothTime = (float)m_SmoothTime.Get(shotType.Args);
			m_CurrentRotation = new Vector2(GetRotationDamp(m_CurrentRotation.x, m_TargetRotation.x, ref m_VelocityRotationX, smoothTime, shotType.ShotCamera.TimeMode.DeltaTime), GetRotationDamp(m_CurrentRotation.y, m_TargetRotation.y, ref m_VelocityRotationY, smoothTime, shotType.ShotCamera.TimeMode.DeltaTime));
		}

		private void UpdateOrbit(TShotType shotType)
		{
			Vector3 vector = Quaternion.Euler(m_CurrentRotation) * m_Aim.Aim * Vector3.forward;
			Vector3 position = PivotPosition - vector * Radius;
			shotType.Position = position;
		}

		private void UpdateLook(TShotType shotType)
		{
			Quaternion quaternion = Quaternion.Euler(m_CurrentRotation) * m_Aim.Aim;
			shotType.Rotation = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, 0f);
		}

		private void CalculateDistance()
		{
			float minDistance = m_Zoom.MinDistance;
			float num = Mathf.Max(0.01f, m_Aim.Radius - minDistance);
			Radius = minDistance + num * m_Zoom.Level;
		}

		private bool CalculatePositions()
		{
			if (Pivot == null)
			{
				return false;
			}
			Transform transform = Pivot.transform;
			Vector3 rhs = Quaternion.Euler(m_CurrentRotation) * m_Aim.Aim * Vector3.forward;
			Vector3 normalized = Vector3.Cross(Vector3.up, rhs).normalized;
			PivotPosition = transform.position;
			PivotPosition += normalized * m_Aim.Shoulder;
			PivotPosition += Vector3.up * m_Aim.Lift;
			return true;
		}

		private float GetRotationDamp(float current, float target, ref float velocity, float smoothTime, float deltaTime)
		{
			if (deltaTime <= float.Epsilon)
			{
				return current;
			}
			return Mathf.SmoothDamp(current, target, ref velocity, smoothTime, float.PositiveInfinity, deltaTime);
		}

		private void ConstrainPitch()
		{
			float num = m_MaxPitch * 0.5f;
			m_TargetRotation.x = Mathf.Clamp(m_TargetRotation.x, 0f - num, num);
		}

		private void ConstrainYaw()
		{
			if (m_MaxYaw.IsEnabled)
			{
				float num = m_MaxYaw.Value * 0.5f;
				if (Pivot != null)
				{
					float y = Pivot.transform.rotation.eulerAngles.y;
					float num2 = QuaternionUtils.ClampAngle(m_TargetRotation.y - y, 0f - num, num);
					m_TargetRotation.y = num2 + y;
				}
			}
		}

		private void ComputeAlign(TShotType shotType)
		{
			float time = shotType.ShotCamera.TimeMode.Time;
			if (m_Align.AutoAlign && time - m_LastInputTime > m_Align.Delay && Pivot != null)
			{
				Quaternion rotation = Pivot.transform.rotation;
				float deltaTime = shotType.ShotCamera.TimeMode.DeltaTime;
				if (deltaTime > float.Epsilon)
				{
					m_TargetRotation.y = Mathf.SmoothDampAngle(m_TargetRotation.y, rotation.eulerAngles.y, ref m_VelocityAlign, m_Align.SmoothTime, float.PositiveInfinity, deltaTime);
				}
			}
		}

		private void ComputeInput(IShotType shotType, Vector2 deltaInput)
		{
			m_LastInputTime = shotType.ShotCamera.TimeMode.Time;
			m_VelocityAlign = 0f;
			m_TargetRotation += new Vector2(deltaInput.y, deltaInput.x);
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType, TShotSystem.GIZMOS_COLOR_ACTIVE);
		}

		private void DoDrawGizmos(TShotType shotType, Color color)
		{
			Gizmos.color = color;
		}
	}
}
