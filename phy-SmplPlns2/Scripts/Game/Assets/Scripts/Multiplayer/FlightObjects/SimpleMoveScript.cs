using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class SimpleMoveScript : MonoBehaviour
	{
		public enum MovementMode
		{
			ChasePlayer = 0,
			AvoidPlayer = 1
		}

		private class Target
		{
			private Func<Vector3> _velocity;

			public bool IsDead => Transform == null;

			public Transform Transform { get; }

			public Vector3 Velocity => _velocity();

			public Target(Transform transform, Func<Vector3> velocity)
			{
				Transform = transform;
				_velocity = velocity;
			}
		}

		[SerializeField]
		private float _acceleration = 20f;

		private Rigidbody _body;

		[SerializeField]
		private float _lateralForceStrength = 5f;

		[SerializeField]
		private float _maxSpeed = 20f;

		[SerializeField]
		private MovementMode _movementMode = MovementMode.AvoidPlayer;

		private NetworkedAreaItemScript _networkItem;

		private Target _target;

		private float _targetRange = 2f;

		private float _targetSwitchCooldown;

		[SerializeField]
		private float _turnTorque = 2.5f;

		[SerializeField]
		private Transform _waypointContainer;

		private List<Transform> _waypoints = new List<Transform>();

		protected virtual void Awake()
		{
			_networkItem = GetComponent<NetworkedAreaItemScript>();
			_body = GetComponent<Rigidbody>();
			if (!(_waypointContainer != null))
			{
				return;
			}
			foreach (Transform item in _waypointContainer)
			{
				_waypoints.Add(item);
			}
		}

		protected virtual void FixedUpdate()
		{
			if (_networkItem.Area.IsOwner)
			{
				if (_targetSwitchCooldown <= 0f)
				{
					AircraftScript closest = GetClosestPlayer(1000f);
					if (closest != null)
					{
						_targetSwitchCooldown = 5f;
						_target = new Target(closest.MainCockpit?.transform, () => closest.Velocity);
					}
					else
					{
						_target = null;
					}
				}
				else
				{
					_targetSwitchCooldown -= Time.deltaTime;
				}
				if (_target?.Transform != null)
				{
					if (_movementMode == MovementMode.AvoidPlayer)
					{
						Vector3 vector = base.transform.position - _target.Transform.position;
						if (vector.magnitude < 50f)
						{
							Vector3 normalized = vector.normalized;
							MoveTowardsPosition(base.transform.position + normalized * 500f, Vector3.zero);
						}
						else
						{
							_body.AddForce(-_body.linearVelocity, ForceMode.Acceleration);
						}
					}
					else if (_movementMode == MovementMode.ChasePlayer)
					{
						MoveTowardsPosition(_target.Transform.position, _target.Velocity);
					}
				}
				else
				{
					_body.AddForce(-_body.linearVelocity, ForceMode.Acceleration);
				}
				_body.AddForce(Vector3.Dot(_body.linearVelocity, base.transform.right) * _lateralForceStrength * -base.transform.right, ForceMode.Acceleration);
			}
			else if (_target != null)
			{
				_target = null;
			}
		}

		private void Accelerate()
		{
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			float num = Vector3.Dot(base.transform.up, Vector3.up);
			_body.AddForce(num * _acceleration * forward, ForceMode.Acceleration);
			if (_body.linearVelocity.magnitude > _maxSpeed)
			{
				_body.linearVelocity = _body.linearVelocity.normalized * _maxSpeed;
			}
		}

		private void ApplyTorqueTowards(Vector3 direction, float scale)
		{
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			float num = Mathf.Clamp(Vector3.SignedAngle(forward, direction, Vector3.up) * 0.025f, -1f, 1f);
			_body.AddTorque(scale * num * _turnTorque * Vector3.up, ForceMode.Acceleration);
		}

		private AircraftScript GetClosestPlayer(float minRange)
		{
			float num = float.MaxValue;
			AircraftScript result = null;
			foreach (FlightScenePlayer allPlayer in FlightSceneScript.Instance.AllPlayers)
			{
				if (allPlayer.Aircraft?.MainCockpit != null)
				{
					float magnitude = (allPlayer.Aircraft.MainCockpit.transform.position - base.transform.position).magnitude;
					if (magnitude < num && magnitude < minRange)
					{
						num = magnitude;
						result = allPlayer.Aircraft;
					}
				}
			}
			return result;
		}

		private void MoveTowardsPosition(Vector3 position, Vector3 velocity)
		{
			Vector3 vector = position - base.transform.position;
			float num = Vector3.Dot(vector.normalized, _body.linearVelocity);
			if (num > 1f)
			{
				float num2 = vector.magnitude / num;
				position += velocity * num2;
				vector = position - base.transform.position;
			}
			if (vector.magnitude > _targetRange)
			{
				Accelerate();
				Vector3 normalized = vector.normalized;
				normalized.y = 0f;
				ApplyTorqueTowards(normalized, Mathf.Clamp01(_body.linearVelocity.magnitude * 0.5f));
			}
		}

		private Transform SelectNextWaypoint(Transform waypoint)
		{
			int num = _waypoints.IndexOf(waypoint) + 1;
			if (num < 0 || num >= _waypoints.Count)
			{
				num = 0;
			}
			return _waypoints[num];
		}
	}
}
