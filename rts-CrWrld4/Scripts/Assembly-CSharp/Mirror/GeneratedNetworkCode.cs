using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror
{
	[StructLayout((LayoutKind)3, CharSet = CharSet.Auto)]
	public static class GeneratedNetworkCode
	{
		public static ReadyMessage _Read_Mirror_002EReadyMessage(NetworkReader reader)
		{
			return default(ReadyMessage);
		}

		public static void _Write_Mirror_002EReadyMessage(NetworkWriter writer, ReadyMessage value)
		{
		}

		public static NotReadyMessage _Read_Mirror_002ENotReadyMessage(NetworkReader reader)
		{
			return default(NotReadyMessage);
		}

		public static void _Write_Mirror_002ENotReadyMessage(NetworkWriter writer, NotReadyMessage value)
		{
		}

		public static AddPlayerMessage _Read_Mirror_002EAddPlayerMessage(NetworkReader reader)
		{
			return default(AddPlayerMessage);
		}

		public static void _Write_Mirror_002EAddPlayerMessage(NetworkWriter writer, AddPlayerMessage value)
		{
		}

		public static SceneMessage _Read_Mirror_002ESceneMessage(NetworkReader reader)
		{
			return default(SceneMessage);
		}

		public static SceneOperation _Read_Mirror_002ESceneOperation(NetworkReader reader)
		{
			return default(SceneOperation);
		}

		public static void _Write_Mirror_002ESceneMessage(NetworkWriter writer, SceneMessage value)
		{
		}

		public static void _Write_Mirror_002ESceneOperation(NetworkWriter writer, SceneOperation value)
		{
		}

		public static CommandMessage _Read_Mirror_002ECommandMessage(NetworkReader reader)
		{
			return default(CommandMessage);
		}

		public static void _Write_Mirror_002ECommandMessage(NetworkWriter writer, CommandMessage value)
		{
		}

		public static RpcMessage _Read_Mirror_002ERpcMessage(NetworkReader reader)
		{
			return default(RpcMessage);
		}

		public static void _Write_Mirror_002ERpcMessage(NetworkWriter writer, RpcMessage value)
		{
		}

		public static SpawnMessage _Read_Mirror_002ESpawnMessage(NetworkReader reader)
		{
			return default(SpawnMessage);
		}

		public static void _Write_Mirror_002ESpawnMessage(NetworkWriter writer, SpawnMessage value)
		{
		}

		public static ObjectSpawnStartedMessage _Read_Mirror_002EObjectSpawnStartedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnStartedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnStartedMessage(NetworkWriter writer, ObjectSpawnStartedMessage value)
		{
		}

		public static ObjectSpawnFinishedMessage _Read_Mirror_002EObjectSpawnFinishedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnFinishedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnFinishedMessage(NetworkWriter writer, ObjectSpawnFinishedMessage value)
		{
		}

		public static ObjectDestroyMessage _Read_Mirror_002EObjectDestroyMessage(NetworkReader reader)
		{
			return default(ObjectDestroyMessage);
		}

		public static void _Write_Mirror_002EObjectDestroyMessage(NetworkWriter writer, ObjectDestroyMessage value)
		{
		}

		public static ObjectHideMessage _Read_Mirror_002EObjectHideMessage(NetworkReader reader)
		{
			return default(ObjectHideMessage);
		}

		public static void _Write_Mirror_002EObjectHideMessage(NetworkWriter writer, ObjectHideMessage value)
		{
		}

		public static UpdateVarsMessage _Read_Mirror_002EUpdateVarsMessage(NetworkReader reader)
		{
			return default(UpdateVarsMessage);
		}

		public static void _Write_Mirror_002EUpdateVarsMessage(NetworkWriter writer, UpdateVarsMessage value)
		{
		}

		public static NetworkPingMessage _Read_Mirror_002ENetworkPingMessage(NetworkReader reader)
		{
			return default(NetworkPingMessage);
		}

		public static void _Write_Mirror_002ENetworkPingMessage(NetworkWriter writer, NetworkPingMessage value)
		{
		}

		public static NetworkPongMessage _Read_Mirror_002ENetworkPongMessage(NetworkReader reader)
		{
			return default(NetworkPongMessage);
		}

		public static void _Write_Mirror_002ENetworkPongMessage(NetworkWriter writer, NetworkPongMessage value)
		{
		}

		public static MVerseAuthenticator.AuthRequestMessage _Read_MVerseAuthenticator_002FAuthRequestMessage(NetworkReader reader)
		{
			return default(MVerseAuthenticator.AuthRequestMessage);
		}

		public static void _Write_MVerseAuthenticator_002FAuthRequestMessage(NetworkWriter writer, MVerseAuthenticator.AuthRequestMessage value)
		{
		}

		public static MVerseAuthenticator.AuthResponseMessage _Read_MVerseAuthenticator_002FAuthResponseMessage(NetworkReader reader)
		{
			return default(MVerseAuthenticator.AuthResponseMessage);
		}

		public static void _Write_MVerseAuthenticator_002FAuthResponseMessage(NetworkWriter writer, MVerseAuthenticator.AuthResponseMessage value)
		{
		}

		public static void _Write_AirSac_002FTARGET_BEHAVIOR(NetworkWriter writer, AirSac.TARGET_BEHAVIOR value)
		{
		}

		public static AirSac.TARGET_BEHAVIOR _Read_AirSac_002FTARGET_BEHAVIOR(NetworkReader reader)
		{
			return default(AirSac.TARGET_BEHAVIOR);
		}

		public static void _Write_Blob_002FTARGET_BEHAVIOR(NetworkWriter writer, Blob.TARGET_BEHAVIOR value)
		{
		}

		public static Blob.TARGET_BEHAVIOR _Read_Blob_002FTARGET_BEHAVIOR(NetworkReader reader)
		{
			return default(Blob.TARGET_BEHAVIOR);
		}

		public static void _Write_UnitManager_002FORIENTATION(NetworkWriter writer, UnitManager.ORIENTATION value)
		{
		}

		public static void _Write_System_002EInt32_005B_005D(NetworkWriter writer, int[] value)
		{
		}

		public static UnitManager.ORIENTATION _Read_UnitManager_002FORIENTATION(NetworkReader reader)
		{
			return default(UnitManager.ORIENTATION);
		}

		public static int[] _Read_System_002EInt32_005B_005D(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_MVersePlayerPrefab_002FStashEvent(NetworkWriter writer, MVersePlayerPrefab.StashEvent value)
		{
		}

		public static MVersePlayerPrefab.StashEvent _Read_MVersePlayerPrefab_002FStashEvent(NetworkReader reader)
		{
			return default(MVersePlayerPrefab.StashEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FDamageDigitalisEvent_003E(NetworkWriter writer, List<MVerseEvents.DamageDigitalisEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FDamageDigitalisEvent(NetworkWriter writer, MVerseEvents.DamageDigitalisEvent value)
		{
		}

		public static List<MVerseEvents.DamageDigitalisEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FDamageDigitalisEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.DamageDigitalisEvent _Read_MVerseEvents_002FDamageDigitalisEvent(NetworkReader reader)
		{
			return default(MVerseEvents.DamageDigitalisEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FDamageCreeperEvent_003E(NetworkWriter writer, List<MVerseEvents.DamageCreeperEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FDamageCreeperEvent(NetworkWriter writer, MVerseEvents.DamageCreeperEvent value)
		{
		}

		public static List<MVerseEvents.DamageCreeperEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FDamageCreeperEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.DamageCreeperEvent _Read_MVerseEvents_002FDamageCreeperEvent(NetworkReader reader)
		{
			return default(MVerseEvents.DamageCreeperEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FAddCreeperEvent_003E(NetworkWriter writer, List<MVerseEvents.AddCreeperEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FAddCreeperEvent(NetworkWriter writer, MVerseEvents.AddCreeperEvent value)
		{
		}

		public static List<MVerseEvents.AddCreeperEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FAddCreeperEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.AddCreeperEvent _Read_MVerseEvents_002FAddCreeperEvent(NetworkReader reader)
		{
			return default(MVerseEvents.AddCreeperEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FAdd2CreeperEvent_003E(NetworkWriter writer, List<MVerseEvents.Add2CreeperEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FAdd2CreeperEvent(NetworkWriter writer, MVerseEvents.Add2CreeperEvent value)
		{
		}

		public static List<MVerseEvents.Add2CreeperEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FAdd2CreeperEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.Add2CreeperEvent _Read_MVerseEvents_002FAdd2CreeperEvent(NetworkReader reader)
		{
			return default(MVerseEvents.Add2CreeperEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FAdd3CreeperEvent_003E(NetworkWriter writer, List<MVerseEvents.Add3CreeperEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FAdd3CreeperEvent(NetworkWriter writer, MVerseEvents.Add3CreeperEvent value)
		{
		}

		public static List<MVerseEvents.Add3CreeperEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FAdd3CreeperEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.Add3CreeperEvent _Read_MVerseEvents_002FAdd3CreeperEvent(NetworkReader reader)
		{
			return default(MVerseEvents.Add3CreeperEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FSetCreeperEvent_003E(NetworkWriter writer, List<MVerseEvents.SetCreeperEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FSetCreeperEvent(NetworkWriter writer, MVerseEvents.SetCreeperEvent value)
		{
		}

		public static List<MVerseEvents.SetCreeperEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FSetCreeperEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.SetCreeperEvent _Read_MVerseEvents_002FSetCreeperEvent(NetworkReader reader)
		{
			return default(MVerseEvents.SetCreeperEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FSetCreeperStainEvent_003E(NetworkWriter writer, List<MVerseEvents.SetCreeperStainEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FSetCreeperStainEvent(NetworkWriter writer, MVerseEvents.SetCreeperStainEvent value)
		{
		}

		public static List<MVerseEvents.SetCreeperStainEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FSetCreeperStainEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.SetCreeperStainEvent _Read_MVerseEvents_002FSetCreeperStainEvent(NetworkReader reader)
		{
			return default(MVerseEvents.SetCreeperStainEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FApplyRunningCreeperEvent_003E(NetworkWriter writer, List<MVerseEvents.ApplyRunningCreeperEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FApplyRunningCreeperEvent(NetworkWriter writer, MVerseEvents.ApplyRunningCreeperEvent value)
		{
		}

		public static List<MVerseEvents.ApplyRunningCreeperEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FApplyRunningCreeperEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.ApplyRunningCreeperEvent _Read_MVerseEvents_002FApplyRunningCreeperEvent(NetworkReader reader)
		{
			return default(MVerseEvents.ApplyRunningCreeperEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FSetTerrainEvent_003E(NetworkWriter writer, List<MVerseEvents.SetTerrainEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FSetTerrainEvent(NetworkWriter writer, MVerseEvents.SetTerrainEvent value)
		{
		}

		public static List<MVerseEvents.SetTerrainEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FSetTerrainEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.SetTerrainEvent _Read_MVerseEvents_002FSetTerrainEvent(NetworkReader reader)
		{
			return default(MVerseEvents.SetTerrainEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FTerraformAddIndicatorEvent_003E(NetworkWriter writer, List<MVerseEvents.TerraformAddIndicatorEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FTerraformAddIndicatorEvent(NetworkWriter writer, MVerseEvents.TerraformAddIndicatorEvent value)
		{
		}

		public static List<MVerseEvents.TerraformAddIndicatorEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FTerraformAddIndicatorEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.TerraformAddIndicatorEvent _Read_MVerseEvents_002FTerraformAddIndicatorEvent(NetworkReader reader)
		{
			return default(MVerseEvents.TerraformAddIndicatorEvent);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FTerraformRemoveIndicatorEvent_003E(NetworkWriter writer, List<MVerseEvents.TerraformRemoveIndicatorEvent> value)
		{
		}

		public static void _Write_MVerseEvents_002FTerraformRemoveIndicatorEvent(NetworkWriter writer, MVerseEvents.TerraformRemoveIndicatorEvent value)
		{
		}

		public static List<MVerseEvents.TerraformRemoveIndicatorEvent> _Read_System_002ECollections_002EGeneric_002EList_00601_003CMVerseEvents_002FTerraformRemoveIndicatorEvent_003E(NetworkReader reader)
		{
			return null;
		}

		public static MVerseEvents.TerraformRemoveIndicatorEvent _Read_MVerseEvents_002FTerraformRemoveIndicatorEvent(NetworkReader reader)
		{
			return default(MVerseEvents.TerraformRemoveIndicatorEvent);
		}

		public static void _Write_System_002EInt64_005B_005D(NetworkWriter writer, long[] value)
		{
		}

		public static long[] _Read_System_002EInt64_005B_005D(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_System_002EBoolean_005B_005D(NetworkWriter writer, bool[] value)
		{
		}

		public static bool[] _Read_System_002EBoolean_005B_005D(NetworkReader reader)
		{
			return null;
		}

		public static void _Write_Spore_002FTARGET_BEHAVIOR(NetworkWriter writer, Spore.TARGET_BEHAVIOR value)
		{
		}

		public static Spore.TARGET_BEHAVIOR _Read_Spore_002FTARGET_BEHAVIOR(NetworkReader reader)
		{
			return default(Spore.TARGET_BEHAVIOR);
		}

		public static void _Write_Strider_002FTARGET_BEHAVIOR(NetworkWriter writer, Strider.TARGET_BEHAVIOR value)
		{
		}

		public static Strider.TARGET_BEHAVIOR _Read_Strider_002FTARGET_BEHAVIOR(NetworkReader reader)
		{
			return default(Strider.TARGET_BEHAVIOR);
		}

		[RuntimeInitializeOnLoadMethod]
		public static void InitReadWriters()
		{
		}
	}
}
