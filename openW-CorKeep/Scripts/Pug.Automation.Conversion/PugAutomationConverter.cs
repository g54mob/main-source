using System.Collections.Generic;
using Pug.Automation;
using Pug.Conversion;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PugAutomationConverter : Converter
{
	private List<AutomatedMoverAuthoring.AffectedPositions> _cachedAffectedPositionsList = new List<AutomatedMoverAuthoring.AffectedPositions>();

	public override void Convert(GameObject authoring)
	{
		AutomationType automationType = AutomationType.None;
		if (TryGetActiveComponent<AffectedByAutomationAuthoring>(authoring, out var _))
		{
			AddComponentData(new MoveeBigEntityCD
			{
				moveTimer = -1
			});
			automationType |= AutomationType.Movee;
		}
		if (TryGetActiveComponent<AutomatedCrafterAuthoring>(authoring, out var _))
		{
			CraftingAuthoring component3 = authoring.GetComponent<CraftingAuthoring>();
			automationType |= AutomationType.Crafter;
			int num = 0;
			if (TryGetActiveComponent<InventoryAuthoring>(authoring, out var component4))
			{
				num = component4.sizeX * component4.sizeY;
			}
			if (component3.allInventoryIsForSingleCraft)
			{
				num = 1;
			}
			if (CraftingCD.DoesCraftingConsumeEntityAmount(component3.craftingType))
			{
				num = 1;
			}
			EnsureHasBuffer<CraftingTimerSlotBuffer>();
			for (int i = 0; i < num; i++)
			{
				AddToBuffer(default(CraftingTimerSlotBuffer));
			}
			if (CraftingCD.IsRecipeCrafter(component3.craftingType))
			{
				EnsureHasBuffer<CraftingByRecipeSlotBuffer>();
				for (int j = 0; j < num; j++)
				{
					AddToBuffer(new CraftingByRecipeSlotBuffer
					{
						currentlyCraftingIndex = -1
					});
				}
			}
			else
			{
				EnsureHasBuffer<CraftingByConsumedObjectSlotBuffer>();
				for (int k = 0; k < num; k++)
				{
					AddToBuffer(new CraftingByConsumedObjectSlotBuffer
					{
						previousConsumedItem = default(ContainedObjectsBuffer)
					});
				}
			}
		}
		if (TryGetActiveComponent<AutomatedMineableAuthoring>(authoring, out var component5))
		{
			automationType |= AutomationType.Mineable;
			if (component5.damageDecreaseFactor != 0f)
			{
				AddComponentData(new MineableDamageDecreaseCD
				{
					damageFactor = 1f,
					damageDecreaseFactor = component5.damageDecreaseFactor,
					damageDecreaseExp = component5.damageDecreaseExponential
				});
			}
		}
		if (TryGetActiveComponent<AutomatedMinerAuthoring>(authoring, out var component6))
		{
			automationType |= AutomationType.Miner;
			AddComponentData(new PugAutomationMinerConfigCD
			{
				offset = component6.damagePositions[0],
				damage = component6.damage,
				cooldown = (int)math.ceil(component6.cooldownTime * (float)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate)
			});
		}
		if (TryGetActiveComponent<AutomatedMoverSharedAuthoring>(authoring, out var component7))
		{
			automationType |= AutomationType.Mover;
			PugAutomationMoversSharedConfigData data = new PugAutomationMoversSharedConfigData
			{
				moveTime = (int)math.ceil(component7.moveTime * (float)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate),
				cooldownTime = (int)math.ceil(component7.cooldownTime * (float)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate),
				allowPickupFromInventories = component7.allowPickupFromInventories,
				pickUp = component7.pickUpDuringMove,
				allowOnlyOneActiveMoverAtATime = component7.allowOnlyOneActiveMoverAtATime,
				enableInRoundRobinAfterActivation = (component7.enabledMovers == AutomatedMoverSharedAuthoring.CyclingType.CycleRoundRobinAfterActivation),
				enableAllMoversAfterActivation = (component7.enabledMovers == AutomatedMoverSharedAuthoring.CyclingType.AllMoversEnabledWhenIdle),
				splitOnMove = component7.splitOnMove
			};
			BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>> defaultMovers = BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>>.Null;
			if (TryGetActiveComponent<AutomatedMoverAuthoring>(authoring, out var component8))
			{
				_cachedAffectedPositionsList.Clear();
				foreach (AutomatedMoverAuthoring.AffectedArea affectedArea in component8.affectedAreas)
				{
					AddArea(affectedArea, _cachedAffectedPositionsList);
				}
				_cachedAffectedPositionsList.AddRange(component8.affectedPositions);
				defaultMovers = CreateAndAddSimpleBlobArrayAsset(_cachedAffectedPositionsList, (AutomatedMoverAuthoring.AffectedPositions x) => new PugAutomationMoverConfigElementData
				{
					moveVector = x.moveVector,
					affectedPosition = x.position
				});
			}
			BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>> harvestAndMovers = BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>>.Null;
			if (TryGetActiveComponent<AutomatedHarvestAndMoverAuthoring>(authoring, out var component9))
			{
				harvestAndMovers = CreateAndAddSimpleBlobArrayAsset(component9.affectedPositions, (AutomatedHarvestAndMoverAuthoring.AffectedPositions x) => new PugAutomationMoverConfigElementData
				{
					moveVector = x.moveVector,
					affectedPosition = x.position
				});
			}
			BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>> moveAndPlanters = BlobAssetReference<BlobArray<PugAutomationMoverConfigElementData>>.Null;
			if (TryGetActiveComponent<AutomatedMoveAndPlanterAuthoring>(authoring, out var component10))
			{
				moveAndPlanters = CreateAndAddSimpleBlobArrayAsset(component10.affectedPositions, (AutomatedMoveAndPlanterAuthoring.AffectedPositions x) => new PugAutomationMoverConfigElementData
				{
					moveVector = x.moveVector,
					affectedPosition = x.position
				});
				AddComponentData(new CategoryFilteringCD
				{
					filterCategory = ObjectCategoryTag.Seed
				});
			}
			if (TryGetActiveComponent<AutomatedApplyFilterForMoversAuthoring>(authoring, out var _))
			{
				EnsureHasComponent<ObjectFilteringCD>();
			}
			AddComponentData(new PugAutomationMoversSharedConfigCD
			{
				SharedConfig = CreateAndAddSimpleBlobAsset(data),
				DefaultMovers = defaultMovers,
				MoveAndPlanters = moveAndPlanters,
				HarvestAndMovers = harvestAndMovers
			});
			int num2 = (defaultMovers.IsCreated ? defaultMovers.Value.Length : 0) + (harvestAndMovers.IsCreated ? harvestAndMovers.Value.Length : 0) + (moveAndPlanters.IsCreated ? moveAndPlanters.Value.Length : 0);
			if (component7.allowOnlyOneActiveMoverAtATime && num2 > 1)
			{
				AddComponentData(new PugAutomationEnabledMoverSyncedCD
				{
					moverIndex = -1
				});
			}
		}
		if (TryGetActiveComponent<AutomatedStorageAuthoring>(authoring, out var _))
		{
			automationType |= AutomationType.Storage;
		}
		if (TryGetActiveComponent<AutomatedHarvestablePlantAuthoring>(authoring, out var _))
		{
			automationType |= AutomationType.HarvestablePlant;
		}
		if (automationType != AutomationType.None)
		{
			AddComponentData(new PugAutomationCD
			{
				type = automationType
			});
		}
	}

	private static void AddArea(AutomatedMoverAuthoring.AffectedArea area, List<AutomatedMoverAuthoring.AffectedPositions> affectedPositions)
	{
		for (int i = 0; i < area.size.y; i++)
		{
			for (int j = 0; j < area.size.x; j++)
			{
				int2 int5 = area.bottomLeft + new int2(j, i);
				affectedPositions.Add(new AutomatedMoverAuthoring.AffectedPositions
				{
					position = int5,
					moveVector = area.moveTo - int5
				});
			}
		}
	}
}
