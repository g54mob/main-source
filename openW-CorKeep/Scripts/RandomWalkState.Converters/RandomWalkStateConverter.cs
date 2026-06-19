using System;
using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public class RandomWalkStateConverter : SingleAuthoringComponentConverter<RandomWalkStateAuthoring>
{
	protected override void Convert(RandomWalkStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<DetectCollisionCD>();
		EnsureHasComponent<RandomWalkStateCD>();
		EnsureHasComponent<DetectCollisionCD>();
		SetProperty("RandomWalk/minWalkDistance", authoring.minWalkDistance);
		SetProperty("RandomWalk/maxWalkDistance", authoring.maxWalkDistance);
		SetProperty("RandomWalk/maxWalkDuration", authoring.maxWalkDuration);
		SetProperty("RandomWalk/minIdleDuration", authoring.minIdleDuration);
		SetProperty("RandomWalk/maxIdleDuration", authoring.maxIdleDuration);
		SetProperty("RandomWalk/movementSpeedMultiplier", authoring.movementSpeedMultiplier);
		AddComponentData(new RandomWalkStatePatternCD
		{
			Value = CreateAndAddWalkStatePatternBlob(authoring)
		});
	}

	private BlobAssetReference<RandomWalkStatePatternBlobData> CreateAndAddWalkStatePatternBlob(RandomWalkStateAuthoring authoring)
	{
		BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		ref RandomWalkStatePatternBlobData root = ref blobBuilder.ConstructRoot<RandomWalkStatePatternBlobData>();
		if (authoring.walkPatternBehaviourDefinition == null)
		{
			CreateDefaultWalkStatePattern(ref blobBuilder, ref root, authoring);
		}
		else
		{
			CreateWalkStatePatternFromDefinitions(ref blobBuilder, ref root, authoring);
		}
		BlobAssetReference<RandomWalkStatePatternBlobData> blobAsset = blobBuilder.CreateBlobAssetReference<RandomWalkStatePatternBlobData>(Allocator.Persistent);
		blobBuilder.Dispose();
		base.BlobAssetStore.TryAdd(ref blobAsset);
		return blobAsset;
	}

	private void CreateDefaultWalkStatePattern(ref BlobBuilder blobBuilder, ref RandomWalkStatePatternBlobData root, RandomWalkStateAuthoring authoring)
	{
		BlobBuilderArray<RandomWalkStatePatternGroupData> blobBuilderArray = blobBuilder.Allocate(ref root.groups, 1);
		blobBuilder.Allocate(ref root.groupRandomWeights, 1)[0] = 1f;
		root.totalGroupWeights = 1f;
		BlobBuilderArray<RandomWalkStatePatterData> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[0].patterns, 1);
		blobBuilder.Allocate(ref blobBuilderArray[0].patternRandomWeights, 1)[0] = 1f;
		blobBuilderArray[0].totalPatternWeights = 1f;
		blobBuilderArray2[0] = new RandomWalkStatePatterData
		{
			cancelConditionType = WalkStateCancelConditionType.All,
			goalPatternType = WalkStateGoalPatternType.Default,
			movementPatternType = WalkStateMovementPatternType.Straight,
			patternSteps = 1,
			minMaxWalkDistance = new float2(authoring.minWalkDistance, authoring.maxWalkDistance),
			maxWalkDuration = authoring.maxWalkDuration,
			goalCheckDistanceSqr = 0.49984902f,
			movementSpeedMultiplier = authoring.movementSpeedMultiplier,
			minMaxIdleDurationAfterWalking = new float2(authoring.minIdleDuration, authoring.maxIdleDuration),
			movementPatternGoalFloatValue = 0f,
			movementPatternFloatValue = 0f,
			movementPatternFloatValue2 = 0f,
			movementPatternGoalIntValue = 0
		};
	}

	private void CreateWalkStatePatternFromDefinitions(ref BlobBuilder blobBuilder, ref RandomWalkStatePatternBlobData root, RandomWalkStateAuthoring authoring)
	{
		root.groupSelectionType = authoring.walkPatternBehaviourDefinition.groupSelectionType;
		BlobBuilderArray<RandomWalkStatePatternGroupData> blobBuilderArray = blobBuilder.Allocate(ref root.groups, authoring.walkPatternBehaviourDefinition.walkPatternGroups.Count);
		BlobBuilderArray<float> blobBuilderArray2 = blobBuilder.Allocate(ref root.groupRandomWeights, authoring.walkPatternBehaviourDefinition.walkPatternGroups.Count);
		float num = 0f;
		for (int i = 0; i < authoring.walkPatternBehaviourDefinition.walkPatternGroups.Count; i++)
		{
			WalkPatternBehaviourDefinition.WalkPatternGroupInSet walkPatternGroupInSet = authoring.walkPatternBehaviourDefinition.walkPatternGroups[i];
			blobBuilderArray[i].patternSelectionType = walkPatternGroupInSet.walkPatternGroup.groupSelectionType;
			float weight = walkPatternGroupInSet.weight;
			blobBuilderArray2[i] = weight;
			num += weight;
			CreateWalkStateGroupDataFromDefinitions(ref blobBuilder, ref blobBuilderArray[i], walkPatternGroupInSet.walkPatternGroup, authoring);
		}
		root.totalGroupWeights = num;
	}

	private void CreateWalkStateGroupDataFromDefinitions(ref BlobBuilder blobBuilder, ref RandomWalkStatePatternGroupData groupBlobData, WalkPatternGroupDefinition groupWalkPatternGroup, RandomWalkStateAuthoring authoring)
	{
		BlobBuilderArray<RandomWalkStatePatterData> blobBuilderArray = blobBuilder.Allocate(ref groupBlobData.patterns, groupWalkPatternGroup.walkPatterns.Count);
		BlobBuilderArray<float> blobBuilderArray2 = blobBuilder.Allocate(ref groupBlobData.patternRandomWeights, groupWalkPatternGroup.walkPatterns.Count);
		float num = 0f;
		for (int i = 0; i < groupWalkPatternGroup.walkPatterns.Count; i++)
		{
			WalkPatternGroupDefinition.WalkPatterInGroup walkPatterInGroup = groupWalkPatternGroup.walkPatterns[i];
			bool flag = walkPatterInGroup.walkPattern.useAuthoringBehaviourValuesForBaseMovementProperties || authoring.overrideUseAuthoringBehaviourValuesForAllPatternBaseMovementProperties;
			blobBuilderArray[i] = new RandomWalkStatePatterData
			{
				cancelConditionType = walkPatterInGroup.walkPattern.cancelConditionType,
				goalPatternType = walkPatterInGroup.walkPattern.goalPatternType,
				movementPatternType = walkPatterInGroup.walkPattern.movementPatternType,
				patternSteps = walkPatterInGroup.walkPattern.patternGoalSteps,
				minMaxWalkDistance = (flag ? new float2(authoring.minWalkDistance, authoring.maxWalkDistance) : ((float2)walkPatterInGroup.walkPattern.baseMovementProperties.minMaxWalkDistance)),
				maxWalkDuration = (flag ? authoring.maxWalkDuration : walkPatterInGroup.walkPattern.baseMovementProperties.maxWalkDuration),
				goalCheckDistanceSqr = (flag ? 0.49984902f : (walkPatterInGroup.walkPattern.baseMovementProperties.goalCheckDistance * walkPatterInGroup.walkPattern.baseMovementProperties.goalCheckDistance)),
				movementSpeedMultiplier = (flag ? authoring.movementSpeedMultiplier : walkPatterInGroup.walkPattern.baseMovementProperties.movementSpeedMultiplier),
				minMaxIdleDurationAfterWalking = (flag ? new float2(authoring.minIdleDuration, authoring.maxIdleDuration) : ((float2)walkPatterInGroup.walkPattern.baseMovementProperties.minMaxIdleDurationAfterWalking))
			};
			SetGenericPatternGoalValuesFromDefinition(ref blobBuilderArray[i], walkPatterInGroup.walkPattern);
			SetGenericPatternValuesFromDefinition(ref blobBuilderArray[i], walkPatterInGroup.walkPattern);
			float weight = walkPatterInGroup.weight;
			blobBuilderArray2[i] = weight;
			num += weight;
		}
		groupBlobData.totalPatternWeights = num;
	}

	private void SetGenericPatternGoalValuesFromDefinition(ref RandomWalkStatePatterData patternBlob, WalkPatternDefinition patternWalkPattern)
	{
		WalkStateGoalPatternType goalPatternType = patternWalkPattern.goalPatternType;
		if (goalPatternType == WalkStateGoalPatternType.CardinalRandom || goalPatternType == WalkStateGoalPatternType.CardinalMoveInSquare || goalPatternType == WalkStateGoalPatternType.CardinalMoveInSingleLine)
		{
			patternBlob.movementPatternGoalFloatValue = patternWalkPattern.minMaxStopDistanceFromCollision.x;
			patternBlob.movementPatternGoalFloatValue2 = patternWalkPattern.minMaxStopDistanceFromCollision.y;
		}
		if (patternWalkPattern.goalPatternType == WalkStateGoalPatternType.CardinalRandom)
		{
			patternBlob.movementPatternGoalIntValue = (int)patternWalkPattern.patternRandomSelectionType;
			return;
		}
		goalPatternType = patternWalkPattern.goalPatternType;
		if (goalPatternType == WalkStateGoalPatternType.CardinalMoveInSquare || goalPatternType == WalkStateGoalPatternType.CardinalMoveInSingleLine)
		{
			patternBlob.movementPatternGoalIntValue = patternWalkPattern.modifiedStepsProperties.modifiedStartingSteps;
			patternBlob.movementPatternGoalIntValue2 = patternWalkPattern.modifiedStepsProperties.modifiedEndingSteps;
			patternBlob.movementPatternGoalFloatValue3 = patternWalkPattern.modifiedStepsProperties.modifiedWalkDistanceMultiplier;
			patternBlob.movementPatternGoalFloatValue4 = patternWalkPattern.modifiedStepsProperties.modifiedIdleDurationAfterWalkingMultiplier;
		}
	}

	private void SetGenericPatternValuesFromDefinition(ref RandomWalkStatePatterData patternBlob, WalkPatternDefinition patternWalkPattern)
	{
		WalkStateMovementPatternType movementPatternType = patternWalkPattern.movementPatternType;
		if (movementPatternType == WalkStateMovementPatternType.SinusoidalAngle || movementPatternType == WalkStateMovementPatternType.SinusoidalFlatAngle)
		{
			patternBlob.movementPatternFloatValue = patternWalkPattern.sinusoidalMaxTurnAngleDeg * (MathF.PI / 180f);
			patternBlob.movementPatternFloatValue2 = patternWalkPattern.sinusoidalRepeatTimeSeconds;
		}
	}
}
