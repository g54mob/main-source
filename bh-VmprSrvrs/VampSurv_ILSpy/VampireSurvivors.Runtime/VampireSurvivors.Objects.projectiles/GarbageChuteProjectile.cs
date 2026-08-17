using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GarbageChuteProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private GarbageChuteWeapon _trueWeapon;

	private Timer _bounceTimer;

	private float _grav = -5f / 24f;

	private float2 _initialVelocity;

	private int _chuteIndex;

	private int _itemSpriteIndex;

	private List<Sprite> _itemSprites;

	private MultiTargetTween _rotationTween;

	private bool _despawned;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0664: Expected O, but got I4
		//IL_066d: Expected O, but got I4
		//IL_0615: Expected O, but got I
		//IL_0830: Expected I, but got O
		//IL_0898: Expected I4, but got I8
		//IL_08a6: Expected O, but got I4
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Expected O, but got Unknown
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_0756: Expected O, but got I
		//IL_0bbf: Expected O, but got I4
		//IL_092c: Expected O, but got I4
		//IL_09b6: Expected I, but got O
		//IL_0a08: Expected O, but got I4
		//IL_0c28: Expected I, but got O
		//IL_0c3e: Expected O, but got I
		//IL_0c47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4c: Expected O, but got Unknown
		//IL_0adc: Expected I, but got O
		//IL_0c72: Expected O, but got I4
		//IL_0c89: Expected I, but got I8
		//IL_0ab8: Expected I, but got I8
		//IL_07b8->IL0b66: Incompatible stack heights: 1 vs 0
		//IL_0763->IL0b66: Incompatible stack heights: 1 vs 0
		//IL_09d9->IL09d9: Incompatible stack heights: 3 vs 2
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_0b35;
		}
		nint num = (nint)typeof(GarbageChuteWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v106 (Il2CppClass<VampireSurvivors.Objects.Weapons.GarbageChuteWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v101 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v106 (Il2CppClass<VampireSurvivors.Objects.Weapons.GarbageChuteWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v101 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v186+FFFFFFF8+v68 @ rax_v181*8]");
			if (0 == (nint)typeof(GarbageChuteWeapon))
			{
				obj3 = 1;
				goto IL_0b44;
			}
		}
		obj3 = 0;
		goto IL_0b44;
		IL_0b44:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_0b35;
		IL_0b35:
		_trueWeapon = (GarbageChuteWeapon)trueWeapon;
		List<Sprite> itemSprites = new List<Sprite>();
		_itemSprites = itemSprites;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"garbage01");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"garbage02");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"garbage03");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"garbage04");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"garbage05");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"garbage06");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TrashCan");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PlasticCup");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_14");
			object obj4 = 0;
		}
		else
		{
			int num12 = list._size + 1;
			list._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj4 = "hats_14";
		}
		object obj5 = "hats_14";
		object obj6 = 0;
		object obj7 = 0;
		while ((nint)obj6 < list._size)
		{
			List<object> itemSprites2 = (List<object>)(object)_itemSprites;
			bool flag2 = (nint)obj7 >= list._size;
			string[] items10 = list._items;
			Sprite sprite = SpriteManager.GetSprite(items10[obj7], "vfx");
			int version10 = itemSprites2._version + 1;
			itemSprites2._version = version10;
			object[] items11 = itemSprites2._items;
			if (itemSprites2._size >= items11.Length)
			{
				itemSprites2.AddWithResize((object)sprite);
				obj7++;
				obj5 = sprite;
				object obj4 = 0;
				obj6 = obj7;
			}
			else
			{
				int num13 = itemSprites2._size + 1;
				itemSprites2._size = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				obj7++;
				obj5 = sprite;
				object obj4 = sprite;
				obj6 = obj7;
			}
		}
		if (_rotationTween != null)
		{
			_rotationTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num14 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.repeat = -1;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween rotationTween = Tweens.Add(tweenConfig);
		_rotationTween = rotationTween;
		List<Sprite> itemSprites3 = _itemSprites;
		object obj9 = UnityEngine.Random.RandomRangeInt(0, itemSprites3._size);
		bool flag3 = (nint)obj9 >= itemSprites3._size;
		Sprite[] items12 = itemSprites3._items;
		ArcadeSprite arcadeSprite = setFrame(items12[obj9]);
		ArcadeSprite arcadeSprite2 = setTint(16777215u);
		float num15 = _trueWeapon.PArea();
		float num16 = default(float);
		ArcadeSprite arcadeSprite3 = setScale(num16, (float?)(object)0);
		_isCullable = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		if ((object)transform != null)
		{
			nint num17 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag5 = obj10 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 100f;
		float num18 = _weapon.PDuration();
		tweenConfig2.delay = num16;
		tweenConfig2.ease = Ease.Linear;
		TweenCallback tweenCallback = null;
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1185 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(GarbageChuteProjectile._003CInitProjectile_003Eb__10_0);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1185 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj11 = (nint)0 >> 4;
		object obj12 = obj11 & 1;
		nint num20;
		if (obj12 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1185 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num20 = unchecked((nint)6447293664L);
				goto IL_0c69;
			}
		}
		num20 = ((Delegate)tweenCallback).method_ptr;
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		goto IL_0c69;
		IL_0c69:
		object obj13 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		tweenConfig2.onComplete = tweenCallback;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
		_scaleTween = scaleTween;
	}

	public void CustomFire(int chuteIndex)
	{
		//IL_04b2: Expected O, but got I4
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_0214: Expected I, but got O
		//IL_02e4: Expected O, but got F4
		//IL_0338: Expected O, but got I4
		//IL_040c->IL036b: Incompatible stack heights: 1 vs 0
		//IL_006d->IL036b: Incompatible stack heights: 1 vs 0
		//IL_00be->IL036b: Incompatible stack heights: 2 vs 0
		//IL_0103->IL036b: Incompatible stack heights: 3 vs 0
		//IL_0129->IL036b: Incompatible stack heights: 3 vs 0
		//IL_0153->IL036b: Incompatible stack heights: 3 vs 0
		//IL_049a->IL036b: Incompatible stack heights: 4 vs 0
		//IL_018c->IL036b: Incompatible stack heights: 4 vs 0
		//IL_01e3->IL036b: Incompatible stack heights: 4 vs 0
		//IL_0205->IL036b: Incompatible stack heights: 4 vs 0
		//IL_0473->IL036b: Incompatible stack heights: 4 vs 0
		//IL_0238->IL036b: Incompatible stack heights: 4 vs 0
		//IL_025a->IL036b: Incompatible stack heights: 4 vs 0
		//IL_02c0->IL036b: Incompatible stack heights: 4 vs 0
		_chuteIndex = chuteIndex;
		_bounceActivated = true;
		_despawned = false;
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				GarbageChuteWeapon trueWeapon = _trueWeapon;
				if ((object)_trueWeapon != null)
				{
					List<GarbageChuteMovement> garbageChutes = trueWeapon._garbageChutes;
					int chuteIndex2 = _chuteIndex;
					if (trueWeapon._garbageChutes != null)
					{
						bool flag2 = _chuteIndex >= garbageChutes._size;
						GarbageChuteMovement[] items = garbageChutes._items;
						if (garbageChutes._items != null)
						{
							bool flag3 = _chuteIndex >= items.Length;
							if (items[chuteIndex2] != null)
							{
								Camera main2 = Camera.main;
								if ((object)main2 != null)
								{
									Transform transform2 = main2.transform;
									if ((object)transform2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v30 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v30 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 _);
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null)
											{
												float num = renderer.height * 0.55f;
												object obj = default(object);
												float num2 = num + (float)obj;
												float2 float5 = default(float2);
												base.position = float5;
												Weapon weapon = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
												{
													object obj2 = UnityEngine.Random.RandomRangeInt(0, 12);
													float num3 = (float)obj2 * ((float)Math.PI / 2f);
													float num4 = num3 / 12f;
													float num5 = num4 + (float)Math.PI / 4f;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
													object obj3 = num5 ^ 0;
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														nint num6 = (nint)this;
														float projectileSpeed = base.ProjectileSpeed;
														if (body != null && (object)s_scene2.physics != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
															object obj4 = obj3 * (object)float5;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
															object obj5 = obj3 * (object)float5;
															BaseBody baseBody = body;
															if (body != null)
															{
																float num7 = (float)baseBody._velocity * 1.5f;
																_initialVelocity = (float2)num7;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v52 (BaseBody)+74]");
																float num8 = 0f * 1.5f;
																SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																{
																	Rate = 1f
																};
																float detune = (float)_indexInWeapon * -100f;
																soundConfig.Volume = (float?)(object)1;
																soundConfig.Detune = detune;
																float time = default(float);
																PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.DLC3_GarbageGrab, soundConfig, 1000f, 1, time);
																return;
															}
														}
													}
												}
											}
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

	public override void InternalUpdate()
	{
		//IL_0563: Expected O, but got I4
		//IL_0563: Expected F4, but got O
		//IL_02e2: Invalid comparison between F4 and O
		//IL_05b6: Expected O, but got F4
		//IL_02fe: Invalid comparison between O and F4
		//IL_00b3->IL04f5: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL04f5: Incompatible stack heights: 1 vs 0
		//IL_010c->IL04f5: Incompatible stack heights: 1 vs 0
		//IL_0147->IL04f5: Incompatible stack heights: 1 vs 0
		//IL_01b8->IL04f5: Incompatible stack heights: 1 vs 0
		//IL_0209->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_0240->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_0262->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_029d->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_058b->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_05dd->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_035e->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_037c->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_0604->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_03b0->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_0430->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_045a->IL04f5: Incompatible stack heights: 2 vs 0
		//IL_0660->IL04f5: Incompatible stack heights: 3 vs 0
		//IL_0493->IL04f5: Incompatible stack heights: 3 vs 0
		//IL_04e0->IL04f5: Incompatible stack heights: 3 vs 0
		//IL_04f4->IL04f4: Incompatible stack heights: 3 vs 2
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * _grav;
		float num2 = num * 1000f;
		float num3 = num2 * 0.01f;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.GarbageChuteProjectile)+F0]");
		float num5 = num4 + 0f;
		setVelocity((float)_initialVelocity, (float?)(object)1);
		float2 float5 = base.position;
		GarbageChuteWeapon trueWeapon = _trueWeapon;
		float2 float9 = default(float2);
		if ((object)_trueWeapon != null)
		{
			List<GarbageChuteMovement> garbageChutes = trueWeapon._garbageChutes;
			int chuteIndex = _chuteIndex;
			if (trueWeapon._garbageChutes != null)
			{
				bool flag = _chuteIndex >= garbageChutes._size;
				GarbageChuteMovement[] items = garbageChutes._items;
				if (garbageChutes._items != null)
				{
					GarbageChuteMovement garbageChuteMovement = items[chuteIndex];
					if (items[chuteIndex] != null && (object)garbageChuteMovement.ChuteSprite != null)
					{
						float2 float6 = garbageChuteMovement.ChuteSprite.position;
						GarbageChuteWeapon trueWeapon2 = _trueWeapon;
						if ((object)_trueWeapon != null)
						{
							float num6 = trueWeapon2.ChuteArea * trueWeapon2.ChuteWidth;
							List<GarbageChuteMovement> garbageChutes2 = trueWeapon2._garbageChutes;
							int chuteIndex2 = _chuteIndex;
							float num7 = num6 * 0.5f;
							float num8 = (float)float6 - num7;
							if (trueWeapon2._garbageChutes != null)
							{
								bool flag2 = _chuteIndex >= garbageChutes2._size;
								GarbageChuteMovement[] items2 = garbageChutes2._items;
								if (garbageChutes2._items != null)
								{
									GarbageChuteMovement garbageChuteMovement2 = items2[chuteIndex2];
									if (items2[chuteIndex2] != null && (object)garbageChuteMovement2.ChuteSprite != null)
									{
										float2 float7 = garbageChuteMovement2.ChuteSprite.position;
										GarbageChuteWeapon trueWeapon3 = _trueWeapon;
										if ((object)_trueWeapon != null)
										{
											float num9 = trueWeapon3.ChuteArea * trueWeapon3.ChuteWidth;
											float num10 = num9 * 0.5f;
											float num11 = num10 + (float)float7;
											float2 float8;
											if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
											{
												if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num11))
												{
													goto IL_0572;
												}
												float8 = float9;
											}
											else
											{
												float8 = float9;
											}
											base.position = float8;
											float num12 = (float)_initialVelocity * -1f;
											_initialVelocity = (float2)num12;
											goto IL_0572;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04f5;
		IL_04f5:
		throw new NullReferenceException();
		IL_0572:
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							float num13 = renderer2.height * 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v24 (PhaserScene+Renderer)+38]");
							float num14 = 0f - num13;
							if (!(num14 > num5))
							{
								return;
							}
							float2 float10 = base.position;
							Camera main = Camera.main;
							if ((object)main != null)
							{
								Transform transform = main.transform;
								if ((object)transform != null)
								{
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
									PhaserScene s_scene3 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer3 = s_scene3._renderer;
										if (s_scene3._renderer != null)
										{
											float num15 = renderer3.height * 0.55f;
											object obj = default(object);
											float num16 = num15 + (float)obj;
											base.position = float9;
											if (_objectsHit != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04f5;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			Despawn();
		}
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && triggerHit && --_penetrating <= 0)
		{
			Despawn();
		}
	}

	public Sprite GetNextSprite()
	{
		//IL_0015: Expected O, but got I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected I4, but got Unknown
		List<Sprite> itemSprites = _itemSprites;
		object obj = _itemSpriteIndex + 1;
		int num = (_itemSpriteIndex = obj % itemSprites._size);
		if (num < itemSprites._size)
		{
			Sprite[] items = itemSprites._items;
			return items[num];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sprite result = default(Sprite);
		return result;
	}

	public Sprite GetRandomSprite()
	{
		//IL_0050: Expected O, but got I4
		List<Sprite> itemSprites = _itemSprites;
		object obj = UnityEngine.Random.RandomRangeInt(0, itemSprites._size);
		bool flag = (nint)obj >= itemSprites._size;
		Sprite[] items = itemSprites._items;
		return items[obj];
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (!_despawned)
		{
			_despawned = true;
			_trueWeapon.ProjectileComplete(_chuteIndex);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__10_0()
	{
		Despawn();
	}
}
