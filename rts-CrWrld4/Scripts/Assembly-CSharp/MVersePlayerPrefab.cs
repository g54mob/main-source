using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVersePlayerPrefab : NetworkBehaviour
{
	public struct StashEvent
	{
		[SerializeField]
		public float distributeEnergy;

		[SerializeField]
		public float distributeAC;

		[SerializeField]
		public float distributeArg;

		[SerializeField]
		public float distributeLiftic;

		public StashEvent(float distributeEnergy, float distributeAC, float distributeArg, float distributeLiftic)
		{
			this.distributeEnergy = 0f;
			this.distributeAC = 0f;
			this.distributeArg = 0f;
			this.distributeLiftic = 0f;
		}
	}

	private MVersePlayerBadge playerBadge;

	private MVerseMouseIndicator mouseIndicator;

	[SyncVar]
	private byte playerNum;

	[SyncVar]
	private int gameTime;

	[SyncVar]
	private int gameSpeed;

	[SyncVar]
	private bool gamePlaying;

	[SyncVar]
	private string playerName;

	[NonSerialized]
	[SyncVar]
	public bool playerNameSet;

	[SyncVar]
	private byte natType;

	private bool playerNameSent;

	private int lastCellX;

	private int lastCellZ;

	private bool lastSendMouse;

	private bool actualClientStarted;

	[NonSerialized]
	public bool clientStarted;

	private float accumulatedTime;

	private MVersePlayerBadge pausedBadge;

	private int updateCount;

	private bool sentNatType;

	private bool lobbyWasShown;

	private double rtt;

	private int ups;

	[NonSerialized]
	public bool singularityDeployed;

	[NonSerialized]
	public short singularityDeployedCellX;

	[NonSerialized]
	public short singularityDeployedCellY;

	[NonSerialized]
	public short singularityDeployedRANGE;

	private HashSet<int> localTerpFireTargets;

	private Dictionary<string, TargetIndicator> targetIndicators;

	private double MAX_SECTOR_DIFF;

	private int MIN_SYNC_TIME;

	private Dictionary<string, int> lastTargetSyncSectors;

	private int MAX_DIG_SECTOR_DIFF;

	private int MIN_DIG_SYNC_TIME;

	private Dictionary<string, int> lastTargetSyncDigSectors;

	private int SPLITPACKETSIZE;

	private byte[] gameMap;

	public byte NetworkplayerNum
	{
		get
		{
			return 0;
		}
		[param: In]
		set
		{
		}
	}

	public int NetworkgameTime
	{
		get
		{
			return 0;
		}
		[param: In]
		set
		{
		}
	}

	public int NetworkgameSpeed
	{
		get
		{
			return 0;
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworkgamePlaying
	{
		get
		{
			return false;
		}
		[param: In]
		set
		{
		}
	}

	public string NetworkplayerName
	{
		get
		{
			return null;
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworkplayerNameSet
	{
		get
		{
			return false;
		}
		[param: In]
		set
		{
		}
	}

	public byte NetworknatType
	{
		get
		{
			return 0;
		}
		[param: In]
		set
		{
		}
	}

	public void Awake()
	{
	}

	public int GetPlayerNum()
	{
		return 0;
	}

	public MVersePlayerBadge GetPlayerBadge()
	{
		return null;
	}

	public int GetGameTime()
	{
		return 0;
	}

	public string GetPlayerName()
	{
		return null;
	}

	public bool GetGamePlaying()
	{
		return false;
	}

	public double GetRTT()
	{
		return 0.0;
	}

	public int GetUPS()
	{
		return 0;
	}

	public override void OnStartAuthority()
	{
	}

	public override void OnStartServer()
	{
	}

	public override void OnStartClient()
	{
	}

	public void OnGameStartClient()
	{
	}

	public override void OnStopServer()
	{
	}

	public override void OnStopClient()
	{
	}

	public void Update()
	{
	}

	public void LateUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPlayerNumChanged(byte oldVal, byte newVal)
	{
	}

	private void OnGameTimeChanged(int oldVal, int newVal)
	{
	}

	private void OnGameSpeedChanged(int oldVal, int newVal)
	{
	}

	private void OnGamePlayingChanged(bool oldVal, bool newVal)
	{
	}

	private void OnNatTypeChanged(byte oldVal, byte newVal)
	{
	}

	private void OnPlayerNameChanged(string oldVal, string newVal)
	{
	}

	[Command]
	public void CmdSetRTTUPS(double rtt, int ups)
	{
	}

	[ClientRpc]
	public void RpcSetRTTUPS(double rtt, int ups)
	{
	}

	[Command]
	public void CmdSetNatType(byte natType)
	{
	}

	[Command]
	public void CmdBeginGame()
	{
	}

	[ClientRpc]
	public void RpcBeginGame()
	{
	}

	[Command]
	public void CmdSendChatMessage(string message)
	{
	}

	[ClientRpc]
	private void RpcReceiveChatMessage(uint senderNetId, string message)
	{
	}

	[Command]
	public void CmdSetGameTime(int val)
	{
	}

	[Command]
	public void CmdSetGameSpeed(int val)
	{
	}

	[Command]
	public void CmdSetGamePlaying(bool val)
	{
	}

	[Command]
	public void CmdSetPlayerName(string val)
	{
	}

	private string GetCorrectedName(string val)
	{
		return null;
	}

	[Command]
	public void CmdSetMouseX(short mouseX)
	{
	}

	[ClientRpc]
	private void RpcReceiveSetMouseX(short mouseX)
	{
	}

	[Command]
	public void CmdSetMouseZ(short mouseZ)
	{
	}

	[ClientRpc]
	private void RpcReceiveSetMouseZ(short mouseZ)
	{
	}

	[Command]
	public void CmdSetMouseVisible(bool vis)
	{
	}

	[ClientRpc]
	private void RpcReceiveSetMouseVisible(bool vis)
	{
	}

	private bool CheckName(string val)
	{
		return false;
	}

	[Command]
	public void CmdCreateMVerseSlaveUnit(string GUID, string unitName, Vector3 position, UnitManager.ORIENTATION orientation, int[] creeperSample, byte creeperSampleSize)
	{
	}

	[ClientRpc]
	private void RpcCreateMVerseSlaveUnit(string GUID, string unitName, Vector3 position, UnitManager.ORIENTATION orientation, int[] creeperSample, byte creeperSampleSize)
	{
	}

	[Command]
	public void CmdSetHealthMVerseSlaveUnit(string GUID, float amt)
	{
	}

	[ClientRpc]
	private void RpcSetHealthMVerseSlaveUnit(string GUID, float amt)
	{
	}

	[Command]
	public void CmdSetWare(string GUID, short wareType, float amt)
	{
	}

	[ClientRpc]
	private void RpcSetWare(string GUID, short wareType, float amt)
	{
	}

	[Command]
	public void CmdSetERNMVerseSlaveUnit(string GUID, bool val)
	{
	}

	[ClientRpc]
	private void RpcSetERNMVerseSlaveUnit(string GUID, bool val)
	{
	}

	[Command]
	public void CmdCompleteBuildMVerseSlaveUnit(string GUID)
	{
	}

	[ClientRpc]
	private void RpcCompleteBuildMVerseSlaveUnit(string GUID)
	{
	}

	[Command]
	public void CmdDestroyUnit(string GUID, bool suppressEffects)
	{
	}

	[ClientRpc]
	private void RpcDestroyUnit(string GUID, bool suppressEffects)
	{
	}

	[Command]
	public void CmdStunUnitsInRange(short cx, short cy, short range, bool enemy)
	{
	}

	[ClientRpc]
	public void RpcStunUnitsInRange(short cx, short cy, short range, bool enemy)
	{
	}

	[Command]
	public void CmdCreateShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	[ClientRpc]
	public void RpcCreateShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	[Command]
	public void CmdCreateACShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	[ClientRpc]
	public void RpcCreateACShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	[Command]
	public void CmdCreateMortarShot(Vector3 startPos, Vector3 targetPos, float offset)
	{
	}

	[ClientRpc]
	public void RpcCreateMortarShot(Vector3 startPos, Vector3 targetPos, float offset)
	{
	}

	[Command]
	public void CmdCreateMissile(Vector3 startPos, string targetTrueGuid)
	{
	}

	[ClientRpc]
	public void RpcCreateMissile(Vector3 startPos, string targetTrueGuid)
	{
	}

	[Command]
	public void CmdCreateSniperShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	[ClientRpc]
	public void RpcCreateSniperShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	[Command]
	public void CmdCreateMVerseGhost(string unitName, int uid, Vector3 position)
	{
	}

	public void CreateMVerseSpore(Spore unit)
	{
	}

	public void CreateMVerseAirSacBubble(AirSacBubble unit)
	{
	}

	public void CreateMVerseBlob(Blob unit)
	{
	}

	public void CreateMVerseStrider(Strider unit)
	{
	}

	public void CreateMVerseAirSac(AirSac unit)
	{
	}

	public void CreateMVerseShrapnel(Shrapnel unit)
	{
	}

	public void CreateMVerseForb(Forb unit)
	{
	}

	[Command]
	public void CmdDestroyMVerseObject(GameObject go)
	{
	}

	[Command]
	public void CmdSendStashEvent(StashEvent frameEvent)
	{
	}

	[ClientRpc]
	private void RpcReceiveStashEvent(StashEvent frameEvent)
	{
	}

	[Command]
	public void CmdSendDamageDigitalisEvents(List<MVerseEvents.DamageDigitalisEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveDamageDigitalisEvents(List<MVerseEvents.DamageDigitalisEvent> events)
	{
	}

	[Command]
	public void CmdSendDamageCreeperEvents(List<MVerseEvents.DamageCreeperEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveDamageCreeperEvents(List<MVerseEvents.DamageCreeperEvent> events)
	{
	}

	[Command]
	public void CmdSendAddCreeperEvents(List<MVerseEvents.AddCreeperEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveAddCreeperEvents(List<MVerseEvents.AddCreeperEvent> events)
	{
	}

	[Command]
	public void CmdSendAdd2CreeperEvents(List<MVerseEvents.Add2CreeperEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveAdd2CreeperEvents(List<MVerseEvents.Add2CreeperEvent> events)
	{
	}

	[Command]
	public void CmdSendAdd3CreeperEvents(List<MVerseEvents.Add3CreeperEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveAdd3CreeperEvents(List<MVerseEvents.Add3CreeperEvent> events)
	{
	}

	[Command]
	public void CmdSendSetCreeperEvents(List<MVerseEvents.SetCreeperEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveSetCreeperEvents(List<MVerseEvents.SetCreeperEvent> events)
	{
	}

	[Command]
	public void CmdSendSetCreeperStainEvents(List<MVerseEvents.SetCreeperStainEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveSetCreeperStainEvents(List<MVerseEvents.SetCreeperStainEvent> events)
	{
	}

	[Command]
	public void CmdSendApplyRunningCreeperEvents(List<MVerseEvents.ApplyRunningCreeperEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveApplyRunningCreeperEvents(List<MVerseEvents.ApplyRunningCreeperEvent> events)
	{
	}

	[Command]
	public void CmdSendSetTerrainEvents(List<MVerseEvents.SetTerrainEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveSetTerrainEvents(List<MVerseEvents.SetTerrainEvent> events)
	{
	}

	[Command]
	public void CmdSendTerraformAddIndicatorEvents(List<MVerseEvents.TerraformAddIndicatorEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveTerraformAddIndicatorEvents(List<MVerseEvents.TerraformAddIndicatorEvent> events)
	{
	}

	[Command]
	public void CmdSendTerraformRemoveIndicatorEvents(List<MVerseEvents.TerraformRemoveIndicatorEvent> events)
	{
	}

	[ClientRpc]
	private void RpcReceiveTerraformRemoveIndicatorEvents(List<MVerseEvents.TerraformRemoveIndicatorEvent> events)
	{
	}

	[Command]
	public void CmdModTerrain(short cellX, short cellY, byte currentLevel, short targetLevel)
	{
	}

	[ClientRpc]
	private void RpcModTerrain(short cellX, short cellY, byte currentLevel, short targetLevel)
	{
	}

	[Command]
	public void CmdManagePanels(bool showAllPanels, bool forceRefreshLand, bool forceRefreshCreeper)
	{
	}

	[ClientRpc]
	private void RpcManagePanels(bool showAllPanels, bool forceRefreshLand, bool forceRefreshCreeper)
	{
	}

	[Command]
	public void CmdSendPod(uint netId, int resourceType, float amt, short cellX, short cellZ)
	{
	}

	[TargetRpc]
	public void TargetReceivePod(NetworkConnection conn, int resourceType, float amt, short cellX, short cellZ)
	{
	}

	[Command]
	public void Cmd4rplSendMsg(string channel, byte[] data)
	{
	}

	[ClientRpc]
	public void Rpc4rplSendMsg(string channel, byte[] data)
	{
	}

	[Command]
	public void CmdSetTotemData(string trueGUID, bool activated, float ammo, bool unitEnabled, bool unitArmed)
	{
	}

	[ClientRpc]
	public void RpcSetTotemData(string trueGUID, bool activated, float ammo, bool unitEnabled, bool unitArmed)
	{
	}

	[Command]
	public void CmdSetStashValue(long val, int cellX, int cellY)
	{
	}

	[ClientRpc]
	public void RpcSetStashValue(long val, int cellX, int cellY)
	{
	}

	[Command]
	public void CmdConvert(short cellX, short cellY, short r)
	{
	}

	[ClientRpc]
	public void RpcConvert(short cellX, short cellY, short r)
	{
	}

	[Command]
	public void CmdDamp(short cellX, short cellY, short r)
	{
	}

	[ClientRpc]
	public void RpcDamp(short cx, short cy, short r)
	{
	}

	[Command]
	public void CmdDeploySingularity(bool deploy, short cellX, short cellY, short RANGE)
	{
	}

	[ClientRpc]
	public void RpcDeploySingularity(bool deploy, short cellX, short cellY, short RANGE)
	{
	}

	[Command]
	public void CmdClipCreeperLine(Vector3 start, Vector3 end, int lineWidth, bool affectCreeper, bool affectAC)
	{
	}

	[ClientRpc]
	public void RpcClipCreeperLine(Vector3 start, Vector3 end, int lineWidth, bool affectCreeper, bool affectAC)
	{
	}

	[Command]
	public void CmdSendResistor(short cellX, short cellY, int amt)
	{
	}

	[ClientRpc]
	public void RpcReceiveResistor(short cellX, short cellY, int amt)
	{
	}

	[Command]
	public void CmdSendWallAffectsAC(short cellX, short cellY, bool val)
	{
	}

	[ClientRpc]
	public void RpcReceiveWallAffectsAC(short cellX, short cellY, bool val)
	{
	}

	[Command]
	public void CmdSendUnitEnabled(string trueGUID, bool val)
	{
	}

	[ClientRpc]
	public void RpcReceiveUnitEnabled(string trueGUID, bool val)
	{
	}

	[Command]
	public void CmdAddTerpFireTarget(short x, short y)
	{
	}

	[ClientRpc]
	public void RpcAddTerpFireTarget(short x, short y)
	{
	}

	[Command]
	public void CmdRemoveTerpFireTarget(short x, short y)
	{
	}

	[ClientRpc]
	public void RpcRemoveTerpFireTarget(short x, short y)
	{
	}

	private void DestroyAllTargetIndicators()
	{
	}

	[Command]
	public void CmdUpdateTargetIndicator(string trueGUID, short cellX, short cellY, byte tiType, short resourceType)
	{
	}

	[ClientRpc]
	public void RpcUpdateTargetIndicator(string trueGUID, short cellX, short cellY, byte tiType, short resourceType)
	{
	}

	[Command]
	public void CmdDestroyTargetIndicator(string trueGUID)
	{
	}

	[ClientRpc]
	public void RpcDestroyTargetIndicator(string trueGUID)
	{
	}

	[Command]
	public void CmdSetCreeperSectorTotals(long[] totals)
	{
	}

	[TargetRpc]
	public void TargetSyncSector(NetworkConnection conn, int sector, int[] data)
	{
	}

	[Command]
	public void CmdSetDigSectorTotals(int[] totals)
	{
	}

	[TargetRpc]
	public void TargetSyncDigSector(NetworkConnection conn, int sector, bool[] data)
	{
	}

	private void DiffSectors(NetworkConnection conn, long[] a, long[] b)
	{
	}

	private void DiffDigSectors(NetworkConnection conn, int[] a, int[] b)
	{
	}

	private long[] GetSectorTotals()
	{
		return null;
	}

	private int[] GetSectorData(int i)
	{
		return null;
	}

	private void SetSectorData(int i, int[] data)
	{
	}

	private int[] GetSectorDigTotals()
	{
		return null;
	}

	private bool[] GetSectorDigData(int i)
	{
		return null;
	}

	private void SetSectorDigData(int i, bool[] data)
	{
	}

	public void BeginGame()
	{
	}

	public void SendGameMap(string file)
	{
	}

	[TargetRpc]
	public void TargetReceiveGameMap(byte pos, int totalDataSize, byte[] data)
	{
	}

	private void LoadMission()
	{
	}

	private List<byte[]> SplitArray(byte[] src, int maxLen)
	{
		return null;
	}

	private byte[] ConcatByteArrays(byte[] oldD, byte[] newD)
	{
		return null;
	}

	private void MirrorProcessed()
	{
	}

	public void UserCode_CmdSetRTTUPS(double rtt, int ups)
	{
	}

	protected static void InvokeUserCode_CmdSetRTTUPS(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetRTTUPS(double rtt, int ups)
	{
	}

	protected static void InvokeUserCode_RpcSetRTTUPS(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetNatType(byte natType)
	{
	}

	protected static void InvokeUserCode_CmdSetNatType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdBeginGame()
	{
	}

	protected static void InvokeUserCode_CmdBeginGame(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcBeginGame()
	{
	}

	protected static void InvokeUserCode_RpcBeginGame(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendChatMessage(string message)
	{
	}

	protected static void InvokeUserCode_CmdSendChatMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveChatMessage(uint senderNetId, string message)
	{
	}

	protected static void InvokeUserCode_RpcReceiveChatMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetGameTime(int val)
	{
	}

	protected static void InvokeUserCode_CmdSetGameTime(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetGameSpeed(int val)
	{
	}

	protected static void InvokeUserCode_CmdSetGameSpeed(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetGamePlaying(bool val)
	{
	}

	protected static void InvokeUserCode_CmdSetGamePlaying(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetPlayerName(string val)
	{
	}

	protected static void InvokeUserCode_CmdSetPlayerName(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetMouseX(short mouseX)
	{
	}

	protected static void InvokeUserCode_CmdSetMouseX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveSetMouseX(short mouseX)
	{
	}

	protected static void InvokeUserCode_RpcReceiveSetMouseX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetMouseZ(short mouseZ)
	{
	}

	protected static void InvokeUserCode_CmdSetMouseZ(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveSetMouseZ(short mouseZ)
	{
	}

	protected static void InvokeUserCode_RpcReceiveSetMouseZ(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetMouseVisible(bool vis)
	{
	}

	protected static void InvokeUserCode_CmdSetMouseVisible(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveSetMouseVisible(bool vis)
	{
	}

	protected static void InvokeUserCode_RpcReceiveSetMouseVisible(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateMVerseSlaveUnit(string GUID, string unitName, Vector3 position, UnitManager.ORIENTATION orientation, int[] creeperSample, byte creeperSampleSize)
	{
	}

	protected static void InvokeUserCode_CmdCreateMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcCreateMVerseSlaveUnit(string GUID, string unitName, Vector3 position, UnitManager.ORIENTATION orientation, int[] creeperSample, byte creeperSampleSize)
	{
	}

	protected static void InvokeUserCode_RpcCreateMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetHealthMVerseSlaveUnit(string GUID, float amt)
	{
	}

	protected static void InvokeUserCode_CmdSetHealthMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcSetHealthMVerseSlaveUnit(string GUID, float amt)
	{
	}

	protected static void InvokeUserCode_RpcSetHealthMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetWare(string GUID, short wareType, float amt)
	{
	}

	protected static void InvokeUserCode_CmdSetWare(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcSetWare(string GUID, short wareType, float amt)
	{
	}

	protected static void InvokeUserCode_RpcSetWare(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetERNMVerseSlaveUnit(string GUID, bool val)
	{
	}

	protected static void InvokeUserCode_CmdSetERNMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcSetERNMVerseSlaveUnit(string GUID, bool val)
	{
	}

	protected static void InvokeUserCode_RpcSetERNMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCompleteBuildMVerseSlaveUnit(string GUID)
	{
	}

	protected static void InvokeUserCode_CmdCompleteBuildMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcCompleteBuildMVerseSlaveUnit(string GUID)
	{
	}

	protected static void InvokeUserCode_RpcCompleteBuildMVerseSlaveUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDestroyUnit(string GUID, bool suppressEffects)
	{
	}

	protected static void InvokeUserCode_CmdDestroyUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcDestroyUnit(string GUID, bool suppressEffects)
	{
	}

	protected static void InvokeUserCode_RpcDestroyUnit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdStunUnitsInRange(short cx, short cy, short range, bool enemy)
	{
	}

	protected static void InvokeUserCode_CmdStunUnitsInRange(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcStunUnitsInRange(short cx, short cy, short range, bool enemy)
	{
	}

	protected static void InvokeUserCode_RpcStunUnitsInRange(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	protected static void InvokeUserCode_CmdCreateShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcCreateShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	protected static void InvokeUserCode_RpcCreateShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateACShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	protected static void InvokeUserCode_CmdCreateACShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcCreateACShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	protected static void InvokeUserCode_RpcCreateACShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateMortarShot(Vector3 startPos, Vector3 targetPos, float offset)
	{
	}

	protected static void InvokeUserCode_CmdCreateMortarShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcCreateMortarShot(Vector3 startPos, Vector3 targetPos, float offset)
	{
	}

	protected static void InvokeUserCode_RpcCreateMortarShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateMissile(Vector3 startPos, string targetTrueGuid)
	{
	}

	protected static void InvokeUserCode_CmdCreateMissile(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcCreateMissile(Vector3 startPos, string targetTrueGuid)
	{
	}

	protected static void InvokeUserCode_RpcCreateMissile(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateSniperShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	protected static void InvokeUserCode_CmdCreateSniperShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcCreateSniperShot(Vector3 startPos, Vector3 targetPos)
	{
	}

	protected static void InvokeUserCode_RpcCreateSniperShot(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateMVerseGhost(string unitName, int uid, Vector3 position)
	{
	}

	protected static void InvokeUserCode_CmdCreateMVerseGhost(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDestroyMVerseObject(GameObject go)
	{
	}

	protected static void InvokeUserCode_CmdDestroyMVerseObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendStashEvent(StashEvent frameEvent)
	{
	}

	protected static void InvokeUserCode_CmdSendStashEvent(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveStashEvent(StashEvent frameEvent)
	{
	}

	protected static void InvokeUserCode_RpcReceiveStashEvent(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendDamageDigitalisEvents(List<MVerseEvents.DamageDigitalisEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendDamageDigitalisEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveDamageDigitalisEvents(List<MVerseEvents.DamageDigitalisEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveDamageDigitalisEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendDamageCreeperEvents(List<MVerseEvents.DamageCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendDamageCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveDamageCreeperEvents(List<MVerseEvents.DamageCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveDamageCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendAddCreeperEvents(List<MVerseEvents.AddCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendAddCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveAddCreeperEvents(List<MVerseEvents.AddCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveAddCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendAdd2CreeperEvents(List<MVerseEvents.Add2CreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendAdd2CreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveAdd2CreeperEvents(List<MVerseEvents.Add2CreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveAdd2CreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendAdd3CreeperEvents(List<MVerseEvents.Add3CreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendAdd3CreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveAdd3CreeperEvents(List<MVerseEvents.Add3CreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveAdd3CreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendSetCreeperEvents(List<MVerseEvents.SetCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendSetCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveSetCreeperEvents(List<MVerseEvents.SetCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveSetCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendSetCreeperStainEvents(List<MVerseEvents.SetCreeperStainEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendSetCreeperStainEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveSetCreeperStainEvents(List<MVerseEvents.SetCreeperStainEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveSetCreeperStainEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendApplyRunningCreeperEvents(List<MVerseEvents.ApplyRunningCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendApplyRunningCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveApplyRunningCreeperEvents(List<MVerseEvents.ApplyRunningCreeperEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveApplyRunningCreeperEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendSetTerrainEvents(List<MVerseEvents.SetTerrainEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendSetTerrainEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveSetTerrainEvents(List<MVerseEvents.SetTerrainEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveSetTerrainEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendTerraformAddIndicatorEvents(List<MVerseEvents.TerraformAddIndicatorEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendTerraformAddIndicatorEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveTerraformAddIndicatorEvents(List<MVerseEvents.TerraformAddIndicatorEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveTerraformAddIndicatorEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendTerraformRemoveIndicatorEvents(List<MVerseEvents.TerraformRemoveIndicatorEvent> events)
	{
	}

	protected static void InvokeUserCode_CmdSendTerraformRemoveIndicatorEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcReceiveTerraformRemoveIndicatorEvents(List<MVerseEvents.TerraformRemoveIndicatorEvent> events)
	{
	}

	protected static void InvokeUserCode_RpcReceiveTerraformRemoveIndicatorEvents(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdModTerrain(short cellX, short cellY, byte currentLevel, short targetLevel)
	{
	}

	protected static void InvokeUserCode_CmdModTerrain(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcModTerrain(short cellX, short cellY, byte currentLevel, short targetLevel)
	{
	}

	protected static void InvokeUserCode_RpcModTerrain(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdManagePanels(bool showAllPanels, bool forceRefreshLand, bool forceRefreshCreeper)
	{
	}

	protected static void InvokeUserCode_CmdManagePanels(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_RpcManagePanels(bool showAllPanels, bool forceRefreshLand, bool forceRefreshCreeper)
	{
	}

	protected static void InvokeUserCode_RpcManagePanels(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendPod(uint netId, int resourceType, float amt, short cellX, short cellZ)
	{
	}

	protected static void InvokeUserCode_CmdSendPod(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_TargetReceivePod(NetworkConnection conn, int resourceType, float amt, short cellX, short cellZ)
	{
	}

	protected static void InvokeUserCode_TargetReceivePod(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_Cmd4rplSendMsg(string channel, byte[] data)
	{
	}

	protected static void InvokeUserCode_Cmd4rplSendMsg(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_Rpc4rplSendMsg(string channel, byte[] data)
	{
	}

	protected static void InvokeUserCode_Rpc4rplSendMsg(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetTotemData(string trueGUID, bool activated, float ammo, bool unitEnabled, bool unitArmed)
	{
	}

	protected static void InvokeUserCode_CmdSetTotemData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetTotemData(string trueGUID, bool activated, float ammo, bool unitEnabled, bool unitArmed)
	{
	}

	protected static void InvokeUserCode_RpcSetTotemData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetStashValue(long val, int cellX, int cellY)
	{
	}

	protected static void InvokeUserCode_CmdSetStashValue(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcSetStashValue(long val, int cellX, int cellY)
	{
	}

	protected static void InvokeUserCode_RpcSetStashValue(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdConvert(short cellX, short cellY, short r)
	{
	}

	protected static void InvokeUserCode_CmdConvert(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcConvert(short cellX, short cellY, short r)
	{
	}

	protected static void InvokeUserCode_RpcConvert(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDamp(short cellX, short cellY, short r)
	{
	}

	protected static void InvokeUserCode_CmdDamp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDamp(short cx, short cy, short r)
	{
	}

	protected static void InvokeUserCode_RpcDamp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDeploySingularity(bool deploy, short cellX, short cellY, short RANGE)
	{
	}

	protected static void InvokeUserCode_CmdDeploySingularity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDeploySingularity(bool deploy, short cellX, short cellY, short RANGE)
	{
	}

	protected static void InvokeUserCode_RpcDeploySingularity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdClipCreeperLine(Vector3 start, Vector3 end, int lineWidth, bool affectCreeper, bool affectAC)
	{
	}

	protected static void InvokeUserCode_CmdClipCreeperLine(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcClipCreeperLine(Vector3 start, Vector3 end, int lineWidth, bool affectCreeper, bool affectAC)
	{
	}

	protected static void InvokeUserCode_RpcClipCreeperLine(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendResistor(short cellX, short cellY, int amt)
	{
	}

	protected static void InvokeUserCode_CmdSendResistor(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcReceiveResistor(short cellX, short cellY, int amt)
	{
	}

	protected static void InvokeUserCode_RpcReceiveResistor(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendWallAffectsAC(short cellX, short cellY, bool val)
	{
	}

	protected static void InvokeUserCode_CmdSendWallAffectsAC(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcReceiveWallAffectsAC(short cellX, short cellY, bool val)
	{
	}

	protected static void InvokeUserCode_RpcReceiveWallAffectsAC(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSendUnitEnabled(string trueGUID, bool val)
	{
	}

	protected static void InvokeUserCode_CmdSendUnitEnabled(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcReceiveUnitEnabled(string trueGUID, bool val)
	{
	}

	protected static void InvokeUserCode_RpcReceiveUnitEnabled(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdAddTerpFireTarget(short x, short y)
	{
	}

	protected static void InvokeUserCode_CmdAddTerpFireTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcAddTerpFireTarget(short x, short y)
	{
	}

	protected static void InvokeUserCode_RpcAddTerpFireTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdRemoveTerpFireTarget(short x, short y)
	{
	}

	protected static void InvokeUserCode_CmdRemoveTerpFireTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcRemoveTerpFireTarget(short x, short y)
	{
	}

	protected static void InvokeUserCode_RpcRemoveTerpFireTarget(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdUpdateTargetIndicator(string trueGUID, short cellX, short cellY, byte tiType, short resourceType)
	{
	}

	protected static void InvokeUserCode_CmdUpdateTargetIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcUpdateTargetIndicator(string trueGUID, short cellX, short cellY, byte tiType, short resourceType)
	{
	}

	protected static void InvokeUserCode_RpcUpdateTargetIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDestroyTargetIndicator(string trueGUID)
	{
	}

	protected static void InvokeUserCode_CmdDestroyTargetIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDestroyTargetIndicator(string trueGUID)
	{
	}

	protected static void InvokeUserCode_RpcDestroyTargetIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetCreeperSectorTotals(long[] totals)
	{
	}

	protected static void InvokeUserCode_CmdSetCreeperSectorTotals(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_TargetSyncSector(NetworkConnection conn, int sector, int[] data)
	{
	}

	protected static void InvokeUserCode_TargetSyncSector(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetDigSectorTotals(int[] totals)
	{
	}

	protected static void InvokeUserCode_CmdSetDigSectorTotals(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_TargetSyncDigSector(NetworkConnection conn, int sector, bool[] data)
	{
	}

	protected static void InvokeUserCode_TargetSyncDigSector(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_TargetReceiveGameMap(byte pos, int totalDataSize, byte[] data)
	{
	}

	protected static void InvokeUserCode_TargetReceiveGameMap(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static MVersePlayerPrefab()
	{
	}

	public override bool SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		return false;
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
	}
}
