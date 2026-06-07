using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tyd;
using UnityEngine;

public class FurnCompMeta : WallSnapCompMeta
{
	[FurnModAttr("name", FurnModAttr.VariableType.String, ReflectTarget = true, Desc = "This name will be used to uniquely identify your furniture, so you should try to make it as unique as possible")]
	public string Name;

	[FurnModAttr("LocalizedName", FurnModAttr.VariableType.String, ReflectTarget = true, Desc = "This is the name that will be used in the UI and which can be translated to other languages")]
	public string LocalizedName;

	[FurnModAttr("Type", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", FetchList = "GetAllTypes", Desc = "The actual type of this furniture")]
	public string Type;

	[FurnModAttr("CanFallback", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture can be replaced by base furniture in case it's not available on target PC. Should only be true if they have the same dimensions")]
	public bool CanFallback;

	[FurnModAttr("ButtonDescription", FurnModAttr.VariableType.BigString, ReflectTarget = true)]
	public string Description;

	[FurnModAttr("Cost", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture")]
	public float Price;

	[FurnModAttr("UnlockYear", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", Desc = "Which year furniture unlocks. 0 if always unlocked")]
	public int UnlockYear;

	[FurnModAttr("UpgradeTo", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", ReflectTarget = true, FetchList = "GetAllUpgrades", Desc = "A group of furniture that this furniture can be replaced by")]
	public string UpgradeTo;

	[FurnModAttr("Category", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", IsArray = true, FetchList = "GetAllCats", Desc = "If you want your furniture to be placed in the construction panel, set this to one single \"Construction\" category")]
	public string[] Category;

	[FurnModAttr("FunctionCategory", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", FetchList = "GetAllFuncs", Desc = "Which functional category to put furniture in")]
	public string FunctionCategory;

	[FurnModAttr("IsIconic", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", IsArray = true, FetchList = "GetAllCatsAndFuncs", Desc = "Which categories to use furniture thumbnail for, if any")]
	public string[] UseThumbnail;

	public string Thumbnail;

	[FurnModHeader("Boundaries")]
	[FurnModAttr("Height1", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Desc = "This is the lowest point of your furniture, this should be -0.1 for carpets")]
	public float Bottom;

	[FurnModAttr("Height2", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Desc = "This is the highest point of your furniture, this should be -0.05 for carpets")]
	public float Top;

	[FurnModAttr("OnXEdge", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Desc = "Whether to offset the furniture on the x-axis of the build grid")]
	public bool XGridOffset;

	[FurnModAttr("OnYEdge", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Desc = "Whether to offset the furniture on the y-axis of the build grid")]
	public bool YGridOffset;

	[FurnModAttr(null, typeof(BoxCollider), CanDisableComp = false, Desc = "This box is used as a collider for mouse selection")]
	public FurnColliderMeta Collider;

	[FurnModHeader("In-game options")]
	[FurnModAttr("MaxQueue", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", Desc = "How many can queue up to use this furniture")]
	public int MaxQueue;

	[FurnModAttr("Wattage", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How much electricity furniture consumes in watt, which is scaled up to a months use")]
	public float Wattage;

	[FurnModAttr("Water", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How much water furniture consumes in liters per hour, which is scaled up to a months use")]
	public float Water;

	[FurnModAttr("Gas", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How much gas furniture consumes in cubic meters per hour, which is scaled up to a months use")]
	public float Gas;

	[FurnModAttr("ExpectedOn", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How many hours per day you expect this furniture to be turned on")]
	public float ExpectedOnTime;

	[FurnModAttr("Noisiness", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How much noise furniture generates")]
	public float Noisiness;

	[FurnModAttr("Comfort", FurnModAttr.VariableType.PercentSlider, WriteDirectParent = "Furniture")]
	public float Comfort;

	[FurnModAttr("Environment", FurnModAttr.VariableType.PercentSlider, WriteDirectParent = "Furniture", UpperBound = 2f, Desc = "100% means no change in environment")]
	public float Environment;

	[FurnModAttr("AcousticDampening", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "Basically the furniture's area in 2D times how soft it is")]
	public float AcousticDampening;

	[FurnModAttr("AirCleaning", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How many square meters of air this furniture can clean per hour, negative if polluting")]
	public float AirFiltration;

	[FurnModAttr("CanAssign", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture can be assigned to an employee as the sole user")]
	public bool CanAssign;

	[FurnModAttr("CanLean", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether employee can lean back in this couch or chair")]
	public bool CanLean;

	[FurnModAttr("CanSteal", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture")]
	public bool CanSteal;

	[FurnModAttr("AlwaysOn", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture is always on using water/electricity and/or degrading")]
	public bool AlwaysOn;

	[FurnModAttr("DefaultOn", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture is defaults to being on when created, ignored if AlwaysOn")]
	public bool DefaultOn;

	[FurnModAttr("DisableObjs", FurnModAttr.VariableType.ExternalComponent, ComponentType = typeof(Transform), IsArray = true, Desc = "List of objects that are disabled when furniture is turned off")]
	public GameObject[] DisableObjects;

	[FurnModAttr("TheScreen", FurnModAttr.VariableType.ExternalComponent, ComponentType = typeof(Renderer), Desc = "An object that changes material when the furniture is turned on or off")]
	public GameObject Screen;

	[FurnModAttr("OnMat", FurnModAttr.VariableType.Material, Desc = "Material to use on screen when furniture is turned on")]
	public Material OnMat;

	[FurnModAttr("OffMat", FurnModAttr.VariableType.Material, Desc = "Material to use on screen when furniture is turned off")]
	public Material OffMat;

	[FurnModAttr("Lighting", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How much this furniture lights up a room")]
	public float Lighting;

	[FurnModAttr("Wait", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How long to wait on furniture, e.g. for coffee machines")]
	public float Wait;

	[FurnModAttr("MiscPotential", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "Used to determine power for different furniture, used for coffee and security cam or posture effect for chairs")]
	public float MiscPotential;

	[FurnModAttr("OnHead", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether employee using furniture will put it on their head")]
	public bool OnHead;

	[FurnModAttr("ComputerTransform", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", Dependency = "Type", DependencyValue = "Computer", ComponentType = typeof(Transform), Desc = "Reference to computer mesh or parent of computer meshes, if multiple")]
	public GameObject ComputerTransform;

	[FurnModAttr("OriginalOffset", FurnModAttr.VariableType.Vector3, WriteDirectParent = "Furniture", Dependency = "Type", DependencyValue = "Computer", Desc = "Computer's original position relative to parent transform")]
	public Vector3 OriginalOffset;

	[FurnModAttr("PCAddonOffset", FurnModAttr.VariableType.Vector3, WriteDirectParent = "Furniture", Desc = "Computer's position relative to parent transform when addon is snapped to it or addon's position when attached to employee head")]
	public Vector3 AddonOffset;

	[FurnModAttr("OriginalRotation", FurnModAttr.VariableType.Vector3, WriteDirectParent = "Furniture", Dependency = "Type", DependencyValue = "Computer", Desc = "Computer's original rotation relative to parent transform")]
	public Vector3 OriginalRotation;

	[FurnModAttr("PCAddonRotation", FurnModAttr.VariableType.Vector3, WriteDirectParent = "Furniture", Desc = "Computer's rotation relative to parent transform when addon is snapped to it or addon's rotation when attached to employee head")]
	public Vector3 AddonRotation;

	[FurnModAttr("ComputerPowerModifier", FurnModAttr.VariableType.PercentSlider, WriteDirectParent = "Furniture", UpperBound = 10f, Dependency = "Type", DependencyValue = "Computer", Desc = "How much the power of this computer differs from others of the same time period")]
	public float ComputerPowerModifier;

	[FurnModAttr("IgnorePCRelease", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "Type", DependencyValue = "Computer", Desc = " Whether PC should affect the decline of PC performance when unlocked")]
	public bool IgnorePCRelease;

	[FurnModAttr("HoldablePoints", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), IsArray = true, Desc = "Points where stuff can be placed, e.g. food")]
	public GameObject[] HoldablePoints;

	[FurnModAttr("DespawnHoldables", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether to despawn stuff that is placed on this furniture")]
	public bool DespawnHoldables;

	[FurnModAttr("DespawnHour", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How many hours to wait before despawning")]
	public float DespawnHour;

	[FurnModAttr("DisableTableGrouping", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether this table should be grouped with other tables for meetings, canteen, etc.")]
	public bool DisableTableGrouping;

	[FurnModAttr("LookAtPoints", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), IsArray = true, Desc = "Points the employee should look at when interacting with furniture")]
	public GameObject[] LookAtPoints;

	[FurnModAttr("ActiveWithOn", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), Desc = "An object that should be enabled or disabled based on whether furniture is turned on")]
	public GameObject ActiveWhenOn;

	[FurnModAttr("InteractChangeMesh", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(MeshFilter), Desc = "An object whose mesh should change when furniture is interacted with")]
	public GameObject InteractChangeMesh;

	[FurnModAttr("InteractMesh", FurnModAttr.VariableType.Mesh, WriteDirectParent = "Furniture", Dependency = "InteractChangeMesh", Desc = "The mesh to use after furniture has been interacted with")]
	public Mesh InteractMesh;

	[FurnModAttr("DefaultMesh", FurnModAttr.VariableType.Mesh, WriteDirectParent = "Furniture", Dependency = "InteractChangeMesh", Desc = "The mesh to use when furniture is no longer being interacted with")]
	public Mesh DefaultMesh;

	[FurnModAttr(null, FurnModAttr.VariableType.Float, Desc = "Only relevant if furniture is based on a server")]
	public float ServerPower;

	[FurnModAttr("Unlockable", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", FetchList = "GetAllUnlocks", Desc = "Which task player need to complete to unlock this furniture. Leave completely blank for none")]
	public string Unlockable;

	[FurnModAttr("AtriumObject", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), Desc = "An object that is scaled depending on atrium height, like a wire from a ceiling lamp. The mesh should be exactly 1 unit tall (Scaling in editor will be used when placing) and origin should be at the bottom of the mesh (See Atrium Fixture)")]
	public GameObject AtriumObject;

	[FurnModAttr("ReverseAtriumScale", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "AtriumObject", Desc = "Will scale atrium object to ceiling if false, otherwise towards floor")]
	public bool ReverseAtriumScale;

	[FurnModHeader("Blueprint")]
	[FurnModAttr("BlueprintReplaceable", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether this furniture can be replaced with a compatible furniture in the blueprint window (Has to have same fit or be smaller, have identical snap points and type)")]
	public bool Replaceable;

	[FurnModAttr("BlueprintUpgradeFrom", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether this furniture should always be replaced with a newer model in the blueprint menu when possible (e.g. computers)")]
	public bool ReplaceFrom;

	[FurnModAttr("BlueprintUpgradeTo", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether this furniture can immediately be upgraded to in the blueprint menu")]
	public bool ReplaceTo;

	[FurnModHeader("Perishable options")]
	[FurnModAttr("Capacity", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", Desc = "How many perishables furniture can hold")]
	public int Capacity;

	[FurnModAttr("RefillCapacity", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether to refill automatically at the end of day")]
	public bool RefillCapacity;

	[FurnModAttr("UnitCost", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "How much a single perishable costs")]
	public float UnitCost;

	[FurnModAttr("Expiration", FurnModAttr.VariableType.Integer, WriteDirectParent = "Furniture", Desc = "How many months before content expires. 0 For every month and -1 for never")]
	public int Expiration;

	[FurnModHeader("Build options")]
	[FurnModAttr("BasementValid", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture")]
	public bool ValidInBasement;

	[FurnModAttr("InRentMode", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether this furniture is purchasable when renting")]
	public bool InRentMode;

	[FurnModAttr("IsDraggable", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether you can drag a line out to place multiple of the furniture at once")]
	public bool IsDraggable;

	[FurnModAttr("DragDistance", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "Distance between each instance as you drag")]
	public float DragDistance;

	[FurnModAttr("InFloor", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture is embedded in floor and will only collide with other in embedded objects or things that block the floor")]
	public bool InFloor;

	[FurnModAttr("BlocksFloor", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture blocks objects embedded in floor")]
	public bool BlocksFloor;

	[FurnModAttr("ValidIndoors", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture can be placed indoors")]
	public bool ValidIndoors;

	[FurnModAttr("ValidOutdoors", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture can be placed in outdoor fenced-in areas")]
	public bool ValidOutdoors;

	[FurnModAttr("ValidOutside", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture can be placed directly outside, not bounded by any rooms")]
	public bool ValidOutside;

	[FurnModAttr("OnlyOnGrass", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture can only be placed on outdoor green areas")]
	public bool OnlyOnGrass;

	[FurnModAttr("AtriumValid", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture should be allowed in upper floors of an atrium")]
	public bool AtriumValid;

	[FurnModAttr("AtriumFixture", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "If furniture is attached to ceiling, should it still be allowed to be placed on lower floors of an atrium? (See Atrium Object)")]
	public bool AtriumFixture;

	[FurnModAttr("PokesThroughRoof", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture")]
	public bool PokesThroughRoof;

	[FurnModAttr("TwoFloors", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether furniture takes up space on two floors, like stairs")]
	public bool TwoFloors;

	[FurnModAttr("MakeHole", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "TwoFloors", Desc = "Whether to use nav boundary to cut a hole in the roof when placed")]
	public bool MakeHole;

	[FurnModAttr("OnRoofObject", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(MeshFilter), Desc = "An object that sits on the floor above the floor the furniture was placed on")]
	public GameObject OnRoofObject;

	[FurnModAttr("IgnoreType", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", FetchList = "GetAllTypes", Desc = "A type of furniture that should be ignored when checking collisions")]
	public string IgnoreType;

	[FurnModAttr("CustomizationRotation", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Desc = "Rotation offset of furniture preview in style panel")]
	public float CustomizationRotation;

	[FurnModAttr("AutoPlaceGroup", FurnModAttr.VariableType.String, IsArray = true, WriteDirectParent = "Furniture", FetchList = "GetAllPlaceAlgos", Desc = "An algorithm to use for auto placement")]
	public string[] AutoPlaceGroup;

	[FurnModHeader("Wall options")]
	[FurnModAttr("WallFurn", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Desc = "Whether this furniture is placed on a wall")]
	public bool WallFurniture;

	[FurnModAttr("YOffset", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Dependency = "WallFurniture", Desc = "Controls how high up along the wall the mouse will be sampled for placing the furniture on a wall")]
	public float YOffset;

	[FurnModAttr("WallWidth", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Dependency = "WallFurniture", Desc = "How wide the furniture is on a wall")]
	public float WallWidth;

	[FurnModAttr("CustomHeight", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Dependency = "WallFurniture", Desc = "If your furniture can be moved up and down the wall, this is its default position")]
	public bool CustomHeight;

	[FurnModAttr("WallHeight", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Dependency = "CustomHeight", Desc = "How tall the furniture is on a wall")]
	public float WallHeight;

	[FurnModAttr("ValidHeights", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", IsArray = true, Dependency = "CustomHeight", Desc = "This is a list of heights at which your furniture can be placed on a wall, from 0 to 2")]
	public float[] ValidHeights;

	[FurnModAttr("GridSizeOverride", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether to override the grid size when placing, e.g. 2 for half size grid")]
	public float GridSizeOverride;

	[FurnModAttr("ReverseWallSide", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether this furniture sits on the exterior of the wall it's placed on, like the company sign")]
	public bool ReverseWallSide;

	[FurnModAttr("OnlyExteriorWalls", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether furniture has to be placed on a wall that faces the exterior")]
	public bool OnlyExterior;

	[FurnModAttr("OnlyInteriorWalls", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether furniture has to be placed on a wall that faces another room")]
	public bool OnlyInterior;

	[FurnModAttr("ValidAgainstOutdoorArea", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether furniture can be placed on a wall facing an outdoor area")]
	public bool ValidAgainstOutdoor;

	[FurnModAttr("PokesThroughWall", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether the furniture pokes through the wall it's placed on")]
	public bool PokesThroughWall;

	[FurnModAttr("ValidOnFence", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture")]
	public bool ValidOnFence;

	[FurnModAttr("WallFurnHide", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "WallFurniture", Desc = "Whether to render furniture when it is obstructed by a wall. Should be toggled off if your furniture sticks out so much from the wall, that it cannot be obstructed by the wall completely")]
	public bool HideOnWall;

	[FurnModHeader("Snap options")]
	[FurnModAttr("IsSnapping", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, CallMethod = "SetStage", Desc = "Whether the furniture snaps to points on another furniture")]
	public bool IsSnapping;

	[FurnModAttr("CanNotSnap", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "IsSnapping", Desc = "Whether the furniture is allowed to be placed directly on the floor as well")]
	public bool PlaceOnFloor;

	[FurnModAttr("SnapsTo", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", IsArray = true, ReflectTarget = true, CallMethod = "SetStage", Dependency = "IsSnapping", FetchList = "GetAllSnaps")]
	public string[] SnapsTo;

	[FurnModAttr("CanRotate", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "IsSnapping", Desc = "Whether the furniture can be rotated on its snap points. Chairs can't for instance")]
	public bool CanRotate;

	[FurnModAttr("Only180Rotation", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "IsSnapping", Desc = "Whether the furniture can only be pointed forwards or backwards from the snap point's orientation. Used for drop points on conveyor belts.")]
	public bool Only180Rotation;

	[FurnModAttr("SurfaceSnapRadius", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Dependency = "IsSnapping", ReflectTarget = true, Desc = "If this is above 0, this furniture can be snapped to points on surfaces. The radius controls collisions with other objects on the surface and minimum distance to its edge")]
	public float SurfaceSnapRadius;

	[FurnModAttr("NeedsChair", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "IsSnapping", Desc = "Warn the player if there is no chair in the linked snap point")]
	public bool NeedsChair;

	[FurnModAttr("OnWithParent", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "IsSnapping", Desc = "Whether furniture turns on when furniture it is snapped to does")]
	public bool OnWithSnap;

	[FurnModHeader("Colors")]
	[FurnModAttr("ColorPrimaryEnabled", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true)]
	public bool Primary;

	[FurnModAttr("ColorPrimaryDefault", FurnModAttr.VariableType.Color, WriteDirectParent = "Furniture", ReflectProp = "ColorPrimary", CallMethod = "RefreshLightColors", Dependency = "Primary")]
	public Color PrimaryColor;

	[FurnModAttr("PrimaryColorName", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", Dependency = "Primary", ReflectTarget = true)]
	public string PrimaryColorName;

	[FurnModAttr("ColorSecondaryEnabled", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true)]
	public bool Secondary;

	[FurnModAttr("ColorSecondaryDefault", FurnModAttr.VariableType.Color, WriteDirectParent = "Furniture", ReflectProp = "ColorSecondary", CallMethod = "RefreshLightColors", Dependency = "Secondary")]
	public Color SecondaryColor;

	[FurnModAttr("SecondaryColorName", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", Dependency = "Secondary", ReflectTarget = true)]
	public string SecondaryColorName;

	[FurnModAttr("ForceColorSecondary", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, Desc = "Whether furniture should be forced to use default secondary color")]
	public bool ForceColorSecondary;

	[FurnModAttr("ChangeColorOffSecondary", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether to make secondary color black when furniture is turned off")]
	public bool ColorOffSecondary;

	[FurnModAttr("ColorTertiaryEnabled", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true)]
	public bool Tertiary;

	[FurnModAttr("ColorTertiaryDefault", FurnModAttr.VariableType.Color, WriteDirectParent = "Furniture", ReflectProp = "ColorTertiary", CallMethod = "RefreshLightColors", Dependency = "Tertiary")]
	public Color TertiaryColor;

	[FurnModAttr("TertiaryColorName", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", Dependency = "Tertiary", ReflectTarget = true)]
	public string TertiaryColorName;

	[FurnModAttr("ForceColorTertiary", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, Desc = "Whether furniture should be forced to use default tertiary color")]
	public bool ForceColorTertiary;

	[FurnModAttr("ChangeColorOffTertiary", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether to make tertiary color black when furniture is turned off")]
	public bool ColorOffTertiary;

	[FurnModAttr("LightPrimary", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", ReflectTarget = true, Desc = "Whether light color should be controlled by primary or tertiary color")]
	public bool LightPrimary;

	[FurnModAttr("EmissionOnWithFurniture", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether to turn emission on/off with furniture On state")]
	public bool EmissionOnWithFurniture;

	[FurnModAttr("EmissionWarmUp", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether emission should slowly turn on/off")]
	public bool EmissionWarmUp;

	[FurnModAttr("AltStyles", FurnModAttr.VariableType.FurnitureStyle, CanInstantiate = true, IsList = true, Desc = "Default alternative furniture colors")]
	public List<FurnitureStyle> AltStyles;

	[FurnModAttr("_defaultColorGroup", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", FetchList = "GetAllColorGroups", Desc = "Name of group that furniture is compatible with for color mapping, like normal and round tables. Leave completely blank for none.")]
	public string ColorGroup;

	[FurnModHeader("Replacement options")]
	[FurnModAttr("ReplacementGroups", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", IsArray = true, FetchList = "GetAllReplacementGroups", Desc = "Which replacement groups to use for this furniture as defined in replacements.tyd")]
	public string[] ReplacementGroups;

	[FurnModAttr("Replacements", FurnModAttr.VariableType.String, WriteDirectParent = "Furniture", IsArray = true, FetchList = "GetAllReplacementKeys", Desc = "Which replacement to use by default for this furniture in the same order as replacement groups")]
	public string[] DefaultReplacements;

	[FurnModHeader("External components")]
	[FurnModAttr(null, typeof(Upgradable), Desc = "If this component is enabled, this furniture can degrade and break over time")]
	public FurnUpgMeta Upgradable;

	[FurnModAttr("ITFix", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "Upgradable", Desc = "Whether furniture should be fixed by maintenance or IT")]
	public bool ITFix;

	[FurnModAttr(null, FurnModAttr.VariableType.Bool, CallMethod = "RefreshMeshShadows", Desc = "Whether the furniture has lights and should turn on when a room is dark and has occupants")]
	public bool IsLamp;

	[FurnModAttr(null, FurnModAttr.VariableType.Bool, Dependency = "IsLamp")]
	public bool HasShadows;

	[FurnModAttr(null, FurnModAttr.VariableType.Bool, Desc = "Whether furniture is a table that can be grouped and has/can have seating")]
	public bool IsTable;

	[FurnModHeader("Temperature options")]
	[FurnModAttr("TempControlType", FurnModAttr.VariableType.Enum, WriteDirectParent = "Furniture", Desc = "Whether furniture outputs heat or cold")]
	public Furniture.TemperatureType TemperatureType;

	[FurnModAttr("TemperatureController", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "TemperatureType", DependencyValue = Furniture.TemperatureType.None, ReverseDependency = true, Desc = "Whether furniture outputs heat or cold to temperature outputs")]
	public bool TemperatureController;

	[FurnModAttr("TemperatureOutput", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "TemperatureType", DependencyValue = Furniture.TemperatureType.None, ReverseDependency = true, Desc = "Whether furniture is an output for a temperature controller")]
	public bool TemperatureOutput;

	[FurnModAttr("HeatCoolArea", FurnModAttr.VariableType.Float, WriteDirectParent = "Furniture", Dependency = "TemperatureType", DependencyValue = Furniture.TemperatureType.None, ReverseDependency = true, Desc = "The amount of room area this furniture can heat/cool")]
	public float TemperatureArea;

	[FurnModAttr("EqualizeTemperature", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "TemperatureType", DependencyValue = Furniture.TemperatureType.None, ReverseDependency = true, Desc = "Whether furniture should try to hit room temperature or just always run at 100%")]
	public bool EqualizeTemperature;

	[FurnModAttr("TemperatureModifyUsage", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Dependency = "TemperatureType", DependencyValue = Furniture.TemperatureType.None, ReverseDependency = true, Desc = "Whether furniture electricity and water usage depends on current room temperature")]
	public bool TemperatureModifyUsage;

	[FurnModAttr("TempAccessPoint", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", Dependency = "TemperatureType", DependencyValue = Furniture.TemperatureType.None, ReverseDependency = true, ComponentType = typeof(Transform), Desc = "Point at which pipes connect up")]
	public GameObject TemperatureAccessPoint;

	[FurnModHeader("Traversal")]
	[FurnModAttr("OffsetPoints", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), IsArray = true, Desc = "Start and end position of path to traverse object")]
	public GameObject[] OffsetPoints;

	[FurnModAttr("InterPoints", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), IsArray = true, Desc = "All points of path to traverse object, not including end points")]
	public GameObject[] InterPoints;

	[FurnModAttr("InterPointsReversed", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), IsArray = true, Desc = "All points of path to traverse object the other way, not including end points")]
	public GameObject[] InterPointsReversed;

	[FurnModAttr("UpperFloorFrame", FurnModAttr.VariableType.ExternalComponent, WriteDirectParent = "Furniture", ComponentType = typeof(Transform), Desc = "A mesh that gives thickness to hole in floor cut out by stairs")]
	public GameObject UpperFloorFrame;

	[FurnModHeader("Use effects")]
	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 0)]
	public float Lead;

	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 1)]
	public float Programmer;

	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 2)]
	public float Designer;

	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 3)]
	public float Artist;

	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 4)]
	public float Service;

	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 5)]
	public float NoiseCancelling;

	[FurnModAttr("UseEffects", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 6)]
	public float SocialIsolation;

	[FurnModHeader("Aura values")]
	[FurnModAttr("CapAura", FurnModAttr.VariableType.Bool, WriteDirectParent = "Furniture", Desc = "Whether to limit this furniture's effect on the room's aura to its values, defaults to 25%")]
	public bool CapAura;

	[FurnModAttr("AuraCoverage", FurnModAttr.VariableType.Float, WriteDirectParent = "AuraCoverage", Desc = "How many square meters the furniture covers, which controls how many you need in a room to max the aura")]
	public float AuraCoverage = 40f;

	[FurnModAttr("AuraValues", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 0, LowerBound = -1f, Desc = "Negative values have a negative effect on the room and vice versa. -100% means disabled")]
	public float Effectiveness = -1f;

	[FurnModAttr("AuraValues", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 1, LowerBound = -1f, Desc = "Negative values have a negative effect on the room and vice versa. -100% means disabled")]
	public float Skill = -1f;

	[FurnModAttr("AuraValues", FurnModAttr.VariableType.PercentSlider, ArrayIndex = 2, LowerBound = -1f, Desc = "Negative values have a negative effect on the room and vice versa. -100% means disabled")]
	public float Mood = -1f;

	public override string MetaName
	{
		get
		{
			return "Furniture";
		}
	}

	public FurnCompMeta(Component target)
		: base(target)
	{
	}

	public void RefreshLightColors()
	{
		FurnitureModdingTool.Instance.RefreshLightColor();
	}

	public void SetStage()
	{
		FurnitureModdingTool.Instance.SetStage();
	}

	public override void OnActivate()
	{
		LampScript component = FurnitureModdingTool.Instance.ActiveObject.GetComponent<LampScript>();
		IsLamp = component != null;
		HasShadows = IsLamp && component.EnableShadows;
		IsTable = FurnitureModdingTool.Instance.ActiveObject.GetComponent<TableScript>() != null;
	}

	public void RefreshMeshShadows()
	{
		if (IsLamp)
		{
			FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnMeshMeta>().ForEachEnum(delegate(FurnMeshMeta x)
			{
				x.Shadows = false;
			});
		}
	}

	public void RefreshAtlas()
	{
		Furniture component = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>();
		FurnMeshMeta atlasObject = AtlasObject;
		object atlasObject2;
		if (atlasObject == null)
		{
			atlasObject2 = null;
		}
		else
		{
			Component target = atlasObject.Target;
			atlasObject2 = (((object)target != null) ? target.GetComponent<MeshRenderer>() : null);
		}
		component.AtlasObject = (MeshRenderer)atlasObject2;
		component.AtlasIndex = 0;
	}

	[FurnModAction]
	public void CheckUpgrades()
	{
		if (string.IsNullOrEmpty(UpgradeTo))
		{
			return;
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		Furniture furniture = (Furniture)Target;
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component != Target)
			{
				if (component.UpgradeCompatible(UpgradeTo))
				{
					list.Add(component.name);
				}
				if (!string.IsNullOrEmpty(component.UpgradeTo) && furniture.UpgradeCompatible(component.UpgradeTo))
				{
					list2.Add(component.name);
				}
			}
		}
		WindowManager.Instance.ShowMessageBox(Target.name + " can upgrade to: " + string.Join(", ", list) + "\nCan be upgraded to " + Target.name + ": " + string.Join(", ", list2), true, DialogWindow.DialogType.Information);
	}

	[FurnModAction]
	public void TestAtlas()
	{
		Furniture f = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>();
		if (f.AtlasCount > 0)
		{
			f.AtlasIndex = (f.AtlasIndex + 1) % f.AtlasCount;
		}
		else
		{
			if (f.ReplacementGroups == null || f.ReplacementGroups.Length == 0)
			{
				return;
			}
			List<ValueTuple<string, int, string>> options = new List<ValueTuple<string, int, string>>();
			for (int i = 0; i < f.ReplacementGroups.Length; i++)
			{
				ObjectDatabase.ReplacementGroup group;
				if (!ObjectDatabase.Instance.GetReplacementGroup(f.ReplacementGroups[i], out group))
				{
					continue;
				}
				foreach (ObjectDatabase.ReplacementObject replacement in group.Replacements)
				{
					options.Add(new ValueTuple<string, int, string>(group.Name + " -> " + replacement.Name, i, replacement.Name));
				}
			}
			if (options.Count > 0)
			{
				WindowManager.Instance.MultiWindow.Show("Replacements", options.Select((ValueTuple<string, int, string> x) => x.Item1), delegate(int x)
				{
					f.SetReplacement(options[x].Item2, options[x].Item3);
				}, false);
			}
		}
	}

	public IEnumerable<string> GetAllColorGroups()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (!string.IsNullOrEmpty(component._defaultColorGroup))
			{
				yield return component._defaultColorGroup;
			}
		}
	}

	public IEnumerable<string> GetAllUnlocks()
	{
		foreach (RewardTask task in GameData.Tasks)
		{
			yield return task.Name;
		}
	}

	public IEnumerable<string> GetAllUpgrades()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (!string.IsNullOrEmpty(component.UpgradeTo))
			{
				yield return component.UpgradeTo;
			}
		}
	}

	public IEnumerable<string> GetAllSnaps()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			SnapPoint[] snapPoints = component.SnapPoints;
			foreach (SnapPoint snapPoint in snapPoints)
			{
				yield return snapPoint.Name;
			}
		}
	}

	public IEnumerable<string> GetAllCats()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component.Category != null)
			{
				string[] category = component.Category;
				for (int i = 0; i < category.Length; i++)
				{
					yield return category[i];
				}
			}
		}
	}

	public IEnumerable<string> GetAllCatsAndFuncs()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture f = item.GetComponent<Furniture>();
			if (f.Category != null)
			{
				string[] category = f.Category;
				for (int i = 0; i < category.Length; i++)
				{
					yield return category[i];
				}
			}
			if (f.FunctionCategory != null)
			{
				yield return f.FunctionCategory;
			}
		}
	}

	public IEnumerable<string> GetAllReplacementGroups()
	{
		foreach (string replacementGroup in ObjectDatabase.Instance.GetReplacementGroups())
		{
			yield return replacementGroup;
		}
	}

	public IEnumerable<string> GetAllReplacementKeys()
	{
		string[] replacementGroups = ReplacementGroups;
		foreach (string text in replacementGroups)
		{
			ObjectDatabase.ReplacementGroup group;
			if (text == null || !ObjectDatabase.Instance.GetReplacementGroup(text, out group))
			{
				continue;
			}
			foreach (ObjectDatabase.ReplacementObject replacement in group.Replacements)
			{
				yield return replacement.Name;
			}
		}
	}

	public IEnumerable<string> GetAllFuncs()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component.FunctionCategory != null)
			{
				yield return component.FunctionCategory;
			}
		}
	}

	public IEnumerable<string> GetAllTypes()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component.Type != null)
			{
				yield return component.Type;
			}
		}
	}

	public IEnumerable<string> GetAllPlaceAlgos()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture f = item.GetComponent<Furniture>();
			if (f.AutoPlaceGroup != null)
			{
				for (int i = 0; i < f.AutoPlaceGroup.Length; i++)
				{
					yield return f.AutoPlaceGroup[i];
				}
			}
		}
	}

	public IEnumerable<string> GetAllTempControllers()
	{
		foreach (GameObject item in ObjectDatabase.Instance.GetAllFurniture())
		{
			Furniture component = item.GetComponent<Furniture>();
			if (component.TempControlType != Furniture.TemperatureType.None && component.TemperatureController)
			{
				yield return component.name;
			}
		}
	}

	private void SaveBounds(string target, TydTable root, Vector2[] self, Vector2[] baseB)
	{
		object value;
		if (self != null)
		{
			TydNode[] children = self.SelectInPlace((Vector2 x) => x.ToTyd());
			value = new TydList(target, children);
		}
		else
		{
			value = new TydString(target, null);
		}
		SetIfChanged(target, self, baseB, root, (TydNode)value);
	}

	public override void WriteToTyD(TydTable root)
	{
		root.SetNode("Name", Name, true);
		root.SetNode("Thumbnail", Thumbnail, true);
		TydTable tydTable = root.FindNode("Furniture", true) as TydTable;
		Furniture furniture = FurnitureModdingTool.Instance.ActivePrefab.BaseObject as Furniture;
		GameObject gameObject = null;
		if (furniture == null)
		{
			gameObject = new GameObject("Temp");
			furniture = gameObject.AddComponent<Furniture>();
			furniture.enabled = false;
		}
		if (tydTable != null)
		{
			if (!string.IsNullOrWhiteSpace(LocalizedName))
			{
				tydTable.SetNode("LocalizedName", LocalizedName, true);
			}
			else
			{
				tydTable.RemoveNode("LocalizedName");
			}
			if (!string.IsNullOrWhiteSpace(Description))
			{
				tydTable.SetNode("ButtonDescription", Description, true);
			}
			else
			{
				tydTable.RemoveNode("ButtonDescription");
			}
			Furniture component = FurnitureModdingTool.Instance.ActiveObject.GetComponent<Furniture>();
			SaveBounds("BuildBoundary", tydTable, component.BuildBoundary, ((object)furniture != null) ? furniture.BuildBoundary : null);
			SaveBounds("MeshBoundary", tydTable, component.MeshBoundary, ((object)furniture != null) ? furniture.MeshBoundary : null);
			SaveBounds("NavBoundary", tydTable, component.NavBoundary, ((object)furniture != null) ? furniture.NavBoundary : null);
			if (AtlasObject != null || (((object)furniture != null) ? furniture.AtlasObject : null) != null)
			{
				tydTable.SetNode("AtlasObject", (AtlasObject != null) ? AtlasObject.Target.name : null, true);
			}
			WriteDirects("Furniture", tydTable, furniture);
			tydTable.RemoveNode("UseEffects");
			List<KeyValuePair<Furniture.UseEffect, FieldInfo>> list = (from Furniture.UseEffect x in Enum.GetValues(typeof(Furniture.UseEffect))
				select new KeyValuePair<Furniture.UseEffect, FieldInfo>(x, Meta.Keys.First((FieldInfo z) => z.Name.Equals(x.ToString())))).ToList();
			TydTable tydTable2 = new TydTable("UseEffects");
			float[] ar = (((object)furniture != null) ? furniture.UseEffects : null);
			bool flag = false;
			for (int num = 0; num < list.Count; num++)
			{
				KeyValuePair<Furniture.UseEffect, FieldInfo> keyValuePair = list[num];
				float value = (float)keyValuePair.Value.GetValue(this);
				flag |= CheckArrayValue(ar, value, num, 0f);
				tydTable2.AddChild(new TydString(keyValuePair.Key.ToString(), value.ToString()));
			}
			if (flag)
			{
				tydTable.AddChild(tydTable2);
			}
			tydTable.RemoveNode("AuraValues");
			List<FieldInfo> list2 = (from Furniture.AuraTypes x in Enum.GetValues(typeof(Furniture.AuraTypes))
				orderby (int)x
				select Meta.Keys.First((FieldInfo z) => z.Name.Equals(x.ToString()))).ToList();
			TydList tydList = new TydList("AuraValues");
			float[] ar2 = (((object)furniture != null) ? furniture.AuraValues : null);
			bool flag2 = false;
			for (int num2 = 0; num2 < list2.Count; num2++)
			{
				float value2 = (float)list2[num2].GetValue(this);
				flag2 |= CheckArrayValue(ar2, value2, num2, -1f);
				tydList.AddChild(new TydString(null, value2.ToString()));
			}
			if (flag2)
			{
				tydTable.AddChild(tydList);
			}
		}
		TydNode root2 = root.FindNode("BoxCollider", true);
		BoxCollider boxCollider = (BoxCollider)Collider.Target;
		root2.SetNode("center", boxCollider.center.ToTyd("center"));
		root2.SetNode("size", boxCollider.size.ToTyd("size"));
		LampScript lampScript = (((object)furniture != null) ? furniture.GetComponent<LampScript>() : null);
		if (IsLamp != (lampScript != null) || (IsLamp && HasShadows != lampScript.EnableShadows))
		{
			if (!IsLamp)
			{
				root.AddChild(new TydTable("LampScript", new TydString("RemoveComponent", "True")));
			}
			else
			{
				root.AddChild(new TydTable("LampScript", new TydString("EnableShadows", HasShadows.ToString())));
			}
		}
		bool flag3 = (((object)furniture != null) ? furniture.GetComponent<TableScript>() : null) != null;
		if (IsTable != flag3)
		{
			if (!IsTable)
			{
				root.AddChild(new TydTable("TableScript", new TydString("RemoveComponent", "True")));
			}
			else
			{
				root.AddChild(new TydTable("TableScript"));
			}
		}
		if (furniture == null || (DisableObjects != null && DisableObjects.Length != 0) || (furniture.DisableObjs != null && furniture.DisableObjs.Length != 0))
		{
			if (DisableObjects != null && DisableObjects.Length != 0)
			{
				TydNode[] children = DisableObjects.SelectNotNull((GameObject x) => new TydString(null, x.name)).ToArray();
				tydTable.SetNode("DisableObjs", new TydList("DisableObjs", children));
			}
			else
			{
				tydTable.SetNode("DisableObjs", new TydList("DisableObjs"));
			}
		}
		else
		{
			tydTable.RemoveNode("DisableObjs");
		}
		if (Screen != null)
		{
			tydTable.SetNode("TheScreen", Screen.name, true);
			tydTable.SetNode("OnMat", OnMat.name, true);
			tydTable.SetNode("OffMat", OffMat.name, true);
		}
		if (AltStyles != null && AltStyles.Count > 0)
		{
			TydNode[] children = AltStyles.SelectInPlace((FurnitureStyle x) => new TydList(null, ColorUtility.ToHtmlStringRGB(x.Color1 ?? SVector3.Zero), ColorUtility.ToHtmlStringRGB(x.Color2 ?? SVector3.Zero), ColorUtility.ToHtmlStringRGB(x.Color3 ?? SVector3.Zero)));
			tydTable.SetNode("AltStyles", new TydList("AltStyles", children));
		}
		else
		{
			tydTable.RemoveNode("AltStyles");
		}
		if (Upgradable != null)
		{
			Upgradable.WriteToTyD(root);
		}
		else if ((((object)furniture != null) ? furniture.GetComponent<Upgradable>() : null) != null)
		{
			root.AddChild(new TydTable("Upgradable", new TydString("RemoveComponent", "True")));
		}
		Server server = (((object)furniture != null) ? furniture.GetComponent<Server>() : null);
		if (server != null && server.Power != ServerPower)
		{
			(root.FindNode("Server", true) as TydTable).SetNode("Power", ServerPower.ToString(), true);
		}
		if (gameObject != null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	private bool CheckArrayValue<T>(T[] ar, T value, int index, T defValue)
	{
		if ((ar != null || value.Equals(defValue)) && (ar == null || index >= ar.Length || ar[index].Equals(value)))
		{
			if (ar != null && index >= ar.Length)
			{
				return !value.Equals(defValue);
			}
			return false;
		}
		return true;
	}

	public override bool UseGizmo()
	{
		return false;
	}

	public override string GetMetaGroup()
	{
		return null;
	}
}
