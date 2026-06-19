#define PUG_RGB_ENABLED
using System.Collections;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	public static class Death
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup, bool isServer)
		{
			changePlayerStateAspect.playerStateCD.ValueRW.isStateLocked = true;
			changePlayerStateAspect.deathStateCD.ValueRW.isDyingOrDead = true;
			changePlayerStateAspect.deathStateCD.ValueRW.spawnedPlayer = false;
			changePlayerStateAspect.deathStateCD.ValueRW.respawnTimer.Start(changePlayerStateShared.currentTick);
			if (isServer)
			{
				PlayerController.PlayAnimationTrigger(-414722770, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
				Entity e = changePlayerStateShared.ecb.CreateEntity();
				changePlayerStateShared.ecb.AddComponent(e, default(PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC));
				changePlayerStateShared.ecb.AddComponent(e, new SendRpcCommandRequest
				{
					TargetConnection = changePlayerStateLookup.playerGhostLookup[changePlayerStateAspect.entity].connection
				});
			}
			changePlayerStateLookup.disablePhysicsLookup.SetComponentEnabled(changePlayerStateAspect.entity, value: true);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			if (IsPermakill(in stateUpdateAspect.characterTypeCD.ValueRO, in stateUpdateAspect.deathStateCD.ValueRO))
			{
				return;
			}
			float percentageFinished = stateUpdateAspect.deathStateCD.ValueRW.respawnTimer.GetPercentageFinished(sharedStateUpdateData.currentTick);
			if (!(percentageFinished < 5f / 6f))
			{
				if (!stateUpdateAspect.deathStateCD.ValueRW.spawnedPlayer)
				{
					stateUpdateAspect.deathStateCD.ValueRW.spawnedPlayer = true;
					RespawnPlayer(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
				}
				if (!(percentageFinished < 1f))
				{
					stateUpdateAspect.playerStateCD.ValueRW.isStateLocked = false;
					stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				}
			}
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			playerController.shadow.gameObject.SetActive(value: false);
			if (playerController.isLocal)
			{
				playerController.UnequipEquippedSlot();
				Manager.ui.HideAllInventoryAndCraftingUI();
				Manager.ui.HideMap();
			}
		}

		public static void StartRespawnSequence(PlayerController playerController, CharacterTypeCD characterTypeCD, DeathStateCD deathStateCD)
		{
			bool isPermakill = IsPermakill(in characterTypeCD, in deathStateCD);
			playerController.StartCoroutine(StateCoroutine(isPermakill));
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			playerController.shadow.gameObject.SetActive(value: true);
			if (playerController.isLocal)
			{
				playerController.EquipSlot(playerController.equippedSlotIndex);
				playerController.UpdateAllEquipmentSlots();
			}
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect statePresentationUpdateAspect, PlayerController playerController, StatePresentationUpdateLookups statePresentationUpdateLookups)
		{
			if (statePresentationUpdateLookups.ghostOwnerIsLocalLookup.IsComponentEnabled(statePresentationUpdateAspect.entity) && IsPermakill(in statePresentationUpdateAspect.characterTypeCD.ValueRO, in statePresentationUpdateAspect.deathStateCD.ValueRO) && playerController.inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.TOGGLE_SPECTATED_PLAYER))
			{
				Manager.camera.FollowNextPlayer();
			}
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateAspect.deathStateCD.ValueRW.allowHardcoreRespawn = false;
			changePlayerStateLookup.disablePhysicsLookup.SetComponentEnabled(changePlayerStateAspect.entity, value: false);
		}

		private static IEnumerator StateCoroutine(bool isPermakill)
		{
			Manager.ui.FadeOutAllGameplayUI();
			Manager.ui.FadeInMouse();
			Manager.rgb.TriggerEvent(RGBManager.Event.PlayerDeath_Splat);
			yield return new WaitForSeconds(1f);
			if (isPermakill)
			{
				Manager.saves.PermaKillCharacter();
				Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.HardcoreDeath);
				yield break;
			}
			Manager.load.FadeOut(3f, FadePresets.blackToBlack);
			Manager.rgb.StartState(RGBManager.State.PlayerDeath_FadeToBlack);
			yield return new WaitForSeconds(3f);
			Manager.rgb.EndState(RGBManager.State.PlayerDeath_FadeToBlack);
			yield return new WaitForSeconds(1f);
			yield return new WaitForSeconds(1f);
			Manager.ui.FadeInAllGameplayUI();
			Manager.ui.FadeInMouse();
			Manager.load.FadeIn(1f, FadePresets.blackToBlack);
		}

		private static void RespawnPlayer(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			stateUpdateAspect.deathStateCD.ValueRW.isDyingOrDead = false;
			float2 float5 = stateUpdateAspect.playerClaimedBed.ValueRO.position;
			if (math.all(float5 == float2.zero))
			{
				float5 = sharedStateUpdateData.playerSpawnPosition.xz;
			}
			lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity] = LocalTransform.FromPosition(float5.X0Y());
			PlayerController.RespawnPlayer(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
		}

		private static bool IsPermakill(in CharacterTypeCD characterTypeCD, in DeathStateCD deathStateCD)
		{
			if (characterTypeCD.IsHardcore())
			{
				return !deathStateCD.allowHardcoreRespawn;
			}
			return false;
		}
	}
}
