using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TrainHazardProjectile : Projectile
{
	private ParticleSystem _pfxEmitter;

	private float _defaultSpeed;

	private Timer _expireTimer;

	private Timer _soundEvent;

	private PhaserSprite _lightSprite;

	protected override void Awake()
	{
		//IL_0044: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		base.Awake();
		_defaultSpeed = _speed;
		GeneratePfx();
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite lightSprite = instance.AddPhaserSprite(pos, "vfx", "TrainLight");
		_lightSprite = lightSprite;
		PhaserSprite phaserSprite = _lightSprite.setOrigin(0f, (float?)(object)1);
		PhaserSprite phaserSprite2 = _lightSprite.setScale(2.35f, (float?)(object)1);
		PhaserSprite phaserSprite3 = _lightSprite.setBlendMode(BlendMode.Screen);
		PhaserSprite phaserSprite4 = _lightSprite.setVisible(visible: false);
	}

	public override void Despawn()
	{
		base.Despawn();
		PhaserSprite phaserSprite = _lightSprite.setVisible(visible: false);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0044: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_02a9: Expected F4, but got I4
		//IL_01ce: Expected F4, but got I4
		//IL_036e: Expected O, but got I4
		//IL_0377: Expected F4, but got I4
		//IL_03c7: Expected O, but got I4
		//IL_04d8: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		bool visible;
		string spriteName;
		if (index <= 0)
		{
			visible = true;
			spriteName = "Trains_03";
		}
		else
		{
			int num = index & 1;
			bool flag = num == 0;
			object obj = !flag;
			spriteName = "Trains_01";
			if (obj == null)
			{
				spriteName = "Trains_02";
			}
			visible = false;
		}
		PhaserSprite phaserSprite = _lightSprite.setVisible(visible);
		Sprite sprite = SpriteManager.GetSprite(spriteName, "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setOrigin(0.25f, (float?)(object)1);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config2 = core._playerOptions.Config;
			if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config3 = core2._playerOptions.Config;
		float num2;
		if (config3._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config4 = core2._playerOptions.Config;
			if (config4._003CVisuallyInvertStages_003Ek__BackingField)
			{
				num2 = 0f;
				goto IL_01e1;
			}
		}
		num2 = 66f;
		goto IL_01e1;
		IL_05b2:
		PhaserSprite lightSprite;
		float originX;
		float? originY;
		PhaserSprite phaserSprite2 = lightSprite.setOrigin(originX, originY);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num3 = _weapon.PDuration();
		Action onComplete = delegate
		{
			_isCullable = true;
		};
		float duration = num2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if (index <= 0)
		{
			PlaySounds();
			return;
		}
		if (_soundEvent != null)
		{
			_soundEvent.Cancel();
		}
		Action onComplete2 = delegate
		{
			PlaySounds();
		};
		object obj2 = _indexInWeapon * 300;
		float duration2 = (float)obj2 * 0.001f;
		Timer soundEvent = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_soundEvent = soundEvent;
		return;
		IL_0588:
		float projectileSpeed = base.ProjectileSpeed;
		float rotation;
		Vector2 vector = SetVelocityFromRotation(rotation, num2);
		GameManager core3 = GM.Core;
		PlayerOptionsData config5 = core3._playerOptions.Config;
		if (config5._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config6 = core3._playerOptions.Config;
			if (config6._003CVisuallyInvertStages_003Ek__BackingField)
			{
				base.angle = 180f;
				ArcadeSprite arcadeSprite4 = setFlipX(flipX: false);
				PhaserSprite phaserSprite3 = _lightSprite.setFlipX(flipX: true);
				lightSprite = _lightSprite;
				originY = (float?)(object)1;
				originX = 1f;
				goto IL_05b2;
			}
		}
		base.angle = 0f;
		ArcadeSprite arcadeSprite5 = setFlipX(flipX: false);
		PhaserSprite phaserSprite4 = _lightSprite.setFlipX(flipX: false);
		lightSprite = _lightSprite;
		originY = (float?)(object)1;
		originX = 0f;
		goto IL_05b2;
		IL_01e1:
		BaseBody baseBody = body.setCircle(56f, (float?)(object)1, (float?)(object)1);
		_speed = _defaultSpeed;
		SetDepths();
		GameManager core4 = GM.Core;
		PlayerOptionsData config7 = core4._playerOptions.Config;
		if (config7._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config8 = core4._playerOptions.Config;
			if (config8._003CVisuallyInvertStages_003Ek__BackingField)
			{
				rotation = (float)Math.PI;
				goto IL_0588;
			}
		}
		rotation = 0f;
		goto IL_0588;
	}

	public void PlaySounds()
	{
		//IL_009b: Expected O, but got F4
		//IL_00ed: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 + 0.5f;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		float detune = num * -100f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 300f, 2, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		float detune2 = num * -2000f;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = detune2;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Brakes, soundConfig2, 300f, 2, time);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004d: Expected O, but got I
		//IL_0116: Expected O, but got I4
		//IL_00a1: Expected O, but got I
		//IL_0442: Expected O, but got Ref
		//IL_0463: Expected I, but got O
		//IL_04bf: Expected O, but got Ref
		//IL_01ae: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_0280: Expected O, but got I
		//IL_02d4: Expected O, but got I
		//IL_03da->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0037->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0069->IL0330: Incompatible stack heights: 1 vs 0
		//IL_00bd->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0519->IL0330: Incompatible stack heights: 5 vs 0
		//IL_0198->IL0330: Incompatible stack heights: 5 vs 0
		//IL_01ca->IL0330: Incompatible stack heights: 5 vs 0
		//IL_0540->IL0330: Incompatible stack heights: 5 vs 0
		//IL_021e->IL0330: Incompatible stack heights: 5 vs 0
		//IL_026a->IL0330: Incompatible stack heights: 5 vs 0
		//IL_029c->IL0330: Incompatible stack heights: 5 vs 0
		//IL_055f->IL0330: Incompatible stack heights: 5 vs 0
		//IL_02f0->IL0330: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		float deltaTime = PauseSystem.DeltaTime;
		float speed = deltaTime + _speed;
		_speed = speed;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Transform core = (Transform)(object)GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v11 (UnityEngine.Transform)+90]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v11 (UnityEngine.Transform)+90]");
					PlayerOptionsData config = ((PlayerOptions)0).Config;
					if (config != null)
					{
						if (config._003CSelectedInverse_003Ek__BackingField)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdi_v11 (UnityEngine.Transform)+90]");
							PlayerOptionsData config2 = ((PlayerOptions)0).Config;
							if (config2 == null)
							{
								goto IL_0330;
							}
							if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
							{
							}
						}
						Transform pfxEmitter = (Transform)(object)_pfxEmitter;
						_ = 0;
						_ = 1;
						_ = 1;
						bool flag2 = (object)_pfxEmitter == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						obj = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						bool flag3 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
						ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj3, 1);
						nint num = (nint)_pfxEmitter;
						_ = 0;
						_ = 1;
						_ = 1;
						bool flag4 = (object)_pfxEmitter == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rsi_v12 (System.IntPtr)+10]");
						bool flag5 = (nint)0 == 0;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rsi_v12 (System.IntPtr)+10]");
						ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj4, 1);
						float2 float5 = base.position;
						float2 float6 = base.position;
						Transform core2 = (Transform)(object)GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v15 (UnityEngine.Transform)+90]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v15 (UnityEngine.Transform)+90]");
								PlayerOptionsData config3 = ((PlayerOptions)0).Config;
								if (config3 != null)
								{
									if (config3._003CSelectedInverse_003Ek__BackingField)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v15 (UnityEngine.Transform)+90]");
										PlayerOptionsData config4 = ((PlayerOptions)0).Config;
										if (config4 == null)
										{
											goto IL_0330;
										}
										if (!config4._003CVisuallyInvertStages_003Ek__BackingField)
										{
										}
									}
									Transform core3 = (Transform)(object)GM.Core;
									if ((object)GM.Core != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdi_v17 (UnityEngine.Transform)+90]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdi_v17 (UnityEngine.Transform)+90]");
											PlayerOptionsData config5 = ((PlayerOptions)0).Config;
											if (config5 != null)
											{
												if (config5._003CSelectedInverse_003Ek__BackingField)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdi_v17 (UnityEngine.Transform)+90]");
													PlayerOptionsData config6 = ((PlayerOptions)0).Config;
													if (config6 == null)
													{
														goto IL_0330;
													}
													if (!config6._003CVisuallyInvertStages_003Ek__BackingField)
													{
													}
												}
												if ((object)_lightSprite != null)
												{
													float2 float7 = default(float2);
													PhaserSprite phaserSprite = _lightSprite.setPosition(float7);
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
		goto IL_0330;
		IL_0330:
		throw new NullReferenceException();
	}

	private void SetDepths()
	{
		//IL_0147: Expected O, but got I4
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected I4, but got Unknown
		//IL_0188->IL00cb: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
					if ((object)_renderer != null)
					{
						int sortingOrder = default(int);
						_renderer.sortingOrder = sortingOrder;
						Renderer renderer2 = _renderer;
						if ((object)_renderer != null)
						{
							bool flag = ((UnityEngine.Object)renderer2).m_CachedPtr == (IntPtr)0;
							object obj = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)renderer2).m_CachedPtr);
							int num = obj - 1;
							RenderingExtensions.SetDepth(_pfxEmitter, num);
							int num2 = base.depth;
							if ((object)_lightSprite != null)
							{
								int num3 = num2 + 100;
								PhaserSprite phaserSprite = _lightSprite.setDepth(num3);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GeneratePfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00ec: Expected native int or pointer, but got O
		//IL_0106: Expected O, but got I
		//IL_0126: Expected O, but got Ref
		//IL_0140: Expected native int or pointer, but got O
		//IL_0281: Expected O, but got I4
		//IL_0165: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01bb: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_02bb: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-61]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}

	private void _003CInitProjectile_003Eb__7_0()
	{
		_isCullable = true;
	}

	private void _003CInitProjectile_003Eb__7_1()
	{
		PlaySounds();
	}
}
