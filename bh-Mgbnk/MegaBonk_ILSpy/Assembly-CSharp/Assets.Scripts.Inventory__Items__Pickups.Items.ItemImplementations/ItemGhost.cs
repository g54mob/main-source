using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGhost : ItemBase
{
	public const int maxGhosts = 100;

	private int numGhosts;

	private int numGhostsPerAmount;

	private string damageSource;

	protected override void OnInitOrAmountChanged()
	{
		int num = numGhostsPerAmount * amount;
		numGhosts = num;
	}

	private void OnInteracted(BaseInteractable interactable, bool success)
	{
		//IL_0044: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		if (success && numGhosts > 0)
		{
			object obj = 0;
			do
			{
				MyPlayer instance = MyPlayer.Instance;
				float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
				float duration = stat * 30f;
				float damage = instance.baseDamage + instance.baseDamage;
				EffectManager.Instance.SpawnGhostProjectile(damage, duration, damageSource);
				obj++;
			}
			while ((nint)obj < numGhosts);
		}
	}

	private void SpawnGhost()
	{
		MyPlayer instance = MyPlayer.Instance;
		float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
		float duration = stat * 30f;
		float damage = instance.baseDamage + instance.baseDamage;
		EffectManager.Instance.SpawnGhostProjectile(damage, duration, damageSource);
	}

	private float GetDuration()
	{
		float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
		return stat * 30f;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		return instance.baseDamage + instance.baseDamage;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<BaseInteractable, bool> b = OnInteracted;
		Delegate obj = Delegate.Combine(DetectInteractables.A_Interacted, b);
		if ((object)obj == null)
		{
			DetectInteractables.A_Interacted = (Action<BaseInteractable, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<BaseInteractable, bool> action = default(Action<BaseInteractable, bool>);
		if (action != null)
		{
			DetectInteractables.A_Interacted = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<BaseInteractable, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<BaseInteractable, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<BaseInteractable, bool> value = OnInteracted;
		Delegate obj = Delegate.Remove(DetectInteractables.A_Interacted, value);
		if ((object)obj == null)
		{
			DetectInteractables.A_Interacted = (Action<BaseInteractable, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<BaseInteractable, bool> action = default(Action<BaseInteractable, bool>);
		if (action != null)
		{
			DetectInteractables.A_Interacted = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<BaseInteractable, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<BaseInteractable, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Tick()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public unsafe ItemGhost(ItemInventory itemInventoryRef)
	{
		//IL_001a: Expected O, but got Ref
		numGhostsPerAmount = 6;
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
		base._002Ector(itemInventoryRef);
	}
}
