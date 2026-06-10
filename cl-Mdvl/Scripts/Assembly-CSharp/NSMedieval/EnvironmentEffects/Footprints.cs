using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Layers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model.MapNew;
using NSMedieval.Scripts.Pooler;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class Footprints : MonoSingleton<Footprints>
	{
		private const float WetnessThreshold = 0.5f;

		public List<GameObject> liveFootprints = new List<GameObject>();

		public event Action<GameObject> OnParticleFinishedEvent;

		public void Footprint(AnimatedAgentView agent, string side, Transform parent)
		{
			if (agent == null || parent == null || parent.transform.position.y >= MonoSingleton<World>.Instance.LayerLevel * (float)World.MapBlockHeight)
			{
				return;
			}
			CreatureBase asCreature = agent.GetAsCreature();
			if (CombatUtils.IsNullOrDisposed(asCreature) || asCreature?.Map == null)
			{
				return;
			}
			MapNode node = asCreature.GetNode();
			VoxelType voxelType = node?.GetNodeBelow()?.VoxelType;
			if (voxelType == null || node.DataType == GridDataType.Slope)
			{
				return;
			}
			SoundWalkableMaterialCategory soundCategory = GetSoundCategory(node, voxelType);
			if (soundCategory == SoundWalkableMaterialCategory.None)
			{
				return;
			}
			int num = -1;
			List<FootprintType> agentFootprints = agent.AgentFootprints;
			int i = 0;
			for (int count = agentFootprints.Count; i < count; i++)
			{
				if (agentFootprints[i].Category == soundCategory)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return;
			}
			string id = ((side == "left") ? agent.AgentFootprints[num].Left : agent.AgentFootprints[num].Right);
			GameObject gameObject = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(id, parent, autoStop: true, useUnscaledTime: false, this.OnParticleFinishedEvent);
			if (!(gameObject == null))
			{
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					gameObject.transform.GetChild(j).transform.localScale = agent.transform.localScale;
				}
				liveFootprints.Add(gameObject);
				gameObject.transform.rotation = Quaternion.Euler(0f, agent.transform.localEulerAngles.y, 0f);
				Vector3 position = parent.transform.position;
				gameObject.transform.position = new Vector3(position.x, Mathf.Floor(position.y), position.z);
				gameObject.transform.SetParent(MonoSingleton<ParticleSystemPool>.Instance.transform);
				if (agent.Animator.GetBool("Running"))
				{
					string id2 = ((GetWetnessValue(node) > 0.5f) ? agent.AgentFootprints[num].Wet : agent.AgentFootprints[num].TrailDust);
					MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(id2, parent.position);
				}
			}
		}

		private SoundWalkableMaterialCategory GetSoundCategory(MapNode mapNode, VoxelType voxelType)
		{
			if (GetWaterLevel(mapNode) == WaterDepthLevel.Low)
			{
				return SoundWalkableMaterialCategory.ShallowWater;
			}
			if (GetSnowValue(mapNode) >= 0.01f)
			{
				return SoundWalkableMaterialCategory.Snow;
			}
			if (GetGrassValue(mapNode) >= 0.01f)
			{
				return SoundWalkableMaterialCategory.Grass;
			}
			if (mapNode.GetWorldObject(GridDataType.PlantMapResource) is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint.WalkableMaterialCategory != SoundWalkableMaterialCategory.None)
			{
				return plantMapResourceInstance.Blueprint.WalkableMaterialCategory;
			}
			if (mapNode.GetWorldObject(GridDataType.BuildingFinished) is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.Blueprint.WalkableMaterialCategory != SoundWalkableMaterialCategory.None)
			{
				return baseBuildingInstance.Blueprint.WalkableMaterialCategory;
			}
			return voxelType.SoundWalkableMaterialCategory;
		}

		private float GetSnowValue(MapNode mapNode)
		{
			SnowGrassWetnessManager snowGrassWetnessManager = mapNode.Map.SnowGrassWetnessManager;
			if (snowGrassWetnessManager != null)
			{
				return (float)(int)snowGrassWetnessManager.GetSnow(mapNode.Index) / 255f;
			}
			return 0f;
		}

		private float GetWetnessValue(MapNode mapNode)
		{
			SnowGrassWetnessManager snowGrassWetnessManager = mapNode.Map.SnowGrassWetnessManager;
			if (snowGrassWetnessManager != null)
			{
				return (float)(int)snowGrassWetnessManager.GetWetness(mapNode.Index) / 255f;
			}
			return 0f;
		}

		private float GetGrassValue(MapNode mapNode)
		{
			SnowGrassWetnessManager snowGrassWetnessManager = VillageManager.ActiveVillage.Map.SnowGrassWetnessManager;
			if (snowGrassWetnessManager != null)
			{
				return snowGrassWetnessManager.GetGrassHealth(mapNode.Index);
			}
			return 0f;
		}

		private WaterDepthLevel GetWaterLevel(MapNode mapNode)
		{
			return VillageManager.ActiveVillage.Map.WaterManager?.GetWaterDepthLevel(mapNode.Index) ?? ((WaterDepthLevel)0);
		}

		private void Start()
		{
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += HideFootprints;
			OnParticleFinishedEvent += RemoveFromLive;
		}

		private void HideFootprints(float currentElevation)
		{
			for (int num = liveFootprints.Count - 1; num >= 0; num--)
			{
				if (num < liveFootprints.Count)
				{
					GameObject gameObject = liveFootprints[num];
					if (!(gameObject.transform.position.y < currentElevation * (float)World.MapBlockHeight))
					{
						gameObject.SetActive(value: false);
					}
				}
			}
		}

		private void RemoveFromLive(GameObject ps)
		{
			liveFootprints.Remove(ps);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<LayerHidingManager>.IsInstantiated())
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= HideFootprints;
			}
			this.OnParticleFinishedEvent = null;
			base.OnDestroy();
		}
	}
}
