using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace CTS
{
	public class Vision : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private Agent _agent;

		[SerializeField]
		private Color _viewColor = Color.white;

		[SerializeField]
		private LayerMask _layersToCheck;

		[SerializeField]
		private LayerMask _obstructionlayers;

		private Collider[] _colliders = new Collider[10];

		private float _scanInterval;

		private float _scanTimer;

		private int _overlapCount;

		[field: SerializeField]
		public float Distance { get; private set; }

		[field: SerializeField]
		[field: Range(0f, 180f)]
		public float Angle { get; private set; }

		[field: SerializeField]
		[field: Range(0f, 10f)]
		public float Height { get; private set; }

		[field: SerializeField]
		[field: Range(1f, 60f)]
		public int ScanFrequency { get; private set; } = 30;

		[field: SerializeField]
		public List<GameObject> SightedObjects { get; private set; } = new List<GameObject>();

		public Mesh ViewMesh { get; private set; }

		public event Action<GameObject> GameObjectSighted;

		protected override void OnAwake()
		{
			ViewMesh = CreateMesh();
		}

		private void Start()
		{
			_scanInterval = 1f / (float)ScanFrequency;
		}

		private void Update()
		{
			if (_agent.IsVigilant)
			{
				_scanTimer -= Time.deltaTime;
				if (_scanTimer < 0f)
				{
					_scanTimer += _scanInterval;
					Scan();
				}
			}
		}

		public void Scan()
		{
			_overlapCount = Physics.OverlapSphereNonAlloc(base.transform.position, Distance + 1f, _colliders, _layersToCheck, QueryTriggerInteraction.Collide);
			List<GameObject> list = CollectionPool<List<GameObject>, GameObject>.Get();
			Vector3 position = base.transform.position;
			for (int i = 0; i < _overlapCount; i++)
			{
				Collider collider = _colliders[i];
				GameObject gameObject = collider.gameObject;
				if (SightedObjects.Contains(gameObject))
				{
					list.Add(gameObject);
					continue;
				}
				Vector3 center = collider.bounds.center;
				if (!(Vector3.Distance(position, center) > Distance) && IsInSight(collider.bounds.center))
				{
					list.Add(gameObject);
					SightedObjects.Add(gameObject);
					this.GameObjectSighted?.Invoke(gameObject);
				}
			}
			for (int num = SightedObjects.Count - 1; num >= 0; num--)
			{
				GameObject item = SightedObjects[num];
				if (!list.Contains(item))
				{
					SightedObjects.RemoveAt(num);
				}
			}
			CollectionPool<List<GameObject>, GameObject>.Release(list);
		}

		public bool IsInSight(Vector3 p_worldPosition)
		{
			Vector3 position = base.transform.position;
			Vector3 vector = p_worldPosition;
			Vector3 vector2 = vector - position;
			if (vector2.y < (0f - Height) * 0.5f || vector2.y > Height * 0.5f)
			{
				return false;
			}
			vector2.y = 0f;
			if (Vector3.Angle(vector2, base.transform.forward) > Angle)
			{
				return false;
			}
			vector.y = position.y;
			if (Physics.Linecast(position, vector, _obstructionlayers))
			{
				return false;
			}
			return true;
		}

		public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
		{
			if (!angleIsGlobal)
			{
				angleInDegrees += base.transform.eulerAngles.y;
			}
			return new Vector3(Mathf.Sin(angleInDegrees * (MathF.PI / 180f)), 0f, Mathf.Cos(angleInDegrees * (MathF.PI / 180f)));
		}

		private Mesh CreateMesh()
		{
			Mesh mesh = new Mesh();
			int num = 20;
			int num2 = (num * 4 + 2 + 2) * 3;
			Vector3[] array = new Vector3[num2];
			int[] array2 = new int[num2];
			Vector3 vector = new Vector3(0f, (0f - Height) * 0.5f, 0f);
			Vector3 vector2 = vector + Quaternion.Euler(0f, 0f - Angle, 0f) * Vector3.forward * Distance;
			Vector3 vector3 = vector + Quaternion.Euler(0f, Angle, 0f) * Vector3.forward * Distance;
			Vector3 vector4 = vector + Vector3.up * Height;
			Vector3 vector5 = vector3 + Vector3.up * Height;
			Vector3 vector6 = vector2 + Vector3.up * Height;
			int num3 = 0;
			array[num3++] = vector;
			array[num3++] = vector2;
			array[num3++] = vector6;
			array[num3++] = vector6;
			array[num3++] = vector4;
			array[num3++] = vector;
			array[num3++] = vector;
			array[num3++] = vector4;
			array[num3++] = vector5;
			array[num3++] = vector5;
			array[num3++] = vector3;
			array[num3++] = vector;
			float num4 = 0f - Angle;
			float num5 = Angle * 2f / (float)num;
			for (int i = 0; i < num; i++)
			{
				vector2 = vector + Quaternion.Euler(0f, num4, 0f) * Vector3.forward * Distance;
				vector3 = vector + Quaternion.Euler(0f, num4 + num5, 0f) * Vector3.forward * Distance;
				vector5 = vector3 + Vector3.up * Height;
				vector6 = vector2 + Vector3.up * Height;
				array[num3++] = vector2;
				array[num3++] = vector3;
				array[num3++] = vector5;
				array[num3++] = vector5;
				array[num3++] = vector6;
				array[num3++] = vector2;
				array[num3++] = vector4;
				array[num3++] = vector6;
				array[num3++] = vector5;
				array[num3++] = vector;
				array[num3++] = vector3;
				array[num3++] = vector2;
				num4 += num5;
			}
			for (int j = 0; j < num2; j++)
			{
				array2[j] = j;
			}
			mesh.vertices = array;
			mesh.triangles = array2;
			mesh.RecalculateNormals();
			return mesh;
		}

		private void OnValidate()
		{
			ViewMesh = CreateMesh();
			_scanInterval = 1f / (float)ScanFrequency;
		}

		private void OnDrawGizmosSelected()
		{
			if ((bool)ViewMesh)
			{
				Gizmos.color = _viewColor;
				Gizmos.DrawMesh(ViewMesh, base.transform.position, base.transform.rotation);
			}
			Gizmos.DrawWireSphere(base.transform.position, Distance);
			for (int i = 0; i < _overlapCount; i++)
			{
				Gizmos.DrawSphere(_colliders[i].transform.position, 0.2f);
			}
			Gizmos.color = Color.green;
			foreach (GameObject sightedObject in SightedObjects)
			{
				Gizmos.DrawLine(base.transform.position, sightedObject.transform.position);
				Gizmos.DrawSphere(sightedObject.transform.position, 0.2f);
			}
		}
	}
}
