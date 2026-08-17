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
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class SilfProjectile : Projectile
{
	private TrailRenderer _Trail;

	private PhaserSpline _spline;

	private float _totalTime;

	private float _duration;

	private bool _silfActive;

	private MultiTargetTween _hitScaleTween;

	private MultiTargetTween _hitFadeTween;

	private MultiTargetTween _hitFadeTrailTween;

	private MultiTargetTween _fadeInTrailTween;

	protected float _minAngleRotDeg = 10f;

	protected float _maxAngleRotDeg = 20f;

	protected Vector2 _targetPos;

	protected SilfWeapon _trueWeapon;

	protected float _trailAlpha = 0.4f;

	protected float _startingAlpha = 1f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("HitWhite1", "vfx");
		_renderer.sprite = sprite;
		float minAngleRotDeg = _minAngleRotDeg * ((float)Math.PI / 180f);
		_minAngleRotDeg = minAngleRotDeg;
		float maxAngleRotDeg = _maxAngleRotDeg * ((float)Math.PI / 180f);
		_maxAngleRotDeg = maxAngleRotDeg;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0065: Expected I4, but got O
		//IL_01a6: Expected I, but got O
		//IL_01ae: Expected I, but got O
		//IL_01be: Expected O, but got I
		//IL_023e: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_0623: Expected O, but got I4
		//IL_01fa: Expected O, but got I
		//IL_025d: Expected I4, but got O
		//IL_0230: Expected O, but got I4
		//IL_048d: Expected O, but got I4
		//IL_051d: Expected O, but got I4
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected I4, but got Unknown
		//IL_0393: Expected O, but got I
		//IL_05f6->IL056d: Incompatible stack heights: 1 vs 0
		//IL_00cd->IL056d: Incompatible stack heights: 1 vs 0
		//IL_010b->IL056d: Incompatible stack heights: 1 vs 0
		//IL_0139->IL056d: Incompatible stack heights: 1 vs 0
		//IL_04d4->IL056d: Incompatible stack heights: 1 vs 0
		//IL_02ba->IL056d: Incompatible stack heights: 1 vs 0
		//IL_02e9->IL056d: Incompatible stack heights: 1 vs 0
		//IL_034f->IL056d: Incompatible stack heights: 2 vs 0
		//IL_03ba->IL056d: Incompatible stack heights: 3 vs 0
		//IL_040d->IL056d: Incompatible stack heights: 3 vs 0
		//IL_042f->IL056d: Incompatible stack heights: 3 vs 0
		//IL_045e->IL056d: Incompatible stack heights: 3 vs 0
		//IL_06f4->IL0655: Incompatible stack heights: 6 vs 1
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		object obj4;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._enable = false;
				int num = (int)_Trail;
				_totalTime = 0f;
				_isCullable = false;
				if ((object)_Trail != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rsi_v12 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rsi_v12 (System.Int32)+10]");
					TrailRenderer.set_textureMode_Injected((IntPtr)0, LineTextureMode.Tile);
					if ((object)_weapon != null)
					{
						float num2 = _weapon.PArea();
						if ((object)_Trail != null)
						{
							object obj = default(object);
							float num3 = (float)obj * 0.05f;
							_Trail.startWidth = num3;
							if ((object)_weapon != null)
							{
								float num4 = _weapon.PArea();
								if ((object)_Trail != null)
								{
									float endWidth = num3 * 0.035f;
									_Trail.endWidth = endWidth;
									Weapon weapon2 = _weapon;
									if ((object)_weapon == null)
									{
										trueWeapon = (float?)(object)0;
										goto IL_05fb;
									}
									nint num5 = (nint)typeof(SilfWeapon);
									nint num6 = (nint)weapon2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.SilfWeapon>)+130]");
									if (num7 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rax_v98+FFFFFFF8+v762 @ rax_v93*8]");
										if (0 == (nint)typeof(SilfWeapon))
										{
											obj4 = 1;
											goto IL_060a;
										}
									}
									obj4 = 0;
									goto IL_060a;
								}
							}
						}
					}
				}
			}
		}
		goto IL_056d;
		IL_05fb:
		_trueWeapon = (SilfWeapon)trueWeapon;
		int num8 = (int)_trueWeapon;
		if ((object)_trueWeapon != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rsi_v15 (System.Int32)+10]");
			if ((nint)0 != 0)
			{
				SilfWeapon trueWeapon2 = _trueWeapon;
				if ((object)_trueWeapon != null)
				{
					Weapon targets = (Weapon)(object)trueWeapon2._Targets;
					if (trueWeapon2._Targets != null)
					{
						int num9 = trueWeapon2._EnemyIndex % ((MonoBehaviour)targets).m_CancellationTokenSource;
						bool flag2 = num9 >= (nint)((MonoBehaviour)targets).m_CancellationTokenSource;
						IntPtr cachedPtr = ((UnityEngine.Object)targets).m_CachedPtr;
						if (((UnityEngine.Object)targets).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v52 (System.IntPtr)+18]");
							bool flag3 = (nint)num9 >= (nint)0;
							SilfWeapon trueWeapon3 = _trueWeapon;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v52 (System.IntPtr)+20+v140 @ rdx_v35 (System.Int32)*8]");
							_targetPos = (Vector2)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v52 (System.IntPtr)+24+v140 @ rdx_v35 (System.Int32)*8]");
							_ = 0;
							if ((object)_trueWeapon != null)
							{
								int enemyIndex = trueWeapon3._EnemyIndex + 1;
								trueWeapon3._EnemyIndex = enemyIndex;
								SilfWeapon trueWeapon4 = _trueWeapon;
								Weapon cachedTransform = (Weapon)(object)_cachedTransform;
								if ((object)_trueWeapon != null && (object)trueWeapon4._Bird != null)
								{
									Transform transform = trueWeapon4._Bird.transform;
									if ((object)transform != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v69 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v69 (UnityEngine.Transform)+10]");
										float ret;
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
										bool flag5 = (object)_cachedTransform == null;
										bool flag6 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
										float value = default(float);
										Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
										goto IL_0655;
									}
								}
							}
						}
					}
				}
				goto IL_056d;
			}
		}
		goto IL_0655;
		IL_060a:
		bool flag7 = obj4 == null;
		trueWeapon = (float?)(object)0;
		if (!flag7)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_05fb;
		IL_056d:
		throw new NullReferenceException();
		IL_0655:
		PhaserSpline spline = GetSpline();
		_spline = spline;
		SetupTrail();
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)0);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, _startingAlpha);
		SilfWeapon trueWeapon5 = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			float duration = trueWeapon5._RayDuration * 0.001f;
			_duration = duration;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
			{
				Rate = 1f,
				Volume = (float?)(object)1
			};
			float detune = (float)_indexInWeapon * -100f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 12, time);
			_silfActive = true;
			return;
		}
		goto IL_056d;
	}

	public override void InternalUpdate()
	{
		//IL_0121->IL00c0: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL00c0: Incompatible stack heights: 1 vs 0
		if (_silfActive)
		{
			float deltaTime = PauseSystem.DeltaTime;
			if ((_totalTime = deltaTime + _totalTime) > _duration)
			{
				_totalTime = _duration;
			}
			object cachedTransform = _cachedTransform;
			float t = _totalTime / _duration;
			Vector2 point = _spline.GetPoint(t);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v2 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)0, ref value);
			if (!(_totalTime < _duration))
			{
				_silfActive = false;
				OnHit();
			}
		}
	}

	protected virtual PhaserSpline GetSpline()
	{
		//IL_010f: Expected O, but got F4
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0101->IL0087: Incompatible stack heights: 1 vs 0
		//IL_0035->IL0087: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_trueWeapon != null)
			{
				object obj = UnityEngine.Random.value;
				object obj3 = default(object);
				object obj2 = obj3 * _maxAngleRotDeg;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,edi\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm2,edi\"");
				object obj4 = obj2 * 0;
				float num = 0f * _minAngleRotDeg;
				float num2 = (float)obj4 + num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				List<Vector2> list = new List<Vector2>();
				list._002Ector();
				if (list != null)
				{
					Vector2 item = default(Vector2);
					list.Add(item);
					list.Add(item);
					list.Add(item);
					PhaserSpline phaserSpline = null;
					phaserSpline._points = list;
					return phaserSpline;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected Vector2 RotatePoint(float targetX, float targetY, float angle, Vector2 origin)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Vector2 result = default(Vector2);
		return result;
	}

	private void OnHit()
	{
		//IL_009d: Expected I, but got O
		//IL_0101: Expected O, but got I4
		//IL_011c: Expected I, but got O
		//IL_01cd: Expected I, but got O
		//IL_0231: Expected O, but got I4
		//IL_02ca: Expected I, but got O
		//IL_033d: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_hitFadeTrailTween != null)
		{
			_hitFadeTrailTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Material material = ((Renderer)_Trail).GetMaterial();
		if ((object)material != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SilfProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween hitFadeTrailTween = Tweens.Add(tweenConfig);
		_hitFadeTrailTween = hitFadeTrailTween;
		if (_hitFadeTween != null)
		{
			_hitFadeTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_renderer != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 120f;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween hitFadeTween = Tweens.Add(tweenConfig2);
		_hitFadeTween = hitFadeTween;
		if (_hitScaleTween != null)
		{
			_hitScaleTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num4 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		float num5 = _weapon.PArea();
		tweenConfig3.duration = 120f;
		tweenConfig3.scale = (float?)(object)1;
		MultiTargetTween hitScaleTween = Tweens.Add(tweenConfig3);
		_hitScaleTween = hitScaleTween;
		Weapon weapon = _weapon;
		PlayerOptionsData config = weapon._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			_renderer.enabled = false;
		}
	}

	public override void Despawn()
	{
		//IL_0299->IL0223: Incompatible stack heights: 1 vs 0
		//IL_0101->IL0223: Incompatible stack heights: 1 vs 0
		//IL_0158->IL0223: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			if (weapon._explodeOnExpire && (((Equipment)weapon)._equipmentType == WeaponType.SILF || ((Equipment)weapon)._equipmentType == WeaponType.SILF2))
			{
				float2 pos = base.position;
				Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
			}
			TrailRenderer trail = _Trail;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if ((object)_Trail != null)
				{
					_Trail.emitting = false;
					PhaserSpline spline = _spline;
					if (_spline != null)
					{
						List<Vector2> points = spline._points;
						if (spline._points != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rcx_v13 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
						}
						spline._points = null;
						BaseBody baseBody = body;
						_silfActive = false;
						if (body != null)
						{
							baseBody._enable = false;
							if (_hitFadeTrailTween != null)
							{
								_hitFadeTrailTween.Kill();
							}
							_hitFadeTrailTween = null;
							if (_hitFadeTween != null)
							{
								_hitFadeTween.Kill();
							}
							_hitFadeTween = null;
							if (_hitScaleTween != null)
							{
								_hitScaleTween.Kill();
							}
							_hitScaleTween = null;
							base.Despawn();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetupTrail()
	{
		//IL_01ea: Expected I, but got O
		//IL_0292->IL0231: Incompatible stack heights: 1 vs 0
		//IL_00e2->IL0231: Incompatible stack heights: 1 vs 0
		//IL_0138->IL0231: Incompatible stack heights: 2 vs 0
		//IL_0164->IL0231: Incompatible stack heights: 2 vs 0
		//IL_01d8->IL0231: Incompatible stack heights: 2 vs 0
		//IL_01b6->IL01b6: Incompatible stack heights: 3 vs 2
		string trailTextureName = GetTrailTextureName();
		Sprite sprite = SpriteManager.GetSprite(trailTextureName, "vfx");
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
		if ((object)_Trail != null)
		{
			Material material = ((Renderer)_Trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			Sprite trail = (Sprite)(object)_Trail;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if ((object)_Trail != null)
				{
					_Trail.emitting = true;
					Sprite trail2 = (Sprite)(object)_Trail;
					if ((object)_Trail != null)
					{
						bool flag2 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)trail2).m_CachedPtr, 31767);
						if (_fadeInTrailTween != null)
						{
							_fadeInTrailTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if ((object)_Trail != null)
						{
							Material material2 = ((Renderer)_Trail).GetMaterial();
							if (array != null)
							{
								if ((object)material2 != null)
								{
									void* value = ((IntPtr*)(&array))->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj = default(object);
									bool flag3 = obj == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
									_ = 1128792064;
									_ = 1;
									MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig);
									_fadeInTrailTween = fadeInTrailTween;
									TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual string GetTrailTextureName()
	{
		//IL_004b: Invalid comparison between O and F4
		//IL_0099: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4CF8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f))
			{
				return "Gradient3_8px";
			}
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f);
				string result = "Gradient3_6px";
				if (!flag)
				{
					result = "Gradient3_4px";
				}
				return result;
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
