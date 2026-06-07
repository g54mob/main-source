using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_TrainCart : ADynamicPlacementTarget, IInteractable
{
	public enum eTrainCartBuffType
	{
		NONE = 0,
		DAMAGE_UP = 1,
		RANGE_UP = 2,
		SHOOT_SPEED_UP = 3
	}

	[Header("砲塔buff類型")]
	[SerializeField]
	private eTrainCartBuffType buffType;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private ParticleSystem particle_TrackFlare;

	[SerializeField]
	private Renderer renderer_Cart;

	[SerializeField]
	private Transform node_PlacementPosition;

	[SerializeField]
	private float forwardDirectionLerpSpeed;

	[SerializeField]
	private ABaseTower attachedTower;

	[SerializeField]
	private List<TowerStats> list_BuffStats;

	[SerializeField]
	private bool doProtectTower;

	[SerializeField]
	private string LocalizationTableName;

	[SerializeField]
	private string LocalizationKey;

	[SerializeField]
	private ParticleSystem particle_ApplyBuff;

	[Header("是否在移動時發送爆炸事件")]
	[SerializeField]
	private bool doSendExplosionEvent;

	[Header("爆炸事件半徑")]
	[SerializeField]
	private float explosionEventRadius;

	private Vector3 lastFramePosition;

	private bool isAnimPlaying;

	private bool isRegisteredDynamicPlacementTarget;

	private Vector3Int lastGridPosition;

	private bool isAvailable;

	[SerializeField]
	private GameObject node_ActivatedEffect;

	[SerializeField]
	private GameObject node_DeactivatedEffect;

	private bool isShowTowerRangeChage;

	public bool IsAnimPlaying => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Initialize(Vector3 lastFramePos)
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	public override Transform GetPlacementTransform()
	{
		return null;
	}

	public void UpdateCartDirection(float deltaTime)
	{
	}

	public override void PlaceTowerProc(ABaseTower tower)
	{
	}

	public void SetCartAvailable(bool isAvailable)
	{
	}

	public override void RemoveTowerProc(ABaseTower tower)
	{
	}

	public void ToggleCartAnimation(bool isOn)
	{
	}

	protected void ApplyEffectToTower(ABaseTower tower)
	{
	}

	public override bool HasTower()
	{
		return false;
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}
