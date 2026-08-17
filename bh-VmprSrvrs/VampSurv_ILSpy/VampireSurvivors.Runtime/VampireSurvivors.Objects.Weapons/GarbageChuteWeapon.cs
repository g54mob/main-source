using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class GarbageChuteWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public GarbageChuteWeapon _003C_003E4__this;

		public GarbageChuteProjectile pojectile;

		public int chuteIndex;
	}

	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals1;

		internal void _003CstartFiringProjectile_003Eb__0()
		{
			//IL_0378: Expected O, but got I4
			//IL_0194: Expected I, but got O
			//IL_01a2: Expected I, but got O
			//IL_01b2: Expected O, but got I
			//IL_0232: Expected O, but got I4
			//IL_01ee: Expected O, but got I
			//IL_0224: Expected O, but got I4
			//IL_0084->IL0318: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL0318: Incompatible stack heights: 1 vs 0
			//IL_00d5->IL0318: Incompatible stack heights: 1 vs 0
			//IL_0110->IL0318: Incompatible stack heights: 1 vs 0
			//IL_013f->IL0318: Incompatible stack heights: 1 vs 0
			//IL_0268->IL0318: Incompatible stack heights: 1 vs 0
			//IL_02d4->IL0318: Incompatible stack heights: 1 vs 0
			//IL_02f6->IL0318: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass10_0 obj = CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass10_0 obj3;
			GameObject gameObject2;
			GameObject pojectile;
			object obj7;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						GarbageChuteWeapon garbageChuteWeapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)((Equipment)garbageChuteWeapon)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)garbageChuteWeapon)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass10_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								GarbageChuteWeapon garbageChuteWeapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									gameObject2 = (GameObject)(object)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, garbageChuteWeapon2._targetTransform);
									bool flag2 = (object)gameObject2 == null;
									pojectile = null;
									if (flag2)
									{
										goto IL_0395;
									}
									nint num = (nint)gameObject2;
									nint num2 = (nint)typeof(GarbageChuteProjectile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+130]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
									if (num3 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+C8]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v44+FFFFFFF8+v487 @ rax_v40*8]");
										if (0 == (nint)typeof(GarbageChuteProjectile))
										{
											obj7 = 1;
											goto IL_03a7;
										}
									}
									obj7 = 0;
									goto IL_03a7;
								}
							}
						}
					}
				}
			}
			goto IL_0318;
			IL_0395:
			obj3.pojectile = (GarbageChuteProjectile)(object)pojectile;
			_003C_003Ec__DisplayClass10_0 obj8 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				GameObject pojectile2 = (GameObject)(object)obj8.pojectile;
				if ((object)obj8.pojectile == null || ((UnityEngine.Object)pojectile2).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				_003C_003Ec__DisplayClass10_0 obj9 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null && (object)obj9.pojectile != null)
				{
					obj9.pojectile.CustomFire(obj9.chuteIndex);
					return;
				}
			}
			goto IL_0318;
			IL_0318:
			throw new NullReferenceException();
			IL_03a7:
			bool flag3 = obj7 == null;
			pojectile = null;
			if (!flag3)
			{
				pojectile = gameObject2;
			}
			goto IL_0395;
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public GarbageChuteWeapon _003C_003E4__this;

		public int chuteIndex;

		internal void _003CProjectileComplete_003Eb__0()
		{
			GarbageChuteWeapon garbageChuteWeapon = _003C_003E4__this;
			List<GarbageChuteMovement> garbageChutes = garbageChuteWeapon._garbageChutes;
			int num = chuteIndex;
			if (chuteIndex < garbageChutes._size)
			{
				GarbageChuteMovement[] items = garbageChutes._items;
				GarbageChuteMovement garbageChuteMovement = items[num];
				if (garbageChuteMovement.ChuteActive && garbageChuteMovement.ChuteFollowingScreen)
				{
					if (garbageChuteMovement.ChuteMoveTweens != null)
					{
						garbageChuteMovement.ChuteMoveTweens.Kill();
					}
					if (garbageChuteMovement._moveChuteTimer != null)
					{
						garbageChuteMovement._moveChuteTimer.Cancel();
					}
					if (garbageChuteMovement._projectileStartTimer != null)
					{
						garbageChuteMovement._projectileStartTimer.Cancel();
					}
					if (garbageChuteMovement._projectileEndTimer != null)
					{
						garbageChuteMovement._projectileEndTimer.Cancel();
					}
					if (garbageChuteMovement._projectileLeftScreenTimer != null)
					{
						garbageChuteMovement._projectileLeftScreenTimer.Cancel();
					}
					garbageChuteMovement.hideChute();
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private float _chuteDefaultWidth = 1f;

	private float _chuteMaxWidth = 2f;

	[NonSerialized]
	public float ChuteArea = 1f;

	[NonSerialized]
	public float ChuteWidth = 1.28f;

	[NonSerialized]
	public List<GarbageChuteMovement> _garbageChutes;

	private List<float> _projectileCount;

	private List<Timer> _projectileTimer;

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		if (_beginningArcana)
		{
			return;
		}
		GameManager core = GM.Core;
		List<WeaponType> list = core._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 > (nint)0)
		{
			GameManager core2 = GM.Core;
			List<WeaponType> list2 = core2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj == -1)
			{
				int beginningAmount = _beginningAmount + 1;
				_beginningAmount = beginningAmount;
				WeaponData currentWeaponData = _currentWeaponData;
				_beginningArcana = true;
				int num = currentWeaponData._003Camount_003Ek__BackingField + 1;
				currentWeaponData._003Camount_003Ek__BackingField = num;
			}
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0076: Expected O, but got I4
		//IL_0091: Expected I4, but got I8
		//IL_00db: Expected O, but got I4
		//IL_0156: Expected I4, but got I8
		//IL_01a0: Expected O, but got I4
		//IL_021b: Expected I4, but got I8
		//IL_03d9: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_0421: Expected F4, but got I4
		base.InitWeapon(characterController, weaponType);
		List<float> projectileCount = new List<float>();
		_projectileCount = projectileCount;
		List<Timer> projectileTimer = new List<Timer>();
		_projectileTimer = projectileTimer;
		List<GarbageChuteMovement> garbageChutes = new List<GarbageChuteMovement>();
		_garbageChutes = garbageChutes;
		int num = 0;
		Vector2 pos = default(Vector2);
		while (true)
		{
			GarbageChuteMovement garbageChuteMovement = new GarbageChuteMovement();
			garbageChuteMovement._chuteSpeed = 0.01f;
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "vfx", "chuteLeft");
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1);
			PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.65f);
			PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
			PhaserSprite phaserSprite5 = phaserSprite4.setOrigin(1f, (float?)(object)1);
			GameObject gameObject = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject).SetName("ChuteSpriteLeft");
			garbageChuteMovement.ChuteSpriteLeft = phaserSprite5;
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite6 = instance2.AddPhaserSprite(pos, "vfx", "chuteRight");
			PhaserSprite phaserSprite7 = phaserSprite6.setDepth(-1);
			PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0.65f);
			PhaserSprite phaserSprite9 = phaserSprite8.setVisible(visible: false);
			PhaserSprite phaserSprite10 = phaserSprite9.setOrigin(0f, (float?)(object)1);
			GameObject gameObject2 = phaserSprite10.gameObject;
			((UnityEngine.Object)gameObject2).SetName("ChuteSpriteRight");
			garbageChuteMovement.ChuteSpriteRight = phaserSprite10;
			PhaserWorld instance3 = PhaserWorld.Instance;
			PhaserSprite phaserSprite11 = instance3.AddPhaserSprite(pos, "vfx", "chuteBackground");
			PhaserSprite phaserSprite12 = phaserSprite11.setDepth(-1);
			PhaserSprite phaserSprite13 = phaserSprite12.setAlpha(0.65f);
			PhaserSprite phaserSprite14 = phaserSprite13.setTint(10066329u);
			PhaserSprite phaserSprite15 = phaserSprite14.setVisible(visible: false);
			GameObject gameObject3 = phaserSprite15.gameObject;
			((UnityEngine.Object)gameObject3).SetName("ChuteSprite");
			garbageChuteMovement.ChuteSprite = phaserSprite15;
			garbageChuteMovement._trueWeapon = this;
			garbageChuteMovement._chuteIndex = num;
			garbageChuteMovement.ChuteOffsetX = 0f;
			if ((object)GM.Core == null)
			{
				break;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			garbageChuteMovement.ChuteOffsetY = renderer.height;
			List<object> garbageChutes2 = (List<object>)(object)_garbageChutes;
			int version = garbageChutes2._version + 1;
			garbageChutes2._version = version;
			object[] items = garbageChutes2._items;
			if (garbageChutes2._size >= items.Length)
			{
				garbageChutes2.AddWithResize((object)garbageChuteMovement);
			}
			else
			{
				int size = garbageChutes2._size + 1;
				garbageChutes2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<float> projectileCount2 = _projectileCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v50 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v50 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v50 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v32+18]");
			if (num2 >= 0)
			{
				projectileCount2.AddWithResize(0f);
				float num3 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v50 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 0;
				float num3 = 0.65f;
			}
			List<object> projectileTimer2 = (List<object>)(object)_projectileTimer;
			int version2 = projectileTimer2._version + 1;
			projectileTimer2._version = version2;
			object[] items2 = projectileTimer2._items;
			if (projectileTimer2._size >= items2.Length)
			{
				projectileTimer2.AddWithResize((object)null);
			}
			else
			{
				int size2 = projectileTimer2._size + 1;
				projectileTimer2._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
			if (num >= 5)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		startNewChute();
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe void startFiringProjectile(int chuteIndex)
	{
		//IL_0072: Expected O, but got I
		//IL_00fc: Expected I, but got O
		//IL_010a: Expected I, but got O
		//IL_011a: Expected O, but got I
		//IL_019a: Expected O, but got I4
		//IL_0156: Expected O, but got I
		//IL_05d0: Expected O, but got I4
		//IL_01af: Expected I4, but got O
		//IL_018c: Expected O, but got I4
		//IL_0221: Expected I, but got O
		//IL_0231: Expected O, but got I
		//IL_0244: Invalid comparison between O and F4
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_0579: Invalid comparison between O and F4
		//IL_05a4: Expected F4, but got O
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_0302: Expected O, but got I4
		//IL_0310: Expected I, but got O
		//IL_0320: Expected O, but got I
		//IL_0522: Expected O, but got I4
		//IL_052a: Expected O, but got I4
		//IL_0532: Expected I4, but got O
		//IL_03a0: Expected O, but got I4
		//IL_035c: Expected O, but got I
		//IL_0637: Expected O, but got I4
		//IL_0392: Expected O, but got I4
		//IL_042b: Expected O, but got I4
		_003C_003Ec__DisplayClass10_0 obj = new _003C_003Ec__DisplayClass10_0();
		obj._003C_003E4__this = this;
		obj.chuteIndex = chuteIndex;
		List<float> projectileCount = _projectileCount;
		float num = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		Projectile projectile;
		Vector2 vector = default(Vector2);
		bool flag;
		nint num3;
		object obj5;
		int num2;
		if ((nint)chuteIndex < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			projectile = base.FireOneProjectile(vector, 0, _targetTransform);
			if ((object)projectile == null)
			{
				num2 = 0;
				flag = false;
				goto IL_05c3;
			}
			num3 = (nint)projectile;
			nint num4 = (nint)typeof(GarbageChuteProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v76+FFFFFFF8+v561 @ rax_v71*8]");
				if (0 == (nint)typeof(GarbageChuteProjectile))
				{
					obj5 = 1;
					goto IL_05d5;
				}
			}
			obj5 = 0;
			goto IL_05d5;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_05c3:
		obj.pojectile = (GarbageChuteProjectile)flag;
		GarbageChuteProjectile pojectile = obj.pojectile;
		if ((object)obj.pojectile != null && ((UnityEngine.Object)pojectile).m_CachedPtr != (IntPtr)0)
		{
			obj.pojectile.CustomFire(obj.chuteIndex);
			num2 = 0;
		}
		nint num6 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.GarbageChuteWeapon>)+410]");
		Action action = (Action)0;
		float num7 = base.PAmount();
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		Vector2 vector2 = vector;
		if (!flag2)
		{
			Projectile projectile2 = projectile;
			GarbageChuteWeapon garbageChuteWeapon = this;
			int num8 = 1;
			bool flag3 = default(bool);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag8;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj6 = num8 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				Vector2 vector3;
				bool flag4;
				object obj9;
				if ((nint)obj6 <= 0)
				{
					Vector2 playerPos = base.PlayerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if (!flag3)
					{
						vector3 = playerPos;
						flag4 = false;
						goto IL_062a;
					}
					vector3 = (Vector2)((bool*)(flag3 ? 1 : 0))->m_value;
					nint num9 = (nint)typeof(GarbageChuteProjectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r8_v15 (UnityEngine.Vector2)+130]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
					if (num10 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r8_v15 (UnityEngine.Vector2)+C8]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ rax_v58+FFFFFFF8+v955 @ rax_v53*8]");
						if (0 == (nint)typeof(GarbageChuteProjectile))
						{
							obj9 = 1;
							goto IL_063c;
						}
					}
					obj9 = 0;
					goto IL_063c;
				}
				_003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass10_1();
				CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals13.localIndex = num8;
				Action action2 = delegate
				{
					//IL_0378: Expected O, but got I4
					//IL_0194: Expected I, but got O
					//IL_01a2: Expected I, but got O
					//IL_01b2: Expected O, but got I
					//IL_0232: Expected O, but got I4
					//IL_01ee: Expected O, but got I
					//IL_0224: Expected O, but got I4
					//IL_0084->IL0318: Incompatible stack heights: 1 vs 0
					//IL_00b3->IL0318: Incompatible stack heights: 1 vs 0
					//IL_00d5->IL0318: Incompatible stack heights: 1 vs 0
					//IL_0110->IL0318: Incompatible stack heights: 1 vs 0
					//IL_013f->IL0318: Incompatible stack heights: 1 vs 0
					//IL_0268->IL0318: Incompatible stack heights: 1 vs 0
					//IL_02d4->IL0318: Incompatible stack heights: 1 vs 0
					//IL_02f6->IL0318: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass10_0 obj11 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
					_003C_003Ec__DisplayClass10_0 obj13;
					GameObject gameObject2;
					GameObject pojectile2;
					object obj17;
					if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null && (object)obj11._003C_003E4__this != null)
					{
						GameObject gameObject = obj11._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag11 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj12 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj12 == null)
							{
								return;
							}
							obj13 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
							{
								GarbageChuteWeapon garbageChuteWeapon2 = obj13._003C_003E4__this;
								if ((object)obj13._003C_003E4__this != null && (object)((Equipment)garbageChuteWeapon2)._003COwner_003Ek__BackingField != null)
								{
									float2 position2 = ((Equipment)garbageChuteWeapon2)._003COwner_003Ek__BackingField.position;
									_003C_003Ec__DisplayClass10_0 obj14 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
									{
										GarbageChuteWeapon garbageChuteWeapon3 = obj14._003C_003E4__this;
										if ((object)obj14._003C_003E4__this != null)
										{
											Vector2 pos = default(Vector2);
											gameObject2 = (GameObject)(object)obj13._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals13.localIndex, garbageChuteWeapon3._targetTransform);
											bool flag12 = (object)gameObject2 == null;
											pojectile2 = null;
											if (flag12)
											{
												goto IL_0395;
											}
											nint num14 = (nint)gameObject2;
											nint num15 = (nint)typeof(GarbageChuteProjectile);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
											object obj15 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+130]");
											nint num16 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile>)+130]");
											if (num16 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v13 (Il2CppClass<UnityEngine.GameObject>)+C8]");
												object obj16 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ rax_v44+FFFFFFF8+v487 @ rax_v40*8]");
												if (0 == (nint)typeof(GarbageChuteProjectile))
												{
													obj17 = 1;
													goto IL_03a7;
												}
											}
											obj17 = 0;
											goto IL_03a7;
										}
									}
								}
							}
						}
					}
					goto IL_0318;
					IL_0395:
					obj13.pojectile = (GarbageChuteProjectile)(object)pojectile2;
					_003C_003Ec__DisplayClass10_0 obj18 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null)
					{
						GameObject pojectile3 = (GameObject)(object)obj18.pojectile;
						if ((object)obj18.pojectile == null || ((UnityEngine.Object)pojectile3).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						_003C_003Ec__DisplayClass10_0 obj19 = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 != null && (object)obj19.pojectile != null)
						{
							obj19.pojectile.CustomFire(obj19.chuteIndex);
							return;
						}
					}
					goto IL_0318;
					IL_0318:
					throw new NullReferenceException();
					IL_03a7:
					bool flag13 = obj17 == null;
					pojectile2 = null;
					if (!flag13)
					{
						pojectile2 = gameObject2;
					}
					goto IL_0395;
				};
				float duration = (float)obj6 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				garbageChuteWeapon = (GarbageChuteWeapon)(this + 168);
				_lastShotTimer = lastShotTimer;
				bool flag5 = false;
				action = action2;
				Action<float> action3 = null;
				goto IL_04fe;
				IL_062a:
				obj.pojectile = (GarbageChuteProjectile)flag4;
				bool flag6 = obj.pojectile;
				bool flag7 = !flag6;
				flag5 = flag3;
				action = null;
				action3 = (Action<float>)vector3;
				garbageChuteWeapon = (GarbageChuteWeapon)(object)obj.pojectile;
				if (!flag7)
				{
					obj.pojectile.CustomFire(obj.chuteIndex);
					flag5 = flag3;
					action = (Action)obj.chuteIndex;
					action3 = null;
					garbageChuteWeapon = (GarbageChuteWeapon)(object)obj.pojectile;
				}
				goto IL_04fe;
				IL_04fe:
				num8++;
				flag8 = (nint)vector > num8;
				vector2 = (Vector2)num8;
				projectile2 = (Projectile)flag5;
				num2 = (int)action3;
				continue;
				IL_063c:
				bool flag9 = obj9 == null;
				flag4 = false;
				if (!flag9)
				{
					flag4 = flag3;
				}
				goto IL_062a;
			}
			while (flag8);
		}
		float num11 = base.PInterval();
		float num12 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj10 = num12 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num13 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		return;
		IL_05d5:
		bool flag10 = obj5 == null;
		num2 = (int)num3;
		flag = false;
		if (!flag10)
		{
			num2 = (int)num3;
			flag = (byte)(int)projectile != 0;
		}
		goto IL_05c3;
	}

	private void startNewChute()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_008a: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		float num = base.PArea();
		object obj = default(object);
		float num2 = (float)obj * _chuteDefaultWidth;
		if (!(num2 > _chuteMaxWidth))
		{
			object obj2 = _chuteMaxWidth & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_01bf;
			}
		}
		num2 = _chuteMaxWidth;
		goto IL_01bf;
		IL_01bf:
		float chuteArea = num2 * 0.5f;
		ChuteArea = chuteArea;
		List<GarbageChuteMovement> garbageChutes = _garbageChutes;
		List<GarbageChuteMovement> garbageChutes2 = _garbageChutes;
		object obj3 = 0;
		object obj4 = 0;
		while (true)
		{
			if ((nint)obj4 >= garbageChutes._size)
			{
				return;
			}
			if ((nint)obj3 >= garbageChutes2._size)
			{
				break;
			}
			GarbageChuteMovement[] items = garbageChutes2._items;
			GarbageChuteMovement garbageChuteMovement = items[obj3];
			if (garbageChuteMovement.ChuteActive)
			{
				obj3++;
				obj4 = obj3;
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			_ = 1;
			if ((nint)obj3 != -1)
			{
				List<GarbageChuteMovement> garbageChutes3 = _garbageChutes;
				if ((nint)obj3 >= garbageChutes3._size)
				{
					break;
				}
				GarbageChuteMovement[] items2 = garbageChutes3._items;
				items2[obj3].startChute();
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private int freeChuteIndex()
	{
		//IL_00c9: Expected I4, but got I8
		List<GarbageChuteMovement> garbageChutes = _garbageChutes;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < garbageChutes._size)
			{
				if (num >= garbageChutes._size)
				{
					break;
				}
				GarbageChuteMovement[] items = garbageChutes._items;
				GarbageChuteMovement garbageChuteMovement = items[num];
				if (garbageChuteMovement.ChuteActive)
				{
					num++;
					num2 = num;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				_ = 1;
				return num;
			}
			return -1;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	public void ProjectileComplete(int chuteIndex)
	{
		//IL_0067: Expected O, but got I
		//IL_00f4: Expected O, but got I
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		CS_0024_003C_003E8__locals10.chuteIndex = chuteIndex;
		List<float> projectileCount = _projectileCount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)chuteIndex < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v5+20+chuteIndex @ rdx (System.Int32)*4]");
			float num = 0f - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			List<float> projectileCount2 = _projectileCount;
			int chuteIndex2 = CS_0024_003C_003E8__locals10.chuteIndex;
			int chuteIndex3 = CS_0024_003C_003E8__locals10.chuteIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)chuteIndex3 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v9+20+v108 @ rax_v10 (System.Int32)*4]");
				if ((nint)0 < (nint)0)
				{
					return;
				}
				List<GarbageChuteMovement> garbageChutes = _garbageChutes;
				int chuteIndex4 = CS_0024_003C_003E8__locals10.chuteIndex;
				if (CS_0024_003C_003E8__locals10.chuteIndex < garbageChutes._size)
				{
					GarbageChuteMovement[] items = garbageChutes._items;
					if (items[chuteIndex4] == null)
					{
						return;
					}
					List<Timer> projectileTimer = _projectileTimer;
					Action onComplete = delegate
					{
						GarbageChuteWeapon garbageChuteWeapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
						List<GarbageChuteMovement> garbageChutes2 = garbageChuteWeapon._garbageChutes;
						int chuteIndex5 = CS_0024_003C_003E8__locals10.chuteIndex;
						if (CS_0024_003C_003E8__locals10.chuteIndex < garbageChutes2._size)
						{
							GarbageChuteMovement[] items2 = garbageChutes2._items;
							GarbageChuteMovement garbageChuteMovement = items2[chuteIndex5];
							if (garbageChuteMovement.ChuteActive && garbageChuteMovement.ChuteFollowingScreen)
							{
								if (garbageChuteMovement.ChuteMoveTweens != null)
								{
									garbageChuteMovement.ChuteMoveTweens.Kill();
								}
								if (garbageChuteMovement._moveChuteTimer != null)
								{
									garbageChuteMovement._moveChuteTimer.Cancel();
								}
								if (garbageChuteMovement._projectileStartTimer != null)
								{
									garbageChuteMovement._projectileStartTimer.Cancel();
								}
								if (garbageChuteMovement._projectileEndTimer != null)
								{
									garbageChuteMovement._projectileEndTimer.Cancel();
								}
								if (garbageChuteMovement._projectileLeftScreenTimer != null)
								{
									garbageChuteMovement._projectileLeftScreenTimer.Cancel();
								}
								garbageChuteMovement.hideChute();
							}
						}
						else
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
					};
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					if (CS_0024_003C_003E8__locals10.chuteIndex < projectileTimer._size)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						int version = projectileTimer._version + 1;
						projectileTimer._version = version;
						return;
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void LateUpdate()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		List<GarbageChuteMovement> garbageChutes = _garbageChutes;
		object obj = 0;
		object obj2 = 0;
		IntPtr intPtr2 = default(IntPtr);
		while (true)
		{
			if ((nint)obj2 < garbageChutes._size)
			{
				List<GarbageChuteMovement> garbageChutes2 = _garbageChutes;
				if ((nint)obj >= garbageChutes2._size)
				{
					break;
				}
				GarbageChuteMovement[] items = garbageChutes2._items;
				GarbageChuteMovement garbageChuteMovement = items[obj];
				IntPtr intPtr3;
				if (!garbageChuteMovement.ChuteFollowingScreen)
				{
					Camera main = Camera.main;
					Transform transform = main.transform;
					float num = transform.position.y + garbageChuteMovement.ChuteOffsetY;
					object obj3 = 0;
					IntPtr intPtr = intPtr2;
				}
				else
				{
					float2 position = garbageChuteMovement.ChuteSprite.position;
					Camera main2 = Camera.main;
					Transform transform2 = main2.transform;
					float num = transform2.position.y + garbageChuteMovement.ChuteOffsetY;
					intPtr3 = intPtr2;
					object obj3 = 0;
					IntPtr intPtr = intPtr2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				float2 position2 = garbageChuteMovement.ChuteSprite.position;
				float2 position3 = garbageChuteMovement.ChuteSprite.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				float2 position4 = garbageChuteMovement.ChuteSprite.position;
				float2 position5 = garbageChuteMovement.ChuteSprite.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				garbageChutes = _garbageChutes;
				obj++;
				intPtr3 = intPtr2;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe override void Cleanup()
	{
		//IL_036e: Expected O, but got Ref
		//IL_0014: Expected O, but got I4
		//IL_001c: Expected O, but got Ref
		//IL_02bd: Expected I4, but got O
		//IL_02bd: Expected O, but got I
		base.Cleanup();
		bool flag = _garbageChutes == null;
		Weapon weapon = this;
		if (!flag)
		{
			List<GarbageChuteMovement>.Enumerator enumerator = default(List<GarbageChuteMovement>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				PhaserSprite phaserSprite = (PhaserSprite)(&enumerator);
				throw new NullReferenceException();
			}
			bool flag2 = _projectileTimer == null;
			weapon = (Weapon)(&enumerator);
			if (!flag2)
			{
				List<Timer>.Enumerator enumerator2 = default(List<Timer>.Enumerator);
				while (enumerator2.MoveNext())
				{
				}
				weapon = (Weapon)(object)_garbageChutes;
				if (_garbageChutes != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v7 (VampireSurvivors.Objects.Weapons.Weapon)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)weapon).m_CancellationTokenSource = null;
					if ((nint)((MonoBehaviour)weapon).m_CancellationTokenSource > 0)
					{
						Array.Clear((Array)(nint)((UnityEngine.Object)weapon).m_CachedPtr, 0, (int)((MonoBehaviour)weapon).m_CancellationTokenSource);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
