using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class PentagramProjectile : Projectile
{
	private Transform _playerCachedTransform;

	private ShatterVFX _shatterVfx;

	private MultiTargetTween[] _tweens;

	private float _globalScale;

	private bool _eraseItems;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0030: Expected I, but got O
		//IL_0038: Expected I, but got O
		//IL_0048: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_00c1: Expected O, but got I
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0135: Expected O, but got I8
		//IL_01e2: Expected O, but got I4
		//IL_0219: Expected O, but got I8
		//IL_0276: Expected O, but got I4
		//IL_02ed: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon2 = _weapon;
		nint num = (nint)typeof(PentagramWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v14+FFFFFFF8+v84 @ rax_v13*8]");
			if (0 == (nint)typeof(PentagramWeapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v14+FFFFFFF8+v231 @ rcx_v11*8]");
				object obj4 = 0 - typeof(PentagramWeapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				Weapon weapon3 = null;
				if (!flag2)
				{
					weapon3 = weapon2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v13 (VampireSurvivors.Objects.Weapons.Weapon)+18A]");
				_eraseItems = false;
				Transform playerCachedTransform = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
				object obj5 = 6442450944L;
				_playerCachedTransform = playerCachedTransform;
				float num4 = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Extents * 2f;
				Vector3 center = CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v21 (UnityEngine.Bounds)+10]");
				float num5 = 0f * 2f;
				if (!(num5 > num4))
				{
					num4 = num5;
				}
				float num6 = num4 * 100f;
				Weapon weapon4 = _weapon;
				bool eraseItems = _eraseItems;
				float num7 = num6 * 0.8f;
				float globalScale = num7 * 0.00390625f;
				_globalScale = globalScale;
				object obj6 = ((Equipment)weapon4)._003CLevel_003Ek__BackingField - 1;
				if ((nint)obj6 <= 7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ r14_v4+72C22AC+v607 @ rax_v24*4]");
					object obj7 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v541 @ rcx_v37 (should have been resolved before IL gen)");
				}
				Sprite sprite = PentagramManager.GetSprite(PentagramType.Lvl1Good);
				_renderer.sprite = sprite;
				Transform transform = _renderer.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v28 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v28 (UnityEngine.Transform)+10]");
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				InitShatterVfx();
				Shatter();
				float num8 = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.PentagramSFX, new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 2f
				}, 0f, 10, num8);
				Action onComplete = delegate
				{
					//IL_0013: Expected I, but got O
					//IL_001b: Expected I, but got O
					//IL_002b: Expected O, but got I
					//IL_0067: Expected O, but got I
					//IL_00a4: Expected O, but got I
					//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
					//IL_00bf: Expected O, but got Unknown
					EraseEnemies(_eraseItems);
					Weapon weapon5 = _weapon;
					nint num9 = (nint)typeof(PentagramWeapon);
					nint num10 = (nint)weapon5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
					if (num11 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v6+FFFFFFF8+v46 @ rax_v5*8]");
						if (0 == (nint)typeof(PentagramWeapon))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v6+FFFFFFF8+v89 @ rcx_v5*8]");
							object obj11 = 0 - typeof(PentagramWeapon);
							bool flag4 = obj11 == null;
							bool flag5 = !flag4;
							Weapon weapon6 = null;
							if (!flag5)
							{
								weapon6 = weapon5;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (VampireSurvivors.Objects.Weapons.Weapon)+18A]");
							if ((nint)0 != 0)
							{
								EraseItems();
							}
							return;
						}
					}
					throw new NullReferenceException();
				};
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num8 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected void EraseEnemies(bool erase = false)
	{
		//IL_0050: Expected O, but got I4
		//IL_0066: Expected F4, but got I4
		//IL_0074: Expected O, but got I4
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		List<EnemyController> allEnemiesInScreenBounds = gameMan._stage.GetAllEnemiesInScreenBounds(0f);
		object obj = 0;
		List<EnemyController> list = allEnemiesInScreenBounds;
		float num = 0f;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<EnemyController>.Enumerator enumerator2 = (List<EnemyController>.Enumerator)0;
			throw new NullReferenceException();
		}
	}

	protected unsafe void EraseItems()
	{
		//IL_003c: Expected O, but got I4
		//IL_0044: Expected O, but got Ref
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_0239: Expected O, but got I4
		//IL_02f9: Expected O, but got I4
		//IL_0302: Expected O, but got I4
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		List<Pickup> allPickupsInScreenBounds = gameMan._stage.GetAllPickupsInScreenBounds();
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Weapon weapon2 = _weapon;
		GameManager gameMan2 = weapon2._gameMan;
		List<Pickup> allGemsInScreenBounds = gameMan2._stage.GetAllGemsInScreenBounds();
		List<Pickup>.Enumerator enumerator3 = default(List<Pickup>.Enumerator);
		if (enumerator3.MoveNext())
		{
			List<Pickup>.Enumerator enumerator4 = (List<Pickup>.Enumerator)0;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)0;
			throw new NullReferenceException();
		}
		Weapon weapon3 = _weapon;
		GameManager gameMan3 = weapon3._gameMan;
		List<Pickup> allFrozenSoulsInScreenBounds = gameMan3._stage.GetAllFrozenSoulsInScreenBounds();
		List<Pickup>.Enumerator enumerator5 = default(List<Pickup>.Enumerator);
		if (enumerator5.MoveNext())
		{
			List<Pickup>.Enumerator enumerator6 = (List<Pickup>.Enumerator)0;
			List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)0;
			throw new NullReferenceException();
		}
		if (GM.Core.IsStageHost)
		{
			Weapon weapon4 = _weapon;
			GameManager gameMan4 = weapon4._gameMan;
			List<Destructible> allDestructiblesInScreenBounds = gameMan4._stage.GetAllDestructiblesInScreenBounds();
			List<Destructible>.Enumerator enumerator7 = default(List<Destructible>.Enumerator);
			if (enumerator7.MoveNext())
			{
				List<Pickup>.Enumerator enumerator8 = (List<Pickup>.Enumerator)0;
				List<Pickup>.Enumerator enumerator2 = (List<Pickup>.Enumerator)0;
				throw new NullReferenceException();
			}
		}
	}

	public override void InternalUpdate()
	{
		//IL_0027: Expected I, but got O
		//IL_002f: Expected I, but got O
		//IL_003f: Expected O, but got I
		//IL_0077: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0213: Expected O, but got I
		//IL_026a: Expected O, but got I4
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected I4, but got Unknown
		Transform playerCachedTransform = _playerCachedTransform;
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)playerCachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)playerCachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		Weapon weapon = _weapon;
		bool flag4 = (object)_weapon == null;
		nint num = (nint)typeof(PentagramWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		bool flag5 = num3 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v31+FFFFFFF8+v257 @ rax_v30*8]");
		bool flag6 = 0 != (nint)typeof(PentagramWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v31+FFFFFFF8+v524 @ rcx_v25*8]");
		object obj4 = 0 - typeof(PentagramWeapon);
		bool flag7 = obj4 == null;
		bool flag8 = !flag7;
		Weapon weapon2 = null;
		if (!flag8)
		{
			weapon2 = _weapon;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v27 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v27 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
		bool flag9 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rbx_v9 (System.Object)+10]");
		bool flag10 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rbx_v9 (System.Object)+10]");
		object obj6 = Renderer.get_sortingOrder_Injected((IntPtr)0);
		bool flag11 = (object)_renderer == null;
		int sortingOrder = obj6 + 30;
		_renderer.sortingOrder = sortingOrder;
	}

	private void Shatter()
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_0106: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0328: Expected I, but got O
		//IL_0376: Expected I, but got O
		//IL_038c: Expected O, but got I
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		//IL_0410: Expected I, but got O
		//IL_05ee: Expected O, but got I4
		//IL_0605: Expected I, but got I8
		//IL_03ec: Expected I, but got I8
		//IL_018c: Expected I, but got O
		//IL_021f: Expected I, but got O
		//IL_0274: Expected O, but got I4
		//IL_04ef: Expected O, but got F4
		//IL_051d: Expected O, but got I4
		//IL_066a: Expected O, but got F4
		//IL_06b8: Expected O, but got I4
		//IL_052b: Expected O, but got F4
		//IL_05bf: Expected O, but got I4
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_02ca: Expected I, but got O
		//IL_04e1->IL0434: Incompatible stack heights: 1 vs 0
		//IL_023d->IL023d: Incompatible stack heights: 2 vs 1
		//IL_02a0->IL0434: Incompatible stack heights: 1 vs 0
		//IL_031e->IL05c4: Incompatible stack heights: 1 vs 0
		//IL_02ed->IL02ed: Incompatible stack heights: 2 vs 1
		if ((object)_shatterVfx != null)
		{
			SpriteRenderer[] array = _shatterVfx.Shatter();
			MultiTargetTween[] tweens = _tweens;
			bool flag = _tweens == null;
			SpriteRenderer spriteRenderer = null;
			SpriteRenderer spriteRenderer2 = null;
			if (!flag)
			{
				while ((nint)spriteRenderer2 < tweens.Length)
				{
					if (tweens[(object)spriteRenderer] != null)
					{
						tweens[(object)spriteRenderer].Kill();
					}
					spriteRenderer = (SpriteRenderer)(spriteRenderer + 1);
					spriteRenderer2 = spriteRenderer;
				}
				if (array != null)
				{
					MultiTargetTween[] tweens2 = new MultiTargetTween[array.Length];
					_tweens = tweens2;
					object obj = 0;
					object obj2 = 0;
					object obj3 = default(object);
					float num3 = default(float);
					object obj7 = default(object);
					while (true)
					{
						if ((nint)obj2 < array.Length)
						{
							MultiTargetTween[] tweens3 = _tweens;
							TweenConfig tweenConfig = new TweenConfig();
							object[] array2 = new object[2];
							if (array2 == null)
							{
								break;
							}
							if ((object)array[obj] != null)
							{
								nint num = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								if (obj3 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							array2[0] = array[obj];
							SpriteRenderer spriteRenderer3 = array[obj];
							if ((object)array[obj] == null)
							{
								break;
							}
							bool flag2 = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer3).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							if ((object)transform != null)
							{
								Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform);
								bool flag3 = (object)transform2 == null;
							}
							array2[1] = transform;
							if (tweenConfig == null)
							{
								break;
							}
							tweenConfig.targets = array2;
							tweenConfig.alpha = (float?)(object)1;
							object obj4 = UnityEngine.Random.value;
							float num2 = num3 * 180f;
							float num4 = num2 - 90f;
							tweenConfig.angle = (float?)(object)1;
							object obj5 = UnityEngine.Random.value;
							float num5 = num4 - 0.5f;
							float num6 = num5 * 1.2f;
							float num7 = num6 * _globalScale;
							float num8 = num7 + num7;
							tweenConfig.localX = (float?)(object)1;
							object obj6 = UnityEngine.Random.value;
							float num9 = num8 - 0.5f;
							float num10 = num9 * 1.2f;
							float num11 = num10 * _globalScale;
							tweenConfig.ease = Ease.Linear;
							tweenConfig.duration = 1000f;
							tweenConfig.delay = 150f;
							tweenConfig.repeat = 0;
							num3 = num11 + num11;
							tweenConfig.yoyo = false;
							tweenConfig.localY = (float?)(object)1;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							if (_tweens == null)
							{
								break;
							}
							if (multiTargetTween != null)
							{
								nint num12 = (nint)tweens3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag4 = obj7 == null;
							}
							tweens3[obj] = multiTargetTween;
							obj++;
							obj2 = obj;
							continue;
						}
						TweenCallback tweenCallback = null;
						nint num13 = (nint)this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rax_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PentagramProjectile>)+370]");
						nint method = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r10_v11 (System.IntPtr)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = method;
						((Delegate)tweenCallback).m_target = this;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r10_v11 (System.IntPtr)+4C]");
						object obj8 = (nint)0 >> 4;
						object obj9 = obj8 & 1;
						nint num14;
						if (obj9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r10_v11 (System.IntPtr)+52]");
							if ((nint)0 == 0)
							{
								num14 = unchecked((nint)6447293664L);
								goto IL_05e5;
							}
						}
						num14 = ((Delegate)tweenCallback).method_ptr;
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						goto IL_05e5;
						IL_05e5:
						object obj10 = 24;
						((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
						Tween tween = DOVirtual.DelayedCall(1.1500001f, tweenCallback, ignoreTimeScale: false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tween == null)
						{
							break;
						}
						tween.stringId = "DefaultGameTweenId";
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		MultiTargetTween[] tweens = _tweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
		_shatterVfx.Destroy();
		base.Despawn();
	}

	private void InitShatterVfx()
	{
		//IL_0096: Expected O, but got I4
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx == null || ((UnityEngine.Object)shatterVfx).m_CachedPtr == (IntPtr)0)
		{
			ShatterVFX.ShatterDetails shatterDetails = new ShatterVFX.ShatterDetails();
			shatterDetails.horizontalCuts = 8;
			shatterDetails.verticalCuts = 8;
			shatterDetails.shatterType = ShatterVFX.ShatterType.Radial;
			shatterDetails.radialSectors = 13;
			shatterDetails.radials = 3;
			shatterDetails.radialCentre = (Vector2)1056964608;
			_ = 1056964608;
			shatterDetails.randomSeed = 61;
			shatterDetails.randomizeAtRunTime = false;
			shatterDetails.randomness = 1f;
			GameObject gameObject = _renderer.gameObject;
			ShatterVFX shatterVfx2 = gameObject.AddComponent<ShatterVFX>();
			_shatterVfx = shatterVfx2;
			ShatterVFX shatterVfx3 = _shatterVfx;
			shatterVfx3.shatterDetails = shatterDetails;
		}
	}

	private void KillTweens()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		MultiTargetTween[] tweens = _tweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
	}

	private void KillTween(MultiTargetTween[] tweens)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				tweens[obj2].Kill();
			}
			obj2++;
			obj = obj2;
		}
	}

	private PentagramType GetPentType()
	{
		//IL_00a3: Expected I4, but got O
		//IL_0046: Expected O, but got I4
		//IL_0070: Expected O, but got I8
		//IL_008a: Expected O, but got I8
		Weapon weapon = _weapon;
		bool eraseItems = _eraseItems;
		if ((object)_weapon != null)
		{
			object obj = ((Equipment)weapon)._003CLevel_003Ek__BackingField - 1;
			if ((nint)obj > 7)
			{
				return PentagramType.Lvl1Good;
			}
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r9_v1+72C3BA4+v15 @ rax_v4*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ rcx_v2 (should have been resolved before IL gen)");
		}
		NullReferenceException ex = new NullReferenceException();
		return (PentagramType)ex;
	}

	public PentagramProjectile()
	{
		MultiTargetTween[] tweens = new MultiTargetTween[0];
		_tweens = tweens;
		_globalScale = 1f;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__5_0()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		EraseEnemies(_eraseItems);
		Weapon weapon = _weapon;
		nint num = (nint)typeof(PentagramWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v6+FFFFFFF8+v46 @ rax_v5*8]");
			if (0 == (nint)typeof(PentagramWeapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v6+FFFFFFF8+v89 @ rcx_v5*8]");
				object obj4 = 0 - typeof(PentagramWeapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				Weapon weapon2 = null;
				if (!flag2)
				{
					weapon2 = weapon;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (VampireSurvivors.Objects.Weapons.Weapon)+18A]");
				if ((nint)0 != 0)
				{
					EraseItems();
				}
				return;
			}
		}
		throw new NullReferenceException();
	}
}
