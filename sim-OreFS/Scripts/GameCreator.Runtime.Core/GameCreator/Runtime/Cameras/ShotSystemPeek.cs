using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemPeek : TShotSystem
	{
		public static readonly int ID = "ShotSystemPeek".GetHashCode();

		private const float DEFAULT_PAN = 1f;

		private const float DEFAULT_TILT = 30f;

		[SerializeField]
		private float m_Pan = 1f;

		[SerializeField]
		private float m_Tilt = 30f;

		[SerializeField]
		private InputPropertyValueVector2 m_Input = InputValueVector2MotionSecondary.Create();

		[SerializeField]
		private float m_SmoothTime = 0.15f;

		[SerializeField]
		private bool m_Restitute;

		[SerializeField]
		private PropertyGetDecimal m_SensitivityX = GetDecimalDecimal.Create(60f);

		[SerializeField]
		private PropertyGetDecimal m_SensitivityY = GetDecimalDecimal.Create(60f);

		[NonSerialized]
		private AnimVector3 m_Value = new AnimVector3(Vector3.zero);

		[NonSerialized]
		private Vector3 m_GizmoPosition = Vector3.zero;

		[NonSerialized]
		private Vector3 m_GizmoDirection = Vector3.forward;

		private const float GIZMO_DISTANCE = 0.5f;

		public override int Id => ID;

		public override void OnAwake(TShotType shotType)
		{
			base.OnAwake(shotType);
			m_Input.OnStartup();
		}

		public override void OnDestroy(TShotType shotType)
		{
			base.OnDestroy(shotType);
			m_Input.OnDispose();
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			if (shotType.IsActive)
			{
				m_Input.OnUpdate();
				Vector2 vector = m_Input.Read();
				if (m_Restitute)
				{
					m_Value.Target = vector;
				}
				else
				{
					float num = (float)m_SensitivityX.Get(shotType.Args);
					float num2 = (float)m_SensitivityY.Get(shotType.Args);
					m_Value.Target += new Vector3(vector.x * num * shotType.ShotCamera.TimeMode.DeltaTime, vector.y * num2 * shotType.ShotCamera.TimeMode.DeltaTime, 0f);
				}
				m_Value.Target = new Vector3(Mathf.Clamp(m_Value.Target.x, -1f, 1f), Mathf.Clamp(m_Value.Target.y, -1f, 1f), 0f);
				m_Value.Smooth = Vector3.one * m_SmoothTime;
				m_Value.UpdateWithDelta(shotType.ShotCamera.TimeMode.DeltaTime);
				Vector2 vector2 = Vector2.ClampMagnitude(new Vector2(m_Value.Current.x, m_Value.Current.y), 1f);
				float t = (vector2.x + 1f) / 2f;
				float t2 = (vector2.y + 1f) / 2f;
				Vector3 position = new Vector3(Mathf.Lerp(0f - m_Pan, m_Pan, t), Mathf.Lerp(0f - m_Pan, m_Pan, t2), 0f);
				Vector3 vector3 = Quaternion.Euler(Mathf.Lerp(0f - m_Tilt, m_Tilt, t2), Mathf.Lerp(0f - m_Tilt, m_Tilt, t), 0f) * Vector3.forward;
				vector3 = shotType.Rotation * vector3;
				m_GizmoPosition = shotType.ShotCamera.transform.position;
				m_GizmoDirection = shotType.ShotCamera.transform.forward;
				shotType.Position = shotType.ShotCamera.transform.TransformPoint(position);
				shotType.Rotation = Quaternion.LookRotation(vector3);
			}
		}

		public override void OnEnable(TShotType shotType, TCamera camera)
		{
			base.OnEnable(shotType, camera);
			m_Value.Target = Vector3.zero;
			m_Value.Current = Vector2.zero;
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType, TShotSystem.GIZMOS_COLOR_ACTIVE, transform);
		}

		private float GetRotationDamp(float current, float target, ref float velocity, float smoothTime, float deltaTime)
		{
			if (deltaTime <= float.Epsilon)
			{
				return current;
			}
			return Mathf.SmoothDampAngle(current, target, ref velocity, smoothTime, float.PositiveInfinity, deltaTime);
		}

		private void DoDrawGizmos(TShotType shotType, Color color, Transform transform)
		{
			Gizmos.color = color;
			Vector3 obj = (Application.isPlaying ? m_GizmoPosition : transform.position);
			Vector3 vector = (Application.isPlaying ? (m_GizmoPosition + m_GizmoDirection * 0.5f) : transform.TransformPoint(Vector3.forward * 0.5f));
			Vector3 normal = (Application.isPlaying ? m_GizmoDirection : transform.forward);
			float num = Mathf.Tan(m_Tilt * (MathF.PI / 180f)) * 0.5f;
			Gizmos.DrawLine(obj, vector);
			GizmosExtension.Circle(obj, m_Pan, normal);
			GizmosExtension.Circle(vector, m_Pan + num, normal);
		}
	}
}
