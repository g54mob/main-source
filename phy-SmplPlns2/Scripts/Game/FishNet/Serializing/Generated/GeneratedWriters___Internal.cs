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
	public static class GeneratedWriters___Internal
	{
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeOnce()
		{
			GenericWriter<Vector3d>.SetWrite(CustomSerializers.WriteVector3d);
			GenericWriter<NetworkConnectionAuthenticator.ClientConnectionData>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FClientConnectionDataFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkConnectionAuthenticator.SerializableVersion>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkConnectionAuthenticator.ConnectionResponseData>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionResponseDataFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkConnectionAuthenticator.ConnectionFailedType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionFailedTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<CreateExplosionsMessage>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerated);
			GenericWriter<CreateExplosionInfo>.SetWrite(GWrite___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerated);
			GenericWriter<int?>.SetWrite(GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<Vector3?>.SetWrite(GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<ExplosiveWeaponImpactType>.SetWrite(GWrite___Assets_002EScripts_002EFlight_002EExplosions_002EExplosiveWeaponImpactTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<List<CreateExplosionInfo>>.SetWrite(GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002EFlight_002ECreateExplosionInfo_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkFlightObjectSpawnerType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ESpawners_002ENetworkFlightObjectSpawnerTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<byte[]>.SetWrite(GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated);
			GenericWriter<FlightSceneClientRpcType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<FlightSceneServerRpcType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<WeatherPreset>.SetWrite(GWrite___Assets_002EScripts_002EEnvironment_002EWeatherPresetFishNet_002ESerializing_002EGenerated);
			GenericWriter<PartDamageEffects.DamageEffectType>.SetWrite(GWrite___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<TargetAlertType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<DamageEventArgs>.SetWrite(GWrite___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerated);
			GenericWriter<ushort?>.SetWrite(GWrite___System_002ENullable_00601_003CSystem_002EUInt16_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<CharacterSuitData>.SetWrite(GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerated);
			GenericWriter<CharacterSuitData.CharacterSuitItemData>.SetWrite(GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemDataFishNet_002ESerializing_002EGenerated);
			GenericWriter<CharacterSuitData.SuitItemDataColor>.SetWrite(GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColorFishNet_002ESerializing_002EGenerated);
			GenericWriter<List<CharacterSuitData.SuitItemDataColor>>.SetWrite(GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColor_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<List<CharacterSuitData.CharacterSuitItemData>>.SetWrite(GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemData_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<int[]>.SetWrite(GWrite___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerated);
			GenericWriter<float?>.SetWrite(GWrite___System_002ENullable_00601_003CSystem_002ESingle_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkAircraftScript>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityState>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityStateFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityPlayerState>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.ChangePlayerStateRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FChangePlayerStateRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.AsyncResult>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.AsyncResult.ResultType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResult_002FResultTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.EndActivityForPlayerRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FEndActivityForPlayerRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.JoinActivityRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinActivityRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityTeamIds>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.JoinTeamRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinTeamRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityTeamIds?>.SetWrite(GWrite___System_002ENullable_00601_003CAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIds_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.PlayerCraftBoundsRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FPlayerCraftBoundsRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.CraftBoundsAsyncResult>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FCraftBoundsAsyncResultFishNet_002ESerializing_002EGenerated);
			GenericWriter<CraftLocalBounds>.SetWrite(GWrite___Assets_002EScripts_002ECraft_002ECraftLocalBoundsFishNet_002ESerializing_002EGenerated);
			GenericWriter<CraftLocalBounds?>.SetWrite(GWrite___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.SpawnLocationRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.SpawnLocationAsyncResult>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationAsyncResultFishNet_002ESerializing_002EGenerated);
			GenericWriter<StartLocationData>.SetWrite(GWrite___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationDataFishNet_002ESerializing_002EGenerated);
			GenericWriter<StartLocationType>.SetWrite(GWrite___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<bool?>.SetWrite(GWrite___System_002ENullable_00601_003CSystem_002EBoolean_003EFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.StartActivityForPlayerRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FStartActivityForPlayerRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.ActivityTimerType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FActivityTimerTypeFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.WaitForAllPlayersEndedRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersEndedRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.WaitForAllPlayersStartedRequest>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersStartedRequestFishNet_002ESerializing_002EGenerated);
			GenericWriter<NetworkedActivityScript.UpdateScoreType>.SetWrite(GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerated);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FClientConnectionDataFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkConnectionAuthenticator.ClientConnectionData value)
		{
			writer.WriteString(value.PasswordHash);
			writer.WriteUInt64(value.SteamId);
			writer.WriteString(value.UserName);
			GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerated(writer, value.Version);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkConnectionAuthenticator.SerializableVersion value)
		{
			writer.WriteInt32(value.Build);
			writer.WriteInt32(value.Major);
			writer.WriteInt32(value.Minor);
			writer.WriteInt32(value.Revision);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionResponseDataFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkConnectionAuthenticator.ConnectionResponseData value)
		{
			GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionFailedTypeFishNet_002ESerializing_002EGenerated(writer, value.ConnectionFailedType);
			writer.WriteBoolean(value.ConnectionSuccessful);
			GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FSerializableVersionFishNet_002ESerializing_002EGenerated(writer, value.ServerVersion);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkConnectionAuthenticator_002FConnectionFailedTypeFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkConnectionAuthenticator.ConnectionFailedType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EMessages_002ECreateExplosionsMessageFishNet_002ESerializing_002EGenerated(this Writer writer, CreateExplosionsMessage value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002EFlight_002ECreateExplosionInfo_003EFishNet_002ESerializing_002EGenerated(writer, value.Explosions);
		}

		public static void GWrite___Assets_002EScripts_002EFlight_002ECreateExplosionInfoFishNet_002ESerializing_002EGenerated(this Writer writer, CreateExplosionInfo value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(writer, value.AttackerPlayerId);
			GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(writer, value.BlastDirection);
			writer.WriteString(value.ExplosionPrefabName);
			writer.WriteSingle(value.ExplosionScale);
			writer.WriteVector3d(value.GlobalPosition);
			GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(writer, value.ImpactDirection);
			GWrite___Assets_002EScripts_002EFlight_002EExplosions_002EExplosiveWeaponImpactTypeFishNet_002ESerializing_002EGenerated(writer, value.ImpactType);
		}

		public static void GWrite___System_002ENullable_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(this Writer writer, int? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteInt32(value.Value);
		}

		public static void GWrite___System_002ENullable_00601_003CUnityEngine_002EVector3_003EFishNet_002ESerializing_002EGenerated(this Writer writer, Vector3? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteVector3(value.Value);
		}

		public static void GWrite___Assets_002EScripts_002EFlight_002EExplosions_002EExplosiveWeaponImpactTypeFishNet_002ESerializing_002EGenerated(this Writer writer, ExplosiveWeaponImpactType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002EFlight_002ECreateExplosionInfo_003EFishNet_002ESerializing_002EGenerated(this Writer writer, List<CreateExplosionInfo> value)
		{
			writer.WriteList(value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EFlightObjects_002ESpawners_002ENetworkFlightObjectSpawnerTypeFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkFlightObjectSpawnerType value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}

		public static void GWrite___System_002EByte_005B_005DFishNet_002ESerializing_002EGenerated(this Writer writer, byte[] value)
		{
			writer.WriteArray(value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneClientRpcTypeFishNet_002ESerializing_002EGenerated(this Writer writer, FlightSceneClientRpcType value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EFlightSceneServerRpcTypeFishNet_002ESerializing_002EGenerated(this Writer writer, FlightSceneServerRpcType value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}

		public static void GWrite___Assets_002EScripts_002EEnvironment_002EWeatherPresetFishNet_002ESerializing_002EGenerated(this Writer writer, WeatherPreset value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___Assets_002EScripts_002ECraft_002EParts_002EPartDamageEffects_002FDamageEffectTypeFishNet_002ESerializing_002EGenerated(this Writer writer, PartDamageEffects.DamageEffectType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002ETargetAlertTypeFishNet_002ESerializing_002EGenerated(this Writer writer, TargetAlertType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerated(this Writer writer, DamageEventArgs value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
			}
			else
			{
				writer.WriteBoolean(value: false);
			}
		}

		public static void GWrite___System_002ENullable_00601_003CSystem_002EUInt16_003EFishNet_002ESerializing_002EGenerated(this Writer writer, ushort? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteUInt16(value.Value);
		}

		public static void GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitDataFishNet_002ESerializing_002EGenerated(this Writer writer, CharacterSuitData value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemData_003EFishNet_002ESerializing_002EGenerated(writer, value.Items);
		}

		public static void GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemDataFishNet_002ESerializing_002EGenerated(this Writer writer, CharacterSuitData.CharacterSuitItemData value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColor_003EFishNet_002ESerializing_002EGenerated(writer, value.Colors);
			writer.WriteBoolean(value.Enabled);
			writer.WriteString(value.Name);
		}

		public static void GWrite___Assets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColorFishNet_002ESerializing_002EGenerated(this Writer writer, CharacterSuitData.SuitItemDataColor value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteColor(value.Color);
			writer.WriteInt32(value.Index);
		}

		public static void GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FSuitItemDataColor_003EFishNet_002ESerializing_002EGenerated(this Writer writer, List<CharacterSuitData.SuitItemDataColor> value)
		{
			writer.WriteList(value);
		}

		public static void GWrite___System_002ECollections_002EGeneric_002EList_00601_003CAssets_002EScripts_002ECharacter_002ESuit_002ECharacterSuitData_002FCharacterSuitItemData_003EFishNet_002ESerializing_002EGenerated(this Writer writer, List<CharacterSuitData.CharacterSuitItemData> value)
		{
			writer.WriteList(value);
		}

		public static void GWrite___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerated(this Writer writer, int[] value)
		{
			writer.WriteArray(value);
		}

		public static void GWrite___System_002ENullable_00601_003CSystem_002ESingle_003EFishNet_002ESerializing_002EGenerated(this Writer writer, float? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteSingle(value.Value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002ENetworkAircraftScriptFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkAircraftScript value)
		{
			writer.WriteNetworkBehaviour(value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityStateFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityState value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityPlayerState value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FChangePlayerStateRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.ChangePlayerStateRequest value)
		{
			writer.WriteBoolean(value.ExcludeOwner);
			writer.WriteInt32(value.PlayerId);
			GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityPlayerStateFishNet_002ESerializing_002EGenerated(writer, value.State);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResultFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.AsyncResult value)
		{
			writer.WriteString(value.Message);
			GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResult_002FResultTypeFishNet_002ESerializing_002EGenerated(writer, value.Type);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FAsyncResult_002FResultTypeFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.AsyncResult.ResultType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FEndActivityForPlayerRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.EndActivityForPlayerRequest value)
		{
			writer.WriteInt32(value.PlayerId);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinActivityRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.JoinActivityRequest value)
		{
			writer.WriteInt32(value.PlayerId);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityTeamIds value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FJoinTeamRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.JoinTeamRequest value)
		{
			writer.WriteInt32(value.PlayerId);
			GWrite___System_002ENullable_00601_003CAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIds_003EFishNet_002ESerializing_002EGenerated(writer, value.TeamId);
		}

		public static void GWrite___System_002ENullable_00601_003CAssets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIds_003EFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityTeamIds? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityTeamIdsFishNet_002ESerializing_002EGenerated(writer, value.Value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FPlayerCraftBoundsRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.PlayerCraftBoundsRequest value)
		{
			writer.WriteBoolean(value.InitialBounds);
			writer.WriteInt32(value.PlayerId);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FCraftBoundsAsyncResultFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.CraftBoundsAsyncResult value)
		{
			GWrite___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerated(writer, value.Data);
			writer.WriteString(value.Message);
		}

		public static void GWrite___Assets_002EScripts_002ECraft_002ECraftLocalBoundsFishNet_002ESerializing_002EGenerated(this Writer writer, CraftLocalBounds value)
		{
			writer.WriteVector3(value.Offset);
			writer.WriteVector3(value.Size);
		}

		public static void GWrite___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerated(this Writer writer, CraftLocalBounds? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			GWrite___Assets_002EScripts_002ECraft_002ECraftLocalBoundsFishNet_002ESerializing_002EGenerated(writer, value.Value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.SpawnLocationRequest value)
		{
			GWrite___System_002ENullable_00601_003CAssets_002EScripts_002ECraft_002ECraftLocalBounds_003EFishNet_002ESerializing_002EGenerated(writer, value.Bounds);
			writer.WriteBoolean(value.InitialSpawn);
			writer.WriteInt32(value.PlayerId);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FSpawnLocationAsyncResultFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.SpawnLocationAsyncResult value)
		{
			GWrite___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationDataFishNet_002ESerializing_002EGenerated(writer, value.Data);
			writer.WriteString(value.Message);
		}

		public static void GWrite___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationDataFishNet_002ESerializing_002EGenerated(this Writer writer, StartLocationData value)
		{
			if (value == null)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteString(value.AreaName);
			writer.WriteString(value.Description);
			writer.WriteString(value.DisplayName);
			writer.WriteVector3(value.DistributionAxis);
			writer.WriteString(value.DynamicLocationId);
			writer.WriteString(value.Id);
			writer.WriteSingle(value.InitialSpeed);
			writer.WriteSingle(value.InitialThrottle);
			writer.WriteVector3(value.InitialVelocity);
			writer.WriteBoolean(value.IsRunwayTakeoff);
			GWrite___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationTypeFishNet_002ESerializing_002EGenerated(writer, value.LocationType);
			writer.WriteSingle(value.MaxDistributionAmount);
			writer.WriteString(value.OverflowLocation);
			writer.WriteVector3(value.Position);
			writer.WriteVector3(value.Rotation);
			GWrite___System_002ENullable_00601_003CSystem_002EBoolean_003EFishNet_002ESerializing_002EGenerated(writer, value.StartOnGround);
		}

		public static void GWrite___Assets_002EScripts_002EFlight_002EStartLocations_002EStartLocationTypeFishNet_002ESerializing_002EGenerated(this Writer writer, StartLocationType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___System_002ENullable_00601_003CSystem_002EBoolean_003EFishNet_002ESerializing_002EGenerated(this Writer writer, bool? value)
		{
			if (!value.HasValue)
			{
				writer.WriteBoolean(value: true);
				return;
			}
			writer.WriteBoolean(value: false);
			writer.WriteBoolean(value.Value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FStartActivityForPlayerRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.StartActivityForPlayerRequest value)
		{
			writer.WriteInt32(value.PlayerId);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FActivityTimerTypeFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.ActivityTimerType value)
		{
			writer.WriteInt32((int)value);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersEndedRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.WaitForAllPlayersEndedRequest value)
		{
			GWrite___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerated(writer, value.PlayerIds);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FWaitForAllPlayersStartedRequestFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.WaitForAllPlayersStartedRequest value)
		{
			GWrite___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerated(writer, value.PlayerIds);
		}

		public static void GWrite___Assets_002EScripts_002EMultiplayer_002EActivityFramework_002ENetworkedActivityScript_002FUpdateScoreTypeFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkedActivityScript.UpdateScoreType value)
		{
			writer.WriteUInt8Unpacked((byte)value);
		}
	}
}
