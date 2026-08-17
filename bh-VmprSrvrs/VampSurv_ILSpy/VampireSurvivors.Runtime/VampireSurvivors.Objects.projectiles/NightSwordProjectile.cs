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
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class NightSwordProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public NightSwordProjectile _003C_003E4__this;

		public bool isFinisher;

		internal void _003CSetTarget_003Eb__0()
		{
			//IL_0015: Expected O, but got I
			//IL_0056: Expected O, but got I4
			//IL_0078: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (ArcadeSprite)+E0]");
			object obj = 0;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ rdx_v2+3E8] (should have been resolved before IL gen)");
			bool flag = !isFinisher;
			bool flag2 = !flag;
			object obj3 = (flag2 ? 1 : 0) + 1;
			float xScale = (float)obj3 * 0.5f;
			ArcadeSprite arcadeSprite2 = arcadeSprite.setScale(xScale, (float?)(object)1);
			if (isFinisher)
			{
				NightSwordProjectile nightSwordProjectile = _003C_003E4__this;
				RenderingExtensions.Start(nightSwordProjectile._pfxEmitter);
			}
		}

		internal void _003CSetTarget_003Eb__1()
		{
			if (isFinisher)
			{
				NightSwordProjectile nightSwordProjectile = _003C_003E4__this;
				nightSwordProjectile._pfxEmitter.Stop();
			}
		}

		internal void _003CSetTarget_003Eb__2()
		{
			_003C_003E4__this.Despawn();
		}
	}

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private NightSwordWeapon _trueWeapon;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private bool _isFinisher;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("nightSword", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_053c: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00f0: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_028f: Expected O, but got I
		//IL_02ab: Expected O, but got I4
		//IL_02c4: Expected O, but got Ref
		//IL_02de: Expected native int or pointer, but got O
		//IL_055d: Expected O, but got I4
		//IL_02f6: Expected O, but got Ref
		//IL_0310: Expected native int or pointer, but got O
		//IL_032a: Expected O, but got I
		//IL_034a: Expected O, but got Ref
		//IL_0371: Expected O, but got I
		//IL_038b: Expected native int or pointer, but got O
		//IL_057a: Expected O, but got I4
		//IL_03bd: Expected O, but got Ref
		//IL_03d7: Expected native int or pointer, but got O
		//IL_05b4: Expected O, but got I
		//IL_041d: Expected O, but got I4
		//IL_044f: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0515;
		}
		nint num = (nint)typeof(NightSwordWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v125+FFFFFFF8+v76 @ rax_v120*8]");
			if (0 == (nint)typeof(NightSwordWeapon))
			{
				obj5 = 1;
				goto IL_0524;
			}
		}
		obj5 = 0;
		goto IL_0524;
		IL_0524:
		bool flag = obj5 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0515;
		IL_0515:
		_trueWeapon = (NightSwordWeapon)trueWeapon;
		_isFinisher = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_renderer).SetMaterial(material);
		ArcadeSprite arcadeSprite2 = setDepth(240);
		if (!_initialisedParticles)
		{
			Rectangle rectangle = new Rectangle();
			rectangle._x = -0.16f;
			rectangle._y = 1.28f;
			rectangle._width = 0.32f;
			rectangle._height = 2.56f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int num4 = list._size + 1;
				list._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+80]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-18]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+80]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(75f, 125f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+18]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+38]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(-600f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 0;
			_ = 16711680;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+80]");
			particleSystemConfig._tint = (uint?)(object)0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = rectangle;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			_pfxEmitter = pfxEmitter;
			_initialisedParticles = true;
		}
		_pfxEmitter.Stop();
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		_pfxEmitter.Stop();
		if (!_isFinisher)
		{
			base.Despawn();
			return;
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		Action onComplete = delegate
		{
			_isFinisher = false;
			base.Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void SetNullTarget()
	{
		Despawn();
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_024a: Expected O, but got I4
		//IL_01ba: Expected O, but got I4
		//IL_07cb: Expected O, but got I4
		//IL_07d4: Expected O, but got I4
		//IL_0319: Expected O, but got I4
		//IL_0822: Expected O, but got I4
		//IL_0410: Expected O, but got Ref
		//IL_04ef: Expected I, but got O
		//IL_065e: Expected I, but got O
		//IL_07bb->IL06cb: Incompatible stack heights: 1 vs 0
		//IL_02ab->IL06cb: Incompatible stack heights: 1 vs 0
		//IL_084a->IL06cb: Incompatible stack heights: 2 vs 0
		//IL_03b5->IL06cb: Incompatible stack heights: 2 vs 0
		//IL_03fe->IL06cb: Incompatible stack heights: 3 vs 0
		//IL_0469->IL06cb: Incompatible stack heights: 3 vs 0
		//IL_04dd->IL06cb: Incompatible stack heights: 3 vs 0
		//IL_04bb->IL04bb: Incompatible stack heights: 4 vs 3
		//IL_05d6->IL06cb: Incompatible stack heights: 3 vs 0
		//IL_064c->IL06cb: Incompatible stack heights: 3 vs 0
		//IL_062a->IL062a: Incompatible stack heights: 4 vs 3
		//IL_06bf->IL06bf: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass11_0();
		Transform transform = default(Transform);
		object obj5;
		if (CS_0024_003C_003E8__locals14 != null)
		{
			CS_0024_003C_003E8__locals14._003C_003E4__this = this;
			_targetTransform = transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebx\"");
			object obj = (object)transform >> 31;
			SoundManager.SoundConfig soundConfig = (SoundManager.SoundConfig)(object)((object)transform + obj);
			object obj2 = soundConfig * 2;
			object obj3 = (object)soundConfig + obj2;
			object obj4 = obj3 + obj3;
			obj5 = _indexInWeapon - obj4;
			NightSwordWeapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon != null)
			{
				bool isFinisher;
				if (!trueWeapon._CanFinish)
				{
					isFinisher = false;
				}
				else
				{
					object obj6 = obj5 - 5;
					bool flag = obj6 == null;
					isFinisher = flag;
				}
				CS_0024_003C_003E8__locals14.isFinisher = isFinisher;
				_isFinisher = isFinisher;
				if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
				{
					int maxInstances;
					float durationMillis;
					SoundManager.SoundConfig soundConfig3;
					SfxType sfxType;
					if ((nint)obj5 >= 5)
					{
						if (!CS_0024_003C_003E8__locals14.isFinisher)
						{
							goto IL_0767;
						}
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Rate = 1f;
						soundConfig2.Detune = 1200f;
						if ((object)_trueWeapon == null)
						{
							goto IL_06cb;
						}
						soundConfig2.Volume = (float?)(object)1;
						maxInstances = 1;
						durationMillis = 300f;
						soundConfig3 = soundConfig2;
						sfxType = SfxType.Crystal8;
					}
					else
					{
						SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
						soundConfig4.Rate = 1f;
						float detune = (float)obj5 * 200f;
						soundConfig4.Detune = detune;
						if ((object)_trueWeapon == null)
						{
							goto IL_06cb;
						}
						soundConfig4.Volume = (float?)(object)1;
						maxInstances = 5;
						durationMillis = 100f;
						soundConfig3 = soundConfig4;
						sfxType = SfxType.Crystal6;
					}
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig3, durationMillis, maxInstances, time);
					goto IL_0767;
				}
				Despawn();
				return;
			}
		}
		goto IL_06cb;
		IL_06cb:
		throw new NullReferenceException();
		IL_0767:
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		NightSwordWeapon trueWeapon2 = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			int[] fireX = trueWeapon2._FireX;
			if (trueWeapon2._FireX != null)
			{
				bool flag3 = (nint)obj5 >= fireX.Length;
				float2 float5 = default(float2);
				base.position = float5;
				bool flag4 = !CS_0024_003C_003E8__locals14.isFinisher;
				Transform spriteName = (Transform)(object)"nightSword";
				if (!flag4)
				{
					spriteName = (Transform)(object)"nightSwordCrit";
				}
				object obj7 = !flag4;
				object obj8 = 150;
				if (obj7 == null)
				{
					obj8 = 100;
				}
				Sprite sprite = SpriteManager.GetSprite((string)(object)spriteName, "vfx");
				ArcadeSprite arcadeSprite = setFrame(sprite);
				float alpha = ((!CS_0024_003C_003E8__locals14.isFinisher) ? 0.75f : 0.5f);
				ArcadeSprite arcadeSprite2 = setAlpha(alpha);
				if (CS_0024_003C_003E8__locals14.isFinisher)
				{
				}
				ArcadeSprite arcadeSprite3 = setOrigin(0.5f, (float?)(object)1);
				NightSwordWeapon trueWeapon3 = _trueWeapon;
				if ((object)_trueWeapon != null)
				{
					int[] fireAngles = trueWeapon3._FireAngles;
					if (trueWeapon3._FireAngles != null)
					{
						bool flag5 = (nint)obj5 >= fireAngles.Length;
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							transform2.localEulerAngles = (Vector3)(&ret);
							int height = Screen.height;
							ArcadeSprite arcadeSprite4 = setDepth(height);
							if (_tween != null)
							{
								_tween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							Transform transform3 = base.transform;
							if (array != null)
							{
								if ((object)transform3 != null)
								{
									void* value = ((IntPtr*)(&array))->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj9 = default(object);
									bool flag6 = obj9 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
									_ = 1;
									_ = 1;
									_ = 1;
									TweenCallback tweenCallback = delegate
									{
										//IL_0015: Expected O, but got I
										//IL_0056: Expected O, but got I4
										//IL_0078: Expected O, but got I4
										ArcadeSprite arcadeSprite5 = CS_0024_003C_003E8__locals14._003C_003E4__this;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (ArcadeSprite)+E0]");
										object obj11 = 0;
										object obj12 = obj11;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ rdx_v2+3E8] (should have been resolved before IL gen)");
										bool flag8 = !CS_0024_003C_003E8__locals14.isFinisher;
										bool flag9 = !flag8;
										object obj13 = (flag9 ? 1 : 0) + 1;
										float xScale = (float)obj13 * 0.5f;
										ArcadeSprite arcadeSprite6 = arcadeSprite5.setScale(xScale, (float?)(object)1);
										if (CS_0024_003C_003E8__locals14.isFinisher)
										{
											NightSwordProjectile nightSwordProjectile = CS_0024_003C_003E8__locals14._003C_003E4__this;
											RenderingExtensions.Start(nightSwordProjectile._pfxEmitter);
										}
									};
									TweenCallback tweenCallback2 = delegate
									{
										if (CS_0024_003C_003E8__locals14.isFinisher)
										{
											NightSwordProjectile nightSwordProjectile = CS_0024_003C_003E8__locals14._003C_003E4__this;
											nightSwordProjectile._pfxEmitter.Stop();
										}
									};
									MultiTargetTween tween = Tweens.Add(tweenConfig);
									_tween = tween;
									if (_tween2 != null)
									{
										_tween2.Kill();
									}
									TweenConfig tweenConfig2 = new TweenConfig();
									object[] array2 = new object[1];
									if (array2 != null)
									{
										if ((object)_renderer != null)
										{
											void* value2 = ((IntPtr*)(&array2))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj10 = default(object);
											bool flag7 = obj10 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig2 != null)
										{
											((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
											_ = 1120403456;
											_ = 1;
											_ = 1120403456;
											_ = 1;
											TweenCallback tweenCallback3 = delegate
											{
												CS_0024_003C_003E8__locals14._003C_003E4__this.Despawn();
											};
											MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
											_tween2 = tween2;
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
		goto IL_06cb;
	}

	private void _003CDespawn_003Eb__9_0()
	{
		_isFinisher = false;
		base.Despawn();
	}
}
