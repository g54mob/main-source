using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning.New.Summoners;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class InteractableShrineChallenge : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	private bool done;

	public GameObject fx;

	private HashSet<Enemy> enemies;

	public static Action A_Completed;

	private bool hasGivenReward;

	public static string debugName = "Challenges";

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> b = EnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> value = EnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe override bool Interact()
	{
		//IL_009c: Invalid comparison between F4 and I4
		//IL_01bb: Expected O, but got Ref
		//IL_04d1: Expected I, but got O
		//IL_029b: Expected O, but got Ref
		//IL_056b: Expected O, but got Ref
		//IL_0355: Expected O, but got Ref
		//IL_05c8: Expected O, but got Ref
		bool flag = done;
		bool result = false;
		if (!flag)
		{
			done = true;
			List<EEnemy> defaultEnemies = new List<EEnemy>();
			ChallengeSummoner challengeSummoner = new ChallengeSummoner(0, defaultEnemies);
			float num = UnityEngine.Random.Range(0f, 1f);
			bool flag2 = 0.5f < num;
			float num2 = 0.5f - num;
			bool flag3 = num2 == 0f;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			bool onlyElites = flag5 & flag4;
			HashSet<Enemy> hashSet = (HashSet<Enemy>)(object)new HashSet<object>();
			enemies = hashSet;
			Transform transform = base.transform;
			bool flag6 = (object)transform == null;
			Component component = this;
			if (!flag6)
			{
				Vector3 position = transform.position;
				Transform transform2 = base.transform;
				bool flag7 = (object)transform2 == null;
				component = this;
				if (!flag7)
				{
					Vector3 position2 = transform2.position;
					component = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						Transform transform3 = MyPlayer.Instance.transform;
						if ((object)transform3 != null)
						{
							Vector3 position3 = transform3.position;
							float num3 = position2.y - position3.y;
							float num4 = default(float);
							Vector3 vector = VectorExtensions.XZVector((Vector3)(&num4));
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
							Transform transform4 = base.transform;
							bool flag8 = (object)transform4 == null;
							component = this;
							if (!flag8)
							{
								Vector3 position4 = transform4.position;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v31+8]");
								float num5 = 0f * 10f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v31+4]");
								float num6 = 0f * 10f;
								float num7 = num5 + position4.z;
								float num8 = num6 + position4.y;
								object obj = default(object);
								float num9 = (float)obj * 10f;
								float num10 = num9 + position4.x;
								nint num11 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rax_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								float num13 = 0f * 100f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
								float num14 = 0f * 100f;
								float num15 = num13 + num7;
								float num16 = num14 + num8;
								float num17 = (float)Vector3.upVector * 100f;
								float num18 = num17 + num10;
								Vector3 vector2 = RaycastUtility.RayToGround((Vector3)(&num4));
								float num19 = vector2.x - num18;
								float num20 = num3 - num16;
								float num21 = vector2.z - num15;
								float num22 = num21 * num21;
								float num23 = num20 * num20;
								float num24 = num19 * num19;
								float num25 = num24 + num23;
								float num26 = num25 + num22;
								if (!(9.9999994E-11f > num26))
								{
								}
								bool flag9 = challengeSummoner == null;
								List<object>.Enumerator enumerator = default(List<object>.Enumerator);
								component = (Component)(&enumerator);
								if (!flag9)
								{
									List<Enemy> list = challengeSummoner.SpawnEnemies(onlyElites, (Vector3)(&num4));
									bool flag10 = list == null;
									component = (Component)(object)challengeSummoner;
									if (!flag10)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
										List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
										Enemy enemy = default(Enemy);
										while (enumerator2.MoveNext())
										{
											if (enemies != null)
											{
												bool flag11 = enemies.Add(enemy);
												continue;
											}
											throw new NullReferenceException();
										}
										((List<Enemy>.Enumerator*)(&enumerator2))->Dispose();
										bool flag12 = enemies == null;
										component = (Component)(&enumerator2);
										if (!flag12)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
											HashSet<object>.Enumerator enumerator3 = default(HashSet<object>.Enumerator);
											while (enumerator3.MoveNext())
											{
												if ((object)enemy != null)
												{
													enemy.MakeChallenge();
													continue;
												}
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
											bool flag13 = (object)fx == null;
											component = (Component)(object)fx;
											if (!flag13)
											{
												fx.SetActive(value: true);
												UnityEngine.Object.Destroy(minimapIcon);
												UnityEngine.Object.Destroy(alertIcon);
												base.OnDestroy();
												result = true;
												goto IL_0635;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0635;
		IL_0635:
		return result;
	}

	public override bool CanInteract()
	{
		return !done;
	}

	private unsafe void EnemyDied(Enemy enemy)
	{
		//IL_00d0: Expected O, but got Ref
		if (!done || hasGivenReward)
		{
			return;
		}
		if (((HashSet<object>)(object)enemies).Contains((object)enemy))
		{
			bool flag = ((HashSet<object>)(object)enemies).Remove((object)enemy);
		}
		HashSet<Enemy> hashSet = enemies;
		if (hashSet._count <= 0)
		{
			hasGivenReward = true;
			EffectManager instance = EffectManager.Instance;
			Vector3 centerPosition = enemy.GetCenterPosition();
			object obj = default(object);
			EffectManager.Instance.SpawnChest(instance.openChestNormal, (Vector3)(&obj));
			UnityEngine.Object.Destroy(this);
			Action a_Completed = A_Completed;
			if (A_Completed != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v278.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C7C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SHRINE_CHALLENGE");
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShrineChallenge()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
