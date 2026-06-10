using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using UnityEngine;

namespace Effects
{
	public class BlueprintPlaceVisualsManager : MonoSingleton<BlueprintPlaceVisualsManager>
	{
		[SerializeField]
		private float placementSpeed = 0.05f;

		[SerializeField]
		private float startingOffset = 0.5f;

		[SerializeField]
		private float endingOffset = 0.1f;

		[SerializeField]
		private float animationSpeed = 1f;

		private readonly List<BlueprintPlacedEffect> blueprintPlacedEffects = new List<BlueprintPlacedEffect>();

		private readonly List<BlueprintPlacedEffect> liveBlueprintPlacedEffects = new List<BlueprintPlacedEffect>();

		private readonly List<BlueprintPlacedEffect> finished = new List<BlueprintPlacedEffect>();

		private Vec3Int startingPosition;

		private float triggerNextElementTime;

		private int propertyID;

		public void PlaySequence()
		{
			if (MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct || blueprintPlacedEffects.Count <= 0)
			{
				return;
			}
			BlueprintPlacedEffect blueprintPlacedEffect = blueprintPlacedEffects[0];
			if (blueprintPlacedEffect == null)
			{
				blueprintPlacedEffects.Remove(blueprintPlacedEffect);
				triggerNextElementTime = placementSpeed;
				return;
			}
			for (int i = 0; i < blueprintPlacedEffect.BaseBuildingViewComponent.BlueprintMeshRenderers.Count; i++)
			{
				MeshRenderer meshRenderer = blueprintPlacedEffect.BaseBuildingViewComponent.BlueprintMeshRenderers[i];
				if (meshRenderer != null)
				{
					SetProgress(meshRenderer, startingOffset);
					meshRenderer.enabled = true;
				}
			}
			blueprintPlacedEffect.Progress = startingOffset;
			blueprintPlacedEffects.Remove(blueprintPlacedEffect);
			liveBlueprintPlacedEffects.Add(blueprintPlacedEffect);
			triggerNextElementTime = placementSpeed;
		}

		public void AddBlueprintToList(BlueprintPlacedEffect item)
		{
			if (!MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
			{
				blueprintPlacedEffects.Add(item);
			}
		}

		public void StartSetup(Vec3Int start)
		{
			if (!MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
			{
				startingPosition = start;
			}
		}

		public void SortBlueprints(Vec3Int end)
		{
			if (MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
			{
				return;
			}
			for (int num = blueprintPlacedEffects.Count - 1; num >= 0; num--)
			{
				BlueprintPlacedEffect blueprintPlacedEffect = blueprintPlacedEffects[num];
				if (blueprintPlacedEffect == null || blueprintPlacedEffect.BaseBuildingViewComponent == null)
				{
					blueprintPlacedEffects.Remove(blueprintPlacedEffect);
				}
			}
			int num2 = ((end.x - startingPosition.x > 0) ? 1 : (-1));
			int num3 = ((end.z - startingPosition.z > 0) ? 1 : (-1));
			if (num2 > 0)
			{
				blueprintPlacedEffects.Sort((BlueprintPlacedEffect x, BlueprintPlacedEffect y) => x.transform.position.x.CompareTo(y.transform.position.x));
			}
			else
			{
				blueprintPlacedEffects.Sort((BlueprintPlacedEffect x, BlueprintPlacedEffect y) => y.transform.position.x.CompareTo(x.transform.position.x));
			}
			if (num3 > 0)
			{
				blueprintPlacedEffects.Sort((BlueprintPlacedEffect x, BlueprintPlacedEffect y) => x.transform.position.z.CompareTo(y.transform.position.z));
			}
			else
			{
				blueprintPlacedEffects.Sort((BlueprintPlacedEffect x, BlueprintPlacedEffect y) => y.transform.position.z.CompareTo(x.transform.position.z));
			}
			PlaySequence();
		}

		private void SetProgress(MeshRenderer renderer, float progress)
		{
			if (!(renderer == null))
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(renderer);
				materialPropertyBlock.SetFloat(propertyID, progress);
				renderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		private void Update()
		{
			if (MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
			{
				return;
			}
			if (blueprintPlacedEffects.Count > 0)
			{
				triggerNextElementTime -= Time.unscaledDeltaTime;
				if (triggerNextElementTime <= 0f)
				{
					PlaySequence();
				}
			}
			if (liveBlueprintPlacedEffects.Count <= 0)
			{
				return;
			}
			for (int num = liveBlueprintPlacedEffects.Count - 1; num >= 0; num--)
			{
				BlueprintPlacedEffect blueprintPlacedEffect = liveBlueprintPlacedEffects[num];
				if (blueprintPlacedEffect.BaseBuildingViewComponent.HasDisposed || blueprintPlacedEffect.BaseBuildingViewComponent.BaseBuildingInstance == null)
				{
					liveBlueprintPlacedEffects.RemoveAt(num);
				}
				else if (!MonoSingleton<BuildingsPool>.Instance.IsUsed(blueprintPlacedEffect.BaseBuildingViewComponent.BaseBuildingInstance.Blueprint.GetID(), blueprintPlacedEffect.BaseBuildingViewComponent))
				{
					finished.Add(blueprintPlacedEffect);
				}
				else
				{
					blueprintPlacedEffect.Progress -= Time.unscaledDeltaTime * animationSpeed;
					for (int i = 0; i < blueprintPlacedEffect.BaseBuildingViewComponent.BlueprintMeshRenderers.Count; i++)
					{
						SetProgress(blueprintPlacedEffect.BaseBuildingViewComponent.BlueprintMeshRenderers[i], blueprintPlacedEffect.Progress);
					}
					if (!(blueprintPlacedEffect.Progress > endingOffset))
					{
						for (int j = 0; j < blueprintPlacedEffect.BaseBuildingViewComponent.BlueprintMeshRenderers.Count; j++)
						{
							SetProgress(blueprintPlacedEffect.BaseBuildingViewComponent.BlueprintMeshRenderers[j], endingOffset);
							blueprintPlacedEffect.Progress = endingOffset;
						}
						blueprintPlacedEffect.PlacedAnimationFinished();
						finished.Add(blueprintPlacedEffect);
					}
				}
			}
			foreach (BlueprintPlacedEffect item in finished)
			{
				liveBlueprintPlacedEffects.Remove(item);
			}
			finished.Clear();
		}

		private void OnEnable()
		{
			propertyID = Shader.PropertyToID("_animationPlaceOffset");
		}
	}
}
