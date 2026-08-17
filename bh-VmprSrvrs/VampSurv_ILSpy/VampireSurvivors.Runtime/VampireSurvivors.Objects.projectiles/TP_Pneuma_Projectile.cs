using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Pneuma_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("SoundWaves04", "vfx");
		float2 originalSize = default(float2);
		ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, originalSize);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_049e: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0140: Expected O, but got F4
		//IL_0529: Expected F4, but got O
		//IL_0251: Expected I, but got O
		//IL_025a: Expected O, but got I4
		//IL_029b: Expected I, but got O
		//IL_03c6: Expected O, but got I4
		//IL_03e1: Expected I, but got O
		//IL_044d: Expected F4, but got I4
		//IL_01bf->IL0475: Incompatible stack heights: 1 vs 0
		//IL_0211->IL0475: Incompatible stack heights: 2 vs 0
		//IL_0244->IL0475: Incompatible stack heights: 2 vs 0
		//IL_028e->IL0475: Incompatible stack heights: 2 vs 0
		//IL_033c->IL0475: Incompatible stack heights: 2 vs 0
		//IL_0393->IL0475: Incompatible stack heights: 3 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setTint(16777215u);
		ArcadeSprite arcadeSprite3 = setAlpha(1f);
		Weapon weapon2 = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				float projectileSpeed = base.ProjectileSpeed;
				object obj2 = default(object);
				object obj = (object)characterController._lastFacingDirection * obj2;
				float projectileSpeed2 = base.ProjectileSpeed;
				float num = (float)obj * 0.75f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v26 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				object obj3 = obj2 * 0;
				float num2 = (float)obj3 * 0.75f;
				ArcadeSprite sprite = _sprite;
				if ((object)_sprite != null)
				{
					BaseBody baseBody = sprite.body;
					if (sprite.body != null)
					{
						baseBody._velocity = (float2)num;
						Transform transform = base.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						Vector3 axis = default(Vector3);
						Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v33 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v33 (UnityEngine.Transform)+10]");
						Quaternion value = default(Quaternion);
						Transform.set_rotation_Injected((IntPtr)0, ref value);
						if (_scaleTween != null)
						{
							_scaleTween.Kill();
						}
						_scaleTween = null;
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							object obj4 = array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj5 = default(object);
							bool flag2 = obj5 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null)
								{
									nint num3 = (nint)weapon3;
									object obj6 = 1000;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v909 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+v173 @ r14_v10] (should have been resolved before IL gen)");
									_ = 1;
									Weapon weapon4 = _weapon;
									if ((object)_weapon != null)
									{
										nint num4 = (nint)weapon4;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v914 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+v173 @ r14_v10] (should have been resolved before IL gen)");
										_ = 1132068864;
										_ = 9;
										_ = 1;
										MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
										_scaleTween = scaleTween;
										if (_fadeTween != null)
										{
											_fadeTween.Kill();
										}
										TweenConfig tweenConfig2 = new TweenConfig();
										object[] array2 = new object[1];
										if (array2 != null)
										{
											int value2 = ((int*)(&array2))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj7 = default(object);
											bool flag3 = obj7 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig2 != null)
											{
												tweenConfig2.targets = array2;
												tweenConfig2.duration = 250f;
												tweenConfig2.alpha = (float?)(object)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pneuma_Projectile>)+370]");
												TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
												nint num5 = (nint)this;
												tweenConfig2.onComplete = onComplete;
												MultiTargetTween fadeTween = Tweens.Add(tweenConfig2);
												_fadeTween = fadeTween;
												float? volume = default(float?);
												float rate = default(float);
												float detune = default(float);
												bool loop = default(bool);
												PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 100f, 10, 0f, volume, rate, detune, loop, 1f);
												int num6 = 1000 - _indexInWeapon;
												ArcadeSprite arcadeSprite4 = setDepth(num6);
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
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			_scaleTween = null;
			if (_fadeTween != null)
			{
				_fadeTween.Kill();
			}
			_fadeTween = null;
			base.Despawn();
		}
	}
}
