using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MagicProjectile_HeavensThunder : Projectile
{
	protected ParticleSystem _particleSystem;

	protected ParticleEventCall _particleEventCall;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private MultiTargetTween _moveTween;

	private Transform target;

	private List<SfxType> _sfxList;

	private static int _sfxIndex;

	private bool _follow;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Rings3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0030: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_01fb: Expected I4, but got O
		//IL_0419: Expected O, but got F4
		//IL_02da->IL035d: Incompatible stack heights: 1 vs 0
		//IL_042e->IL0224: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if ((object)_particleSystem != null)
		{
			_particleSystem.Play(withChildren: true);
			_isCullable = false;
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
				BaseBody baseBody2 = body;
				if (body != null)
				{
					baseBody2._enable = false;
					_follow = true;
					if (_hitboxTimer != null)
					{
						_hitboxTimer.Cancel();
					}
					if ((object)_weapon != null)
					{
						float hitBoxDelay = _weapon.HitBoxDelay;
						Action onComplete = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
						};
						float num = hitBoxDelay * 0.001f;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_hitboxTimer = hitboxTimer;
						nint num2 = (nint)this;
						Transform transform = base.AimForRandomEnemyInScreen();
						target = transform;
						Transform transform2 = target;
						bool flag = (object)target == null;
						float num3 = num;
						float num4 = 16f;
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							num3 = num;
							num4 = 16f;
							if (!flag2)
							{
								int num5 = (int)target;
								if ((object)target == null)
								{
									goto IL_035d;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdi_v11 (System.Int32)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdi_v11 (System.Int32)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								float num6 = default(float);
								base.position = (float2)num6;
								float num7 = default(float);
								num3 = num7;
								num4 = num6;
							}
						}
						if (_despawnTween != null)
						{
							_despawnTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							object obj = array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj2 = default(object);
							bool flag4 = obj2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								_ = 1133903872;
								_ = 1142292480;
								_ = 1;
								TweenCallback tweenCallback = delegate
								{
									//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
									//IL_00b3: Expected O, but got Unknown
									//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
									//IL_00ce: Expected O, but got Unknown
									//IL_0101: Expected O, but got I
									//IL_016d: Expected O, but got F4
									//IL_01a9: Expected O, but got I4
									BaseBody baseBody3 = body;
									_follow = false;
									baseBody3._enable = true;
									if (_hitboxTimer != null)
									{
										_hitboxTimer.Cancel();
									}
									_particleSystem.Stop();
									List<SfxType> sfxList = _sfxList;
									int sfxIndex = _sfxIndex + 1;
									_sfxIndex = sfxIndex;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
									object obj3 = (object)typeof(EME_MagicProjectile_HeavensThunder) >> 31;
									object obj4 = (object)typeof(EME_MagicProjectile_HeavensThunder) + obj3;
									object obj5 = obj4 * 2;
									object obj6 = obj4 + obj5;
									object obj7 = _sfxIndex - obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
									bool flag5 = (nint)obj7 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
									object obj8 = 0;
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									soundConfig.Rate = 1f;
									object obj9 = UnityEngine.Random.value;
									object obj10 = default(object);
									float num8 = (float)obj10 - 0.2f;
									soundConfig.Rate = 1f;
									float detune = num8 * 2000f;
									soundConfig.Volume = (float?)(object)1;
									soundConfig.Detune = detune;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v12+20+v59 @ r8_v6*4]");
									float time = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.None, soundConfig, 100f, 2, time);
								};
								TweenCallback tweenCallback2 = delegate
								{
									Despawn();
								};
								MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
								_despawnTween = despawnTween;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_035d;
		IL_035d:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_0169->IL0123: Incompatible stack heights: 1 vs 0
		Transform transform = target;
		if ((object)target == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			Transform transform2 = base.AimForRandomEnemyInScreen();
			target = transform2;
		}
		Transform transform3 = target;
		if ((object)target != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0 && _follow)
		{
			object obj = target;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rdi_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rdi_v5 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			float2 float5 = default(float2);
			base.position = float5;
		}
	}

	public override void Despawn()
	{
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Stop();
		}
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesToFinish()
	{
		if ((object)_particleSystem != null)
		{
			_particleSystem.Clear(withChildren: true);
		}
		base.Despawn();
	}

	public EME_MagicProjectile_HeavensThunder()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01a9: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01d1: Expected O, but got I
		//IL_0156: Expected O, but got I
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)458);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 458;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)459);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 459;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)460);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 460;
		}
		_sfxList = list;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__11_1()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0101: Expected O, but got I
		//IL_016d: Expected O, but got F4
		//IL_01a9: Expected O, but got I4
		BaseBody baseBody = body;
		_follow = false;
		baseBody._enable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_particleSystem.Stop();
		List<SfxType> sfxList = _sfxList;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		object obj = (object)typeof(EME_MagicProjectile_HeavensThunder) >> 31;
		object obj2 = (object)typeof(EME_MagicProjectile_HeavensThunder) + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = _sfxIndex - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		bool flag = (nint)obj5 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj6 = 0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj7 = UnityEngine.Random.value;
		object obj8 = default(object);
		float num = (float)obj8 - 0.2f;
		soundConfig.Rate = 1f;
		float detune = num * 2000f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v12+20+v59 @ r8_v6*4]");
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.None, soundConfig, 100f, 2, time);
	}

	private void _003CInitProjectile_003Eb__11_2()
	{
		Despawn();
	}
}
