using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile : Projectile
{
	private Timer _expireTimer;

	private MultiTargetTween _scaleTween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00fe: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_03c7: Expected O, but got F4
		//IL_0149: Expected O, but got I4
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected I4, but got Unknown
		//IL_0413: Expected O, but got F4
		//IL_0450: Expected O, but got I4
		//IL_0533: Expected O, but got F4
		//IL_055e: Expected O, but got I4
		//IL_028c: Expected I, but got O
		//IL_0311: Expected O, but got I4
		//IL_032c: Expected I, but got O
		//IL_027f->IL0366: Incompatible stack heights: 3 vs 0
		//IL_02d1->IL0366: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA4F]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string value = "ProjectileBullet2";
			Sprite sprite = SpriteManager.GetSprite("ProjectileBullet2", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
					object obj = UnityEngine.Random.value;
					Weapon weapon2 = _weapon;
					object obj2 = default(object);
					float num = (_speed = (float)obj2 + 8f);
					if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						int num2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
						object obj3 = index + 1;
						int sortingOrder = obj3 + num2;
						if ((object)_renderer != null)
						{
							_renderer.sortingOrder = sortingOrder;
							if ((object)_weapon != null)
							{
								float num3 = _weapon.PArea();
								if ((object)_weapon != null)
								{
									float num4 = _weapon.PDuration();
									object obj4 = UnityEngine.Random.value;
									float num5 = num * num;
									float num6 = num5 * 0.25f;
									float duration = num + num6;
									ArcadeSprite arcadeSprite = setScale(num, (float?)(object)0);
									object cachedTransform = _cachedTransform;
									if ((object)_cachedTransform != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rsi_v15 (System.Object)+10]");
										bool flag = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rsi_v15 (System.Object)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
										object cachedTransform2 = _cachedTransform;
										bool flag2 = (object)_cachedTransform == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rsi_v16 (System.Object)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rsi_v16 (System.Object)+10]");
										Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Rate = 1f
										};
										object obj5 = UnityEngine.Random.value;
										float detune = (float)ret * 300f;
										soundConfig.Detune = detune;
										soundConfig.Volume = (float?)(object)1;
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_machinegun, soundConfig, 600f, 1, time);
										if (_scaleTween != null)
										{
											_scaleTween.Kill();
										}
										TweenConfig tweenConfig = new TweenConfig();
										object[] array = new object[1];
										if (array != null)
										{
											nint num7 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj6 = default(object);
											bool flag4 = obj6 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig != null)
											{
												tweenConfig.targets = array;
												tweenConfig.duration = duration;
												tweenConfig.ease = Ease.InOutSine;
												tweenConfig.scale = (float?)(object)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1393 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile>)+370]");
												TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
												nint num8 = (nint)this;
												tweenConfig.onComplete = onComplete;
												MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
												_scaleTween = scaleTween;
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
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}
}
