using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(200)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#The_Tree_Manager")]
	public class GPUITreeManager : GPUITerrainManager<GPUITreePrototypeData>
	{
		private struct TerrainTreeData
		{
			public Vector3 terrainSize;

			public Vector3 terrainPosition;

			public TreeInstance[] treeData;
		}

		[SerializeField]
		internal bool _enableTreeInstanceColors;

		[NonSerialized]
		private bool _requireUpdate;

		[NonSerialized]
		private List<TerrainTreeData> _terrainTreeDataArray;

		[NonSerialized]
		private int[] _treeInstanceCounts;

		[NonSerialized]
		private GPUIShaderBuffer[] _treeTransformBuffers;

		[NonSerialized]
		private int[] _treeTransformBufferStartIndexes;

		[NonSerialized]
		private GPUIDataBuffer<GPUICounterData> _counterDataBuffer;

		[NonSerialized]
		private bool _reloadTreeInstances;

		private const int ERROR_CODE_ADDITION = 500;

		private static readonly List<string> TREE_INSTANCE_COLORS_SHADER_KEYWORDS = new List<string> { GPUITerrainConstants.Kw_GPUI_TREE_INSTANCE_COLOR };

		public override bool IsValid(bool logError = true)
		{
			if (!base.IsValid(logError))
			{
				return false;
			}
			bool flag = false;
			int terrainCount = GetTerrainCount();
			for (int i = 0; i < terrainCount; i++)
			{
				GPUITerrain terrain = GetTerrain(i);
				if (terrain != null && terrain.TreePrototypes != null && terrain.TreePrototypes.Length != 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				errorCode = -502;
				return false;
			}
			return true;
		}

		public override void Initialize()
		{
			base.Initialize();
			int num = _prototypes.Length;
			_terrainTreeDataArray = new List<TerrainTreeData>();
			_treeInstanceCounts = new int[num];
			_treeTransformBuffers = new GPUIShaderBuffer[num];
			_treeTransformBufferStartIndexes = new int[num];
			_counterDataBuffer = new GPUIDataBuffer<GPUICounterData>("Tree Counter Buffer", num);
			GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(UpdateTreeMatrices);
			GPUIRenderingSystem.Instance.OnPreCull.AddListener(UpdateTreeMatrices);
		}

		public override void Dispose()
		{
			base.Dispose();
			_terrainTreeDataArray = null;
			_treeInstanceCounts = null;
			_treeTransformBuffers = null;
			_treeTransformBufferStartIndexes = null;
			if (_counterDataBuffer != null)
			{
				_counterDataBuffer.Dispose();
				_counterDataBuffer = null;
			}
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(UpdateTreeMatrices);
			}
		}

		private void UpdateTreeMatrices(GPUICameraData cameraData)
		{
			UpdateTreeMatrices();
		}

		private void UpdateTreeMatrices()
		{
			if (!_requireUpdate || !GPUIRenderingSystem.IsActive || !base.IsInitialized)
			{
				return;
			}
			_requireUpdate = false;
			int num = _prototypes.Length;
			if (num == 0)
			{
				return;
			}
			if (_treeInstanceCounts.Length != num)
			{
				_treeInstanceCounts = new int[num];
			}
			if (_counterDataBuffer.Length != num)
			{
				_counterDataBuffer.Resize(num);
			}
			_counterDataBuffer.UpdateBufferData(forceUpdate: true);
			foreach (GPUITerrain activeTerrainValue in GetActiveTerrainValues())
			{
				if (activeTerrainValue == null || !activeTerrainValue.isActiveAndEnabled)
				{
					continue;
				}
				TreeInstance[] treeInstances = activeTerrainValue.GetTreeInstances(_reloadTreeInstances);
				if (treeInstances == null || treeInstances.Length == 0)
				{
					continue;
				}
				_terrainTreeDataArray.Add(new TerrainTreeData
				{
					terrainSize = activeTerrainValue.GetSize(),
					terrainPosition = activeTerrainValue.GetPosition(),
					treeData = treeInstances
				});
				for (int i = 0; i < treeInstances.Length; i++)
				{
					int prototypeIndex = treeInstances[i].prototypeIndex;
					if (prototypeIndex >= 0 && prototypeIndex < num)
					{
						_treeInstanceCounts[prototypeIndex]++;
					}
				}
			}
			_reloadTreeInstances = false;
			if (_treeTransformBuffers.Length != num)
			{
				_treeTransformBuffers = new GPUIShaderBuffer[num];
			}
			if (_treeTransformBufferStartIndexes.Length != num)
			{
				_treeTransformBufferStartIndexes = new int[num];
			}
			for (int j = 0; j < num; j++)
			{
				if (!_prototypes[j].isEnabled)
				{
					_treeTransformBuffers[j] = null;
					continue;
				}
				int num2 = _treeInstanceCounts[j];
				GPUIRenderingSystem.SetBufferSize(_runtimeRenderKeys[j], num2, isCopyPreviousData: false);
				GPUIRenderingSystem.SetInstanceCount(_runtimeRenderKeys[j], num2);
				_prototypeDataArray[j]._treeInstanceDataBuffer?.Release();
				if (num2 > 0)
				{
					if (_enableTreeInstanceColors)
					{
						_prototypeDataArray[j]._treeInstanceDataBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, num2, 16);
					}
					if (!GPUIRenderingSystem.TryGetTransformBuffer(_runtimeRenderKeys[j], out _treeTransformBuffers[j], out _treeTransformBufferStartIndexes[j], (GPUICameraData)null, true))
					{
						Debug.LogError("Tree Manager can not find transform buffer for prototype: " + _prototypes[j]);
					}
				}
				else
				{
					_treeTransformBuffers[j] = null;
				}
			}
			ComputeShader cS_TerrainTreeGenerator = GPUITerrainConstants.CS_TerrainTreeGenerator;
			if (_enableTreeInstanceColors)
			{
				cS_TerrainTreeGenerator.EnableKeyword(GPUITerrainConstants.Kw_GPUI_TREE_INSTANCE_COLOR);
				for (int k = 0; k < num; k++)
				{
					if (_treeInstanceCounts[k] > 0 && GPUIRenderingSystem.TryGetRenderSourceGroup(_runtimeRenderKeys[k], out var renderSourceGroup))
					{
						renderSourceGroup.AddMaterialPropertyOverride(GPUITerrainConstants.PROP_gpuiTreeInstanceDataBuffer, _prototypeDataArray[k]._treeInstanceDataBuffer);
					}
				}
			}
			else
			{
				cS_TerrainTreeGenerator.DisableKeyword(GPUITerrainConstants.Kw_GPUI_TREE_INSTANCE_COLOR);
			}
			int num3 = 0;
			for (int l = 0; l < _terrainTreeDataArray.Count; l++)
			{
				num3 = Mathf.Max(num3, _terrainTreeDataArray[l].treeData.Length);
			}
			if (num3 > 0)
			{
				GraphicsBuffer graphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, num3, Marshal.SizeOf(typeof(TreeInstance)));
				for (int m = 0; m < _terrainTreeDataArray.Count; m++)
				{
					TerrainTreeData terrainTreeData = _terrainTreeDataArray[m];
					int num4 = terrainTreeData.treeData.Length;
					if (num4 == 0)
					{
						continue;
					}
					graphicsBuffer.SetData(terrainTreeData.treeData);
					for (int n = 0; n < num; n++)
					{
						GPUIShaderBuffer gPUIShaderBuffer = _treeTransformBuffers[n];
						if (gPUIShaderBuffer != null && gPUIShaderBuffer.Buffer != null)
						{
							int val = _treeTransformBufferStartIndexes[n];
							cS_TerrainTreeGenerator.SetBuffer(0, GPUIConstants.PROP_gpuiTransformBuffer, gPUIShaderBuffer.Buffer);
							cS_TerrainTreeGenerator.SetBuffer(0, GPUITerrainConstants.PROP_treeData, graphicsBuffer);
							cS_TerrainTreeGenerator.SetBuffer(0, GPUIConstants.PROP_counterBuffer, _counterDataBuffer);
							if (_enableTreeInstanceColors)
							{
								cS_TerrainTreeGenerator.SetBuffer(0, GPUITerrainConstants.PROP_gpuiTreeInstanceDataBuffer, _prototypeDataArray[n]._treeInstanceDataBuffer);
							}
							cS_TerrainTreeGenerator.SetInt(GPUIConstants.PROP_bufferSize, num4);
							cS_TerrainTreeGenerator.SetInt(GPUIConstants.PROP_transformBufferStartIndex, val);
							cS_TerrainTreeGenerator.SetInt(GPUIConstants.PROP_prototypeIndex, n);
							cS_TerrainTreeGenerator.SetVector(GPUITerrainConstants.PROP_terrainSize, terrainTreeData.terrainSize);
							cS_TerrainTreeGenerator.SetVector(GPUITerrainConstants.PROP_terrainPosition, terrainTreeData.terrainPosition);
							cS_TerrainTreeGenerator.SetVector(GPUITerrainConstants.PROP_prefabScale, _prototypes[n].prefabObject.transform.localScale);
							cS_TerrainTreeGenerator.SetBool(GPUITerrainConstants.PROP_applyPrefabScale, _prototypeDataArray[n].isApplyPrefabScale);
							cS_TerrainTreeGenerator.SetBool(GPUITerrainConstants.PROP_applyRotation, _prototypeDataArray[n].isApplyRotation);
							cS_TerrainTreeGenerator.SetBool(GPUITerrainConstants.PROP_applyHeight, _prototypeDataArray[n].isApplyHeight);
							cS_TerrainTreeGenerator.DispatchX(0, num4);
							gPUIShaderBuffer.OnDataModified();
						}
					}
				}
				graphicsBuffer.Dispose();
			}
			_terrainTreeDataArray.Clear();
			for (int num5 = 0; num5 < _treeInstanceCounts.Length; num5++)
			{
				_treeInstanceCounts[num5] = 0;
			}
		}

		protected override bool AddMissingPrototypesFromTerrain(GPUITerrain gpuiTerrain)
		{
			bool result = false;
			TreePrototype[] treePrototypes = gpuiTerrain.TreePrototypes;
			int[] terrainPrototypeIndexes = GetTerrainPrototypeIndexes(gpuiTerrain);
			for (int i = 0; i < terrainPrototypeIndexes.Length; i++)
			{
				if (terrainPrototypeIndexes[i] < 0)
				{
					AddTreePrototype(treePrototypes[i]);
					result = true;
				}
			}
			return result;
		}

		protected override void SetGPUITerrainManager(GPUITerrain gpuiTerrain)
		{
			gpuiTerrain.SetTreeManager(this);
		}

		protected override void RemoveGPUITerrainManager(GPUITerrain gpuiTerrain)
		{
			gpuiTerrain.RemoveTreeManager();
		}

		internal int DetermineTreePrototypeIndex(TreePrototype treePrototype)
		{
			if (_prototypes != null)
			{
				for (int i = 0; i < _prototypes.Length; i++)
				{
					GPUIPrototype gPUIPrototype = _prototypes[i];
					if (treePrototype.prefab == gPUIPrototype.prefabObject)
					{
						return i;
					}
				}
			}
			if (_isAutoAddPrototypesBasedOnTerrains)
			{
				_isTerrainsModified = true;
			}
			return -1;
		}

		protected override void DeterminePrototypeIndexes(GPUITerrain gpuiTerrain)
		{
			gpuiTerrain.DetermineTreePrototypeIndexes(this);
		}

		protected override int[] GetTerrainPrototypeIndexes(GPUITerrain gpuiTerrain)
		{
			if (gpuiTerrain.TreePrototypes == null)
			{
				gpuiTerrain.LoadTerrainData();
			}
			if (gpuiTerrain.TreePrototypes != null && (gpuiTerrain.TreePrototypeIndexes == null || gpuiTerrain.TreePrototypes.Length != gpuiTerrain.TreePrototypeIndexes.Length))
			{
				DeterminePrototypeIndexes(gpuiTerrain);
			}
			return gpuiTerrain.TreePrototypeIndexes;
		}

		public int AddTreePrototype(TreePrototype treePrototype)
		{
			if (_prototypes != null)
			{
				for (int i = 0; i < _prototypes.Length; i++)
				{
					if (_prototypes[i] != null && _prototypes[i].prefabObject == treePrototype.prefab)
					{
						return i;
					}
				}
			}
			GPUITreePrototypeData gPUITreePrototypeData = new GPUITreePrototypeData(treePrototype);
			int num = _prototypeDataArray.Length;
			Array.Resize(ref _prototypeDataArray, num + 1);
			_prototypeDataArray[num] = gPUITreePrototypeData;
			GPUIPrototype gPUIPrototype = new GPUIPrototype(treePrototype.prefab, GetDefaultProfile());
			if (!treePrototype.prefab.HasComponent<LODGroup>() || treePrototype.prefab.HasComponentInChildren<BillboardRenderer>())
			{
				gPUIPrototype.isGenerateBillboard = true;
			}
			int result = AddPrototype(gPUIPrototype);
			OnNewPrototypeDataCreated(num);
			return result;
		}

		public void RemoveTreePrototypeAtIndex(int index, bool removeFromTerrain)
		{
			if (removeFromTerrain)
			{
				int terrainCount = GetTerrainCount();
				for (int i = 0; i < terrainCount; i++)
				{
					GPUITerrain terrain = GetTerrain(i);
					if (terrain != null)
					{
						terrain.RemoveTreePrototypeAtIndex(index);
					}
				}
			}
			RemovePrototypeAtIndex(index);
		}

		public void AddPrototypeToTerrains(GameObject pickerGameObject, int overwriteIndex)
		{
			int terrainCount = GetTerrainCount();
			for (int i = 0; i < terrainCount; i++)
			{
				GPUITerrain terrain = GetTerrain(i);
				if (terrain != null)
				{
					terrain.AddTreePrototypeToTerrain(pickerGameObject, overwriteIndex);
				}
			}
		}

		public override void RequireUpdate()
		{
			_requireUpdate = true;
		}

		public void RequireUpdate(bool reloadTreeInstances)
		{
			_reloadTreeInstances = reloadTreeInstances;
			RequireUpdate();
		}

		public override GPUIProfile GetDefaultProfile()
		{
			if (defaultProfile != null)
			{
				return defaultProfile;
			}
			return GPUITerrainConstants.DefaultTreeProfile;
		}

		public override List<string> GetShaderKeywords(int prototypeIndex)
		{
			if (_enableTreeInstanceColors)
			{
				return TREE_INSTANCE_COLORS_SHADER_KEYWORDS;
			}
			return base.GetShaderKeywords(prototypeIndex);
		}
	}
}
