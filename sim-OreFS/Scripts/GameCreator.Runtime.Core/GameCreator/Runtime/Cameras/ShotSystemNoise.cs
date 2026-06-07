using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemNoise : TShotSystem
	{
		public static readonly int ID = "ShotSystemNoise".GetHashCode();

		private const float SEED_MIN = -99f;

		private const float SEED_MAX = 99f;

		[SerializeField]
		private PropertyGetRotation m_Angle = GetRotationEuler.Create(Vector3.one);

		[SerializeField]
		private PropertyGetPosition m_Movement = GetPositionVector3.Create(Vector3.zero);

		[SerializeField]
		private PropertyGetDecimal m_AngularSpeed = GetDecimalDecimal.Create(0.25f);

		[SerializeField]
		private PropertyGetDecimal m_LinearSpeed = GetDecimalDecimal.Create(0.5f);

		[NonSerialized]
		private float m_SeedAngleX;

		[NonSerialized]
		private float m_SeedAngleY;

		[NonSerialized]
		private float m_SeedAngleZ;

		[NonSerialized]
		private float m_SeedMoveX;

		[NonSerialized]
		private float m_SeedMoveY;

		[NonSerialized]
		private float m_SeedMoveZ;

		public override int Id => ID;

		public override void OnAwake(TShotType shotType)
		{
			base.OnAwake(shotType);
			m_SeedAngleX = UnityEngine.Random.Range(-99f, 99f);
			m_SeedAngleY = UnityEngine.Random.Range(-99f, 99f);
			m_SeedAngleZ = UnityEngine.Random.Range(-99f, 99f);
			m_SeedMoveX = UnityEngine.Random.Range(-99f, 99f);
			m_SeedMoveY = UnityEngine.Random.Range(-99f, 99f);
			m_SeedMoveZ = UnityEngine.Random.Range(-99f, 99f);
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			float speed = (float)m_AngularSpeed.Get(shotType.Args);
			float speed2 = (float)m_LinearSpeed.Get(shotType.Args);
			float time = shotType.ShotCamera.TimeMode.Time;
			float noise = GetNoise(m_SeedAngleX, speed, time);
			float noise2 = GetNoise(m_SeedAngleY, speed, time);
			float noise3 = GetNoise(m_SeedAngleZ, speed, time);
			float noise4 = GetNoise(m_SeedMoveX, speed2, time);
			float noise5 = GetNoise(m_SeedMoveY, speed2, time);
			float noise6 = GetNoise(m_SeedMoveZ, speed2, time);
			Vector3 eulerAngles = m_Angle.Get(shotType.Args).eulerAngles;
			Vector3 vector = m_Movement.Get(shotType.Args);
			Quaternion quaternion = Quaternion.Euler(noise * eulerAngles.x, noise2 * eulerAngles.y, noise3 * eulerAngles.z);
			Vector3 vector2 = new Vector3(noise4 * vector.x, noise5 * vector.y, noise6 * vector.z);
			shotType.Rotation *= quaternion;
			shotType.Position += vector2;
		}

		private float GetNoise(float seed, float speed, float time)
		{
			return Mathf.Clamp01(Mathf.PerlinNoise(seed, (seed + time) * speed)) * 2f - 1f;
		}
	}
}
