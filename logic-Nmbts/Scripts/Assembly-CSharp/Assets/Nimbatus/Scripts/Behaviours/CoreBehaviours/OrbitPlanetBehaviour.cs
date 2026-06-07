using System.Collections;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class OrbitPlanetBehaviour : CoreBehaviour
	{
		public EnemyRadar Radar;

		public float MoveSpeed = 30f;

		public float RotationSpeed = 5f;

		public float OrbitHeight = 100f;

		public LayerMask AvoidanceMask;

		public bool UpIsForward;

		private bool _stopCoroutine;

		private Vector3 _targetPosition;

		private bool _deactivateGravity;

		private float _avoidTime;

		protected override void OnInit()
		{
			_stopCoroutine = false;
			_avoidTime = 0f;
			Radar.AddFriendlyUnit(OwnWorldObject.Rigidbody);
			OwnWorldObject.StartCoroutine(UpdatePosition());
			_deactivateGravity = OwnWorldObject.DeactivateGravity;
			OwnWorldObject.HealthPool.DamageTaken += HealthPool_OnDamageTaken;
		}

		private void HealthPool_OnDamageTaken(HealthPool healthPool, DamageInformation damage)
		{
			if (damage.DamageSourceObject != null && damage.Reason == EDamageReason.Player)
			{
				EnemyRadar radar = Radar;
				if ((object)radar != null)
				{
					radar.SetFocusTarget(damage.DamageSourceObject.transform);
				}
			}
		}

		private IEnumerator UpdatePosition()
		{
			while (!_stopCoroutine)
			{
				float angle = TransformHelper.GetAngle(OwnWorldObject.transform.position) + 20f;
				float num = (float)WorldController.TerrainSettings.PlanetSize + OrbitHeight;
				_targetPosition = SpawnTransformHelper.GetCoordinates(angle, num);
				Vector3 pos;
				Vector3 n;
				if (TransformHelper.GetSurfacePosition(angle, 1000f, 1000f, out pos, out n) && pos.magnitude + 50f > num)
				{
					_targetPosition = pos + n * OrbitHeight;
				}
				yield return new WaitForSeconds(1f);
			}
		}

		private Quaternion GetRotation()
		{
			int num = (UpIsForward ? (-90) : 0);
			Vector3 velocity = OwnWorldObject.Rigidbody.velocity;
			return Quaternion.AngleAxis(Mathf.Atan2(velocity.y, velocity.x) * 57.29578f + (float)num, Vector3.forward);
		}

		private Vector2 GetVelocity()
		{
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			if (Radar.HasFriendlyUnits)
			{
				vector = Radar.FriendlyFlockCenter - OwnWorldObject.transform.position;
				vector2 = Radar.FriendlyFlockVelocity - OwnWorldObject.Rigidbody.velocity;
			}
			if (Time.time - _avoidTime < 2f || Physics.Raycast(OwnWorldObject.transform.position, UpIsForward ? OwnWorldObject.transform.up : OwnWorldObject.transform.right, 30f, AvoidanceMask))
			{
				if (Time.time - _avoidTime > 2f)
				{
					_avoidTime = Time.time;
				}
				return OwnWorldObject.transform.position.normalized * MoveSpeed * 100f;
			}
			Vector2 vector3 = (Vector2)_targetPosition - (Vector2)OwnWorldObject.transform.position;
			float magnitude = vector3.magnitude;
			float num = Mathf.Min(1f, magnitude * 0.1f);
			return (vector + vector2 + vector3 * 3f).normalized * MoveSpeed * 100f * num;
		}

		protected override void OnFixedUpdate()
		{
			if (OwnWorldObject.Rigidbody.isKinematic)
			{
				return;
			}
			if (OwnWorldObject.HealthPool.CurrentState == EChemicalState.Frozen)
			{
				OwnWorldObject.Rigidbody.drag = 0.1f;
				OwnWorldObject.Rigidbody.angularDrag = 0.1f;
				OwnWorldObject.DeactivateGravity = false;
				return;
			}
			OwnWorldObject.Rigidbody.drag = OwnWorldObject.StartDrag;
			OwnWorldObject.Rigidbody.angularDrag = OwnWorldObject.StartAngularDrag;
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			float a = Time.fixedDeltaTime * RotationSpeed;
			a = Mathf.Min(a, OwnWorldObject.Rigidbody.velocity.magnitude * 0.1f);
			Quaternion rotation = GetRotation();
			Vector2 vector = GetVelocity() * Time.fixedDeltaTime;
			if (!float.IsNaN(vector.x) && !float.IsNaN(vector.y))
			{
				OwnWorldObject.Rigidbody.AddForce(vector.x, vector.y, 0f, ForceMode.Force);
			}
			OwnWorldObject.Rigidbody.MoveRotation(Quaternion.Lerp(OwnWorldObject.Rigidbody.rotation, rotation, a));
		}

		protected override void OnRelease()
		{
			OwnWorldObject.DeactivateGravity = _deactivateGravity;
			OwnWorldObject.HealthPool.DamageTaken -= HealthPool_OnDamageTaken;
			_stopCoroutine = true;
			Radar.Clear();
		}
	}
}
