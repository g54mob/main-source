using System.Collections.Generic;
using UnityEngine;

namespace emotiontheory
{
	[RequireComponent(typeof(SphereCollider))]
	[ExecuteInEditMode]
	public class ETCircle : MonoBehaviour
	{
		private bool UseChildren;

		[Tooltip("Destroy this component and the collider after we're done.")]
		public bool DestroyOnStart = true;

		[Tooltip("The object we're trying to create.")]
		public GameObject Prefab;

		[HideInInspector]
		[SerializeField]
		private List<GameObject> gameObjects;

		private SphereCollider _sphereCollider;

		[Tooltip("Offset the rotation by a step.")]
		[Range(0f, 1f)]
		public int RotationOffset;

		[Tooltip("The total number of objects.")]
		[Range(1f, 360f)]
		public int Count = 4;

		[Tooltip("How much variance there is within the circle.")]
		[Range(0f, 1f)]
		public float RandomVariance;

		[Tooltip("Determines whether each object should be rotated to face outwards from the center.")]
		public bool FaceOutwards;

		private List<Vector3> positions;

		private List<Quaternion> rotations;

		[Tooltip("Run automatically. (Right-click the script name to Run manually)")]
		public bool UpdateInRealTime;

		public SphereCollider sphereCollider
		{
			get
			{
				if (!_sphereCollider)
				{
					_sphereCollider = GetComponent<Collider>() as SphereCollider;
				}
				return _sphereCollider;
			}
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				base.enabled = false;
				sphereCollider.enabled = false;
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
			CreatePositions();
			CreateObjects();
			if (DestroyOnStart && Application.isPlaying)
			{
				Object.Destroy(this);
				Object.Destroy(sphereCollider);
			}
		}

		private void CreatePositions()
		{
			positions = new List<Vector3>();
			rotations = new List<Quaternion>();
			float num = 360f / (float)Count;
			float radius = sphereCollider.radius;
			float num2 = (float)RotationOffset * (num / 2f);
			float num3 = Random.Range((0f - RandomVariance) * num, RandomVariance * num);
			for (int i = 0; i < Count; i++)
			{
				Quaternion quaternion = Quaternion.Euler(0f, num2 + (num + num3) * (float)i, 0f);
				Vector3 item = quaternion * new Vector3(0f, 0f, radius);
				positions.Add(item);
				rotations.Add(quaternion);
			}
		}

		private void CreateObjects()
		{
			foreach (Transform item in base.transform)
			{
				Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < positions.Count; i++)
			{
				Vector3 localPosition = positions[i];
				Quaternion localRotation = rotations[i];
				GameObject gameObject = Object.Instantiate(Prefab);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = localPosition;
				if (FaceOutwards)
				{
					gameObject.transform.localRotation = localRotation;
				}
				else
				{
					gameObject.transform.localEulerAngles = Vector3.zero;
				}
				gameObjects.Add(gameObject);
			}
		}
	}
}
