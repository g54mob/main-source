using System.Collections.Generic;
using Pug.Conversion;
using Unity.Entities;

public class SupportConditionsConverter : SingleAuthoringComponentConverter<SupportsConditionsAuthoring>
{
	private ConditionsTable _cachedConditionsTable;

	private List<ConditionData> _cachedConditionData = new List<ConditionData>();

	private ConditionsTable ConditionsTable
	{
		get
		{
			if (_cachedConditionsTable == null)
			{
				_cachedConditionsTable = ConditionsTable.GetTable();
			}
			return _cachedConditionsTable;
		}
	}

	protected override void Convert(SupportsConditionsAuthoring authoring)
	{
		List<ConditionData> initialConditions = authoring.initialConditions;
		List<SupportsConditionsAuthoring.ConditionWithRandomChance> initialConditionsWithRandomChance = authoring.initialConditionsWithRandomChance;
		if (TryGetActiveComponent<AreaLevelAuthoring>(authoring, out var component))
		{
			uint rngSeed = 1u;
			ObjectAuthoring component3;
			if (TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out var component2))
			{
				rngSeed = (uint)(component2.objectInfo.objectID + 1);
			}
			else if (TryGetActiveComponent<ObjectAuthoring>(authoring, out component3))
			{
				rngSeed = (uint)component3.objectName.GetHashCode();
			}
			EnemyAuthoring component4;
			bool isEnemy = TryGetActiveComponent<EnemyAuthoring>(authoring, out component4);
			ConditionExtensions.LevelToConditionValues(initialConditions, component.level, rngSeed, isHeldInHand: false, isArmor: false, isEnemy, ConditionsTable);
			_cachedConditionData.Clear();
			for (int i = 0; i < initialConditionsWithRandomChance.Count; i++)
			{
				_cachedConditionData.Add(initialConditionsWithRandomChance[i].conditionData);
			}
			ConditionExtensions.LevelToConditionValues(_cachedConditionData, component.level, rngSeed, isHeldInHand: false, isArmor: false, isEnemy, ConditionsTable);
			for (int j = 0; j < initialConditionsWithRandomChance.Count; j++)
			{
				initialConditionsWithRandomChance[j].conditionData = _cachedConditionData[j];
			}
		}
		EnsureHasBuffer<ConditionsBuffer>();
		foreach (ConditionData item in initialConditions)
		{
			AddToBuffer(new ConditionsBuffer
			{
				condition = new Condition
				{
					conditionData = item
				}
			});
		}
		if (initialConditionsWithRandomChance.Count > 0)
		{
			Entity entity = CreateAdditionalEntity();
			AddComponentData(entity, new InitializeRandomConditionsCD
			{
				EntityToInitialize = base.PrimaryEntity
			});
			AddComponentData(new InitialRandomConditionsCD
			{
				initialConditions = CreateAndAddSimpleBlobArrayAsset(initialConditionsWithRandomChance, (SupportsConditionsAuthoring.ConditionWithRandomChance conditionWithChance) => new InitialRandomConditionData
				{
					chance = conditionWithChance.chance,
					condition = conditionWithChance.conditionData
				})
			});
		}
		EnsureHasBuffer<ConditionTickTimerBuffer>();
		EnsureHasBuffer<SummarizedConditionEffectsBuffer>();
		for (int num = 0; num < 143; num++)
		{
			AddToBuffer(new SummarizedConditionEffectsBuffer
			{
				value = 0
			});
		}
		EnsureHasBuffer<SummarizedConditionsBuffer>();
		for (int num2 = 0; num2 < 357; num2++)
		{
			AddToBuffer(new SummarizedConditionsBuffer
			{
				value = 0
			});
		}
		EnsureHasBuffer<NewConditionsBuffer>();
		EnsureHasBuffer<RemoveConditionsBuffer>();
		if (!authoring.cantBeAffectedByHealing)
		{
			EnsureHasComponent<IsBeingBeHealedByOtherEntitiesCD>();
			EnsureHasBuffer<IsBeingBeHealedByOtherEntitiesBuffer>();
		}
		if (!authoring.cantBeAffectedByEnvironment)
		{
			EnsureHasComponent<BurningConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<RadioActiveConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<AffectedByAcidConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<AffectedBySlipperyMovementConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<InfectedWithMoldConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<VoidDamageConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<HasAuraConditionCD>(componentIsEnabled: false);
			EnsureHasComponent<AmassThenReciprocateCD>();
		}
		if (!authoring.cantBeAffectedByAuras)
		{
			EnsureHasBuffer<IsAffectedByAurasFromEntitiesBuffer>();
		}
		if (authoring.dontShowStatsTextOnItem)
		{
			EnsureHasComponent<DontShowConditionsStatTextOnItemCD>();
		}
	}
}
