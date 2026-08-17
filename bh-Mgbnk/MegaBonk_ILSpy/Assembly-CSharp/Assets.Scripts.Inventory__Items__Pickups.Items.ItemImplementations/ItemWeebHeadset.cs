using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemWeebHeadset(ItemInventory itemInventoryRef) : ItemBase(itemInventoryRef)
{
	public float charmChancePerAmount = 0.02f;

	private float durationPerAmount = 1.5f;

	private float charmDuration;

	private float charmChance;

	private int maxProcsPerTick = 100;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		object obj = amount * durationPerAmount;
		float num = (float)obj + 5f;
		charmDuration = num;
		float input = (float)amount * charmChancePerAmount;
		if (0.02f > (charmChance = StatScaling.HyperbolicScaling(input, 0.1f, 4f)))
		{
			charmChance = 0.02f;
		}
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
		if (!dc.enemy.IsDead() && !dc.enemy.HasDebuff(EDebuff.Charm) && numProcsThisTick < maxProcsPerTick && ItemUtility.TryProc(dc.procCoefficient, charmChance))
		{
			dc.enemy.Charm(dc, charmDuration);
			int num = numProcsThisTick + 1;
			numProcsThisTick = num;
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public override void Tick()
	{
		numProcsThisTick = 0;
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}
}
