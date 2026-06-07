using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemFirstPerson : TShotSystem
	{
		public static readonly int ID = "ShotSystemFirstPerson".GetHashCode();

		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private Bone m_Mount = new Bone(HumanBodyBones.Head);

		[SerializeField]
		private Vector3 m_Offset = Vector3.zero;

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
		private float m_SmoothTime = 0.1f;

		private Vector3 m_LastTargetPosition = Vector3.zero;

		private Vector2 m_CurrentRotation = new Vector2(0f, 0f);

		private Vector2 m_TargetRotation = new Vector2(0f, 0f);

		private float m_VelocityX;

		private float m_VelocityY;

		public override int Id => ID;

		public Vector2 Sensitivity
		{
			set
			{
				m_SensitivityX = new PropertyGetDecimal(value.x);
				m_SensitivityY = new PropertyGetDecimal(value.y);
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

		public GameObject Target
		{
			set
			{
				m_Character = GetGameObjectInstance.Create(value);
			}
		}

		public Bone Bone
		{
			get
			{
				return m_Mount;
			}
			set
			{
				m_Mount = value;
			}
		}

		public void SetRotation(Quaternion rotation)
		{
			Vector2 vector = new Vector2(rotation.eulerAngles.x, rotation.eulerAngles.y);
			vector.x = QuaternionUtils.Convert180(vector.x);
			vector.y = QuaternionUtils.Convert180(vector.y);
			m_TargetRotation = vector;
			m_CurrentRotation = vector;
		}

		public void SetDirection(Vector3 direction)
		{
			SetRotation(Quaternion.LookRotation(direction, Vector3.up));
		}

		public Character GetTarget(IShotType shotType)
		{
			return m_Character.Get<Character>(shotType.ShotCamera);
		}

		public override void OnAwake(TShotType shotType)
		{
			base.OnAwake(shotType);
			m_InputRotate.OnStartup();
		}

		public override void OnDestroy(TShotType shotType)
		{
			base.OnDestroy(shotType);
			m_InputRotate.OnDispose();
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			m_InputRotate.OnUpdate();
			if (shotType.IsActive)
			{
				double num = m_SensitivityX.Get(shotType.Args);
				double num2 = m_SensitivityY.Get(shotType.Args);
				Vector2 vector = m_InputRotate.Read();
				ComputeInput(new Vector2(vector.x * (float)num, vector.y * (float)num2));
			}
			ConstrainPitch();
			ConstrainYaw(shotType);
			m_CurrentRotation = new Vector2(GetRotationDamp(m_CurrentRotation.x, m_TargetRotation.x, ref m_VelocityX, m_SmoothTime, shotType.ShotCamera.TimeMode.DeltaTime), GetRotationDamp(m_CurrentRotation.y, m_TargetRotation.y, ref m_VelocityY, m_SmoothTime, shotType.ShotCamera.TimeMode.DeltaTime));
			Vector3 targetPosition = GetTargetPosition(shotType);
			Quaternion rotation = Quaternion.Euler(m_CurrentRotation.x, m_CurrentRotation.y, 0f);
			shotType.Position = targetPosition;
			shotType.Rotation = rotation;
			m_LastTargetPosition = targetPosition;
		}

		public override void OnEnable(TShotType shotType, TCamera camera)
		{
			base.OnEnable(shotType, camera);
			SetRotation(camera.transform.rotation);
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

		private void ConstrainYaw(TShotType shotType)
		{
			if (m_MaxYaw.IsEnabled)
			{
				float num = m_MaxYaw.Value * 0.5f;
				Character character = m_Character.Get<Character>(shotType.Args);
				if (character != null)
				{
					float y = character.transform.rotation.eulerAngles.y;
					float num2 = QuaternionUtils.ClampAngle(m_TargetRotation.y - y, 0f - num, num);
					m_TargetRotation.y = num2 + y;
				}
			}
		}

		private Vector3 GetTargetPosition(TShotType shotType)
		{
			Character character = m_Character.Get<Character>(shotType.Args);
			if (character == null)
			{
				return m_LastTargetPosition;
			}
			Animator animator = character.Animim.Animator;
			if (animator == null)
			{
				return m_LastTargetPosition;
			}
			Transform transform = m_Mount.GetTransform(animator);
			if (!(transform != null))
			{
				return m_LastTargetPosition;
			}
			return transform.TransformPoint(m_Offset);
		}

		private void ComputeInput(Vector2 deltaInput)
		{
			m_TargetRotation += new Vector2(deltaInput.y, deltaInput.x);
		}
	}
}
