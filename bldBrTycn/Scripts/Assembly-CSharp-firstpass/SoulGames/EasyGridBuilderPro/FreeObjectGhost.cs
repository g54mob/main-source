using System;
using SoulGames.Utilities;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class FreeObjectGhost : MonoBehaviour
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

		private ColliderBridgeFreeObject colliderBridge;

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
			currentActiveSystem.GetBuildableFreeObjectTypeSO();
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
			currentActiveSystem.GetBuildableFreeObjectTypeSO();
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
					Vector3 buildableFreeObjectMouseWorldPosition = currentActiveSystem.GetBuildableFreeObjectMouseWorldPosition();
					float buildableFreeObjectRotation = currentActiveSystem.GetBuildableFreeObjectRotation();
					base.transform.position = Vector3.Lerp(base.transform.position, buildableFreeObjectMouseWorldPosition, Time.deltaTime * 15f);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(0f, buildableFreeObjectRotation, 0f), Time.deltaTime * 25f);
				}
				else
				{
					Vector3 buildableFreeObjectMouseWorldPosition2 = currentActiveSystem.GetBuildableFreeObjectMouseWorldPosition();
					float buildableFreeObjectRotation2 = currentActiveSystem.GetBuildableFreeObjectRotation();
					base.transform.position = Vector3.Lerp(base.transform.position, buildableFreeObjectMouseWorldPosition2, Time.deltaTime * 15f);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(0f, 0f, buildableFreeObjectRotation2), Time.deltaTime * 25f);
				}
				BuildableFreeObjectTypeSO buildableFreeObjectTypeSO = currentActiveSystem.GetBuildableFreeObjectTypeSO();
				if (visual != null)
				{
					HandleVisualColor(buildableFreeObjectTypeSO);
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
			BuildableFreeObjectTypeSO buildableFreeObjectTypeSO = currentActiveSystem.GetBuildableFreeObjectTypeSO();
			if (!(buildableFreeObjectTypeSO != null))
			{
				return;
			}
			if (buildableFreeObjectTypeSO.ghostPrefab == null)
			{
				buildableFreeObjectTypeSO.ghostPrefab = buildableFreeObjectTypeSO.objectPrefab[0];
			}
			visual = UnityEngine.Object.Instantiate(buildableFreeObjectTypeSO.ghostPrefab, Vector3.zero, Quaternion.identity);
			HandleVisualColor(buildableFreeObjectTypeSO);
			visual.parent = base.transform;
			visual.localPosition = Vector3.zero;
			visual.localEulerAngles = Vector3.zero;
			parentObject = new GameObject(buildableFreeObjectTypeSO.name).transform;
			parentObject.parent = base.transform;
			parentObject.localPosition = Vector3.zero;
			parentObject.localEulerAngles = Vector3.zero;
			parentObject.localScale = new Vector3(parentObject.localScale.x + 0.01f, parentObject.localScale.y + 0.01f, parentObject.localScale.z + 0.01f);
			BuildableFreeObject component = visual.GetComponent<BuildableFreeObject>();
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
			colliderBridge = parentObject.gameObject.AddComponent<ColliderBridgeFreeObject>();
			tempRB = parentObject.gameObject.AddComponent<Rigidbody>();
			tempRB.isKinematic = true;
			SetLayerRecursive(parentObject.gameObject, LayerNumber());
		}

		private void CleanObject()
		{
			if ((bool)tempCollider)
			{
				FreeObjectGhost.OnBuildableObjectAreaBlockerExit?.Invoke();
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
				FreeObjectGhost.OnBuildableObjectAreaBlockerEnter?.Invoke();
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if ((bool)other.gameObject.GetComponent<BuildableObjectAreaBlocker>())
			{
				FreeObjectGhost.OnBuildableObjectAreaBlockerExit?.Invoke();
			}
		}

		public void OnTriggerStay(Collider other)
		{
			if ((bool)other.gameObject.GetComponent<BuildableObjectAreaBlocker>())
			{
				FreeObjectGhost.OnBuildableObjectAreaBlockerEnter?.Invoke();
			}
		}

		private void HandleVisualColor(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			if (!currentActiveSystem.NotPlaceableVisualCallerBuildableFreeObject())
			{
				if (buildableFreeObjectTypeSO.notPlaceableGhostMaterial != null)
				{
					selectedMat = buildableFreeObjectTypeSO.notPlaceableGhostMaterial;
				}
				else if (buildableFreeObjectTypeSO.placeableGhostMaterial != null)
				{
					selectedMat = buildableFreeObjectTypeSO.placeableGhostMaterial;
				}
				else
				{
					selectedMat = null;
				}
			}
			else if (buildableFreeObjectTypeSO.placeableGhostMaterial != null)
			{
				selectedMat = buildableFreeObjectTypeSO.placeableGhostMaterial;
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
