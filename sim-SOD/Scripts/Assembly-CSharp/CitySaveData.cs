using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CitySaveData
{
	[Serializable]
	public class DistrictCitySave
	{
		public string name;

		public string preset;

		public int districtID;

		public List<BlockCitySave> blocks;

		public float averageLandValue;

		public List<SocialStatistics.EthnicityFrequency> dominantEthnicities;
	}

	[Serializable]
	public class BlockCitySave
	{
		public string name;

		public int blockID;

		public float averageDensity;

		public float averageLandValue;
	}

	[Serializable]
	public class CityTileCitySave
	{
		public string name;

		public int blockID;

		public int districtID;

		public Vector2Int cityCoord;

		public BuildingCitySave building;

		public List<TileCitySave> outsideTiles;

		public BuildingPreset.Density density;

		public BuildingPreset.LandValue landValue;
	}

	[Serializable]
	public class BuildingCitySave
	{
		public int buildingID;

		public string name;

		public List<FloorCitySave> floors;

		public string preset;

		public NewBuilding.Direction facing;

		public bool isInaccessible;

		public List<NewBuilding.SideSign> sideSigns;

		public List<AirDuctGroupCitySave> airDucts;

		public string designStyle;

		public Color wood;

		public string floorMaterial;

		public Toolbox.MaterialKey floorMatKey;

		public string ceilingMaterial;

		public Toolbox.MaterialKey ceilingMatKey;

		public string defaultWallMaterial;

		public Toolbox.MaterialKey defaultWallKey;

		public string extWallMaterial;

		public Toolbox.MaterialKey extWallKey;

		public string colourScheme;

		public string floorMatOverride;

		public string ceilingMatOverride;

		public string wallMatOverride;

		public string floorMatOverrideB;

		public string ceilingMatOverrideB;

		public string wallMatOverrideB;
	}

	[Serializable]
	public class AirDuctGroupCitySave
	{
		public int id;

		public bool ext;

		public List<int> airVents;

		public List<AirDuctSegmentCitySave> airDucts;

		public List<int> ventRooms;

		public List<int> adjoining;
	}

	[Serializable]
	public class AirDuctSegmentCitySave
	{
		public int level;

		public int index;

		public Vector3Int duct;

		public Vector3Int previous;

		public Vector3Int next;

		public Vector3Int node;

		public bool peek;

		public Vector3Int addRot;
	}

	[Serializable]
	public class AirVentSave
	{
		public int id;

		public NewAddress.AirVent ventType;

		public int wall;

		public Vector3Int node;

		public Vector3Int rNode;
	}

	[Serializable]
	public class FloorCitySave
	{
		public string name;

		public int floorID;

		public int floor;

		public List<AddressCitySave> addresses;

		public List<TileCitySave> tiles;

		public Vector2 size;

		public int defaultFloorHeight;

		public int defaultCeilingHeight;

		public int layoutIndex;

		public bool echelons;

		public int breakerSec;

		public int breakerLights;

		public int breakerDoors;
	}

	[Serializable]
	public class TileCitySave
	{
		public int tileID;

		public Vector2Int floorCoord;

		public Vector3Int globalTileCoord;

		public bool isEdge;

		public int rotation;

		public bool isEntrance;

		public bool isMainEntrance;

		public bool isStairwell;

		public int stairwellRotation;

		public bool isElevator;

		public int elevatorRotation;

		public bool isTop;

		public bool isBottom;
	}

	[Serializable]
	public class StreetCitySave
	{
		public string name;

		public AddressPreset.AccessType access;

		public List<RoomCitySave> rooms;

		public string designStyle;

		public int streetID;

		public int district;

		public List<Vector3Int> tiles;

		public string streetSuffix;

		public bool isAlley;

		public bool isBackstreet;

		public List<int> sharedGround;

		public List<StreetController.StreetTile> streetTiles;
	}

	[Serializable]
	public class AddressCitySave
	{
		public string name;

		public int residenceNumber;

		public bool isLobby;

		public bool isOutside;

		public AddressPreset.AccessType access;

		public List<RoomCitySave> rooms;

		public string designStyle;

		public bool neonHor;

		public bool neonVer;

		public int neonVerticalIndex;

		public int neonColour;

		public string neonFont;

		public float landValue;

		public GameplayController.Passcode passcode;

		public List<Vector3> protectedNodes;

		public int id;

		public string address;

		public string preset;

		public Color wood;

		public ResidenceCitySave residence;

		public CompanyCitySave company;

		public bool isOutsideAddress;

		public bool isLobbyAddress;

		public int breakerSec;

		public int breakerLights;

		public int breakerDoors;
	}

	[Serializable]
	public class ResidenceCitySave
	{
		public string preset;

		public int mail;
	}

	[Serializable]
	public class CompanyCitySave
	{
		public string preset;

		public int id;

		public List<OccupationCitySave> companyRoster;

		public string shortName;

		public List<string> nameAltTags;

		public int passedWorkLocation;

		public List<string> menuItems;

		public List<int> itemCosts;
	}

	[Serializable]
	public class OccupationCitySave
	{
		public int id;

		public string preset;

		public string name;

		public bool teamLeader;

		public int boss;

		public float paygrade;

		public int teamID;

		public bool isOwner;

		public OccupationPreset.workType work;

		public List<OccupationPreset.workTags> tags;

		public int shift;

		public float startTime;

		public float endTime;

		public List<SessionData.WeekDay> workDaysList;

		public float salary;

		public string salaryString;
	}

	[Serializable]
	public class RoomCitySave
	{
		public string name;

		public List<NodeCitySave> nodes;

		public List<string> openPlanElements;

		public List<LightZoneSave> lightZones;

		public List<int> commonRooms;

		public int floorID;

		public int id;

		public int fID;

		public int iID;

		public string preset;

		public bool reachableFromEntrance;

		public bool isOutsideWindow;

		public bool allowCoving;

		public string floorMaterial;

		public Toolbox.MaterialKey floorMatKey;

		public string ceilingMaterial;

		public Toolbox.MaterialKey ceilingMatKey;

		public string defaultWallMaterial;

		public Toolbox.MaterialKey defaultWallKey;

		public Toolbox.MaterialKey miscKey;

		public string colourScheme;

		public string mainLightPreset;

		public bool isBaseNullRoom;

		public Vector3 middle;

		public List<FurnitureClusterCitySave> f;

		public List<int> owners;

		public List<AirVentSave> airVents;

		public GameplayController.Passcode password;

		public int cf;

		public List<CullTreeSave> cullTree;

		public List<int> above;

		public List<int> below;

		public List<int> adj;

		public List<int> occ;
	}

	[Serializable]
	public class CullTreeSave
	{
		public int r;

		public List<int> d;
	}

	[Serializable]
	public class LightZoneSave
	{
		public List<Vector3Int> n;

		public Color areaLightColour;

		public float areaLightBright;
	}

	[Serializable]
	public class NodeCitySave
	{
		public Vector3Int nc;

		public List<WallCitySave> w;

		public NewNode.FloorTileType ft;

		public string fr;

		public string frr;
	}

	[Serializable]
	public class WallCitySave
	{
		public Vector2 wo;

		public int id;

		public string p;

		public int ow;

		public int pw;

		public int cw;

		public bool oo;

		public bool oa;

		public int cl;

		public bool sw;

		public List<WallFrontageSave> fr;

		public bool dm;

		public Toolbox.MaterialKey dmk;

		public float ds;

		public float ls;
	}

	[Serializable]
	public class WallFrontageSave
	{
		public string str;

		public Toolbox.MaterialKey matKey;

		public Vector3 o;
	}

	[Serializable]
	public class FurnitureClusterCitySave
	{
		public string cluster;

		public Vector3Int anchorNode;

		public int angle;

		public List<FurnitureClusterObjectCitySave> objs;
	}

	[Serializable]
	public class FurnitureClusterObjectCitySave
	{
		public int id;

		public List<string> furnitureClasses;

		public int angle;

		public Vector3Int anchorNode;

		public List<Vector3Int> coversNodes;

		public Vector3 offset;

		public string furniture;

		public string art;

		public bool up;

		public Vector3 scale;

		public Toolbox.MaterialKey matKey;

		public Toolbox.MaterialKey artMatKet;

		public List<int> owners;
	}

	[Serializable]
	public class HumanCitySave
	{
		public int humanID;

		public int home;

		public float speedModifier;

		public int job;

		public string birthday;

		public float societalClass;

		public Descriptors descriptors;

		public Human.BloodType blood;

		public string citizenName;

		public string firstName;

		public string casualName;

		public string surName;

		public bool homeless;

		public float slangUsage;

		public float genderScale;

		public Human.Gender gender;

		public Human.Gender bGender;

		public float sexuality;

		public float homosexuality;

		public List<Human.Gender> attractedTo;

		public int partner;

		public int paramour;

		public string anniversary;

		public float sleepNeedMultiplier;

		public float snoring;

		public float snoreDelay;

		public float humility;

		public float emotionality;

		public float extraversion;

		public float agreeableness;

		public float conscientiousness;

		public float creativity;

		public List<AcquaintanceCitySave> acquaintances;

		public List<CharTraitSave> traits;

		public GameplayController.Passcode password;

		public float maxHealth;

		public float recoveryRate;

		public float combatSkill;

		public float combatHeft;

		public float maxNerve;

		public float breathRecovery;

		public string handwriting;

		public int sightingMemory;

		public List<string> favItems;

		public List<int> favItemRanks;

		public List<CompanyPreset.CompanyCategory> favCat;

		public List<int> favAddresses;

		public List<CitizenOutfitController.Outfit> outfits;

		public int favCol;
	}

	[Serializable]
	public class CharTraitSave
	{
		public int traitID;

		public string trait;

		public int reason;

		public string date;
	}

	[Serializable]
	public class AcquaintanceCitySave
	{
		public int from;

		public int with;

		public List<Acquaintance.ConnectionType> connections;

		public Acquaintance.ConnectionType secret;

		public float compatible;

		public float known;

		public float like;

		public List<Evidence.DataKey> dataKeys;
	}

	[Serializable]
	public class EvidenceStateSave
	{
		public string id;

		public int page;

		public List<EvidenceMultiPage.MultiPageContent> mpContent;
	}

	public string build;

	public string cityName;

	public string seed;

	public Vector2 citySize;

	public int population;

	public int playersApartment;

	public List<DistrictCitySave> districts;

	public List<StreetCitySave> streets;

	public List<CityTileCitySave> cityTiles;

	public List<HumanCitySave> citizens;

	public List<Interactable> interactables;

	public List<GroupsController.SocialGroup> groups;

	public List<PipeConstructor.PipeGroup> pipes;

	public List<OccupationCitySave> criminals;

	public List<EvidenceStateSave> multiPage;

	public List<MetaObject> metas;
}
