using System;
using System.Runtime.CompilerServices;
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

public class EME_CannonProjectile_SunlightShower : Projectile
{
	private TrailRenderer _TrailBlue;

	private TrailRenderer _TrailOrange;

	private const float Radius = 16f;

	private const float FallDurationMS = 500f;

	private Tween _positionTween;

	private Timer _despawnTimer;

	private Timer _sfxTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0033: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SetupTrails();
		BaseBody baseBody = body;
		_isCullable = false;
		baseBody._enable = true;
		BaseBody baseBody2 = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
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
		//IL_0064: Expected I, but got O
		//IL_006c: Expected I, but got O
		//IL_007c: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		//IL_00b8: Expected O, but got I
		//IL_010b: Expected I4, but got O
		//IL_00ee: Expected O, but got I4
		//IL_01d9: Expected I, but got O
		//IL_0186: Expected O, but got I
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon = _weapon;
		bool flag;
		bool canPause;
		if ((object)_weapon == null)
		{
			flag = false;
			canPause = false;
			goto IL_0268;
		}
		nint num = (nint)typeof(EME_Cannon3Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon3Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon3Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v34+FFFFFFF8+v111 @ rax_v30*8]");
			if (0 == (nint)typeof(EME_Cannon3Weapon))
			{
				obj3 = 1;
				goto IL_0234;
			}
		}
		obj3 = 0;
		goto IL_0234;
		IL_0234:
		bool flag2 = obj3 == null;
		flag = false;
		canPause = false;
		if (!flag2)
		{
			flag = (byte)(int)_weapon != 0;
			canPause = false;
		}
		goto IL_0268;
		IL_0268:
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v2 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				float2 float5 = base.position;
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v2 (System.Boolean)+218]");
				float2 pos = default(float2);
				Projectile projectile = ((BulletPool)0).SpawnAt(pos, _weapon);
			}
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShower>)+370]");
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

	private void SetupTrails()
	{
		//IL_0159: Expected O, but got F4
		//IL_0162: Invalid comparison between O and F4
		TrailRenderer trailBlue = _TrailBlue;
		if ((object)_TrailBlue == null || ((UnityEngine.Object)trailBlue).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		TrailRenderer trailOrange = _TrailOrange;
		if ((object)_TrailOrange != null && ((UnityEngine.Object)trailOrange).m_CachedPtr != (IntPtr)0)
		{
			object obj = UnityEngine.Random.value;
			object obj2 = default(object);
			TrailRenderer trailOrange2;
			float time;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
			{
				_TrailBlue.time = 0.6f;
				trailOrange2 = _TrailOrange;
				time = 0.3f;
			}
			else
			{
				_TrailBlue.time = 0.3f;
				trailOrange2 = _TrailOrange;
				time = 0.6f;
			}
			trailOrange2.time = time;
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_TrailBlue);
			TrailRendererPauseController trailRendererPauseController2 = RenderingExtensions.AddPauseController(_TrailOrange);
		}
	}
}
