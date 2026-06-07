using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using UnityEngine;

public class RuntimePrefabPool : VegetationItemPool
{
	private readonly List<GameObject> _prefabPoolList = new List<GameObject>();

	private readonly RuntimePrefabRule _runtimePrefabRule;

	private int _prefabCounter;

	private readonly Transform _prefabParent;

	private bool _showPrefabsInHierarchy;

	private VegetationItemInfoPro _vegetationItemInfoPro;

	private VegetationSystemPro _vegetationSystemPro;

	public RuntimePrefabPool(RuntimePrefabRule runtimePrefabRule, VegetationItemInfoPro vegetationItemInfoPro, Transform prefabParent, bool showPrefabsInHierarchy, VegetationSystemPro vegetationSystemPro)
	{
		_vegetationSystemPro = vegetationSystemPro;
		_vegetationItemInfoPro = vegetationItemInfoPro;
		_prefabParent = prefabParent;
		_showPrefabsInHierarchy = showPrefabsInHierarchy;
		_runtimePrefabRule = runtimePrefabRule;
	}

	public void SetPrefabVisibility(bool value)
	{
		_showPrefabsInHierarchy = value;
		for (int i = 0; i <= _prefabPoolList.Count - 1; i++)
		{
			GameObject gameObject = _prefabPoolList[i];
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

	public override GameObject GetObject(ItemSelectorInstanceInfo info)
	{
		if (_prefabPoolList.Count <= 0)
		{
			return CreateRuntimePrefabObject(info);
		}
		GameObject gameObject = _prefabPoolList[_prefabPoolList.Count - 1];
		_prefabPoolList.RemoveAtSwapBack(_prefabPoolList.Count - 1);
		gameObject.SetActive(value: true);
		PositionPrefabObject(gameObject, info);
		return gameObject;
	}

	public GameObject CreateRuntimePrefabObject(ItemSelectorInstanceInfo info)
	{
		_prefabCounter++;
		GameObject gameObject;
		if ((bool)_runtimePrefabRule.RuntimePrefab)
		{
			gameObject = Object.Instantiate(_runtimePrefabRule.RuntimePrefab);
			gameObject.name = _runtimePrefabRule.RuntimePrefab.name;
		}
		else
		{
			gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.name = "Run-time prefab" + _prefabCounter + "_" + gameObject.name;
		}
		gameObject.hideFlags = GetVisibilityHideFlags();
		gameObject.transform.SetParent(_prefabParent);
		gameObject.SetActive(value: true);
		gameObject.layer = _runtimePrefabRule.PrefabLayer;
		AddVegetationItemInstanceInfo(gameObject);
		PositionPrefabObject(gameObject, info);
		return gameObject;
	}

	private HideFlags GetVisibilityHideFlags()
	{
		if (!_showPrefabsInHierarchy)
		{
			return HideFlags.HideAndDontSave;
		}
		return HideFlags.DontSave;
	}

	private void PositionPrefabObject(GameObject prefabObject, ItemSelectorInstanceInfo info)
	{
		Vector3 vector = Vector3.one;
		if (_runtimePrefabRule.UseVegetationItemScale)
		{
			vector = new Vector3(vector.x * info.Scale.x, vector.y * info.Scale.y, vector.z * info.Scale.z);
		}
		Vector3 vector2 = info.Position + _vegetationSystemPro.FloatingOriginOffset;
		Vector3 vector3 = ((!_runtimePrefabRule.UseVegetationItemScale) ? _runtimePrefabRule.PrefabOffset : new Vector3(info.Scale.x * _runtimePrefabRule.PrefabOffset.x, info.Scale.y * _runtimePrefabRule.PrefabOffset.y, info.Scale.z * _runtimePrefabRule.PrefabOffset.z));
		vector3 += info.Rotation * vector3;
		prefabObject.transform.position = vector2 + vector3;
		prefabObject.transform.localScale = new Vector3(vector.x * _runtimePrefabRule.PrefabScale.x, vector.y * _runtimePrefabRule.PrefabScale.y, vector.z * _runtimePrefabRule.PrefabScale.z);
		prefabObject.transform.rotation = info.Rotation * Quaternion.Euler(_runtimePrefabRule.PrefabRotation);
		UpdateVegetationItemInstanceInfo(prefabObject, info);
	}

	public override void ReturnObject(GameObject prefabObject)
	{
		if (!(prefabObject == null))
		{
			if (_runtimePrefabRule.UsePool)
			{
				prefabObject.SetActive(value: false);
				_prefabPoolList.Add(prefabObject);
			}
			else
			{
				DestroyObject(prefabObject);
			}
		}
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
		for (int i = 0; i <= _prefabPoolList.Count - 1; i++)
		{
			DestroyObject(_prefabPoolList[i]);
		}
		_prefabPoolList.Clear();
	}
}
