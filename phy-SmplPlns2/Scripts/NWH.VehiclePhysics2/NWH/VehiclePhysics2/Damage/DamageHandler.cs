using System;
using System.Collections.Generic;
using System.Linq;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace NWH.VehiclePhysics2.Damage
{
	[Serializable]
	[RequireComponent(typeof(VehicleController))]
	[RequireComponent(typeof(Rigidbody))]
	public class DamageHandler : MonoBehaviour
	{
		public class VehicleCollision
		{
			[Tooltip("    Collision data for the collision event.")]
			public Collision collision;

			[Tooltip("    Magnitude of the decekeration vector at the moment of impact.")]
			public float decelerationMagnitude;

			[Tooltip("Queue of mesh filter components that are waiting for deformation.\r\nSome of the meshes might be queued for checking even if not deformed.")]
			public Queue<MeshFilter> deformationQueue = new Queue<MeshFilter>();
		}

		[Tooltip("Flips the damage direction. If the mesh is deforming in the wrong direction try enabling this.")]
		public bool flipImpactDirection = true;

		[Tooltip("Collisions with the objects that have a tag that is on this list will be ignored.\r\nCollision state will be changed but no processing will happen.")]
		public List<string> collisionIgnoreTags = new List<string> { "Wheel" };

		[Tooltip("Disable repeating collision until the 'collisionTimeout' time has passed. Used to prevent single collision triggering multiple times from minor bumps.")]
		public float collisionTimeout = 0.8f;

		[Tooltip("    How much new collisions add to the 'damage' value. Does not affect mesh deformation strength.")]
		public float damageIntensity = 1f;

		[Tooltip("    Deceleration magnitude needed to trigger damage.")]
		public float decelerationThreshold = 200f;

		[Tooltip("    Objects that have a tag that is on this list will not have their meshes deformed on collision.")]
		public List<string> deformationIgnoreTags = new List<string> { "Wheel" };

		[Range(0f, 2f)]
		[Tooltip("    Radius is which vertices will be deformed.")]
		public float deformationRadius = 0.4f;

		[Range(0.001f, 0.5f)]
		[Tooltip("    Adds noise to the mesh deformation. 0 will result in smooth mesh.")]
		public float deformationRandomness = 0.01f;

		[Range(0.1f, 5f)]
		[Tooltip("    Determines how much vertices will be deformed for given collision strength.")]
		public float deformationStrength = 0.5f;

		[Tooltip("Number of vertices that will be checked and eventually deformed per frame. Setting it to lower values will reduce or remove frame drops but will induce lag into mesh deformation as vehicle will be deformed over longer time span.")]
		public int deformationVerticesPerFrame = 8000;

		[Tooltip("    Should meshes be deformed upon collision?")]
		public bool meshDeform = true;

		public List<ParticleSystem> smokeParticleSystems = new List<ParticleSystem>();

		[Tooltip("    Should damage affect vehicle performance (steering, power, etc.)?")]
		public bool visualOnly;

		[Tooltip("    Collision data for the latest collision. Null if no collision yet happened.")]
		public Collision lastCollision;

		[Tooltip("    Time since startup to the latest collision.")]
		public float lastCollisionTime = -1f;

		private Queue<VehicleCollision> _collisionEvents = new Queue<VehicleCollision>();

		private List<MeshFilter> _deformableMeshFilters = new List<MeshFilter>();

		private List<Mesh> _originalMeshes = new List<Mesh>();

		private Rigidbody _rigidbody;

		private VehicleController _vehicleController;

		public float Damage { get; private set; }

		private void OnCollisionEnter(Collision collision)
		{
			HandleCollision(collision);
		}

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_vehicleController = GetComponent<VehicleController>();
			MeshFilter[] array = (from m in base.transform.GetComponentsInChildren<MeshFilter>()
				where collisionIgnoreTags.Any((string t) => !m.CompareTag(t))
				select m).ToArray();
			foreach (MeshFilter meshFilter in array)
			{
				if (!_deformableMeshFilters.Contains(meshFilter))
				{
					_deformableMeshFilters.Add(meshFilter);
					_originalMeshes.Add(meshFilter.sharedMesh);
				}
			}
		}

		private void Update()
		{
			if (_collisionEvents.Count == 0)
			{
				return;
			}
			VehicleCollision vehicleCollision = _collisionEvents.Peek();
			if (vehicleCollision.deformationQueue.Count == 0)
			{
				_collisionEvents.Dequeue();
				if (_collisionEvents.Count != 0)
				{
					vehicleCollision = _collisionEvents.Peek();
				}
			}
			int num = 0;
			while (num < deformationVerticesPerFrame && vehicleCollision.deformationQueue.Count > 0)
			{
				MeshFilter meshFilter = vehicleCollision.deformationQueue.Dequeue();
				num += meshFilter.mesh.vertexCount;
				MeshDeform(vehicleCollision, meshFilter);
			}
		}

		public void HandleCollision(Collision collision)
		{
			if (!base.enabled)
			{
				return;
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (!(realtimeSinceStartup < lastCollisionTime + collisionTimeout))
			{
				float num = collision.relativeVelocity.magnitude * 100f;
				if (num > decelerationThreshold && Enqueue(collision, num))
				{
					lastCollision = collision;
					lastCollisionTime = realtimeSinceStartup;
				}
			}
		}

		public static Vector3 AverageCollisionNormal(ContactPoint[] contacts)
		{
			Vector3[] array = new Vector3[contacts.Length];
			int num = contacts.Length;
			for (int i = 0; i < num; i++)
			{
				array[i] = contacts[i].normal;
			}
			return AveragePoint(array);
		}

		public static Vector3 AverageCollisionPoint(ContactPoint[] contacts)
		{
			Vector3[] array = new Vector3[contacts.Length];
			int num = contacts.Length;
			for (int i = 0; i < num; i++)
			{
				array[i] = contacts[i].point;
			}
			return AveragePoint(array);
		}

		public bool Enqueue(Collision collision, float accelerationMagnitude)
		{
			int count = collisionIgnoreTags.Count;
			for (int i = 0; i < count; i++)
			{
				if (collision.collider.CompareTag(collisionIgnoreTags[i]))
				{
					return false;
				}
			}
			VehicleCollision vehicleCollision = new VehicleCollision();
			vehicleCollision.collision = collision;
			vehicleCollision.decelerationMagnitude = accelerationMagnitude;
			Vector3 vector = AverageCollisionPoint(collision.contacts);
			if (!visualOnly && damageIntensity > 0f)
			{
				damageIntensity = ((damageIntensity < 0f) ? 0f : ((damageIntensity > 0.99f) ? 0.99f : damageIntensity));
				float num = collision.impulse.magnitude / (Time.fixedDeltaTime * _rigidbody.mass * 10f) * damageIntensity * 0.002f;
				Damage += num;
				Damage = ((Damage < 0f) ? 0f : ((Damage > 1f) ? 1f : Damage));
				if (_vehicleController != null)
				{
					for (int j = 0; j < _vehicleController.powertrain.wheelCount; j++)
					{
						WheelComponent wheelComponent = _vehicleController.powertrain.wheels[j];
						if (Vector3.Distance(vector, wheelComponent.wheelUAPI.WheelPosition) < wheelComponent.wheelUAPI.Radius * 2.5f)
						{
							wheelComponent.wheelUAPI.Damage += num;
						}
					}
					float num2 = 1f;
					if (Vector3.Distance(_vehicleController.WorldEnginePosition, vector) < num2)
					{
						_vehicleController.powertrain.engine.Damage += num;
					}
					if (Vector3.Distance(_vehicleController.WorldTransmissionPosition, vector) < num2)
					{
						_vehicleController.powertrain.transmission.Damage += num;
					}
				}
			}
			if (!meshDeform)
			{
				return true;
			}
			foreach (MeshFilter deformableMeshFilter in _deformableMeshFilters)
			{
				string text = deformableMeshFilter.gameObject.tag;
				if (text == null)
				{
					vehicleCollision.deformationQueue.Enqueue(deformableMeshFilter);
					continue;
				}
				bool flag = false;
				for (int k = 0; k < deformationIgnoreTags.Count; k++)
				{
					if (text == deformationIgnoreTags[k])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					vehicleCollision.deformationQueue.Enqueue(deformableMeshFilter);
				}
			}
			_collisionEvents.Enqueue(vehicleCollision);
			return true;
		}

		public void MeshDeform(VehicleCollision collisionEvent, MeshFilter deformableMeshFilter)
		{
			for (int i = 0; i < collisionEvent.collision.contacts.Length; i++)
			{
				ContactPoint contactPoint = collisionEvent.collision.contacts[i];
				Vector3 point = contactPoint.point;
				Vector3 vector = (flipImpactDirection ? (-contactPoint.normal) : contactPoint.normal);
				float num = Mathf.Clamp(collisionEvent.decelerationMagnitude * deformationStrength / 3000f, 0f, deformationRadius);
				Vector3[] vertices = deformableMeshFilter.mesh.vertices;
				int num2 = vertices.Length;
				for (int j = 0; j < num2; j++)
				{
					Vector3 position = deformableMeshFilter.transform.TransformPoint(vertices[j]);
					float num3 = Mathf.Sqrt((point.x - position.x) * (point.x - position.x) + (point.z - position.z) * (point.z - position.z) + (point.y - position.y) * (point.y - position.y));
					num3 *= UnityEngine.Random.Range(1f - deformationRandomness, 1f + deformationRandomness);
					if (num3 < num)
					{
						position += vector * (num - num3);
						vertices[j] = deformableMeshFilter.transform.InverseTransformPoint(position);
					}
				}
				deformableMeshFilter.mesh.vertices = vertices;
				deformableMeshFilter.mesh.RecalculateNormals();
				deformableMeshFilter.mesh.RecalculateTangents();
			}
		}

		public void Repair()
		{
			if (meshDeform)
			{
				int count = _deformableMeshFilters.Count;
				for (int i = 0; i < count; i++)
				{
					if (_originalMeshes[i] != null)
					{
						_deformableMeshFilters[i].mesh = _originalMeshes[i];
					}
				}
			}
			_vehicleController.powertrain.Repair();
			for (int j = 0; j < _vehicleController.powertrain.wheelCount; j++)
			{
				_vehicleController.powertrain.wheels[j].wheelUAPI.Damage = 0f;
			}
			Damage = 0f;
		}

		private static Vector3 AveragePoint(Vector3[] points)
		{
			Vector3 zero = Vector3.zero;
			int num = points.Length;
			for (int i = 0; i < num; i++)
			{
				zero += points[i];
			}
			return zero / points.Length;
		}
	}
}
