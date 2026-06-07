using Assets.Scripts.Craft;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Assets.Scripts.Flight.Discoverables
{
	public abstract class DiscoverableAreaScript : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _cubeSize = Vector3.zero;

		[SerializeField]
		private bool _drawGizmo = true;

		[SerializeField]
		private bool _mustBeStopped;

		[SerializeField]
		private bool _mustNotHaveCriticalDamage = true;

		private Rigidbody _parentRigidBody;

		[SerializeField]
		private DiscoverableAreaShape _shape = DiscoverableAreaShape.Cube;

		[SerializeField]
		private float _sphereRadius;

		public bool Discovered { get; protected set; }

		protected bool MustBeStopped => _mustBeStopped;

		protected bool MustNotHaveCriticalDamage => _mustNotHaveCriticalDamage;

		protected Rigidbody ParentRigidBody => _parentRigidBody;

		public virtual bool IsPlayerInBounds(FlightScenePlayer player)
		{
			if ((object)player?.Aircraft == null && (object)player.CharacterActor == null)
			{
				return false;
			}
			Vector3 vector = player.Aircraft?.Position ?? player.CharacterActor.Position;
			bool result = false;
			if (_shape == DiscoverableAreaShape.Cube)
			{
				Vector3 vector2 = base.transform.InverseTransformPoint(vector);
				if (vector2.x >= 0f && vector2.x <= _cubeSize.x && vector2.y >= 0f && vector2.y <= _cubeSize.y && vector2.z >= 0f)
				{
					return vector2.z <= _cubeSize.z;
				}
				return false;
			}
			if (_shape == DiscoverableAreaShape.Sphere)
			{
				return (vector - base.transform.position).sqrMagnitude <= _sphereRadius * _sphereRadius;
			}
			return result;
		}

		protected virtual void Awake()
		{
			if (_mustBeStopped)
			{
				_parentRigidBody = GetComponentInParent<Rigidbody>();
			}
			_drawGizmo = !Application.isPlaying;
		}

		protected abstract void OnDiscovered();

		protected virtual void OnDrawGizmos()
		{
			if (_drawGizmo)
			{
				Gizmos.color = Color.white;
				Gizmos.matrix = base.transform.localToWorldMatrix;
				if (_shape == DiscoverableAreaShape.Sphere)
				{
					Vector3 lossyScale = base.transform.lossyScale;
					float num = (lossyScale.x + lossyScale.y + lossyScale.z) / 3f;
					Gizmos.DrawWireSphere(Vector3.zero, _sphereRadius / num);
				}
				else if (_shape == DiscoverableAreaShape.Cube)
				{
					Gizmos.DrawWireCube(_cubeSize / 2f, _cubeSize);
				}
			}
		}

		protected virtual void PlayerInBounds(FlightScenePlayer player)
		{
			AircraftScript aircraft = player.Aircraft;
			CharacterActor characterActor = player.CharacterActor;
			float num = 0f;
			if (_mustBeStopped)
			{
				if (_parentRigidBody != null)
				{
					if (aircraft != null)
					{
						num = (aircraft.Velocity - _parentRigidBody.linearVelocity).magnitude;
					}
					else if (characterActor != null)
					{
						num = (characterActor.Velocity - _parentRigidBody.linearVelocity).magnitude;
					}
				}
				else
				{
					num = aircraft?.AirSpeed ?? characterActor.Velocity.magnitude;
				}
			}
			if ((!_mustBeStopped || num <= 2f) && (!_mustNotHaveCriticalDamage || !aircraft.CriticallyDamaged))
			{
				Discovered = true;
				OnDiscovered();
			}
		}

		protected virtual void Update()
		{
			if (!PauseManager.Paused && !Discovered)
			{
				FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
				if (localPlayer != null && IsPlayerInBounds(localPlayer))
				{
					PlayerInBounds(localPlayer);
				}
			}
		}
	}
}
