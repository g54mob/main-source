using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ColliderPool : VegetationItemPool
{
	private readonly List<GameObject> _colliderPoolList = new List<GameObject>();

	private readonly VegetationItemInfoPro _vegetationItemInfoPro;

	private readonly VegetationItemModelInfo _vegetationItemModelInfo;

	private readonly VegetationSystemPro _vegetationSystemPro;

	private int _colliderCounter;

	private readonly Transform _colliderParent;

	private readonly GameObject _sourceColliderObject;

	private bool _showColliders;

	private LayerMask _colliderLayer;

	private string _colliderTag;

	public ColliderPool(VegetationItemInfoPro vegetationItemInfoPro, VegetationItemModelInfo vegetationItemModelInfo, VegetationSystemPro vegetationSystemPro, Transform colliderParent, bool showColliders)
	{
		_vegetationItemInfoPro = vegetationItemInfoPro;
		_vegetationItemModelInfo = vegetationItemModelInfo;
		_vegetationSystemPro = vegetationSystemPro;
		_colliderParent = colliderParent;
		_showColliders = showColliders;
		_colliderLayer = vegetationSystemPro.VegetationSettings.GetLayer(vegetationItemInfoPro.VegetationType);
		_colliderTag = vegetationItemInfoPro.ColliderTag;
		if (_colliderTag == "")
		{
			_colliderTag = "Untagged";
		}
		if (_vegetationItemInfoPro.ColliderType == ColliderType.FromPrefab)
		{
			GameObject gameObject = Object.Instantiate(vegetationItemInfoPro.VegetationPrefab);
			if (_vegetationItemInfoPro.ColliderTag != "")
			{
				gameObject.tag = vegetationItemInfoPro.ColliderTag;
			}
			gameObject.hideFlags = HideFlags.DontSave;
			gameObject.name = "ColliderSource_" + _vegetationItemInfoPro.VegetationItemID;
			gameObject.transform.SetParent(_colliderParent);
			_sourceColliderObject = CreateColliderObject(gameObject);
			DestroyObject(gameObject);
		}
	}

	private void AddVegetationItemInstanceInfo(GameObject colliderObject)
	{
		VegetationItemInstanceInfo vegetationItemInstanceInfo = colliderObject.AddComponent<VegetationItemInstanceInfo>();
		vegetationItemInstanceInfo.VegetationType = _vegetationItemInfoPro.VegetationType;
		vegetationItemInstanceInfo.VegetationItemID = _vegetationItemInfoPro.VegetationItemID;
		colliderObject.AddComponent<RuntimeObjectInfo>().VegetationItemInfo = _vegetationItemInfoPro;
	}

	private void UpdateVegetationItemInstanceInfo(GameObject colliderObject, ItemSelectorInstanceInfo info)
	{
		VegetationItemInstanceInfo component = colliderObject.GetComponent<VegetationItemInstanceInfo>();
		if ((bool)component)
		{
			component.Position = info.Position;
			component.VegetationItemInstanceID = Mathf.RoundToInt(component.Position.x * 100f) + "_" + Mathf.RoundToInt(component.Position.y * 100f) + "_" + Mathf.RoundToInt(component.Position.z * 100f);
			component.Rotation = info.Rotation;
			component.Scale = info.Scale;
		}
	}

	public void SetColliderVisibility(bool value)
	{
		_showColliders = value;
		for (int i = 0; i <= _colliderPoolList.Count - 1; i++)
		{
			GameObject gameObject = _colliderPoolList[i];
			if (value)
			{
				gameObject.hideFlags = HideFlags.DontSave;
			}
			else
			{
				gameObject.hideFlags = HideFlags.HideAndDontSave;
			}
		}
	}

	public override GameObject GetObject(ItemSelectorInstanceInfo info)
	{
		if (_colliderPoolList.Count <= 0)
		{
			return CreateColliderObject(info);
		}
		GameObject gameObject = _colliderPoolList[_colliderPoolList.Count - 1];
		_colliderPoolList.RemoveAtSwapBack(_colliderPoolList.Count - 1);
		gameObject.SetActive(value: true);
		PositionColliderObject(gameObject, info);
		return gameObject;
	}

	private HideFlags GetVisibilityHideFlags()
	{
		if (!_showColliders)
		{
			return HideFlags.HideAndDontSave;
		}
		return HideFlags.DontSave;
	}

	private void PositionColliderObject(GameObject colliderObject, ItemSelectorInstanceInfo info)
	{
		colliderObject.transform.position = info.Position + _vegetationSystemPro.FloatingOriginOffset;
		colliderObject.transform.localScale = info.Scale;
		colliderObject.transform.rotation = info.Rotation;
		UpdateVegetationItemInstanceInfo(colliderObject, info);
	}

	public GameObject CreateColliderObject(ItemSelectorInstanceInfo info)
	{
		_colliderCounter++;
		GameObject gameObject;
		if (_vegetationItemInfoPro.ColliderType == ColliderType.FromPrefab)
		{
			gameObject = Object.Instantiate(_sourceColliderObject);
			gameObject.name = "Collider_" + _colliderCounter;
			gameObject.hideFlags = GetVisibilityHideFlags();
			gameObject.transform.SetParent(_colliderParent);
		}
		else
		{
			gameObject = CreatePrimitiveCollider(info);
		}
		if (_vegetationItemInfoPro.ColliderTag != "")
		{
			gameObject.tag = _vegetationItemInfoPro.ColliderTag;
		}
		AddNavMesObstacle(gameObject);
		gameObject.SetActive(value: true);
		AddVegetationItemInstanceInfo(gameObject);
		PositionColliderObject(gameObject, info);
		gameObject.layer = _vegetationSystemPro.VegetationSettings.GetLayer(_vegetationItemInfoPro.VegetationType);
		return gameObject;
	}

	private GameObject CreatePrimitiveCollider(ItemSelectorInstanceInfo info)
	{
		switch (_vegetationItemInfoPro.ColliderType)
		{
		case ColliderType.Capsule:
		{
			GameObject gameObject5 = new GameObject("CapsuleCollider_" + _colliderCounter);
			gameObject5.layer = _colliderLayer;
			gameObject5.tag = _colliderTag;
			gameObject5.transform.SetParent(_colliderParent);
			gameObject5.hideFlags = GetVisibilityHideFlags();
			CapsuleCollider capsuleCollider = gameObject5.AddComponent<CapsuleCollider>();
			capsuleCollider.height = _vegetationItemInfoPro.ColliderHeight;
			capsuleCollider.radius = _vegetationItemInfoPro.ColliderRadius;
			capsuleCollider.isTrigger = _vegetationItemInfoPro.ColliderTrigger;
			Vector3 vector3 = new Vector3(info.Scale.x * _vegetationItemInfoPro.ColliderOffset.x, info.Scale.y * _vegetationItemInfoPro.ColliderOffset.y, info.Scale.z * _vegetationItemInfoPro.ColliderOffset.z);
			vector3 += info.Rotation * vector3;
			capsuleCollider.center = vector3;
			return gameObject5;
		}
		case ColliderType.Sphere:
		{
			GameObject gameObject4 = new GameObject("SphereCollider_" + _colliderCounter);
			gameObject4.layer = _colliderLayer;
			gameObject4.tag = _colliderTag;
			gameObject4.transform.SetParent(_colliderParent);
			gameObject4.hideFlags = GetVisibilityHideFlags();
			SphereCollider sphereCollider = gameObject4.AddComponent<SphereCollider>();
			sphereCollider.radius = _vegetationItemInfoPro.ColliderRadius;
			sphereCollider.isTrigger = _vegetationItemInfoPro.ColliderTrigger;
			Vector3 vector2 = new Vector3(info.Scale.x * _vegetationItemInfoPro.ColliderOffset.x, info.Scale.y * _vegetationItemInfoPro.ColliderOffset.y, info.Scale.z * _vegetationItemInfoPro.ColliderOffset.z);
			vector2 += info.Rotation * vector2;
			sphereCollider.center = vector2;
			return gameObject4;
		}
		case ColliderType.Box:
		{
			GameObject gameObject3 = new GameObject("BoxCollider_" + _colliderCounter);
			gameObject3.layer = _colliderLayer;
			gameObject3.tag = _colliderTag;
			gameObject3.transform.SetParent(_colliderParent);
			gameObject3.hideFlags = GetVisibilityHideFlags();
			BoxCollider boxCollider = gameObject3.AddComponent<BoxCollider>();
			Vector3 size = new Vector3(info.Scale.x * _vegetationItemInfoPro.ColliderSize.x, info.Scale.y * _vegetationItemInfoPro.ColliderSize.y, info.Scale.z * _vegetationItemInfoPro.ColliderSize.z);
			boxCollider.size = size;
			boxCollider.isTrigger = _vegetationItemInfoPro.ColliderTrigger;
			Vector3 vector = new Vector3(info.Scale.x * _vegetationItemInfoPro.ColliderOffset.x, info.Scale.y * _vegetationItemInfoPro.ColliderOffset.y, info.Scale.z * _vegetationItemInfoPro.ColliderOffset.z);
			vector += info.Rotation * vector;
			boxCollider.center = vector;
			return gameObject3;
		}
		case ColliderType.CustomMesh:
		{
			GameObject gameObject2 = new GameObject("MeshCollider_" + _colliderCounter);
			gameObject2.layer = _colliderLayer;
			gameObject2.tag = _colliderTag;
			gameObject2.transform.SetParent(_colliderParent);
			gameObject2.hideFlags = GetVisibilityHideFlags();
			MeshCollider meshCollider2 = gameObject2.AddComponent<MeshCollider>();
			meshCollider2.isTrigger = _vegetationItemInfoPro.ColliderTrigger;
			meshCollider2.sharedMesh = _vegetationItemInfoPro.ColliderMesh;
			meshCollider2.convex = _vegetationItemInfoPro.ColliderConvex;
			return gameObject2;
		}
		case ColliderType.Mesh:
		{
			GameObject gameObject = new GameObject("MeshCollider_" + _colliderCounter);
			gameObject.layer = _colliderLayer;
			gameObject.tag = _colliderTag;
			gameObject.transform.SetParent(_colliderParent);
			gameObject.hideFlags = GetVisibilityHideFlags();
			MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
			meshCollider.isTrigger = _vegetationItemInfoPro.ColliderTrigger;
			meshCollider.sharedMesh = _vegetationItemModelInfo.VegetationMeshLod0;
			meshCollider.convex = _vegetationItemInfoPro.ColliderConvex;
			return gameObject;
		}
		default:
			return new GameObject("Empty collider object");
		}
	}

	private void AddNavMesObstacle(GameObject go)
	{
		switch (_vegetationItemInfoPro.NavMeshObstacleType)
		{
		case NavMeshObstacleType.Box:
		{
			NavMeshObstacle navMeshObstacle2 = go.AddComponent<NavMeshObstacle>();
			navMeshObstacle2.shape = NavMeshObstacleShape.Box;
			navMeshObstacle2.center = _vegetationItemInfoPro.NavMeshObstacleCenter;
			navMeshObstacle2.size = _vegetationItemInfoPro.NavMeshObstacleSize;
			navMeshObstacle2.carving = _vegetationItemInfoPro.NavMeshObstacleCarve;
			break;
		}
		case NavMeshObstacleType.Capsule:
		{
			NavMeshObstacle navMeshObstacle = go.AddComponent<NavMeshObstacle>();
			navMeshObstacle.shape = NavMeshObstacleShape.Capsule;
			navMeshObstacle.center = _vegetationItemInfoPro.NavMeshObstacleCenter;
			navMeshObstacle.radius = _vegetationItemInfoPro.NavMeshObstacleRadius;
			navMeshObstacle.height = _vegetationItemInfoPro.NavMeshObstacleHeight;
			navMeshObstacle.carving = _vegetationItemInfoPro.NavMeshObstacleCarve;
			break;
		}
		}
	}

	public override void ReturnObject(GameObject colliderObject)
	{
		if ((bool)colliderObject)
		{
			colliderObject.SetActive(value: false);
			_colliderPoolList.Add(colliderObject);
		}
	}

	private GameObject CreateColliderObject(GameObject sourceObject)
	{
		sourceObject.transform.position = Vector3.zero;
		sourceObject.transform.localScale = Vector3.one;
		sourceObject.transform.rotation = Quaternion.identity;
		GameObject gameObject = new GameObject("SourceColliderObject")
		{
			hideFlags = HideFlags.DontSave
		};
		gameObject.transform.SetParent(_colliderParent);
		gameObject.transform.position = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.layer = _colliderLayer;
		gameObject.tag = _colliderTag;
		gameObject.SetActive(value: false);
		MeshCollider[] componentsInChildren = sourceObject.GetComponentsInChildren<MeshCollider>();
		SphereCollider[] componentsInChildren2 = sourceObject.GetComponentsInChildren<SphereCollider>();
		BoxCollider[] componentsInChildren3 = sourceObject.GetComponentsInChildren<BoxCollider>();
		CapsuleCollider[] componentsInChildren4 = sourceObject.GetComponentsInChildren<CapsuleCollider>();
		for (int i = 0; i <= componentsInChildren4.Length - 1; i++)
		{
			GameObject gameObject2 = new GameObject("CapsuleCollider");
			gameObject2.hideFlags = HideFlags.DontSave;
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.transform.position = componentsInChildren4[i].transform.position;
			gameObject2.transform.localScale = componentsInChildren4[i].transform.localScale;
			gameObject2.transform.rotation = componentsInChildren4[i].transform.rotation;
			gameObject2.layer = _colliderLayer;
			gameObject2.tag = _colliderTag;
			CapsuleCollider capsuleCollider = gameObject2.AddComponent<CapsuleCollider>();
			capsuleCollider.radius = componentsInChildren4[i].radius;
			capsuleCollider.height = componentsInChildren4[i].height;
			capsuleCollider.center = componentsInChildren4[i].center;
			capsuleCollider.direction = componentsInChildren4[i].direction;
			capsuleCollider.sharedMaterial = componentsInChildren4[i].sharedMaterial;
			capsuleCollider.isTrigger = componentsInChildren4[i].isTrigger;
		}
		for (int j = 0; j <= componentsInChildren3.Length - 1; j++)
		{
			GameObject gameObject3 = new GameObject("BoxCollider");
			gameObject3.hideFlags = HideFlags.DontSave;
			gameObject3.transform.SetParent(gameObject.transform);
			gameObject3.transform.position = componentsInChildren3[j].transform.position;
			gameObject3.transform.localScale = componentsInChildren3[j].transform.localScale;
			gameObject3.transform.rotation = componentsInChildren3[j].transform.rotation;
			gameObject3.layer = _colliderLayer;
			gameObject3.tag = _colliderTag;
			BoxCollider boxCollider = gameObject3.AddComponent<BoxCollider>();
			boxCollider.center = componentsInChildren3[j].center;
			boxCollider.size = componentsInChildren3[j].size;
			boxCollider.sharedMaterial = componentsInChildren3[j].sharedMaterial;
			boxCollider.isTrigger = componentsInChildren3[j].isTrigger;
		}
		for (int k = 0; k <= componentsInChildren2.Length - 1; k++)
		{
			GameObject gameObject4 = new GameObject("SphereCollider");
			gameObject4.hideFlags = HideFlags.DontSave;
			gameObject4.transform.SetParent(gameObject.transform);
			gameObject4.transform.position = componentsInChildren2[k].transform.position;
			gameObject4.transform.localScale = componentsInChildren2[k].transform.localScale;
			gameObject4.transform.rotation = componentsInChildren2[k].transform.rotation;
			gameObject4.layer = _colliderLayer;
			gameObject4.tag = _colliderTag;
			SphereCollider sphereCollider = gameObject4.AddComponent<SphereCollider>();
			sphereCollider.center = componentsInChildren2[k].center;
			sphereCollider.radius = componentsInChildren2[k].radius;
			sphereCollider.sharedMaterial = componentsInChildren2[k].sharedMaterial;
			sphereCollider.isTrigger = componentsInChildren2[k].isTrigger;
		}
		for (int l = 0; l <= componentsInChildren.Length - 1; l++)
		{
			GameObject gameObject5 = new GameObject("MeshCollider");
			gameObject5.hideFlags = HideFlags.DontSave;
			gameObject5.transform.SetParent(gameObject.transform);
			gameObject5.transform.position = componentsInChildren[l].transform.position;
			gameObject5.transform.localScale = componentsInChildren[l].transform.localScale;
			gameObject5.transform.rotation = componentsInChildren[l].transform.rotation;
			gameObject5.layer = _colliderLayer;
			gameObject5.tag = _colliderTag;
			MeshCollider meshCollider = gameObject5.AddComponent<MeshCollider>();
			meshCollider.cookingOptions = componentsInChildren[l].cookingOptions;
			meshCollider.convex = componentsInChildren[l].convex;
			meshCollider.sharedMesh = componentsInChildren[l].sharedMesh;
			meshCollider.sharedMaterial = componentsInChildren[l].sharedMaterial;
			meshCollider.isTrigger = componentsInChildren[l].isTrigger;
		}
		return gameObject;
	}

	private static void DestroyObject(GameObject go)
	{
		if (Application.isPlaying)
		{
			Object.DestroyImmediate(go);
		}
		else
		{
			Object.DestroyImmediate(go);
		}
	}

	public void Dispose()
	{
		for (int i = 0; i <= _colliderPoolList.Count - 1; i++)
		{
			DestroyObject(_colliderPoolList[i]);
		}
		_colliderPoolList.Clear();
		if (_vegetationItemInfoPro.ColliderType == ColliderType.FromPrefab)
		{
			DestroyObject(_sourceColliderObject);
		}
	}
}
