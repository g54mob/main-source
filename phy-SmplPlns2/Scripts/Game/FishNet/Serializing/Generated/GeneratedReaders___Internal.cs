using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.Character.Suit;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Environment;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using Assets.Scripts.Multiplayer.Messages;
using Assets.Scripts.Multiplayer.Utils;
using UnityEngine;

namespace FishNet.Serializing.Generated
{
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	public static class GeneratedReaders___Internal
	{
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeOnce()
		{
			GenericReader<Vector3d>.SetRead(CustomSerializers.ReadVector3d);
			GenericReader<NetworkConnectionAuthenticator.ClientConnectionData>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FClientConnectionDataFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkConnectionAuthenticator.SerializableVersion>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkConnectionAuthenticator.ConnectionResponseData>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionResponseDataFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkConnectionAuthenticator.ConnectionFailedType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionFailedTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<CreateExplosionsMessage>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerateds);
			GenericReader<CreateExplosionInfo>.SetRead(GRead___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerateds);
			GenericReader<int?>.SetRead(GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<Vector3?>.SetRead(GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<ExplosiveWeaponImpactType>.SetRead(GRead___Assets_002EScripts_002EFlight_002EExplosions_002EExplosiveWeaponImpactTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<List<CreateExplosionInfo>>.SetRead(GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002EFlight_002ECreateExplosionInfo_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkFlightObjectSpawnerType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ESpawners_002ENetworkFlightObjectSpawnerTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<FlightSceneClientRpcType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<FlightSceneServerRpcType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<WeatherPreset>.SetRead(GRead___Assets_002EScripts_002EEnvironment_002EWeatherPresetFishNet_002ESerializing_002EGenerateds);
			GenericReader<PartDamageEffects.DamageEffectType>.SetRead(GRead___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<TargetAlertType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<DamageEventArgs>.SetRead(GRead___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerateds);
			GenericReader<ushort?>.SetRead(GRead___System_002ENullable_00601_003CSystem_002EUInt16_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<CharacterSuitData>.SetRead(GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerateds);
			GenericReader<CharacterSuitData.CharacterSuitItemData>.SetRead(GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemDataFishNet_002ESerializing_002EGenerateds);
			GenericReader<CharacterSuitData.SuitItemDataColor>.SetRead(GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColorFishNet_002ESerializing_002EGenerateds);
			GenericReader<List<CharacterSuitData.SuitItemDataColor>>.SetRead(GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColor_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<List<CharacterSuitData.CharacterSuitItemData>>.SetRead(GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemData_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<int[]>.SetRead(GRead___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerateds);
			GenericReader<float?>.SetRead(GRead___System_002ENullable_00601_003CSystem_002ESingle_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkAircraftScript>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityState>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityStateFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityPlayerState>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.ChangePlayerStateRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FChangePlayerStateRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.AsyncResult>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.AsyncResult.ResultType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResult_002FResultTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.EndActivityForPlayerRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FEndActivityForPlayerRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.JoinActivityRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinActivityRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityTeamIds>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.JoinTeamRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinTeamRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityTeamIds?>.SetRead(GRead___System_002ENullable_00601_003CAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIds_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.PlayerCraftBoundsRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FPlayerCraftBoundsRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.CraftBoundsAsyncResult>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FCraftBoundsAsyncResultFishNet_002ESerializing_002EGenerateds);
			GenericReader<CraftLocalBounds>.SetRead(GRead___Assets_002EScripts_002ECraft_002ECraftLocalBoundsFishNet_002ESerializing_002EGenerateds);
			GenericReader<CraftLocalBounds?>.SetRead(GRead___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.SpawnLocationRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.SpawnLocationAsyncResult>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationAsyncResultFishNet_002ESerializing_002EGenerateds);
			GenericReader<StartLocationData>.SetRead(GRead___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationDataFishNet_002ESerializing_002EGenerateds);
			GenericReader<StartLocationType>.SetRead(GRead___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<bool?>.SetRead(GRead___System_002ENullable_00601_003CSystem_002EBoolean_003EFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.StartActivityForPlayerRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FStartActivityForPlayerRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.ActivityTimerType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FActivityTimerTypeFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.WaitForAllPlayersEndedRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersEndedRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.WaitForAllPlayersStartedRequest>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersStartedRequestFishNet_002ESerializing_002EGenerateds);
			GenericReader<NetworkedActivityScript.UpdateScoreType>.SetRead(GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerateds);
		}

		public static NetworkConnectionAuthenticator.ClientConnectionData GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FClientConnectionDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkConnectionAuthenticator.ClientConnectionData
			{
				PasswordHash = reader.ReadStringAllocated(),
				SteamId = reader.ReadUInt64(),
				UserName = reader.ReadStringAllocated(),
				Version = GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkConnectionAuthenticator.SerializableVersion GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkConnectionAuthenticator.SerializableVersion
			{
				Build = reader.ReadInt32(),
				Major = reader.ReadInt32(),
				Minor = reader.ReadInt32(),
				Revision = reader.ReadInt32()
			};
		}

		public static NetworkConnectionAuthenticator.ConnectionResponseData GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionResponseDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkConnectionAuthenticator.ConnectionResponseData
			{
				ConnectionFailedType = GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionFailedTypeFishNet_002ESerializing_002EGenerateds(reader),
				ConnectionSuccessful = reader.ReadBoolean(),
				ServerVersion = GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkConnectionAuthenticator.ConnectionFailedType GRead___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionFailedTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkConnectionAuthenticator.ConnectionFailedType)reader.ReadInt32();
		}

		public static CreateExplosionsMessage GRead___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			CreateExplosionsMessage createExplosionsMessage = new CreateExplosionsMessage();
			createExplosionsMessage.Explosions = GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002EFlight_002ECreateExplosionInfo_003EFishNet_002ESerializing_002EGenerateds(reader);
			return createExplosionsMessage;
		}

		public static CreateExplosionInfo GRead___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			CreateExplosionInfo createExplosionInfo = new CreateExplosionInfo();
			createExplosionInfo.AttackerPlayerId = GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(reader);
			createExplosionInfo.BlastDirection = GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(reader);
			createExplosionInfo.ExplosionPrefabName = reader.ReadStringAllocated();
			createExplosionInfo.ExplosionScale = reader.ReadSingle();
			createExplosionInfo.GlobalPosition = reader.ReadVector3d();
			createExplosionInfo.ImpactDirection = GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(reader);
			createExplosionInfo.ImpactType = GRead___Assets_002EScripts_002EFlight_002EExplosions_002EExplosiveWeaponImpactTypeFishNet_002ESerializing_002EGenerateds(reader);
			return createExplosionInfo;
		}

		public static int? GRead___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return reader.ReadInt32();
		}

		public static Vector3? GRead___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return reader.ReadVector3();
		}

		public static ExplosiveWeaponImpactType GRead___Assets_002EScripts_002EFlight_002EExplosions_002EExplosiveWeaponImpactTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (ExplosiveWeaponImpactType)reader.ReadInt32();
		}

		public static List<CreateExplosionInfo> GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002EFlight_002ECreateExplosionInfo_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return reader.ReadList<CreateExplosionInfo>();
		}

		public static NetworkFlightObjectSpawnerType GRead___Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ESpawners_002ENetworkFlightObjectSpawnerTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkFlightObjectSpawnerType)reader.ReadUInt8Unpacked();
		}

		public static FlightSceneClientRpcType GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (FlightSceneClientRpcType)reader.ReadUInt8Unpacked();
		}

		public static FlightSceneServerRpcType GRead___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (FlightSceneServerRpcType)reader.ReadUInt8Unpacked();
		}

		public static WeatherPreset GRead___Assets_002EScripts_002EEnvironment_002EWeatherPresetFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (WeatherPreset)reader.ReadInt32();
		}

		public static PartDamageEffects.DamageEffectType GRead___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (PartDamageEffects.DamageEffectType)reader.ReadInt32();
		}

		public static TargetAlertType GRead___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (TargetAlertType)reader.ReadInt32();
		}

		public static DamageEventArgs GRead___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return new DamageEventArgs();
		}

		public static ushort? GRead___System_002ENullable_00601_003CSystem_002EUInt16_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return reader.ReadUInt16();
		}

		public static CharacterSuitData GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			CharacterSuitData characterSuitData = new CharacterSuitData();
			characterSuitData.Items = GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemData_003EFishNet_002ESerializing_002EGenerateds(reader);
			return characterSuitData;
		}

		public static CharacterSuitData.CharacterSuitItemData GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			CharacterSuitData.CharacterSuitItemData characterSuitItemData = new CharacterSuitData.CharacterSuitItemData();
			characterSuitItemData.Colors = GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColor_003EFishNet_002ESerializing_002EGenerateds(reader);
			characterSuitItemData.Enabled = reader.ReadBoolean();
			characterSuitItemData.Name = reader.ReadStringAllocated();
			return characterSuitItemData;
		}

		public static CharacterSuitData.SuitItemDataColor GRead___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColorFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			CharacterSuitData.SuitItemDataColor suitItemDataColor = new CharacterSuitData.SuitItemDataColor();
			suitItemDataColor.Color = reader.ReadColor();
			suitItemDataColor.Index = reader.ReadInt32();
			return suitItemDataColor;
		}

		public static List<CharacterSuitData.SuitItemDataColor> GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColor_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return reader.ReadList<CharacterSuitData.SuitItemDataColor>();
		}

		public static List<CharacterSuitData.CharacterSuitItemData> GRead___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemData_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return reader.ReadList<CharacterSuitData.CharacterSuitItemData>();
		}

		public static int[] GRead___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return reader.ReadArrayAllocated<int>();
		}

		public static float? GRead___System_002ENullable_00601_003CSystem_002ESingle_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return reader.ReadSingle();
		}

		public static NetworkAircraftScript GRead___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkAircraftScript)reader.ReadNetworkBehaviour();
		}

		public static NetworkedActivityState GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityStateFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkedActivityState)reader.ReadUInt8Unpacked();
		}

		public static NetworkedActivityPlayerState GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkedActivityPlayerState)reader.ReadUInt8Unpacked();
		}

		public static NetworkedActivityScript.ChangePlayerStateRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FChangePlayerStateRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.ChangePlayerStateRequest
			{
				ExcludeOwner = reader.ReadBoolean(),
				PlayerId = reader.ReadInt32(),
				State = GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkedActivityScript.AsyncResult GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.AsyncResult
			{
				Message = reader.ReadStringAllocated(),
				Type = GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResult_002FResultTypeFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkedActivityScript.AsyncResult.ResultType GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResult_002FResultTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkedActivityScript.AsyncResult.ResultType)reader.ReadInt32();
		}

		public static NetworkedActivityScript.EndActivityForPlayerRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FEndActivityForPlayerRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.EndActivityForPlayerRequest
			{
				PlayerId = reader.ReadInt32()
			};
		}

		public static NetworkedActivityScript.JoinActivityRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinActivityRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.JoinActivityRequest
			{
				PlayerId = reader.ReadInt32()
			};
		}

		public static NetworkedActivityTeamIds GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkedActivityTeamIds)reader.ReadUInt8Unpacked();
		}

		public static NetworkedActivityScript.JoinTeamRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinTeamRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.JoinTeamRequest
			{
				PlayerId = reader.ReadInt32(),
				TeamId = GRead___System_002ENullable_00601_003CAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIds_003EFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkedActivityTeamIds? GRead___System_002ENullable_00601_003CAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIds_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerateds(reader);
		}

		public static NetworkedActivityScript.PlayerCraftBoundsRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FPlayerCraftBoundsRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.PlayerCraftBoundsRequest
			{
				InitialBounds = reader.ReadBoolean(),
				PlayerId = reader.ReadInt32()
			};
		}

		public static NetworkedActivityScript.CraftBoundsAsyncResult GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FCraftBoundsAsyncResultFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.CraftBoundsAsyncResult
			{
				Data = GRead___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerateds(reader),
				Message = reader.ReadStringAllocated()
			};
		}

		public static CraftLocalBounds GRead___Assets_002EScripts_002ECraft_002ECraftLocalBoundsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new CraftLocalBounds
			{
				Offset = reader.ReadVector3(),
				Size = reader.ReadVector3()
			};
		}

		public static CraftLocalBounds? GRead___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return GRead___Assets_002EScripts_002ECraft_002ECraftLocalBoundsFishNet_002ESerializing_002EGenerateds(reader);
		}

		public static NetworkedActivityScript.SpawnLocationRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.SpawnLocationRequest
			{
				Bounds = GRead___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerateds(reader),
				InitialSpawn = reader.ReadBoolean(),
				PlayerId = reader.ReadInt32()
			};
		}

		public static NetworkedActivityScript.SpawnLocationAsyncResult GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationAsyncResultFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.SpawnLocationAsyncResult
			{
				Data = GRead___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationDataFishNet_002ESerializing_002EGenerateds(reader),
				Message = reader.ReadStringAllocated()
			};
		}

		public static StartLocationData GRead___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			StartLocationData startLocationData = new StartLocationData();
			startLocationData.AreaName = reader.ReadStringAllocated();
			startLocationData.Description = reader.ReadStringAllocated();
			startLocationData.DisplayName = reader.ReadStringAllocated();
			startLocationData.DistributionAxis = reader.ReadVector3();
			startLocationData.DynamicLocationId = reader.ReadStringAllocated();
			startLocationData.Id = reader.ReadStringAllocated();
			startLocationData.InitialSpeed = reader.ReadSingle();
			startLocationData.InitialThrottle = reader.ReadSingle();
			startLocationData.InitialVelocity = reader.ReadVector3();
			startLocationData.IsRunwayTakeoff = reader.ReadBoolean();
			startLocationData.LocationType = GRead___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationTypeFishNet_002ESerializing_002EGenerateds(reader);
			startLocationData.MaxDistributionAmount = reader.ReadSingle();
			startLocationData.OverflowLocation = reader.ReadStringAllocated();
			startLocationData.Position = reader.ReadVector3();
			startLocationData.Rotation = reader.ReadVector3();
			startLocationData.StartOnGround = GRead___System_002ENullable_00601_003CSystem_002EBoolean_003EFishNet_002ESerializing_002EGenerateds(reader);
			return startLocationData;
		}

		public static StartLocationType GRead___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (StartLocationType)reader.ReadInt32();
		}

		public static bool? GRead___System_002ENullable_00601_003CSystem_002EBoolean_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			if (reader.ReadBoolean())
			{
				return null;
			}
			return reader.ReadBoolean();
		}

		public static NetworkedActivityScript.StartActivityForPlayerRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FStartActivityForPlayerRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.StartActivityForPlayerRequest
			{
				PlayerId = reader.ReadInt32()
			};
		}

		public static NetworkedActivityScript.ActivityTimerType GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FActivityTimerTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkedActivityScript.ActivityTimerType)reader.ReadInt32();
		}

		public static NetworkedActivityScript.WaitForAllPlayersEndedRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersEndedRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.WaitForAllPlayersEndedRequest
			{
				PlayerIds = GRead___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkedActivityScript.WaitForAllPlayersStartedRequest GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersStartedRequestFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return new NetworkedActivityScript.WaitForAllPlayersStartedRequest
			{
				PlayerIds = GRead___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerateds(reader)
			};
		}

		public static NetworkedActivityScript.UpdateScoreType GRead___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return (NetworkedActivityScript.UpdateScoreType)reader.ReadUInt8Unpacked();
		}
	}
}
