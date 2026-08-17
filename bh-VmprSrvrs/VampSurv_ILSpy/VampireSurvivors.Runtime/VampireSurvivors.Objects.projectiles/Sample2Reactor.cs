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
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Sample2Reactor : Projectile
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public float duration;

		public Sample2Reactor _003C_003E4__this;

		internal void _003CfireThruster_003Eb__0()
		{
			//IL_01ce: Expected O, but got F4
			//IL_0211: Expected O, but got I4
			//IL_0046: Expected O, but got I4
			//IL_009d: Expected O, but got I4
			//IL_00f4: Expected O, but got I4
			if (!(100f > duration))
			{
				object obj = UnityEngine.Random.value;
				float detune = 100f * -1000f;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Detune = detune;
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Fireloop, soundConfig, 400f, 3, time);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Detune = detune;
				soundConfig2.Rate = 0.5f;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Fireloop, soundConfig2, 400f, 3, time);
				SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
				soundConfig3.Volume = (float?)(object)1;
				soundConfig3.Detune = detune;
				soundConfig3.Rate = 1f;
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig3, 150f, 6, time);
				SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
				soundConfig4.Volume = (float?)(object)1;
				soundConfig4.Detune = detune;
				soundConfig4.Rate = 0.5f;
				PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig4, 150f, 6, time);
				float num = duration * 0.9f;
				_003C_003E4__this.fireThruster(num);
			}
			else
			{
				_003C_003E4__this.launchOffScreen();
				Sample2Reactor sample2Reactor = _003C_003E4__this;
				sample2Reactor._pfxFireEmitterScreen.Play(withChildren: true);
				Sample2Reactor sample2Reactor2 = _003C_003E4__this;
				sample2Reactor2._pfxFireEmitterAdd.Play(withChildren: true);
			}
		}
	}

	private ParticleSystem _pfxFireEmitterScreen;

	private ParticleSystem _pfxFireEmitterAdd;

	protected Sample2Weapon _trueWeapon;

	protected float reactorOffsetY;

	protected MultiTargetTween _scaleYTween;

	private float pixelWidth;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_021f;
		}
		nint num = (nint)typeof(Sample2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v52+FFFFFFF8+v66 @ rax_v47*8]");
			if (0 == (nint)typeof(Sample2Weapon))
			{
				obj3 = 1;
				goto IL_022e;
			}
		}
		obj3 = 0;
		goto IL_022e;
		IL_022e:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_021f;
		IL_021f:
		_trueWeapon = (Sample2Weapon)trueWeapon;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ArcadeSprite arcadeSprite = setScale(pixelWidth = (float)renderer.pixelWidth * 0.75f, (float?)(object)1);
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num4 = renderer2.height * 0.5f;
		BaseBody baseBody2 = body;
		reactorOffsetY = num4;
		baseBody2._enable = false;
		ParticleSystem pfxFireEmitterScreen = _pfxFireEmitterScreen;
		if ((object)_pfxFireEmitterScreen == null || ((UnityEngine.Object)pfxFireEmitterScreen).m_CachedPtr == (IntPtr)0)
		{
			GenerateParticleSystems();
		}
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
	}

	public void FireProjectile(float totalDuration)
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
		float num = 111.111115f;
		float num2 = 100f;
		float num3 = default(float);
		num = num3;
		float num4 = default(float);
		num2 = num4;
		do
		{
			num2 += num;
			num = num2 / 0.9f;
		}
		while (totalDuration > num);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 39 Invalid \"Jump target not found in method: 0x187053480\"");
		throw new NullReferenceException();
	}

	protected void fireThruster(float duration)
	{
		//IL_005b: Expected O, but got I4
		//IL_00c6: Expected I, but got O
		//IL_0183: Expected O, but got I4
		//IL_026a->IL01e2: Incompatible stack heights: 1 vs 0
		//IL_00b9->IL01e2: Incompatible stack heights: 2 vs 0
		//IL_010b->IL01e2: Incompatible stack heights: 3 vs 0
		//IL_013b->IL01e2: Incompatible stack heights: 3 vs 0
		//IL_02e5->IL01e2: Incompatible stack heights: 3 vs 0
		//IL_0162->IL01e2: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass9_0();
		if (CS_0024_003C_003E8__locals10 != null)
		{
			CS_0024_003C_003E8__locals10.duration = duration;
			CS_0024_003C_003E8__locals10._003C_003E4__this = this;
			if (_objectsHit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				ArcadeSprite arcadeSprite = setScale(pixelWidth, (float?)(object)1);
				object pfxFireEmitterScreen = _pfxFireEmitterScreen;
				if ((object)_pfxFireEmitterScreen != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v7 (System.Object)+10]");
					ParticleSystem.Emit_Internal_Injected((IntPtr)0, 60);
					object pfxFireEmitterAdd = _pfxFireEmitterAdd;
					if ((object)_pfxFireEmitterAdd != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v8 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v8 (System.Object)+10]");
						ParticleSystem.Emit_Internal_Injected((IntPtr)0, 12);
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag3 = obj == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
									{
										tweenConfig.ease = Ease.InOutSine;
										tweenConfig.scaleY = (float?)(object)1;
										tweenConfig.duration = CS_0024_003C_003E8__locals10.duration;
										TweenCallback onComplete = delegate
										{
											//IL_01ce: Expected O, but got F4
											//IL_0211: Expected O, but got I4
											//IL_0046: Expected O, but got I4
											//IL_009d: Expected O, but got I4
											//IL_00f4: Expected O, but got I4
											if (!(100f > CS_0024_003C_003E8__locals10.duration))
											{
												object obj2 = UnityEngine.Random.value;
												float detune = 100f * -1000f;
												SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
												soundConfig.Detune = detune;
												soundConfig.Rate = 1f;
												soundConfig.Volume = (float?)(object)1;
												float time = default(float);
												PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Fireloop, soundConfig, 400f, 3, time);
												SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
												soundConfig2.Volume = (float?)(object)1;
												soundConfig2.Detune = detune;
												soundConfig2.Rate = 0.5f;
												PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Fireloop, soundConfig2, 400f, 3, time);
												SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
												soundConfig3.Volume = (float?)(object)1;
												soundConfig3.Detune = detune;
												soundConfig3.Rate = 1f;
												PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig3, 150f, 6, time);
												SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
												soundConfig4.Volume = (float?)(object)1;
												soundConfig4.Detune = detune;
												soundConfig4.Rate = 0.5f;
												PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig4, 150f, 6, time);
												float duration2 = CS_0024_003C_003E8__locals10.duration * 0.9f;
												CS_0024_003C_003E8__locals10._003C_003E4__this.fireThruster(duration2);
											}
											else
											{
												CS_0024_003C_003E8__locals10._003C_003E4__this.launchOffScreen();
												Sample2Reactor sample2Reactor = CS_0024_003C_003E8__locals10._003C_003E4__this;
												sample2Reactor._pfxFireEmitterScreen.Play(withChildren: true);
												Sample2Reactor sample2Reactor2 = CS_0024_003C_003E8__locals10._003C_003E4__this;
												sample2Reactor2._pfxFireEmitterAdd.Play(withChildren: true);
											}
										};
										tweenConfig.onComplete = onComplete;
										MultiTargetTween scaleYTween = Tweens.Add(tweenConfig);
										_scaleYTween = scaleYTween;
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

	protected void launchOffScreen()
	{
		//IL_003a: Expected I, but got O
		//IL_00ac: Expected O, but got I4
		_trueWeapon.hideReactor();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.duration = 1000f;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				BaseBody baseBody = body;
				baseBody._enable = false;
				Sample2Weapon trueWeapon = _trueWeapon;
				trueWeapon._reactorPool.Cleanup();
				_pfxFireEmitterScreen.Stop();
				_pfxFireEmitterAdd.Stop();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleYTween = Tweens.Add(tweenConfig);
			_scaleYTween = scaleYTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected override void OnUpdate()
	{
		//IL_0012: Invalid comparison between F4 and I4
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		Transform transform = base.transform;
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform2 = main.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_scaleYTween != null)
		{
			_scaleYTween.Kill();
		}
		base.Despawn();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		//IL_0586: Expected native int or pointer, but got O
		//IL_05a0: Expected O, but got I
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Expected O, but got Unknown
		//IL_05da: Expected native int or pointer, but got O
		//IL_1183: Expected O, but got I4
		//IL_060d: Expected O, but got I4
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_064d: Expected O, but got I
		//IL_0667: Expected native int or pointer, but got O
		//IL_11bd: Expected O, but got I
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_06b9: Expected native int or pointer, but got O
		//IL_11f7: Expected O, but got I
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Expected O, but got Unknown
		//IL_070b: Expected native int or pointer, but got O
		//IL_0733: Expected O, but got I
		//IL_1231: Expected O, but got I
		//IL_125e: Expected O, but got I4
		//IL_078e: Expected O, but got I
		//IL_07af: Expected O, but got I
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf1: Expected O, but got Unknown
		//IL_0c0b: Expected native int or pointer, but got O
		//IL_0c25: Expected O, but got I
		//IL_0c40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c45: Expected O, but got Unknown
		//IL_0c5f: Expected native int or pointer, but got O
		//IL_128b: Expected O, but got I
		//IL_0ca5: Expected O, but got I4
		//IL_0cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbe: Expected O, but got Unknown
		//IL_0ce5: Expected O, but got I
		//IL_0cff: Expected native int or pointer, but got O
		//IL_12c5: Expected O, but got I
		//IL_0d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d37: Expected O, but got Unknown
		//IL_0d51: Expected native int or pointer, but got O
		//IL_12ff: Expected O, but got I
		//IL_0d84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d89: Expected O, but got Unknown
		//IL_0da3: Expected native int or pointer, but got O
		//IL_1339: Expected O, but got I
		//IL_0e04: Expected O, but got I4
		//IL_0e3e: Expected O, but got I
		//IL_0e5f: Expected O, but got I
		//IL_0f0b: Expected O, but got Ref
		//IL_0f19: Expected I, but got O
		//IL_0f62: Expected O, but got I
		//IL_13c7: Expected O, but got I
		//IL_1437: Unknown result type (might be due to invalid IL or missing references)
		//IL_143c: Expected O, but got Unknown
		//IL_1406: Expected O, but got I
		//IL_146e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1473: Expected O, but got Unknown
		//IL_1460->IL10a9: Incompatible stack heights: 3 vs 0
		//IL_1070->IL142e: Incompatible stack heights: 4 vs 3
		//IL_10a9->IL1465: Incompatible stack heights: 4 vs 3
		object obj2 = default(object);
		object obj = obj2 - 632;
		float num = pixelWidth * 0.9f;
		bool flag = (object)GM.Core == null;
		float num2 = num * 0.5f;
		float num3 = num2 * 0.01f;
		if (!flag)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer2 = s_scene2._renderer;
						if (s_scene2._renderer != null)
						{
							float num4 = (float)renderer2.pixelWidth * 0.5f;
							Line line = null;
							float x = num4 + num3;
							line._y1 = 120f;
							line._y2 = 120f;
							line._x2 = x;
							float num5 = (float)renderer.pixelWidth * 0.5f;
							float x2 = num5 - num3;
							line._x1 = x2;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene3 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
								{
									ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
									List<string> list = new List<string>();
									if (list != null)
									{
										int version = list._version + 1;
										list._version = version;
										string[] items = list._items;
										if (list._items != null)
										{
											if (list._size >= items.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"ReportSlash0001");
											}
											else
											{
												int num6 = list._size + 1;
												list._size = num6;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											int version2 = list._version + 1;
											list._version = version2;
											string[] items2 = list._items;
											if (list._items != null)
											{
												if (list._size >= items2.Length)
												{
													((List<object>)(object)list).AddWithResize((object)"ReportSlash0002");
												}
												else
												{
													int num7 = list._size + 1;
													list._size = num7;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												}
												int version3 = list._version + 1;
												list._version = version3;
												string[] items3 = list._items;
												if (list._items != null)
												{
													if (list._size >= items3.Length)
													{
														((List<object>)(object)list).AddWithResize((object)"ReportSlash0003");
													}
													else
													{
														int num8 = list._size + 1;
														list._size = num8;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													}
													int version4 = list._version + 1;
													list._version = version4;
													string[] items4 = list._items;
													if (list._items != null)
													{
														if (list._size >= items4.Length)
														{
															((List<object>)(object)list).AddWithResize((object)"ReportSlash0004");
														}
														else
														{
															int num9 = list._size + 1;
															list._size = num9;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version5 = list._version + 1;
														list._version = version5;
														string[] items5 = list._items;
														if (list._items != null)
														{
															if (list._size >= items5.Length)
															{
																((List<object>)(object)list).AddWithResize((object)"ReportSlash0005");
															}
															else
															{
																int num10 = list._size + 1;
																list._size = num10;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															if (particleSystemConfig != null)
															{
																particleSystemConfig._frame = list;
																ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(obj + 176);
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f, 1000f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
																particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)(obj + 208);
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(400f, 500f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
																_ = 0;
																particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(90f);
																particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)(obj + 240);
																_ = 0;
																_ = 20;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																particleSystemConfig._quantity = (int?)(object)0;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(3f, 6f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
																particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)(obj + 272);
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 6f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
																particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)(obj + 304);
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.65f, 0.1f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
																obj = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
																_ = 0;
																EmitZone emitZone = new EmitZone();
																emitZone._type = EmitZoneType.Random;
																emitZone._source = line;
																emitZone._overrideRotation = (Vector3?)(object)1;
																particleSystemConfig._emitZone = emitZone;
																_ = 0;
																_ = 1120403456;
																_ = 1;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																particleSystemConfig._frequency = (float?)(object)0;
																_ = 2;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																particleSystemConfig._blendMode = (BlendMode?)(object)0;
																particleSystemConfig._tintRandom = new uint[5] { 16777215u, 16776960u, 16711680u, 16777096u, 16746632u };
																particleSystemConfig._on = true;
																ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
																List<string> list2 = new List<string>();
																if (list2 != null)
																{
																	int version6 = list2._version + 1;
																	list2._version = version6;
																	string[] items6 = list2._items;
																	if (list2._items != null)
																	{
																		if (list2._size >= items6.Length)
																		{
																			((List<object>)(object)list2).AddWithResize((object)"ReportSlash0001");
																		}
																		else
																		{
																			int num11 = list2._size + 1;
																			list2._size = num11;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		int version7 = list2._version + 1;
																		list2._version = version7;
																		string[] items7 = list2._items;
																		if (list2._items != null)
																		{
																			if (list2._size >= items7.Length)
																			{
																				((List<object>)(object)list2).AddWithResize((object)"ReportSlash0002");
																			}
																			else
																			{
																				int num12 = list2._size + 1;
																				list2._size = num12;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			}
																			int version8 = list2._version + 1;
																			list2._version = version8;
																			string[] items8 = list2._items;
																			if (list2._items != null)
																			{
																				if (list2._size >= items8.Length)
																				{
																					((List<object>)(object)list2).AddWithResize((object)"ReportSlash0003");
																				}
																				else
																				{
																					int num13 = list2._size + 1;
																					list2._size = num13;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				int version9 = list2._version + 1;
																				list2._version = version9;
																				string[] items9 = list2._items;
																				if (list2._items != null)
																				{
																					if (list2._size >= items9.Length)
																					{
																						((List<object>)(object)list2).AddWithResize((object)"ReportSlash0004");
																					}
																					else
																					{
																						int num14 = list2._size + 1;
																						list2._size = num14;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					}
																					int version10 = list2._version + 1;
																					list2._version = version10;
																					string[] items10 = list2._items;
																					if (list2._items != null)
																					{
																						if (list2._size >= items10.Length)
																						{
																							((List<object>)(object)list2).AddWithResize((object)"ReportSlash0005");
																						}
																						else
																						{
																							int num15 = list2._size + 1;
																							list2._size = num15;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						}
																						if (particleSystemConfig2 != null)
																						{
																							particleSystemConfig2._frame = list2;
																							ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)(obj + 336);
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(500f, 1000f));
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
																							particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+160]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)(obj + 368);
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(400f, 500f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+170]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+180]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
																							particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
																							_ = 0;
																							minMaxCurve3 = new ParticleSystem.MinMaxCurve(90f);
																							particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)(obj + 400);
																							_ = 0;
																							_ = 4;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																							particleSystemConfig2._quantity = (int?)(object)0;
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(3f, 6f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																							particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)(obj + 432);
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 6f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1C0]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
																							particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
																							_ = 0;
																							ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)(obj + 464);
																							_ = 0;
																							_ = 0;
																							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.65f, 0.1f));
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1D0]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1E0]");
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
																							particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
																							_ = 0;
																							EmitZone emitZone2 = new EmitZone();
																							emitZone2._type = EmitZoneType.Random;
																							emitZone2._source = line;
																							emitZone2._overrideRotation = (Vector3?)(object)1;
																							particleSystemConfig2._emitZone = emitZone2;
																							_ = 0;
																							_ = 1120403456;
																							_ = 1;
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																							particleSystemConfig2._frequency = (float?)(object)0;
																							_ = 1;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+280]");
																							particleSystemConfig2._blendMode = (BlendMode?)(object)0;
																							particleSystemConfig2._tintRandom = new uint[5] { 16777215u, 16776960u, 16711680u, 16777096u, 16746632u };
																							particleSystemConfig2._on = true;
																							Camera main = Camera.main;
																							Transform parent = main.transform;
																							ParticleSystem pfxFireEmitterScreen = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent, "ReactorEmitter Screen");
																							_pfxFireEmitterScreen = pfxFireEmitterScreen;
																							Transform transform = _pfxFireEmitterScreen.transform;
																							object obj3 = default(object);
																							transform.localPosition = (Vector3)(&obj3);
																							nint num16 = (nint)typeof(GM);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1109 @ rax_v117 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
																							nint num17 = 0;
																							bool flag2 = (object)GM.Core == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1110 @ rax_v118+28]");
																							object obj4 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v933 @ rdx_v69+1C]");
																							int num18 = (int)(-3);
																							RenderingExtensions.SetDepth(_pfxFireEmitterScreen, num18);
																							Camera main2 = Camera.main;
																							Transform parent2 = main2.transform;
																							ParticleSystem pfxFireEmitterAdd = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent2, "ReactorEmitter Add");
																							_pfxFireEmitterAdd = pfxFireEmitterAdd;
																							Transform transform2 = _pfxFireEmitterAdd.transform;
																							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																							Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&minMaxCurve3));
																							bool flag4 = (object)GM.Core == null;
																							PhaserScene s_scene4 = ArcadePhysics.s_scene;
																							PhaserScene.Renderer renderer3 = s_scene4._renderer;
																							RenderingExtensions.SetDepth(depth: renderer3.pixelHeight - 3, pfx: _pfxFireEmitterAdd);
																							_ = _pfxFireEmitterScreen;
																							_ = _pfxFireEmitterScreen;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																							object obj5 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																							if ((nint)0 == 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																								bool flag5 = obj5 == null;
																							}
																							object obj6 = obj + 656;
																							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3449 @ rax_v138 (should have been resolved before IL gen)");
																							if ((object)_pfxFireEmitterAdd != null)
																							{
																								_ = _pfxFireEmitterAdd;
																								_ = _pfxFireEmitterAdd;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																								object obj7 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																								if ((nint)0 == 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																									bool flag6 = obj7 == null;
																								}
																								object obj8 = obj + 664;
																								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3526 @ rax_v143 (should have been resolved before IL gen)");
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
		throw new NullReferenceException();
	}

	private void _003ClaunchOffScreen_003Eb__10_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		Sample2Weapon trueWeapon = _trueWeapon;
		trueWeapon._reactorPool.Cleanup();
		_pfxFireEmitterScreen.Stop();
		_pfxFireEmitterAdd.Stop();
	}
}
