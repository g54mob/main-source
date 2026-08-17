using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WineGlass1_Projectile : Projectile
{
	private PhaserSprite _animatedSprite;

	private TP_WineGlass1_Weapon _trueWeapon;

	private SpriteAnimation spriteAnim;

	private TweenerCore<Vector2, Vector2, VectorOptions> throwTween;

	private List<SfxType> Glass_Light;

	private List<SfxType> Glass_Medium;

	private List<SfxType> Glass_Heavy;

	private MultiTargetTween _angleTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_WineGlass06", "ThosePeople");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004d: Expected I, but got O
		//IL_0055: Expected I4, but got O
		//IL_0065: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0836: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_00d7: Expected O, but got I4
		//IL_0135: Expected I, but got O
		//IL_014d: Invalid comparison between I4 and F4
		//IL_085a: Expected O, but got I4
		//IL_01c9: Expected I4, but got I8
		//IL_01f7: Expected O, but got I4
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected I4, but got Unknown
		//IL_034f: Expected I4, but got O
		//IL_08a2: Expected O, but got F4
		//IL_08ab: Invalid comparison between O and F4
		//IL_08ca: Invalid comparison between F4 and I4
		//IL_08f3: Expected O, but got I4
		//IL_0394: Expected O, but got Ref
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected Ref, but got Unknown
		//IL_0a2a: Expected O, but got F4
		//IL_0a7a: Expected O, but got F4
		//IL_0b12: Invalid comparison between F4 and O
		//IL_052c: Expected F4, but got O
		//IL_0619: Expected I4, but got O
		//IL_067c: Expected O, but got I4
		//IL_097a->IL09f8: Incompatible stack heights: 1 vs 0
		//IL_0b77->IL0844: Incompatible stack heights: 1 vs 0
		//IL_0724->IL0844: Incompatible stack heights: 1 vs 0
		//IL_0776->IL0844: Incompatible stack heights: 2 vs 0
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		base.angle = 0f;
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_080f;
		}
		nint num = (nint)typeof(TP_WineGlass1_Weapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r9_v2 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass1_Weapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r9_v2 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v198+FFFFFFF8+v88 @ rax_v193*8]");
			if (0 == (nint)typeof(TP_WineGlass1_Weapon))
			{
				obj3 = 1;
				goto IL_081e;
			}
		}
		obj3 = 0;
		goto IL_081e;
		IL_031e:
		GameManager core = GM.Core;
		Vector3 ret;
		Vector3 ret2 = default(Vector3);
		if ((object)GM.Core != null)
		{
			int num3 = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rsi_v21 (System.Int32)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rsi_v21 (System.Int32)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)core._stage != null)
					{
						EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&ret2), excludeDead: true);
						if ((object)enemyController != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rax_v120 (VampireSurvivors.Objects.Characters.EnemyController)+10]");
							if ((nint)0 != 0)
							{
								float2 float5 = enemyController.position;
								float num4 = 3.4028235E+38f;
								bool flag = true;
								goto IL_09f8;
							}
						}
						Weapon weapon3 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
						{
							float2 float6 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
							object obj4 = UnityEngine.Random.value;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
								{
									object obj5 = UnityEngine.Random.value;
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
										{
											float num4 = 3.4028235E+38f;
											bool flag = true;
											goto IL_09f8;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0844;
		IL_0844:
		throw new NullReferenceException();
		IL_080f:
		_trueWeapon = (TP_WineGlass1_Weapon)trueWeapon;
		Weapon weapon4 = _weapon;
		_speed = 2f;
		float2 float8 = default(float2);
		if ((object)_weapon != null)
		{
			nint num5 = (nint)weapon4;
			float num6 = _weapon.PArea();
			float num7 = default(float);
			if (!(0f > num7))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			bool flag2 = !(1f > num7);
			float xScale = num7;
			if (!flag2)
			{
				xScale = 1f;
			}
			ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
			float2 float7 = base.position;
			base.position = float8;
			int num8 = (int)(_indexInWeapon & 0x80000001L);
			if (1f < num7)
			{
				object obj6 = num8 - 1;
				object obj7 = obj6 | -2;
				num8 = obj7 + 1;
			}
			if (num8 == 1)
			{
				object obj8 = UnityEngine.Random.value;
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
				float num9 = (float)float8 - 0.5f;
				bool flag4 = num9 == 0f;
				bool flag5 = !flag3;
				bool flag6 = !flag4;
				object obj9 = flag6 & flag5;
				if (obj9 != null)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						Weapon weapon5 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null && (object)core2._stage != null)
						{
							ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)weapon5)._003COwner_003Ek__BackingField + 176);
							Transform transform = core2._stage.PickRandomEnemyInScreenBounds(ref rng);
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ rax_v165 (UnityEngine.Transform)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ rax_v165 (UnityEngine.Transform)+10]");
									bool flag7 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ rax_v165 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out ret2);
									bool flag = false;
									goto IL_09f8;
								}
							}
							goto IL_031e;
						}
					}
					goto IL_0844;
				}
			}
			goto IL_031e;
		}
		goto IL_0844;
		IL_09f8:
		Weapon weapon6 = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon6)._003COwner_003Ek__BackingField != null)
		{
			Transform transform2 = ((Equipment)weapon6)._003COwner_003Ek__BackingField.transform;
			if ((object)transform2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v45 (UnityEngine.Transform)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v45 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				float projectileSpeed = base.ProjectileSpeed;
				bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8);
				float num10 = 1f;
				if (!flag9)
				{
					num10 = (float)float8;
				}
				float num11 = (float)float8 / num10;
				if (throwTween != null)
				{
					TweenExtensions.Kill(throwTween);
				}
				DOGetter<Vector2> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DFF0");
				DOSetter<Vector2> dOSetter = null;
				((TP_WineGlass1_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__9_1((Vector2)this);
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, dOSetter, float8, num11);
				TweenCallback tweenCallback = OnBreak;
				bool flag10 = tweenerCore == null;
				nint num12 = 0;
				if (!flag10)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1974 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					bool flag11 = (nint)0 == 0;
					num12 = 0;
					if (!flag11)
					{
						num12 = 0;
					}
				}
				throwTween = tweenerCore;
				int num13 = (int)throwTween;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (throwTween != null)
				{
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					};
					float detune = (float)_indexInWeapon * 100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Shuriken, soundConfig, 200f, 10, time);
					if (_angleTween != null)
					{
						_angleTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						object obj10 = array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj11 = default(object);
						bool flag12 = obj11 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							float num14 = num11 * 1000f;
							_ = 1;
							MultiTargetTween angleTween = Tweens.Add(tweenConfig);
							_angleTween = angleTween;
							return;
						}
					}
				}
			}
		}
		goto IL_0844;
		IL_081e:
		bool flag13 = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag13)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_080f;
	}

	private void OnBreak()
	{
		//IL_0184: Expected O, but got I4
		//IL_00ca: Invalid comparison between F4 and I4
		//IL_00ea: Expected O, but got I4
		//IL_01c3: Expected I4, but got O
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_01dd: Invalid comparison between F4 and O
		Weapon weapon = _weapon;
		IList<SfxType> list = Glass_Light;
		if (((Equipment)weapon)._003CLevel_003Ek__BackingField < 7)
		{
			if (((Equipment)weapon)._003CLevel_003Ek__BackingField >= 4)
			{
				list = Glass_Medium;
			}
		}
		else
		{
			list = Glass_Heavy;
		}
		SfxType sfxType = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 10, time);
		TP_WineGlass1_Weapon trueWeapon = _trueWeapon;
		float2 float5 = base.position;
		float num = trueWeapon.PAmount();
		float num2 = (float)float5 * 4f;
		if (num2 > 0f)
		{
			float2 float6 = (float2)0;
			float2 float7 = default(float2);
			float6 = float7;
			do
			{
				Projectile projectile = trueWeapon.FireOneProjectile(float5, (int)float6, ((Weapon)trueWeapon)._targetTransform);
				float6++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6));
		}
		TP_WineGlass1_Weapon trueWeapon2 = _trueWeapon;
		float2 float8 = base.position;
		Vector2 pos = default(Vector2);
		Projectile projectile2 = _trueWeapon.FireOneProjectile(pos, 0, ((Weapon)trueWeapon2)._targetTransform);
		Despawn();
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (throwTween != null)
		{
			TweenExtensions.Kill(throwTween);
		}
		base.Despawn();
	}

	public override void InternalUpdate()
	{
	}

	public TP_WineGlass1_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0b33: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0b5b: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0b83: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0bab: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0bd3: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0bfb: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0c23: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_0c4b: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_0c73: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_0c9b: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_0cc3: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_0557: Expected O, but got I
		//IL_05b1: Expected O, but got I
		//IL_0cfa: Expected O, but got I
		//IL_061b: Expected O, but got I
		//IL_0d22: Expected O, but got I
		//IL_0685: Expected O, but got I
		//IL_0d4a: Expected O, but got I
		//IL_06ef: Expected O, but got I
		//IL_0d72: Expected O, but got I
		//IL_0759: Expected O, but got I
		//IL_0d9a: Expected O, but got I
		//IL_07c3: Expected O, but got I
		//IL_0dc2: Expected O, but got I
		//IL_082d: Expected O, but got I
		//IL_0dea: Expected O, but got I
		//IL_0897: Expected O, but got I
		//IL_0e12: Expected O, but got I
		//IL_0901: Expected O, but got I
		//IL_0948: Expected O, but got I
		//IL_09a2: Expected O, but got I
		//IL_0e49: Expected O, but got I
		//IL_0a0c: Expected O, but got I
		//IL_0e71: Expected O, but got I
		//IL_0a76: Expected O, but got I
		//IL_0e99: Expected O, but got I
		//IL_0ae0: Expected O, but got I
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)135);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 135;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)138);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 138;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)139);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 139;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)140);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 140;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)141);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 141;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)145);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 145;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)146);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 146;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)147);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 147;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)148);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 148;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)149);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 149;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)151);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 151;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)156);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 156;
		}
		Glass_Light = list;
		List<SfxType> list2 = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v30+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)134);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 134;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v32+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)137);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 137;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v34+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)144);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 144;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v36+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)150);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 150;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v38+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)152);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 152;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v40+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)154);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 154;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v42+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)155);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 155;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v44+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)157);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 157;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v46+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)158);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1252 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 158;
		}
		Glass_Medium = list2;
		List<SfxType> list3 = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v50+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)136);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 136;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v52+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)142);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 142;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v54+18]");
		if (num24 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)143);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 143;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v56+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)153);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 153;
		}
		Glass_Heavy = list3;
		base._002Ector();
	}

	private Vector2 _003CInitProjectile_003Eb__9_0()
	{
		float2 float5 = base.position;
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CInitProjectile_003Eb__9_1(Vector2 x)
	{
		float2 float5 = default(float2);
		base.position = float5;
	}
}
