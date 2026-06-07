using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class MissileFlightPhysics : IMissileFlightPhysics
	{
		private float _bodyArea;

		private Transform _centerOfThrust;

		private Vector3 _currentErrorAxis = Vector3.zero;

		private float _finArea;

		private float _initialDistance;

		private float _loftHeight;

		private MissileScript _missile;

		private float _missileSurfaceArea;

		private float _noseConeArea;

		private Vector3 _prevLos;

		private Vector3 _prevLOS = Vector3.zero;

		private Vector3 _prevTargetVelocity = Vector3.zero;

		private ProceduralMissileData _proceduralMissileData;

		private float _thrustVectoringTurnOffset;

		public MissileFlightPhysics(MissileScript missile, Transform centerOfThrust, ProceduralMissileData proceduralMissileData)
		{
		}

		public void OnFire(Vector3 toTarget)
		{
			_loftHeight = LoftHeight(toTarget.magnitude);
			_initialDistance = toTarget.magnitude;
		}

		public void UpdatePhysics(bool locked, Rigidbody body, MissileScript.FrameStats stats, MissileScript.FrameStats previousStats, float deltaTime)
		{
		}

		private Vector3 GetLeadPN(MissileScript.FrameStats stats, MissileScript.FrameStats previousStats, Rigidbody body, float deltaTime)
		{
			Vector3 rhs = _missile.CurrentTarget.Target.Velocity - body.linearVelocity;
			Vector3 vector = (_missile.CurrentTarget.Target.Velocity - _prevTargetVelocity) / deltaTime;
			Vector3 vector2 = Vector3.Cross(stats.ToTarget, rhs) / stats.ToTarget.sqrMagnitude;
			float num = 4f;
			Vector3 vector3 = new Vector3(0f, 9.81f, 0f);
			Vector3 vector4 = (0f - num) * rhs.magnitude * Vector3.Cross(body.linearVelocity.normalized, vector2);
			Vector3 vector5 = vector - Vector3.Project(vector, stats.ToTarget);
			Vector3 result = vector4 + vector5 * (0.35f * num / 2f) + vector3;
			_prevLOS = vector2;
			_prevTargetVelocity = _missile.CurrentTarget.Target.Velocity;
			return result;
		}

		private float LoftHeight(float initialDistance)
		{
			return Mathf.Sqrt(Mathf.Max(initialDistance + 2500f, 0f)) * 100f - 5000f;
		}
	}
}
