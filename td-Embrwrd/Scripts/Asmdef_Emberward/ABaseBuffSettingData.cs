using System;
using UnityEngine;

public abstract class ABaseBuffSettingData : AItemSettingData
{
	public enum eBuffTargetType
	{
		TOWER = 0,
		TETRIS = 1,
		MONSTER = 2,
		MAP_AREA = 3,
		IMMEDIATE_CAST = 4
	}

	[SerializeField]
	[Header("卡片圖示 (無白色框線)")]
	protected Sprite sprite_Icon_NoOutline;

	[Header("Buff持續時間類型")]
	public eBuffDurationType DurationType;

	[Header("持續時間")]
	public float Duration_Time;

	[Header("持續回合")]
	public int Duration_Round;

	[Header("重複施放是否疊加時間")]
	public bool IsDurationStacked;

	[Header("重複施放是否疊加數值")]
	public bool IsEffectStacked;

	[Header("是否是跟發射有關的特效")]
	public bool IsShootingEffect;

	[Header("是否是跟打中目標有關的特效")]
	public bool IsHitTargetEffect;

	[Header("Buff目標")]
	public eBuffTargetType TargetType;

	[Header("是否對塔使用後，只有瞬間效果)")]
	public bool IsOnlySpellEffectOnTower;

	[Header("是否只能對鎖定的方塊使用")]
	public bool OnlyToLockedTetris;

	[Header("技能範圍")]
	public float SkillAreaRange;

	[Header("技能提示圈的類型")]
	public Obj_RangeIndicator.eMagicRingMaterialType RangeIndicatorType;

	[Header("是否只能在指定的世界中出現")]
	public bool DoLimitWorldType;

	[Header("只能在指定的世界中出現")]
	public eWorldType OnlyShowInWorld;

	protected float durationLeft_Time;

	protected int durationLeft_Round;

	protected int effectStacks;

	public bool IsFinished;

	protected ABaseTower targetTower;

	protected Obj_TetrisBlock targetTetris;

	protected AMonsterBase targetMonster;

	protected Vector3 targetPosition;

	protected int sourceID;

	public Action OnBuffRemove;

	public Action<int> OnTimeUpdate;

	public ABaseTower TargetTower => null;

	public Obj_TetrisBlock TargetTetris => null;

	public AMonsterBase TargetMonster => null;

	public Vector3 TargetPosition => default(Vector3);

	public int SourceID => 0;

	public Sprite GetIcon_NoOutline()
	{
		return null;
	}

	private bool ShowIfIsTimeDuration()
	{
		return false;
	}

	private bool ShowIfTargetTower()
	{
		return false;
	}

	private bool ShowIfTargetTetris()
	{
		return false;
	}

	private bool ShowIfTargetMapArea()
	{
		return false;
	}

	public void PreRegister(ABaseTower tower, int sourceID)
	{
	}

	public virtual void PreRegisterProc(ABaseTower tower)
	{
	}

	public void Initialize()
	{
	}

	public void SetBuffTarget(ABaseTower tower)
	{
	}

	public void SetBuffTarget(Obj_TetrisBlock tetris)
	{
	}

	public void SetBuffTarget(AMonsterBase monster)
	{
	}

	public void SetBuffTarget(Vector3 position)
	{
	}

	public void Tick(float delta)
	{
	}

	protected virtual void TickProc(float delta)
	{
	}

	public void Update_Round()
	{
	}

	public void Activate()
	{
	}

	public void ForceRemove()
	{
	}

	private void EndBuff()
	{
	}

	private void OnRoundEnd()
	{
	}

	public virtual bool IsMapBuffApplyable(Vector3 targetPos)
	{
		return false;
	}

	public virtual bool IsTowerBuffApplyable(ABaseTower tower)
	{
		return false;
	}

	public virtual void OnPointerEnterTargetTower(ABaseTower tower)
	{
	}

	public virtual void OnPointerExitTarget(ABaseTower tower)
	{
	}

	protected abstract void ApplyEffect();

	protected abstract void RemoveEffect();

	public virtual void OnTowerShoot(ABaseTower tower, AMonsterBase targetMonster)
	{
	}

	public virtual void OnTowerBulletHit(ABaseTower tower, AMonsterBase targetMonster, int shootIndex, int bulletIndex)
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}

	protected string GetLocDurationString(string str)
	{
		return null;
	}
}
