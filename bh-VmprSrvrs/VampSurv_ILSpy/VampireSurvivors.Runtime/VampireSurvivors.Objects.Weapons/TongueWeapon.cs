using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TongueWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public EnemyController chosenEnemy;

		public int index;

		public TongueWeapon _003C_003E4__this;

		internal void _003CTryFiring_003Eb__0()
		{
			//IL_014e: Expected I4, but got O
			//IL_015c: Expected I, but got O
			//IL_016c: Expected O, but got I
			//IL_01ec: Expected O, but got I4
			//IL_01a8: Expected O, but got I
			//IL_01de: Expected O, but got I4
			TongueWeapon tongueWeapon = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)tongueWeapon)._003COwner_003Ek__BackingField;
			if (characterController._isDead || characterController.IsDisconnectedFromOnlinePlay)
			{
				return;
			}
			EnemyController enemyController = chosenEnemy;
			if (enemyController._003CIsDead_003Ek__BackingField)
			{
				return;
			}
			TongueWeapon tongueWeapon2 = _003C_003E4__this;
			float2 position = ((Equipment)tongueWeapon2)._003COwner_003Ek__BackingField.position;
			TongueWeapon tongueWeapon3 = _003C_003E4__this;
			float2 position2 = ((Equipment)tongueWeapon3)._003COwner_003Ek__BackingField.position;
			ArcadeSprite arcadeSprite = chosenEnemy;
			((ArcadeSprite)chosenEnemy).CheckRenderer();
			Transform transform = arcadeSprite._spriteRenderer.transform;
			Vector2 pos = default(Vector2);
			Projectile projectile = tongueWeapon2.FireOneProjectile(pos, index, transform);
			bool flag = (object)projectile == null;
			int num = index;
			Projectile projectile2 = null;
			object obj3;
			if (!flag)
			{
				num = (int)projectile;
				nint num2 = (nint)typeof(TongueProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TongueProjectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ r8_v3 (System.Int32)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TongueProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ r8_v3 (System.Int32)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rax_v28+FFFFFFF8+v349 @ rax_v24*8]");
					if (0 == (nint)typeof(TongueProjectile))
					{
						obj3 = 1;
						goto IL_0253;
					}
				}
				obj3 = 0;
				goto IL_0253;
			}
			goto IL_027a;
			IL_0253:
			bool flag2 = obj3 == null;
			projectile2 = null;
			if (!flag2)
			{
				projectile2 = projectile;
			}
			goto IL_027a;
			IL_027a:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B0BE40");
			}
		}
	}

	public float distanceMultiplier = 1f;

	private float _baseRange = 1f;

	protected Weapon _counterWeapon;

	private bool _readyToFire;

	private List<EnemyController> aimCache;

	public virtual float forwardFacing => 1f;

	protected virtual WeaponType _counterWeaponType => WeaponType.C1_TONGUE1_COUNTER;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num = renderer.width * 0.25f;
		float num2 = renderer2.height * 0.25f;
		if (num > num2)
		{
			num = num2;
		}
		_baseRange = num;
	}

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PRegen();
			float num3 = default(float);
			float num2 = num3 + 1f;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num3;
					return num3 + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual bool CanLickBackwards()
	{
		return false;
	}

	private List<EnemyController> ChooseEnemiesInRange(float2 position, float radius, bool facingLeft)
	{
		//IL_0027: Expected F4, but got O
		//IL_0103: Expected O, but got I4
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_0346: Expected O, but got I4
		//IL_02b4: Invalid comparison between F4 and I4
		//IL_02c3: Invalid comparison between F4 and I4
		bool flag = CanLickBackwards();
		float y = default(float);
		bool includeDynamic = default(bool);
		bool includeStatic = default(bool);
		Group specificGroup = default(Group);
		List<BaseBody> list = ArcadePhysics.s_instance.OverlapCirc((float)position, y, radius, includeDynamic, includeStatic, specificGroup);
		List<EnemyController> list2 = aimCache;
		int version = list2._version + 1;
		list2._version = version;
		list2._size = 0;
		if (list2._size > 0)
		{
			Array.Clear(list2._items, 0, list2._size);
		}
		float num = forwardFacing;
		bool flag2 = !facingLeft;
		float num3 = default(float);
		float num2 = num3;
		if (!flag2)
		{
			num2 = num3 * -1f;
		}
		bool flag3 = (nint)list < 0;
		object obj = list._size - 1;
		if (!flag3)
		{
			float2 float5 = position;
			List<EnemyController> result = default(List<EnemyController>);
			object obj3;
			do
			{
				bool flag5;
				if ((nint)obj < list._size)
				{
					BaseBody[] items = list._items;
					BaseBody baseBody = items[obj];
					bool flag4 = items[obj] == null;
					Component component = (Component)(object)items[obj];
					if (!flag4)
					{
						component = baseBody._gameObject;
					}
					ArcadeSprite arcadeSprite;
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						EnemyController component2 = component.GetComponent<EnemyController>();
						arcadeSprite = component2;
					}
					else
					{
						arcadeSprite = null;
					}
					flag5 = (nint)arcadeSprite < 0;
					if ((object)arcadeSprite != null)
					{
						flag5 = (nint)((UnityEngine.Object)arcadeSprite).m_CachedPtr < 0;
						if (((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rbx_v10 (ArcadeSprite)+260]");
							flag5 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rbx_v10 (ArcadeSprite)+260]");
							if ((nint)0 == 0)
							{
								float num4 = num3;
								float2 float6 = float5;
								if (!flag)
								{
									float2 cachedPosition = arcadeSprite.cachedPosition;
									object obj2 = cachedPosition - position;
									num4 = (float)obj2 * num2;
									flag5 = num4 < 0f;
									bool flag6 = !(num4 > 0f);
									float6 = cachedPosition;
									num3 = num4;
									float5 = cachedPosition;
									if (flag6)
									{
										goto IL_032d;
									}
								}
								flag5 = (nint)aimCache < 0;
								EnemyController component3 = ((Component)(object)aimCache).GetComponent<EnemyController>();
								num3 = num4;
								float5 = float6;
							}
						}
					}
					goto IL_032d;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
				IL_032d:
				obj--;
				obj3 = !flag5;
			}
			while (obj3 != null);
		}
		Extensions.Shuffle((IList<object>)aimCache);
		return aimCache;
	}

	public override void Fire(bool skipTriggers = false)
	{
		_readyToFire = true;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (_readyToFire)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (!characterController._isDead && !characterController.IsDisconnectedFromOnlinePlay)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 60 Invalid \"Jump target not found in method: 0x1873DB600\"");
			}
		}
	}

	private unsafe void TryFiring()
	{
		//IL_0094: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0252: Invalid comparison between F4 and I4
		//IL_0300: Expected O, but got I4
		//IL_030e: Expected I, but got O
		//IL_031e: Expected O, but got I
		//IL_039e: Expected O, but got I4
		//IL_02e5: Expected O, but got F4
		//IL_035a: Expected O, but got I
		//IL_0390: Expected O, but got I4
		float num = base.PArea();
		float num2 = base.PSpeed();
		float num3 = distanceMultiplier * _baseRange;
		object obj = default(object);
		float num4 = num3 * (float)obj;
		float num5 = (float)obj * num4;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		List<EnemyController> list = ChooseEnemiesInRange(position, num5, flipX);
		if (list._size <= 0)
		{
			return;
		}
		float num6 = num5 * num5;
		object obj2 = 0;
		object obj3 = 0;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj9 = default(object);
		bool flag = default(bool);
		float num13 = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			if ((nint)obj3 >= list._size)
			{
				return;
			}
			if ((nint)obj2 >= list._size)
			{
				break;
			}
			EnemyController[] items = list._items;
			float2 position2 = items[obj2].position;
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj4 = position3 - position2;
			object obj5 = obj6 - obj7;
			object obj8 = obj4 * obj4;
			float num7 = (float)obj5 * (float)obj5;
			float num8 = (float)obj8 + num7;
			if (num6 < num8)
			{
				obj2++;
				obj3 = obj2;
				continue;
			}
			float num9 = base.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r12d,xmm0\"");
			if ((nint)obj9 > 0)
			{
				int num10 = 0;
				while (true)
				{
					_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass15_0();
					CS_0024_003C_003E8__locals14._003C_003E4__this = this;
					CS_0024_003C_003E8__locals14.index = num10;
					WeaponData currentWeaponData = _currentWeaponData;
					int num11 = num10 % list._size;
					if (num11 >= list._size)
					{
						break;
					}
					EnemyController[] items2 = list._items;
					CS_0024_003C_003E8__locals14.chosenEnemy = items2[num11];
					float num12 = (float)num10 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					bool flag2;
					object obj12;
					if (!(num12 > 0f))
					{
						float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						ArcadeSprite chosenEnemy = CS_0024_003C_003E8__locals14.chosenEnemy;
						((ArcadeSprite)CS_0024_003C_003E8__locals14.chosenEnemy).CheckRenderer();
						Transform transform = chosenEnemy._spriteRenderer.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						Action<float> action;
						if (!flag)
						{
							action = (Action<float>)num13;
							flag2 = false;
							goto IL_058b;
						}
						action = (Action<float>)((bool*)(flag ? 1 : 0))->m_value;
						nint num14 = (nint)typeof(TongueProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TongueProjectile>)+130]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ r8_v14 (System.Action`1<System.Single>)+130]");
						nint num15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TongueProjectile>)+130]");
						if (num15 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v967 @ r8_v14 (System.Action`1<System.Single>)+C8]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rax_v62+FFFFFFF8+v1043 @ rax_v58*8]");
							if (0 == (nint)typeof(TongueProjectile))
							{
								obj12 = 1;
								goto IL_0560;
							}
						}
						obj12 = 0;
						goto IL_0560;
					}
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_014e: Expected I4, but got O
						//IL_015c: Expected I, but got O
						//IL_016c: Expected O, but got I
						//IL_01ec: Expected O, but got I4
						//IL_01a8: Expected O, but got I
						//IL_01de: Expected O, but got I4
						TongueWeapon tongueWeapon = CS_0024_003C_003E8__locals14._003C_003E4__this;
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)tongueWeapon)._003COwner_003Ek__BackingField;
						if (characterController._isDead || characterController.IsDisconnectedFromOnlinePlay)
						{
							return;
						}
						EnemyController chosenEnemy2 = CS_0024_003C_003E8__locals14.chosenEnemy;
						if (chosenEnemy2._003CIsDead_003Ek__BackingField)
						{
							return;
						}
						TongueWeapon tongueWeapon2 = CS_0024_003C_003E8__locals14._003C_003E4__this;
						float2 position6 = ((Equipment)tongueWeapon2)._003COwner_003Ek__BackingField.position;
						TongueWeapon tongueWeapon3 = CS_0024_003C_003E8__locals14._003C_003E4__this;
						float2 position7 = ((Equipment)tongueWeapon3)._003COwner_003Ek__BackingField.position;
						ArcadeSprite chosenEnemy3 = CS_0024_003C_003E8__locals14.chosenEnemy;
						((ArcadeSprite)CS_0024_003C_003E8__locals14.chosenEnemy).CheckRenderer();
						Transform target = chosenEnemy3._spriteRenderer.transform;
						Vector2 pos = default(Vector2);
						Projectile projectile = tongueWeapon2.FireOneProjectile(pos, CS_0024_003C_003E8__locals14.index, target);
						bool flag4 = (object)projectile == null;
						int index = CS_0024_003C_003E8__locals14.index;
						Projectile projectile2 = null;
						object obj15;
						if (!flag4)
						{
							index = (int)projectile;
							nint num17 = (nint)typeof(TongueProjectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TongueProjectile>)+130]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ r8_v3 (System.Int32)+130]");
							nint num18 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TongueProjectile>)+130]");
							if (num18 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ r8_v3 (System.Int32)+C8]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rax_v28+FFFFFFF8+v349 @ rax_v24*8]");
								if (0 == (nint)typeof(TongueProjectile))
								{
									obj15 = 1;
									goto IL_0253;
								}
							}
							obj15 = 0;
							goto IL_0253;
						}
						goto IL_027a;
						IL_0253:
						bool flag5 = obj15 == null;
						projectile2 = null;
						if (!flag5)
						{
							projectile2 = projectile;
						}
						goto IL_027a;
						IL_027a:
						if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B0BE40");
						}
					};
					float num16 = (float)CS_0024_003C_003E8__locals14.index * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num16 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					goto IL_0489;
					IL_0560:
					bool flag3 = obj12 == null;
					flag2 = false;
					if (!flag3)
					{
						flag2 = flag;
					}
					goto IL_058b;
					IL_058b:
					if (flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rbx_v13 (System.Boolean)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B0BE40");
						}
					}
					goto IL_0489;
					IL_0489:
					num10++;
					if (num10 < (nint)obj9)
					{
						continue;
					}
					goto IL_04b3;
				}
				break;
			}
			goto IL_04b3;
			IL_04b3:
			_readyToFire = false;
			base.ResetFiringTimer();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected virtual bool SupportCounterWeapon()
	{
		return true;
	}

	public override void CheckArcanas()
	{
		//IL_0161: Expected I, but got O
		//IL_016f: Expected I, but got O
		//IL_017f: Expected O, but got I
		//IL_01ff: Expected O, but got I4
		//IL_01bb: Expected O, but got I
		//IL_01f1: Expected O, but got I4
		//IL_027e: Expected I, but got O
		Weapon weapon;
		UnityEngine.Object obj2;
		object obj5;
		if (SupportCounterWeapon())
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj > -1 && _counterWeaponType != WeaponType.VOID)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				WeaponType counterWeaponType = _counterWeaponType;
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(counterWeaponType, searchHidden: true);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					return;
				}
				GameManager core2 = GM.Core;
				WeaponType counterWeaponType2 = _counterWeaponType;
				bool allowDuplicates = default(bool);
				weapon = core2._weaponsFacade.AddHiddenWeapon(counterWeaponType2, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
				bool flag = (object)weapon == null;
				obj2 = null;
				if (!flag)
				{
					nint num = (nint)weapon;
					nint num2 = (nint)typeof(TongueWeapon_Counter);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon_Counter>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.TongueWeapon_Counter>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v43+FFFFFFF8+v479 @ rax_v39*8]");
						if (0 == (nint)typeof(TongueWeapon_Counter))
						{
							obj5 = 1;
							goto IL_02f2;
						}
					}
					obj5 = 0;
					goto IL_02f2;
				}
				goto IL_0211;
			}
		}
		goto IL_029c;
		IL_02f2:
		bool flag2 = obj5 == null;
		obj2 = null;
		if (!flag2)
		{
			obj2 = weapon;
		}
		goto IL_0211;
		IL_029c:
		CheckBeginningArcana();
		return;
		IL_0211:
		if ((bool)obj2)
		{
			_counterWeapon = (Weapon)obj2;
			Weapon counterWeapon = _counterWeapon;
			while (((Equipment)counterWeapon)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				nint num4 = (nint)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v583 @ rax_v36 (Il2CppClass<UnityEngine.Object>)+3C8] (should have been resolved before IL gen)");
				counterWeapon = _counterWeapon;
			}
		}
		goto IL_029c;
	}

	public override bool LevelUp()
	{
		//IL_009b: Expected I4, but got O
		bool flag = LevelUp(skipFire: false);
		if (!flag)
		{
			return flag;
		}
		if (SupportCounterWeapon() && (bool)_counterWeapon)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag2 = _counterWeapon.LevelUp();
		}
		return flag;
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		_isVisible = visible;
		if (visible)
		{
			return;
		}
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TongueWeapon()
	{
		List<EnemyController> list = new List<EnemyController>();
		aimCache = list;
		base._002Ector();
	}
}
