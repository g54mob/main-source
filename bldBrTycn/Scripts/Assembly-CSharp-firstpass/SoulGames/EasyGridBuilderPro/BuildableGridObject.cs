using System;
using System.Collections.Generic;
using SoulGames.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace SoulGames.EasyGridBuilderPro
{
	public class BuildableGridObject : MonoBehaviour
	{
		public delegate void OnBuildableGridObjectBuiltDelegate(BuildableGridObject buildableGridObject);

		[Serializable]
		public class SaveObject
		{
			public string buildableGridObjectTypeSOName;

			public Vector2Int origin;

			public BuildableGridObjectTypeSO.Dir dir;
		}

		private Vector2Int calculatedWidthAndlength;

		private bool showGridBelowObject;

		private Canvas objectGridCanvas;

		private Sprite gridImageSprite;

		private Color gridImagePlaceableColor;

		private Color gridImageNotPlaceableColor;

		private GameObject spawnedCanvas;

		private Image gridImage;

		private float cellSize;

		private bool isObjectBuilt;

		private bool enableCanvas;

		private EasyGridBuilderPro ownGridSystem;

		private int ownGridSystemActiveGridIndex;

		private EasyGridBuilderPro activeGridSystem;

		[Tooltip("Provide this Buildable Grid Object's 'Buildable Grid Object Type SO'")]
		[SerializeField]
		private BuildableGridObjectTypeSO buildableGridObjectTypeSO;

		[Tooltip("Rotate object automatically in XY Grid Axis. (Which means this object is originally prepared for the Grid Axis XZ)")]
		[SerializeField]
		public bool rotateObjectForXY;

		[Tooltip("Rotate object automatically in XZ Grid Axis. (Which means this object is originally prepared for the Grid Axis XY)")]
		[SerializeField]
		public bool rotateObjectForXZ;

		private Vector2Int origin;

		private BuildableGridObjectTypeSO.Dir dir;

		private bool canvasHandleCalled;

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

		public static event OnBuildableGridObjectBuiltDelegate OnBuildableGridObjectBuilt;

		private void Start()
		{
			if (MultiGridManager.Instance.activeGridSystem == null)
			{
				return;
			}
			activeGridSystem = MultiGridManager.Instance.activeGridSystem;
			GridObjectSelector.OnObjectSelect += OnObjectSelect;
			GridObjectSelector.OnObjectDeselect += OnObjectDeselect;
			GridObjectMover.OnObjectStartMoving += OnObjectStartMoving;
			GridObjectMover.OnObjectStoppedMoving += OnObjectStoppedMoving;
			cellSize = activeGridSystem.GetGridCellSize();
			calculatedWidthAndlength = buildableGridObjectTypeSO.CalculatePlacedObjectSize(cellSize);
			showGridBelowObject = buildableGridObjectTypeSO.showGridBelowObject;
			objectGridCanvas = buildableGridObjectTypeSO.objectGridCanvas;
			gridImageSprite = buildableGridObjectTypeSO.gridImageSprite;
			gridImagePlaceableColor = buildableGridObjectTypeSO.gridImagePlaceableColor;
			gridImageNotPlaceableColor = buildableGridObjectTypeSO.gridImageNotPlaceableColor;
			if (showGridBelowObject)
			{
				if (!canvasHandleCalled)
				{
					spawnedCanvas = UnityEngine.Object.Instantiate(objectGridCanvas.gameObject, Vector3.zero, Quaternion.identity);
					spawnedCanvas.transform.SetParent(base.transform, worldPositionStays: false);
				}
				HandleVisualCanvasGrid(activeGridSystem);
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
			if (selectedObject.GetComponent<BuildableGridObject>() == this)
			{
				enableCanvas = true;
			}
			else
			{
				enableCanvas = false;
			}
		}

		private void OnObjectDeselect(EasyGridBuilderPro ownSystem, GameObject selectedObject)
		{
			enableCanvas = false;
		}

		private void OnObjectStartMoving(EasyGridBuilderPro ownSystem, GameObject movingObject)
		{
			if (movingObject.GetComponent<BuildableGridObject>() == this)
			{
				enableCanvas = true;
			}
			else
			{
				enableCanvas = false;
			}
		}

		private void OnObjectStoppedMoving(EasyGridBuilderPro ownSystem, GameObject movingObject)
		{
			enableCanvas = false;
		}

		private void Update()
		{
			if (!isObjectBuilt && showGridBelowObject)
			{
				HandleVisualCanvasGridColor();
			}
			else if (isObjectBuilt)
			{
				HandleVisualCanvasGridMode();
			}
		}

		public static BuildableGridObject Create(Vector3 worldPosition, Vector2Int origin, BuildableGridObjectTypeSO.Dir dir, BuildableGridObjectTypeSO buildableGridObjectTypeSO, EasyGridBuilderPro system)
		{
			Transform transform = UnityEngine.Object.Instantiate(buildableGridObjectTypeSO.objectPrefab[UnityEngine.Random.Range(0, buildableGridObjectTypeSO.objectPrefab.Length)], Vector3.zero, Quaternion.identity);
			transform.name = transform.name.Replace("(Clone)", "").Trim();
			transform.rotation = Quaternion.Euler(0f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
			transform.localPosition = worldPosition;
			if (buildableGridObjectTypeSO.setBuiltObjectLayer)
			{
				SetLayerRecursive(transform.gameObject, LayerNumber(buildableGridObjectTypeSO.builtObjectLayer));
			}
			float gridCellSize = system.GetGridCellSize();
			Vector2Int vector2Int = buildableGridObjectTypeSO.CalculatePlacedObjectSize(gridCellSize);
			BuildableGridObject component = transform.GetComponent<BuildableGridObject>();
			if (system.gridAxis == GridAxis.XZ)
			{
				if (component.IsRotateObjectForXZ())
				{
					switch (buildableGridObjectTypeSO.GetRotationAngle(dir))
					{
					case 0:
						transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.x * gridCellSize / 2f, worldPosition.y, transform.localPosition.z + (float)vector2Int.y * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().x, transform.localPosition.y - component.GetObjectPivotOffset().z, transform.localPosition.z - component.GetObjectPivotOffset().y);
						break;
					case 90:
						transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.y * gridCellSize / 2f, worldPosition.y, transform.localPosition.z - (float)vector2Int.x * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().y, transform.localPosition.y - component.GetObjectPivotOffset().z, transform.localPosition.z + component.GetObjectPivotOffset().x);
						break;
					case 180:
						transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.x * gridCellSize / 2f, worldPosition.y, transform.localPosition.z - (float)vector2Int.y * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().x, transform.localPosition.y - component.GetObjectPivotOffset().z, transform.localPosition.z + component.GetObjectPivotOffset().y);
						break;
					case 270:
						transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.y * gridCellSize / 2f, worldPosition.y, transform.localPosition.z + (float)vector2Int.x * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().y, transform.localPosition.y - component.GetObjectPivotOffset().z, transform.localPosition.z - component.GetObjectPivotOffset().x);
						break;
					}
				}
				else
				{
					switch (buildableGridObjectTypeSO.GetRotationAngle(dir))
					{
					case 0:
						transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.x * gridCellSize / 2f, worldPosition.y, transform.localPosition.z + (float)vector2Int.y * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().x, transform.localPosition.y - component.GetObjectPivotOffset().y, transform.localPosition.z - component.GetObjectPivotOffset().z);
						break;
					case 90:
						transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.y * gridCellSize / 2f, worldPosition.y, transform.localPosition.z - (float)vector2Int.x * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().z, transform.localPosition.y - component.GetObjectPivotOffset().y, transform.localPosition.z + component.GetObjectPivotOffset().x);
						break;
					case 180:
						transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.x * gridCellSize / 2f, worldPosition.y, transform.localPosition.z - (float)vector2Int.y * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().x, transform.localPosition.y - component.GetObjectPivotOffset().y, transform.localPosition.z + component.GetObjectPivotOffset().z);
						break;
					case 270:
						transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.y * gridCellSize / 2f, worldPosition.y, transform.localPosition.z + (float)vector2Int.x * gridCellSize / 2f);
						transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().z, transform.localPosition.y - component.GetObjectPivotOffset().y, transform.localPosition.z - component.GetObjectPivotOffset().x);
						break;
					}
				}
			}
			else if (component.IsRotateObjectForXY())
			{
				switch (buildableGridObjectTypeSO.GetRotationAngle(dir))
				{
				case 0:
					transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.y + (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().x, transform.localPosition.y - component.GetObjectPivotOffset().z, transform.localPosition.z + component.GetObjectPivotOffset().y);
					break;
				case 90:
					transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.y - (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().z, transform.localPosition.y + component.GetObjectPivotOffset().x, transform.localPosition.z + component.GetObjectPivotOffset().y);
					break;
				case 180:
					transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.y - (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().x, transform.localPosition.y + component.GetObjectPivotOffset().z, transform.localPosition.z + component.GetObjectPivotOffset().y);
					break;
				case 270:
					transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.y + (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().z, transform.localPosition.y - component.GetObjectPivotOffset().x, transform.localPosition.z + component.GetObjectPivotOffset().y);
					break;
				}
			}
			else
			{
				switch (buildableGridObjectTypeSO.GetRotationAngle(dir))
				{
				case 0:
					transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.y + (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().x, transform.localPosition.y - component.GetObjectPivotOffset().y, transform.localPosition.z + component.GetObjectPivotOffset().z);
					break;
				case 90:
					transform.localPosition = new Vector3(transform.localPosition.x + (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.y - (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x - component.GetObjectPivotOffset().y, transform.localPosition.y + component.GetObjectPivotOffset().x, transform.localPosition.z + component.GetObjectPivotOffset().z);
					break;
				case 180:
					transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.y - (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().x, transform.localPosition.y + component.GetObjectPivotOffset().y, transform.localPosition.z + component.GetObjectPivotOffset().z);
					break;
				case 270:
					transform.localPosition = new Vector3(transform.localPosition.x - (float)vector2Int.y * gridCellSize / 2f, transform.localPosition.y + (float)vector2Int.x * gridCellSize / 2f, transform.localPosition.z);
					transform.localPosition = new Vector3(transform.localPosition.x + component.GetObjectPivotOffset().y, transform.localPosition.y - component.GetObjectPivotOffset().x, transform.localPosition.z + component.GetObjectPivotOffset().z);
					break;
				}
			}
			component.origin = origin;
			component.dir = dir;
			component.cellSize = gridCellSize;
			component.calculatedWidthAndlength = vector2Int;
			if (!component.canvasHandleCalled)
			{
				component.spawnedCanvas = UnityEngine.Object.Instantiate(component.buildableGridObjectTypeSO.objectGridCanvas.gameObject, Vector3.zero, Quaternion.identity);
				component.spawnedCanvas.transform.SetParent(component.transform, worldPositionStays: false);
			}
			component.HandleVisualCanvasGrid(system);
			component.Setup();
			return component;
		}

		protected void Setup()
		{
			BuildableGridObject.OnBuildableGridObjectBuilt?.Invoke(this);
		}

		public void GridSetupDone(EasyGridBuilderPro gridSystem, bool isObjectBuilt, int activeGridIndex, BuildableGridObjectTypeSO.Dir dir)
		{
			this.isObjectBuilt = isObjectBuilt;
			ownGridSystem = gridSystem;
			ownGridSystemActiveGridIndex = activeGridIndex;
			if (gridSystem.gridAxis == GridAxis.XY)
			{
				if (IsRotateObjectForXY())
				{
					switch (dir)
					{
					case BuildableGridObjectTypeSO.Dir.Down:
						base.transform.rotation = Quaternion.Euler(-90f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
						break;
					case BuildableGridObjectTypeSO.Dir.Left:
						base.transform.rotation = Quaternion.Euler(0f, buildableGridObjectTypeSO.GetRotationAngle(dir), -90f);
						break;
					case BuildableGridObjectTypeSO.Dir.Up:
						base.transform.rotation = Quaternion.Euler(90f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
						break;
					case BuildableGridObjectTypeSO.Dir.Right:
						base.transform.rotation = Quaternion.Euler(0f, buildableGridObjectTypeSO.GetRotationAngle(dir), 90f);
						break;
					}
				}
			}
			else if (IsRotateObjectForXZ())
			{
				switch (dir)
				{
				case BuildableGridObjectTypeSO.Dir.Down:
					base.transform.rotation = Quaternion.Euler(90f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
					break;
				case BuildableGridObjectTypeSO.Dir.Left:
					base.transform.rotation = Quaternion.Euler(90f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
					break;
				case BuildableGridObjectTypeSO.Dir.Up:
					base.transform.rotation = Quaternion.Euler(90f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
					break;
				case BuildableGridObjectTypeSO.Dir.Right:
					base.transform.rotation = Quaternion.Euler(90f, buildableGridObjectTypeSO.GetRotationAngle(dir), 0f);
					break;
				}
			}
		}

		public bool GetIsObjectBuilt()
		{
			return isObjectBuilt;
		}

		protected void TriggerGridObjectChanged()
		{
			if (activeGridSystem.gridAxis == GridAxis.XZ)
			{
				foreach (Vector2Int gridPosition in GetGridPositionList())
				{
					activeGridSystem.GetGridObjectXZ(gridPosition).TriggerGridObjectChanged();
				}
				return;
			}
			foreach (Vector2Int gridPosition2 in GetGridPositionList())
			{
				activeGridSystem.GetGridObjectXY(gridPosition2).TriggerGridObjectChanged();
			}
		}

		private void HandleVisualCanvasGrid(EasyGridBuilderPro activeGridSystem)
		{
			if (activeGridSystem.gridAxis == GridAxis.XZ)
			{
				if (!spawnedCanvas)
				{
					return;
				}
				Transform child = spawnedCanvas.transform.GetChild(0);
				gridImage = child.GetComponent<Image>();
				if (!canvasHandleCalled)
				{
					Vector2 sizeDelta = new Vector2((float)buildableGridObjectTypeSO.CalculatePlacedObjectSize(activeGridSystem.GetGridCellSize()).x * activeGridSystem.GetGridCellSize(), (float)buildableGridObjectTypeSO.CalculatePlacedObjectSize(activeGridSystem.GetGridCellSize()).y * activeGridSystem.GetGridCellSize());
					if (IsRotateObjectForXZ())
					{
						spawnedCanvas.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						spawnedCanvas.transform.localPosition = new Vector3(sizeDelta.x / -2f, sizeDelta.y / -2f, 0f);
						spawnedCanvas.transform.localPosition = new Vector3(spawnedCanvas.transform.localPosition.x + GetObjectPivotOffset().x, spawnedCanvas.transform.localPosition.y + GetObjectPivotOffset().y, spawnedCanvas.transform.localPosition.z);
					}
					else
					{
						spawnedCanvas.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
						spawnedCanvas.transform.localPosition = new Vector3(sizeDelta.x / -2f, 0f, sizeDelta.y / -2f);
						spawnedCanvas.transform.localPosition = new Vector3(spawnedCanvas.transform.localPosition.x + GetObjectPivotOffset().x, spawnedCanvas.transform.localPosition.y, spawnedCanvas.transform.localPosition.z + GetObjectPivotOffset().z);
					}
					spawnedCanvas.GetComponent<RectTransform>().sizeDelta = sizeDelta;
					child.GetComponent<RectTransform>().sizeDelta = sizeDelta;
				}
				gridImage.sprite = gridImageSprite;
				gridImage.type = Image.Type.Tiled;
				if (!canvasHandleCalled)
				{
					gridImage.pixelsPerUnitMultiplier = 100f / activeGridSystem.GetGridCellSize();
					canvasHandleCalled = true;
				}
				gridImage.color = gridImagePlaceableColor;
			}
			else
			{
				if (!spawnedCanvas)
				{
					return;
				}
				Transform child2 = spawnedCanvas.transform.GetChild(0);
				gridImage = child2.GetComponent<Image>();
				if (!canvasHandleCalled)
				{
					Vector2 sizeDelta2 = new Vector2((float)buildableGridObjectTypeSO.CalculatePlacedObjectSize(activeGridSystem.GetGridCellSize()).x * activeGridSystem.GetGridCellSize(), (float)buildableGridObjectTypeSO.CalculatePlacedObjectSize(activeGridSystem.GetGridCellSize()).y * activeGridSystem.GetGridCellSize());
					if (IsRotateObjectForXY())
					{
						spawnedCanvas.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
						spawnedCanvas.transform.localPosition = new Vector3(sizeDelta2.x / -2f, 0f, sizeDelta2.y / 2f);
						spawnedCanvas.transform.localPosition = new Vector3(spawnedCanvas.transform.localPosition.x + GetObjectPivotOffset().x, spawnedCanvas.transform.localPosition.y, spawnedCanvas.transform.localPosition.z + GetObjectPivotOffset().z);
					}
					else
					{
						spawnedCanvas.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						spawnedCanvas.transform.localPosition = new Vector3(sizeDelta2.x / -2f, sizeDelta2.y / -2f, 0f);
						spawnedCanvas.transform.localPosition = new Vector3(spawnedCanvas.transform.localPosition.x + GetObjectPivotOffset().x, spawnedCanvas.transform.localPosition.y + GetObjectPivotOffset().y, spawnedCanvas.transform.localPosition.z);
					}
					spawnedCanvas.GetComponent<RectTransform>().sizeDelta = sizeDelta2;
					child2.GetComponent<RectTransform>().sizeDelta = sizeDelta2;
				}
				gridImage.sprite = gridImageSprite;
				gridImage.type = Image.Type.Tiled;
				if (!canvasHandleCalled)
				{
					gridImage.pixelsPerUnitMultiplier = 100f / activeGridSystem.GetGridCellSize();
					canvasHandleCalled = true;
				}
				gridImage.color = gridImagePlaceableColor;
			}
		}

		private void HandleVisualCanvasGridColor()
		{
			if ((bool)spawnedCanvas)
			{
				if (!activeGridSystem.NotPlaceableVisualCallerBuildableGridObject())
				{
					gridImage.color = gridImageNotPlaceableColor;
				}
				else
				{
					gridImage.color = gridImagePlaceableColor;
				}
			}
		}

		private void HandleVisualCanvasGridMode()
		{
			if (enableCanvas && !spawnedCanvas.activeSelf)
			{
				spawnedCanvas.SetActive(value: true);
			}
			else if (!enableCanvas && spawnedCanvas.activeSelf)
			{
				spawnedCanvas.SetActive(value: false);
			}
		}

		public EasyGridBuilderPro GetOwnGridSystem()
		{
			return ownGridSystem;
		}

		public int GetOwnGridSystemActiveGridIndex()
		{
			return ownGridSystemActiveGridIndex;
		}

		public Vector2Int GetGridOrigin()
		{
			return origin;
		}

		public List<Vector2Int> GetGridPositionList()
		{
			return buildableGridObjectTypeSO.GetGridPositionList(origin, dir, activeGridSystem.GetGridCellSize());
		}

		public virtual void DestroySelf()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public override string ToString()
		{
			return buildableGridObjectTypeSO.objectName;
		}

		public BuildableGridObjectTypeSO GetBuildableGridObjectTypeSO()
		{
			return buildableGridObjectTypeSO;
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
				UnityEngine.Object.DestroyImmediate(base.gameObject.GetComponent<BoxCollider>(), allowDestroyingAssets: true);
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

		public SaveObject GetSaveObject()
		{
			return new SaveObject
			{
				buildableGridObjectTypeSOName = buildableGridObjectTypeSO.name,
				origin = origin,
				dir = dir
			};
		}
	}
}
