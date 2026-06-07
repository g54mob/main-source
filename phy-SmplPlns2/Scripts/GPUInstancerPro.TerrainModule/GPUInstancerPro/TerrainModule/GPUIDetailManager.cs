using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(200)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#The_Detail_Manager")]
	public class GPUIDetailManager : GPUITerrainManager<GPUIDetailPrototypeData>
	{
		internal class GPUIDetailUpdateData : GPUIDataBuffer<GPUICounterData>
		{
			public GPUICameraData cameraData;

			public Vector3 position;

			public int lastUpdateFrame;

			public bool requireReadback;

			public bool processReadback;

			public GPUIDetailUpdateData(GPUICameraData cameraData, string name, int length, GraphicsBuffer.Target target = GraphicsBuffer.Target.Structured)
				: base(name, length, target)
			{
				this.cameraData = cameraData;
				position = Vector3.negativeInfinity;
				lastUpdateFrame = 0;
			}

			public void ProcessGPUReadback(GPUIDetailManager detailManager)
			{
				if (detailManager._runtimeRenderKeys == null)
				{
					return;
				}
				NativeArray<GPUICounterData> requestedData = GetRequestedData();
				if (!requestedData.IsCreated)
				{
					return;
				}
				bool flag = GPUIRenderingSystem.Instance.CameraDataProvider.Count > 1 || !Application.isPlaying;
				int length = requestedData.Length;
				int prototypeCount = detailManager.GetPrototypeCount();
				for (int i = 0; i < prototypeCount && i < length; i++)
				{
					int num = detailManager._runtimeRenderKeys[i];
					if (num == 0)
					{
						continue;
					}
					if (GPUIRenderingSystem.TryGetRenderSourceGroup(num, out var renderSourceGroup))
					{
						int count = (int)requestedData[i].count;
						GPUIDetailPrototypeData gPUIDetailPrototypeData = detailManager._prototypeDataArray[i];
						if (count <= 0 || count == renderSourceGroup.InstanceCount)
						{
							continue;
						}
						int num2 = Mathf.Max(Mathf.CeilToInt((float)count * gPUIDetailPrototypeData.detailExtraBufferSizePercentage), 1024);
						if (count > renderSourceGroup.BufferSize)
						{
							GPUIRenderingSystem.SetBufferSize(num, count + num2, isCopyPreviousData: false);
							if (!flag)
							{
								GPUIRenderingSystem.SetInstanceCount(num, count);
							}
							detailManager.RequireUpdate();
						}
						else if (!flag && gPUIDetailPrototypeData.detailBufferSizePercentageDifferenceForReduction > 0f)
						{
							int num3 = Mathf.CeilToInt((float)count * gPUIDetailPrototypeData.detailBufferSizePercentageDifferenceForReduction) + num2;
							if (renderSourceGroup.BufferSize - count > num3)
							{
								GPUIRenderingSystem.SetBufferSize(num, count + num2, isCopyPreviousData: false);
								GPUIRenderingSystem.SetInstanceCount(num, count);
								detailManager.RequireUpdate();
							}
							else
							{
								GPUIRenderingSystem.SetInstanceCount(num, count);
							}
						}
						else if (count > renderSourceGroup.InstanceCount)
						{
							GPUIRenderingSystem.SetInstanceCount(num, count);
						}
					}
					else
					{
						Debug.LogWarning(GPUIConstants.LOG_PREFIX + "Can not find renderer with key: " + detailManager._runtimeRenderKeys[i]);
					}
				}
			}
		}

		[SerializeField]
		public GPUIProfile defaultDetailTextureProfile;

		[SerializeField]
		public float detailObjectDistance = 250f;

		[SerializeField]
		public Vector4 windVector = new Vector2(0.4f, 0.8f);

		[SerializeField]
		public Texture2D healthyDryNoiseTexture;

		[SerializeField]
		[Range(0f, 100f)]
		public float detailUpdateDistance = 1f;

		[SerializeField]
		public bool disableAsyncDetailDataRequest;

		[NonSerialized]
		private int _requireUpdateFrame;

		[NonSerialized]
		private Dictionary<int, GPUIDetailUpdateData> _detailUpdateDataDict;

		[NonSerialized]
		private Action<GPUIDataBuffer<GPUICounterData>> _processCounterDataCallback;

		[NonSerialized]
		private bool _forceImmediateUpdate;

		[NonSerialized]
		private int[] _sizeAndIndexes;

		[NonSerialized]
		private bool _reloadTerrainDetailTextures;

		private const int ERROR_CODE_ADDITION = 400;

		public const int DETAIL_SUB_SETTING_DIVIDER = 1000;

		protected override void Update()
		{
			base.Update();
			if (_detailUpdateDataDict == null)
			{
				return;
			}
			foreach (GPUIDetailUpdateData value in _detailUpdateDataDict.Values)
			{
				if (!value.IsDataRequested())
				{
					if (value.requireReadback)
					{
						value.requireReadback = false;
						value.AsyncDataRequest(_processCounterDataCallback, writeToDataAfterReadback: false);
					}
					else if (value.processReadback)
					{
						value.processReadback = false;
						value.ProcessGPUReadback(this);
					}
				}
			}
		}

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
				if (terrain != null && terrain.DetailPrototypes != null && terrain.DetailPrototypes.Length != 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				errorCode = -402;
				return false;
			}
			return true;
		}

		public override void Initialize()
		{
			base.Initialize();
			_sizeAndIndexes = new int[4];
			_detailUpdateDataDict = new Dictionary<int, GPUIDetailUpdateData>();
			GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
			instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(UpdateDetailMatrices));
			GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
			instance2.OnCommandBufferModified = (Action)Delegate.Remove(instance2.OnCommandBufferModified, new Action(RequireUpdate));
			GPUIRenderingSystem instance3 = GPUIRenderingSystem.Instance;
			instance3.OnPreCull = (Action<GPUICameraData>)Delegate.Combine(instance3.OnPreCull, new Action<GPUICameraData>(UpdateDetailMatrices));
			GPUIRenderingSystem instance4 = GPUIRenderingSystem.Instance;
			instance4.OnCommandBufferModified = (Action)Delegate.Combine(instance4.OnCommandBufferModified, new Action(RequireUpdate));
			_processCounterDataCallback = ProcessCounterData;
			RequireUpdate();
			if (GPUITerrain._terrainsSearchingForDetailManager != null)
			{
				AddTerrains(GPUITerrain._terrainsSearchingForDetailManager);
				GPUITerrain._terrainsSearchingForDetailManager.Clear();
			}
		}

		protected override bool RegisterRenderer(int prototypeIndex)
		{
			if (base.RegisterRenderer(prototypeIndex))
			{
				GPUIDetailPrototypeData obj = _prototypeDataArray[prototypeIndex];
				int num = Mathf.Max(obj.initialBufferSize, 1);
				GPUIRenderingSystem.SetBufferSize(_runtimeRenderKeys[prototypeIndex], num, isCopyPreviousData: false);
				if (disableAsyncDetailDataRequest)
				{
					GPUIRenderingSystem.SetInstanceCount(_runtimeRenderKeys[prototypeIndex], num);
				}
				obj._bounds = GPUIRenderingSystem.Instance.LODGroupDataProvider.GetOrCreateLODGroupData(_prototypes[prototypeIndex]).bounds;
				if (_detailUpdateDataDict != null)
				{
					foreach (GPUIDetailUpdateData value in _detailUpdateDataDict.Values)
					{
						if (prototypeIndex >= value.Length)
						{
							value.Resize(prototypeIndex + 1);
						}
					}
				}
				return true;
			}
			return false;
		}

		public override void Dispose()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
				instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(UpdateDetailMatrices));
				GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
				instance2.OnCommandBufferModified = (Action)Delegate.Remove(instance2.OnCommandBufferModified, new Action(RequireUpdate));
			}
			base.Dispose();
			if (_detailUpdateDataDict != null)
			{
				foreach (KeyValuePair<int, GPUIDetailUpdateData> item in _detailUpdateDataDict)
				{
					item.Value.Dispose();
				}
			}
			_detailUpdateDataDict = null;
		}

		private void UpdateDetailMatrices(GPUICameraData cameraData)
		{
			if (!base.IsInitialized)
			{
				return;
			}
			int num = _prototypes.Length;
			if (num == 0)
			{
				return;
			}
			Dictionary<int, GPUITerrain>.ValueCollection activeTerrainValues = GetActiveTerrainValues();
			if (GetActiveTerrainCount() == 0 && _runtimeRenderKeys != null)
			{
				for (int i = 0; i < _runtimeRenderKeys.Length; i++)
				{
					int num2 = _runtimeRenderKeys[i];
					if (num2 != 0)
					{
						int num3 = Mathf.Max(GetPrototypeData(i).initialBufferSize, 1);
						GPUIRenderingSystem.SetBufferSize(num2, num3, isCopyPreviousData: false);
						if (disableAsyncDetailDataRequest)
						{
							GPUIRenderingSystem.SetInstanceCount(num2, num3);
						}
					}
				}
			}
			ComputeShader cS_VegetationGenerator = GPUITerrainConstants.CS_VegetationGenerator;
			if (_detailUpdateDataDict == null)
			{
				_detailUpdateDataDict = new Dictionary<int, GPUIDetailUpdateData>();
			}
			Vector3 cameraPosition = cameraData.GetCameraPosition();
			int instanceID = cameraData.ActiveCamera.GetInstanceID();
			if (!_detailUpdateDataDict.TryGetValue(instanceID, out var value))
			{
				value = new GPUIDetailUpdateData(cameraData, "GPUIDetailCounterBuffer", num);
				_detailUpdateDataDict[instanceID] = value;
			}
			if (value.Length < num)
			{
				value.Resize(num);
			}
			if ((!_forceImmediateUpdate && value.IsDataRequested()) || (_requireUpdateFrame <= value.lastUpdateFrame && !(detailUpdateDistance <= 0f) && !(Vector3.Distance(value.position, cameraPosition) >= detailUpdateDistance)))
			{
				return;
			}
			if (_forceImmediateUpdate)
			{
				value.WaitForReadbackCompletion();
				_forceImmediateUpdate = false;
				if (value.processReadback)
				{
					value.processReadback = false;
					value.ProcessGPUReadback(this);
				}
			}
			if (!value.UpdateBufferData())
			{
				_sizeAndIndexes[0] = num;
				cS_VegetationGenerator.SetBuffer(1, GPUITerrainConstants.PROP_detailCounterBuffer, value.Buffer);
				cS_VegetationGenerator.SetInts(GPUIConstants.PROP_sizeAndIndexes, _sizeAndIndexes);
				cS_VegetationGenerator.DispatchX(1, num);
			}
			bool flag = true;
			for (int j = 0; j < num; j++)
			{
				if (!_prototypes[j].isEnabled)
				{
					continue;
				}
				if (GPUIRenderingSystem.TryGetRenderSourceGroup(_runtimeRenderKeys[j], out var renderSourceGroup) && cameraData.TryGetShaderBuffer(_runtimeRenderKeys[j], out var shaderBuffer))
				{
					GraphicsBuffer buffer = shaderBuffer.Buffer;
					if (buffer == null)
					{
						flag = false;
						continue;
					}
					_sizeAndIndexes[0] = buffer.count;
					_sizeAndIndexes[1] = j;
					GPUIDetailPrototypeData detailPrototypeData = _prototypeDataArray[j];
					foreach (GPUITerrain item in activeTerrainValues)
					{
						if (!(item == null) && item.isActiveAndEnabled)
						{
							if (!item.IsDetailDensityTexturesLoaded || _reloadTerrainDetailTextures)
							{
								item.CreateDetailTextures();
							}
							item.GenerateVegetation(detailPrototypeData, buffer, value, cameraPosition, detailObjectDistance, healthyDryNoiseTexture, _sizeAndIndexes);
						}
					}
					cS_VegetationGenerator.SetBuffer(2, GPUIConstants.PROP_gpuiTransformBuffer, buffer);
					cS_VegetationGenerator.SetBuffer(2, GPUITerrainConstants.PROP_detailCounterBuffer, value.Buffer);
					cS_VegetationGenerator.SetInts(GPUIConstants.PROP_sizeAndIndexes, _sizeAndIndexes);
					cS_VegetationGenerator.DispatchX(2, buffer.count);
					renderSourceGroup.TransformBufferData.OnTransformDataModified();
				}
				else
				{
					flag = false;
				}
			}
			_reloadTerrainDetailTextures = false;
			if (!disableAsyncDetailDataRequest)
			{
				value.requireReadback = true;
			}
			if (flag)
			{
				value.position = cameraPosition;
				value.lastUpdateFrame = Time.frameCount;
			}
		}

		private void ProcessCounterData(GPUIDataBuffer<GPUICounterData> buffer)
		{
			if (buffer is GPUIDetailUpdateData gPUIDetailUpdateData)
			{
				gPUIDetailUpdateData.processReadback = true;
			}
		}

		public void ExecuteProceduralDetails(GPUITerrain gpuiTerrain)
		{
			int prototypeCount = GetPrototypeCount();
			int[] terrainPrototypeIndexes = GetTerrainPrototypeIndexes(gpuiTerrain);
			if (terrainPrototypeIndexes == null)
			{
				return;
			}
			for (int i = 0; i < prototypeCount; i++)
			{
				GPUIDetailPrototypeData gPUIDetailPrototypeData = _prototypeDataArray[i];
				if (!(gPUIDetailPrototypeData.proceduralDensityData != null))
				{
					continue;
				}
				for (int j = 0; j < terrainPrototypeIndexes.Length; j++)
				{
					if (terrainPrototypeIndexes[j] % 1000 == i)
					{
						gPUIDetailPrototypeData.proceduralDensityData.Execute(gpuiTerrain, j);
					}
				}
			}
		}

		protected override bool AddMissingPrototypesFromTerrain(GPUITerrain gpuiTerrain)
		{
			bool result = false;
			DetailPrototype[] detailPrototypes = gpuiTerrain.DetailPrototypes;
			int[] terrainPrototypeIndexes = GetTerrainPrototypeIndexes(gpuiTerrain);
			for (int i = 0; i < terrainPrototypeIndexes.Length; i++)
			{
				if (terrainPrototypeIndexes[i] < 0)
				{
					AddDetailPrototype(detailPrototypes[i]);
					result = true;
				}
			}
			return result;
		}

		protected override void BeginDeterminePrototypeIndexes()
		{
			int terrainCount = GetTerrainCount();
			int prototypeCount = GetPrototypeCount();
			for (int num = terrainCount - 1; num >= 0; num--)
			{
				GPUITerrain terrain = GetTerrain(num);
				if (!(terrain == null) && terrain.DetailPrototypeIndexes != null && terrain.DetailPrototypes != null)
				{
					for (int i = 0; i < prototypeCount; i++)
					{
						int firstTerrainDetailPrototypeIndex = terrain.GetFirstTerrainDetailPrototypeIndex(i);
						if (firstTerrainDetailPrototypeIndex >= 0 && terrain.DetailPrototypes.Length > firstTerrainDetailPrototypeIndex)
						{
							DetailPrototype detailPrototype = terrain.DetailPrototypes[firstTerrainDetailPrototypeIndex];
							if (_prototypeDataArray[i].IsMatchingPrefabAndTexture(detailPrototype, _prototypes[i], checkPropertyValues: false))
							{
								_prototypeDataArray[i].ReadFromDetailPrototypeData(terrain.DetailPrototypes[firstTerrainDetailPrototypeIndex], terrain.DetailPrototypeIndexes[firstTerrainDetailPrototypeIndex] / 1000, this, i);
							}
						}
					}
				}
			}
		}

		internal int DetermineDetailPrototypeIndex(DetailPrototype detailPrototype)
		{
			if (_prototypes != null)
			{
				for (int i = 0; i < _prototypes.Length; i++)
				{
					GPUIPrototype prototype = _prototypes[i];
					GPUIDetailPrototypeData gPUIDetailPrototypeData = _prototypeDataArray[i];
					if (!gPUIDetailPrototypeData.IsMatchingPrefabAndTexture(detailPrototype, prototype))
					{
						continue;
					}
					int subSettingCount = gPUIDetailPrototypeData.GetSubSettingCount();
					for (int j = 0; j < subSettingCount; j++)
					{
						if (gPUIDetailPrototypeData.HasSameSettingsWith(detailPrototype, j))
						{
							return i + j * 1000;
						}
					}
					gPUIDetailPrototypeData.ReadFromDetailPrototypeData(detailPrototype, subSettingCount, this, i);
					if (base.IsInitialized)
					{
						gPUIDetailPrototypeData.SetParameterBufferData();
					}
					return i + subSettingCount * 1000;
				}
			}
			if (_isAutoAddPrototypesBasedOnTerrains)
			{
				_isTerrainsModified = true;
			}
			return -1;
		}

		protected override void SetGPUITerrainManager(GPUITerrain gpuiTerrain)
		{
			gpuiTerrain.SetDetailManager(this);
		}

		protected override void RemoveGPUITerrainManager(GPUITerrain gpuiTerrain)
		{
			if (gpuiTerrain.DetailManager == this)
			{
				gpuiTerrain.RemoveDetailManager();
			}
		}

		protected override void OnNewPrototypeDataCreated(int prototypeIndex)
		{
			base.OnNewPrototypeDataCreated(prototypeIndex);
			if (_prototypeDataArray[prototypeIndex].detailTexture != null)
			{
				_prototypes[prototypeIndex].name = _prototypeDataArray[prototypeIndex].detailTexture.name;
			}
		}

		public override void CheckPrototypeChanges()
		{
			base.CheckPrototypeChanges();
			for (int i = 0; i < GetPrototypeCount(); i++)
			{
				GPUIPrototype gPUIPrototype = _prototypes[i];
				if (gPUIPrototype.prototypeType == GPUIPrototypeType.MeshAndMaterial)
				{
					if (gPUIPrototype.prototypeMesh == null)
					{
						gPUIPrototype.prototypeMesh = GPUITerrainConstants.DefaultDetailMesh;
					}
					if (gPUIPrototype.prototypeMaterials == null || gPUIPrototype.prototypeMaterials.Length == 0 || gPUIPrototype.prototypeMaterials[0] == null)
					{
						gPUIPrototype.prototypeMaterials = new Material[1] { GPUITerrainConstants.DefaultDetailMaterial };
					}
					if (_prototypeDataArray[i].mpbDescription == null)
					{
						_prototypeDataArray[i].mpbDescription = GPUITerrainConstants.DefaultDetailMaterialDescription;
					}
				}
			}
		}

		protected override void DeterminePrototypeIndexes(GPUITerrain gpuiTerrain)
		{
			gpuiTerrain.DetermineDetailPrototypeIndexes(this);
		}

		protected override int[] GetTerrainPrototypeIndexes(GPUITerrain gpuiTerrain)
		{
			if (gpuiTerrain.DetailPrototypes == null)
			{
				gpuiTerrain.LoadTerrain();
			}
			if (gpuiTerrain.DetailPrototypeIndexes == null || (gpuiTerrain.DetailPrototypes != null && gpuiTerrain.DetailPrototypes.Length != gpuiTerrain.DetailPrototypeIndexes.Length))
			{
				DeterminePrototypeIndexes(gpuiTerrain);
			}
			return gpuiTerrain.DetailPrototypeIndexes;
		}

		public int AddDetailPrototype(DetailPrototype detailPrototype)
		{
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < _prototypes.Length; i++)
			{
				GPUIPrototype prototype = _prototypes[i];
				GPUIDetailPrototypeData gPUIDetailPrototypeData = _prototypeDataArray[i];
				if (!gPUIDetailPrototypeData.IsMatchingPrefabAndTexture(detailPrototype, prototype))
				{
					continue;
				}
				num = i;
				num2 = gPUIDetailPrototypeData.GetSubSettingCount();
				for (int j = 0; j < num2; j++)
				{
					if (gPUIDetailPrototypeData.HasSameSettingsWith(detailPrototype, j))
					{
						num2 = j;
						break;
					}
				}
				break;
			}
			if (num < 0)
			{
				num = ((!(detailPrototype.prototype != null)) ? AddPrototype(new GPUIPrototype(GPUITerrainConstants.DefaultDetailMesh, new Material[1] { GPUITerrainConstants.DefaultDetailMaterial }, GetTexturePrototypeProfile())) : AddPrototype(new GPUIPrototype(detailPrototype.prototype.GetPrefabRoot(), GetDefaultProfile())));
			}
			if (num < 0)
			{
				if (detailPrototype.prototype != null)
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Failed adding a new Detail prototype: " + detailPrototype.prototype, detailPrototype.prototype);
				}
				else
				{
					Debug.LogError(GPUIConstants.LOG_PREFIX + "Failed adding a new Detail prototype: " + detailPrototype.prototypeTexture, detailPrototype.prototypeTexture);
				}
				return -1;
			}
			_prototypeDataArray[num].ReadFromDetailPrototypeData(detailPrototype, num2, this, num);
			OnNewPrototypeDataCreated(num);
			return num;
		}

		public override void OnPrototypePropertiesModified()
		{
			base.OnPrototypePropertiesModified();
			if (!base.IsInitialized)
			{
				return;
			}
			if (healthyDryNoiseTexture == null)
			{
				healthyDryNoiseTexture = GPUITerrainConstants.DefaultHealthyDryNoiseTexture;
			}
			for (int i = 0; i < _prototypes.Length; i++)
			{
				if (_runtimeRenderKeys[i] != 0 && _prototypeDataArray[i].detailTexture != null && GPUIRenderingSystem.TryGetRenderSourceGroup(_runtimeRenderKeys[i], out var renderSourceGroup))
				{
					_prototypeDataArray[i].SetMPBValues(this, i, renderSourceGroup);
				}
			}
			for (int j = 0; j < _prototypeDataArray.Length; j++)
			{
				_prototypeDataArray[j].SetParameterBufferData();
			}
			RequireUpdate();
		}

		public void RemoveDetailPrototypeAtIndex(int index, bool removeFromTerrain)
		{
			if (removeFromTerrain)
			{
				int terrainCount = GetTerrainCount();
				for (int i = 0; i < terrainCount; i++)
				{
					GPUITerrain terrain = GetTerrain(i);
					if (terrain != null)
					{
						terrain.RemoveDetailPrototypeAtIndex(index);
					}
				}
			}
			RemovePrototypeAtIndex(index);
		}

		public override bool CanAddObjectAsPrototype(UnityEngine.Object obj)
		{
			if (base.CanAddObjectAsPrototype(obj))
			{
				return true;
			}
			if (obj is Texture2D)
			{
				return true;
			}
			return false;
		}

		public void AddPrototypeToTerrains(UnityEngine.Object pickerObject, int overwriteIndex)
		{
			int terrainCount = GetTerrainCount();
			for (int i = 0; i < terrainCount; i++)
			{
				GPUITerrain terrain = GetTerrain(i);
				if (terrain != null)
				{
					terrain.AddDetailPrototypeToTerrain(pickerObject, overwriteIndex);
				}
			}
		}

		protected override void OnFirstTerrainAdded(Terrain terrain)
		{
			base.OnFirstTerrainAdded(terrain);
			if (detailObjectDistance == 250f)
			{
				float num = terrain.detailObjectDistance;
				if (num > 0f)
				{
					detailObjectDistance = num;
				}
			}
		}

		public override void RequireUpdate()
		{
			_requireUpdateFrame = Time.frameCount;
		}

		public void RequireUpdate(bool forceImmediateUpdate, bool reloadTerrainDetailTextures = false)
		{
			if (forceImmediateUpdate)
			{
				_forceImmediateUpdate = true;
			}
			if (reloadTerrainDetailTextures)
			{
				_reloadTerrainDetailTextures = true;
			}
			RequireUpdate();
		}

		public override GPUIProfile GetDefaultProfile()
		{
			if (defaultProfile != null)
			{
				return defaultProfile;
			}
			return GPUITerrainConstants.DefaultDetailPrefabProfile;
		}

		public GPUIProfile GetTexturePrototypeProfile()
		{
			if (defaultDetailTextureProfile != null)
			{
				return defaultDetailTextureProfile;
			}
			return GPUITerrainConstants.DefaultDetailTextureProfile;
		}

		public override int GetRendererGroupID(int prototypeIndex)
		{
			return GPUIUtility.GenerateHash(GetInstanceID(), prototypeIndex);
		}

		public override GPUITransformBufferType GetTransformBufferType(int prototypeIndex)
		{
			return GPUITransformBufferType.CameraBased;
		}

		public Bounds GetPrototypeBounds(int prototypeIndex)
		{
			return _prototypeDataArray[prototypeIndex]._bounds;
		}

		public void SetDistanceDensityReduction(bool enabled)
		{
			if (_prototypeDataArray != null)
			{
				for (int i = 0; i < _prototypeDataArray.Length; i++)
				{
					_prototypeDataArray[i].isUseDensityReduction = enabled;
				}
				RequireUpdate();
			}
		}

		public void SetDetailObjectDistance(float distance)
		{
			detailObjectDistance = distance;
			RequireUpdate();
		}

		public bool IsReadTerrainDetails(int prototypeIndex)
		{
			GPUIDetailPrototypeData prototypeData = GetPrototypeData(prototypeIndex);
			if (prototypeData != null && prototypeData.proceduralDensityData != null && !prototypeData.proceduralDensityData.isReadTerrainDetails)
			{
				return false;
			}
			return true;
		}

		public bool HasProceduralDensity()
		{
			int prototypeCount = GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (_prototypeDataArray[i].proceduralDensityData != null)
				{
					return true;
				}
			}
			return false;
		}
	}
}
