using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public static class EffectEventExtensions
{
	private const string XP_GAINED_TERM = "experienceGained";

	private const float DISTANCE_SQ_TO_PLAY_AUDIO_AND_RUMBLE_ON_GAMEPAD = 25f;

	public static void PlayEffect(EffectEventCD effectEvent, Entity callerEntity, World world)
	{
		if (effectEvent.localOnlyEffect == 1 && (Manager.main.player == null || Manager.main.player.entity != callerEntity))
		{
			return;
		}
		switch (effectEvent.effectID)
		{
		case EffectID.FailedHit:
		case EffectID.FailedHitWithSparks:
		{
			float3 float5 = effectEvent.position1;
			if (effectEvent.entity != Entity.Null && EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityMonoRenderPosition(effectEvent.entity, out var position3))
			{
				float5 = position3;
			}
			bool playOnGamepad = ShouldPlayAudioAndRumbleOnGamepad(float5);
			AudioManager.Sfx(SfxID.clunk, float5, 1f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad);
			if (effectEvent.effectID == EffectID.FailedHitWithSparks)
			{
				Manager.effects.PlayPuff(PuffID.Sparks, float5, 5);
				Manager.effects.WithTileColliders(float5);
			}
			break;
		}
		case EffectID.PlaceObject:
			PlaceObject(effectEvent);
			break;
		case EffectID.PlaceTile:
			PlaceTile(effectEvent);
			break;
		case EffectID.PlaceCritter:
			PlaceCritter(effectEvent);
			break;
		case EffectID.DamageTile:
			DamageTile(effectEvent, weakHit: false);
			if (effectEvent.tileInfo.tileType.IsContainedResource())
			{
				effectEvent.tileInfo = new TileInfo
				{
					tileType = TileType.wall,
					tileset = effectEvent.value1
				};
				DamageTile(effectEvent, weakHit: false);
			}
			break;
		case EffectID.DamageTileWeak:
			DamageTile(effectEvent, weakHit: true);
			if (effectEvent.tileInfo.tileType.IsContainedResource())
			{
				effectEvent.tileInfo = new TileInfo
				{
					tileType = TileType.wall,
					tileset = effectEvent.value1
				};
				DamageTile(effectEvent, weakHit: false);
			}
			break;
		case EffectID.DestroyTile:
			Manager.effects.PlayDestroyTileEffect(effectEvent.position1, effectEvent.tileInfo.tileType, effectEvent.tileInfo.tileset, effectEvent.value1);
			break;
		case EffectID.RefillWater:
		{
			bool flag5 = effectEvent.value1 == 6;
			bool flag6 = effectEvent.value1 == 9;
			bool flag7 = effectEvent.value1 == 3;
			PlayerController playerController4 = (PlayerController)Manager.memory.GetEntityMono(effectEvent.entity);
			if (!(playerController4 == null))
			{
				Vector3 position4 = playerController4.carryablePlaceItemSprite.transform.position;
				float3 position5 = effectEvent.position1;
				if (flag7)
				{
					AudioManager.Sfx(SfxTableID.refillLava, position4);
					PuffID[] inputPuffs5 = new PuffID[3]
					{
						PuffID.SmallLavaSplash,
						PuffID.LavaDrip,
						PuffID.LavaRipple
					};
					RefillEffects(position4, position5, inputPuffs5, SpriteTempEffectID.WaterSplashLava);
				}
				else if (flag6)
				{
					AudioManager.Sfx(SfxTableID.refillWater, position4);
					PuffID[] inputPuffs6 = new PuffID[3]
					{
						PuffID.SmallMoldWaterSplash,
						PuffID.MoldWaterDrip,
						PuffID.MoldWaterRipple
					};
					RefillEffects(position4, position5, inputPuffs6, SpriteTempEffectID.WaterSplashMold);
				}
				else if (flag5)
				{
					AudioManager.Sfx(SfxTableID.refillWater, position4);
					PuffID[] inputPuffs7 = new PuffID[3]
					{
						PuffID.SmallYellowWaterSplash,
						PuffID.YellowWaterDrip,
						PuffID.YellowWaterRipple
					};
					RefillEffects(position4, position5, inputPuffs7, SpriteTempEffectID.WaterSplashYellow);
				}
				else
				{
					AudioManager.Sfx(SfxTableID.refillWater, position4);
					PuffID[] inputPuffs8 = new PuffID[3]
					{
						PuffID.SmallWaterSplash,
						PuffID.WaterDrip,
						PuffID.WaterRipple
					};
					RefillEffects(position4, position5, inputPuffs8, SpriteTempEffectID.WaterSplash);
				}
			}
			break;
		}
		case EffectID.PlaceWater:
		{
			bool flag11 = effectEvent.value1 == 6;
			bool flag12 = effectEvent.value1 == 9;
			bool flag13 = effectEvent.value1 == 3;
			PlayerController playerController10 = (PlayerController)Manager.memory.GetEntityMono(effectEvent.entity);
			if (!(playerController10 == null))
			{
				Vector3 position14 = playerController10.carryablePlaceItemSprite.transform.position;
				if (flag13)
				{
					AudioManager.Sfx(SfxTableID.placeLava, position14);
					Manager.effects.PlayPuff(PuffID.SmallLavaSplash, effectEvent.position1, 20);
					Manager.effects.PlayPuff(PuffID.LavaDrip, position14, 20);
					Manager.effects.PlayTempSprite(SpriteTempEffectID.WaterRippleLava, effectEvent.position1, 1f, 0.42857143f);
				}
				else if (flag12)
				{
					AudioManager.Sfx(SfxTableID.placeWater, position14);
					Manager.effects.PlayPuff(PuffID.SmallMoldWaterSplash, effectEvent.position1, 20);
					Manager.effects.PlayPuff(PuffID.MoldWaterDrip, position14, 20);
					Manager.effects.PlayTempSprite(SpriteTempEffectID.WaterRippleWhite, effectEvent.position1, 1f, 0.42857143f);
				}
				else if (flag11)
				{
					AudioManager.Sfx(SfxTableID.placeWater, position14);
					Manager.effects.PlayPuff(PuffID.SmallYellowWaterSplash, effectEvent.position1, 20);
					Manager.effects.PlayPuff(PuffID.YellowWaterDrip, position14, 20);
					Manager.effects.PlayTempSprite(SpriteTempEffectID.WaterRippleYellow, effectEvent.position1, 1f, 0.42857143f);
				}
				else
				{
					AudioManager.Sfx(SfxTableID.placeWater, position14);
					Manager.effects.PlayPuff(PuffID.SmallWaterSplash, effectEvent.position1, 20);
					Manager.effects.PlayPuff(PuffID.WaterDrip, position14, 20);
					Manager.effects.PlayTempSprite(SpriteTempEffectID.WaterRipple, effectEvent.position1, 1f, 0.42857143f);
				}
			}
			break;
		}
		case EffectID.DigGround:
			AudioManager.Sfx(SfxID.shoveldig, effectEvent.position1, 1f, 1f, 0.2f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
			Manager.effects.PlayPuff(PuffID.DirtBlockDebris, effectEvent.position1, 5);
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 12);
			break;
		case EffectID.DigDugUpGround:
			AudioManager.Sfx(SfxID.shoveldig, effectEvent.position1, 1f, 1.5f, 0.2f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 3);
			break;
		case EffectID.EatDefault:
			AudioManager.Sfx(SfxID.nom2, effectEvent.position1, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
			Manager.effects.PlayPuff(PuffID.SmallWhitePuff, effectEvent.position1 + new float3(0f, 1f, 0f) * 0.3125f);
			break;
		case EffectID.EatMushroom:
			AudioManager.Sfx(SfxID.nom2, effectEvent.position1, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
			Manager.effects.PlayPuff(PuffID.SmallWhitePuff, effectEvent.position1 + new float3(0f, 1f, 0f) * 0.3125f, 5);
			Manager.effects.PlayPuff(PuffID.MushroomDebris, effectEvent.position1 + new float3(0f, 1f, 0f) * 0.3125f, 8);
			break;
		case EffectID.EatHeartBerry:
			AudioManager.Sfx(SfxID.nom2, effectEvent.position1, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
			Manager.effects.PlayPuff(PuffID.SmallRedPuff, effectEvent.position1 + new float3(0f, 1f, 0f) * 0.3125f, 14);
			break;
		case EffectID.EatIncreaseMaxHealthItem:
		{
			PlayerController playerController6 = (PlayerController)Manager.memory.GetEntityMono(effectEvent.entity);
			AudioManager.Sfx(SfxID.maxHealthUp1, playerController6.transform.position, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(playerController6.transform.position));
			Manager.effects.PlayPuff(PuffID.MaxHealthUp, playerController6.transform.position + new Vector3(0f, 1f, 0f) * 0.3125f, 1);
			break;
		}
		case EffectID.WhiteParticles:
			Manager.effects.PlayPuff(PuffID.SmallWhitePuff, effectEvent.position1);
			break;
		case EffectID.RedDamageNumber:
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				if (GetEntityCombatTextPosition(effectEvent.entity, out var position))
				{
					CombatText.SpawnCombatText(effectEvent.value1.ToString(), CombatText.NumberColor.Red, position, isDamageNumber: true);
				}
				EntityMonoBehaviour entityMono2 = Manager.memory.GetEntityMono(effectEvent.entity);
				if (entityMono2 != null)
				{
					DamageEffectType damageEffectType = (DamageEffectType)effectEvent.value2;
					PlayDamageEffectByType(entityMono2, damageEffectType);
				}
			}
			break;
		case EffectID.WhiteDamageNumber:
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				if (GetEntityCombatTextPosition(effectEvent.entity, out var position13))
				{
					CombatText.SpawnCombatText(effectEvent.value1.ToString(), CombatText.NumberColor.White, position13, isDamageNumber: true);
				}
				EntityMonoBehaviour entityMono16 = Manager.memory.GetEntityMono(effectEvent.entity);
				if (entityMono16 != null)
				{
					DamageEffectType damageEffectType3 = (DamageEffectType)effectEvent.value2;
					PlayDamageEffectByType(entityMono16, damageEffectType3);
				}
			}
			break;
		case EffectID.HealingNumber:
		{
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityCombatTextPosition(effectEvent.entity, out var position11))
			{
				CombatText.SpawnCombatText(effectEvent.value1.ToString(), CombatText.NumberColor.Green, position11, isDamageNumber: true);
			}
			break;
		}
		case EffectID.CritNumber:
		{
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityCombatTextPosition(effectEvent.entity, out var position9))
			{
				CombatText.SpawnCombatText(effectEvent.value1.ToString(), CombatText.NumberColor.Yellow, position9, isDamageNumber: true, isCrit: true);
			}
			break;
		}
		case EffectID.Dodge:
		{
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityCombatTextPosition(effectEvent.entity, out var position8))
			{
				CombatText.SpawnCombatText("dodge", CombatText.NumberColor.White, position8, isDamageNumber: false, isCrit: false, localize: true);
			}
			break;
		}
		case EffectID.Parry:
		{
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityCombatTextPosition(effectEvent.entity, out var position2))
			{
				if (effectEvent.value1 == 0)
				{
					CombatText.SpawnCombatText("parry", CombatText.NumberColor.Orange, position2, isDamageNumber: false, isCrit: false, localize: true, null, randomPosition: false);
				}
				else if (effectEvent.value1 == 1)
				{
					CombatText.SpawnCombatText("0", CombatText.NumberColor.Orange, position2, isDamageNumber: false, isCrit: false, localize: false, null, randomPosition: false);
				}
				Manager.effects.PlayPuff(PuffID.HitStarPoof, position2 + new Vector3(0f, 0.25f, -0.25f), 1);
				Manager.effects.PlayPuff(PuffID.Parry, position2 + new Vector3(0f, 0.25f, -0.25f), 1);
				AudioManager.Sfx(SfxID.shieldParry, position2, 1f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
				AudioManager.Sfx(SfxID.knockback, position2, 1f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
			}
			break;
		}
		case EffectID.AttackFX:
		{
			if (!EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				break;
			}
			PlayerController playerController9 = (PlayerController)Manager.memory.GetEntityMono(effectEvent.entity);
			if (playerController9 == null || !PugDatabase.HasComponent<MeleeWeaponCD>((ObjectID)effectEvent.value1))
			{
				break;
			}
			MeleeWeaponCD component = PugDatabase.GetComponent<MeleeWeaponCD>((ObjectID)effectEvent.value1);
			Direction direction = new Direction
			{
				id = (Direction.Id)effectEvent.value2
			};
			Vector3 vector = direction.f3;
			Direction.Id id = Direction.FromVector(vector).id;
			float x3 = effectEvent.vector1.x;
			float width = 0.5f;
			float y3 = 0.01f;
			bool flag10 = id == Direction.right;
			float duration = 1f;
			float delay = 0f;
			Material material = null;
			if (PugDatabase.HasComponent<SecondaryUseCD>((ObjectID)effectEvent.value1))
			{
				SecondaryUseCD component2 = PugDatabase.GetComponent<SecondaryUseCD>((ObjectID)effectEvent.value1);
				material = Manager.effects.weaponEffectsTable.GetWeaponEffectMaterial(component2.weaponEffectType);
			}
			float arc = component.arcAngle switch
			{
				ArcAngle.arc45 => 45f, 
				ArcAngle.arc90 => 90f, 
				ArcAngle.arc135 => 135f, 
				ArcAngle.arc180 => 180f, 
				ArcAngle.arc270 => 270f, 
				ArcAngle.arc360 => 360f, 
				_ => 90f, 
			};
			float x4 = (component.colliderCenteredOnWindup ? 0f : effectEvent.position1.x);
			float num3 = (component.colliderCenteredOnWindup ? 0f : effectEvent.position1.z);
			switch (component.attackFXType)
			{
			case AttackFXType.Arc:
				delay = 0.06f;
				playerController9.attackFX.PlayArc(vector, x3 * 0.5f, arc, duration, delay, material, !flag10);
				x4 = 0f;
				num3 = 0f;
				if (id == Direction.forward)
				{
					num3 += x3 * 0.19999999f * 0.5f;
				}
				else if (id == Direction.back)
				{
					num3 -= x3 * 0.19999999f * 0.5f;
				}
				break;
			case AttackFXType.Line:
				duration = 1.5f;
				playerController9.attackFX.PlayLine(vector, x3, width, duration, delay, material);
				x4 = 0f;
				num3 = 0f;
				y3 = 0.5f;
				break;
			case AttackFXType.Shockwave:
				duration = 2f;
				playerController9.attackFX.PlayShockwave(x3 * 0.5f, duration, delay, material);
				break;
			}
			Vector3 localPosition = new Vector3(x4, y3, num3);
			playerController9.attackFX.transform.localPosition = localPosition;
			break;
		}
		case EffectID.FireDamage:
		{
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityCombatTextPosition(effectEvent.entity, out var position7))
			{
				bool isCrit = effectEvent.value2 == 1;
				CombatText.SpawnCombatText(effectEvent.value1.ToString(), CombatText.NumberColor.Orange, position7, isDamageNumber: true, isCrit);
			}
			break;
		}
		case EffectID.CheatDeath:
		{
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld) && GetEntityCombatTextPosition(effectEvent.entity, out var position6))
			{
				CombatText.SpawnCombatText("cheatDeath", CombatText.NumberColor.White, position6, isDamageNumber: false, isCrit: false, localize: true);
			}
			break;
		}
		case EffectID.Dash:
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				PlayerController playerController3 = Manager.memory.GetEntityMono(effectEvent.entity) as PlayerController;
				if (playerController3 != null)
				{
					AudioManager.SfxFollowTransform(SfxID.Dash, playerController3.transform, 1f, 1f, 0.2f);
					Manager.effects.PlayPuff(PuffID.DirtItemDust, playerController3.transform.position, 6);
					playerController3.SpawnDashEffect(effectEvent.vector1);
				}
			}
			break;
		case EffectID.MinionDetonation:
			AudioManager.Sfx(SfxTableID.MinionDetonationImpending, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.PurpleSmoke, effectEvent.position1, 6);
			break;
		case EffectID.RemoteDetonation:
			AudioManager.Sfx(SfxTableID.switchClickGenericSfx, effectEvent.position1, 0.4f);
			AudioManager.Sfx(SfxID.remote_clicker_1_01, effectEvent.position1, 0.3f, 0.93f, 0.03f);
			Manager.effects.PlayPuff(PuffID.Sparks, effectEvent.position1 + new float3(0f, 0.5f, 0f), 4);
			break;
		case EffectID.AcidExplosion:
			Manager.effects.PlayPuff(PuffID.AcidExplosion, effectEvent.position1);
			AudioManager.Sfx(SfxID.slimeImpact, effectEvent.position1, 1f, 1f, 0.1f);
			break;
		case EffectID.AmassingDamage:
			Manager.effects.PlayPuff(PuffID.AcidExplosion, effectEvent.position1);
			AudioManager.Sfx(SfxID.slimeImpact, effectEvent.position1, 1f, 1f, 0.1f);
			Manager.effects.PlayPuff(PuffID.AmassEffectPuff, effectEvent.position1, 6);
			break;
		case EffectID.DrinkPotionDefault:
			AudioManager.Sfx(SfxID.drinking, effectEvent.position1, 1f, 1.1f, 0.15f);
			Manager.effects.PlayPuff(PuffID.SmallRedPuff, effectEvent.position1 + new float3(0f, 1f, 0f) * 0.3125f);
			break;
		case EffectID.TeleportExplosion:
		{
			AudioManager.Sfx(SfxID.darkgleam, effectEvent.position1);
			SpawnEffect freeComponent = Manager.memory.GetFreeComponent<SpawnEffect>(deferOnOccupied: true);
			if (freeComponent != null)
			{
				freeComponent.transform.position = effectEvent.position1 + new float3(0f, 5f, -5f);
				freeComponent.OnOccupied();
			}
			else
			{
				Debug.LogError("failed to instantiate player spawn effect in Casting.cs");
			}
			break;
		}
		case EffectID.ScanEffect:
			Manager.effects.PlayScanEffect(effectEvent.position1, 10f, 5f);
			break;
		case EffectID.SpawnRoot:
			AudioManager.Sfx(SfxID.Plop, effectEvent.position1, 1f, 1f, 0.2f);
			Manager.effects.PlayPuff(PuffID.DirtBlockDebris, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 20);
			break;
		case EffectID.HitDamageSound:
			if (effectEvent.value2 == 1)
			{
				AudioManager.Sfx(effectEvent.value1, effectEvent.position1);
			}
			else
			{
				AudioManager.Sfx((SfxID)effectEvent.value1, effectEvent.position1, 1f, 1f, 0f, reuse: true);
			}
			break;
		case EffectID.Paint:
		{
			float3 float6 = effectEvent.position1;
			ObjectID value3 = (ObjectID)effectEvent.value2;
			if (value3 != ObjectID.None && PugDatabase.TryGetComponent<ObjectPropertiesCD>(value3, out var component3) && component3.Has(-1171081164))
			{
				EntityMonoBehaviour entityMono17 = Manager.memory.GetEntityMono(effectEvent.entity);
				if (entityMono17 != null)
				{
					float6 = entityMono17.center;
				}
			}
			AudioManager.Sfx(SfxID.drinking, float6, 1f, 1.5f, 0.1f);
			Manager.effects.PlayPuff((PuffID)effectEvent.value1, effectEvent.position1, 60);
			break;
		}
		case EffectID.MinecartCrash:
		{
			EntityMonoBehaviour entityMono13 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono13 != null)
			{
				Entity controlledByEntity2 = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(effectEvent.entity, entityMono13.world).controlledByEntity;
				EntityMonoBehaviour entityMono14 = Manager.memory.GetEntityMono(controlledByEntity2);
				if (entityMono14 != null)
				{
					Vector3 position12 = entityMono14.transform.position;
					Manager.effects.PlayPuff(PuffID.DirtBlockDust, position12, 20);
					Manager.effects.PlayPuff(PuffID.Sparks, position12);
					AudioManager.Sfx(SfxID.metalImpact, position12, 0.8f, 0.8f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(position12));
					entityMono13.animator.SetTrigger(-1533413595);
				}
			}
			break;
		}
		case EffectID.MinecartQuickTurn:
		{
			EntityMonoBehaviour entityMono11 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono11 != null)
			{
				Entity controlledByEntity = EntityUtility.GetComponentData<ControlledByOtherEntityCD>(effectEvent.entity, entityMono11.world).controlledByEntity;
				EntityMonoBehaviour entityMono12 = Manager.memory.GetEntityMono(controlledByEntity);
				if (entityMono12 != null)
				{
					Vector3 position10 = entityMono12.transform.position;
					Manager.effects.PlayPuff(PuffID.DirtBlockDust, position10, 5);
					Manager.effects.PlayPuff(PuffID.Sparks, position10, 4);
					AudioManager.Sfx(SfxID.metalImpactSmall, position10, 0.5f, 0.55f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(position10));
				}
			}
			break;
		}
		case EffectID.WaterSplash:
		{
			AudioManager.Sfx(SfxID.puddle2, effectEvent.position1, 0.1f, 1.1f, 0.25f, reuse: true);
			AudioManager.Sfx(SfxTableID.waterSplashSfx, effectEvent.position1, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: true);
			effectEvent.tileInfo = Manager.multiMap.GetTileLayerLookup().GetTopTile(Manager.camera.RenderOrigo.ToInt2() + effectEvent.position1.RoundToInt2());
			bool flag8 = effectEvent.tileInfo.tileset == 6;
			bool num2 = effectEvent.tileInfo.tileset == 9;
			bool flag9 = effectEvent.tileInfo.tileset == 3;
			if (num2)
			{
				PuffID[] inputPuffs9 = new PuffID[2]
				{
					PuffID.SmallMoldWaterSplash,
					PuffID.MoldWaterRipple
				};
				WaterSplashEffects(effectEvent.position1, inputPuffs9, SpriteTempEffectID.WaterSplashMold);
			}
			else if (flag8)
			{
				PuffID[] inputPuffs10 = new PuffID[2]
				{
					PuffID.SmallYellowWaterSplash,
					PuffID.YellowWaterRipple
				};
				WaterSplashEffects(effectEvent.position1, inputPuffs10, SpriteTempEffectID.WaterSplashYellow);
			}
			else if (flag9)
			{
				PuffID[] inputPuffs11 = new PuffID[2]
				{
					PuffID.SmallLavaSplash,
					PuffID.LavaRipple
				};
				WaterSplashEffects(effectEvent.position1, inputPuffs11, SpriteTempEffectID.WaterSplashYellow);
			}
			else
			{
				PuffID[] inputPuffs12 = new PuffID[2]
				{
					PuffID.SmallWaterSplash,
					PuffID.WaterRipple
				};
				WaterSplashEffects(effectEvent.position1, inputPuffs12, SpriteTempEffectID.WaterSplash);
			}
			break;
		}
		case EffectID.SmallWaterSplash:
		{
			AudioManager.Sfx(SfxTableID.waterSplashSfx, effectEvent.position1, 0.3f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: true);
			effectEvent.tileInfo = Manager.multiMap.GetTileLayerLookup().GetTopTile(Manager.camera.RenderOrigo.ToInt2() + effectEvent.position1.RoundToInt2());
			bool flag3 = effectEvent.tileInfo.tileset == 6;
			bool num = effectEvent.tileInfo.tileset == 9;
			bool flag4 = effectEvent.tileInfo.tileset == 3;
			if (num)
			{
				PuffID[] inputPuffs = new PuffID[2]
				{
					PuffID.SmallMoldWaterSplash,
					PuffID.MoldWaterRipple
				};
				SmallWaterSplashEffects(effectEvent.position1, inputPuffs, SpriteTempEffectID.WaterSplashMold);
			}
			else if (flag3)
			{
				PuffID[] inputPuffs2 = new PuffID[2]
				{
					PuffID.SmallYellowWaterSplash,
					PuffID.YellowWaterRipple
				};
				SmallWaterSplashEffects(effectEvent.position1, inputPuffs2, SpriteTempEffectID.WaterSplashYellow);
			}
			else if (flag4)
			{
				PuffID[] inputPuffs3 = new PuffID[2]
				{
					PuffID.SmallLavaSplash,
					PuffID.LavaRipple
				};
				SmallWaterSplashEffects(effectEvent.position1, inputPuffs3, SpriteTempEffectID.WaterSplashYellow);
			}
			else
			{
				PuffID[] inputPuffs4 = new PuffID[2]
				{
					PuffID.SmallWaterSplash,
					PuffID.WaterRipple
				};
				SmallWaterSplashEffects(effectEvent.position1, inputPuffs4, SpriteTempEffectID.WaterSplash);
			}
			break;
		}
		case EffectID.PlayerTakeDamage:
		{
			if (!EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				break;
			}
			PlayerController playerController2 = Manager.memory.GetEntityMono(effectEvent.entity) as PlayerController;
			if (playerController2 != null)
			{
				playerController2.PlayTakeDamageEffect();
				if (playerController2.isLocal && effectEvent.value1 != 0)
				{
					Manager.ui.playerHealthBarUI.FlashHealthBarWhite();
				}
				DamageEffectType damageEffectType2 = (DamageEffectType)effectEvent.value2;
				PlayDamageEffectByType(playerController2, damageEffectType2);
			}
			break;
		}
		case EffectID.PlayerTakeMagicBarrierDamage:
		{
			if (!EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				break;
			}
			PlayerController playerController = Manager.memory.GetEntityMono(effectEvent.entity) as PlayerController;
			if (playerController != null)
			{
				playerController.PlayTakeBarrierDamageEffect();
				if (playerController.isLocal)
				{
					Manager.ui.playerHealthBarUI.FlashHealthBarWhite();
				}
			}
			break;
		}
		case EffectID.PortalTeleport:
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				Portal portal = Manager.memory.GetEntityMono(effectEvent.entity) as Portal;
				if (portal != null)
				{
					portal.PlayLocalTeleportEffects();
				}
			}
			break;
		case EffectID.BurnSmoke:
			Manager.effects.PlayPuff(PuffID.BurnSmoke, effectEvent.position1, 20);
			AudioManager.Sfx(SfxID.bombFuse, effectEvent.position1, 0.5f, 1f, 0.1f);
			break;
		case EffectID.SmallRumble:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 15f)
			{
				AudioManager.Sfx(SfxID.rockDebris1, effectEvent.position1, 0.8f, 1.15f, 0.1f);
				Manager.camera.ShakeCameraNow(0.5f, 0.3f, 0.3f);
			}
			break;
		case EffectID.Rumble:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 15f)
			{
				AudioManager.Sfx(SfxID.rockDebris1, effectEvent.position1, 1f, 0.85f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
				Manager.camera.ShakeCameraNow(0.5f, 0.5f, 0.5f);
			}
			break;
		case EffectID.MysteriousSunkenSeaRumble:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 15f)
			{
				AudioManager.SfxMono(SfxID.hiveMotherwakeUp, 0.35f, 0.65f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, muteVolumeWhilePaused: true, playOnGamepad: true);
				Manager.camera.ShakeCameraNow(1f);
			}
			break;
		case EffectID.CaveInEffect:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 15f)
			{
				AudioManager.SfxMono(SfxID.EarthquakeSpawn, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, muteVolumeWhilePaused: true, playOnGamepad: true);
				Manager.camera.ShakeCameraNow(5f, 2f, 2f, null, null, 1, 50f);
			}
			break;
		case EffectID.ChestSpawn:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 10f)
			{
				AudioManager.Sfx(SfxTableID.spawnChestFromWall, effectEvent.position1, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
				Manager.effects.PlayPuff(PuffID.ShinyPuff, effectEvent.position1 + new float3(0f, 0.5f, 0f));
			}
			break;
		case EffectID.HalloweenEffect:
			Manager.effects.PlayPuff(PuffID.HalloweenConfetti, effectEvent.position1, 40);
			Manager.effects.PlayPuff(PuffID.HalloweenConfetti2, effectEvent.position1, 40);
			AudioManager.Sfx(SfxID.grassImpactHard, effectEvent.position1, 1f, 0.8f, 0.2f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
			switch (UnityEngine.Random.Range(0, 2))
			{
			case 0:
				AudioManager.Sfx(SfxID.CuteEvilLaugh1, effectEvent.position1, 0.8f, 1.2f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
				break;
			case 1:
				AudioManager.Sfx(SfxID.CuteEvilLaugh2, effectEvent.position1, 0.8f, 1.2f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
				break;
			}
			break;
		case EffectID.HonkSound:
		{
			EntityMonoBehaviour entityMono15 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono15 != null)
			{
				AudioManager.Sfx(effectEvent.value1, entityMono15.RenderPosition);
			}
			break;
		}
		case EffectID.ChristmasEffect:
			Manager.effects.PlayPuff(PuffID.ChristmasConfetti, effectEvent.position1, 20);
			Manager.effects.PlayPuff(PuffID.ChristmasConfetti2, effectEvent.position1, 30);
			Manager.effects.PlayPuff(PuffID.Snowflakes, effectEvent.position1, 30);
			Manager.effects.PlayPuff(PuffID.SnowLinger, effectEvent.position1, 60);
			AudioManager.Sfx(SfxTableID.christmasPresent, effectEvent.position1);
			break;
		case EffectID.LuxaryChristmasEffect:
			Manager.effects.PlayPuff(PuffID.LuxaryConfetti, effectEvent.position1, 20);
			Manager.effects.PlayPuff(PuffID.LuxaryConfetti2, effectEvent.position1, 30);
			Manager.effects.PlayPuff(PuffID.Snowflakes, effectEvent.position1, 30);
			Manager.effects.PlayPuff(PuffID.SnowLinger, effectEvent.position1, 60);
			AudioManager.Sfx(SfxTableID.christmasPresentLuxary, effectEvent.position1);
			break;
		case EffectID.LunarEffect:
			Manager.effects.PlayPuff(PuffID.LunarPoof, effectEvent.position1, 20);
			AudioManager.Sfx(SfxTableID.lunarRedEnvelopeOpen, effectEvent.position1);
			break;
		case EffectID.SpawnNPC:
			if (effectEvent.value1 == 3904)
			{
				switch (Manager.prefs.season)
				{
				case Season.Christmas:
					if (effectEvent.value2 == 1)
					{
						Manager.effects.PlayPuff(PuffID.Snowflakes, effectEvent.position1, 30);
						Manager.effects.PlayPuff(PuffID.SnowLinger, effectEvent.position1, 60);
						Manager.effects.PlayPuff(PuffID.SnowItemDust, effectEvent.position1, 30);
					}
					else
					{
						Manager.effects.PlayPuff(PuffID.Snowflakes, effectEvent.position1, 30);
						Manager.effects.PlayPuff(PuffID.SnowLinger, effectEvent.position1, 60);
						Manager.effects.PlayPuff(PuffID.SnowItemDust, effectEvent.position1, 30);
						AudioManager.Sfx(SfxTableID.christmasPresent, effectEvent.position1);
					}
					break;
				case Season.Valentine:
					if (effectEvent.value2 == 1)
					{
						Manager.effects.PlayPuff(PuffID.Hearts, effectEvent.position1, 30);
						break;
					}
					Manager.effects.PlayPuff(PuffID.Hearts, effectEvent.position1, 50);
					AudioManager.Sfx(SfxTableID.valentinePresent, effectEvent.position1);
					break;
				case Season.Easter:
					if (effectEvent.value2 == 1)
					{
						Manager.effects.PlayPuff(PuffID.LeafDebris, effectEvent.position1);
						break;
					}
					Manager.effects.PlayPuff(PuffID.LeafDebris, effectEvent.position1, 20);
					Manager.effects.PlayPuff(PuffID.Confetti, effectEvent.position1);
					Manager.effects.PlayPuff(PuffID.Confetti2, effectEvent.position1);
					AudioManager.Sfx(SfxID.bubble, effectEvent.position1, 1f, 0.8f, 0.1f);
					AudioManager.Sfx(SfxID.Dash, effectEvent.position1, 1f, 1f, 0.1f);
					break;
				case Season.Halloween:
					if (effectEvent.value2 == 1)
					{
						Manager.effects.PlayPuff(PuffID.HalloweenConfetti, effectEvent.position1);
						Manager.effects.PlayPuff(PuffID.HalloweenConfetti2, effectEvent.position1);
						break;
					}
					Manager.effects.PlayPuff(PuffID.HalloweenConfetti, effectEvent.position1, 20);
					Manager.effects.PlayPuff(PuffID.HalloweenConfetti2, effectEvent.position1, 20);
					AudioManager.Sfx(SfxID.bubble, effectEvent.position1, 1f, 0.8f, 0.1f);
					AudioManager.Sfx(SfxID.Dash, effectEvent.position1, 1f, 1f, 0.1f);
					break;
				default:
					if (effectEvent.value2 == 1)
					{
						Manager.effects.PlayPuff(PuffID.MerchantSpawn, effectEvent.position1);
						break;
					}
					Manager.effects.PlayPuff(PuffID.MerchantSpawn, effectEvent.position1);
					AudioManager.Sfx(SfxID.bubble, effectEvent.position1, 1f, 0.8f, 0.1f);
					AudioManager.Sfx(SfxID.Dash, effectEvent.position1, 1f, 1f, 0.1f);
					break;
				}
			}
			else if (effectEvent.value2 == 1)
			{
				Manager.effects.PlayPuff(PuffID.MerchantSpawn, effectEvent.position1);
			}
			else
			{
				Manager.effects.PlayPuff(PuffID.MerchantSpawn, effectEvent.position1);
				AudioManager.Sfx(SfxID.bubble, effectEvent.position1, 1f, 0.8f, 0.1f);
				AudioManager.Sfx(SfxID.Dash, effectEvent.position1, 1f, 1f, 0.1f);
			}
			break;
		case EffectID.ValentineEffect:
			Manager.effects.PlayPuff(PuffID.ValentineConfetti, effectEvent.position1, 20);
			Manager.effects.PlayPuff(PuffID.ValentineConfetti2, effectEvent.position1, 30);
			Manager.effects.PlayPuff(PuffID.Hearts, effectEvent.position1, 15);
			AudioManager.Sfx(SfxTableID.valentinePresent, effectEvent.position1);
			break;
		case EffectID.PlushieInteract:
		{
			AudioManager.Sfx(SfxTableID.plushie, effectEvent.position1);
			EntityMonoBehaviour entityMono10 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono10 != null)
			{
				entityMono10.animator.SetTrigger(-689712656);
			}
			break;
		}
		case EffectID.SqueakyToyInteract:
		{
			AudioManager.Sfx(SfxTableID.squeakyToy, effectEvent.position1);
			EntityMonoBehaviour entityMono9 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono9 != null)
			{
				entityMono9.animator.SetTrigger(-689712656);
			}
			break;
		}
		case EffectID.MagicMirrorEffect:
			AudioManager.Sfx(SfxTableID.magicMirror, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.EnergyPillarFlash, effectEvent.position1);
			break;
		case EffectID.MagicMirrorEffectWow:
			AudioManager.Sfx(SfxTableID.magicMirrorWow, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.ColorfulEnergyPillarFlash, effectEvent.position1);
			break;
		case EffectID.HatchBrownEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.EggBrownDebris, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchWhiteEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.EggWhiteDebris, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchGreenEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.EggGreenDebris, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchYellowEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.HatchYellowEgg, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchBlackEgg:
			Manager.effects.PlayPuff(PuffID.LavaStoneBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.HatchBlackEgg, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchBlueEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.HatchBlueEgg, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchOrangeEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.HatchOrangeEgg, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.HatchPurpleEgg:
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.HatchPurpleEgg, effectEvent.position1, 16);
			AudioManager.Sfx(SfxTableID.eggHatch, effectEvent.position1);
			break;
		case EffectID.PettingSound:
			AudioManager.Sfx(SfxTableID.pettingSound, effectEvent.position1);
			break;
		case EffectID.Hearts:
			Manager.effects.PlayPuff(PuffID.Hearts, effectEvent.position1, 25);
			AudioManager.Sfx(SfxID.bubble, effectEvent.position1, 1f, 0.8f, 0.1f);
			AudioManager.Sfx(SfxID.Dash, effectEvent.position1, 1f, 1f, 0.1f);
			break;
		case EffectID.useCattleCage:
			Manager.effects.PlayPuff(PuffID.CaptureAnimal, effectEvent.position1, 1);
			AudioManager.Sfx(SfxTableID.useCattleCage, effectEvent.position1);
			break;
		case EffectID.snailShellBreaking:
			Manager.effects.PlayPuff(PuffID.CrystalSolariteBigDebris, effectEvent.position1, 15);
			Manager.effects.PlayPuff(PuffID.CrystalSolariteSmallDebris, effectEvent.position1, 25);
			Manager.effects.PlayPuff(PuffID.CrystalSolariteDustSphere, effectEvent.position1, 35);
			AudioManager.Sfx(SfxTableID.crystalSnailShellBreaking, effectEvent.position1);
			break;
		case EffectID.SingingCrystalInteract:
			Manager.effects.PlayPuff(PuffID.SingingCrystalEffect, effectEvent.position1);
			AudioManager.Sfx(SfxTableID.singingCrystalInteract, effectEvent.position1);
			break;
		case EffectID.RoofingToolEffect:
			RoofingToolEffect.SpawnRoofingToolEffect(effectEvent.position1, effectEvent.value1 == 1);
			break;
		case EffectID.StrongAttackSound:
			AudioManager.Sfx(effectEvent.value1, effectEvent.position1, effectEvent.vector1.x, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
			break;
		case EffectID.SnakeBossEngage:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 100f)
			{
				AudioManager.Sfx(SfxTableID.snakeBossGrowl, Manager.main.player.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				Manager.camera.ShakeCameraNow(3f, 2f, 2f, null, null, 0, 3f);
			}
			break;
		case EffectID.BossDefeated:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 40f)
			{
				AudioManager.Sfx(SfxTableID.bossEnding, Manager.main.player.RenderPosition);
			}
			break;
		case EffectID.HydraBossEngage:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 100f)
			{
				AudioManager.Sfx(SfxTableID.hydraBossActivateGrowl, Manager.main.player.RenderPosition, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: true);
				Manager.camera.ShakeCameraNow(3f, 2f, 2f, null, null, 0, 3f);
			}
			break;
		case EffectID.ShortTeleportStart:
			AudioManager.Sfx(SfxTableID.ShortTeleportStart, effectEvent.position1);
			Manager.effects.PlayPuff(PuffID.RiftTeleportStart, effectEvent.position1);
			break;
		case EffectID.ShortTeleportEnd:
			Manager.effects.PlayPuff(PuffID.RiftTeleportStart, effectEvent.position1);
			break;
		case EffectID.SummonedWallBoss:
			Manager.effects.PlayPuff(PuffID.WallBossSummonPop, effectEvent.position1);
			break;
		case EffectID.Emote:
		{
			PlayerController playerController8 = Manager.memory.GetEntityMono(effectEvent.entity) as PlayerController;
			if (playerController8 != null)
			{
				Emote.SpawnEmoteText(playerController8.center, (Emote.EmoteType)effectEvent.value1);
			}
			break;
		}
		case EffectID.EquipmentBreak:
		{
			PlayerController playerController7 = Manager.memory.GetEntityMono(effectEvent.entity) as PlayerController;
			if (playerController7 != null)
			{
				playerController7.PlayEquipmentBreakSound();
			}
			break;
		}
		case EffectID.PetTeleport:
			Manager.effects.PlayPuff(PuffID.MerchantSpawn, effectEvent.position1);
			AudioManager.Sfx(SfxID.bubble, effectEvent.position1, 0.5f, 0.8f, 0.1f);
			AudioManager.Sfx(SfxID.Dash, effectEvent.position1, 0.5f, 1f, 0.1f);
			break;
		case EffectID.EmoteIcon:
		{
			PlayerController playerController5 = Manager.memory.GetEntityMono(effectEvent.entity) as PlayerController;
			if (playerController5 != null)
			{
				Emote.SpawnEmoteIcon(playerController5.RenderPosition, (Emote.EmoteIcon)effectEvent.value1, playerController5.transform, effectEvent.value2 == 1);
			}
			break;
		}
		case EffectID.PetGainExperience:
			if (EntityUtility.EntityExists(effectEvent.entity, Manager.ecs.ClientWorld))
			{
				CombatText.SpawnCombatText("experienceGained", CombatText.NumberColor.White, effectEvent.position1, isDamageNumber: false, isCrit: false, localize: true, new string[1] { effectEvent.value1.ToString() });
			}
			break;
		case EffectID.CaughtItemChatMessage:
		{
			string[] formatFields4 = new string[1] { PlayerController.GetObjectName(new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = (ObjectID)effectEvent.value1
				}
			}, localize: true).text };
			ObjectInfo objectInfo3 = PugDatabase.GetObjectInfo((ObjectID)effectEvent.value1);
			if (objectInfo3 != null)
			{
				Manager.ui.chatWindow.AddInfoText(formatFields4, objectInfo3.rarity, ChatWindow.MessageTextType.CaughtItem);
			}
			break;
		}
		case EffectID.ChatMessage:
			Manager.ui.chatWindow.AddInfoText((ChatWindow.MessageTextType)effectEvent.value1);
			break;
		case EffectID.GainedItemChatMessage:
		{
			string[] formatFields3 = new string[1] { PlayerController.GetObjectName(new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = (ObjectID)effectEvent.value1
				}
			}, localize: true).text };
			ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo((ObjectID)effectEvent.value1);
			if (objectInfo2 != null)
			{
				Manager.ui.chatWindow.AddInfoText(formatFields3, objectInfo2.rarity, ChatWindow.MessageTextType.GainedItem);
			}
			break;
		}
		case EffectID.ReceivedItemsChatMessage:
		{
			string[] formatFields2 = new string[2]
			{
				effectEvent.value2.ToString(),
				PlayerController.GetObjectName(new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = (ObjectID)effectEvent.value1
					}
				}, localize: true).text
			};
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo((ObjectID)effectEvent.value1);
			if (objectInfo != null)
			{
				Manager.ui.chatWindow.AddInfoText(formatFields2, objectInfo.rarity, ChatWindow.MessageTextType.ReceivedItems);
			}
			break;
		}
		case EffectID.PickUpCritter:
			AudioManager.Sfx(SfxID.twitch, effectEvent.position1, 0.3f, 0.8f, 0.1f, reuse: true);
			break;
		case EffectID.SingleAudioSFXFromTable:
		{
			EntityMonoBehaviour entityMono8 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono8 != null)
			{
				AudioManager.Sfx(effectEvent.value1, entityMono8.transform.position);
			}
			break;
		}
		case EffectID.SingleAudioSFX:
		{
			EntityMonoBehaviour entityMono7 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono7 != null)
			{
				float x2 = effectEvent.vector1.x;
				float y2 = effectEvent.vector1.y;
				float z2 = effectEvent.vector1.z;
				bool useSpatialSound = effectEvent.value2 == 1;
				AudioManager.Sfx((SfxID)effectEvent.value1, entityMono7.transform.position, x2, y2, z2, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound);
			}
			break;
		}
		case EffectID.SingleAudioFollowSFX:
		{
			EntityMonoBehaviour entityMono6 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono6 != null)
			{
				float x = effectEvent.vector1.x;
				float y = effectEvent.vector1.y;
				float z = effectEvent.vector1.z;
				AudioManager.SfxFollowTransform((SfxID)effectEvent.value1, entityMono6.transform, x, y, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, z);
			}
			break;
		}
		case EffectID.UpgradeSFX:
		{
			EntityMonoBehaviour entityMono5 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono5 != null)
			{
				AudioManager.Sfx(Manager.effects.GetUpgradeSfx(effectEvent.value1), entityMono5.transform.position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.UI);
			}
			break;
		}
		case EffectID.SingleAudioSFXUI:
			AudioManager.SfxUI(SfxID.metalImpactSmall, 0.6f, reuse: true, 0.7f, 0.1f);
			break;
		case EffectID.InfoTextObjectAndAmount:
		{
			Rarity rarity = (Rarity)effectEvent.vector1.x;
			ChatWindow.MessageTextType messageTextType = (ChatWindow.MessageTextType)effectEvent.vector1.y;
			int variation = (int)effectEvent.vector1.z;
			string[] formatFields = new string[2]
			{
				effectEvent.value2.ToString(),
				PlayerController.GetObjectName(new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = (ObjectID)effectEvent.value1,
						variation = variation
					}
				}, localize: true).text
			};
			Manager.ui.chatWindow.AddInfoText(formatFields, rarity, messageTextType);
			break;
		}
		case EffectID.PlayDamageEffect:
		{
			bool flag = effectEvent.value1 == 1;
			bool flag2 = effectEvent.value2 == 1;
			if (EntityUtility.TryGetComponentData<DamageEffectCD>(effectEvent.entity, world, out var value2))
			{
				value2.trigger++;
				EntityUtility.SetComponentData(effectEvent.entity, world, value2);
			}
			if (EntityUtility.HasComponentData<TookDamageStateCD>(effectEvent.entity, world) && (!EntityUtility.HasComponentData<EnemyCD>(effectEvent.entity, world) || flag) && (!flag2 || !EntityUtility.HasComponentData<SleepStateCD>(effectEvent.entity, world)))
			{
				EntityMonoBehaviour entityMono4 = Manager.memory.GetEntityMono(effectEvent.entity);
				if (entityMono4 != null && !EntityUtility.IsComponentEnabled<EntityDestroyedCD>(effectEvent.entity, world))
				{
					entityMono4.TryPlayAnimation(-1533413595);
				}
			}
			break;
		}
		case EffectID.EchoExplosion:
			AudioManager.Sfx(SfxTableID.EchoExplosion, effectEvent.position1);
			break;
		case EffectID.MinionTargetFlash:
		{
			EntityMonoBehaviour entityMono3 = Manager.memory.GetEntityMono(effectEvent.entity);
			if (entityMono3 != null)
			{
				entityMono3.FlashToDisplayAsMinionTarget();
			}
			break;
		}
		case EffectID.CommandMinionAttackSound:
			AudioManager.Sfx(SfxTableID.commandMinionAttack, effectEvent.position1);
			break;
		case EffectID.CommandMinionMoveArrow:
			Manager.effects.PlayPuff(PuffID.CommandMinionMoveArrow, effectEvent.position1, 1);
			AudioManager.Sfx(SfxTableID.commandMinionMove, effectEvent.position1);
			break;
		case EffectID.TriggerVoidBreach:
		{
			Vector3 zero = Vector3.zero;
			zero = ((!((PlayerController)Manager.memory.GetEntityMono(effectEvent.entity) != null)) ? ((Vector3)effectEvent.position1) : ((PlayerController)Manager.memory.GetEntityMono(effectEvent.entity)).transform.position);
			Manager.effects.PlayPuff(PuffID.VoidBreachBurst, zero, 20);
			AudioManager.Sfx(SfxID.rockDebris1, zero, 1f, 0.85f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(zero));
			Manager.camera.ShakeCameraNow(5f, 2f, 2f, null, null, 0, 3f);
			break;
		}
		case EffectID.AffixActivated:
		{
			EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(callerEntity);
			ConditionsEffectsHandler conditionsEffectsHandler = ((entityMono != null) ? entityMono.conditionEffectsHandler : null);
			if (conditionsEffectsHandler != null)
			{
				AffixID value = (AffixID)effectEvent.value1;
				conditionsEffectsHandler.PlayAffixActivationEffect(value);
			}
			break;
		}
		case EffectID.OpenChest:
			if (Manager.main.player != null && math.distance(Manager.main.player.RenderPosition, effectEvent.position1) < 10f)
			{
				AudioManager.Sfx(SfxTableID.uiOpenLockedChestSfx, effectEvent.position1, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
				Manager.effects.PlayPuff(PuffID.ShinyPuff, effectEvent.position1 + new float3(0f, 0.5f, 0f));
			}
			break;
		case EffectID.RemoteDetonatorExplosionSfx:
			Manager.audio.FadeOutAndStopSfx(SfxTableID.switchClickGenericSfx);
			AudioManager.Sfx(SfxID.remote_clicker_1_01, effectEvent.position1, 0.35f, 1f, 0.04f);
			AudioManager.Sfx(SfxID.remote_clicker_2_01, effectEvent.position1, 0.1f, 1f, 0.04f);
			break;
		case EffectID.ShieldOffHandSfx:
			AudioManager.Sfx(SfxTableID.uiOffHandShieldSfx, effectEvent.position1);
			break;
		case EffectID.None:
		case (EffectID)54:
		case (EffectID)55:
		case (EffectID)56:
			break;
		}
	}

	private static void PlayDamageEffectByType(EntityMonoBehaviour entityMonoPlayer, DamageEffectType damageEffectType)
	{
		if (damageEffectType == DamageEffectType.Electricity)
		{
			Manager.effects.PlayPuff(PuffID.ElectricHit, entityMonoPlayer.center, 5);
			AudioManager.Sfx(SfxTableID.electricProjectileImpact, entityMonoPlayer.center, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, null, forceStackable: false, 1f, 0f, 0.1f);
		}
	}

	private static bool GetEntityMonoRenderPosition(Entity entity, out Vector3 position)
	{
		position = Vector3.zero;
		EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(entity);
		if (entityMono == null)
		{
			return false;
		}
		position = entityMono.RenderPosition;
		return true;
	}

	private static bool GetEntityCombatTextPosition(Entity entity, out Vector3 position)
	{
		position = Vector3.zero;
		EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(entity);
		if (entityMono == null)
		{
			return false;
		}
		position = entityMono.combatTextPosition;
		return true;
	}

	private static void PlaceObject(EffectEventCD effectEvent)
	{
		int value = effectEvent.value1;
		AudioManager.Sfx(SfxID.shoop, effectEvent.position1, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
		if (value == 110)
		{
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 1);
		}
		else
		{
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 3);
		}
		if (Manager.multiMap.GetTileLayerLookup().GetTopTile(Manager.camera.RenderOrigo.ToInt2() + effectEvent.position1.RoundToInt2()).tileType == TileType.water)
		{
			EntityMonoBehaviour.TryAddWaterImpulseForObject(PugDatabase.GetObjectInfo((ObjectID)effectEvent.value1), effectEvent.position1, effectEvent.vector1);
		}
		Manager.effects.EnablePlacedObjectEffectsAtPosition(effectEvent.position1 + Manager.camera.RenderOrigo.ToFloat3());
	}

	private static void PlaceTile(EffectEventCD effectEvent)
	{
		AudioManager.Sfx(SfxID.shoop, effectEvent.position1, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 6);
		TileType value = (TileType)effectEvent.value1;
		switch (value)
		{
		case TileType.wall:
		case TileType.ground:
		{
			bool isGround = value == TileType.ground;
			Manager.effects.WobbleAtPosition(ExtensionMethods.RoundToInt(effectEvent.position1), 1f, isGround);
			break;
		}
		case TileType.bridge:
			WaterSim.AddImpulse(effectEvent.position1, 1f, 2f);
			break;
		}
	}

	private static void PlaceCritter(EffectEventCD effectEvent)
	{
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, effectEvent.position1, 2);
		AudioManager.Sfx(SfxID.shoop, effectEvent.position1, 0.6f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, ShouldPlayAudioAndRumbleOnGamepad(effectEvent.position1));
	}

	private static void DamageTile(EffectEventCD effectEvent, bool weakHit)
	{
		TileType tileType = effectEvent.tileInfo.tileType;
		int tileset = effectEvent.tileInfo.tileset;
		float3 position = effectEvent.position1;
		position.y = 0f;
		ObjectInfo objectInfo = PugDatabase.TryGetTileItemInfo(tileType, tileset);
		ObjectDataCD objectData = ((objectInfo != null) ? new ObjectDataCD
		{
			objectID = objectInfo.objectID,
			variation = objectInfo.variation
		} : default(ObjectDataCD));
		if (PugDatabase.HasComponent<TileEffectCD>(objectData))
		{
			TileEffectCD component = PugDatabase.GetComponent<TileEffectCD>(objectData);
			bool playOnGamepad = ShouldPlayAudioAndRumbleOnGamepad(position);
			if (tileType == TileType.wall && weakHit)
			{
				AudioManager.Sfx(SfxTableID.weakHit, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad, null, forceStackable: true);
			}
			else if (component.sfxTableDamageId != 0)
			{
				AudioManager.Sfx(component.sfxTableDamageId, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad);
			}
			else
			{
				AudioManager.Sfx(SfxTableID.defaultTileDamage, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad, null, forceStackable: true);
			}
			if (tileType.IsContainedResource())
			{
				AudioManager.Sfx(SfxTableID.oreHit, position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad, null, forceStackable: true);
			}
		}
		switch (tileType)
		{
		case TileType.groundSlime:
			switch (tileset)
			{
			case 8:
				Manager.effects.PlayPuff(PuffID.PoisonSlimeExplosion, position);
				Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepPoison, new Vector3(position.x, 0.02f, position.z), 0.33f, 0.5f);
				break;
			case 6:
				Manager.effects.PlayPuff(PuffID.AcidPuff, position);
				Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepAcid, new Vector3(position.x, 0.02f, position.z), 0.33f, 0.5f);
				break;
			case 10:
				Manager.effects.PlayPuff(PuffID.SmallBluePuff, position);
				Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepBlueSplat, new Vector3(position.x, 0.02f, position.z), 0.33f, 0.5f);
				break;
			case 69:
				Manager.effects.PlayPuff(PuffID.SmallBlackPuff, position);
				Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepOilSplat, new Vector3(position.x, 0.02f, position.z), 0.33f, 0.5f);
				break;
			default:
				Manager.effects.PlayPuff(PuffID.SlimeExplosion, position);
				Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepSlime, new Vector3(position.x, 0.02f, position.z), 0.33f, 0.5f);
				break;
			}
			break;
		case TileType.circuitPlate:
		case TileType.floor:
		case TileType.rug:
		case TileType.rail:
		case TileType.litFloor:
		case TileType.looseFlooring:
		case TileType.chrysalis:
			PlayGroundWobble(effectEvent, position);
			break;
		case TileType.bridge:
			PlayGroundWobble(effectEvent, position);
			WaterSim.AddImpulse(position);
			break;
		case TileType.ore:
		case TileType.ancientCrystal:
			Manager.effects.WobbleAtPosition(ExtensionMethods.RoundToInt(position), weakHit ? 0.5f : 1f);
			break;
		case TileType.ground:
			Manager.effects.WobbleAtPosition(ExtensionMethods.RoundToInt(position), 1f, isGround: true);
			break;
		case TileType.wall:
			Manager.effects.WobbleAtPosition(ExtensionMethods.RoundToInt(position), weakHit ? 0.5f : 1f);
			break;
		default:
			Manager.effects.WobbleAtPosition(ExtensionMethods.RoundToInt(position), weakHit ? 0.5f : 1f);
			break;
		}
	}

	private static void PlayGroundWobble(EffectEventCD effectEvent, float3 position)
	{
		if (Manager.multiMap.GetTileLayerLookup().GetTopTile(Manager.camera.RenderOrigo.ToInt2() + position.RoundToInt2()).tileType != effectEvent.tileInfo.tileType)
		{
			Debug.LogWarning("Server delay caused PlayGroundWobble to not play");
			return;
		}
		Material material;
		Sprite spriteOfSurfaceTile = Manager.multiMap.GetSpriteOfSurfaceTile(Manager.camera.RenderOrigo.ToInt2() + effectEvent.position1.RoundToInt2(), out material);
		damagedGroundTile freeComponent = Manager.memory.GetFreeComponent<damagedGroundTile>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.transform.position = position;
			freeComponent.SR.sprite = spriteOfSurfaceTile;
			freeComponent.SR.material = material;
			freeComponent.OnOccupied();
		}
		else
		{
			Debug.LogError("failed to instantiate damagedGroundTile");
		}
	}

	private static void RefillEffects(float3 position1, float3 position2, PuffID[] inputPuffs, int tempSprite)
	{
		Manager.effects.PlayPuff(inputPuffs[0], position1, 8);
		Manager.effects.PlayPuff(inputPuffs[0], position2);
		Manager.effects.PlayPuff(inputPuffs[1], position1);
		Manager.effects.PlayPuff(inputPuffs[2], position2, 1);
		Manager.effects.PlayTempSprite(tempSprite, position2, 1f, 0.5f);
	}

	private static void WaterSplashEffects(float3 position1, PuffID[] inputPuffs, int tempSprite, int optionalSizeVariation = 0)
	{
		Manager.effects.PlayPuff(inputPuffs[0], position1, 15, guaranteedToPlay: false, optionalSizeVariation);
		Manager.effects.PlayPuff(inputPuffs[1], position1, 1, guaranteedToPlay: false, optionalSizeVariation);
		Manager.effects.PlayTempSprite(tempSprite, position1, 1f, 0.5f);
	}

	private static void SmallWaterSplashEffects(float3 position1, PuffID[] inputPuffs, int tempSprite)
	{
		Manager.effects.PlayPuff(inputPuffs[0], position1, 15);
		Manager.effects.PlayPuff(inputPuffs[1], position1, 1);
		Manager.effects.PlayTempSprite(tempSprite, position1, 0.6f, 0.5f);
	}

	public static EffectEventCD CreateSingleAudioSFX(bool localOnlyEffect, SfxID sfxID, Entity entity, float volume = 1f, float pitch = 1f, float pitchDev = 0f, bool useSpatialSound = true)
	{
		return new EffectEventCD
		{
			localOnlyEffect = (byte)(localOnlyEffect ? 1 : 0),
			effectID = EffectID.SingleAudioSFX,
			entity = entity,
			value1 = (int)sfxID,
			vector1 = new float3(volume, pitch, pitchDev),
			value2 = (useSpatialSound ? 1 : 0)
		};
	}

	public static EffectEventCD CreateSingleAudioFollowSFX(bool localOnlyEffect, SfxID sfxID, Entity entity, float volume = 1f, float pitch = 1f, float maxSpatialDistance = 16f)
	{
		return new EffectEventCD
		{
			localOnlyEffect = (byte)(localOnlyEffect ? 1 : 0),
			effectID = EffectID.SingleAudioFollowSFX,
			entity = entity,
			value1 = (int)sfxID,
			vector1 = new float3(volume, pitch, maxSpatialDistance)
		};
	}

	public static EffectEventCD CreateSingleAudioSFXUI(bool localOnlyEffect, SfxID sfxID, float volume = 1f, float pitch = 1f, float pitchDev = 0.15f)
	{
		return new EffectEventCD
		{
			localOnlyEffect = (byte)(localOnlyEffect ? 1 : 0),
			effectID = EffectID.SingleAudioSFXUI,
			value1 = (int)sfxID,
			vector1 = new float3(volume, pitch, pitchDev)
		};
	}

	public static EffectEventCD CreateInfoTextItemAndAmount(ChatWindow.MessageTextType messageTextType, ObjectID objectID, int variation, int amount, Rarity rarity)
	{
		return new EffectEventCD
		{
			localOnlyEffect = 1,
			effectID = EffectID.InfoTextObjectAndAmount,
			value1 = (int)objectID,
			value2 = amount,
			vector1 = new float3((float)rarity, (float)messageTextType, variation)
		};
	}

	public static bool ShouldPlayAudioAndRumbleOnGamepad(float3 renderPosition)
	{
		if (Manager.main.player != null)
		{
			return math.distancesq(Manager.main.player.RenderPosition, renderPosition) < 25f;
		}
		return false;
	}

	public static void PlayDynamicBubbleExplosion(float3 renderPosition, TileInfo tileInfo)
	{
		AudioManager.Sfx(SfxTableID.BubbleExplosion, renderPosition);
		bool flag = tileInfo.tileset == 6;
		bool num = tileInfo.tileset == 9;
		bool flag2 = tileInfo.tileset == 3;
		if (num)
		{
			PuffID[] inputPuffs = new PuffID[2]
			{
				PuffID.SmallMoldWaterSplash,
				PuffID.MoldWaterRipple
			};
			WaterSplashEffects(renderPosition, inputPuffs, SpriteTempEffectID.WaterSplashMold, 1);
		}
		else if (flag)
		{
			PuffID[] inputPuffs2 = new PuffID[2]
			{
				PuffID.SmallYellowWaterSplash,
				PuffID.YellowWaterRipple
			};
			WaterSplashEffects(renderPosition, inputPuffs2, SpriteTempEffectID.WaterSplashYellow, 1);
		}
		else if (flag2)
		{
			PuffID[] inputPuffs3 = new PuffID[2]
			{
				PuffID.SmallLavaSplash,
				PuffID.LavaRipple
			};
			WaterSplashEffects(renderPosition, inputPuffs3, SpriteTempEffectID.WaterSplashYellow, 1);
		}
		else
		{
			PuffID[] inputPuffs4 = new PuffID[2]
			{
				PuffID.SmallWaterSplash,
				PuffID.WaterRipple
			};
			WaterSplashEffects(renderPosition, inputPuffs4, SpriteTempEffectID.WaterSplash, 1);
		}
	}
}
