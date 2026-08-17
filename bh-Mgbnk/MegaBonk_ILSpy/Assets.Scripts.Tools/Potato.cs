using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Tools;

public static class Potato
{
	private static float lastCollisionTime = 0f;

	private static float noCollisionTimeThreshold = 60f;

	public static EPotatoFlags flags;

	public static float totalDamageDone;

	public static float dmgMin1;

	public static float dmgMin2;

	public static float dmgMin5;

	public static float dmgMin10;

	private static float dmgMin1Max = 100000f;

	private static float dmgMin2Max = 500000f;

	private static float dmgMin5Max = 5000000f;

	private static int totalKills;

	public static int killsMinute1;

	public static int killsMinute2;

	public static int killsMinute5;

	public static int killsMinute10;

	private static int maxKillsMinute1 = 500;

	private static int maxKillsMinute2 = 2000;

	private static int maxKillsMinute5 = 10000;

	private static int maxKillsMinute10 = 50000;

	public static int enemyCollisionCalls;

	public static int playerDamageCalls;

	public static int damageBlocksCount;

	public static int damageTakenCount;

	public static int totalDamageTaken;

	private static int lastKillCount;

	private static int lastGoldCount;

	private static bool isRunning;

	private static float nextCheckTime;

	public static void Init()
	{
		//IL_0783: Expected I, but got O
		//IL_078c: Expected O, but got I4
		//IL_07ff: Expected O, but got I4
		//IL_0815: Expected I, but got O
		//IL_0863: Expected O, but got I4
		//IL_0879: Expected I, but got O
		//IL_089f: Expected O, but got I4
		//IL_08b5: Expected I, but got O
		//IL_01b9: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_020d: Expected I, but got O
		//IL_021e: Expected O, but got I4
		//IL_0c5a: Expected I, but got O
		//IL_0922: Expected I, but got O
		//IL_0933: Expected O, but got I4
		//IL_0949: Expected I, but got O
		//IL_0977: Expected O, but got I4
		//IL_098d: Expected I, but got O
		//IL_09bb: Expected O, but got I4
		//IL_09d1: Expected I, but got O
		//IL_09ff: Expected O, but got I4
		//IL_0a15: Expected I, but got O
		//IL_0a74: Expected O, but got I4
		//IL_0a8a: Expected I, but got O
		//IL_0ab8: Expected O, but got I4
		//IL_0ace: Expected I, but got O
		//IL_0afc: Expected O, but got I4
		//IL_0b12: Expected I, but got O
		//IL_0b40: Expected O, but got I4
		//IL_0b56: Expected I, but got O
		//IL_0618: Expected O, but got I4
		//IL_066c: Expected O, but got I4
		//IL_0ba4: Expected O, but got I4
		//IL_0bba: Expected I, but got O
		//IL_0bed: Expected I, but got O
		//IL_0bf6: Expected O, but got I4
		Delegate obj = GameManager.A_RunStarted;
		Action action = OnRunStarted;
		Delegate obj2 = Delegate.Combine(GameManager.A_RunStarted, action);
		Action action2;
		nint num;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				num = (nint)typeof(Action);
				obj4 = 0;
				obj5 = obj2;
				goto IL_0cd7;
			}
			GameManager.A_RunStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0c0c;
			}
		}
		Action b = OnPlayerCollided;
		Delegate obj7 = Delegate.Combine(MyPlayer.A_Collided, b);
		if ((object)obj7 == null)
		{
			MyPlayer.A_Collided = null;
		}
		else
		{
			bool flag4 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj7;
			}
			bool flag5 = (object)obj8 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0c17;
			}
			MyPlayer.A_Collided = (Action)obj8;
			bool flag6 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag6)
			{
				obj9 = obj7;
			}
			bool flag7 = (object)obj9 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0c27;
			}
		}
		Action<Enemy, DamageContainer> b2 = OnEnemyDamaged;
		Delegate obj10 = Delegate.Combine(Enemy.A_Damage, b2);
		nint num5;
		Delegate obj11;
		if ((object)obj10 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
			bool flag8 = action3 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_08eb;
			}
			Enemy.A_Damage = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_08fb;
			}
		}
		obj = Enemy.A_HpTamper;
		Action action4 = OnHpTamper;
		Delegate obj13 = Delegate.Combine(Enemy.A_HpTamper, action4);
		if ((object)obj13 == null)
		{
			Enemy.A_HpTamper = null;
		}
		else
		{
			bool flag10 = (object)obj13.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj13;
			}
			bool flag11 = (object)obj14 == null;
			num5 = (nint)obj;
			obj11 = action4;
			obj4 = 0;
			obj5 = obj13;
			nint num6 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0c37;
			}
			Enemy.A_HpTamper = (Action)obj14;
			bool flag12 = (object)obj13.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag12)
			{
				obj15 = obj13;
			}
			bool flag13 = (object)obj15 == null;
			action2 = action4;
			obj4 = 0;
			obj5 = obj13;
			nint num7 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_0c47;
			}
		}
		obj = MyPlayer.A_CollidedEnemy;
		Action action5 = OnEnemyCollision;
		Delegate obj16 = Delegate.Combine(MyPlayer.A_CollidedEnemy, action5);
		if ((object)obj16 == null)
		{
			MyPlayer.A_CollidedEnemy = null;
		}
		else
		{
			bool flag14 = (object)obj16.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj16;
			}
			bool flag15 = (object)obj17 == null;
			action2 = action5;
			obj4 = 0;
			obj5 = obj16;
			nint num8 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0c67;
			}
			MyPlayer.A_CollidedEnemy = (Action)obj17;
			bool flag16 = (object)obj16.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag16)
			{
				obj18 = obj16;
			}
			bool flag17 = (object)obj18 == null;
			action2 = action5;
			obj4 = 0;
			obj5 = obj16;
			nint num9 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0c77;
			}
		}
		obj = PlayerHealth.A_DamagePlayerCalled;
		Action action6 = OnDamageCalled;
		Delegate obj19 = Delegate.Combine(PlayerHealth.A_DamagePlayerCalled, action6);
		if ((object)obj19 == null)
		{
			PlayerHealth.A_DamagePlayerCalled = null;
		}
		else
		{
			bool flag18 = (object)obj19.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag18)
			{
				obj20 = obj19;
			}
			bool flag19 = (object)obj20 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj19;
			nint num10 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_0c87;
			}
			PlayerHealth.A_DamagePlayerCalled = (Action)obj20;
			bool flag20 = (object)obj19.GetType() != typeof(Action);
			Delegate obj21 = null;
			if (!flag20)
			{
				obj21 = obj19;
			}
			bool flag21 = (object)obj21 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj19;
			nint num11 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_0c97;
			}
		}
		obj = PlayerHealth.A_StoppedDamage;
		Action action7 = OnDamageStopped;
		Delegate obj22 = Delegate.Combine(PlayerHealth.A_StoppedDamage, action7);
		if ((object)obj22 == null)
		{
			PlayerHealth.A_StoppedDamage = null;
		}
		else
		{
			bool flag22 = (object)obj22.GetType() != typeof(Action);
			Delegate obj23 = null;
			if (!flag22)
			{
				obj23 = obj22;
			}
			bool flag23 = (object)obj23 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj22;
			nint num12 = (nint)typeof(Action);
			if (flag23)
			{
				goto IL_0ca7;
			}
			PlayerHealth.A_StoppedDamage = (Action)obj23;
			bool flag24 = (object)obj22.GetType() != typeof(Action);
			Delegate obj24 = null;
			if (!flag24)
			{
				obj24 = obj22;
			}
			bool flag25 = (object)obj24 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj22;
			nint num13 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_0cb7;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> b3 = new Action<object, object, bool>(OnDamageTaken);
		Delegate obj25 = Delegate.Combine(PlayerHealth.A_TakeDamage, b3);
		if ((object)obj25 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action8 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag26 = action8 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj25;
			obj4 = 0;
			obj5 = null;
			if (flag26)
			{
				goto IL_0b64;
			}
			PlayerHealth.A_TakeDamage = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj26 = default(object);
			bool flag27 = obj26 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj25;
			obj4 = 0;
			obj5 = null;
			if (flag27)
			{
				goto IL_0b74;
			}
		}
		obj = GameManager.A_GameOver;
		Action action9 = OnRunOver;
		Delegate obj27 = Delegate.Combine(GameManager.A_GameOver, action9);
		if ((object)obj27 == null)
		{
			GameManager.A_GameOver = null;
			return;
		}
		bool flag28 = (object)obj27.GetType() != typeof(Action);
		Delegate obj28 = null;
		if (!flag28)
		{
			obj28 = obj27;
		}
		bool flag29 = (object)obj28 == null;
		action2 = action9;
		obj4 = 0;
		obj5 = obj27;
		nint num14 = (nint)typeof(Action);
		if (flag29)
		{
			goto IL_0cc7;
		}
		GameManager.A_GameOver = (Action)obj28;
		bool flag30 = (object)obj27.GetType() != typeof(Action);
		Delegate obj29 = null;
		if (!flag30)
		{
			obj29 = obj27;
		}
		bool flag31 = (object)obj29 == null;
		action2 = action9;
		num = (nint)typeof(Action);
		obj4 = 0;
		obj5 = obj27;
		if (!flag31)
		{
			return;
		}
		goto IL_0cd7;
		IL_0b74:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b64;
		IL_08eb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c27;
		IL_0c0c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0c37:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08fb;
		IL_0c17:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c0c;
		IL_0cc7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b74;
		IL_0c77:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c67;
		IL_0c87:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c77;
		IL_0b64:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0cb7;
		IL_0c27:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c17;
		IL_0ca7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c97;
		IL_0cb7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0ca7;
		IL_0c97:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c87;
		IL_0c67:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c47;
		IL_0cd7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0cc7;
		IL_08fb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08eb;
		IL_0c47:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num5 = (nint)obj;
		obj11 = action2;
		goto IL_0c37;
	}

	public static void Cleanup()
	{
		//IL_0783: Expected I, but got O
		//IL_078c: Expected O, but got I4
		//IL_07ff: Expected O, but got I4
		//IL_0815: Expected I, but got O
		//IL_0863: Expected O, but got I4
		//IL_0879: Expected I, but got O
		//IL_089f: Expected O, but got I4
		//IL_08b5: Expected I, but got O
		//IL_01b9: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_020d: Expected I, but got O
		//IL_021e: Expected O, but got I4
		//IL_0c5a: Expected I, but got O
		//IL_0922: Expected I, but got O
		//IL_0933: Expected O, but got I4
		//IL_0949: Expected I, but got O
		//IL_0977: Expected O, but got I4
		//IL_098d: Expected I, but got O
		//IL_09bb: Expected O, but got I4
		//IL_09d1: Expected I, but got O
		//IL_09ff: Expected O, but got I4
		//IL_0a15: Expected I, but got O
		//IL_0a74: Expected O, but got I4
		//IL_0a8a: Expected I, but got O
		//IL_0ab8: Expected O, but got I4
		//IL_0ace: Expected I, but got O
		//IL_0afc: Expected O, but got I4
		//IL_0b12: Expected I, but got O
		//IL_0b40: Expected O, but got I4
		//IL_0b56: Expected I, but got O
		//IL_0618: Expected O, but got I4
		//IL_066c: Expected O, but got I4
		//IL_0ba4: Expected O, but got I4
		//IL_0bba: Expected I, but got O
		//IL_0bed: Expected I, but got O
		//IL_0bf6: Expected O, but got I4
		Delegate obj = GameManager.A_RunStarted;
		Action action = OnRunStarted;
		Delegate obj2 = Delegate.Remove(GameManager.A_RunStarted, action);
		Action action2;
		nint num;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				num = (nint)typeof(Action);
				obj4 = 0;
				obj5 = obj2;
				goto IL_0cd7;
			}
			GameManager.A_RunStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0c0c;
			}
		}
		Action value = OnPlayerCollided;
		Delegate obj7 = Delegate.Remove(MyPlayer.A_Collided, value);
		if ((object)obj7 == null)
		{
			MyPlayer.A_Collided = null;
		}
		else
		{
			bool flag4 = (object)obj7.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj7;
			}
			bool flag5 = (object)obj8 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0c17;
			}
			MyPlayer.A_Collided = (Action)obj8;
			bool flag6 = (object)obj7.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag6)
			{
				obj9 = obj7;
			}
			bool flag7 = (object)obj9 == null;
			obj4 = 0;
			obj5 = obj7;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0c27;
			}
		}
		Action<Enemy, DamageContainer> value2 = OnEnemyDamaged;
		Delegate obj10 = Delegate.Remove(Enemy.A_Damage, value2);
		nint num5;
		Delegate obj11;
		if ((object)obj10 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
			bool flag8 = action3 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag8)
			{
				goto IL_08eb;
			}
			Enemy.A_Damage = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag9 = obj12 == null;
			num5 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj11 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag9)
			{
				goto IL_08fb;
			}
		}
		obj = Enemy.A_HpTamper;
		Action action4 = OnHpTamper;
		Delegate obj13 = Delegate.Remove(Enemy.A_HpTamper, action4);
		if ((object)obj13 == null)
		{
			Enemy.A_HpTamper = null;
		}
		else
		{
			bool flag10 = (object)obj13.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj13;
			}
			bool flag11 = (object)obj14 == null;
			num5 = (nint)obj;
			obj11 = action4;
			obj4 = 0;
			obj5 = obj13;
			nint num6 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0c37;
			}
			Enemy.A_HpTamper = (Action)obj14;
			bool flag12 = (object)obj13.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag12)
			{
				obj15 = obj13;
			}
			bool flag13 = (object)obj15 == null;
			action2 = action4;
			obj4 = 0;
			obj5 = obj13;
			nint num7 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_0c47;
			}
		}
		obj = MyPlayer.A_CollidedEnemy;
		Action action5 = OnEnemyCollision;
		Delegate obj16 = Delegate.Remove(MyPlayer.A_CollidedEnemy, action5);
		if ((object)obj16 == null)
		{
			MyPlayer.A_CollidedEnemy = null;
		}
		else
		{
			bool flag14 = (object)obj16.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj16;
			}
			bool flag15 = (object)obj17 == null;
			action2 = action5;
			obj4 = 0;
			obj5 = obj16;
			nint num8 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0c67;
			}
			MyPlayer.A_CollidedEnemy = (Action)obj17;
			bool flag16 = (object)obj16.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag16)
			{
				obj18 = obj16;
			}
			bool flag17 = (object)obj18 == null;
			action2 = action5;
			obj4 = 0;
			obj5 = obj16;
			nint num9 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0c77;
			}
		}
		obj = PlayerHealth.A_DamagePlayerCalled;
		Action action6 = OnDamageCalled;
		Delegate obj19 = Delegate.Remove(PlayerHealth.A_DamagePlayerCalled, action6);
		if ((object)obj19 == null)
		{
			PlayerHealth.A_DamagePlayerCalled = null;
		}
		else
		{
			bool flag18 = (object)obj19.GetType() != typeof(Action);
			Delegate obj20 = null;
			if (!flag18)
			{
				obj20 = obj19;
			}
			bool flag19 = (object)obj20 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj19;
			nint num10 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_0c87;
			}
			PlayerHealth.A_DamagePlayerCalled = (Action)obj20;
			bool flag20 = (object)obj19.GetType() != typeof(Action);
			Delegate obj21 = null;
			if (!flag20)
			{
				obj21 = obj19;
			}
			bool flag21 = (object)obj21 == null;
			action2 = action6;
			obj4 = 0;
			obj5 = obj19;
			nint num11 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_0c97;
			}
		}
		obj = PlayerHealth.A_StoppedDamage;
		Action action7 = OnDamageStopped;
		Delegate obj22 = Delegate.Remove(PlayerHealth.A_StoppedDamage, action7);
		if ((object)obj22 == null)
		{
			PlayerHealth.A_StoppedDamage = null;
		}
		else
		{
			bool flag22 = (object)obj22.GetType() != typeof(Action);
			Delegate obj23 = null;
			if (!flag22)
			{
				obj23 = obj22;
			}
			bool flag23 = (object)obj23 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj22;
			nint num12 = (nint)typeof(Action);
			if (flag23)
			{
				goto IL_0ca7;
			}
			PlayerHealth.A_StoppedDamage = (Action)obj23;
			bool flag24 = (object)obj22.GetType() != typeof(Action);
			Delegate obj24 = null;
			if (!flag24)
			{
				obj24 = obj22;
			}
			bool flag25 = (object)obj24 == null;
			action2 = action7;
			obj4 = 0;
			obj5 = obj22;
			nint num13 = (nint)typeof(Action);
			if (flag25)
			{
				goto IL_0cb7;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> value3 = new Action<object, object, bool>(OnDamageTaken);
		Delegate obj25 = Delegate.Remove(PlayerHealth.A_TakeDamage, value3);
		if ((object)obj25 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action8 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag26 = action8 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj25;
			obj4 = 0;
			obj5 = null;
			if (flag26)
			{
				goto IL_0b64;
			}
			PlayerHealth.A_TakeDamage = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj26 = default(object);
			bool flag27 = obj26 == null;
			obj = (Delegate)(object)typeof(Action<PlayerHealth, DamageContainer, bool>);
			action2 = (Action)obj25;
			obj4 = 0;
			obj5 = null;
			if (flag27)
			{
				goto IL_0b74;
			}
		}
		obj = GameManager.A_GameOver;
		Action action9 = OnRunOver;
		Delegate obj27 = Delegate.Remove(GameManager.A_GameOver, action9);
		if ((object)obj27 == null)
		{
			GameManager.A_GameOver = null;
			return;
		}
		bool flag28 = (object)obj27.GetType() != typeof(Action);
		Delegate obj28 = null;
		if (!flag28)
		{
			obj28 = obj27;
		}
		bool flag29 = (object)obj28 == null;
		action2 = action9;
		obj4 = 0;
		obj5 = obj27;
		nint num14 = (nint)typeof(Action);
		if (flag29)
		{
			goto IL_0cc7;
		}
		GameManager.A_GameOver = (Action)obj28;
		bool flag30 = (object)obj27.GetType() != typeof(Action);
		Delegate obj29 = null;
		if (!flag30)
		{
			obj29 = obj27;
		}
		bool flag31 = (object)obj29 == null;
		action2 = action9;
		num = (nint)typeof(Action);
		obj4 = 0;
		obj5 = obj27;
		if (!flag31)
		{
			return;
		}
		goto IL_0cd7;
		IL_0b74:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b64;
		IL_08eb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c27;
		IL_0c0c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0c37:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08fb;
		IL_0c17:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c0c;
		IL_0cc7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b74;
		IL_0c77:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c67;
		IL_0c87:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c77;
		IL_0b64:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0cb7;
		IL_0c27:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c17;
		IL_0ca7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c97;
		IL_0cb7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0ca7;
		IL_0c97:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c87;
		IL_0c67:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0c47;
		IL_0cd7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0cc7;
		IL_08fb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08eb;
		IL_0c47:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num5 = (nint)obj;
		obj11 = action2;
		goto IL_0c37;
	}

	private static void OnRunStarted()
	{
		flags = EPotatoFlags.None;
		totalDamageDone = 0f;
		dmgMin1 = 0f;
		dmgMin2 = 0f;
		dmgMin5 = 0f;
		dmgMin10 = 0f;
		totalKills = 0;
		killsMinute1 = 0;
		killsMinute2 = 0;
		killsMinute5 = 0;
		killsMinute10 = 0;
		lastCollisionTime = 0f;
		lastKillCount = 0;
		lastGoldCount = 0;
		enemyCollisionCalls = 0;
		playerDamageCalls = 0;
		damageBlocksCount = 0;
		damageTakenCount = 0;
		totalDamageTaken = 0;
		nextCheckTime = 0f;
		isRunning = true;
	}

	private static void OnRunOver()
	{
		isRunning = false;
	}

	private static void OnRunEnded()
	{
		isRunning = false;
	}

	private static void OnPlayerCollided()
	{
		//IL_002e: Expected I, but got O
		nint num = (nint)typeof(Potato);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v3 (Il2CppClass<Assets.Scripts.Tools.Potato>)+E4]");
		if ((nint)0 == 0)
		{
			lastCollisionTime = MyTime.time;
		}
		else
		{
			lastCollisionTime = MyTime.time;
		}
	}

	public static void Update()
	{
		//IL_00b9: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_035a: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_0246: Invalid comparison between I4 and F4
		//IL_0267: Invalid comparison between I4 and F4
		if (!isRunning || !(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.inventory == null || !(GameManager.Instance != null))
		{
			return;
		}
		GameManager instance2 = GameManager.Instance;
		if (!instance2.isPlaying)
		{
			return;
		}
		object obj = flags & EPotatoFlags.Kills;
		bool flag = obj == null;
		object obj2 = !flag;
		object obj4 = default(object);
		if (obj2 == null)
		{
			int stat = RunStats.GetStat(EMyStat.kills);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
			object obj3 = stat - lastKillCount;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				MarkPotato(EPotatoFlags.Kills, "SPIKE IN KILLS");
			}
			lastKillCount = stat;
		}
		object obj5 = flags & EPotatoFlags.Gold;
		bool flag2 = obj5 == null;
		object obj6 = !flag2;
		if (obj6 == null)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory = instance3.inventory;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
			object obj7 = inventory._003CgoldInt_003Ek__BackingField - lastGoldCount;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				MarkPotato(EPotatoFlags.Gold, "SPIKE IN GOLD");
			}
			lastGoldCount = inventory._003CgoldInt_003Ek__BackingField;
		}
		object obj8 = flags & EPotatoFlags.Hp;
		bool flag3 = obj8 == null;
		object obj9 = !flag3;
		if (obj9 == null)
		{
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance4.inventory;
			PlayerHealth playerHealth = inventory2.playerHealth;
			float num = (float)PlayerHealth.maxMaxHp * 1.2f;
			if ((float)playerHealth.hp > num || (float)playerHealth.maxHp > num || playerHealth.shield > num)
			{
				MarkPotato(EPotatoFlags.Hp, "INVALID MAX HP");
			}
		}
		VerifyKillCountPerMinute();
	}

	private static void TestInput()
	{
	}

	private static void CheckCollision()
	{
	}

	private static void VerifyKillCount()
	{
		//IL_005f: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		object obj = flags & EPotatoFlags.Kills;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 == null)
		{
			int stat = RunStats.GetStat(EMyStat.kills);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
			object obj3 = stat - lastKillCount;
			object obj4 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				MarkPotato(EPotatoFlags.Kills, "SPIKE IN KILLS");
			}
			lastKillCount = stat;
		}
	}

	private static void VerifyGold()
	{
		//IL_0071: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		object obj = flags & EPotatoFlags.Gold;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 == null)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
			object obj3 = inventory._003CgoldInt_003Ek__BackingField - lastGoldCount;
			object obj4 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				MarkPotato(EPotatoFlags.Gold, "SPIKE IN GOLD");
			}
			lastGoldCount = inventory._003CgoldInt_003Ek__BackingField;
		}
	}

	private static void VerifyHp()
	{
		//IL_0014: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0083: Invalid comparison between I4 and F4
		//IL_00a4: Invalid comparison between I4 and F4
		object obj = flags & EPotatoFlags.Hp;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 == null)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			PlayerHealth playerHealth = inventory.playerHealth;
			float num = (float)PlayerHealth.maxMaxHp * 1.2f;
			if ((float)playerHealth.hp > num || (float)playerHealth.maxHp > num || playerHealth.shield > num)
			{
				MarkPotato(EPotatoFlags.Hp, "INVALID MAX HP");
			}
		}
	}

	private static void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
		//IL_0211: Expected O, but got I4
		//IL_022b: Expected O, but got I4
		//IL_0013: Invalid comparison between I4 and F4
		//IL_0248: Expected O, but got I4
		//IL_0251: Invalid comparison between F4 and O
		object obj = flags & EPotatoFlags.Damage;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 != null || 0f > dc.damage)
		{
			return;
		}
		if (!(dc.damage > 2.1474836E+09f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm1\"");
		}
		object obj3 = 2147483647 - 2147483647;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)totalDamageDone) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			float num = 2.1474836E+09f + totalDamageDone;
			totalDamageDone = num;
		}
		else
		{
			totalDamageDone = 2.1474836E+09f;
		}
		if (!(60f < MyTime.runTimer))
		{
			dmgMin1 = totalDamageDone;
			if (dmgMin1 > dmgMin1Max)
			{
				MarkPotato(EPotatoFlags.Damage, "TOO MUCH DAMAGE IN 1 MINUTE");
			}
		}
		if (!(120f < MyTime.runTimer))
		{
			dmgMin2 = totalDamageDone;
			if (dmgMin2 > dmgMin2Max)
			{
				MarkPotato(EPotatoFlags.Damage, "TOO MUCH DAMAGE IN 2 MINUTES");
			}
		}
		if (!(300f < MyTime.runTimer))
		{
			dmgMin5 = totalDamageDone;
			if (dmgMin5 > dmgMin5Max)
			{
				MarkPotato(EPotatoFlags.Damage, "TOO MUCH DAMAGE IN 5 MINUTES");
			}
		}
		if (!(600f < MyTime.runTimer))
		{
			dmgMin10 = totalDamageDone;
		}
	}

	private static void VerifyKillCountPerMinute()
	{
		//IL_01d4: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		object obj = flags & EPotatoFlags.KillsPerMinute;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 != null || nextCheckTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + 5f;
		nextCheckTime = num;
		int stat = RunStats.GetStat(EMyStat.kills);
		if (!(60f < MyTime.runTimer))
		{
			killsMinute1 = stat;
			if (killsMinute1 > maxKillsMinute1)
			{
				MarkPotato(EPotatoFlags.KillsPerMinute, "TOO MUCH KILLS IN 1 MINUTE");
			}
		}
		if (!(120f < MyTime.runTimer))
		{
			killsMinute2 = stat;
			if (killsMinute2 > maxKillsMinute2)
			{
				MarkPotato(EPotatoFlags.KillsPerMinute, "TOO MUCH KILLS IN 2 MINUTES");
			}
		}
		if (!(300f < MyTime.runTimer))
		{
			killsMinute5 = stat;
			if (killsMinute5 > maxKillsMinute5)
			{
				MarkPotato(EPotatoFlags.KillsPerMinute, "TOO MUCH KILLS IN 5 MINUTES");
			}
		}
		if (!(600f < MyTime.runTimer))
		{
			killsMinute10 = stat;
			if (killsMinute10 > maxKillsMinute10)
			{
				MarkPotato(EPotatoFlags.KillsPerMinute, "TOO MUCH KILLS IN 10 MINUTES");
			}
		}
	}

	private static void OnHpTamper()
	{
		//IL_002f: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		object obj = flags & EPotatoFlags.HpTamper;
		bool flag = obj == null;
		object obj2 = !flag;
		if (obj2 == null)
		{
			MarkPotato(EPotatoFlags.HpTamper, "HP TAMPERING");
		}
	}

	private static void OnEnemyCollision()
	{
		int num = enemyCollisionCalls + 1;
		enemyCollisionCalls = num;
	}

	private static void OnDamageCalled()
	{
		int num = playerDamageCalls + 1;
		playerDamageCalls = num;
	}

	private static void OnDamageStopped()
	{
		int num = damageBlocksCount + 1;
		damageBlocksCount = num;
	}

	private static void OnDamageTaken(PlayerHealth arg1, DamageContainer arg2, bool arg3)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rbx+1Ch]\"");
		PlayerHealth playerHealth = default(PlayerHealth);
		int num = playerHealth + totalDamageTaken;
		totalDamageTaken = num;
	}

	private static void MarkPotato(EPotatoFlags flag, string message)
	{
		RunConfig runConfig = MapController.runConfig;
		if (runConfig.challenge == null)
		{
			EPotatoFlags ePotatoFlags = flag | flags;
			flags = ePotatoFlags;
		}
	}
}
