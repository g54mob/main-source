using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Pocket2_Projectile : Projectile
{
	private Transform _BodyTarget1;

	private Transform _BodyTarget2;

	private TP_Pocket2_Weapon _trueWeapon;

	private TP_Pocket2_InvisibleProjectile _invisibleProjectile1;

	private TP_Pocket2_InvisibleProjectile _invisibleProjectile2;

	private PhaserSprite _swordSprite;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private MultiTargetTween _rotateTween;

	private MultiTargetTween _fadeTween;

	private Timer _timer;

	private bool _isDespawning;

	private bool _isSuperAttack;

	protected override void Awake()
	{
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
					if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1481]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						GameObject gameObject = base.gameObject;
						Vector2 vector = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_ClaimhSolais");
						if ((object)phaserSprite != null)
						{
							PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(vector);
							if ((object)phaserSprite2 != null)
							{
								GameObject gameObject2 = phaserSprite2.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("_swordSprite");
									_swordSprite = phaserSprite2;
									PhaserSprite swordSprite = _swordSprite;
									if ((object)_swordSprite != null && (object)swordSprite._spriteRenderer != null)
									{
										Transform transform = swordSprite._spriteRenderer.transform;
										bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
										return;
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

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		bool flag = (object)_weapon == null;
		TP_Pocket2_Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_0197;
		}
		nint num = (nint)typeof(TP_Pocket2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pocket2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Pocket2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v25+FFFFFFF8+v63 @ rax_v21*8]");
			if (0 == (nint)typeof(TP_Pocket2_Weapon))
			{
				obj3 = 1;
				goto IL_01a6;
			}
		}
		obj3 = 0;
		goto IL_01a6;
		IL_0197:
		_trueWeapon = trueWeapon;
		Transform parent = _weapon.transform;
		Transform transform = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
		BaseBody baseBody = body;
		baseBody._enable = false;
		_isCullable = false;
		_isDespawning = false;
		GenerateParticleSystem();
		PhaserSprite phaserSprite = _swordSprite.setAlpha(0f);
		SetScaleToArea();
		return;
		IL_01a6:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = (TP_Pocket2_Weapon)_weapon;
		}
		goto IL_0197;
	}

	public void FinishInitialisation(bool isSuperAttack, bool flipped)
	{
		//IL_00cb->IL0116: Incompatible stack heights: 1 vs 0
		_isSuperAttack = isSuperAttack;
		if (isSuperAttack)
		{
			if ((object)_trueWeapon == null)
			{
				goto IL_0085;
			}
		}
		else
		{
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform == null)
			{
				goto IL_0085;
			}
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		}
		Transform cachedTransform2 = _cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
		SetPositonAndRotation(flipped);
		FadeIn();
		PlaySfx();
		return;
		IL_0085:
		throw new NullReferenceException();
	}

	private unsafe void SetPositonAndRotation(bool flipped)
	{
		//IL_0193: Expected O, but got I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_0030: Expected O, but got Ref
		//IL_00a8: Expected I, but got O
		//IL_0127: Expected O, but got I4
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		object obj = (flipped ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		object obj3 = obj2 - 1;
		float num = (float)obj3 * 90f;
		float duration = ((!_isSuperAttack) ? 500f : 375f);
		object obj4 = default(object);
		_cachedTransform.localEulerAngles = (Vector3)(&obj4);
		if (_rotateTween != null)
		{
			_rotateTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = duration;
		tweenConfig.rotateMode = RotateMode.LocalAxisAdd;
		tweenConfig.ease = Ease.InSine;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onComplete = FadeOut;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween rotateTween = Tweens.Add(tweenConfig);
		_rotateTween = rotateTween;
	}

	private unsafe void FadeIn()
	{
		//IL_00c5: Expected I, but got O
		//IL_0137: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float num;
		float num2;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			num = 0.4f;
			num2 = 0.1f;
		}
		else
		{
			num = 0.2f;
			num2 = 0.8f;
		}
		float num3 = (float)_indexInWeapon * num2;
		float num4 = 1f - num3;
		if (num4 > num)
		{
			if (_fadeTween != null)
			{
				_fadeTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_swordSprite != null)
			{
				nint num5 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_01c7;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Expected Ref, but got Unknown
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Expected Ref, but got Unknown
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				//IL_002f: Expected Ref, but got Unknown
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				//IL_003a: Expected Ref, but got Unknown
				CreateInvisibleBody(ref *(TP_Pocket2_InvisibleProjectile*)(this + 232), ref *(Transform*)(this + 208));
				CreateInvisibleBody(ref *(TP_Pocket2_InvisibleProjectile*)(this + 240), ref *(Transform*)(this + 216));
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
			_fadeTween = fadeTween;
			return;
		}
		goto IL_01c7;
		IL_01c7:
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void CreateInvisibleBody(ref TP_Pocket2_InvisibleProjectile invisibleBody, ref Transform attachPoint)
	{
		//IL_0077: Expected I, but got O
		//IL_0085: Expected I, but got O
		//IL_0095: Expected O, but got I
		//IL_0115: Expected O, but got I4
		//IL_00d1: Expected O, but got I
		//IL_0107: Expected O, but got I4
		//IL_0255: Expected F4, but got O
		//IL_02d2: Expected O, but got I4
		//IL_02a6->IL02eb: Incompatible stack heights: 1 vs 0
		//IL_0279->IL02eb: Incompatible stack heights: 1 vs 0
		//IL_03d5->IL02eb: Incompatible stack heights: 1 vs 0
		//IL_02ea->IL02ea: Incompatible stack heights: 1 vs 0
		TP_Pocket2_Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon == null || trueWeapon._invisibleProjectilePool == null)
		{
			goto IL_02eb;
		}
		float2 pos = default(float2);
		Projectile projectile = trueWeapon._invisibleProjectilePool.SpawnAt(pos, _weapon);
		bool flag = (object)projectile == null;
		Projectile projectile2 = projectile;
		if (flag)
		{
			goto IL_031b;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(TP_Pocket2_InvisibleProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_InvisibleProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_InvisibleProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v55+FFFFFFF8+v278 @ rax_v50*8]");
			if (0 == (nint)typeof(TP_Pocket2_InvisibleProjectile))
			{
				obj3 = 1;
				goto IL_0328;
			}
		}
		obj3 = 0;
		goto IL_0328;
		IL_02eb:
		throw new NullReferenceException();
		IL_0328:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_031b;
		IL_031b:
		ref TP_Pocket2_InvisibleProjectile reference = ref *(TP_Pocket2_InvisibleProjectile*)projectile2;
		TP_Pocket2_InvisibleProjectile tP_Pocket2_InvisibleProjectile = invisibleBody;
		if ((object)invisibleBody == null || ((UnityEngine.Object)tP_Pocket2_InvisibleProjectile).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		TP_Pocket2_InvisibleProjectile tP_Pocket2_InvisibleProjectile2 = invisibleBody;
		if ((object)invisibleBody != null)
		{
			tP_Pocket2_InvisibleProjectile2._003CIsSuperAttack_003Ek__BackingField = _isSuperAttack;
			TP_Pocket2_InvisibleProjectile tP_Pocket2_InvisibleProjectile3 = invisibleBody;
			if ((object)invisibleBody != null)
			{
				BaseBody baseBody = tP_Pocket2_InvisibleProjectile3.body;
				if (tP_Pocket2_InvisibleProjectile3.body != null)
				{
					baseBody._enable = true;
					if ((object)((Projectile)tP_Pocket2_InvisibleProjectile3)._cachedTransform != null)
					{
						((Projectile)tP_Pocket2_InvisibleProjectile3)._cachedTransform.SetParent(attachPoint, worldPositionStays: true);
						TP_Pocket2_InvisibleProjectile cachedTransform = (TP_Pocket2_InvisibleProjectile)(object)((Projectile)tP_Pocket2_InvisibleProjectile3)._cachedTransform;
						float xScale = (float)Vector3.zeroVector;
						bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
						float value = default(float);
						Transform.set_localPosition_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
						if (_isSuperAttack)
						{
							if ((object)_trueWeapon == null)
							{
								goto IL_02eb;
							}
							xScale = 3.5f;
						}
						else
						{
							if ((object)_weapon == null)
							{
								goto IL_02eb;
							}
							float num4 = _weapon.PArea();
						}
						if ((object)invisibleBody != null)
						{
							ArcadeSprite arcadeSprite = invisibleBody.setScale(xScale, (float?)(object)0);
							EnableInvisibleBody(ref invisibleBody, enable: true);
							return;
						}
					}
				}
			}
		}
		goto IL_02eb;
	}

	private void EnableInvisibleBody(ref TP_Pocket2_InvisibleProjectile invisibleBody, bool enable)
	{
		TP_Pocket2_InvisibleProjectile tP_Pocket2_InvisibleProjectile = invisibleBody;
		if ((object)invisibleBody != null && ((UnityEngine.Object)tP_Pocket2_InvisibleProjectile).m_CachedPtr != (IntPtr)0)
		{
			TP_Pocket2_InvisibleProjectile tP_Pocket2_InvisibleProjectile2 = invisibleBody;
			BaseBody baseBody = tP_Pocket2_InvisibleProjectile2.body;
			baseBody._enable = enable;
		}
	}

	public override void InternalUpdate()
	{
		UpdatePfx();
	}

	private void UpdatePfx()
	{
		//IL_01aa->IL0132: Incompatible stack heights: 1 vs 0
		//IL_010a->IL0132: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL0132: Incompatible stack heights: 2 vs 0
		//IL_0132->IL01fe: Incompatible stack heights: 2 vs 0
		if (_isDespawning)
		{
			return;
		}
		float num;
		if (_isSuperAttack)
		{
			if ((object)_trueWeapon != null)
			{
				num = 3.5f;
				goto IL_008c;
			}
		}
		else if ((object)_weapon != null)
		{
			float num2 = _weapon.PArea();
			float num3 = default(float);
			num = num3;
			goto IL_008c;
		}
		goto IL_0132;
		IL_0132:
		throw new NullReferenceException();
		IL_008c:
		ParticleSystem particleSystem = RenderingExtensions.SetScale(_pfx, num);
		Transform bodyTarget = _BodyTarget1;
		if ((object)_BodyTarget1 != null)
		{
			bool flag = ((UnityEngine.Object)bodyTarget).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)bodyTarget).m_CachedPtr, out Vector3 ret);
			if ((object)_pfxManager != null)
			{
				Vector2 pos = default(Vector2);
				_pfxManager.EmitParticleAt(pos);
				TP_Pocket2_Projectile bodyTarget2 = (TP_Pocket2_Projectile)(object)_BodyTarget2;
				if ((object)_BodyTarget2 != null)
				{
					bool flag2 = ((UnityEngine.Object)bodyTarget2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)bodyTarget2).m_CachedPtr, out ret);
					if ((object)_pfxManager != null)
					{
						_pfxManager.EmitParticleAt(pos);
						return;
					}
				}
			}
		}
		goto IL_0132;
	}

	private void PlaySfx()
	{
		//IL_017b: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float num = (float)_indexInWeapon * -100f;
		float detune = num - 200f;
		soundConfig.Detune = detune;
		if (_indexInWeapon == 0)
		{
		}
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Kick, soundConfig, 200f, 10, time);
		if (_indexInWeapon == 0)
		{
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_SwordSwing, soundConfig2, 200f, 10, time);
			if (_isSuperAttack)
			{
				SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
				soundConfig3.Volume = (float?)(object)1;
				soundConfig3.Rate = 1f;
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig3, 200f, 10, time);
			}
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00a3: Expected O, but got I
		//IL_023a: Expected O, but got Ref
		//IL_0254: Expected native int or pointer, but got O
		//IL_03b9: Expected O, but got I4
		//IL_0285: Expected O, but got I
		//IL_02a1: Expected O, but got I4
		//IL_02ba: Expected O, but got Ref
		//IL_02d4: Expected native int or pointer, but got O
		//IL_03d6: Expected O, but got I4
		//IL_031c: Expected F4, but got I
		//IL_0410: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			_ = 0;
			ParticleEmitterManager pfxManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
				pfxManager = (ParticleEmitterManager)0;
			}
			else
			{
				pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly2.png");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(50f, 100f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			_ = 0;
			_ = 5;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
			_ = 0;
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			_ = 0;
			float num3 = _weapon.PArea();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			minMaxCurve2 = new ParticleSystem.MinMaxCurve(0f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			_ = 0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
	}

	private unsafe void FadeOut()
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected Ref, but got Unknown
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		ref TP_Pocket2_InvisibleProjectile invisibleBody = ref *(TP_Pocket2_InvisibleProjectile*)(this + 232);
		_isDespawning = true;
		EnableInvisibleBody(ref invisibleBody, enable: false);
		EnableInvisibleBody(ref *(TP_Pocket2_InvisibleProjectile*)(this + 240), enable: false);
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_swordSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = WaitForPfx;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
		_fadeTween = fadeTween;
	}

	private void WaitForPfx()
	{
		//IL_0030: Expected I, but got O
		if (_timer != null)
		{
			_timer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pocket2_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.4f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timer = timer;
	}

	public override void Despawn()
	{
		TP_Pocket2_InvisibleProjectile invisibleProjectile = _invisibleProjectile1;
		if ((object)_invisibleProjectile1 != null && ((UnityEngine.Object)invisibleProjectile).m_CachedPtr != (IntPtr)0)
		{
			_invisibleProjectile1.Despawn();
		}
		TP_Pocket2_InvisibleProjectile invisibleProjectile2 = _invisibleProjectile2;
		if ((object)_invisibleProjectile2 != null && ((UnityEngine.Object)invisibleProjectile2).m_CachedPtr != (IntPtr)0)
		{
			_invisibleProjectile2.Despawn();
		}
		if (_rotateTween != null)
		{
			_rotateTween.Kill();
		}
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		if (_timer != null)
		{
			_timer.Cancel();
		}
		base.Despawn();
	}

	private unsafe void _003CFadeIn_003Eb__17_0()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Ref, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Ref, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Ref, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Ref, but got Unknown
		CreateInvisibleBody(ref *(TP_Pocket2_InvisibleProjectile*)(this + 232), ref *(Transform*)(this + 208));
		CreateInvisibleBody(ref *(TP_Pocket2_InvisibleProjectile*)(this + 240), ref *(Transform*)(this + 216));
	}
}
