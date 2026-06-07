using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class UnitData
{
	public class UnitConstants
	{
		public bool ENEMY;

		public bool IMPERVIOUS;

		public bool SELECTABLE;

		public int WIDTH;

		public int HEIGHT;

		public float Y_HEIGHT;

		public Vector3 CONNECT_OFFSET;

		public Vector3 FIRE_OFFSET;

		public int RANGE;

		public int BUILD_COST;

		public int PROGRESSIVE_BUILD_COST;

		public Dictionary<int, int> BUILD_WARES;

		public bool CONNECTABLE;

		public float PZ_RANGE_BOOST;

		public float UPGRADE_RANGE_BOOST;

		public bool LOS_ENABLED;

		public float LOS_TARGET_HEIGHT_OFFSET;

		public bool LOS_ALWAYS_SHOW;

		public bool LOS_IGNORE_TERRAIN;

		public bool LOS_NEEDS_REFRESH;

		public float LOS_TERRAIN_HEIGHT_MOD;

		public Vector3 TARGET_ME_OFFSET;

		public bool LOS_INDIRECT;

		public float LOS_INDIRECT_HEIGHT_OFFSET;

		public float LOS_START_DIST_BIAS;

		public float MAX_HEALTH;

		public float MAX_AMMO;

		public Dictionary<int, int> AMMO_WARES;

		public bool CAN_MOVE;

		public bool CAN_SPECIFY_TARGET;

		public bool CREEPER_DAMAGES_ONLY_ON_HEIGHT;

		public bool MOVE_IGNORE_LAND;

		public bool ONLY_ON_RESOURCE;

		public bool AVOID_CONTAMINANT;

		public bool AVOID_MESH;

		public bool IGNORE_FOG;

		public bool ONLY_ON_VOID;

		public bool ALLOW_PLATFORM;

		public bool CREATE_FOOTPRINT;

		public bool START_BUILDING;

		public bool PLAYER_CAN_DESTROY;

		public bool SHAKE_CAMERA_ON_DESTROY;

		public bool CREEPER_DAMAGES;

		public bool ANTICREEPER_DAMAGES;

		public bool CAN_STUN;

		public bool DESTROY_ON_UNEVEN_TERRAIN;

		public bool CAN_ERN;

		public bool REQUEST_PACKETS;

		public bool CAN_REQUEST_AMMO;

		public bool CAN_PASS_PACKETS;

		public bool DRAG_SELECTABLE;

		public bool HAS_BUILD_BAR;

		public bool HAS_HEALTH_BAR;

		public bool HAS_AMMO_BAR;

		public Vector3 BUILD_BAR_POS_BACK;

		public Vector3 HEALTH_BAR_POS_BACK;

		public Vector3 AMMO_BAR_POS_BACK;

		public Vector3 BUILD_BAR_POS_FORWARD;

		public Vector3 HEALTH_BAR_POS_FORWARD;

		public Vector3 AMMO_BAR_POS_FORWARD;

		public int PSEUDO_TERRAIN_HEIGHT;

		public bool LOG_DESTROY;

		public float DECREASES_COMMAND_SCORE;

		public bool INCLUDE_IN_GAME_RECORDER;

		public bool CAN_NULLIFY;

		public int SUPPLY;

		public bool CAN_ROTATE;

		public int SPECIAL_TARGET;

		public string DESTROYED_SOUND;

		public string DESTROYED_EXPLOSION;

		public Vector3 DESTROYED_EXPLOSION_SCALE;

		public string POPUPTEXT0;

		public string POPUPTEXT1;

		public string MVERSEBARRELNAME;

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public static Vector3 BUILD_BAR_POS_BACK_DEFALUT;

	public static Vector3 HEALTH_BAR_POS_BACK_DEFALUT;

	public static Vector3 AMMO_BAR_POS_BACK_DEFALUT;

	public static Vector3 BUILD_BAR_POS_FORWARD_DEFALUT;

	public static Vector3 HEALTH_BAR_POS_FORWARD_DEFALUT;

	public static Vector3 AMMO_BAR_POS_FORWARD_DEFALUT;

	private Dictionary<string, UnitConstants> unitConstants;

	public UnitConstants GetUnitContants(string unit)
	{
		return null;
	}

	public void SetUnitConstants(string unit, UnitConstants c)
	{
	}

	public void InitDefaultUnits()
	{
	}
}
