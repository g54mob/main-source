using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class RuntimePrefabStorage
{
	[NonSerialized]
	public readonly List<RuntimePrefabInfo> RuntimePrefabInfoList = new List<RuntimePrefabInfo>();

	private readonly VegetationItemPool _vegetationItemPool;

	public RuntimePrefabStorage(VegetationItemPool vegetationItemPool)
	{
		_vegetationItemPool = vegetationItemPool;
	}

	public void SetPrefabVisibility(bool value)
	{
		for (int i = 0; i <= RuntimePrefabInfoList.Count - 1; i++)
		{
			RuntimePrefabInfo runtimePrefabInfo = RuntimePrefabInfoList[i];
			if (value)
			{
				runtimePrefabInfo.RuntimeObject.hideFlags = HideFlags.DontSave;
			}
			else
			{
				runtimePrefabInfo.RuntimeObject.hideFlags = HideFlags.HideAndDontSave;
			}
		}
	}

	public void UpdateFloatingOrigin(Vector3 deltaFloatingOriginOffset)
	{
		for (int num = RuntimePrefabInfoList.Count - 1; num >= 0; num--)
		{
			RuntimePrefabInfoList[num].RuntimeObject.transform.position += deltaFloatingOriginOffset;
		}
	}

	public void RemoveRuntimePrefab(int vegetationCellIndex)
	{
		for (int num = RuntimePrefabInfoList.Count - 1; num >= 0; num--)
		{
			RuntimePrefabInfo runtimePrefabInfo = RuntimePrefabInfoList[num];
			if (runtimePrefabInfo.VegetationCellIndex == vegetationCellIndex)
			{
				if (_vegetationItemPool != null)
				{
					_vegetationItemPool.ReturnObject(runtimePrefabInfo.RuntimeObject);
				}
				else
				{
					DestroyRuntimePrefab(runtimePrefabInfo);
				}
				RuntimePrefabInfoList.RemoveAtSwapBack(num);
			}
		}
	}

	public void AddRuntimePrefab(GameObject runtimeObject, int vegetationCellIndex, int vegetationCellItemIndex)
	{
		RuntimePrefabInfo item = new RuntimePrefabInfo
		{
			VegetationCellIndex = vegetationCellIndex,
			VegetationCellItemIndex = vegetationCellItemIndex,
			RuntimeObject = runtimeObject
		};
		RuntimePrefabInfoList.Add(item);
	}

	public void RemoveRuntimePrefab(int vegetationCellIndex, int vegetationCellItemIndex, VegetationItemPool vegetationItemPool)
	{
		for (int num = RuntimePrefabInfoList.Count - 1; num >= 0; num--)
		{
			RuntimePrefabInfo runtimePrefabInfo = RuntimePrefabInfoList[num];
			if (runtimePrefabInfo.VegetationCellIndex == vegetationCellIndex && runtimePrefabInfo.VegetationCellItemIndex == vegetationCellItemIndex)
			{
				if (vegetationItemPool != null)
				{
					vegetationItemPool.ReturnObject(runtimePrefabInfo.RuntimeObject);
				}
				else
				{
					DestroyRuntimePrefab(runtimePrefabInfo);
				}
				RuntimePrefabInfoList.RemoveAtSwapBack(num);
			}
		}
	}

	public GameObject GetRuntimePrefab(int vegetationCellIndex, int vegetationCellItemIndex)
	{
		for (int num = RuntimePrefabInfoList.Count - 1; num >= 0; num--)
		{
			RuntimePrefabInfo runtimePrefabInfo = RuntimePrefabInfoList[num];
			if (runtimePrefabInfo.VegetationCellIndex == vegetationCellIndex && runtimePrefabInfo.VegetationCellItemIndex == vegetationCellItemIndex)
			{
				return runtimePrefabInfo.RuntimeObject;
			}
		}
		return null;
	}

	private void DestroyRuntimePrefab(RuntimePrefabInfo runtimePrefabInfo)
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(runtimePrefabInfo.RuntimeObject);
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(runtimePrefabInfo.RuntimeObject);
		}
	}

	public void Dispose()
	{
		for (int num = RuntimePrefabInfoList.Count - 1; num >= 0; num--)
		{
			RuntimePrefabInfo runtimePrefabInfo = RuntimePrefabInfoList[num];
			if (_vegetationItemPool != null)
			{
				_vegetationItemPool.ReturnObject(runtimePrefabInfo.RuntimeObject);
			}
			else
			{
				DestroyRuntimePrefab(runtimePrefabInfo);
			}
		}
		RuntimePrefabInfoList.Clear();
	}
}
