using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Terrain))]
	[DefaultExecutionOrder(-200)]
	[DisallowMultipleComponent]
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
			if (_terrain == null)
			{
				_terrain = GetComponent<Terrain>();
			}
			base.LoadTerrain();
		}

		public override bool LoadTerrainData()
		{
			if (!base.LoadTerrainData())
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find TerrainData for terrain: " + _terrain.name, base.gameObject);
				return false;
			}
			if (_terrain.terrainData != null)
			{
				_treePrototypes = _terrain.terrainData.treePrototypes;
				DetermineTreePrototypeIndexes(base.TreeManager);
				_detailPrototypes = _terrain.terrainData.detailPrototypes;
				DetermineDetailPrototypeIndexes(base.DetailManager);
				_detailScatterMode = _terrain.terrainData.detailScatterMode;
				if (_terrain.treeDistance > 0f)
				{
					_terrainTreeDistance = _terrain.treeDistance;
				}
				return true;
			}
			return false;
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
			if (_terrain == null || _terrain.terrainData == null)
			{
				return null;
			}
			return _terrain.terrainData.heightmapTexture;
		}

		protected override void LoadDetailDensityTextures()
		{
			if (_terrain == null || _terrain.terrainData == null)
			{
				return;
			}
			_detailPrototypes = _terrain.terrainData.detailPrototypes;
			DetermineDetailPrototypeIndexes(base.DetailManager);
			int num = ((base.DetailPrototypes != null) ? base.DetailPrototypes.Length : 0);
			ResizeDetailDensityTextureArray(num);
			if (num == 0)
			{
				return;
			}
			_detailScatterMode = _terrain.terrainData.detailScatterMode;
			string terrainName = _terrain.terrainData.name;
			for (int i = 0; i < num; i++)
			{
				CreateDetailTexture(terrainName, i);
				if (!IsReadTerrainDetails(i))
				{
					_detailDensityTextures[i].ClearRenderTexture();
				}
				else if (_isBakedDetailTextures && (_isCustomBakedDetailTextures || Application.isPlaying))
				{
					BlitBakedDetailTexture(i);
				}
				else
				{
					CaptureTerrainDetailsToRenderTexture(_detailDensityTextures[i], i);
				}
			}
			ExecuteProceduralDetails();
			if (base.DetailManager != null)
			{
				base.DetailManager.RequireUpdate(!Application.isPlaying);
			}
		}

		private void CaptureTerrainDetailsToRenderTexture(RenderTexture rt, int detailLayer, bool captureWithComputeDetailInstanceTransforms = false)
		{
			if (captureWithComputeDetailInstanceTransforms)
			{
				GPUITerrainUtility.CaptureTerrainDetailToRenderTextureWithComputeDetailInstanceTransforms(_terrain.terrainData, detailLayer, (base.DetailPrototypes[detailLayer].useDensityScaling ? _terrain.detailObjectDensity : 1f) * base.DetailPrototypes[detailLayer].density, rt, terrainHolesSampleMode == GPUITerrainHolesSampleMode.Initialization);
			}
			else
			{
				GPUITerrainUtility.CaptureTerrainDetailToRenderTexture(_terrain.terrainData, detailLayer, rt, terrainHolesSampleMode == GPUITerrainHolesSampleMode.Initialization);
			}
		}

		public void SetDetailLayer(int layer, int[,] details)
		{
			int num = _terrain.terrainData.detailPrototypes.Length;
			if (layer < num)
			{
				ResizeDetailDensityTextureArray(num);
				int detailResolution = _terrain.terrainData.detailResolution;
				CreateDetailTexture(_terrain.terrainData.name, layer);
				GPUITerrainUtility.CaptureTerrainDetailToRenderTexture(_terrain.terrainData, detailResolution, details, _detailDensityTextures[layer], terrainHolesSampleMode == GPUITerrainHolesSampleMode.Initialization);
				base.IsDetailDensityTexturesLoaded = true;
			}
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
				if (base.TreeManager != null)
				{
					ConvertToGPUITreeData(base.TreeManager);
				}
			}
		}

		public override void AddTreePrototypeToTerrain(GameObject pickerGameObject, int overwriteIndex)
		{
			base.AddTreePrototypeToTerrain(pickerGameObject, overwriteIndex);
			_terrain.terrainData.treePrototypes = _treePrototypes;
			_terrain.terrainData.RefreshPrototypes();
		}

		public override void AddDetailPrototypeToTerrain(UnityEngine.Object pickerObject, int overwriteIndex)
		{
			base.AddDetailPrototypeToTerrain(pickerObject, overwriteIndex);
			_terrain.terrainData.detailPrototypes = _detailPrototypes;
			_terrain.terrainData.RefreshPrototypes();
		}

		protected override void OnRemoveTreePrototypesAtIndexes(List<int> terrainPrototypeIndexes)
		{
			_terrain.terrainData.treeInstances = _treeInstances;
			_terrain.terrainData.treePrototypes = _treePrototypes;
			_terrain.terrainData.RefreshPrototypes();
		}

		protected override void OnRemoveDetailPrototypesAtIndexes(List<int> terrainPrototypeIndexes)
		{
			if (terrainPrototypeIndexes.Count == 0)
			{
				return;
			}
			DetailPrototype[] detailPrototypes = _terrain.terrainData.detailPrototypes;
			List<int[,]> list = new List<int[,]>();
			for (int i = 0; i < detailPrototypes.Length; i++)
			{
				if (!terrainPrototypeIndexes.Contains(i))
				{
					list.Add(_terrain.terrainData.GetDetailLayer(0, 0, _terrain.terrainData.detailResolution, _terrain.terrainData.detailResolution, i));
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				_terrain.terrainData.SetDetailLayer(0, 0, j, list[j]);
			}
			_terrain.terrainData.detailPrototypes = _detailPrototypes;
			_terrain.terrainData.RefreshPrototypes();
		}

		public override int GetHeightmapResolution()
		{
			return _terrain.terrainData.heightmapResolution;
		}

		public override bool SetTerrainBounds(bool forceNew = false)
		{
			if (_terrain == null || _terrain.terrainData == null)
			{
				return false;
			}
			Vector3 size = _terrain.terrainData.size;
			Bounds bounds = new Bounds(size / 2f, size);
			if (forceNew || _bounds != bounds)
			{
				_bounds = bounds;
				return true;
			}
			return false;
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
			float num = (base.DetailPrototypes[prototypeIndex].useDensityScaling ? _terrain.detailObjectDensity : 1f);
			if (_detailScatterMode == DetailScatterMode.CoverageMode)
			{
				num *= _terrain.terrainData.ComputeDetailCoverage(prototypeIndex);
				int detailResolution = _terrain.terrainData.detailResolution;
				Vector3 size = GetSize();
				float num2 = math.sqrt(size.x / (float)detailResolution * (size.z / (float)detailResolution));
				return num * num2;
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

		public override void SetBakedDetailTexture(int index, Texture2D texture)
		{
			base.SetBakedDetailTexture(index, texture);
			_isBakedDetailTextures = true;
			_isCustomBakedDetailTextures = true;
		}

		public override void SetTreeInstances(TreeInstance[] treeInstances, bool applyToTerrainData = false)
		{
			base.SetTreeInstances(treeInstances, applyToTerrainData);
			if (applyToTerrainData)
			{
				TerrainCollider component = _terrain.GetComponent<TerrainCollider>();
				if (component != null)
				{
					component.enabled = false;
				}
				_terrain.terrainData.treeInstances = treeInstances;
				if (component != null)
				{
					component.enabled = true;
				}
			}
		}

		protected override int GetDetailResolution()
		{
			return _terrain.terrainData.detailResolution;
		}

		public override Texture GetHolesTexture()
		{
			return _terrain.terrainData.holesTexture;
		}

		public override int GetAlphamapTextureCount()
		{
			return _terrain.terrainData.alphamapTextureCount;
		}

		public override Texture2D[] GetAlphamapTextures()
		{
			return _terrain.terrainData.alphamapTextures;
		}

		public override TerrainLayer[] GetTerrainLayers()
		{
			return _terrain.terrainData.terrainLayers;
		}
	}
}
