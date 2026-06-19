using PlayerState;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public static class FishingMiniGame
{
	public static void StartFishing(ref FishingMiniGameStateCD fishingMiniGameStateCD)
	{
		fishingMiniGameStateCD.miniGameOutcome = MiniGameOutcome.Undefined;
		fishingMiniGameStateCD.beginMiniGameTimer.ClearStart();
		fishingMiniGameStateCD.miniGameOverTimer.ClearStart();
		fishingMiniGameStateCD.fishStruggleTimer.ClearStart();
		fishingMiniGameStateCD.isInFishingMiniGame = false;
		fishingMiniGameStateCD.fishIsStruggling = false;
		fishingMiniGameStateCD.playerReeling = false;
		fishingMiniGameStateCD.prevPlayerReeling = false;
		fishingMiniGameStateCD.fishStruggleIndex = 0;
		fishingMiniGameStateCD.reelVolume = 0f;
		fishingMiniGameStateCD.lineTension = 0f;
		fishingMiniGameStateCD.struggleAudioFadeOutTime = 0.35f;
		fishingMiniGameStateCD.fishPosition = 0f;
		fishingMiniGameStateCD.fishLevel = 0;
	}

	public static void BeginPullUp(Entity entity, ref FishingMiniGameStateCD fishingMiniGameStateCD, NetworkTick currentTick, DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
	{
		fishingMiniGameStateCD.beginMiniGameTimer.Start(currentTick);
		fishingMiniGameStateCD.isInFishingMiniGame = true;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = currentTick,
			value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: false, SfxID.twitch, entity)
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
	}

	public static bool WaitForBeginMiniGame(ref FishingMiniGameStateCD fishingMiniGameStateCD, in SharedStateUpdateData sharedStateUpdateData)
	{
		if (!fishingMiniGameStateCD.beginMiniGameTimer.isRunning)
		{
			return false;
		}
		if (fishingMiniGameStateCD.beginMiniGameTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
		{
			fishingMiniGameStateCD.beginMiniGameTimer.Stop(sharedStateUpdateData.currentTick);
		}
		return true;
	}

	public static void UpdateMiniGame(in StateUpdateAspect stateUpdateAspect, in SharedStateUpdateData sharedStateUpdateData, in LookupStateUpdateData lookupStateUpdateData, Fishing.PullUpData pullUpData)
	{
		ref FishingMiniGameStateCD valueRW = ref stateUpdateAspect.fishingMiniGameStateCD.ValueRW;
		ref FishingStateCD valueRW2 = ref stateUpdateAspect.fishingStateCD.ValueRW;
		if (!valueRW.miniGameOverTimer.isRunning)
		{
			float num = FishingTable.FishingValueToLevel(EntityUtility.GetConditionEffectValue(ConditionEffect.Fishing, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionEffectsLookup));
			float num2 = 2f;
			if (valueRW.fishLevel <= 4)
			{
				num2 = 4f;
			}
			float num3 = 1f + math.max(((float)valueRW.fishLevel - num) / num2, -0.5f);
			if (!valueRW.fishStruggleTimer.isRunning || valueRW.fishStruggleTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				ref FishingStruggleInfoData fishStruggleInfo = ref sharedStateUpdateData.fishingTableCD.GetFishStruggleInfo(valueRW2.fishingLootToSpawn);
				int length = fishStruggleInfo.struggleData.Length;
				valueRW.fishStruggleIndex = math.min(valueRW.fishStruggleIndex, length);
				valueRW.fishIsStruggling = fishStruggleInfo.struggleData[valueRW.fishStruggleIndex].isStruggling;
				float time = fishStruggleInfo.struggleData[valueRW.fishStruggleIndex].time;
				valueRW.fishStruggleTimer.Start(sharedStateUpdateData.currentTick, time, sharedStateUpdateData.tickRate);
				valueRW.fishStruggleIndex = (valueRW.fishStruggleIndex + 1) % length;
			}
			if (valueRW.fishIsStruggling)
			{
				valueRW.struggleBlend += sharedStateUpdateData.deltaTime * 5f;
			}
			else
			{
				valueRW.struggleBlend = 0f;
			}
			valueRW.struggleBlend = math.clamp(valueRW.struggleBlend, 0f, 1f);
			valueRW.playerReeling = stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown);
			if (valueRW.playerReeling)
			{
				if (!valueRW.fishIsStruggling)
				{
					valueRW.fishPosition -= sharedStateUpdateData.deltaTime * 0.35f;
				}
				valueRW.reelVolume += sharedStateUpdateData.deltaTime * 4f;
			}
			else
			{
				if (valueRW.fishIsStruggling)
				{
					valueRW.fishPosition += sharedStateUpdateData.deltaTime * 0.15f;
				}
				else
				{
					valueRW.fishPosition += sharedStateUpdateData.deltaTime * 0.25f * num3;
				}
				valueRW.reelVolume -= sharedStateUpdateData.deltaTime * 8f;
			}
			valueRW.fishPosition = math.clamp(valueRW.fishPosition, -1f, 1f);
			valueRW.reelVolume = math.clamp(valueRW.reelVolume, 0f, 1f);
			if (valueRW.playerReeling != valueRW.prevPlayerReeling)
			{
				if (valueRW.playerReeling)
				{
					PlayerController.PlayAnimationTrigger(-1305355105, sharedStateUpdateData.currentTick, stateUpdateAspect.animationBuffer, ref stateUpdateAspect.animationBufferPointer.ValueRW);
				}
				else
				{
					PlayerController.PlayAnimationTrigger(1975517117, sharedStateUpdateData.currentTick, stateUpdateAspect.animationBuffer, ref stateUpdateAspect.animationBufferPointer.ValueRW);
				}
				valueRW.prevPlayerReeling = valueRW.playerReeling;
			}
			if (valueRW.playerReeling)
			{
				float num4 = 0.05f;
				if (valueRW.fishIsStruggling)
				{
					num4 = 0.6f * valueRW.struggleBlend;
				}
				valueRW.lineTension += sharedStateUpdateData.deltaTime * num4;
			}
			else
			{
				valueRW.lineTension -= sharedStateUpdateData.deltaTime * 0.06f;
			}
			valueRW.lineTension = math.clamp(valueRW.lineTension, 0f, 1f);
			if (valueRW.fishPosition <= -0.9f)
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW3 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.successTone, stateUpdateAspect.entity, 0.6f)
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW3, in item);
				valueRW.miniGameOverTimer.Start(sharedStateUpdateData.currentTick, 0.3f, sharedStateUpdateData.tickRate);
				valueRW.miniGameOutcome = MiniGameOutcome.FishCaught;
			}
			else if (valueRW.fishPosition >= 0.95f)
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW4 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.fishFail, stateUpdateAspect.entity)
				};
				ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW4, in item);
				valueRW2.fishingLootToSpawn = ObjectID.None;
				valueRW.miniGameOverTimer.Start(sharedStateUpdateData.currentTick, 1f, sharedStateUpdateData.tickRate);
				valueRW.miniGameOutcome = MiniGameOutcome.FishEscaped;
			}
			else if (valueRW.lineTension >= 1f)
			{
				valueRW2.fishingLootToSpawn = ObjectID.None;
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW5 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.lineSnap, stateUpdateAspect.entity, 1f, 0.7f, 0.1f)
				};
				ghostEffectEventBuffer3.AddToRingBuffer(ref valueRW5, in item);
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW6 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.fishFail, stateUpdateAspect.entity)
				};
				ghostEffectEventBuffer4.AddToRingBuffer(ref valueRW6, in item);
				valueRW.miniGameOverTimer.Start(sharedStateUpdateData.currentTick, 1f, sharedStateUpdateData.tickRate);
				valueRW.miniGameOutcome = MiniGameOutcome.LineSnapped;
				PlayerController.PlayAnimationTrigger(1352515405, sharedStateUpdateData.currentTick, stateUpdateAspect.animationBuffer, ref stateUpdateAspect.animationBufferPointer.ValueRW);
			}
			return;
		}
		valueRW.lineTension = 0f;
		valueRW.playerReeling = false;
		valueRW.fishIsStruggling = false;
		if (valueRW.miniGameOutcome == MiniGameOutcome.FishCaught)
		{
			if (valueRW.miniGameOverTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				Fishing.PullUp(in pullUpData, failedThrow: false);
			}
		}
		else if (valueRW.miniGameOutcome == MiniGameOutcome.FishEscaped)
		{
			valueRW.fishPosition += sharedStateUpdateData.deltaTime * 0.5f;
			if (valueRW.miniGameOverTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				Fishing.PullUp(in pullUpData, failedThrow: true);
			}
		}
		else if (valueRW.miniGameOutcome == MiniGameOutcome.LineSnapped)
		{
			valueRW.fishPosition += sharedStateUpdateData.deltaTime * 0.5f;
			if (valueRW.miniGameOverTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				Fishing.OnExitFishing(ref stateUpdateAspect.playerStateCD.ValueRW, ref stateUpdateAspect.playerOrientationCD.ValueRW, ref valueRW2, sharedStateUpdateData.currentTick, wasExitingState: false);
			}
		}
	}
}
