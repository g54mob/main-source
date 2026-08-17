using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BoneProjectile : Projectile
{
	private Tween _angleTween;

	private Tween _scaleTween;

	private float _saveVelX;

	private float _saveVelY;

	private Timer _bounceTimer;

	private bool _canBounce;

	[NonSerialized]
	public float _physBounce = 1f;

	[NonSerialized]
	public bool _accelOnBounce;

	protected override void Awake()
	{
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	protected override void OnDestroy()
	{
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
	}

	public void BounceMore()
	{
		//IL_0047: Expected O, but got I4
		if (_accelOnBounce)
		{
			BaseBody baseBody = body;
			_physBounce = 0.1f;
			baseBody._bounce = (float2)1066192077;
			_ = 1066192077;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_05f4: Expected I4, but got O
		//IL_070a: Expected O, but got F4
		//IL_0229: Expected O, but got Ref
		//IL_06c1: Expected O, but got Ref
		//IL_0442: Expected I, but got O
		//IL_0537: Expected O, but got I4
		//IL_0729->IL05e3: Incompatible stack heights: 1 vs 0
		//IL_06df->IL05e3: Incompatible stack heights: 1 vs 0
		//IL_06fc->IL05e3: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_speed = 1f;
		_canBounce = true;
		SetScaleToArea(0.5f);
		BaseBody baseBody = base.body;
		_physBounce = 0f;
		if (base.body != null)
		{
			baseBody._bounce = (float2)1065353216;
			_ = 1065353216;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				if (core._003CIsHalloween_003Ek__BackingField)
				{
					Sprite sprite = SpriteManager.GetSprite("pumpkin", "vfx");
					ArcadeSprite arcadeSprite = setFrame(sprite);
				}
				_isCullable = false;
				setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null && base.body != null)
					{
						Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
						BaseBody baseBody2 = base.body;
						if (base.body != null)
						{
							baseBody2._onWorldBounds = true;
							Weapon weapon3 = _weapon;
							if ((object)_weapon != null)
							{
								if (!weapon3.IsHoming)
								{
									Transform transform = base.AimForRandomEnemy();
								}
								else
								{
									Transform transform2 = base.AimForNearestEnemy();
								}
								int num = (int)_cachedTransform;
								object obj = UnityEngine.Random.value;
								Vector3 euler = default(Vector3);
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdi_v7 (System.Int32)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdi_v7 (System.Int32)+10]");
								Quaternion value = default(Quaternion);
								Transform.set_localRotation_Injected((IntPtr)0, ref value);
								if (_angleTween != null)
								{
									TweenExtensions.Kill(_angleTween);
								}
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&euler), 1f, RotateMode.FastBeyond360);
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = 4294967295L;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
											if ((nint)0 == 0)
											{
												_ = 2139095040;
											}
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore != null)
								{
									_angleTween = tweenerCore;
									if (_scaleTween != null)
									{
										TweenExtensions.Kill(_scaleTween);
									}
									TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&euler), 0.5f);
									if ((object)_weapon != null)
									{
										float num2 = _weapon.PDuration();
										float delay = (float)Vector3.zeroVector * 0.001f;
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, delay);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoneProjectile>)+370]");
										TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
										nint num3 = (nint)this;
										if (tweenerCore2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1184 @ rax_v53 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 1;
													_ = 0;
												}
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if (tweenerCore2 != null)
										{
											_scaleTween = tweenerCore2;
											SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
											{
												Rate = 1f,
												Volume = (float?)(object)1
											};
											float detune = (float)_indexInWeapon * -100f;
											soundConfig.Detune = detune;
											float time = default(float);
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
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
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_001c: Expected F4, but got O
		//IL_006a: Expected F4, but got I
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FFEC14h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FFEC35h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0093: Expected O, but got I4
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0164: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && (_canBounce ? 1 : 0) != (nint)obj)
		{
			if ((_accelOnBounce ? 1 : 0) != (nint)obj)
			{
				BaseBody baseBody = body;
				_physBounce = 0.1f;
				baseBody._bounce = (float2)1066192077;
				_ = 1066192077;
			}
			_canBounce = false;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canBounce = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.030000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			float num = _physBounce + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = num ^ 0;
			object obj4 = default(object);
			object obj3 = obj4 * obj2;
			object obj6 = default(object);
			object obj5 = obj6 * obj2;
			nint num2 = (nint)this;
			float projectileSpeed = base.ProjectileSpeed;
			float2 velocity = obj3 * obj2;
			object obj7 = obj5 * obj2;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody3 = sprite.body;
			baseBody3._velocity = velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0209: Expected O, but got I4
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
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
				goto IL_01a3;
			}
		}
		obj5 = 4294967295L;
		goto IL_01a3;
		IL_0224:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		return;
		IL_01a3:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
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
				goto IL_0224;
			}
		}
		obj6 = 4294967295L;
		goto IL_0224;
	}

	private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
	{
		//IL_004c: Expected O, but got I4
		if (bdy == body)
		{
			if (_accelOnBounce)
			{
				BaseBody baseBody = body;
				_physBounce = 0.1f;
				baseBody._bounce = (float2)1066192077;
				_ = 1066192077;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		_angleTween = null;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		_scaleTween = null;
		base.Despawn();
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	private void _003COnHasHitAnObject_003Eb__13_0()
	{
		_canBounce = true;
	}
}
