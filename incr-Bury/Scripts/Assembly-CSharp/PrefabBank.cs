using System.Collections.Generic;
using UnityEngine;

public class PrefabBank : MonoBehaviour
{
	public PlantBed plantBed_SpawnedInScene;

	public Transform mainPlant_BerryLaunchTarget;

	[Header("Dirt Patches")]
	public BuildableInfo buildable_DirtPatch;

	public BerryProfile berryProfile_Dirt;

	[Header("Conveyor Belt")]
	public BuildableInfo buildable_ConveyorBelt;

	public GameObject conveyorBelt_InScene;

	[Header("Trampolines")]
	public BuildableInfo buildable_Trampoline;

	[Header("Blender")]
	public BuildableInfo buildable_Blender;

	[Header("Golden Berry")]
	public Material mat_GoldenBerry;

	[Header("Nebula Berry")]
	public Material mat_Nebula;

	[Header("Piggy Bank")]
	public GameObject piggyBankInScene;

	[Header("Berry Profiles")]
	public List<BerryProfile> berryProfiles;

	[Header("Coin Prefabs")]
	public List<GameObject> coinPrefabs;

	public List<int> coinValueAmounts;

	[Header("Seeds")]
	public GameObject seedPrefab;

	[Header("Materials")]
	public Material selectionOutline_Mat;

	[Header("Particles")]
	public GameObject bonusTileParticlesPrefab;

	public GameObject cultistUpgradeParticles_Prefab;

	public GameObject vacuumAirBlast_Particles_Prefab;

	[Header("Void Box/Hole Growth")]
	public GameObject voidBox_Prefab;

	[Header("Smoothie")]
	public GameObject smoothie_Prefab;

	[Header("Blender Berry Particle Colors")]
	public List<Color> BlenderBerryParticleColors;

	[Header("Cultist Prefabs")]
	public GameObject cultistPrefab_BlueBerry;

	public GameObject cultistPrefab_Raspberry;

	public GameObject cultistPrefab_Strawberry;

	public GameObject cultistPrefab_Kiwi;

	public GameObject cultistPrefab_Plum;

	public GameObject cultistPrefab_Apple;

	public GameObject cultistPrefab_Pear;

	public GameObject cultistPrefab_Peach;

	public GameObject cultistPrefab_Banana;

	public GameObject cultistPrefab_Pineapple;

	public GameObject cultistPrefab_Watermelon;

	public GameObject cultistPrefab_Pumpkin;

	public GameObject cultistPrefab_Belladonna;

	[Header("Blender Bot")]
	public GameObject blenderBot_Prefab;

	[Header("Candy")]
	public GameObject candy_Prefab;
}
