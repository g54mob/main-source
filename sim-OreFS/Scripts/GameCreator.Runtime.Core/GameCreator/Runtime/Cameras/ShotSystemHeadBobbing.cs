using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemHeadBobbing : TShotSystem
	{
		public static readonly int ID = "ShotSystemHeadBobbing".GetHashCode();

		private const float BOB_SMOOTH_TIME = 0.35f;

		[SerializeField]
		private bool m_IsActive = true;

		[SerializeField]
		private float m_SmoothTime = 0.35f;

		[SerializeField]
		private PropertyGetDecimal m_StepLength = GetDecimalDecimal.Create(0.75f);

		[SerializeField]
		private PropertyGetDecimal m_StepHeight = GetDecimalDecimal.Create(0.02f);

		[SerializeField]
		private PropertyGetDecimal m_StepWidth = GetDecimalDecimal.Create(0.01f);

		private AnimFloat m_Speed;

		public override int Id => ID;

		public bool IsActive
		{
			get
			{
				return m_IsActive;
			}
			set
			{
				m_IsActive = value;
			}
		}

		public override void OnAwake(TShotType shotType)
		{
			base.OnAwake(shotType);
			m_Speed = new AnimFloat(0f, m_SmoothTime);
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			if (shotType is ShotTypeFirstPerson shotTypeFirstPerson)
			{
				float target;
				if (m_IsActive)
				{
					Character character = shotTypeFirstPerson.Character;
					target = ((!(character == null) && character.Driver.IsGrounded) ? GetStepSpeedCoefficient(shotTypeFirstPerson) : 0f);
				}
				else
				{
					target = 0f;
				}
				m_Speed.UpdateWithDelta(target, m_SmoothTime, shotType.ShotCamera.TimeMode.DeltaTime);
				float x = BobStepBalance(shotTypeFirstPerson);
				float y = BobStepHeight(shotTypeFirstPerson);
				Vector3 vector = shotType.Transform.TransformDirection(new Vector3(x, y, 0f));
				shotType.Position += vector;
			}
		}

		private float GetStepFrequency(ShotTypeFirstPerson shotType)
		{
			Character character = shotType.Character;
			float num = (float)m_StepLength.Get(shotType.Args);
			if (!(character != null) || !(character.Motion.LinearSpeed > 0f))
			{
				return 0f;
			}
			return Mathf.Clamp01(num / character.Motion.LinearSpeed);
		}

		private float GetStepSpeedCoefficient(ShotTypeFirstPerson shotType)
		{
			Character character = shotType.Character;
			Vector3 vector = Vector3.Scale(Vector3Plane.NormalUp, character.Driver.WorldMoveDirection);
			if (!(character != null) || !(character.Motion.LinearSpeed > 0f))
			{
				return 0f;
			}
			return Mathf.Clamp01(vector.magnitude / character.Motion.LinearSpeed);
		}

		private float GetStepPeriod(ShotTypeFirstPerson shotType)
		{
			float stepFrequency = GetStepFrequency(shotType);
			if (stepFrequency <= float.Epsilon)
			{
				return 0f;
			}
			return shotType.ShotCamera.TimeMode.Time / stepFrequency;
		}

		private float BobStepHeight(ShotTypeFirstPerson shotType)
		{
			float num = (float)m_StepHeight.Get(shotType.Args);
			float stepPeriod = GetStepPeriod(shotType);
			float b = (Mathf.Cos(stepPeriod * 2f) - 1f) * num * m_Speed.Current;
			return Mathf.Lerp(0f, b, stepPeriod);
		}

		private float BobStepBalance(ShotTypeFirstPerson shotType)
		{
			float num = (float)m_StepWidth.Get(shotType.Args);
			float stepPeriod = GetStepPeriod(shotType);
			float b = Mathf.Sin(stepPeriod) * num * m_Speed.Current;
			return Mathf.Lerp(0f, b, stepPeriod);
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
