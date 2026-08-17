using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Spite0_Projectile : Projectile
{
	private bool ShowWhiteTrail = true;

	private TrailRenderer _ShotTrail;

	private float _bodyRadius = 4f;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeInTrailTween;

	private List<TP_Spite1_Projectile> _damageBoxes;

	protected override void Awake()
	{
		//IL_0154->IL0166: Incompatible stack heights: 2 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				if (ShowWhiteTrail)
				{
					GameObject gameObject = _renderer.gameObject;
					TrailRenderer shotTrail = gameObject.AddComponent<TrailRenderer>();
					_ShotTrail = shotTrail;
					SpriteRenderer shotTrail2 = (SpriteRenderer)(object)_ShotTrail;
					bool flag = ((UnityEngine.Object)shotTrail2).m_CachedPtr == (IntPtr)0;
					Color value = default(Color);
					TrailRenderer.set_startColor_Injected(((UnityEngine.Object)shotTrail2).m_CachedPtr, ref value);
					SpriteRenderer shotTrail3 = (SpriteRenderer)(object)_ShotTrail;
					bool flag2 = ((UnityEngine.Object)shotTrail3).m_CachedPtr == (IntPtr)0;
					Color value2 = default(Color);
					TrailRenderer.set_endColor_Injected(((UnityEngine.Object)shotTrail3).m_CachedPtr, ref value2);
					_ShotTrail.startWidth = 0.02f;
					_ShotTrail.endWidth = 0f;
					_ShotTrail.time = 0.2f;
					_ShotTrail.Clear();
					TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_ShotTrail);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetDamageBoxes(List<TP_Spite1_Projectile> boxes)
	{
		//IL_002b: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_00b5->IL0156: Incompatible stack heights: 1 vs 0
		//IL_00ec->IL0156: Incompatible stack heights: 1 vs 0
		//IL_01c7->IL0156: Incompatible stack heights: 2 vs 0
		//IL_0142->IL0156: Incompatible stack heights: 2 vs 0
		//IL_0155->IL01cc: Incompatible stack heights: 2 vs 0
		List<TP_Spite1_Projectile> damageBoxes = default(List<TP_Spite1_Projectile>);
		_damageBoxes = damageBoxes;
		List<TP_Spite1_Projectile> damageBoxes2 = _damageBoxes;
		bool flag = _damageBoxes == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj < damageBoxes2._size)
				{
					List<TP_Spite1_Projectile> damageBoxes3 = _damageBoxes;
					if (_damageBoxes == null)
					{
						break;
					}
					bool flag2 = (nint)obj2 >= damageBoxes3._size;
					TP_Spite1_Projectile[] items = damageBoxes3._items;
					if (damageBoxes3._items == null)
					{
						break;
					}
					object obj3 = items[obj2];
					if ((object)items[obj2] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v4 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v4 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					transform.SetParent(_cachedTransform, worldPositionStays: true);
					damageBoxes2 = _damageBoxes;
					obj2++;
					if (_damageBoxes == null)
					{
						break;
					}
					obj = obj2;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_028d: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_004f: Expected O, but got Ref
		//IL_0079: Expected O, but got I4
		//IL_0266: Expected I4, but got F4
		//IL_019d: Expected I, but got O
		//IL_0201: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)0, (float?)(object)0);
		_speed = 4f;
		_isCullable = false;
		object obj = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj));
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.8f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -50f;
		soundConfig.Detune = detune;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicShot, soundConfig, 200f, 10, num);
		if (ShowWhiteTrail)
		{
			Material material = ((Renderer)_ShotTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			_ShotTrail.emitting = true;
			if (_fadeInTrailTween != null)
			{
				_fadeInTrailTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Material material2 = ((Renderer)_ShotTrail).GetMaterial();
			if ((object)material2 != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween fadeInTrailTween = Tweens.Add(tweenConfig);
			_fadeInTrailTween = fadeInTrailTween;
		}
		Action onComplete = StartDespawn;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite0_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		//IL_031c: Expected I, but got O
		//IL_006e->IL0277: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL0277: Incompatible stack heights: 2 vs 0
		//IL_02d9->IL0277: Incompatible stack heights: 3 vs 0
		//IL_0445->IL038b: Incompatible stack heights: 1 vs 0
		//IL_0358->IL0277: Incompatible stack heights: 4 vs 0
		//IL_00ed->IL035d: Incompatible stack heights: 4 vs 0
		List<TP_Spite1_Projectile> damageBoxes = _damageBoxes;
		bool flag = _damageBoxes == null;
		int num = 0;
		int num2 = 0;
		if (!flag)
		{
			while (true)
			{
				List<TP_Spite1_Projectile> damageBoxes2 = _damageBoxes;
				if (num2 < damageBoxes._size)
				{
					if (_damageBoxes == null)
					{
						break;
					}
					bool flag2 = num >= damageBoxes2._size;
					TP_Spite1_Projectile[] items = damageBoxes2._items;
					if (damageBoxes2._items == null)
					{
						break;
					}
					bool flag3 = num >= items.Length;
					object obj = items[num];
					if ((object)items[num] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v11 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v11 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
					nint num3 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v846 @ rax_v48 (Il2CppClass<System.Object>)+368] (should have been resolved before IL gen)");
					damageBoxes = _damageBoxes;
					num++;
					if (_damageBoxes == null)
					{
						break;
					}
					num2 = num;
					continue;
				}
				if (_damageBoxes == null)
				{
					break;
				}
				int version = damageBoxes2._version + 1;
				damageBoxes2._version = version;
				damageBoxes2._size = 0;
				if (damageBoxes2._size > 0)
				{
					Array.Clear(damageBoxes2._items, 0, damageBoxes2._size);
					num2 = 0;
				}
				if (ShowWhiteTrail)
				{
					object shotTrail = _ShotTrail;
					if ((object)_ShotTrail == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v9 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_ShotTrail);
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v9 (System.Object)+10]");
					TrailRenderer.Clear_Injected((IntPtr)0);
					object shotTrail2 = _ShotTrail;
					if ((object)_ShotTrail == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v10 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v10 (System.Object)+10]");
					TrailRenderer.set_emitting_Injected((IntPtr)0, false);
				}
				if (_scaleTween != null)
				{
					_scaleTween.Kill();
				}
				if (_fadeInTrailTween != null)
				{
					_fadeInTrailTween.Kill();
				}
				base.Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public TP_Spite0_Projectile()
	{
		List<TP_Spite1_Projectile> damageBoxes = new List<TP_Spite1_Projectile>();
		_damageBoxes = damageBoxes;
		base._002Ector();
	}
}
