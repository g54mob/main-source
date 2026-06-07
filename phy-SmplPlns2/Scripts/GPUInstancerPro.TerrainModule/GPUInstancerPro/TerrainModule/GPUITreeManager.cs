using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(200)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#The_Tree_Manager")]
	public class GPUITreeManager : GPUITerrainManager<GPUITreePrototypeData>
	{
		[SerializeField]
		internal bool _enableTreeInstanceColors;

		[SerializeField]
		internal bool _autoGenerateBillboards = true;

		[NonSerialized]
		private bool _requireUpdate;

		[NonSerialized]
		private int[] _treeInstanceCounts;

		[NonSerialized]
		private GPUITransformBufferData[] _treeTransformBuffers;

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
			_treeInstanceCounts = new int[num];
			_treeTransformBuffers = new GPUITransformBufferData[num];
			_treeTransformBufferStartIndexes = new int[num];
			_counterDataBuffer = new GPUIDataBuffer<GPUICounterData>("Tree Counter Buffer", num);
			GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
			instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(UpdateTreeMatrices));
			GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
			instance2.OnPreCull = (Action<GPUICameraData>)Delegate.Combine(instance2.OnPreCull, new Action<GPUICameraData>(UpdateTreeMatrices));
			if (GPUITerrain._terrainsSearchingForTreeManager != null)
			{
				AddTerrains(GPUITerrain._terrainsSearchingForTreeManager);
				GPUITerrain._terrainsSearchingForTreeManager.Clear();
			}
		}

		public override void Dispose()
		{
			base.Dispose();
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
				GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
				instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(UpdateTreeMatrices));
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
			int num2 = 0;
			foreach (GPUITerrain activeTerrainValue in GetActiveTerrainValues())
			{
				if (!IsRenderTerrainTrees(activeTerrainValue))
				{
					continue;
				}
				int[] terrainPrototypeIndexes = GetTerrainPrototypeIndexes(activeTerrainValue);
				if (terrainPrototypeIndexes == null)
				{
					continue;
				}
				TreeInstance[] treeInstances = activeTerrainValue.GetTreeInstances(_reloadTreeInstances);
				num2 = Mathf.Max(num2, treeInstances.Length);
				for (int i = 0; i < treeInstances.Length; i++)
				{
					int prototypeIndex = treeInstances[i].prototypeIndex;
					if (prototypeIndex < terrainPrototypeIndexes.Length)
					{
						int num3 = terrainPrototypeIndexes[prototypeIndex];
						if (num3 >= 0 && num3 < num)
						{
							_treeInstanceCounts[num3]++;
						}
					}
				}
			}
			_reloadTreeInstances = false;
			if (_treeTransformBuffers.Length != num)
			{
				_treeTransformBuffers = new GPUITransformBufferData[num];
			}
			if (_treeTransformBufferStartIndexes.Length != num)
			{
				_treeTransformBufferStartIndexes = new int[num];
			}
			for (int j = 0; j < num; j++)
			{
				if (!_prototypes[j].isEnabled || _runtimeRenderKeys[j] == 0)
				{
					_treeTransformBuffers[j] = null;
					continue;
				}
				int num4 = _treeInstanceCounts[j];
				GPUIRenderingSystem.SetBufferSize(_runtimeRenderKeys[j], num4, isCopyPreviousData: false);
				GPUIRenderingSystem.SetInstanceCount(_runtimeRenderKeys[j], num4);
				_prototypeDataArray[j]._treeInstanceDataBuffer?.Release();
				if (num4 > 0)
				{
					if (_enableTreeInstanceColors)
					{
						_prototypeDataArray[j]._treeInstanceDataBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, num4, 16);
					}
					if (GPUIRenderingSystem.TryGetTransformBufferData(_runtimeRenderKeys[j], out _treeTransformBuffers[j], out _treeTransformBufferStartIndexes[j], out var _))
					{
						_treeTransformBuffers[j].GetTransformBuffer()?.CompleteAsyncRequests();
					}
					else
					{
						Debug.LogError(GPUIConstants.LOG_PREFIX + "Tree Manager can not find transform buffer for prototype: " + _prototypes[j]);
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
						renderSourceGroup.AddMaterialPropertyOverride(GPUITerrainConstants.PROP_gpuiTreeInstanceDataBuffer, _prototypeDataArray[k]._treeInstanceDataBuffer, -1, -1, isPersistent: true);
					}
				}
				cS_TerrainTreeGenerator.SetBool(GPUIConstants.PROP_isLinearSpace, QualitySettings.activeColorSpace == ColorSpace.Linear);
			}
			else
			{
				cS_TerrainTreeGenerator.DisableKeyword(GPUITerrainConstants.Kw_GPUI_TREE_INSTANCE_COLOR);
			}
			if (num2 > 0)
			{
				GraphicsBuffer graphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, num2, Marshal.SizeOf(typeof(TreeInstance)));
				List<int> terrainPrototypeIndexes2 = new List<int>();
				foreach (GPUITerrain activeTerrainValue2 in GetActiveTerrainValues())
				{
					if (!IsRenderTerrainTrees(activeTerrainValue2) || activeTerrainValue2.TreePrototypeIndexes == null)
					{
						continue;
					}
					TreeInstance[] treeInstances2 = activeTerrainValue2.GetTreeInstances();
					int num5 = treeInstances2.Length;
					if (num5 == 0)
					{
						continue;
					}
					graphicsBuffer.SetData(treeInstances2);
					Vector3 size = activeTerrainValue2.GetSize();
					Vector3 position = activeTerrainValue2.GetPosition();
					bool flag = activeTerrainValue2.terrainHolesSampleMode == GPUITerrain.GPUITerrainHolesSampleMode.Runtime;
					Texture holesTexture = activeTerrainValue2.GetHolesTexture();
					bool flag2 = activeTerrainValue2.HasMatrixOffset();
					Matrix4x4 matrixOffset = activeTerrainValue2.GetMatrixOffset();
					for (int l = 0; l < num; l++)
					{
						GPUITransformBufferData gPUITransformBufferData = _treeTransformBuffers[l];
						if (gPUITransformBufferData == null)
						{
							continue;
						}
						GPUIShaderBuffer transformBuffer = gPUITransformBufferData.GetTransformBuffer();
						if (transformBuffer == null || transformBuffer.Buffer == null)
						{
							continue;
						}
						activeTerrainValue2.GetTerrainTreePrototypeIndexes(l, ref terrainPrototypeIndexes2);
						foreach (int item in terrainPrototypeIndexes2)
						{
							int val = _treeTransformBufferStartIndexes[l];
							cS_TerrainTreeGenerator.SetBuffer(0, GPUIConstants.PROP_gpuiTransformBuffer, transformBuffer.Buffer);
							cS_TerrainTreeGenerator.SetBuffer(0, GPUITerrainConstants.PROP_treeData, graphicsBuffer);
							cS_TerrainTreeGenerator.SetBuffer(0, GPUIConstants.PROP_counterBuffer, _counterDataBuffer);
							if (_enableTreeInstanceColors)
							{
								cS_TerrainTreeGenerator.SetBuffer(0, GPUITerrainConstants.PROP_gpuiTreeInstanceDataBuffer, _prototypeDataArray[l]._treeInstanceDataBuffer);
							}
							cS_TerrainTreeGenerator.SetInt(GPUIConstants.PROP_bufferSize, num5);
							cS_TerrainTreeGenerator.SetInt(GPUIConstants.PROP_transformBufferStartIndex, val);
							cS_TerrainTreeGenerator.SetInt(GPUIConstants.PROP_prototypeIndex, l);
							cS_TerrainTreeGenerator.SetInt(GPUITerrainConstants.PROP_terrainPrototypeIndex, item);
							cS_TerrainTreeGenerator.SetVector(GPUITerrainConstants.PROP_terrainSize, size);
							cS_TerrainTreeGenerator.SetVector(GPUITerrainConstants.PROP_terrainPosition, position);
							cS_TerrainTreeGenerator.SetVector(GPUITerrainConstants.PROP_prefabScale, _prototypes[l].prefabObject.transform.localScale);
							cS_TerrainTreeGenerator.SetBool(GPUITerrainConstants.PROP_applyPrefabScale, _prototypeDataArray[l].isApplyPrefabScale);
							cS_TerrainTreeGenerator.SetBool(GPUITerrainConstants.PROP_applyRotation, _prototypeDataArray[l].isApplyRotation);
							cS_TerrainTreeGenerator.SetBool(GPUITerrainConstants.PROP_applyHeight, _prototypeDataArray[l].isApplyHeight);
							if (flag && holesTexture != null)
							{
								cS_TerrainTreeGenerator.EnableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
								cS_TerrainTreeGenerator.SetTexture(0, GPUITerrainConstants.PROP_terrainHoleTexture, holesTexture);
							}
							else
							{
								cS_TerrainTreeGenerator.DisableKeyword(GPUITerrainConstants.Kw_GPUI_TERRAIN_HOLES);
							}
							if (flag2)
							{
								cS_TerrainTreeGenerator.EnableKeyword("GPUI_TRANSFORM_OFFSET");
								cS_TerrainTreeGenerator.SetMatrix(GPUIConstants.PROP_gpuiTransformOffset, matrixOffset);
							}
							else
							{
								cS_TerrainTreeGenerator.DisableKeyword("GPUI_TRANSFORM_OFFSET");
							}
							cS_TerrainTreeGenerator.DispatchX(0, num5);
						}
						gPUITransformBufferData.OnTransformDataModified();
						gPUITransformBufferData.ResetPreviousFrameBuffer();
					}
				}
				graphicsBuffer.Dispose();
			}
			for (int m = 0; m < _treeInstanceCounts.Length; m++)
			{
				_treeInstanceCounts[m] = 0;
			}
			OnLightProbesUpdated();
		}

		private bool IsRenderTerrainTrees(GPUITerrain gpuiTerrain)
		{
			if (gpuiTerrain != null)
			{
				return gpuiTerrain.isActiveAndEnabled;
			}
			return false;
		}

		protected override void OnUpdatePerInstanceLightProbes(int prototypeIndex)
		{
			if (!GPUIRenderingSystem.TryGetTransformBufferData(_runtimeRenderKeys[prototypeIndex], out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				return;
			}
			GPUIShaderBuffer transformBuffer = transformBufferData.GetTransformBuffer();
			if (transformBuffer != null)
			{
				transformBuffer.CompleteAsyncRequests();
				transformBuffer.AsyncRequestIntoNativeArray(delegate(NativeArray<Matrix4x4> matrices)
				{
					transformBufferData.CalculateInterpolatedLightAndOcclusionProbes(matrices, 0, bufferStartIndex, bufferSize);
					matrices.Dispose();
				});
			}
		}

		protected override bool AddMissingPrototypesFromTerrain(GPUITerrain gpuiTerrain)
		{
			bool flag = false;
			TreePrototype[] treePrototypes = gpuiTerrain.TreePrototypes;
			int[] terrainPrototypeIndexes = GetTerrainPrototypeIndexes(gpuiTerrain);
			for (int i = 0; i < terrainPrototypeIndexes.Length; i++)
			{
				flag |= terrainPrototypeIndexes[i] < 0 && AddTreePrototype(treePrototypes[i]) >= 0;
			}
			return flag;
		}

		protected override void SetGPUITerrainManager(GPUITerrain gpuiTerrain)
		{
			gpuiTerrain.SetTreeManager(this);
		}

		protected override void RemoveGPUITerrainManager(GPUITerrain gpuiTerrain)
		{
			if (gpuiTerrain.TreeManager == this)
			{
				gpuiTerrain.RemoveTreeManager();
			}
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
			if (treePrototype == null || treePrototype.prefab == null)
			{
				return -1;
			}
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
			if (_autoGenerateBillboards && (!treePrototype.prefab.HasComponent<LODGroup>() || treePrototype.prefab.HasComponentInChildren<BillboardRenderer>()))
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
