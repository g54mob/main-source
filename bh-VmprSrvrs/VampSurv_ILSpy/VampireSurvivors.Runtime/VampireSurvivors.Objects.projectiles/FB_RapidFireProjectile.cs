using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_RapidFireProjectile : Projectile
{
	private Timer _timerEvent;

	private MultiTargetTween _hideTween;

	private float _save_vel_x;

	private float _save_vel_y;

	private Vector2 _aimVector;

	private float _bulletDeceleration;

	private TweenerCore<float, float, FloatOptions> _speedTween;

	protected Sprite cachedSprite;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("FB_ShortBulletBlue", "firstBlood");
		cachedSprite = sprite;
		ArcadeSprite arcadeSprite = setFrame(cachedSprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0840: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_007a: Invalid comparison between O and F4
		//IL_08b0: Expected I, but got O
		//IL_0a4b: Expected O, but got F4
		//IL_08be: Expected O, but got F4
		//IL_0953: Expected I, but got O
		//IL_010a: Expected I, but got O
		//IL_023c: Expected O, but got I4
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_02ca: Expected F4, but got I4
		//IL_0297: Expected O, but got I8
		//IL_0210: Expected O, but got F4
		//IL_0423: Expected O, but got I
		//IL_047c: Invalid comparison between I and F4
		//IL_0a00: Expected O, but got I4
		//IL_060a: Expected I, but got O
		//IL_074b: Expected I, but got O
		//IL_07e0: Expected O, but got F4
		//IL_09a6->IL0807: Incompatible stack heights: 4 vs 0
		//IL_01cf->IL0807: Incompatible stack heights: 4 vs 0
		//IL_02e8->IL0807: Incompatible stack heights: 4 vs 0
		//IL_01fe->IL0807: Incompatible stack heights: 4 vs 0
		//IL_0320->IL0807: Incompatible stack heights: 4 vs 0
		//IL_0380->IL0807: Incompatible stack heights: 4 vs 0
		//IL_03af->IL0807: Incompatible stack heights: 4 vs 0
		//IL_03d1->IL0807: Incompatible stack heights: 4 vs 0
		//IL_0443->IL0807: Incompatible stack heights: 5 vs 0
		//IL_0a1e->IL0807: Incompatible stack heights: 6 vs 0
		//IL_0a3d->IL0807: Incompatible stack heights: 6 vs 0
		//IL_071f->IL0807: Incompatible stack heights: 6 vs 0
		//IL_0790->IL0807: Incompatible stack heights: 6 vs 0
		//IL_076e->IL076e: Incompatible stack heights: 7 vs 6
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setFrame(cachedSprite);
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		object obj = default(object);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float alpha;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
				{
					float num2 = (float)obj - 1f;
					float num3 = num2 / 5f;
					float num4 = 1f - num3;
					float num5 = num4 * 0.65f;
					alpha = num5 + 0.35f;
				}
				else
				{
					alpha = 0.35f;
				}
				ArcadeSprite arcadeSprite3 = setAlpha(alpha);
				BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((EventEmitter)cachedTransform).callbacks == null;
					Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, out Vector3 ret);
					object obj2 = UnityEngine.Random.value;
					object obj3 = UnityEngine.Random.value;
					float num6 = (float)ret + 0.15f;
					BulletPool cachedTransform2 = (BulletPool)(object)_cachedTransform;
					float num7 = num6 * (float)_indexInWeapon;
					float num8 = num7 * 0.1f;
					object obj4 = default(object);
					float num9 = num8 + (float)obj4;
					bool flag2 = (object)_cachedTransform == null;
					bool flag3 = ((EventEmitter)cachedTransform2).callbacks == null;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform2).callbacks, ref value);
					bool flag4 = (object)weapon == null;
					nint num10 = (nint)this;
					if (weapon.IsHoming)
					{
						Transform transform = base.AimForNearestEnemy();
						goto IL_096c;
					}
					Vector2 vector = calDirection();
					float num11 = UnityEngine.Random.Range(-(float)Math.PI / 30f, (float)Math.PI / 30f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					object obj5 = default(object);
					float num12 = num11 + (float)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float projectileSpeed = base.ProjectileSpeed;
					float num13 = num12 * num12;
					float num14 = num12 * num12;
					ArcadeSprite sprite = _sprite;
					if ((object)_sprite != null)
					{
						BaseBody baseBody2 = sprite.body;
						if (sprite.body != null)
						{
							baseBody2._velocity = (float2)num13;
							goto IL_096c;
						}
					}
				}
			}
		}
		goto IL_0807;
		IL_0807:
		throw new NullReferenceException();
		IL_096c:
		BaseBody baseBody3 = body;
		_save_vel_x = 1f;
		_save_vel_y = 1f;
		if (body != null)
		{
			object obj6 = 12 - index;
			BulletPool bulletPool = (BulletPool)(obj6 * 100);
			_aimVector = baseBody3._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v41 (BaseBody)+74]");
			_ = 0;
			if ((long)bulletPool < 4294966096L)
			{
				bulletPool = (BulletPool)4294966096L;
			}
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FullAutoShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			if ((object)_weapon != null)
			{
				int num15 = _weapon.PBounces();
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					Weapon weapon3 = _weapon;
					List<float> critChancesArray = weapon2._critChancesArray;
					int critIndex = weapon3._critIndex + 1;
					weapon3._critIndex = critIndex;
					Weapon weapon4 = _weapon;
					if ((object)_weapon != null)
					{
						List<float> critChancesArray2 = weapon4._critChancesArray;
						if (weapon4._critChancesArray != null && weapon2._critChancesArray != null)
						{
							int critIndex2 = weapon3._critIndex;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ r10_v12 (System.Collections.Generic.List`1<System.Single>)+18]");
							int num16 = (int)((nint)critIndex2 % (nint)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v20 (System.Collections.Generic.List`1<System.Single>)+18]");
							bool flag5 = (nint)num16 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v20 (System.Collections.Generic.List`1<System.Single>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v20 (System.Collections.Generic.List`1<System.Single>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v47+18]");
								bool flag6 = (nint)num16 >= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v47+20+v233 @ rdx_v31 (System.Int32)*4]");
								bool flag7 = !(0f < 0.85f);
								int bounces = num15;
								if (!flag7)
								{
									bounces = num15 + 1;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v47+20+v233 @ rdx_v31 (System.Int32)*4]");
								float num17 = 0f * 0.5f;
								_bounces = bounces;
								float num18 = num17 + 0.5f;
								float num19 = num18 * (float)obj;
								ArcadeSprite arcadeSprite4 = setScale(num19, (float?)(object)0);
								if ((object)_weapon != null)
								{
									float num20 = _weapon.PDuration();
									_bulletDeceleration = 1f;
									if (_speedTween != null)
									{
										TweenExtensions.Kill(_speedTween);
									}
									DOGetter<float> getter = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
									DOSetter<float> dOSetter = null;
									((FB_RapidFireProjectile)(object)dOSetter)._003CInitProjectile_003Eb__9_1(num19);
									float num21 = (float)bulletPool * 0.75f;
									float duration = num21 * 0.001f;
									TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, duration);
									float num22 = (float)bulletPool * 0.25f;
									float delay = num22 * 0.001f;
									TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1620 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_RapidFireProjectile>)+370]");
									TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
									nint num23 = (nint)this;
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
										if ((nint)0 == 0)
										{
										}
									}
									_speedTween = tweenerCore;
									BulletPool speedTween = (BulletPool)(object)_speedTween;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (_speedTween != null)
									{
										speedTween._pool = (ObjectPool)(object)"DefaultGameTweenId";
										if (_hideTween != null)
										{
											_hideTween.Kill();
										}
										TweenConfig tweenConfig = new TweenConfig();
										Delegate[] array = (Delegate[])new object[1];
										if (array != null)
										{
											if ((object)_cachedTransform != null)
											{
												nint num24 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj8 = default(object);
												bool flag8 = obj8 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig != null)
											{
												((EventEmitter)(object)tweenConfig).callbacks = array;
												_ = 1;
												float num25 = (float)bulletPool * 0.25f;
												float num26 = (float)bulletPool * 0.75f;
												_ = 1;
												((Group)(object)tweenConfig).children = (HashSet<PhaserGameObject>)num25;
												MultiTargetTween hideTween = Tweens.Add(tweenConfig);
												_hideTween = hideTween;
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
		goto IL_0807;
	}

	protected virtual Vector2 calDirection()
	{
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Vector2 result = default(Vector2);
			if (((Equipment)weapon)._003COwner_003Ek__BackingField.flipX)
			{
				return result;
			}
			return result;
		}
		return (Vector2)new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			float save_vel_x = _save_vel_x * -1f;
			_save_vel_x = save_vel_x;
			float save_vel_y = _save_vel_y * -1f;
			_save_vel_y = save_vel_y;
		}
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_013b: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (triggerHit && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				Despawn();
			}
			return;
		}
		nint num = (nint)this;
		int bounces = _bounces - 1;
		_bounces = bounces;
		Transform transform = base.AimForRandomEnemy();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		float save_vel_x = _save_vel_x * -1f;
		_save_vel_x = save_vel_x;
		float save_vel_y = _save_vel_y * -1f;
		_save_vel_y = save_vel_y;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_01de: Expected O, but got I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_0178;
			}
		}
		obj5 = 4294967295L;
		goto IL_0178;
		IL_01f9:
		object obj6;
		float save_vel_y = (float)obj6 * _save_vel_y;
		_save_vel_y = save_vel_y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_0178:
		float save_vel_x = (float)obj5 * _save_vel_x;
		_save_vel_x = save_vel_x;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_01f9;
			}
		}
		obj6 = 4294967295L;
		goto IL_01f9;
	}

	public override void InternalUpdate()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0078: Expected O, but got F4
		object obj = _aimVector * _save_vel_x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_RapidFireProjectile)+EC]");
		object obj2 = 0 * _save_vel_y;
		float num = (float)obj * _bulletDeceleration;
		float num2 = (float)obj2 * _bulletDeceleration;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
	}

	public override void Despawn()
	{
		if (_timerEvent != null)
		{
			_timerEvent.Cancel();
		}
		if (_hideTween != null)
		{
			_hideTween.Kill();
		}
		base.Despawn();
	}

	public FB_RapidFireProjectile()
	{
		//IL_0035: Expected I, but got O
		_save_vel_x = -1f;
		_save_vel_y = -1f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_aimVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_bulletDeceleration = 1f;
		base._002Ector();
	}

	private float _003CInitProjectile_003Eb__9_0()
	{
		return _bulletDeceleration;
	}

	private void _003CInitProjectile_003Eb__9_1(float x)
	{
		_bulletDeceleration = x;
	}
}
