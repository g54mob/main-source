using System;
using System.Collections.Generic;
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
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_RapierProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public EME_RapierProjectile _003C_003E4__this;

		public bool isFinisher;

		internal void _003CSetTarget_003Eb__0()
		{
			//IL_0015: Expected O, but got I
			//IL_003e: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (ArcadeSprite)+E0]");
			object obj = 0;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v96 @ rdx_v2+3E8] (should have been resolved before IL gen)");
			float xScale = default(float);
			ArcadeSprite arcadeSprite2 = arcadeSprite.setScale(xScale, (float?)(object)1);
			if (isFinisher)
			{
				EME_RapierProjectile eME_RapierProjectile = _003C_003E4__this;
				RenderingExtensions.Start(eME_RapierProjectile._pfxEmitter);
			}
		}

		internal void _003CSetTarget_003Eb__1()
		{
			if (isFinisher)
			{
				EME_RapierProjectile eME_RapierProjectile = _003C_003E4__this;
				eME_RapierProjectile._pfxEmitter.Stop();
			}
		}

		internal void _003CSetTarget_003Eb__2()
		{
			EME_RapierProjectile eME_RapierProjectile = _003C_003E4__this;
			BaseBody body = eME_RapierProjectile.body;
			body._enable = false;
		}
	}

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private EME_RapierWeapon _trueWeapon;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private bool _initialisedParticles;

	private MeshRenderer _Quad1;

	private MeshRenderer _Quad2;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private bool _isFinisher;

	private Timer _DespawnTimer;

	private PhaserSprite _displayImage;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I4, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_072a: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected I4, but got Unknown
		//IL_017e: Expected O, but got I4
		//IL_062d: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0668: Expected O, but got I
		//IL_033d: Expected O, but got I
		//IL_0359: Expected O, but got I4
		//IL_0372: Expected O, but got Ref
		//IL_038c: Expected native int or pointer, but got O
		//IL_0746: Expected O, but got I4
		//IL_03a4: Expected O, but got Ref
		//IL_03be: Expected native int or pointer, but got O
		//IL_03d8: Expected O, but got I
		//IL_03f8: Expected O, but got Ref
		//IL_041f: Expected O, but got I
		//IL_0439: Expected native int or pointer, but got O
		//IL_0763: Expected O, but got I4
		//IL_046b: Expected O, but got Ref
		//IL_0485: Expected native int or pointer, but got O
		//IL_079d: Expected O, but got I
		//IL_04cb: Expected O, but got I4
		//IL_04fd: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0703;
		}
		nint num = (nint)typeof(EME_RapierWeapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v78 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v20 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v78 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_RapierWeapon>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r9_v20 (System.Int32)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v143+FFFFFFF8+v76 @ rax_v138*8]");
			if (0 == (nint)typeof(EME_RapierWeapon))
			{
				obj5 = 1;
				goto IL_0712;
			}
		}
		obj5 = 0;
		goto IL_0712;
		IL_0712:
		bool flag = obj5 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0703;
		IL_0703:
		_trueWeapon = (EME_RapierWeapon)trueWeapon;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		int num4 = _trueWeapon.DisplayedSlashes();
		object obj6 = num4 - 2;
		int num5 = num4 ^ 2;
		int num6 = num4 ^ obj6;
		int num7 = num5 & num6;
		bool flag2 = num7 < 0;
		bool flag3 = (nint)obj6 < 0;
		bool flag4 = flag3 == flag2;
		_Quad1.enabled = flag4;
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setDepth(240);
		if (!_initialisedParticles)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite displayImage = instance.AddPhaserSprite(pos, "vfx", "desatSlash");
			_displayImage = displayImage;
			PhaserSprite phaserSprite = _displayImage.setAlpha(0f);
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
				int num8 = list._size + 1;
				list._size = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+90]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+90]");
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
			_ = 35071;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+90]");
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
		Material material = ((Renderer)_Quad1).GetMaterial();
		material.SetFloatImpl(_AlphaMul, 0f);
		Material material2 = ((Renderer)_Quad2).GetMaterial();
		material2.SetFloatImpl(_AlphaMul, 0f);
		_ = 0;
		_ = 0;
		_ = 1125515264;
		_ = 1;
		_ = 1107296256;
		_ = 1;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+98]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+90]");
		BaseBody baseBody2 = baseBody.setSize((float?)(object)num9, (float?)(object)0);
		_ = 0;
		_ = 3246391296L;
		_ = 1;
		BaseBody baseBody3 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+90]");
		BaseBody baseBody4 = baseBody3.setOffset(-75f, (float?)(object)0);
		BaseBody baseBody5 = body;
		baseBody5._enable = true;
		float2 float5 = base.position;
		PhaserSprite phaserSprite2 = _displayImage.setPosition(float5);
		PhaserSprite phaserSprite3 = _displayImage.setBlendMode(BlendMode.Add);
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
		if (_DespawnTimer != null)
		{
			_DespawnTimer.Cancel();
		}
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
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00c4: Expected O, but got I4
		//IL_022f: Expected O, but got I4
		//IL_0449: Expected O, but got Ref
		//IL_04f2: Expected O, but got Ref
		//IL_05f6: Expected I, but got O
		//IL_0766: Expected I, but got O
		//IL_07e2: Expected I, but got O
		//IL_0816: Expected I4, but got F4
		//IL_0904->IL0835: Incompatible stack heights: 1 vs 0
		//IL_02a5->IL0835: Incompatible stack heights: 1 vs 0
		//IL_02fb->IL0835: Incompatible stack heights: 2 vs 0
		//IL_0350->IL0835: Incompatible stack heights: 3 vs 0
		//IL_0382->IL0835: Incompatible stack heights: 3 vs 0
		//IL_03bf->IL0835: Incompatible stack heights: 3 vs 0
		//IL_03ee->IL0835: Incompatible stack heights: 3 vs 0
		//IL_0437->IL0835: Incompatible stack heights: 4 vs 0
		//IL_0944->IL0835: Incompatible stack heights: 4 vs 0
		//IL_0478->IL0835: Incompatible stack heights: 4 vs 0
		//IL_04b4->IL0835: Incompatible stack heights: 5 vs 0
		//IL_04e0->IL0835: Incompatible stack heights: 5 vs 0
		//IL_096c->IL0835: Incompatible stack heights: 5 vs 0
		//IL_056e->IL0835: Incompatible stack heights: 5 vs 0
		//IL_05e4->IL0835: Incompatible stack heights: 5 vs 0
		//IL_05c2->IL05c2: Incompatible stack heights: 6 vs 5
		//IL_06de->IL0835: Incompatible stack heights: 5 vs 0
		//IL_0754->IL0835: Incompatible stack heights: 5 vs 0
		//IL_0732->IL0732: Incompatible stack heights: 6 vs 5
		//IL_0829->IL0829: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass18_0();
		if (CS_0024_003C_003E8__locals9 != null)
		{
			CS_0024_003C_003E8__locals9._003C_003E4__this = this;
			Transform transform = default(Transform);
			_targetTransform = transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
			CS_0024_003C_003E8__locals9.isFinisher = false;
			object obj = (object)transform >> 31;
			object obj2 = (object)transform + obj;
			object obj3 = obj2 * 2;
			object obj4 = obj2 + obj3;
			object obj5 = obj4 + obj4;
			object obj6 = _indexInWeapon - obj5;
			if ((object)transform == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				Despawn();
				return;
			}
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			if ((object)_Quad1 != null)
			{
				Material material = ((Renderer)_Quad1).GetMaterial();
				if ((object)material != null)
				{
					material.SetFloatImpl(_AlphaMul, 1f);
					if ((object)_Quad2 != null)
					{
						Material material2 = ((Renderer)_Quad2).GetMaterial();
						if ((object)material2 != null)
						{
							material2.SetFloatImpl(_AlphaMul, 1f);
							if ((object)_Quad1 != null)
							{
								Material material3 = ((Renderer)_Quad1).GetMaterial();
								TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material3, 0f, _AlphaMul, 0.5f);
								if ((object)_Quad2 != null)
								{
									Material material4 = ((Renderer)_Quad2).GetMaterial();
									TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material4, 0f, _AlphaMul, 0.5f);
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									soundConfig.Rate = 2f;
									soundConfig.Volume = (float?)(object)1;
									float detune = (float)obj6 * 0f;
									soundConfig.Detune = detune;
									float num = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory1, soundConfig, 100f, 5, num);
									bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									float2 ret;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
									EME_RapierWeapon trueWeapon = _trueWeapon;
									if ((object)_trueWeapon != null)
									{
										int[] fireX = trueWeapon._FireX;
										if (trueWeapon._FireX != null)
										{
											bool flag2 = (nint)obj6 >= fireX.Length;
											EME_RapierWeapon trueWeapon2 = _trueWeapon;
											int[] fireY = trueWeapon2._FireY;
											if (trueWeapon2._FireY != null)
											{
												bool flag3 = (nint)obj6 >= fireY.Length;
												float2 float5 = default(float2);
												base.position = float5;
												float2 float6 = base.position;
												if ((object)_displayImage != null)
												{
													PhaserSprite phaserSprite = _displayImage.setPosition(float6);
													if ((object)_displayImage != null)
													{
														PhaserSprite phaserSprite2 = _displayImage.setAlpha(1f);
														EME_RapierWeapon trueWeapon3 = _trueWeapon;
														if ((object)_trueWeapon != null)
														{
															int[] fireAngles = trueWeapon3._FireAngles;
															if (trueWeapon3._FireAngles != null)
															{
																bool flag4 = (nint)obj6 >= fireAngles.Length;
																Transform transform2 = base.transform;
																if ((object)transform2 != null)
																{
																	transform2.localEulerAngles = (Vector3)(&ret);
																	int height = Screen.height;
																	ArcadeSprite arcadeSprite2 = setDepth(height);
																	EME_RapierWeapon trueWeapon4 = _trueWeapon;
																	if ((object)_trueWeapon != null)
																	{
																		int[] fireAngles2 = trueWeapon4._FireAngles;
																		if (trueWeapon4._FireAngles != null)
																		{
																			bool flag5 = (nint)obj6 >= fireAngles2.Length;
																			if ((object)_displayImage != null)
																			{
																				Transform transform3 = _displayImage.transform;
																				if ((object)transform3 != null)
																				{
																					transform3.localEulerAngles = (Vector3)(&ret);
																					int height2 = Screen.height;
																					if ((object)_displayImage != null)
																					{
																						PhaserSprite phaserSprite3 = _displayImage.setDepth(height2);
																						if (_tween != null)
																						{
																							_tween.Kill();
																						}
																						TweenConfig tweenConfig = new TweenConfig();
																						object[] array = new object[1];
																						if (array != null)
																						{
																							if ((object)_displayImage != null)
																							{
																								void* value = ((IntPtr*)(&array))->m_value;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																								object obj7 = default(object);
																								bool flag6 = obj7 == null;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							if (tweenConfig != null)
																							{
																								((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
																								_ = 1;
																								_ = 1120403456;
																								_ = 1;
																								_ = 1;
																								TweenCallback tweenCallback = delegate
																								{
																									//IL_0015: Expected O, but got I
																									//IL_003e: Expected O, but got I4
																									ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals9._003C_003E4__this;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (ArcadeSprite)+E0]");
																									object obj9 = 0;
																									object obj10 = obj9;
																									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v96 @ rdx_v2+3E8] (should have been resolved before IL gen)");
																									float xScale = default(float);
																									ArcadeSprite arcadeSprite4 = arcadeSprite3.setScale(xScale, (float?)(object)1);
																									if (CS_0024_003C_003E8__locals9.isFinisher)
																									{
																										EME_RapierProjectile eME_RapierProjectile = CS_0024_003C_003E8__locals9._003C_003E4__this;
																										RenderingExtensions.Start(eME_RapierProjectile._pfxEmitter);
																									}
																								};
																								TweenCallback tweenCallback2 = delegate
																								{
																									if (CS_0024_003C_003E8__locals9.isFinisher)
																									{
																										EME_RapierProjectile eME_RapierProjectile = CS_0024_003C_003E8__locals9._003C_003E4__this;
																										eME_RapierProjectile._pfxEmitter.Stop();
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
																									if ((object)_displayImage != null)
																									{
																										void* value2 = ((IntPtr*)(&array2))->m_value;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																										object obj8 = default(object);
																										bool flag7 = obj8 == null;
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
																											EME_RapierProjectile eME_RapierProjectile = CS_0024_003C_003E8__locals9._003C_003E4__this;
																											BaseBody baseBody = eME_RapierProjectile.body;
																											baseBody._enable = false;
																										};
																										MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
																										_tween2 = tween2;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2135 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_RapierProjectile>)+370]");
																										Action onComplete = new Action(this, (IntPtr)0);
																										nint num2 = (nint)this;
																										MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																										int repeat = default(int);
																										TimerType type = default(TimerType);
																										Timer despawnTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																										_DespawnTimer = despawnTimer;
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
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	static EME_RapierProjectile()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003CDespawn_003Eb__16_0()
	{
		_isFinisher = false;
		base.Despawn();
	}
}
