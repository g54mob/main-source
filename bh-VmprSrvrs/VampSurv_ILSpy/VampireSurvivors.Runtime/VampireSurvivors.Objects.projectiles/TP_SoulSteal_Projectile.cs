using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SoulSteal_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public TP_SoulSteal_Projectile _003C_003E4__this;

		public List<EnemyController> enemies;

		internal void _003CCheckForDoSoulStealAgain_003Eb__0()
		{
			_003C_003E4__this.CheckForDoSoulStealAgain(enemies);
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public float2 enemyPos;

		public TP_SoulSteal_Projectile _003C_003E4__this;

		internal void _003CDoSoulSteal_003Eb__0()
		{
			if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TP_SOULSTEAL_LITTLEHEART))
			{
				Vector2 pos = default(Vector2);
				Pickup pickup = PickupManager.CreatePickup(pos, ItemType.TP_SOULSTEAL_LITTLEHEART);
				pickup.GoToPlayer = true;
				TP_SoulSteal_Projectile tP_SoulSteal_Projectile = _003C_003E4__this;
				Weapon weapon = tP_SoulSteal_Projectile._weapon;
				pickup._targetPlayer = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				pickup.Time = 1.6518f;
				return;
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public float2 enemyPos;

		public TP_SoulSteal_Projectile _003C_003E4__this;

		internal void _003CDoSoulStealAgain_003Eb__0()
		{
			if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TP_SOULSTEAL_LITTLEHEART))
			{
				Vector2 pos = default(Vector2);
				Pickup pickup = PickupManager.CreatePickup(pos, ItemType.TP_SOULSTEAL_LITTLEHEART);
				pickup.GoToPlayer = true;
				TP_SoulSteal_Projectile tP_SoulSteal_Projectile = _003C_003E4__this;
				Weapon weapon = tP_SoulSteal_Projectile._weapon;
				pickup._targetPlayer = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				pickup.Time = 1.6518f;
				return;
			}
			throw new NullReferenceException();
		}
	}

	private bool _tryAgain;

	private int _tries;

	private List<PhaserSprite> explosionSprites;

	private int _exploIndex;

	private TP_SoulSteal_Weapon _soulStealWeapon;

	protected override void Awake()
	{
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0141: Expected O, but got I4
		//IL_0069: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_0101: Expected O, but got I4
		//IL_00bd: Expected O, but got I
		//IL_0110: Expected I4, but got O
		//IL_00f3: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon2 = _weapon;
		_tryAgain = false;
		_tries = 3;
		bool flag = (object)_weapon == null;
		bool flag2 = false;
		if (flag)
		{
			goto IL_0137;
		}
		nint num = (nint)typeof(TP_SoulSteal_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SoulSteal_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SoulSteal_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v17+FFFFFFF8+v72 @ rax_v13*8]");
			if (0 == (nint)typeof(TP_SoulSteal_Weapon))
			{
				obj3 = 1;
				goto IL_0146;
			}
		}
		obj3 = 0;
		goto IL_0146;
		IL_0137:
		_soulStealWeapon = (TP_SoulSteal_Weapon)flag2;
		return;
		IL_0146:
		bool flag3 = obj3 == null;
		flag2 = false;
		if (!flag3)
		{
			flag2 = (byte)(int)_weapon != 0;
		}
		goto IL_0137;
	}

	public override void InternalUpdate()
	{
	}

	public unsafe void DoSoulSteal(List<EnemyController> enemies)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected O, but got Unknown
		//IL_01e9: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		//IL_02e6: Expected F4, but got I4
		//IL_0291: Expected I4, but got F4
		//IL_0550: Expected I, but got O
		//IL_0325: Expected I, but got O
		//IL_033c: Expected I, but got O
		//IL_0350: Expected F4, but got I4
		//IL_035b: Expected F4, but got I4
		//IL_00ad->IL0457: Incompatible stack heights: 1 vs 0
		//IL_00e4->IL0457: Incompatible stack heights: 1 vs 0
		//IL_0117->IL0457: Incompatible stack heights: 1 vs 0
		//IL_04f6->IL05a7: Incompatible stack heights: 2 vs 0
		//IL_015d->IL0457: Incompatible stack heights: 2 vs 0
		//IL_0384->IL0457: Incompatible stack heights: 2 vs 0
		//IL_0318->IL0457: Incompatible stack heights: 2 vs 0
		//IL_0543->IL0457: Incompatible stack heights: 2 vs 0
		//IL_041d->IL0457: Incompatible stack heights: 2 vs 0
		if (enemies != null)
		{
			object obj = 0;
			object obj2 = 0;
			object obj3 = 0;
			object obj4 = 0;
			float num2 = default(float);
			float num3 = default(float);
			int num4 = default(int);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				EnemyController[] items;
				bool flag7;
				float num9;
				if ((nint)obj4 < enemies._size)
				{
					_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass8_0();
					if (CS_0024_003C_003E8__locals4 == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals4._003C_003E4__this = this;
					bool flag = (nint)obj >= enemies._size;
					items = enemies._items;
					if (enemies._items == null)
					{
						break;
					}
					ArcadeSprite arcadeSprite = items[obj];
					if ((object)items[obj] == null)
					{
						break;
					}
					Transform cachedTrans = ((ArcadeSprite)items[obj]).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
					if (arcadeSprite.body != null)
					{
						BaseBody baseBody = arcadeSprite.body;
						ArcadeTransform arcadeTransform = baseBody._transform;
						if (baseBody._transform == null)
						{
							break;
						}
						arcadeTransform.position = ret;
					}
					CS_0024_003C_003E8__locals4.enemyPos = ret;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v9 (ArcadeSprite)+260]");
					bool flag3 = (nint)0 != 0;
					float num = num2;
					if (flag3)
					{
						goto IL_04cd;
					}
					bool flag4 = arcadeSprite.body == null;
					num = num2;
					if (flag4)
					{
						goto IL_04cd;
					}
					bool canPause;
					if (obj2 == null)
					{
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hit, new SoundManager.SoundConfig
						{
							Rate = 1f,
							Volume = (float?)(object)1
						}, 500f, 8, num3);
						num4 = 8;
						canPause = false;
						obj2 = 1;
					}
					else
					{
						canPause = false;
					}
					bool flag5 = CheckHeart();
					bool flag6 = !flag5;
					float num5 = num2;
					flag7 = (byte)num4 != 0;
					if (!flag6)
					{
						Action onComplete = delegate
						{
							if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TP_SOULSTEAL_LITTLEHEART))
							{
								Vector2 pos = default(Vector2);
								Pickup pickup = PickupManager.CreatePickup(pos, ItemType.TP_SOULSTEAL_LITTLEHEART);
								pickup.GoToPlayer = true;
								TP_SoulSteal_Projectile tP_SoulSteal_Projectile = CS_0024_003C_003E8__locals4._003C_003E4__this;
								Weapon weapon2 = tP_SoulSteal_Projectile._weapon;
								pickup._targetPlayer = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
								pickup.Time = 1.6518f;
								return;
							}
							throw new NullReferenceException();
						};
						num5 = (float)obj3 * 0.001f;
						Timer timer = Timers.Register(num5, onComplete, null, isLooped: false, (byte)(int)num3 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
						flag7 = false;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v9 (ArcadeSprite)+20C]");
					if ((nint)0 != 0)
					{
						bool flag8 = 1065353216 <= 0;
						num5 = 1.0653532E+09f;
						if (!flag8)
						{
							Weapon weapon = _weapon;
							if ((object)_weapon == null)
							{
								break;
							}
							nint num6 = (nint)weapon;
							float num7 = _weapon.PPower();
							nint num8 = (nint)arcadeSprite;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v996 @ r9_v11 (Il2CppClass<ArcadeSprite>)+3E8] (should have been resolved before IL gen)");
							num9 = 1.0653532E+09f;
							num = 1.0653532E+09f;
							flag7 = (byte)num8 != 0;
							goto IL_0529;
						}
					}
					if ((object)_weapon == null)
					{
						break;
					}
					float num10 = _weapon.PPower();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v9 (ArcadeSprite)+1EC]");
					num = 0f * 0.34f;
					bool flag9 = num5 > num;
					num9 = num5;
					if (!flag9)
					{
						num9 = num;
					}
					nint num11 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1009 @ rdx_v21 (Il2CppClass<ArcadeSprite>)+3E8] (should have been resolved before IL gen)");
					goto IL_0529;
				}
				base.Despawn();
				return;
				IL_04cd:
				obj++;
				obj3 += 4;
				obj4 = obj;
				continue;
				IL_0529:
				if ((object)_soulStealWeapon == null)
				{
					break;
				}
				_soulStealWeapon.Hit(items[obj]);
				TP_SoulSteal_Weapon soulStealWeapon = _soulStealWeapon;
				if ((object)_soulStealWeapon == null)
				{
					break;
				}
				float num12 = num9 + ((Weapon)soulStealWeapon)._003CStatsInflictedDamage_003Ek__BackingField;
				((Weapon)soulStealWeapon)._003CStatsInflictedDamage_003Ek__BackingField = num12;
				num4 = (flag7 ? 1 : 0);
				goto IL_04cd;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DoSoulStealAgain(List<EnemyController> enemies)
	{
		//IL_0440: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_04c8: Expected O, but got F4
		//IL_04f7: Expected O, but got I
		//IL_03aa: Expected I, but got O
		//IL_01a0: Expected O, but got I
		//IL_0172: Expected O, but got F4
		//IL_0296: Expected F4, but got I4
		//IL_03d6: Expected I, but got O
		//IL_01d3: Expected O, but got I
		//IL_02ac: Expected I, but got O
		//IL_02f9: Expected F4, but got I4
		//IL_02fe: Expected I, but got O
		//IL_0237: Expected I4, but got F4
		//IL_032d: Expected F4, but got I4
		//IL_0332: Expected I, but got O
		//IL_0374: Expected F4, but got I4
		//IL_0379: Expected I, but got O
		//IL_040c->IL0497: Incompatible stack heights: 2 vs 0
		//IL_0390->IL0497: Incompatible stack heights: 2 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 2000f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rosary, soundConfig, 500f, 8, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = 2323.6f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Rosary, soundConfig2, 500f, 8, num);
		bool flag = false;
		bool flag2 = false;
		int num2 = 8;
		bool flag3 = false;
		float num4 = default(float);
		nint num5 = default(nint);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while ((flag3 ? 1 : 0) < enemies._size)
		{
			_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass9_0();
			CS_0024_003C_003E8__locals3._003C_003E4__this = this;
			bool flag4 = (flag2 ? 1 : 0) >= enemies._size;
			EnemyController[] items = enemies._items;
			ArcadeSprite arcadeSprite = items[flag2 ? 1u : 0u];
			Transform cachedTrans = ((ArcadeSprite)items[flag2 ? 1u : 0u]).CachedTrans;
			bool flag5 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite.body != null)
			{
				BaseBody baseBody = arcadeSprite.body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				arcadeTransform.position = (float2)ret;
			}
			CS_0024_003C_003E8__locals3.enemyPos = (float2)ret;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v7 (ArcadeSprite)+260]");
			bool flag6 = (nint)0 != 0;
			float num3 = num4;
			Action<float> action = (Action<float>)num5;
			if (!flag6)
			{
				bool flag7 = arcadeSprite.body == null;
				num3 = num4;
				action = (Action<float>)num5;
				if (!flag7)
				{
					bool flag8 = CheckHeart();
					bool flag9 = !flag8;
					num3 = num4;
					action = (Action<float>)num5;
					if (!flag9)
					{
						Action onComplete = delegate
						{
							if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TP_SOULSTEAL_LITTLEHEART))
							{
								Vector2 pos = default(Vector2);
								Pickup pickup = PickupManager.CreatePickup(pos, ItemType.TP_SOULSTEAL_LITTLEHEART);
								pickup.GoToPlayer = true;
								TP_SoulSteal_Projectile tP_SoulSteal_Projectile = CS_0024_003C_003E8__locals3._003C_003E4__this;
								Weapon weapon = tP_SoulSteal_Projectile._weapon;
								pickup._targetPlayer = ((Equipment)weapon)._003COwner_003Ek__BackingField;
								pickup.Time = 1.6518f;
								return;
							}
							throw new NullReferenceException();
						};
						num3 = (float)(flag ? 1 : 0) * 0.001f;
						Timer timer = Timers.Register(num3, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						action = null;
						num2 = 0;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v7 (ArcadeSprite)+20C]");
			if ((nint)0 != 0)
			{
				bool flag10 = 1065353216 <= 0;
				num3 = 1.0653532E+09f;
				if (!flag10)
				{
					nint num6 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v200 @ rdx_v16 (Il2CppClass<ArcadeSprite>)+3E8] (should have been resolved before IL gen)");
					_soulStealWeapon.Hit(items[flag2 ? 1u : 0u]);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v7 (ArcadeSprite)+260]");
					bool flag11 = (nint)0 != 0;
					num3 = 1.0653532E+09f;
					num5 = unchecked((nint)null);
					if (!flag11)
					{
						bool flag12 = arcadeSprite.body == null;
						num3 = 1.0653532E+09f;
						num5 = unchecked((nint)null);
						if (!flag12)
						{
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							_tryAgain = true;
							flag = (byte)((flag ? 1u : 0u) + 4u) != 0;
							num3 = 1.0653532E+09f;
							num5 = unchecked((nint)null);
							num = num;
							flag3 = flag2;
							continue;
						}
					}
					goto IL_03db;
				}
			}
			bool flag13 = _tries > 3;
			num5 = (nint)action;
			if (!flag13)
			{
				_soulStealWeapon.Hit(items[flag2 ? 1u : 0u]);
				num5 = unchecked((nint)null);
			}
			goto IL_03db;
			IL_03db:
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			flag = (byte)((flag ? 1u : 0u) + 4u) != 0;
			num = num;
			flag3 = flag2;
		}
	}

	private void CheckForDoSoulStealAgain(List<EnemyController> enemies)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.enemies = enemies;
		if (_tryAgain)
		{
			int num = _tries + 1;
			_tryAgain = false;
			_tries = num;
			if (num < 9)
			{
				DoSoulStealAgain(CS_0024_003C_003E8__locals5.enemies);
			}
		}
		Action onComplete = delegate
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this.CheckForDoSoulStealAgain(CS_0024_003C_003E8__locals5.enemies);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public bool CheckHeart()
	{
		//IL_0126: Expected I4, but got O
		if ((object)_weapon != null)
		{
			float chanceFromArray = _weapon.GetChanceFromArray();
			if ((object)_weapon != null)
			{
				float chance = _weapon.Chance;
				Weapon weapon = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PLuck();
					object obj2 = default(object);
					object obj = obj2 * obj2;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
					object obj3 = obj - obj2;
					bool flag2 = obj3 == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
