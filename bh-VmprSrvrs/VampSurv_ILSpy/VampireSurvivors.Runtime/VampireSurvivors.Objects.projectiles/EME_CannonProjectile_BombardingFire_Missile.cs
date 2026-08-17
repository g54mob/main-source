using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile_BombardingFire_Missile : Projectile
{
	private ParticleSystem _MissileVFX;

	private TrailRenderer _Trail;

	private const float VFXScale = 0.8f;

	private const float FallDurationMS = 500f;

	private Tween _positionTween;

	private Timer _despawnTimer;

	private Timer _sfxTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I4, but got O
		//IL_00a8->IL00a8: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		SetupTrail();
		BaseBody baseBody = body;
		_isCullable = false;
		if (body != null)
		{
			baseBody._enable = false;
			int num = (int)_MissileVFX;
			if ((object)_MissileVFX != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v6 (System.Int32)+10]");
				if ((nint)0 != 0)
				{
					if ((object)_MissileVFX == null)
					{
						goto IL_012f;
					}
					Transform transform = _MissileVFX.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v30 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v30 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					_MissileVFX.Play(withChildren: true);
				}
			}
			if (_sfxTimer != null)
			{
				_sfxTimer.Cancel();
			}
			Action onComplete = PlaySfx;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer sfxTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_sfxTimer = sfxTimer;
			return;
		}
		goto IL_012f;
		IL_012f:
		throw new NullReferenceException();
	}

	public unsafe void MoveToTarget(float2 targetPos)
	{
		//IL_0033: Expected O, but got Ref
		//IL_0044: Expected O, but got I8
		//IL_016c: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0374: Expected O, but got I4
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_012b: Expected O, but got I4
		//IL_027a: Expected O, but got Ref
		//IL_0361->IL027b: Incompatible stack heights: 1 vs 0
		if (_positionTween != null)
		{
			TweenExtensions.Kill(_positionTween);
		}
		Vector3 ret = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&ret), 0.5f);
		object obj = 6603577472L;
		object obj9;
		nint num3;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbp_v1+462E0+v147 @ rdx_v23*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbp_v1+462E0+v147 @ rdx_v23*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbp_v1+462E0+v147 @ rdx_v23*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbp_v1+462E0+v147 @ rdx_v23*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbp_v1+462E0+v147 @ rdx_v23*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = Explode;
					obj9 = 0;
					tweenCallback2 = tweenCallback;
					num3 = 0;
					goto IL_0197;
				}
			}
		}
		TweenCallback tweenCallback3 = Explode;
		bool flag2 = tweenerCore == null;
		obj9 = 0;
		tweenCallback2 = tweenCallback3;
		num3 = 0;
		object obj10 = 0;
		nint num4 = 0;
		if (!flag2)
		{
			goto IL_0197;
		}
		goto IL_01e6;
		IL_0197:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		bool flag3 = (nint)0 == 0;
		obj10 = obj9;
		num4 = num3;
		if (!flag3)
		{
			obj10 = obj9;
			num4 = num3;
		}
		goto IL_01e6;
		IL_01e6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_positionTween = tweenerCore;
			TweenerCore<Vector3, Vector3, VectorOptions> cachedTransform = (TweenerCore<Vector3, Vector3, VectorOptions>)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rbx_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rbx_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				object obj12 = default(object);
				object obj13 = default(object);
				object obj11 = obj12 - obj13;
				object obj14 = (object)targetPos - (object)ret;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				if ((object)_cachedTransform != null)
				{
					_cachedTransform.Rotate((Vector3)(&ret), Space.Self);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Explode()
	{
		//IL_002a: Expected I, but got O
		//IL_0032: Expected I, but got O
		//IL_0042: Expected O, but got I
		//IL_00c2: Expected O, but got I4
		//IL_007e: Expected O, but got I
		//IL_00d1: Expected I4, but got O
		//IL_00b4: Expected O, but got I4
		//IL_014d: Expected O, but got I
		//IL_01fa: Expected I, but got O
		Weapon weapon = _weapon;
		bool flag;
		bool canPause;
		if ((object)_weapon == null)
		{
			flag = false;
			canPause = false;
			goto IL_02a6;
		}
		nint num = (nint)typeof(EME_Cannon2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v46+FFFFFFF8+v55 @ rax_v42*8]");
			if (0 == (nint)typeof(EME_Cannon2Weapon))
			{
				obj3 = 1;
				goto IL_0272;
			}
		}
		obj3 = 0;
		goto IL_0272;
		IL_0272:
		bool flag2 = obj3 == null;
		flag = false;
		canPause = false;
		if (!flag2)
		{
			flag = (byte)(int)_weapon != 0;
			canPause = false;
		}
		goto IL_02a6;
		IL_02a6:
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v1 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				float2 float5 = base.position;
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v1 (System.Boolean)+1E0]");
				float2 pos = default(float2);
				Projectile projectile = ((BulletPool)0).SpawnAt(pos, _weapon, _indexInWeapon);
			}
		}
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_BombardingFire_Missile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num4 = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
		_despawnTimer = despawnTimer;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -20f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_bombardingfire2, soundConfig, 200f, 10, time);
	}

	public override void Despawn()
	{
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Clear(withChildren: true);
		}
		if (_positionTween != null)
		{
			TweenExtensions.Kill(_positionTween);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
		base.Despawn();
	}

	private void SetupTrail()
	{
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			float saturationMax = default(float);
			float valueMin = default(float);
			float valueMax = default(float);
			float alphaMin = default(float);
			Color color = UnityEngine.Random.ColorHSV(0f, 0.1f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
			Color color2 = UnityEngine.Random.ColorHSV(0.1f, 0.2f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			_Trail.time = 0.8f;
			_Trail.startWidth = 0.05f;
			_Trail.endWidth = 0.025f;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
			Material material = ((Renderer)_Trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
			_Trail.Clear();
			_Trail.emitting = true;
			Gradient gradient = new Gradient();
			IntPtr ptr = Gradient.Init();
			gradient.m_Ptr = ptr;
			gradient.m_RequiresNativeCleanup = true;
			GradientColorKey[] colorKeys = new GradientColorKey[2];
			_ = color.r;
			_ = 0;
			_ = color2.r;
			_ = 1f;
			GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
			_ = 1061997773;
			_ = 0;
			_ = 1065353216;
			gradient.SetKeys(colorKeys, alphaKeys);
			_Trail.colorGradient = gradient;
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
		}
	}
}
