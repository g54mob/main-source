using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Terrain))]
	[DefaultExecutionOrder(-200)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Terrain")]
	public class GPUITerrainBuiltin : GPUITerrain
	{
		[SerializeField]
		internal float _terrainTreeDistance = 5000f;

		[SerializeField]
		internal bool _isBakedDetailTextures;

		[SerializeField]
		protected bool _isCustomBakedDetailTextures;

		[SerializeField]
		private Terrain _terrain;

		[NonSerialized]
		private DetailScatterMode _detailScatterMode;

		public override void LoadTerrain()
		{
			base.LoadTerrain();
			if (_terrain == null)
			{
				_terrain = GetComponent<Terrain>();
			}
			Vector3 size = _terrain.terrainData.size;
			Bounds bounds = new Bounds(size / 2f, size);
			if (_bounds != bounds)
			{
				_bounds = bounds;
			}
		}

		public override void LoadTerrainData()
		{
			base.LoadTerrainData();
			if (_terrain.terrainData != null)
			{
				base.TreePrototypes = _terrain.terrainData.treePrototypes;
				base.DetailPrototypes = _terrain.terrainData.detailPrototypes;
				_detailScatterMode = _terrain.terrainData.detailScatterMode;
				if (_terrain.treeDistance > 0f)
				{
					_terrainTreeDistance = _terrain.treeDistance;
				}
			}
		}

		internal override void SetTerrainDetailObjectDistance(float value)
		{
			base.SetTerrainDetailObjectDistance(value);
			if (!(_terrain == null))
			{
				_terrain.detailObjectDistance = value;
			}
		}

		internal override void SetTerrainTreeDistance(float value)
		{
			base.SetTerrainTreeDistance(value);
			if (!(_terrain == null))
			{
				_terrain.treeDistance = value;
			}
		}

		protected override RenderTexture LoadHeightmapTexture()
		{
			return _terrain.terrainData.heightmapTexture;
		}

		protected override void LoadDetailDensityTextures(bool forceUpdate = false)
		{
			if (_terrain == null || _terrain.terrainData == null)
			{
				return;
			}
			int num = _terrain.terrainData.detailPrototypes.Length;
			if (forceUpdate || num == 0 || !Application.isPlaying)
			{
				DisposeDetailDensityTextures();
			}
			if (num == 0)
			{
				return;
			}
			_detailScatterMode = _terrain.terrainData.detailScatterMode;
			int detailResolution = _terrain.terrainData.detailResolution;
			ResizeDetailDensityTexturesArray(num);
			if (_isBakedDetailTextures)
			{
				if (_bakedDetailTextures == null)
				{
					_bakedDetailTextures = new Texture2D[num];
				}
				else if (_bakedDetailTextures.Length != num)
				{
					Array.Resize(ref _bakedDetailTextures, num);
				}
			}
			for (int i = 0; i < num; i++)
			{
				RenderTexture renderTexture = _detailDensityTextures[i];
				if (renderTexture != null)
				{
					if (_isBakedDetailTextures && _isCustomBakedDetailTextures)
					{
						Graphics.Blit(_bakedDetailTextures[i], renderTexture);
					}
					continue;
				}
				renderTexture = GPUITerrainUtility.CreateDetailRenderTexture(detailResolution, _terrain.terrainData.name + "_GPUIDL" + i);
				_detailDensityTextures[i] = renderTexture;
				if (_isBakedDetailTextures && _isCustomBakedDetailTextures)
				{
					Graphics.Blit(_bakedDetailTextures[i], renderTexture);
				}
				else
				{
					CaptureTerrainDetailsToRenderTexture(renderTexture, i);
				}
			}
			if (base.DetailManager != null)
			{
				base.DetailManager.RequireUpdate();
			}
		}

		private void CaptureTerrainDetailsToRenderTexture(RenderTexture rt, int detailLayer)
		{
			if (!_isBakedDetailTextures || !_isCustomBakedDetailTextures)
			{
				GPUITerrainUtility.CaptureTerrainDetailToRenderTexture(_terrain, detailLayer, rt, terrainHolesSampleMode == GPUITerrainHolesSampleMode.Initialization);
			}
		}

		public void SetDetailLayer(int layer, int[,] details)
		{
			int num = _terrain.terrainData.detailPrototypes.Length;
			if (layer < num)
			{
				ResizeDetailDensityTexturesArray(num);
				int detailResolution = _terrain.terrainData.detailResolution;
				if (_detailDensityTextures[layer] == null)
				{
					_detailDensityTextures[layer] = GPUITerrainUtility.CreateDetailRenderTexture(detailResolution, _terrain.terrainData.name + "_GPUIDL" + layer);
				}
				GPUITerrainUtility.CaptureTerrainDetailToRenderTexture(_terrain, detailResolution, details, _detailDensityTextures[layer], terrainHolesSampleMode == GPUITerrainHolesSampleMode.Initialization);
				base.IsDetailDensityTexturesLoaded = true;
			}
		}

		public override void RemoveTreePrototypeAtIndex(int index)
		{
			base.RemoveTreePrototypeAtIndex(index);
			int terrainTreePrototypeIndex = GetTerrainTreePrototypeIndex(index);
			if (terrainTreePrototypeIndex < 0)
			{
				return;
			}
			List<TreePrototype> list = new List<TreePrototype>(_terrain.terrainData.treePrototypes);
			TreeInstance[] array = _terrain.terrainData.treeInstances;
			for (int i = 0; i < array.Length; i++)
			{
				TreeInstance treeInstance = array[i];
				if (treeInstance.prototypeIndex >= terrainTreePrototypeIndex)
				{
					if (treeInstance.prototypeIndex == terrainTreePrototypeIndex)
					{
						array = array.RemoveAtAndReturn(i);
						i--;
					}
					else if (treeInstance.prototypeIndex > terrainTreePrototypeIndex)
					{
						array[i].prototypeIndex = treeInstance.prototypeIndex - 1;
					}
				}
			}
			if (list.Count > terrainTreePrototypeIndex)
			{
				list.RemoveAt(terrainTreePrototypeIndex);
			}
			_terrain.terrainData.treeInstances = array;
			_terrain.terrainData.treePrototypes = list.ToArray();
			_terrain.terrainData.RefreshPrototypes();
		}

		public override void RemoveDetailPrototypeAtIndex(int index)
		{
			base.RemoveDetailPrototypeAtIndex(index);
			int terrainDetailPrototypeIndex = GetTerrainDetailPrototypeIndex(index);
			if (terrainDetailPrototypeIndex < 0)
			{
				return;
			}
			DetailPrototype[] detailPrototypes = _terrain.terrainData.detailPrototypes;
			List<DetailPrototype> list = new List<DetailPrototype>();
			List<int[,]> list2 = new List<int[,]>();
			for (int i = 0; i < detailPrototypes.Length; i++)
			{
				if (i != terrainDetailPrototypeIndex)
				{
					list.Add(detailPrototypes[i]);
					list2.Add(_terrain.terrainData.GetDetailLayer(0, 0, _terrain.terrainData.detailResolution, _terrain.terrainData.detailResolution, i));
				}
			}
			_terrain.terrainData.detailPrototypes = list.ToArray();
			for (int j = 0; j < list2.Count; j++)
			{
				_terrain.terrainData.SetDetailLayer(0, 0, j, list2[j]);
			}
			_terrain.terrainData.RefreshPrototypes();
		}

		[ContextMenu("Save Detail Density Changes")]
		public void SaveDetailChangesToTerrainData()
		{
			for (int i = 0; i < GetDetailTextureCount(); i++)
			{
				GPUITerrainUtility.UpdateTerrainDetailWithRenderTexture(_terrain, i, GetDetailDensityTexture(i));
			}
		}

		[ContextMenu("Reset Detail Density Changes")]
		public void ResetDetailChanges()
		{
			CreateDetailTextures();
			if (base.DetailManager != null)
			{
				base.DetailManager.RequireUpdate();
			}
		}

		protected override void LoadTreeInstances()
		{
			if (_terrain != null && _terrain.terrainData != null)
			{
				_treeInstances = _terrain.terrainData.treeInstances;
			}
		}

		public override int GetHeightmapResolution()
		{
			return _terrain.terrainData.heightmapResolution;
		}

		public override Vector3 GetSize()
		{
			return _terrain.terrainData.size;
		}

		public Terrain GetTerrain()
		{
			if (_terrain == null)
			{
				LoadTerrain();
			}
			return _terrain;
		}

		public override float GetTerrainTreeDistance()
		{
			return _terrainTreeDistance;
		}

		public override bool IsBakedDetailTextures()
		{
			return _isBakedDetailTextures;
		}

		public override float GetDetailDensity(int prototypeIndex)
		{
			DetailPrototype detailPrototype = base.DetailPrototypes[prototypeIndex];
			float num = (detailPrototype.useDensityScaling ? _terrain.detailObjectDensity : 1f);
			if (_detailScatterMode == DetailScatterMode.CoverageMode)
			{
				int detailResolution = _terrain.terrainData.detailResolution;
				Vector3 size = GetSize();
				float num2 = size.x / (float)detailResolution * (size.z / (float)detailResolution);
				Bounds prototypeBounds = base.DetailManager.GetPrototypeBounds(base.DetailPrototypeIndexes[prototypeIndex] % 1000);
				float x = math.max(math.max(prototypeBounds.size.x, prototypeBounds.size.z), 1f);
				return num * num2 * math.pow(detailPrototype.density, 2f) / (math.pow(detailPrototype.maxWidth, 2f) * math.pow(x, 3f));
			}
			return num * 255f;
		}

		public override Color GetWavingGrassTint()
		{
			if (_terrain == null || _terrain.terrainData == null)
			{
				return base.GetWavingGrassTint();
			}
			return _terrain.terrainData.wavingGrassTint;
		}

		public override void AddTreePrototypeToTerrain(GameObject pickerGameObject, int overwriteIndex)
		{
			base.AddTreePrototypeToTerrain(pickerGameObject, overwriteIndex);
			TreePrototype[] treePrototypes = _terrain.terrainData.treePrototypes;
			if (overwriteIndex >= 0)
			{
				int terrainTreePrototypeIndex = GetTerrainTreePrototypeIndex(overwriteIndex);
				if (terrainTreePrototypeIndex >= 0 && terrainTreePrototypeIndex < treePrototypes.Length)
				{
					treePrototypes[terrainTreePrototypeIndex].prefab = pickerGameObject;
					_terrain.terrainData.treePrototypes = treePrototypes;
					_terrain.terrainData.RefreshPrototypes();
					return;
				}
			}
			else
			{
				List<TreePrototype> list = new List<TreePrototype>(treePrototypes);
				list.Add(new TreePrototype
				{
					prefab = pickerGameObject
				});
				_terrain.terrainData.treePrototypes = list.ToArray();
				_terrain.terrainData.RefreshPrototypes();
			}
			DetermineTreePrototypeIndexes(base.TreeManager);
		}

		public override void AddDetailPrototypeToTerrain(UnityEngine.Object pickerObject, int overwriteIndex)
		{
			base.AddDetailPrototypeToTerrain(pickerObject, overwriteIndex);
			DetailPrototype[] detailPrototypes = _terrain.terrainData.detailPrototypes;
			if (pickerObject is Texture2D)
			{
				if (overwriteIndex >= 0)
				{
					int terrainDetailPrototypeIndex = GetTerrainDetailPrototypeIndex(overwriteIndex);
					if (terrainDetailPrototypeIndex >= 0 && terrainDetailPrototypeIndex < detailPrototypes.Length)
					{
						detailPrototypes[terrainDetailPrototypeIndex].prototype = null;
						detailPrototypes[terrainDetailPrototypeIndex].prototypeTexture = (Texture2D)pickerObject;
						detailPrototypes[terrainDetailPrototypeIndex].renderMode = DetailRenderMode.GrassBillboard;
						detailPrototypes[terrainDetailPrototypeIndex].usePrototypeMesh = false;
						_terrain.terrainData.detailPrototypes = detailPrototypes;
						_terrain.terrainData.RefreshPrototypes();
					}
				}
				else
				{
					List<DetailPrototype> list = new List<DetailPrototype>(detailPrototypes);
					list.Add(new DetailPrototype
					{
						usePrototypeMesh = false,
						prototypeTexture = (Texture2D)pickerObject,
						renderMode = DetailRenderMode.GrassBillboard,
						noiseSeed = UnityEngine.Random.Range(100, 100000)
					});
					_terrain.terrainData.detailPrototypes = list.ToArray();
					_terrain.terrainData.RefreshPrototypes();
				}
			}
			else if (pickerObject is GameObject gameObject)
			{
				if (gameObject.GetComponentInChildren<MeshRenderer>() == null)
				{
					return;
				}
				if (overwriteIndex >= 0)
				{
					int terrainDetailPrototypeIndex2 = GetTerrainDetailPrototypeIndex(overwriteIndex);
					if (terrainDetailPrototypeIndex2 >= 0 && terrainDetailPrototypeIndex2 < detailPrototypes.Length)
					{
						detailPrototypes[terrainDetailPrototypeIndex2].prototype = gameObject;
						detailPrototypes[terrainDetailPrototypeIndex2].prototypeTexture = null;
						detailPrototypes[terrainDetailPrototypeIndex2].renderMode = DetailRenderMode.VertexLit;
						detailPrototypes[terrainDetailPrototypeIndex2].usePrototypeMesh = true;
						_terrain.terrainData.detailPrototypes = detailPrototypes;
						_terrain.terrainData.RefreshPrototypes();
					}
				}
				else
				{
					List<DetailPrototype> list2 = new List<DetailPrototype>(detailPrototypes);
					list2.Add(new DetailPrototype
					{
						usePrototypeMesh = true,
						prototype = gameObject.GetComponentInChildren<MeshRenderer>().gameObject,
						renderMode = DetailRenderMode.VertexLit,
						noiseSeed = UnityEngine.Random.Range(100, 100000),
						healthyColor = Color.white,
						dryColor = Color.white,
						useInstancing = true
					});
					_terrain.terrainData.detailPrototypes = list2.ToArray();
					_terrain.terrainData.RefreshPrototypes();
				}
			}
			DetermineDetailPrototypeIndexes(base.DetailManager);
		}

		public override void SetBakedDetailTexture(int index, Texture2D texture)
		{
			base.SetBakedDetailTexture(index, texture);
			_isBakedDetailTextures = true;
			_isCustomBakedDetailTextures = true;
		}

		protected override int GetDetailResolution()
		{
			return _terrain.terrainData.detailResolution;
		}

		public override Texture GetHolesTexture()
		{
			return _terrain.terrainData.holesTexture;
		}
	}
}
