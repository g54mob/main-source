using System;
using Polarith.UnityUtils;
using UnityEngine;
using UnityEngine.AI;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Object Spawner")]
	public sealed class ObjectSpawner : MonoBehaviour
	{
		[Flags]
		public enum RestrictionType
		{
			Nothing = 0,
			NavMeshArea = 1
		}

		public enum InstantationType
		{
			Instant = 0,
			Interval = 1
		}

		[Tooltip("The reference to the game object or prefab that is spawned.")]
		public GameObject SpawningObject;

		[Tooltip("The parent object of the spawned objects. Can be set to null if no parent should be assigned. ")]
		public GameObject Parent;

		public int MaximumObjects = 50;

		[Tooltip("A rectangle defining the spawning area.")]
		public Rect SpawnArea;

		[Tooltip("If true, the spawning area will be flipped into the XZ-plane. Otherwise, the spawning area is in the XY-plane.")]
		public bool XZSpawn;

		[Tooltip("Determines if all objects are either spawned at once or spawned over a given time span.")]
		public InstantationType Instantiation;

		[Tooltip("The time between 2 object spawns. Only used if Instantiation is set to InstantationType.OverTime.")]
		public float SpawnInterval;

		[Tooltip("Determines which restrictions are applied to the spawning area, like excluding specific Navigation Areas.")]
		public RestrictionType Restriction;

		[NavMeshAreaMask]
		[Tooltip("Determines the Navigation Areas where objects can be spawned.")]
		public int NavMeshAreaMask = -1;

		[Tooltip("If true, the Spawn Area is visualized.")]
		public bool EnableGizmo;

		private float currentTime;

		public bool SpawnObject()
		{
			float num = 0f;
			float num2 = 1f;
			if (XZSpawn)
			{
				num = 1f;
				num2 = 0f;
			}
			Vector3 position = new Vector3(UnityEngine.Random.Range(SpawnArea.x, SpawnArea.x + SpawnArea.width), num2 * UnityEngine.Random.Range(SpawnArea.y, SpawnArea.y + SpawnArea.height), num * UnityEngine.Random.Range(SpawnArea.y, SpawnArea.y + SpawnArea.height));
			if (ValidatePosition(position))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(SpawningObject);
				if (Parent != null)
				{
					gameObject.transform.SetParent(Parent.transform);
				}
				gameObject.transform.position = position;
				return true;
			}
			return false;
		}

		private bool ValidatePosition(Vector3 position)
		{
			if (Restriction == RestrictionType.NavMeshArea)
			{
				if (NavMesh.SamplePosition(position, out var _, 0.1f, NavMeshAreaMask))
				{
					NavMesh.FindClosestEdge(position, out var hit2, ~NavMeshAreaMask);
					if (hit2.distance > 0.1f)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		private void Start()
		{
			if (Instantiation == InstantationType.Instant)
			{
				for (int i = 0; i < MaximumObjects; i++)
				{
					SpawnObject();
				}
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (Instantiation != InstantationType.Instant && Parent.transform.childCount < MaximumObjects)
			{
				if (currentTime >= SpawnInterval && SpawnObject())
				{
					currentTime = 0f;
				}
				currentTime += Time.deltaTime;
			}
		}

		private void OnDrawGizmosSelected()
		{
			float num = 0f;
			float num2 = 1f;
			if (XZSpawn)
			{
				num = 1f;
				num2 = 0f;
			}
			if (EnableGizmo)
			{
				Gizmos.color = Color.green;
				Vector3 position = base.gameObject.transform.position;
				Gizmos.DrawLine(new Vector3(SpawnArea.x, num2 * SpawnArea.y + num * position.y, num * SpawnArea.y + num2 * position.z), new Vector3(SpawnArea.xMax, num2 * SpawnArea.y + num * position.y, num * SpawnArea.y + num2 * position.z));
				Gizmos.DrawLine(new Vector3(SpawnArea.x, num2 * SpawnArea.yMax + num * position.y, num * SpawnArea.yMax + num2 * position.z), new Vector3(SpawnArea.xMax, num2 * SpawnArea.yMax + num * position.y, num * SpawnArea.yMax + num2 * position.z));
				Gizmos.DrawLine(new Vector3(SpawnArea.x, num2 * SpawnArea.y + num * position.y, num * SpawnArea.y + num2 * position.z), new Vector3(SpawnArea.x, num2 * SpawnArea.yMax + num * position.y, num * SpawnArea.yMax + num2 * position.z));
				Gizmos.DrawLine(new Vector3(SpawnArea.xMax, num2 * SpawnArea.y + num * position.y, num * SpawnArea.y + num2 * position.z), new Vector3(SpawnArea.xMax, num2 * SpawnArea.yMax + num * position.y, num * SpawnArea.yMax + num2 * position.z));
			}
		}
	}
}
