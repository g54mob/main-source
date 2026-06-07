using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUILODGroupDataProvider : GPUIDataProvider<int, GPUILODGroupData>
	{
		private List<GPUILODGroupData> _generatedLODGroups;

		public override void Initialize()
		{
			base.Initialize();
			if (_generatedLODGroups == null)
			{
				_generatedLODGroups = new List<GPUILODGroupData>();
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			DestroyGeneratedLODGroups();
		}

		public void DestroyGeneratedLODGroups()
		{
			if (_generatedLODGroups == null)
			{
				return;
			}
			foreach (GPUILODGroupData generatedLODGroup in _generatedLODGroups)
			{
				generatedLODGroup.Dispose();
				generatedLODGroup.DestroyGeneric();
			}
			_generatedLODGroups.Clear();
		}

		public void RegenerateLODGroups()
		{
			if (!base.IsInitialized)
			{
				return;
			}
			foreach (KeyValuePair<int, GPUILODGroupData> item in _dataDict)
			{
				if (item.Value != null && item.Value.prototype != null)
				{
					item.Value.CreateRenderersFromPrototype(item.Value.prototype);
				}
			}
			GPUIRenderingSystem.Instance.UpdateCommandBuffers(forceNew: true);
		}

		public void RecalculateLODGroupBounds()
		{
			if (!base.IsInitialized)
			{
				return;
			}
			foreach (KeyValuePair<int, GPUILODGroupData> item in _dataDict)
			{
				if (item.Value != null && item.Value.prototype != null)
				{
					item.Value.CalculateBounds();
				}
			}
		}

		public void RegenerateLODGroupData(GPUIPrototype prototype)
		{
			if (base.IsInitialized)
			{
				GPUILODGroupData orCreateLODGroupData = GetOrCreateLODGroupData(prototype);
				if (orCreateLODGroupData != null)
				{
					orCreateLODGroupData.CreateRenderersFromPrototype(prototype);
					orCreateLODGroupData.SetParameterBufferData();
					GPUIRenderingSystem.Instance.UpdateCommandBuffers();
				}
			}
		}

		public GPUILODGroupData GetOrCreateLODGroupData(GPUIPrototype prototype)
		{
			if (!base.IsInitialized)
			{
				Initialize();
			}
			int key = prototype.GetKey();
			if (!TryGetData(key, out var result) || result == null)
			{
				if (prototype.prototypeType == GPUIPrototypeType.LODGroupData)
				{
					result = prototype.gpuiLODGroupData;
				}
				else
				{
					result = GPUILODGroupData.CreateLODGroupData(prototype);
					_generatedLODGroups.Add(result);
				}
				_dataDict[key] = result;
			}
			return result;
		}

		public GameObject FindPrefabObjectFromPrefabID(int prefabID)
		{
			if (!base.IsInitialized)
			{
				return null;
			}
			foreach (GPUILODGroupData value in _dataDict.Values)
			{
				if (value.prototype != null && !(value.prototype.prefabObject == null) && value.prototype.prefabObject.TryGetComponent<GPUIPrefabBase>(out var component) && component.GetPrefabID() == prefabID)
				{
					return value.prototype.prefabObject;
				}
			}
			return null;
		}

		public void ClearNullValues()
		{
			if (!base.IsInitialized)
			{
				return;
			}
			for (int i = 0; i < base.Count; i++)
			{
				KeyValuePair<int, GPUILODGroupData> kVPairAtIndex = GetKVPairAtIndex(i);
				if (kVPairAtIndex.Value == null)
				{
					Remove(kVPairAtIndex.Key);
					i--;
				}
			}
		}
	}
}
