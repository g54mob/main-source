using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierNoDamage : ChallengeModifier
{
	private bool hasBeenCalled;

	private bool hasBeenKilled;

	public override void Init(ChallengeData challengeData)
	{
		//IL_0101: Expected I, but got O
		Action b = OnDamagePlayer;
		Delegate obj = Delegate.Combine(PlayerHealth.A_DamagePlayerCalled, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_DamagePlayerCalled = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			PlayerHealth.A_DamagePlayerCalled = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_0101: Expected I, but got O
		Action value = OnDamagePlayer;
		Delegate obj = Delegate.Remove(PlayerHealth.A_DamagePlayerCalled, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_DamagePlayerCalled = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			PlayerHealth.A_DamagePlayerCalled = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDamagePlayer()
	{
		if (hasBeenCalled)
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (inventory.statusEffects.HasStatusEffect(EStatusEffect.Shield))
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		if (!inventory2.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			if (!inventory3.statusEffects.HasStatusEffect(EStatusEffect.Invulnerability))
			{
				hasBeenCalled = true;
			}
		}
	}

	public override void Tick()
	{
		if (hasBeenCalled && !hasBeenKilled)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			inventory.playerHealth.KillPlayer();
		}
	}
}
