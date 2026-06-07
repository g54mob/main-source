using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class MVerseUnit : NetworkBehaviour, BaseUnitManager
{
	[SyncVar]
	public bool isBuilding;

	[SyncVar]
	public Vector3 location;

	[SyncVar]
	public uint rotation;

	[SyncVar]
	public string guid;

	[SyncVar]
	public int uid;

	[SyncVar]
	public byte WIDTH;

	[SyncVar]
	public byte HEIGHT;

	[SyncVar]
	public UnitManager.ORIENTATION ORIENTATION;

	[SyncVar]
	public uint ownerNetId;

	[SyncVar]
	public bool nullifyActive;

	[SyncVar]
	public bool ernHeld;

	[SyncVar]
	public Vector2 moveTo;

	[SyncVar]
	public Vector3 barrelLocation;

	[SyncVar]
	public uint barrelRotation;

	public MVersePlayerPrefab pp;

	private int shieldRange;

	private int defogRange;

	[NonSerialized]
	public UnitManager unitManager;

	private Transform unitManagerBarrel;

	[NonSerialized]
	public bool clientStarted;

	private Transform goBarrel;

	private GameObject go;

	private MVerseMoveGhost moveGhost;

	private bool dead;

	private float locationDistance;

	private float rotationDistance;

	private float barrelLocationDistance;

	private float barrelRotationDistance;

	private UnitERNIndicator uei;

	private Vector2 deployedPosition;

	private UnitManager.ORIENTATION deployedOrientation;

	public int SPRAYER_FIELD_STRENGTH;

	private bool sprayerFieldDeployed;

	private int SPRAYER_FIELD_RANGE;

	private Vector2 deployedShieldPosition;

	private int deployedShieldCenterHeight;

	private int deployedShieldRange;

	private int fieldStrength;

	private bool showShield;

	private Vector2 deployedDTPosition;

	private int deployedDTRange;

	private Vector3 lastPosition;

	private uint lastRotationi;

	private Vector3 lastBarrelPosition;

	private uint lastBarrelRotationi;

	private float deltaT;

	private float MIN_DELTAT;

	private Vector2 lastOwnerDeployedPosition;

	private UnitManager.ORIENTATION lastOwnerDeployedOrientation;

	private Vector2 lastOwnerMoveTargetPosition;

	private Vector2 lastOwnerDeployedShieldPosition;

	private Vector2 lastOwnerDeployedDTPosition;

	private int lastOwnerDeployedShieldRange;

	private int lastOwnerDeployedDTRange;

	private bool lastSprayerDeployed;

	[NonSerialized]
	public Dictionary<int, MVerseBeam> beamDictionary;

	[NonSerialized]
	public HashSet<int> mverseBeamsCreated;

	private int NULLIFIER_RANGE;

	private Dictionary<UnitManager, Nullifier.Beam> beams;

	private int materialNum;

	public int cellX
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cellY
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool NetworkisBuilding
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

	public Vector3 Networklocation
	{
		get
		{
			return default(Vector3);
		}
		[param: In]
		set
		{
		}
	}

	public uint Networkrotation
	{
		get
		{
			return 0u;
		}
		[param: In]
		set
		{
		}
	}

	public string Networkguid
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

	public int Networkuid
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

	public byte NetworkWIDTH
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

	public byte NetworkHEIGHT
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

	public UnitManager.ORIENTATION NetworkORIENTATION
	{
		get
		{
			return default(UnitManager.ORIENTATION);
		}
		[param: In]
		set
		{
		}
	}

	public uint NetworkownerNetId
	{
		get
		{
			return 0u;
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworknullifyActive
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

	public bool NetworkernHeld
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

	public Vector2 NetworkmoveTo
	{
		get
		{
			return default(Vector2);
		}
		[param: In]
		set
		{
		}
	}

	public Vector3 NetworkbarrelLocation
	{
		get
		{
			return default(Vector3);
		}
		[param: In]
		set
		{
		}
	}

	public uint NetworkbarrelRotation
	{
		get
		{
			return 0u;
		}
		[param: In]
		set
		{
		}
	}

	public int GetShieldRange()
	{
		return 0;
	}

	public int GetDefogRange()
	{
		return 0;
	}

	public void Awake()
	{
	}

	public override void OnStartServer()
	{
	}

	public override void OnStartClient()
	{
	}

	public static Transform FindDeepChild(Transform aParent, string aName)
	{
		return null;
	}

	private void OnGameStartClient()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnIsBuildingChanged(bool oldVal, bool newVal)
	{
	}

	private void UpdateIsBuildingState()
	{
	}

	private void OnLocationChanged(Vector3 oldLoc, Vector3 newLoc)
	{
	}

	private void OnRotationChanged(uint oldRot, uint newRot)
	{
	}

	private void OnBarrelLocationChanged(Vector3 oldLoc, Vector3 newLoc)
	{
	}

	private void OnBarrelRotationChanged(uint oldRot, uint newRot)
	{
	}

	private void OnWidthChanged(byte oldVal, byte newVal)
	{
	}

	private void OnHeightChanged(byte oldVal, byte newVal)
	{
	}

	private void OnOrientationChanged(UnitManager.ORIENTATION oldVal, UnitManager.ORIENTATION newVal)
	{
	}

	private void OnNullifiedUnitsChanged(bool oldVal, bool newVal)
	{
	}

	private void OnErnHeld(bool oldVal, bool newVal)
	{
	}

	private void OnMoveToChanged(Vector2 oldVal, Vector2 newVal)
	{
	}

	[Command]
	private void CmdSetErnHeld(bool val)
	{
	}

	[Command]
	private void CmdSetIsBuilding(bool val)
	{
	}

	[Command]
	private void CmdSetLocation(Vector3 pos)
	{
	}

	[Command]
	private void CmdSetRotation(uint roti)
	{
	}

	[Command]
	private void CmdSetBarrelLocation(Vector3 pos)
	{
	}

	[Command]
	private void CmdSetBarrelRotation(uint roti)
	{
	}

	[Command]
	private void CmdSetSize(byte WIDTH, byte HEIGHT, UnitManager.ORIENTATION orientation)
	{
	}

	[Command]
	public void CmdSetNullifyActive(bool val)
	{
	}

	[Command]
	public void CmdMoveTo(Vector2 moveTo)
	{
	}

	[Command]
	public void CmdDeployFootprint(bool deploy, int gsx, int gsy, UnitManager.ORIENTATION orient, byte width, byte height)
	{
	}

	[ClientRpc]
	public void RpcDeployFootprint(bool deploy, int gsx, int gsy, UnitManager.ORIENTATION orient, byte width, byte height)
	{
	}

	[Command]
	public void CmdDefogTerrain(bool deploy, int gsx, int gsy, int range)
	{
	}

	[ClientRpc]
	public void RpcDefogTerrain(bool deploy, int gsx, int gsy, int range)
	{
	}

	[Command]
	public void CmdDeployShield(bool deploy, int gsx, int gsy, int shieldRange)
	{
	}

	[ClientRpc]
	public void RpcDeployShield(bool deploy, int gsx, int gsy, int shieldRange)
	{
	}

	[Command]
	public void CmdDeploySprayerField(bool deploy, int gsx, int gsy)
	{
	}

	[ClientRpc]
	public void RpcDeploySprayerField(bool deploy, int gsx, int gsy)
	{
	}

	[Command]
	public void CmdCreateMVerseBeam(int unitUID, int beamUID)
	{
	}

	protected virtual void DeployFootprint(bool deploy, int gsx, int gsy, UnitManager.ORIENTATION orient)
	{
	}

	private void DeploySprayerField(bool deploy, int gameSpaceX, int gameSpaceY)
	{
	}

	private void DeployField(int gsx, int gsy, int R, int fieldStrength, bool deploy)
	{
	}

	public void DeployShield(bool deploy)
	{
	}

	private void DeployShield(bool deploy, int gsx, int gsy)
	{
	}

	public void DefogTerrain(bool deploy)
	{
	}

	private void DefogTerrain(bool deploy, int gsx, int gsy)
	{
	}

	private void LateUpdate()
	{
	}

	private void SyncBeams()
	{
	}

	public void GameUpdate()
	{
	}

	private bool InRange(UnitManager em, int gsx, int gsy, int range)
	{
		return false;
	}

	private void NullifyUnits()
	{
	}

	private MVerseMoveGhost CreateMoveGhost(Transform t, string unitName, uint ownerNetId)
	{
		return null;
	}

	private static Transform GetBarrel(string unitName, GameObject go)
	{
		return null;
	}

	private static GameObject CreateGO(Transform t, string unitName, uint ownerNetId, out Transform goBarrel, out int materialNum)
	{
		goBarrel = null;
		materialNum = default(int);
		return null;
	}

	private static GameObject GetBuildGhost(string unitName, out bool wasCustom)
	{
		wasCustom = default(bool);
		return null;
	}

	private Vector3 IntPosition(Vector3 pos)
	{
		return default(Vector3);
	}

	private void MirrorProcessed()
	{
	}

	private void UserCode_CmdSetErnHeld(bool val)
	{
	}

	protected static void InvokeUserCode_CmdSetErnHeld(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_CmdSetIsBuilding(bool val)
	{
	}

	protected static void InvokeUserCode_CmdSetIsBuilding(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_CmdSetLocation(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_CmdSetLocation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_CmdSetRotation(uint roti)
	{
	}

	protected static void InvokeUserCode_CmdSetRotation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_CmdSetBarrelLocation(Vector3 pos)
	{
	}

	protected static void InvokeUserCode_CmdSetBarrelLocation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_CmdSetBarrelRotation(uint roti)
	{
	}

	protected static void InvokeUserCode_CmdSetBarrelRotation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	private void UserCode_CmdSetSize(byte WIDTH, byte HEIGHT, UnitManager.ORIENTATION orientation)
	{
	}

	protected static void InvokeUserCode_CmdSetSize(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetNullifyActive(bool val)
	{
	}

	protected static void InvokeUserCode_CmdSetNullifyActive(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdMoveTo(Vector2 moveTo)
	{
	}

	protected static void InvokeUserCode_CmdMoveTo(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDeployFootprint(bool deploy, int gsx, int gsy, UnitManager.ORIENTATION orient, byte width, byte height)
	{
	}

	protected static void InvokeUserCode_CmdDeployFootprint(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDeployFootprint(bool deploy, int gsx, int gsy, UnitManager.ORIENTATION orient, byte width, byte height)
	{
	}

	protected static void InvokeUserCode_RpcDeployFootprint(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDefogTerrain(bool deploy, int gsx, int gsy, int range)
	{
	}

	protected static void InvokeUserCode_CmdDefogTerrain(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDefogTerrain(bool deploy, int gsx, int gsy, int range)
	{
	}

	protected static void InvokeUserCode_RpcDefogTerrain(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDeployShield(bool deploy, int gsx, int gsy, int shieldRange)
	{
	}

	protected static void InvokeUserCode_CmdDeployShield(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDeployShield(bool deploy, int gsx, int gsy, int shieldRange)
	{
	}

	protected static void InvokeUserCode_RpcDeployShield(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdDeploySprayerField(bool deploy, int gsx, int gsy)
	{
	}

	protected static void InvokeUserCode_CmdDeploySprayerField(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_RpcDeploySprayerField(bool deploy, int gsx, int gsy)
	{
	}

	protected static void InvokeUserCode_RpcDeploySprayerField(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCreateMVerseBeam(int unitUID, int beamUID)
	{
	}

	protected static void InvokeUserCode_CmdCreateMVerseBeam(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static MVerseUnit()
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
