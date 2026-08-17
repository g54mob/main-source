using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilitySpeedDemon : PassiveAbility
{
	private float increaseInterval = 1f;

	private float increasePerInterval = 0.0085f;

	private float speedIncrease;

	private float nextInterval;

	private float cap = 1.5f;

	private float updateStatsInterval = 0.25f;

	private float nextUpdateDamageTime;

	private float damagePerSpeedMultiplier = 0.5f;

	private float damagePerLevel = 0.0075f;

	private int hitsToFullyResetSpeedMin = 4;

	private int hitsToFullyResetSpeedMax = 15;

	private int hitsToFullyResetSpeed = 4;

	private int levelPerHitIncrease = 10;

	public override void Init()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		float num = MyTime.time + increaseInterval;
		nextInterval = num;
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num3;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0235;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num3 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<int> b2 = OnLevelup;
		Delegate obj6 = Delegate.Combine(PlayerXp.A_LevelUp, b2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action2 = default(Action<int>);
		bool flag2 = action2 == null;
		num3 = (nint)typeof(Action<int>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0225;
		}
		PlayerXp.A_LevelUp = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num2 = (nint)typeof(Action<int>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0235;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0235:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num3 = num2;
		goto IL_0225;
		IL_0225:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	public override void Cleanup()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ca;
			}
		}
		Action<int> value2 = OnLevelup;
		Delegate obj6 = Delegate.Remove(PlayerXp.A_LevelUp, value2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action2 = default(Action<int>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<int>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		PlayerXp.A_LevelUp = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ca;
	}

	public override void Tick()
	{
		//IL_014f: Invalid comparison between I4 and F4
		//IL_00a3: Expected F4, but got I4
		if (!(GameManager.Instance != null))
		{
			return;
		}
		GameManager instance = GameManager.Instance;
		if (instance._003CisCrypt_003Ek__BackingField)
		{
			return;
		}
		if (!(nextInterval > MyTime.time))
		{
			float num = speedIncrease + increasePerInterval;
			float num2 = MyTime.time + increaseInterval;
			nextInterval = num2;
			if (!(0f > num))
			{
				if (num > cap)
				{
					num = cap;
				}
			}
			else
			{
				num = 0f;
			}
			bool flag = num == speedIncrease;
			speedIncrease = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018047E18Ch\"");
			if (!flag)
			{
				StatModifier statModifier = new StatModifier();
				float modification = speedIncrease + 1f;
				statModifier.modifyType = EStatModifyType.Multiplication;
				statModifier.stat = EStat.MoveSpeedMultiplier;
				statModifier.modification = modification;
				SetStat(statModifier);
			}
		}
		TickDamageIncrease();
	}

	private void TickSpeedIncrease()
	{
		//IL_00df: Invalid comparison between I4 and F4
		//IL_0043: Expected F4, but got I4
		if (nextInterval > MyTime.time)
		{
			return;
		}
		float num = speedIncrease + increasePerInterval;
		float num2 = MyTime.time + increaseInterval;
		nextInterval = num2;
		if (!(0f > num))
		{
			if (num > cap)
			{
				num = cap;
			}
		}
		else
		{
			num = 0f;
		}
		bool flag = num == speedIncrease;
		speedIncrease = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018047DFD1h\"");
		if (!flag)
		{
			StatModifier statModifier = new StatModifier();
			float modification = speedIncrease + 1f;
			statModifier.modifyType = EStatModifyType.Multiplication;
			statModifier.stat = EStat.MoveSpeedMultiplier;
			statModifier.modification = modification;
			SetStat(statModifier);
		}
	}

	private void TickDamageIncrease()
	{
		//IL_0076: Invalid comparison between I4 and F4
		//IL_00c1: Expected F4, but got I4
		if (nextUpdateDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + updateStatsInterval;
		nextUpdateDamageTime = num;
		MyPlayer instance = MyPlayer.Instance;
		float speedHorizontal = instance.playerMovement.GetSpeedHorizontal();
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerMovement playerMovement = instance2.playerMovement;
		float num2 = speedHorizontal * 0.75f;
		float maxSpeed = playerMovement.movementValues.GetMaxSpeed();
		float num3 = num2 / maxSpeed;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float stat = PlayerStats.GetStat(EStat.MoveSpeedMultiplier);
		MyPlayer instance3 = MyPlayer.Instance;
		int characterLevel = instance3.inventory.GetCharacterLevel();
		float num4 = stat - 1f;
		float num5 = num4 * damagePerSpeedMultiplier;
		float num6 = (float)characterLevel * damagePerLevel;
		float num7 = num6 + num5;
		StatModifier statModifier = new StatModifier();
		float modification = num7 * num3;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.DamageMultiplier;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	private bool CanTick()
	{
		//IL_0075: Expected I4, but got O
		bool flag = GameManager.Instance != null;
		if (!flag)
		{
			return flag;
		}
		GameManager instance = GameManager.Instance;
		if ((object)GameManager.Instance != null)
		{
			return !instance._003CisCrypt_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnLevelup(int level)
	{
		//IL_001d: Expected F8, but got I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected I4, but got Unknown
		//IL_005f: Expected O, but got F8
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected I4, but got Unknown
		//IL_0084: Invalid comparison between F8 and I4
		//IL_0094: Invalid comparison between F8 and I4
		//IL_016d: Expected I4, but got F8
		//IL_00b2: Invalid comparison between F8 and I4
		//IL_013d: Expected F8, but got I4
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected I4, but got Unknown
		//IL_0103: Expected O, but got F8
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected I4, but got Unknown
		//IL_0128: Invalid comparison between F8 and I4
		int num = level / levelPerHitIncrease;
		double num2 = Math.Floor((double)num);
		double num3 = num2 + (double)hitsToFullyResetSpeedMin;
		double num4 = num3 - (double)hitsToFullyResetSpeedMin;
		int num5 = num3 ^ hitsToFullyResetSpeedMin;
		object obj = num3 ^ num4;
		int num6 = num5 & obj;
		bool flag = num6 < 0;
		bool flag2 = num4 < 0.0;
		if (!(num3 < (double)hitsToFullyResetSpeedMin))
		{
			if (num3 > (double)hitsToFullyResetSpeedMax)
			{
				hitsToFullyResetSpeed = hitsToFullyResetSpeedMax;
				return;
			}
			double num7 = num3 - (double)hitsToFullyResetSpeedMin;
			int num8 = num3 ^ hitsToFullyResetSpeedMin;
			object obj2 = num3 ^ num7;
			int num9 = num8 & obj2;
			flag = num9 < 0;
			flag2 = num7 < 0.0;
		}
		if (flag2 != flag)
		{
			num3 = hitsToFullyResetSpeedMin;
		}
		hitsToFullyResetSpeed = (int)num3;
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool brokeShield)
	{
		//IL_0131: Invalid comparison between I4 and F4
		if (dc.damageSource != "fallDamage" && dc.damageSource != DebuffPoison.poisonDamageSource && dc.damageSource != ItemKevin.damageSource)
		{
			float num = MyTime.time + increaseInterval;
			nextInterval = num;
			float num2 = cap / (float)hitsToFullyResetSpeed;
			if (0f > (speedIncrease -= num2))
			{
				speedIncrease = 0f;
			}
			StatModifier statModifier = new StatModifier();
			float modification = speedIncrease + 1f;
			statModifier.modifyType = EStatModifyType.Multiplication;
			statModifier.stat = EStat.MoveSpeedMultiplier;
			statModifier.modification = modification;
			SetStat(statModifier);
		}
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.SpeedDemon;
	}
}
