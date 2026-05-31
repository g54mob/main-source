using SoulGames.Utilities;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class BuildableFreeObject : MonoBehaviour
	{
		public delegate void OnBuildableFreeObjectBuiltDelegate(BuildableFreeObject buildableFreeObject);

		private EasyGridBuilderPro ownGridSystem;

		private EasyGridBuilderPro activeGridSystem;

		private bool isObjectBuilt;

		[Tooltip("Provide this Buildable Free Object's 'Buildable Free Object Type SO'")]
		[SerializeField]
		private BuildableFreeObjectTypeSO buildableFreeObjectTypeSO;

		[Tooltip("Rotate object automatically in XY Grid Axis. (Which means this object is originally prepared for the Grid Axis XZ)")]
		[SerializeField]
		public bool rotateObjectForXY;

		[Tooltip("Rotate object automatically in XZ Grid Axis. (Which means this object is originally prepared for the Grid Axis XY)")]
		[SerializeField]
		public bool rotateObjectForXZ;

		[Rename("Rotate Scale & Pivot For XY")]
		[Tooltip("Set pivot on XY axis instead of XZ axis. (Use this if the object is originally prepared for the Grid Axis XY)")]
		[SerializeField]
		private bool rotateForXY;

		[Tooltip("Scale of the Object. (This is used to calculate grid object size and collision)")]
		[SerializeField]
		private Vector3 objectScale;

		[Tooltip("Offset of the Object Scale")]
		[SerializeField]
		private Vector3 objectCenter;

		[Tooltip("Custom Pivot position of this object")]
		[SerializeField]
		private Vector3 objectCustomPivot;

		private bool hasCollider;

		public static event OnBuildableFreeObjectBuiltDelegate OnBuildableFreeObjectBuilt;

		private void Start()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null))
			{
				activeGridSystem = MultiGridManager.Instance.activeGridSystem;
				GridObjectSelector.OnObjectSelect += OnObjectSelect;
				GridObjectSelector.OnObjectDeselect += OnObjectDeselect;
				GridObjectMover.OnObjectStartMoving += OnObjectStartMoving;
				GridObjectMover.OnObjectStoppedMoving += OnObjectStoppedMoving;
			}
		}

		private void OnDestroy()
		{
			GridObjectSelector.OnObjectSelect -= OnObjectSelect;
			GridObjectSelector.OnObjectDeselect -= OnObjectDeselect;
			GridObjectMover.OnObjectStartMoving -= OnObjectStartMoving;
			GridObjectMover.OnObjectStoppedMoving -= OnObjectStoppedMoving;
		}

		private void OnObjectSelect(EasyGridBuilderPro ownSystem, GameObject selectedObject)
		{
		}

		private void OnObjectDeselect(EasyGridBuilderPro ownSystem, GameObject selectedObject)
		{
		}

		private void OnObjectStartMoving(EasyGridBuilderPro ownSystem, GameObject movingObject)
		{
		}

		private void OnObjectStoppedMoving(EasyGridBuilderPro ownSystem, GameObject movingObject)
		{
		}

		public static BuildableFreeObject Create(Vector3 worldPosition, float rotation, BuildableFreeObjectTypeSO buildableFreeObjectTypeSO, EasyGridBuilderPro system)
		{
			Transform transform = Object.Instantiate(buildableFreeObjectTypeSO.objectPrefab[Random.Range(0, buildableFreeObjectTypeSO.objectPrefab.Length)], Vector3.zero, Quaternion.identity);
			transform.name = transform.name.Replace("(Clone)", "").Trim();
			transform.rotation = Quaternion.Euler(0f, rotation, 0f);
			transform.localPosition = worldPosition;
			BuildableFreeObject component = transform.GetComponent<BuildableFreeObject>();
			if (system.gridAxis == GridAxis.XZ)
			{
				if (component.IsRotateObjectForXZ())
				{
					Transform transform2 = new GameObject("tempTransform").transform;
					transform2.localPosition = worldPosition;
					transform2.rotation = Quaternion.Euler(90f, 0f, 0f);
					transform.parent = transform2;
					transform.localEulerAngles = new Vector3(0f, 0f, 0f - rotation);
					transform.parent = null;
					Object.Destroy(transform2.gameObject);
				}
				else
				{
					transform.rotation = Quaternion.Euler(0f, rotation, 0f);
				}
			}
			else if (component.IsRotateObjectForXY())
			{
				Transform transform3 = new GameObject("tempTransform").transform;
				transform3.localPosition = worldPosition;
				transform3.rotation = Quaternion.Euler(-90f, 0f, 0f);
				transform.parent = transform3;
				transform.localEulerAngles = new Vector3(0f, 0f - rotation, 0f);
				transform.parent = null;
				Object.Destroy(transform3.gameObject);
			}
			else
			{
				transform.rotation = Quaternion.Euler(0f, 0f, rotation);
			}
			if (buildableFreeObjectTypeSO.setBuiltObjectLayer)
			{
				SetLayerRecursive(transform.gameObject, LayerNumber(buildableFreeObjectTypeSO.builtObjectLayer));
			}
			component.Setup();
			return component;
		}

		protected void Setup()
		{
			BuildableFreeObject.OnBuildableFreeObjectBuilt?.Invoke(this);
		}

		public void GridSetupDone(EasyGridBuilderPro gridSystem, bool isObjectBuilt, float rotation)
		{
			this.isObjectBuilt = isObjectBuilt;
			ownGridSystem = gridSystem;
		}

		public bool GetIsObjectBuilt()
		{
			return isObjectBuilt;
		}

		public virtual void DestroySelf()
		{
			Object.Destroy(base.gameObject);
		}

		public override string ToString()
		{
			return buildableFreeObjectTypeSO.objectName;
		}

		public EasyGridBuilderPro GetOwnGridSystem()
		{
			return ownGridSystem;
		}

		public BuildableFreeObjectTypeSO GetBuildableFreeObjectTypeSO()
		{
			return buildableFreeObjectTypeSO;
		}

		public Vector3 GetRawObjectScale()
		{
			return objectScale;
		}

		public Vector3 GetRawObjectCenter()
		{
			return objectCenter;
		}

		public bool IsRotateObjectForXY()
		{
			return rotateObjectForXY;
		}

		public bool IsRotateObjectForXZ()
		{
			return rotateObjectForXZ;
		}

		public Vector3 GetObjectPivotOffset()
		{
			return objectCustomPivot;
		}

		public Vector2 GetObjectScale()
		{
			if (ownGridSystem != null)
			{
				if (ownGridSystem.gridAxis == GridAxis.XZ)
				{
					if (rotateObjectForXZ)
					{
						return new Vector2(objectScale.x, objectScale.y);
					}
					return new Vector2(objectScale.x, objectScale.z);
				}
				if (rotateObjectForXY)
				{
					return new Vector2(objectScale.x, objectScale.z);
				}
				return new Vector2(objectScale.x, objectScale.y);
			}
			if (MultiGridManager.Instance.activeGridSystem.gridAxis == GridAxis.XZ)
			{
				if (rotateObjectForXZ)
				{
					return new Vector2(objectScale.x, objectScale.y);
				}
				return new Vector2(objectScale.x, objectScale.z);
			}
			if (rotateObjectForXY)
			{
				return new Vector2(objectScale.x, objectScale.z);
			}
			return new Vector2(objectScale.x, objectScale.y);
		}

		public void AutoCalculatePivotAndSize()
		{
			if (!base.gameObject.GetComponent<BoxCollider>())
			{
				base.gameObject.AddComponent<BoxCollider>();
				hasCollider = false;
			}
			else
			{
				hasCollider = true;
			}
			bool flag = false;
			Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
			if (base.gameObject.transform.childCount != 0)
			{
				for (int i = 0; i < base.gameObject.transform.childCount; i++)
				{
					Renderer component = base.gameObject.transform.GetChild(i).GetComponent<Renderer>();
					if (component != null)
					{
						if (flag)
						{
							bounds.Encapsulate(component.bounds);
							continue;
						}
						bounds = component.bounds;
						flag = true;
					}
				}
				BoxCollider component2 = base.gameObject.GetComponent<BoxCollider>();
				component2.center = bounds.center - base.gameObject.transform.position;
				component2.size = bounds.size;
			}
			objectScale = GetComponent<BoxCollider>().bounds.size;
			objectCenter = GetComponent<BoxCollider>().bounds.center;
			if (rotateForXY)
			{
				objectCustomPivot = new Vector3(objectCenter.x, objectCenter.y, objectCenter.z + objectScale.z / 2f);
			}
			else
			{
				objectCustomPivot = new Vector3(objectCenter.x, objectCenter.y - objectScale.y / 2f, objectCenter.z);
			}
			if (!hasCollider)
			{
				Object.DestroyImmediate(base.gameObject.GetComponent<BoxCollider>(), allowDestroyingAssets: true);
			}
		}

		private void OnDrawGizmos()
		{
			if (!Application.isPlaying)
			{
				Gizmos.color = Color.cyan;
				Gizmos.DrawWireCube(objectCenter, objectScale);
				Vector3 vector = objectCustomPivot;
				Vector3 to = ((!rotateForXY) ? new Vector3(objectCustomPivot.x, objectCustomPivot.y + objectScale.y, objectCustomPivot.z) : new Vector3(objectCustomPivot.x, objectCustomPivot.y, objectCustomPivot.z - objectScale.z));
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(vector, 0.2f);
				Gizmos.DrawLine(vector, to);
			}
		}

		private static int LayerNumber(LayerMask builtObjectLayer)
		{
			int num = 0;
			int num2 = builtObjectLayer.value;
			while (num2 > 0)
			{
				num2 >>= 1;
				num++;
			}
			if (num > 1)
			{
				return num - 1;
			}
			return 0;
		}

		private static void SetLayerRecursive(GameObject targetGameObject, int layer)
		{
			targetGameObject.layer = layer;
			foreach (Transform item in targetGameObject.transform)
			{
				SetLayerRecursive(item.gameObject, layer);
			}
		}
	}
}
