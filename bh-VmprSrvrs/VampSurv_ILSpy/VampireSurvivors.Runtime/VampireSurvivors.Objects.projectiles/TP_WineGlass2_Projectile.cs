using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WineGlass2_Projectile : Projectile
{
	private PhaserSprite _animatedSprite;

	private TP_WineGlass2_Weapon _trueWeapon;

	private SpriteAnimation spriteAnim;

	private TweenerCore<Vector2, Vector2, VectorOptions> throwTween;

	private MultiTargetTween _angleTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_MealTicket", "ThosePeople");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004e: Expected I, but got O
		//IL_0056: Expected I, but got O
		//IL_0066: Expected O, but got I
		//IL_00e6: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_080a: Expected O, but got I4
		//IL_00a2: Expected O, but got I
		//IL_07a7: Expected O, but got I
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_010b: Expected O, but got I4
		//IL_00d8: Expected O, but got I4
		//IL_0148: Expected I4, but got I8
		//IL_0172: Expected O, but got I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected I4, but got Unknown
		//IL_02ca: Expected I4, but got O
		//IL_0842: Expected O, but got F4
		//IL_084b: Invalid comparison between O and F4
		//IL_086a: Invalid comparison between F4 and I4
		//IL_0893: Expected O, but got I4
		//IL_030f: Expected O, but got Ref
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected Ref, but got Unknown
		//IL_09d1: Expected O, but got F4
		//IL_0a21: Expected O, but got F4
		//IL_0ab9: Invalid comparison between F4 and O
		//IL_04a7: Expected F4, but got O
		//IL_0594: Expected I4, but got O
		//IL_05f7: Expected O, but got I4
		//IL_0921->IL099f: Incompatible stack heights: 1 vs 0
		//IL_0b1e->IL08b1: Incompatible stack heights: 1 vs 0
		//IL_069f->IL08b1: Incompatible stack heights: 1 vs 0
		//IL_06f1->IL08b1: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		base.angle = 0f;
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_078a;
		}
		nint num = (nint)typeof(TP_WineGlass2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v71 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v71 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_WineGlass2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v194+FFFFFFF8+v90 @ rax_v189*8]");
			if (0 == (nint)typeof(TP_WineGlass2_Weapon))
			{
				obj3 = 1;
				goto IL_07f1;
			}
		}
		obj3 = 0;
		goto IL_07f1;
		IL_08b1:
		throw new NullReferenceException();
		IL_099f:
		Weapon weapon3 = _weapon;
		Vector3 ret;
		float2 float5 = default(float2);
		if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rax_v31 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rax_v31 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				float projectileSpeed = base.ProjectileSpeed;
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5);
				float num4 = 1f;
				if (!flag2)
				{
					num4 = (float)float5;
				}
				float num5 = (float)float5 / num4;
				if (throwTween != null)
				{
					TweenExtensions.Kill(throwTween);
				}
				DOGetter<Vector2> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DFF0");
				DOSetter<Vector2> dOSetter = null;
				((TP_WineGlass2_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__6_1((Vector2)this);
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, dOSetter, float5, num5);
				TweenCallback tweenCallback = OnBreak;
				bool flag3 = tweenerCore == null;
				nint num6 = 0;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1923 @ rax_v46 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					bool flag4 = (nint)0 == 0;
					num6 = 0;
					if (!flag4)
					{
						num6 = 0;
					}
				}
				throwTween = tweenerCore;
				int num7 = (int)throwTween;
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
						object obj4 = array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						bool flag5 = obj5 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							float num8 = num5 * 1000f;
							_ = 1;
							MultiTargetTween angleTween = Tweens.Add(tweenConfig);
							_angleTween = angleTween;
							return;
						}
					}
				}
			}
		}
		goto IL_08b1;
		IL_078a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		object obj6 = num9 ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		object obj7 = 0 & obj6;
		bool flag6 = (nint)obj7 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag7 = (nint)0 < (nint)0;
		_trueWeapon = (TP_WineGlass2_Weapon)trueWeapon;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		_speed = 2f;
		float2 float6 = base.position;
		base.position = float5;
		int num10 = (int)(_indexInWeapon & 0x80000001L);
		if (flag7 != flag6)
		{
			object obj8 = num10 - 1;
			object obj9 = obj8 | -2;
			num10 = obj9 + 1;
		}
		Vector3 ret2 = default(Vector3);
		if (num10 == 1)
		{
			object obj10 = UnityEngine.Random.value;
			bool flag8 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
			float num11 = (float)float5 - 0.5f;
			bool flag9 = num11 == 0f;
			bool flag10 = !flag8;
			bool flag11 = !flag9;
			object obj11 = flag11 & flag10;
			if (obj11 != null)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Weapon weapon4 = _weapon;
					if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null && (object)core._stage != null)
					{
						ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)weapon4)._003COwner_003Ek__BackingField + 176);
						Transform transform2 = core._stage.PickRandomEnemyInScreenBounds(ref rng);
						if ((object)transform2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v162 (UnityEngine.Transform)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v162 (UnityEngine.Transform)+10]");
								bool flag12 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v162 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out ret2);
								bool flag13 = false;
								goto IL_099f;
							}
						}
						goto IL_0299;
					}
				}
				goto IL_08b1;
			}
		}
		goto IL_0299;
		IL_0299:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			int num12 = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rsi_v21 (System.Int32)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rsi_v21 (System.Int32)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)core2._stage != null)
					{
						EnemyController enemyController = core2._stage.FindClosestEnemy((Vector3)(&ret2), excludeDead: true);
						if ((object)enemyController != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v117 (VampireSurvivors.Objects.Characters.EnemyController)+10]");
							if ((nint)0 != 0)
							{
								float2 float7 = enemyController.position;
								float num13 = 3.4028235E+38f;
								bool flag13 = true;
								goto IL_099f;
							}
						}
						Weapon weapon5 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
						{
							float2 float8 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.position;
							object obj12 = UnityEngine.Random.value;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
								{
									object obj13 = UnityEngine.Random.value;
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
										{
											float num13 = 3.4028235E+38f;
											bool flag13 = true;
											goto IL_099f;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_08b1;
		IL_07f1:
		bool flag14 = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag14)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_078a;
	}

	private void OnBreak()
	{
		//IL_00f8: Expected O, but got I4
		//IL_0107: Expected F4, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0127: Expected I4, but got O
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Rate = 2f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = _indexInWeapon;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_LifeMaxUp, soundConfig, 200f, 1, time);
		TP_WineGlass2_Weapon trueWeapon = _trueWeapon;
		float2 float5 = base.position;
		float num = trueWeapon.PAmount();
		if ((nint)float5 > 0)
		{
			float2 float6 = (float2)0;
			float2 float7 = default(float2);
			float6 = float7;
			do
			{
				Projectile projectile = trueWeapon.FireOneProjectile(float5, (int)float6, ((Weapon)trueWeapon)._targetTransform);
				float6++;
			}
			while (float5 > float6 != 0);
		}
		TP_WineGlass2_Weapon trueWeapon2 = _trueWeapon;
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

	private Vector2 _003CInitProjectile_003Eb__6_0()
	{
		float2 float5 = base.position;
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CInitProjectile_003Eb__6_1(Vector2 x)
	{
		float2 float5 = default(float2);
		base.position = float5;
	}
}
