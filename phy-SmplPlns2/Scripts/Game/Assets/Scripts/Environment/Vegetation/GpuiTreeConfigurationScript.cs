using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Settings;
using GPUInstancerPro;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Environment.Vegetation
{
	public class GpuiTreeConfigurationScript : GpuiConfigurationScript
	{
		private GPUIProfile _activeProfile;

		[SerializeField]
		private GameObject _terrainRoot;

		private Setting<EnvironmentQualitySettings.TreeDensityQualityLevel> _treeDensity;

		private Setting<float> _treeDistanceSetting;

		private BoolSetting _treeShadowsSetting;

		public void SetTreeDistance(float treeDistance)
		{
			_activeProfile.minMaxDistance = new Vector2(0f, treeDistance);
			_activeProfile.customShadowDistance = treeDistance;
			_activeProfile.SetParameterBufferData();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_treeDensity.Changed -= OnTreeDensityChanged;
			_treeShadowsSetting.Changed -= OnTreeShadowsChanged;
			_treeDistanceSetting.Changed -= OnTreeDistanceChanged;
			if (FlightSceneScript.Instance?.CameraScript != null)
			{
				FlightSceneScript.Instance.CameraScript.FovChanged -= OnFovChanged;
			}
		}

		protected override void Start()
		{
			base.Start();
			_activeProfile = UnityEngine.Object.Instantiate(base.TreeManager.defaultProfile);
			int prototypeCount = base.TreeManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				base.TreeManager.GetPrototype(i).profile = _activeProfile;
			}
			base.TreeManager.Initialize();
			UnityEngine.Terrain[] componentsInChildren = _terrainRoot.GetComponentsInChildren<UnityEngine.Terrain>();
			foreach (UnityEngine.Terrain obj in componentsInChildren)
			{
				obj.drawTreesAndFoliage = false;
				obj.treeDistance = 0f;
			}
			IGameQualitySettings quality = Game.Instance.Settings.Quality;
			_treeDistanceSetting = quality.Environment.TreeDistance;
			_treeShadowsSetting = quality.Shadow.TreeShadows;
			_treeDensity = quality.Environment.TreeDensity;
			_treeDistanceSetting.Changed += OnTreeDistanceChanged;
			_treeShadowsSetting.Changed += OnTreeShadowsChanged;
			_treeDensity.Changed += OnTreeDensityChanged;
			SetTreeDistance(_treeDistanceSetting.Value);
			ApplyTreeShadowSettings();
			ApplyTreeDensity(_treeDensity.Value);
			FlightSceneScript.Instance.CameraScript.FovChanged += OnFovChanged;
			OnFovChanged(this, EventArgs.Empty);
		}

		private void ApplyTreeDensity(EnvironmentQualitySettings.TreeDensityQualityLevel value)
		{
			base.TreeManager.enabled = value != EnvironmentQualitySettings.TreeDensityQualityLevel.Off;
			TerrainVegetationScript[] componentsInChildren = _terrainRoot.GetComponentsInChildren<TerrainVegetationScript>();
			foreach (TerrainVegetationScript terrainVegetationScript in componentsInChildren)
			{
				TreeInstance[] treeInstancesOriginal = terrainVegetationScript.TreeInstancesOriginal;
				switch (value)
				{
				case EnvironmentQualitySettings.TreeDensityQualityLevel.High:
					terrainVegetationScript.TreeInstances = treeInstancesOriginal;
					break;
				case EnvironmentQualitySettings.TreeDensityQualityLevel.Medium:
					terrainVegetationScript.TreeInstances = ReduceTreeDensity(treeInstancesOriginal, 0.5f);
					break;
				case EnvironmentQualitySettings.TreeDensityQualityLevel.Low:
					terrainVegetationScript.TreeInstances = ReduceTreeDensity(treeInstancesOriginal, 0.9f);
					break;
				case EnvironmentQualitySettings.TreeDensityQualityLevel.Off:
					terrainVegetationScript.TreeInstances = new TreeInstance[0];
					break;
				}
			}
		}

		private void ApplyTreeShadowSettings()
		{
			_activeProfile.isShadowCasting = _treeShadowsSetting.Value;
			_activeProfile.SetParameterBufferData();
		}

		private void OnFovChanged(object sender, EventArgs e)
		{
		}

		private void OnTreeDensityChanged(object sender, SettingChangedEventArgs<EnvironmentQualitySettings.TreeDensityQualityLevel> e)
		{
			ApplyTreeDensity(_treeDensity.Value);
		}

		private void OnTreeDistanceChanged(object sender, SettingChangedEventArgs<float> e)
		{
			SetTreeDistance(e.Setting.Value);
		}

		private void OnTreeShadowsChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			ApplyTreeShadowSettings();
		}

		private TreeInstance[] ReduceTreeDensity(TreeInstance[] trees, float removalFactor)
		{
			List<TreeInstance> list = new List<TreeInstance>();
			System.Random random = new System.Random(2025);
			for (int i = 0; i < trees.Length; i++)
			{
				if (random.NextDouble() > (double)removalFactor)
				{
					list.Add(trees[i]);
				}
			}
			return list.ToArray();
		}
	}
}
