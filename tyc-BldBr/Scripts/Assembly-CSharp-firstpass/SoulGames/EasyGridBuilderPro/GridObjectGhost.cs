using System;
using SoulGames.Utilities;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class GridObjectGhost : MonoBehaviour
	{
		public delegate void OnBuildableObjectAreaBlockerEnterDelegate();

		public delegate void OnBuildableObjectAreaBlockerExitDelegate();

		[Tooltip("Spawned Ghost object's layer. \nIMPORTANT: Set this to 'Ignore Raycast' layer.")]
		[SerializeField]
		private LayerMask ghostObjectLayer;

		private Transform visual;

		private Transform parentObject;

		private EasyGridBuilderPro currentActiveSystem;

		private Material selectedMat;

		private bool updateFix;

		private BoxCollider tempCollider;

		private Rigidbody tempRB;

		private ColliderBridgeGridObject colliderBridge;

		private Vector3 tempColliderScale;

		private Vector3 tempColliderCenter;

		public static event OnBuildableObjectAreaBlockerEnterDelegate OnBuildableObjectAreaBlockerEnter;

		public static event OnBuildableObjectAreaBlockerExitDelegate OnBuildableObjectAreaBlockerExit;

		private void Start()
		{
			if (MultiGridManager.Instance.activeGridSystem == null)
			{
				return;
			}
			currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
			CleanObject();
			RefreshVisual();
			MultiGridManager.Instance.OnActiveGridChanged += OnGridSystemChanged;
			foreach (EasyGridBuilderPro easyGridBuilderPro in MultiGridManager.Instance.easyGridBuilderProList)
			{
				easyGridBuilderPro.OnSelectedBuildableChanged += OnSelectedChanged;
			}
		}

		private void OnDestroy()
		{
			MultiGridManager.Instance.OnActiveGridChanged -= OnGridSystemChanged;
			foreach (EasyGridBuilderPro easyGridBuilderPro in MultiGridManager.Instance.easyGridBuilderProList)
			{
				easyGridBuilderPro.OnSelectedBuildableChanged -= OnSelectedChanged;
			}
		}

		private void OnSelectedChanged(object sender, EventArgs e)
		{
			CleanObject();
			RefreshVisual();
		}

		private void OnGridSystemChanged(EasyGridBuilderPro currentActiveSystem)
		{
			this.currentActiveSystem = currentActiveSystem;
			currentActiveSystem.GetBuildableGridObjectTypeSO();
			CleanObject();
			RefreshVisual();
		}

		private void Update()
		{
			if (MultiGridManager.Instance.activeGridSystem == null)
			{
				return;
			}
			currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
			currentActiveSystem.GetBuildableGridObjectTypeSO();
			if (visual != null && currentActiveSystem.GetGridMode() != GridMode.Build)
			{
				UnityEngine.Object.Destroy(parentObject.gameObject);
				parentObject = null;
				visual = null;
			}
			if (!MultiGridManager.Instance.onGrid)
			{
				if (visual != null)
				{
					UnityEngine.Object.Destroy(parentObject.gameObject);
					parentObject = null;
					visual = null;
					updateFix = true;
				}
			}
			else if (updateFix)
			{
				CleanObject();
				RefreshVisual();
				updateFix = false;
			}
		}

		private void LateUpdate()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null))
			{
				if (currentActiveSystem.gridAxis == GridAxis.XZ)
				{
					Vector3 mouseWorldSnappedPosition = currentActiveSystem.GetMouseWorldSnappedPosition();
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(mouseWorldSnappedPosition.x, currentActiveSystem.GetGridOrigin().y, mouseWorldSnappedPosition.z), Time.deltaTime * 25f);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, currentActiveSystem.GetPlacedObjectRotation(), Time.deltaTime * 25f);
				}
				else
				{
					Vector3 mouseWorldSnappedPosition2 = currentActiveSystem.GetMouseWorldSnappedPosition();
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(mouseWorldSnappedPosition2.x, mouseWorldSnappedPosition2.y, currentActiveSystem.GetGridOrigin().z), Time.deltaTime * 25f);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, currentActiveSystem.GetPlacedObjectRotation(), Time.deltaTime * 25f);
				}
				BuildableGridObjectTypeSO buildableGridObjectTypeSO = currentActiveSystem.GetBuildableGridObjectTypeSO();
				if (visual != null)
				{
					HandleVisualColor(buildableGridObjectTypeSO);
				}
			}
		}

		private void RefreshVisual()
		{
			if (visual != null)
			{
				UnityEngine.Object.Destroy(parentObject.gameObject);
				parentObject = null;
				visual = null;
			}
			BuildableGridObjectTypeSO buildableGridObjectTypeSO = currentActiveSystem.GetBuildableGridObjectTypeSO();
			if (!(buildableGridObjectTypeSO != null))
			{
				return;
			}
			if (buildableGridObjectTypeSO.ghostPrefab == null)
			{
				buildableGridObjectTypeSO.ghostPrefab = buildableGridObjectTypeSO.objectPrefab[0];
			}
			visual = UnityEngine.Object.Instantiate(buildableGridObjectTypeSO.ghostPrefab, Vector3.zero, Quaternion.identity);
			HandleVisualColor(buildableGridObjectTypeSO);
			visual.parent = base.transform;
			visual.localPosition = Vector3.zero;
			visual.localEulerAngles = Vector3.zero;
			parentObject = new GameObject(buildableGridObjectTypeSO.name).transform;
			parentObject.parent = base.transform;
			parentObject.localPosition = Vector3.zero;
			parentObject.localEulerAngles = Vector3.zero;
			parentObject.localScale = new Vector3(parentObject.localScale.x + 0.01f, parentObject.localScale.y + 0.01f, parentObject.localScale.z + 0.01f);
			BuildableGridObject component = visual.GetComponent<BuildableGridObject>();
			if (currentActiveSystem.gridAxis == GridAxis.XY)
			{
				if (component.IsRotateObjectForXY())
				{
					visual.localEulerAngles = new Vector3(-90f, 0f, 0f);
				}
			}
			else if (component.IsRotateObjectForXZ())
			{
				visual.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			visual.parent = parentObject;
			Vector2Int vector2Int = buildableGridObjectTypeSO.CalculatePlacedObjectSize(currentActiveSystem.GetGridCellSize());
			if (currentActiveSystem.gridAxis == GridAxis.XZ)
			{
				parentObject.localPosition = new Vector3((float)vector2Int.x * currentActiveSystem.GetGridCellSize() / 2f, visual.localPosition.y, (float)vector2Int.y * currentActiveSystem.GetGridCellSize() / 2f);
				if (component.IsRotateObjectForXZ())
				{
					parentObject.localPosition = new Vector3(parentObject.localPosition.x - component.GetObjectPivotOffset().x, parentObject.localPosition.y - component.GetObjectPivotOffset().z, parentObject.localPosition.z - component.GetObjectPivotOffset().y);
				}
				else
				{
					parentObject.localPosition = new Vector3(parentObject.localPosition.x - component.GetObjectPivotOffset().x, parentObject.localPosition.y - component.GetObjectPivotOffset().y, parentObject.localPosition.z - component.GetObjectPivotOffset().z);
				}
			}
			else
			{
				parentObject.localPosition = new Vector3((float)vector2Int.x * currentActiveSystem.GetGridCellSize() / 2f, (float)vector2Int.y * currentActiveSystem.GetGridCellSize() / 2f, visual.localPosition.z);
				if (component.IsRotateObjectForXY())
				{
					parentObject.localPosition = new Vector3(parentObject.localPosition.x - component.GetObjectPivotOffset().x, parentObject.localPosition.y - component.GetObjectPivotOffset().z, parentObject.localPosition.z + component.GetObjectPivotOffset().y);
				}
				else
				{
					parentObject.localPosition = new Vector3(parentObject.localPosition.x - component.GetObjectPivotOffset().x, parentObject.localPosition.y - component.GetObjectPivotOffset().y, parentObject.localPosition.z + component.GetObjectPivotOffset().z);
				}
			}
			tempColliderScale = component.GetRawObjectScale();
			tempColliderCenter = component.GetRawObjectCenter();
			tempCollider = parentObject.gameObject.AddComponent<BoxCollider>();
			if (currentActiveSystem.gridAxis == GridAxis.XZ)
			{
				if (component.IsRotateObjectForXZ())
				{
					tempCollider.isTrigger = true;
					tempCollider.size = new Vector3(tempColliderScale.x, tempColliderScale.z, tempColliderScale.y);
					tempCollider.center = new Vector3(tempColliderCenter.x, 0f - tempColliderCenter.z, tempColliderCenter.y);
				}
				else
				{
					tempCollider.isTrigger = true;
					tempCollider.size = tempColliderScale;
					tempCollider.center = tempColliderCenter;
				}
			}
			else if (component.IsRotateObjectForXY())
			{
				tempCollider.isTrigger = true;
				tempCollider.size = new Vector3(tempColliderScale.x, tempColliderScale.z, tempColliderScale.y);
				tempCollider.center = new Vector3(tempColliderCenter.x, tempColliderCenter.z, 0f - tempColliderCenter.y);
			}
			else
			{
				tempCollider.isTrigger = true;
				tempCollider.size = tempColliderScale;
				tempCollider.center = tempColliderCenter;
			}
			colliderBridge = parentObject.gameObject.AddComponent<ColliderBridgeGridObject>();
			tempRB = parentObject.gameObject.AddComponent<Rigidbody>();
			tempRB.isKinematic = true;
			SetLayerRecursive(parentObject.gameObject, LayerNumber());
		}

		private void CleanObject()
		{
			if ((bool)tempCollider)
			{
				GridObjectGhost.OnBuildableObjectAreaBlockerExit?.Invoke();
				UnityEngine.Object.DestroyImmediate(tempCollider);
				UnityEngine.Object.DestroyImmediate(colliderBridge);
				UnityEngine.Object.DestroyImmediate(tempRB);
				tempCollider = null;
			}
		}

		public void OnTriggerEnter(Collider other)
		{
			if ((bool)other.gameObject.GetComponent<BuildableObjectAreaBlocker>())
			{
				GridObjectGhost.OnBuildableObjectAreaBlockerEnter?.Invoke();
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if ((bool)other.gameObject.GetComponent<BuildableObjectAreaBlocker>())
			{
				GridObjectGhost.OnBuildableObjectAreaBlockerExit?.Invoke();
			}
		}

		public void OnTriggerStay(Collider other)
		{
			if ((bool)other.gameObject.GetComponent<BuildableObjectAreaBlocker>())
			{
				GridObjectGhost.OnBuildableObjectAreaBlockerEnter?.Invoke();
			}
		}

		private void HandleVisualColor(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			if (!currentActiveSystem.NotPlaceableVisualCallerBuildableGridObject())
			{
				if (buildableGridObjectTypeSO.notPlaceableGhostMaterial != null)
				{
					selectedMat = buildableGridObjectTypeSO.notPlaceableGhostMaterial;
				}
				else if (buildableGridObjectTypeSO.placeableGhostMaterial != null)
				{
					selectedMat = buildableGridObjectTypeSO.placeableGhostMaterial;
				}
				else
				{
					selectedMat = null;
				}
			}
			else if (buildableGridObjectTypeSO.placeableGhostMaterial != null)
			{
				selectedMat = buildableGridObjectTypeSO.placeableGhostMaterial;
			}
			else
			{
				selectedMat = null;
			}
			if (!(selectedMat != null))
			{
				return;
			}
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			GameObject gameObject3 = null;
			GameObject gameObject4 = null;
			if ((bool)visual.GetComponent<MeshRenderer>())
			{
				visual.GetComponent<MeshRenderer>().material = selectedMat;
			}
			for (int i = 0; i < visual.childCount; i++)
			{
				gameObject = visual.GetChild(i).gameObject;
				if ((bool)gameObject.GetComponent<MeshRenderer>())
				{
					gameObject.GetComponent<MeshRenderer>().material = selectedMat;
				}
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					gameObject2 = gameObject.transform.GetChild(j).gameObject;
					if ((bool)gameObject2.GetComponent<MeshRenderer>())
					{
						gameObject2.GetComponent<MeshRenderer>().material = selectedMat;
					}
					for (int k = 0; k < gameObject2.transform.childCount; k++)
					{
						gameObject3 = gameObject2.transform.GetChild(k).gameObject;
						if ((bool)gameObject3.GetComponent<MeshRenderer>())
						{
							gameObject3.GetComponent<MeshRenderer>().material = selectedMat;
						}
						for (int l = 0; l < gameObject3.transform.childCount; l++)
						{
							gameObject4 = gameObject3.transform.GetChild(l).gameObject;
							if ((bool)gameObject4.GetComponent<MeshRenderer>())
							{
								gameObject4.GetComponent<MeshRenderer>().material = selectedMat;
							}
						}
					}
				}
			}
		}

		private int LayerNumber()
		{
			int num = 0;
			int num2 = ghostObjectLayer.value;
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

		private void SetLayerRecursive(GameObject targetGameObject, int layer)
		{
			targetGameObject.layer = layer;
			foreach (Transform item in targetGameObject.transform)
			{
				SetLayerRecursive(item.gameObject, layer);
			}
		}
	}
}
