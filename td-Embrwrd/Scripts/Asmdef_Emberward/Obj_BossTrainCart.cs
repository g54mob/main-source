using System.Collections.Generic;
using TMPro;
using UnityEngine;

[SelectionBase]
public class Obj_BossTrainCart : MonoBehaviour
{
	[SerializeField]
	private int chestCount;

	[SerializeField]
	private Obj_TerritoryOverrider territoryOverrider;

	[SerializeField]
	private Obj_BossTrainCannon cannon;

	[SerializeField]
	private List<Transform> list_BossStandPoints;

	[SerializeField]
	private List<Obj_BossTrainBox> list_Boxes;

	[SerializeField]
	private List<AObj_RandomPlacement> list_RandomPlacement;

	[SerializeField]
	private List<ParticleSystem> list_ExplosionFireParticle;

	[SerializeField]
	private List<APowerGrid> list_PowerGridsAfterExplosion;

	[SerializeField]
	private Obj_BossTrainCartLayout trainCartLayout;

	[SerializeField]
	private int defaultWeight;

	[SerializeField]
	private TMP_Text text_Weight;

	[SerializeField]
	private List<Transform> list_CartBorders;

	[SerializeField]
	private Obj_BossTrainWeightDisplayBoard obj_weightDisplayBoard;

	[SerializeField]
	private Transform node_CartFrontSide;

	[SerializeField]
	private Transform node_CartBackSide;

	private List<ABaseTower> list_TowersOnCart;

	private List<Obj_TetrisBlock> list_TetrisOnCart;

	private int currentWeight;

	private int maxWeight;

	private List<int> list_BoxWithChestIndex;

	private float updateWeightInterval;

	private float updateWeightTimer;

	private List<ABaseTower> list_DebuffedTowers;

	public Obj_TerritoryOverrider TerritoryOverrider => null;

	public Obj_BossTrainCannon Cannon => null;

	public List<Transform> List_BossStandPoints => null;

	public List<Obj_BossTrainBox> List_Boxes => null;

	public List<AObj_RandomPlacement> List_RandomPlacement => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OverrideTrainCartLayout(Obj_BossTrainCartLayout layout)
	{
	}

	public void SetupWhichBoxContainChest()
	{
	}

	public void CheckTrainBoxDestroy(Vector3 bossPosition)
	{
	}

	public void PlayExplosionFireParticle()
	{
	}

	public void TriggerRandomPlacement()
	{
	}

	public void OverrideTerritory()
	{
	}

	private void UpdateWeightDisplay()
	{
	}

	private void UpdateWeight()
	{
	}

	public bool IsPositionOnCart(Vector3 position)
	{
		return false;
	}

	public static bool CheckIsInArea(Vector3Int pos, List<Transform> list_borderNodes)
	{
		return false;
	}
}
