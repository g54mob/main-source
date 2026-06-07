using UnityEngine;

[CreateAssetMenu(fileName = "GE_healData_default", menuName = "Tower Factory/GameplayEffect/EnemiesEffects/Heal")]
public class GE_HealData : GameplayEffectData
{
	public enum EBarType
	{
		Health = 0,
		Armor = 1,
		Shield = 2
	}

	public enum EHealType
	{
		Normal = 0,
		Percentage = 1
	}

	[Header("Heal")]
	[SerializeField]
	private bool refill;

	[SerializeField]
	private EBarType barType;

	[SerializeField]
	private EHealType healType;

	[SerializeField]
	private float amount;

	[SerializeField]
	[Tooltip("Si está a true, se curará la barra correspondiente aunque el enemigo no tenga esa barra de base")]
	private bool increaseMaxStat;

	[SerializeField]
	private GE_Heal_VFX healVFX_life;

	[SerializeField]
	private GE_Heal_VFX healVFX_health;

	[SerializeField]
	private GE_Heal_VFX healVFX_armor;

	[SerializeField]
	private GE_Heal_VFX healVFX_shield;

	public bool Refill => refill;

	public EBarType BarType => barType;

	public EHealType HealType => healType;

	public float Amount => amount;

	public bool IncreaseMaxStat => increaseMaxStat;

	public GE_Heal_VFX HealVFX_life => healVFX_life;

	public GE_Heal_VFX HealVFX_health => healVFX_health;

	public GE_Heal_VFX HealVFX_armor => healVFX_armor;

	public GE_Heal_VFX HealVFX_shield => healVFX_shield;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_Heal();
	}

	private void OnValidate()
	{
		base.HasTickTime = false;
	}

	protected override bool ShowNameInInspector()
	{
		return false;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowMaxStacksInInspector()
	{
		return false;
	}
}
