using System.Collections.Generic;
using UnityEngine;

namespace emotiontheory
{
	[RequireComponent(typeof(BoxCollider))]
	[ExecuteInEditMode]
	public class ETGrid : MonoBehaviour
	{
		private bool UseChildren;

		[Tooltip("Destroy this component and the collider after we're done.")]
		public bool DestroyOnStart = true;

		[Tooltip("The object to create.")]
		public GameObject Prefab;

		[HideInInspector]
		[SerializeField]
		private List<GameObject> gameObjects;

		private BoxCollider _boxCollider;

		[Tooltip("The distance between each object (use Count if you'd rather define a total number instead).")]
		public Vector3 Padding = new Vector3(1f, 2f, 1f);

		[Tooltip("[Optional] Random position variance.")]
		public Vector3 RandomVariance = new Vector3(0f, 0f, 0f);

		[Tooltip("Use a total count instead of calculating via Padding.")]
		public bool UseCount;

		[Tooltip("The total number of objects.")]
		public Vector3 Count = new Vector3(3f, 1f, 3f);

		private List<Vector3> positions;

		[Tooltip("Run automatically. (Right-click the script name to Run manually)")]
		public bool UpdateInRealTime;

		public BoxCollider boxCollider
		{
			get
			{
				if (!_boxCollider)
				{
					_boxCollider = GetComponent<Collider>() as BoxCollider;
				}
				return _boxCollider;
			}
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				base.enabled = false;
				boxCollider.enabled = false;
			}
		}

		private void Update()
		{
			if (UpdateInRealTime && !Application.isPlaying)
			{
				Run();
			}
		}

		[ContextMenu("Run")]
		public void Run()
		{
			foreach (GameObject gameObject in gameObjects)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(gameObject);
				}
				else
				{
					Object.DestroyImmediate(gameObject);
				}
			}
			gameObjects.Clear();
			foreach (Transform item in base.transform)
			{
				Object.DestroyImmediate(item.gameObject);
			}
			if (!Prefab && !UseChildren)
			{
				throw new UnityException("ObjectLattice requires a Prefab assigned.");
			}
			positions = CreatePositions();
			CreateObjects();
			if (DestroyOnStart && Application.isPlaying)
			{
				Object.Destroy(this);
				Object.Destroy(boxCollider);
			}
		}

		private List<Vector3> CreatePositions()
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f - boxCollider.size.x / 2f + boxCollider.center.x;
			float num2 = 0f - boxCollider.size.y / 2f + boxCollider.center.y;
			float num3 = 0f - boxCollider.size.z / 2f + boxCollider.center.z;
			int num4 = (int)(boxCollider.size.x / Padding.x + 1f);
			int num5 = (int)(boxCollider.size.y / Padding.y + 1f);
			int num6 = (int)(boxCollider.size.z / Padding.z + 1f);
			if (UseCount)
			{
				Count.x = Mathf.Clamp((int)Count.x, 1f, float.PositiveInfinity);
				Count.y = Mathf.Clamp((int)Count.y, 1f, float.PositiveInfinity);
				Count.z = Mathf.Clamp((int)Count.z, 1f, float.PositiveInfinity);
				if (Count.x == 1f)
				{
					Padding.x = boxCollider.size.x + 1f;
				}
				else
				{
					Padding.x = boxCollider.size.x / (float)((int)Count.x - 1);
				}
				if (Count.y == 1f)
				{
					Padding.y = boxCollider.size.y + 1f;
				}
				else
				{
					Padding.y = boxCollider.size.y / (float)((int)Count.y - 1);
				}
				if (Count.z == 1f)
				{
					Padding.z = boxCollider.size.z + 1f;
				}
				else
				{
					Padding.z = boxCollider.size.z / (float)((int)Count.z - 1);
				}
				num4 = (int)Count.x;
				num5 = (int)Count.y;
				num6 = (int)Count.z;
			}
			for (int i = 0; i < num4; i++)
			{
				for (int j = 0; j < num5; j++)
				{
					for (int k = 0; k < num6; k++)
					{
						Vector3 vector = new Vector3(num + (float)i * Padding.x, num2 + (float)j * Padding.y, num3 + (float)k * Padding.z);
						Vector3 vector2 = new Vector3(Random.Range(0f - RandomVariance.x, RandomVariance.x), Random.Range(0f - RandomVariance.y, RandomVariance.y), Random.Range(0f - RandomVariance.z, RandomVariance.z));
						Vector3 vector3 = vector + vector2;
						Vector3 item = new Vector3(Mathf.Clamp(vector3.x, num, num + boxCollider.size.x), Mathf.Clamp(vector3.y, num2, num2 + boxCollider.size.y), Mathf.Clamp(vector3.z, num3, num3 + boxCollider.size.z));
						list.Add(item);
					}
				}
			}
			return list;
		}

		private void CreateObjects()
		{
			if (!UseChildren)
			{
				foreach (Transform item in base.transform)
				{
					Object.Destroy(item.gameObject);
				}
				{
					foreach (Vector3 position in positions)
					{
						GameObject gameObject = Object.Instantiate(Prefab);
						gameObject.transform.parent = base.transform;
						gameObject.transform.localPosition = position;
						gameObject.transform.localEulerAngles = Vector3.zero;
						gameObjects.Add(gameObject);
					}
					return;
				}
			}
			int num = Mathf.Min(base.transform.childCount, positions.Count);
			for (int i = 0; i < num; i++)
			{
				Transform child = base.transform.GetChild(i);
				Vector3 localPosition = positions[i];
				child.localPosition = localPosition;
				gameObjects.Add(child.gameObject);
			}
		}
	}
}
