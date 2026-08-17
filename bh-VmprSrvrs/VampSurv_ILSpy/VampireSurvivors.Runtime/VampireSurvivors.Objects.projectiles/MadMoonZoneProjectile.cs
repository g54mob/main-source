using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class MadMoonZoneProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public List<EnemyController> spawnedEnemies;

		public int eventID;

		internal void _003CSpawnSkelegems_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01e3: Expected O, but got I4
			//IL_0104: Expected O, but got I4
			List<EnemyController> list = spawnedEnemies;
			bool flag = (nint)spawnedEnemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				List<EnemyController> list2 = spawnedEnemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventID;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventID)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public List<EnemyController> spawnedEnemies;

		public int eventID;

		internal void _003CSpawnAnforaCluster_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01e3: Expected O, but got I4
			//IL_0104: Expected O, but got I4
			List<EnemyController> list = spawnedEnemies;
			bool flag = (nint)spawnedEnemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				List<EnemyController> list2 = spawnedEnemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventID;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventID)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public EnemyController blinder;

		public int eventID;

		internal void _003CSpawnReapers_003Eb__0()
		{
			EnemyController enemyController = blinder;
			if ((object)blinder != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemyController2 = blinder;
				if (!enemyController2._003CIsDead_003Ek__BackingField && enemyController2._003CStageEventId_003Ek__BackingField == eventID)
				{
					enemyController2._003CIsCullable_003Ek__BackingField = true;
					blinder.Disappear();
				}
			}
		}
	}

	private sealed class _003CDamageEnemyLoop_003Ed__31(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemyController enemy;

		public float amount;

		public MadMoonZoneProjectile _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_016f: Invalid comparison between O and F4
			//IL_01ad: Invalid comparison between F4 and O
			//IL_02e4: Expected O, but got I4
			//IL_01eb: Invalid comparison between O and F4
			//IL_0229: Invalid comparison between F4 and O
			//IL_02ca->IL04ae: Incompatible stack heights: 9 vs 13
			//IL_028a->IL044e: Incompatible stack heights: 10 vs 9
			//IL_02b1->IL044e: Incompatible stack heights: 10 vs 9
			MadMoonZoneProjectile madMoonZoneProjectile = _003C_003E4__this;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				bool flag = (object)enemy == null;
				Transform transform = enemy.transform;
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				bool flag4 = (object)enemy == null;
				Transform transform2 = enemy.transform;
				bool flag5 = (object)transform2 == null;
				bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag7 = (object)_003C_003E4__this == null;
				ArcadeSprite sprite = madMoonZoneProjectile._sprite;
				bool flag8 = (object)madMoonZoneProjectile._sprite == null;
				BaseBody body = sprite.body;
				bool flag9 = sprite.body == null;
				float num = (float)body._size * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v19 (BaseBody)+5C]");
				float num2 = 0f * 100f;
				float num3 = num * 0.00390625f;
				float num4 = num2 * 0.00390625f;
				float2 position = madMoonZoneProjectile._sprite.position;
				float num5 = num3 * 0.5f;
				float num6 = (float)position - num5;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
				{
					float num7 = num3 * 0.5f;
					float num8 = num7 + (float)position;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
					{
						float num9 = num4 * 0.5f;
						object obj = default(object);
						float num10 = (float)obj - num9;
						object obj2 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10))
						{
							float num11 = num4 * 0.5f;
							float num12 = num11 + (float)obj;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
							{
								if (!PauseSystem._paused)
								{
									EnemyController enemyController = enemy;
									bool flag10 = (object)enemy == null;
									if (!enemyController._003CIsDead_003Ek__BackingField)
									{
										enemy.GetDamaged(amount, HitVfxType.Default, 1f, WeaponType.VOID, hasKb: false);
									}
								}
								WaitForSeconds waitForSeconds = null;
								waitForSeconds.m_Seconds = 0.2f;
								_003C_003E2__current = waitForSeconds;
								_003C_003E1__state = 1;
								return true;
							}
						}
					}
				}
				bool flag11 = (object)enemy == null;
				ArcadeSprite arcadeSprite = enemy.setScale(1f, (float?)(object)0);
				List<EnemyController>[] effectedEnemies = MadMoonZoneProjectile.effectedEnemies;
				bool flag12 = MadMoonZoneProjectile.effectedEnemies == null;
				int level = madMoonZoneProjectile.level;
				bool flag13 = madMoonZoneProjectile.level >= effectedEnemies.Length;
				bool flag14 = effectedEnemies[level] == null;
				bool flag15 = ((List<object>)(object)effectedEnemies[level]).Remove((object)enemy);
				return false;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private Camera _camera;

	private float alpha = 0.05f;

	public MadMoonProjectile symbol;

	public float2 playerPos;

	private MadMoonSymbol effect;

	private int reel;

	public float buffMultiplier;

	private static List<EnemyController>[] effectedEnemies;

	private static List<Gem>[] effectedGems;

	private static List<TreasureChest>[] effectedTreasures;

	private static List<Coin>[] effectedCoins;

	private static List<Destructible>[] effectedLights;

	private int level;

	private MultiTargetTween _scaleTween;

	private Timer anforaDisappearTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
	}

	public void AfterInit(MadMoonProjectile symbol, float time, int level, int reel, MadMoonSymbol effect, float value = 1f, bool specialBonus = false)
	{
		//IL_0102: Expected O, but got I4
		//IL_0102: Expected O, but got I
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_01b3: Expected O, but got I
		this.symbol = symbol;
		int num = default(int);
		this.reel = num;
		this.level = level;
		MadMoonSymbol madMoonSymbol = default(MadMoonSymbol);
		this.effect = madMoonSymbol;
		switch (madMoonSymbol)
		{
		case MadMoonSymbol.Clover:
		{
			GameManager core2 = GM.Core;
			Action<GameplaySignals.DestructibleDestroyed> action2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD290");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v7 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj = null;
			Action<object> action3 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.DestructibleDestroyed>)obj)._003CSubscribeId_003Eb__0;
			((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.DestructibleDestroyed>)0)._003CSubscribeId_003Eb__0((object)1);
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			SignalBus signalBus = core2._signalBus;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v26 (System.Object)+10]");
			Type signalType = default(Type);
			Action<object> callback = default(Action<object>);
			signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
			break;
		}
		case MadMoonSymbol.Curse:
		{
			GameManager core = GM.Core;
			Action<GameplaySignals.EnemyKilledImmediateSignal> action = null;
			((MadMoonZoneProjectile)(object)action).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)this);
			((MadMoonZoneProjectile)(object)core._signalBus).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)action);
			break;
		}
		}
		float mult = default(float);
		bool specialBonus2 = default(bool);
		CheckObjects(mult, specialBonus2);
		Despawn();
	}

	private unsafe Color getColor(MadMoonSymbol madMoonSymbol)
	{
		//IL_000a: Expected native int or pointer, but got O
		//IL_0146: Expected native int or pointer, but got O
		//IL_0154: Expected native int or pointer, but got O
		//IL_0162: Expected native int or pointer, but got O
		//IL_003a: Expected O, but got I4
		//IL_0117: Expected native int or pointer, but got O
		//IL_0125: Expected native int or pointer, but got O
		//IL_0133: Expected native int or pointer, but got O
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_00e8: Expected native int or pointer, but got O
		//IL_00f6: Expected native int or pointer, but got O
		//IL_0104: Expected native int or pointer, but got O
		//IL_00b9: Expected native int or pointer, but got O
		//IL_00c7: Expected native int or pointer, but got O
		//IL_00d5: Expected native int or pointer, but got O
		//IL_008a: Expected native int or pointer, but got O
		//IL_0098: Expected native int or pointer, but got O
		//IL_00a6: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->a = alpha;
		bool flag = madMoonSymbol == MadMoonSymbol.Curse;
		if (!flag)
		{
			object obj = madMoonSymbol - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						((Color*)(nint)color)->r = 1f;
						((Color*)(nint)color)->g = 1f;
						((Color*)(nint)color)->b = 1f;
						return color;
					}
					((Color*)(nint)color)->r = 0.82f;
					((Color*)(nint)color)->g = 0.7f;
					((Color*)(nint)color)->b = 0.45f;
					return color;
				}
				((Color*)(nint)color)->r = 0.28f;
				((Color*)(nint)color)->g = 0.75f;
				((Color*)(nint)color)->b = 0.33f;
				return color;
			}
			((Color*)(nint)color)->r = 0.9f;
			((Color*)(nint)color)->g = 0.71f;
			((Color*)(nint)color)->b = 0.09f;
			return color;
		}
		((Color*)(nint)color)->r = 0.74f;
		((Color*)(nint)color)->g = 0.39f;
		((Color*)(nint)color)->b = 1f;
		return color;
	}

	public void CheckObjects(float mult = 1f, bool specialBonus = false)
	{
		//IL_003f: Expected O, but got I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0663: Expected I4, but got O
		//IL_0671: Expected I4, but got O
		//IL_0692: Expected I, but got O
		//IL_0788: Expected F4, but got I4
		//IL_00d5: Expected I4, but got O
		//IL_00df: Expected I4, but got O
		//IL_0be6: Invalid comparison between F4 and I
		//IL_079d: Invalid comparison between F4 and I
		//IL_0128: Expected O, but got I
		//IL_0131: Expected I4, but got O
		//IL_013b: Expected I4, but got O
		//IL_09a8: Expected O, but got I
		//IL_07c4: Expected O, but got I
		//IL_037b: Expected I, but got O
		//IL_0167: Expected O, but got I
		//IL_09e7: Invalid comparison between O and F4
		//IL_0a0d: Expected O, but got I
		//IL_0a27: Expected O, but got I4
		//IL_07f9: Invalid comparison between F4 and I
		//IL_01aa: Expected O, but got I
		//IL_01db: Expected O, but got I4
		//IL_084e: Expected O, but got I
		//IL_0502: Expected I, but got O
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		bool flag = effect == MadMoonSymbol.Curse;
		bool flag3 = default(bool);
		HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
		if (!flag)
		{
			object obj = effect - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						return;
					}
					float num = mult * 0.1f;
					List<Pickup> allPickupsOfTypes = PickupManager.GetAllPickupsOfTypes(new ItemType[4]
					{
						ItemType.COIN,
						ItemType.COINBAG1,
						ItemType.COINBAGMAX,
						ItemType.STATIC_GOLDPILE
					});
					bool flag2 = (byte)(int)GM.Core != 0;
					if ((int)(~GM.Core) == 0 && allPickupsOfTypes != null)
					{
						int index = allPickupsOfTypes._size;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r8_v16 (System.Boolean)+238]");
						((List<object>)(object)allPickupsOfTypes).InsertRange(index, (IEnumerable<object>)0);
						flag2 = (byte)(int)GM.Core != 0;
						if ((int)(~GM.Core) == 0)
						{
							int index2 = allPickupsOfTypes._size;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r8_v16 (System.Boolean)+250]");
							((List<object>)(object)allPickupsOfTypes).InsertRange(index2, (IEnumerable<object>)0);
							if (allPickupsOfTypes._size > 0)
							{
								int index3 = allPickupsOfTypes._size;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r8_v16 (System.Boolean)+250]");
								allPickupsOfTypes.InsertRange(index3, (IEnumerable<Pickup>)0);
								float num2 = (float)allPickupsOfTypes._size + num;
								float value = num2 / (float)allPickupsOfTypes._size;
								object obj3 = 0;
								while ((nint)obj3 < allPickupsOfTypes._size)
								{
									if ((nint)obj3 < allPickupsOfTypes._size)
									{
										Pickup[] items = allPickupsOfTypes._items;
										if (allPickupsOfTypes._items != null)
										{
											if ((nint)obj3 >= items.Length)
											{
												goto IL_0af7;
											}
											if ((object)items[obj3] != null)
											{
												items[obj3].Bless(value);
												obj3++;
												flag2 = true;
												continue;
											}
										}
										goto IL_0a8c;
									}
									goto IL_0aed;
								}
							}
							if (flag3)
							{
								SpawnAnforaCluster();
							}
							return;
						}
					}
				}
				else
				{
					float num3 = mult * 0.1f;
					ItemType[] array = new ItemType[1];
					if (array != null)
					{
						if (array.Length <= 0)
						{
							goto IL_0af7;
						}
						_ = 8;
						List<Pickup> allPickupsOfTypes2 = PickupManager.GetAllPickupsOfTypes(array);
						if (allPickupsOfTypes2 != null)
						{
							List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
							if (enumerator.MoveNext())
							{
								nint num4 = (nint)typeof(TreasureChest);
								bool flag4 = false;
								bool flag2 = false;
								throw new NullReferenceException();
							}
							GameManager core = GM.Core;
							if ((object)GM.Core != null)
							{
								PhysicsManager physicsManager = core._physicsManager;
								if (core._physicsManager != null)
								{
									PhysicsGroup destructiblesGroup = physicsManager._destructiblesGroup;
									if (physicsManager._destructiblesGroup != null && ((Group)destructiblesGroup).children != null)
									{
										if (!enumerator2.MoveNext())
										{
											return;
										}
										nint num5 = (nint)typeof(Destructible);
										bool flag5 = false;
										bool flag2 = false;
										throw new NullReferenceException();
									}
								}
							}
						}
					}
				}
			}
			else
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					IEnumerable<Gem> enumerable = Enumerable.OfType<Gem>(core2._gems);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AABF60");
					object obj4 = default(object);
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B70270");
						float num6 = mult * 0.01f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+18]");
						float num7 = 0f + num6;
						float num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+18]");
						float value2 = num8 / 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+18]");
						if ((nint)0 > (nint)0)
						{
							float num9 = 0f;
							while (true)
							{
								float num10 = num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+18]");
								if (!(num10 < 0f))
								{
									break;
								}
								float num11 = num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+18]");
								if (num11 < 0f)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+10]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v50+10]");
									if ((nint)0 != 0)
									{
										float num12 = num9;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v42+18]");
										if (!(num12 < 0f))
										{
											goto IL_0af7;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v42+20+v174 @ rbx_v15 (System.Single)*8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v42+20+v174 @ rbx_v15 (System.Single)*8]");
											((Gem)0).BlessColor(value2, num9);
											num9++;
											continue;
										}
									}
									goto IL_0a8c;
								}
								goto IL_0aed;
							}
						}
						if (flag3)
						{
							SpawnSkelegems();
						}
						return;
					}
				}
			}
		}
		else
		{
			float num13 = mult * 0.1f;
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				PhysicsGroup enemies = core3.Enemies;
				if (core3.Enemies != null)
				{
					bool flag6 = (byte)(int)((Group)enemies).children != 0;
					if ((int)(~((Group)enemies).children) == 0)
					{
						object obj7 = default(object);
						while (true)
						{
							if (enumerator2.MoveNext())
							{
								nint num14 = (nint)typeof(EnemyController);
								bool flag7 = false;
								ArcadeSprite arcadeSprite = null;
								bool flag8 = (object)arcadeSprite == null;
								bool flag2 = false;
								if (flag8)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rdi_v4 (ArcadeSprite)+1F4]");
								float num15 = 0f + 10f;
								float num16 = num13 * 0.1f;
								float num17 = num16 + 1f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rdi_v4 (ArcadeSprite)+1EC]");
								float num18 = 0f * num17;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rdi_v4 (ArcadeSprite)+1E8]");
								nint num19 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rdi_v4 (ArcadeSprite)+1EC]");
								object obj6 = num19 / 0;
								float num20 = (float)obj6 * num18;
								if (!(num13 < 10f))
								{
									bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
									bool flag10 = !flag9;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rdi_v4 (ArcadeSprite)+20C]");
									object obj8 = (nint)0 & (nint)(flag10 ? 1 : 0);
									bool flag11 = obj8 == null;
									object obj9 = !flag11;
									if (obj9 == null)
									{
										float num21 = UnityEngine.Random.Range(0.1f, num18);
									}
									else
									{
										float minInclusive = num20 * 0.8f;
										float num21 = UnityEngine.Random.Range(minInclusive, num18);
									}
								}
								float2 float5 = arcadeSprite.position;
								DoVFX(float5);
								continue;
							}
							if (flag3)
							{
								SpawnReapers();
							}
							return;
						}
						goto IL_0cb5;
					}
				}
			}
		}
		goto IL_0a8c;
		IL_0aed:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0cb5;
		IL_0cb5:
		throw new NullReferenceException();
		IL_0af7:
		throw new IndexOutOfRangeException();
		IL_0a8c:
		throw new NullReferenceException();
	}

	private unsafe void SpawnSkelegems()
	{
		//IL_06a8: Expected O, but got F4
		//IL_05a6: Expected I, but got O
		//IL_0202: Invalid comparison between F4 and I4
		//IL_0463: Expected I, but got O
		//IL_0479: Expected O, but got I
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_0263: Expected O, but got I4
		//IL_04fd: Expected I, but got O
		//IL_0647: Expected O, but got I4
		//IL_065e: Expected I, but got I8
		//IL_04d9: Expected I, but got I8
		//IL_02ea: Expected O, but got F4
		//IL_05c8: Expected O, but got I4
		//IL_05d6: Expected I, but got O
		//IL_03e1: Invalid comparison between F4 and I4
		//IL_0407: Expected O, but got F4
		//IL_031f: Expected O, but got I4
		//IL_032d: Expected I, but got O
		//IL_0392: Expected I, but got O
		//IL_0639->IL0503: Incompatible stack heights: 1 vs 0
		//IL_02c5->IL0503: Incompatible stack heights: 1 vs 0
		//IL_0360->IL0503: Incompatible stack heights: 1 vs 0
		//IL_03af->IL0503: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass19_0 obj = new _003C_003Ec__DisplayClass19_0();
		List<EnemyController> spawnedEnemies = new List<EnemyController>();
		bool flag4 = default(bool);
		if (obj != null)
		{
			obj.spawnedEnemies = spawnedEnemies;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					float num = gameSessionData._activeCharacter.PGrowth();
					object obj2 = default(object);
					float num2 = (float)obj2 * 20f;
					if (!(20f > num2))
					{
						bool flag = !(num2 > 60f);
						float num3 = 60f;
						if (!flag)
						{
							num3 = 60f;
							num2 = 60f;
						}
					}
					else
					{
						num2 = 20f;
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage = core2._stage;
						if ((object)core2._stage != null && stage._stageEventManager != null)
						{
							int randomEventId = StageEventManager.RandomEventId + 1;
							StageEventManager.RandomEventId = randomEventId;
							obj.eventID = StageEventManager.RandomEventId;
							object obj3 = UnityEngine.Random.value;
							GameSessionData gameSessionData2 = _gameSessionData;
							float num4 = (float)obj2 * ((float)Math.PI * 2f);
							if (_gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
							{
								Transform transform = gameSessionData2._activeCharacter.transform;
								if ((object)transform != null)
								{
									bool flag2 = ((List<EnemyController>)(object)transform)._items == null;
									Transform.get_position_Injected((IntPtr)((List<EnemyController>)(object)transform)._items, out Vector3 _);
									Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
									if (!(num2 > 0f))
									{
										goto IL_0415;
									}
									float num5 = num2 * 0.5f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v36 (UnityEngine.Bounds)+10]");
									float num6 = 0f * 2f;
									float num7 = (float)Math.PI / num5;
									bool flag3 = false;
									Vector2 vector = (Vector2)0;
									Camera mainCamera = _mainCamera;
									object obj4 = default(object);
									nint num8 = (nint)(&obj4);
									object obj5 = default(object);
									float num13 = default(float);
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
										float num9 = num4 + num7;
										float num10 = num4 * 0.8f;
										GameManager core3 = GM.Core;
										if ((object)GM.Core == null)
										{
											break;
										}
										float num11 = num6 * 0.9f;
										float num12 = num11 * num10;
										float num3 = num12 + (float)obj5;
										if ((object)core3._stage == null)
										{
											break;
										}
										GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.EX_SKELEGEM, (Vector2)num13, asRemote: false, flag4);
										bool flag5 = (object)gameObject == null;
										mainCamera = (Camera)1251;
										num8 = (nint)typeof(UnityEngine.Object);
										if (!flag5)
										{
											bool flag6 = ((List<EnemyController>)(object)gameObject)._items == null;
											mainCamera = (Camera)1251;
											num8 = (nint)typeof(UnityEngine.Object);
											if (!flag6)
											{
												EnemyController component = gameObject.GetComponent<EnemyController>();
												if ((object)component == null)
												{
													break;
												}
												component._003CIsCullable_003Ek__BackingField = false;
												component._003CStageEventId_003Ek__BackingField = obj.eventID;
												num8 = (nint)obj.spawnedEnemies;
												if (obj.spawnedEnemies == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
												mainCamera = (Camera)(object)component;
											}
										}
										flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
										bool flag7 = num2 > (float)(flag3 ? 1 : 0);
										flag4 = flag4;
										num4 = num9;
										num5 = num13;
										vector = (Vector2)num13;
										if (flag7)
										{
											continue;
										}
										goto IL_0415;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_063e:
		object obj6 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(60.000004f, action, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		anforaDisappearTimer = timer;
		return;
		IL_0415:
		action = null;
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_0._003CSpawnSkelegems_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num15;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num15 = unchecked((nint)6447293664L);
				goto IL_063e;
			}
		}
		num15 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_063e;
	}

	private unsafe void SpawnAnforaCluster()
	{
		//IL_0370: Invalid comparison between F4 and I4
		//IL_0381: Expected I4, but got F4
		//IL_0274: Expected I, but got O
		//IL_028a: Expected O, but got I
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_030e: Expected I, but got O
		//IL_03d1: Expected O, but got I4
		//IL_03e8: Expected I, but got I8
		//IL_0416: Expected O, but got I4
		//IL_02ea: Expected I, but got I8
		//IL_020a: Invalid comparison between F4 and I4
		//IL_0218: Expected I4, but got F4
		_003C_003Ec__DisplayClass20_0 obj = new _003C_003Ec__DisplayClass20_0();
		List<EnemyController> spawnedEnemies = new List<EnemyController>();
		obj.spawnedEnemies = spawnedEnemies;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float num = gameSessionData._activeCharacter.PGreed();
		bool flag = default(bool);
		float num2 = (float)(flag ? 1 : 0) * 20f;
		bool flag2 = 20f > num2;
		float num3 = 20f;
		float num4;
		if (!flag2)
		{
			bool flag3 = !(num2 > 60f);
			num3 = 60f;
			num4 = 60f;
			if (flag3)
			{
				goto IL_0333;
			}
		}
		num2 = num3;
		num4 = num3;
		goto IL_0333;
		IL_03c8:
		object obj2 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime;
		ItemType itemType = default(ItemType);
		bool flag4 = default(bool);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(60.000004f, action, null, isLooped: false, useRealTime, (MonoBehaviour)itemType, flag4 ? 1 : 0, type, isOnlineTimer: false, canPause: false);
		anforaDisappearTimer = timer;
		return;
		IL_0333:
		GameManager core2 = GM.Core;
		Weapon weapon = _weapon;
		Vector2 positionWithinSight = core2._stage.GetPositionWithinSight(((Equipment)weapon)._003COwner_003Ek__BackingField, 90f, 0.1f);
		float num5 = default(float);
		Pickup pickup = GM.Core.MakeStagePickup(positionWithinSight, ItemType.STATIC_GOLDPILE, WeaponType.VOID, num5, itemType, flag4);
		GameManager core3 = GM.Core;
		Stage stage = core3._stage;
		if (stage._stageEventManager == null)
		{
			throw new NullReferenceException();
		}
		int randomEventId = StageEventManager.RandomEventId + 1;
		StageEventManager.RandomEventId = randomEventId;
		obj.eventID = StageEventManager.RandomEventId;
		bool flag5 = !(num2 > 0f);
		useRealTime = (byte)(int)num5 != 0;
		bool flag6 = false;
		if (!flag5)
		{
			Component component = default(Component);
			bool flag7;
			do
			{
				GameManager core4 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					EnemyController component2 = component.GetComponent<EnemyController>();
					component2._003CIsCullable_003Ek__BackingField = false;
					component2._003CStageEventId_003Ek__BackingField = obj.eventID;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
				}
				flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
				flag7 = num2 > (float)(flag6 ? 1 : 0);
				useRealTime = (byte)(int)num5 != 0;
			}
			while (flag7);
		}
		action = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CSpawnAnforaCluster_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		nint num7;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num7 = unchecked((nint)6447293664L);
				goto IL_03c8;
			}
		}
		num7 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_03c8;
	}

	private void SpawnReapers()
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass21_0();
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		bool flag = default(bool);
		GM.Core.RosaryDamage(showVfx: true, 1f, WeaponType.VOID, flag);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (stage._stageEventManager == null)
		{
			throw new NullReferenceException();
		}
		int randomEventId = StageEventManager.RandomEventId + 1;
		StageEventManager.RandomEventId = randomEventId;
		CS_0024_003C_003E8__locals10.eventID = StageEventManager.RandomEventId;
		GameManager core2 = GM.Core;
		EnemyController blinder = core2._stage.SpawnMadMoonBlinder();
		CS_0024_003C_003E8__locals10.blinder = blinder;
		EnemyController blinder2 = CS_0024_003C_003E8__locals10.blinder;
		blinder2._003CIsCullable_003Ek__BackingField = false;
		EnemyController blinder3 = CS_0024_003C_003E8__locals10.blinder;
		blinder3._003CStageEventId_003Ek__BackingField = CS_0024_003C_003E8__locals10.eventID;
		Action onComplete = delegate
		{
			EnemyController blinder4 = CS_0024_003C_003E8__locals10.blinder;
			if ((object)CS_0024_003C_003E8__locals10.blinder != null && ((UnityEngine.Object)blinder4).m_CachedPtr != (IntPtr)0)
			{
				EnemyController blinder5 = CS_0024_003C_003E8__locals10.blinder;
				if (!blinder5._003CIsDead_003Ek__BackingField && blinder5._003CStageEventId_003Ek__BackingField == CS_0024_003C_003E8__locals10.eventID)
				{
					blinder5._003CIsCullable_003Ek__BackingField = true;
					CS_0024_003C_003E8__locals10.blinder.Disappear();
				}
			}
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		anforaDisappearTimer = timer;
	}

	public void AddGemEffect(Gem gem)
	{
		//IL_002b: Expected F4, but got I4
		float index = UnityEngine.Random.RandomRangeInt(0, 11);
		gem.BlessColor(0.001f, index);
	}

	public void AddTreasureEffect(TreasureChest treasure, float valueLuck = 1f)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm2\"");
		float value = default(float);
		treasure.Bless(value);
	}

	public void AddCoinEffect(Coin coin)
	{
		coin.Bless(0.1f);
	}

	public void AddLightEffect(Destructible destructible, float valueLuck = 1f)
	{
		float num = valueLuck * 0.1f;
		float num2 = num + 0.4f;
		float blessedLevel = num2 + destructible._blessedLevel;
		destructible._blessedLevel = blessedLevel;
		float2 float5 = destructible.position;
		DoVFX(float5);
	}

	public void AddEnemyEffect(EnemyController enemy, float valueCurse = 1f)
	{
		//IL_00c3: Invalid comparison between O and F4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_0100: Expected O, but got I4
		float num = enemy._003CSpeed_003Ek__BackingField + 10f;
		float num2 = valueCurse * 0.1f;
		enemy._003CSpeed_003Ek__BackingField = num;
		float num3 = num2 + 1f;
		float num4 = enemy._hp / enemy._maxHp;
		float num5 = num3 * enemy._maxHp;
		float num6 = num4 * num5;
		enemy._maxHp = num5;
		enemy._hp = num6;
		if (!(valueCurse < 10f))
		{
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			bool flag2 = !flag;
			object obj2 = (_003F?)enemy._003CResRosary_003Ek__BackingField & flag2;
			bool flag3 = obj2 == null;
			object obj3 = !flag3;
			float minInclusive;
			if (obj3 == null)
			{
				minInclusive = 0.1f;
			}
			else
			{
				float num7 = num6 * 0.8f;
				minInclusive = num7;
			}
			float hp = UnityEngine.Random.Range(minInclusive, num5);
			enemy._hp = hp;
		}
		float2 float5 = enemy.position;
		DoVFX(float5);
	}

	public void OnEnemyKilled(GameplaySignals.EnemyKilledImmediateSignal signal)
	{
		//IL_0118: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		List<EnemyController>[] array = effectedEnemies;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= array.Length)
			{
				return;
			}
			List<EnemyController> list = array[obj];
			if (list._size != 0)
			{
				int num = Array.IndexOf((object[])list._items, (object)signal, 0, list._size);
				if (num != -1)
				{
					break;
				}
			}
			obj++;
			obj2 = obj;
		}
		List<EnemyController>[] array2 = effectedEnemies;
		int num2 = level;
		bool flag = ((List<object>)(object)array2[num2]).Remove((object)signal);
	}

	public void OnDestructibleDestroyed(GameplaySignals.DestructibleDestroyed signal)
	{
		//IL_0118: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		List<Destructible>[] array = effectedLights;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= array.Length)
			{
				return;
			}
			List<Destructible> list = array[obj];
			if (list._size != 0)
			{
				int num = Array.IndexOf((object[])list._items, (object)signal, 0, list._size);
				if (num != -1)
				{
					break;
				}
			}
			obj++;
			obj2 = obj;
		}
		List<Destructible>[] array2 = effectedLights;
		int num2 = level;
		bool flag = ((List<object>)(object)array2[num2]).Remove((object)signal);
	}

	private void DoVFX(float2 position)
	{
		//IL_006c: Expected I4, but got I8
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(core2._pickupVfx, pos, -1);
		}
	}

	public void OnItemPickedUp(Pickup pickup)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Expected O, but got I4
		//IL_07be: Expected O, but got I4
		//IL_07c7: Expected O, but got I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_0521: Expected I, but got O
		//IL_0529: Expected I, but got O
		//IL_0539: Expected O, but got I
		//IL_00c4: Expected O, but got I4
		//IL_0575: Expected O, but got I
		//IL_0770: Expected O, but got I4
		//IL_0779: Expected O, but got I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0632: Expected I, but got O
		//IL_063a: Expected I, but got O
		//IL_064a: Expected O, but got I
		//IL_0360: Expected I, but got O
		//IL_0368: Expected I, but got O
		//IL_0378: Expected O, but got I
		//IL_0686: Expected O, but got I
		//IL_03b4: Expected O, but got I
		//IL_0731: Expected O, but got I4
		//IL_073a: Expected O, but got I4
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		//IL_0471: Expected I, but got O
		//IL_0479: Expected I, but got O
		//IL_0489: Expected O, but got I
		//IL_017d: Expected I, but got O
		//IL_0185: Expected I, but got O
		//IL_0195: Expected O, but got I
		//IL_04c5: Expected O, but got I
		//IL_01d1: Expected O, but got I
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_028e: Expected I, but got O
		//IL_0296: Expected I, but got O
		//IL_02a6: Expected O, but got I
		//IL_02e2: Expected O, but got I
		object obj = pickup + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Pickup pickup2 = (Pickup)1;
		object obj4 = default(object);
		object obj5 = default(object);
		List<object> list;
		if (obj4 != obj5)
		{
			object obj6 = pickup + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj8 = default(object);
			object obj7 = obj8 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			pickup2 = (Pickup)1;
			object obj9 = default(object);
			object obj10 = default(object);
			if (obj9 != obj10)
			{
				object obj11 = pickup + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj13 = default(object);
				object obj12 = obj13 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj14 = default(object);
				object obj15 = default(object);
				if (obj14 != obj15)
				{
					return;
				}
				List<Coin>[] array = effectedCoins;
				object obj16 = 0;
				object obj17 = 0;
				while (true)
				{
					if ((nint)obj17 >= array.Length)
					{
						return;
					}
					list = (List<object>)(object)array[obj16];
					nint num = (nint)typeof(Coin);
					nint num2 = (nint)pickup;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rdx_v34 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v75+FFFFFFF8+v326 @ rax_v74*8]");
						if (0 == (nint)typeof(Coin))
						{
							if (list._size != 0)
							{
								int num4 = Array.IndexOf(list._items, pickup, 0, list._size);
								if (num4 != -1)
								{
									break;
								}
							}
							obj16++;
							obj17 = obj16;
							continue;
						}
					}
					throw new InvalidCastException();
				}
				nint num5 = (nint)typeof(Coin);
				nint num6 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v53 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v53 (Il2CppClass<VampireSurvivors.Objects.Items.Coin>)+130]");
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v84+FFFFFFF8+v228 @ rax_v83*8]");
					if (0 == (nint)typeof(Coin))
					{
						goto IL_0796;
					}
				}
				throw new InvalidCastException();
			}
			List<TreasureChest>[] array2 = effectedTreasures;
			object obj22 = 0;
			object obj23 = 0;
			while (true)
			{
				if ((nint)obj23 >= array2.Length)
				{
					return;
				}
				list = (List<object>)(object)array2[obj22];
				nint num8 = (nint)typeof(TreasureChest);
				nint num9 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Items.TreasureChest>)+130]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Items.TreasureChest>)+130]");
				if (num10 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v53+FFFFFFF8+v633 @ rax_v52*8]");
					if (0 == (nint)typeof(TreasureChest))
					{
						if (list._size != 0)
						{
							int num11 = Array.IndexOf(list._items, pickup, 0, list._size);
							if (num11 != -1)
							{
								break;
							}
						}
						obj22++;
						obj23 = obj22;
						continue;
					}
				}
				throw new InvalidCastException();
			}
			nint num12 = (nint)typeof(TreasureChest);
			nint num13 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rcx_v41 (Il2CppClass<VampireSurvivors.Objects.Items.TreasureChest>)+130]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rcx_v41 (Il2CppClass<VampireSurvivors.Objects.Items.TreasureChest>)+130]");
			if (num14 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v62+FFFFFFF8+v415 @ rax_v61*8]");
				if (0 == (nint)typeof(TreasureChest))
				{
					goto IL_0796;
				}
			}
			throw new InvalidCastException();
		}
		List<Gem>[] array3 = effectedGems;
		object obj28 = 0;
		object obj29 = 0;
		while (true)
		{
			if ((nint)obj29 >= array3.Length)
			{
				return;
			}
			list = (List<object>)(object)array3[obj28];
			nint num15 = (nint)typeof(Gem);
			nint num16 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
			object obj30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
			if (num17 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v30+FFFFFFF8+v806 @ rax_v29*8]");
				if (0 == (nint)typeof(Gem))
				{
					if (list._size != 0)
					{
						int num18 = Array.IndexOf(list._items, pickup, 0, list._size);
						if (num18 != -1)
						{
							break;
						}
					}
					obj28++;
					obj29 = obj28;
					continue;
				}
			}
			throw new InvalidCastException();
		}
		nint num19 = (nint)typeof(Gem);
		nint num20 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rcx_v28 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
		if (num21 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rcx_v28 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v39+FFFFFFF8+v832 @ rax_v38*8]");
			if (0 == (nint)typeof(Gem))
			{
				goto IL_0796;
			}
		}
		throw new InvalidCastException();
		IL_0796:
		bool flag = list.Remove(pickup);
	}

	private IEnumerator DamageEnemyLoop(EnemyController enemy, float amount)
	{
		_003CDamageEnemyLoop_003Ed__31 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.enemy = enemy;
		obj.amount = amount;
		return obj;
	}

	private bool ObjectOverlaps(float2 objectPos)
	{
		//IL_01f5: Expected I4, but got O
		//IL_00db: Invalid comparison between O and F4
		//IL_0119: Invalid comparison between F4 and O
		//IL_0157: Invalid comparison between O and F4
		//IL_0195: Invalid comparison between F4 and O
		//IL_01b3: Invalid comparison between F4 and I4
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdx_v2 (BaseBody)+5C]");
				float num = 0f * 100f;
				float num2 = (float)baseBody._size * 100f;
				float num3 = num * 0.00390625f;
				float num4 = num2 * 0.00390625f;
				float2 float5 = _sprite.position;
				float num5 = num4 * 0.5f;
				float num6 = (float)float5 - num5;
				if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref objectPos) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
				{
					float num7 = num4 * 0.5f;
					float num8 = num7 + (float)float5;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref objectPos))
					{
						float num9 = num3 * 0.5f;
						object obj = default(object);
						float num10 = (float)obj - num9;
						object obj2 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10))
						{
							float num11 = num3 * 0.5f;
							float num12 = num11 + (float)obj;
							bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
							float num13 = num12 - (float)obj2;
							bool flag2 = num13 == 0f;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							return flag4 & flag3;
						}
					}
				}
				return false;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void Despawn()
	{
		//IL_0161: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		if (effect != MadMoonSymbol.Curse)
		{
			if (effect == MadMoonSymbol.Clover)
			{
				GameManager core = GM.Core;
				Action<GameplaySignals.DestructibleDestroyed> token = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD290");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type signalType = default(Type);
				bool throwIfMissing = default(bool);
				core._signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
			}
		}
		else
		{
			GameManager core2 = GM.Core;
			Action<GameplaySignals.EnemyKilledImmediateSignal> action = null;
			((MadMoonZoneProjectile)(object)action).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)this);
			((MadMoonZoneProjectile)(object)core2._signalBus).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)action);
			List<EnemyController>[] array = effectedEnemies;
			int num = 0;
			for (int num2 = 0; num2 < array.Length; num2 = num)
			{
				List<EnemyController> list = array[num];
				int version = list._version + 1;
				list._version = version;
				list._size = 0;
				if (list._size > 0)
				{
					Array.Clear(list._items, 0, list._size);
					object obj3 = 0;
				}
				num++;
			}
		}
		base.Despawn();
	}

	public void RemoveGemEffect(Gem gem, int level)
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_006f: Expected O, but got I4
		object obj = level + 1;
		object obj2 = obj * 4;
		object obj3 = obj + obj2;
		object obj4 = obj3 + obj3;
		float num = ((Pickup)gem)._003CValue_003Ek__BackingField - (float)obj4;
		((Pickup)gem)._003CValue_003Ek__BackingField = num;
		ArcadeSprite arcadeSprite = gem.setScale(1f, (float?)(object)0);
		List<Gem>[] array = effectedGems;
		bool flag = ((List<object>)(object)array[level]).Remove((object)gem);
	}

	public void RemoveTreasureEffect(TreasureChest treasure, int level)
	{
		//IL_002e: Expected O, but got I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected I4, but got Unknown
		//IL_00a5: Expected O, but got I4
		Treasure treasure2 = treasure._treasure;
		object obj = treasure2._003Clevel_003Ek__BackingField - level;
		int num = obj - 1;
		if (num < 1)
		{
			num = 1;
		}
		treasure2._003Clevel_003Ek__BackingField = num;
		ArcadeSprite arcadeSprite = treasure.setScale(1f, (float?)(object)0);
		List<TreasureChest>[] array = effectedTreasures;
		bool flag = ((List<object>)(object)array[level]).Remove((object)treasure);
	}

	public void RemoveCoinEffect(Coin coin, int level)
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_006f: Expected O, but got I4
		object obj = level + 1;
		object obj2 = obj * 4;
		object obj3 = obj + obj2;
		object obj4 = obj3 + obj3;
		float num = ((Pickup)coin)._003CValue_003Ek__BackingField - (float)obj4;
		((Pickup)coin)._003CValue_003Ek__BackingField = num;
		ArcadeSprite arcadeSprite = coin.setScale(1f, (float?)(object)0);
		List<Coin>[] array = effectedCoins;
		bool flag = ((List<object>)(object)array[level]).Remove((object)coin);
	}

	public void RemoveLightEffect(Destructible p, int level)
	{
		Destructible destructible = RenderingExtensions.SetScale(p, 1f);
		List<Destructible>[] array = effectedLights;
		bool flag = ((List<object>)(object)array[level]).Remove((object)p);
	}

	public void RemoveEnemyEffect(EnemyController enemy)
	{
		//IL_0018: Expected O, but got I4
		ArcadeSprite arcadeSprite = enemy.setScale(1f, (float?)(object)0);
		List<EnemyController>[] array = effectedEnemies;
		int num = level;
		bool flag = ((List<object>)(object)array[num]).Remove((object)enemy);
	}

	static MadMoonZoneProjectile()
	{
		//IL_002a: Expected I, but got O
		//IL_008f: Expected I, but got O
		//IL_00f4: Expected I, but got O
		//IL_0159: Expected I, but got O
		//IL_01df: Expected I, but got O
		//IL_0244: Expected I, but got O
		//IL_02a9: Expected I, but got O
		//IL_030e: Expected I, but got O
		//IL_0394: Expected I, but got O
		//IL_03f9: Expected I, but got O
		//IL_045e: Expected I, but got O
		//IL_04c3: Expected I, but got O
		//IL_0549: Expected I, but got O
		//IL_05ae: Expected I, but got O
		//IL_0613: Expected I, but got O
		//IL_0678: Expected I, but got O
		//IL_06fe: Expected I, but got O
		//IL_0763: Expected I, but got O
		//IL_07c8: Expected I, but got O
		//IL_082d: Expected I, but got O
		List<EnemyController>[] array = new List<EnemyController>[4];
		List<EnemyController> list = new List<EnemyController>();
		if (list != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<EnemyController> list2 = new List<EnemyController>();
		if (list2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<EnemyController> list3 = new List<EnemyController>();
		if (list3 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<EnemyController> list4 = new List<EnemyController>();
		if (list4 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		effectedEnemies = array;
		List<Gem>[] array2 = new List<Gem>[4];
		List<Gem> list5 = new List<Gem>();
		if (list5 != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Gem> list6 = new List<Gem>();
		if (list6 != null)
		{
			nint num6 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Gem> list7 = new List<Gem>();
		if (list7 != null)
		{
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Gem> list8 = new List<Gem>();
		if (list8 != null)
		{
			nint num8 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
				throw ex8;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		effectedGems = array2;
		List<TreasureChest>[] array3 = new List<TreasureChest>[4];
		List<TreasureChest> list9 = new List<TreasureChest>();
		if (list9 != null)
		{
			nint num9 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 == null)
			{
				ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
				throw ex9;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<TreasureChest> list10 = new List<TreasureChest>();
		if (list10 != null)
		{
			nint num10 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			if (obj10 == null)
			{
				ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
				throw ex10;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<TreasureChest> list11 = new List<TreasureChest>();
		if (list11 != null)
		{
			nint num11 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 == null)
			{
				ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
				throw ex11;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<TreasureChest> list12 = new List<TreasureChest>();
		if (list12 != null)
		{
			nint num12 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj12 = default(object);
			if (obj12 == null)
			{
				ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
				throw ex12;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		effectedTreasures = array3;
		List<Coin>[] array4 = new List<Coin>[4];
		List<Coin> list13 = new List<Coin>();
		if (list13 != null)
		{
			nint num13 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj13 = default(object);
			if (obj13 == null)
			{
				ArrayTypeMismatchException ex13 = new ArrayTypeMismatchException();
				throw ex13;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Coin> list14 = new List<Coin>();
		if (list14 != null)
		{
			nint num14 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj14 = default(object);
			if (obj14 == null)
			{
				ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
				throw ex14;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Coin> list15 = new List<Coin>();
		if (list15 != null)
		{
			nint num15 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj15 = default(object);
			if (obj15 == null)
			{
				ArrayTypeMismatchException ex15 = new ArrayTypeMismatchException();
				throw ex15;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Coin> list16 = new List<Coin>();
		if (list16 != null)
		{
			nint num16 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj16 = default(object);
			if (obj16 == null)
			{
				ArrayTypeMismatchException ex16 = new ArrayTypeMismatchException();
				throw ex16;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		effectedCoins = array4;
		List<Destructible>[] array5 = new List<Destructible>[4];
		List<Destructible> list17 = new List<Destructible>();
		if (list17 != null)
		{
			nint num17 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			if (obj17 == null)
			{
				ArrayTypeMismatchException ex17 = new ArrayTypeMismatchException();
				throw ex17;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Destructible> list18 = new List<Destructible>();
		if (list18 != null)
		{
			nint num18 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj18 = default(object);
			if (obj18 == null)
			{
				ArrayTypeMismatchException ex18 = new ArrayTypeMismatchException();
				throw ex18;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Destructible> list19 = new List<Destructible>();
		if (list19 != null)
		{
			nint num19 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj19 = default(object);
			if (obj19 == null)
			{
				ArrayTypeMismatchException ex19 = new ArrayTypeMismatchException();
				throw ex19;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		List<Destructible> list20 = new List<Destructible>();
		if (list20 != null)
		{
			nint num20 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj20 = default(object);
			if (obj20 == null)
			{
				ArrayTypeMismatchException ex20 = new ArrayTypeMismatchException();
				throw ex20;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		effectedLights = array5;
	}
}
