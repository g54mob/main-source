using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSigma : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__6_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnDeath_003Eb__6_1()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory2, soundConfig, 0f, 10, time);
		}
	}

	public override bool NeedsCart => false;

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e1: Expected O, but got Ref
		//IL_01fb: Expected native int or pointer, but got O
		//IL_001b: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		//IL_0075: Expected native int or pointer, but got O
		//IL_0213: Expected O, but got Ref
		//IL_022e: Expected O, but got Ref
		//IL_0173: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_019d: Expected O, but got I
		//IL_01b8: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.MakeLevelOne();
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		ParticleSystem particleSystem = RenderingExtensions.SetAngle(_damageVfx, minMaxCurve2);
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		object obj3 = default(object);
		if ((nint)0 == 0)
		{
			float num = (float)obj3 * 0.001f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			if ((nint)0 == 3)
			{
				float num2 = (float)obj3 * 0.001f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-1D]");
				float num3 = 0f * 0.001f;
			}
		}
		_ = _damageVfx;
		ParticleSystem.MinMaxCurve gravityModifier = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 55));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		_ = _damageVfx;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->gravityModifier = gravityModifier;
		ParticleSystem particleSystem2 = RenderingExtensions.SetTint(_damageVfx, 16777147u);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		particleSystemConfig._002Ector("vfx");
		_ = 1;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		RenderingExtensions.SetCollisionBounds(_damageVfx, particleSystemConfig);
	}

	public override void LevelUp()
	{
		//IL_00e6: Expected O, but got I4
		base.LevelUp();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager = core2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if (num <= 0)
		{
			return;
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		if (config2._003CSelectedMazzo_003Ek__BackingField)
		{
			object obj = base._level - 2;
			if ((nint)obj <= 1 || base._level == 77 || base._level == 108)
			{
				GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
			}
		}
	}

	protected override void OnStop()
	{
	}

	public override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
	{
		//IL_01ae: Expected O, but got I4
		//IL_01ca: Expected O, but got F4
		//IL_01f7: Expected O, but got F4
		//IL_00f5: Expected F4, but got I4
		//IL_0115: Expected O, but got I4
		//IL_0205: Expected O, but got F4
		//IL_0246: Expected F4, but got I4
		//IL_024f->IL0128: Incompatible stack heights: 1 vs 0
		if (_receivingDamage)
		{
			return;
		}
		Action onComplete = delegate
		{
			_receivingDamage = false;
			if (!_isInvul)
			{
				base.RestoreTint();
			}
			_damageVfx.Stop();
		};
		float duration = vulnerabilityDelay * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer blinkTimeoutTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_blinkTimeoutTimer = blinkTimeoutTimer;
		if (playDamageFx)
		{
			if ((object)_damageVfx != null)
			{
				Transform transform = _damageVfx.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					PlayDamageParticleFX();
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Rate = 1f
					};
					object obj = UnityEngine.Random.value;
					object obj2 = default(object);
					float num = (float)obj2 * 500f;
					float num2 = num + 1000f;
					((Delegate)(object)soundConfig).m_target = num2;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, flag ? 1 : 0);
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Rate = 1f
					};
					object obj3 = UnityEngine.Random.value;
					float num3 = num2 * -500f;
					float num4 = num3 - 500f;
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LossSFX, soundConfig2, 450f, 1, flag ? 1 : 0);
					goto IL_0128;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_0128;
		IL_0128:
		_receivingDamage = true;
	}

	public unsafe override void OnDeath()
	{
		//IL_07cc: Expected I, but got O
		//IL_010a: Expected O, but got I
		//IL_017f: Expected I, but got O
		//IL_0205: Expected O, but got I4
		//IL_02a9: Expected I, but got O
		//IL_0313: Expected O, but got I4
		//IL_03dc: Expected I, but got O
		//IL_0446: Expected O, but got I4
		//IL_0501: Expected I, but got O
		//IL_0595: Expected O, but got I4
		//IL_06ea->IL0674: Incompatible stack heights: 1 vs 0
		//IL_0129->IL0674: Incompatible stack heights: 2 vs 0
		//IL_0155->IL0674: Incompatible stack heights: 2 vs 0
		//IL_01c4->IL0674: Incompatible stack heights: 2 vs 0
		//IL_01a2->IL01a2: Incompatible stack heights: 3 vs 2
		//IL_0253->IL0674: Incompatible stack heights: 2 vs 0
		//IL_027f->IL0674: Incompatible stack heights: 2 vs 0
		//IL_02ee->IL0674: Incompatible stack heights: 2 vs 0
		//IL_02cc->IL02cc: Incompatible stack heights: 3 vs 2
		//IL_0386->IL0674: Incompatible stack heights: 2 vs 0
		//IL_03b2->IL0674: Incompatible stack heights: 2 vs 0
		//IL_0421->IL0674: Incompatible stack heights: 2 vs 0
		//IL_03ff->IL03ff: Incompatible stack heights: 3 vs 2
		//IL_04ab->IL0674: Incompatible stack heights: 2 vs 0
		//IL_04d7->IL0674: Incompatible stack heights: 2 vs 0
		//IL_0546->IL0674: Incompatible stack heights: 2 vs 0
		//IL_0524->IL0524: Incompatible stack heights: 3 vs 2
		if (_regenTimer != null)
		{
			_regenTimer.Cancel();
		}
		if (_blinkTimeoutTimer != null)
		{
			_blinkTimeoutTimer.Cancel();
		}
		if ((object)_CharacterRenderer != null)
		{
			((Renderer)_CharacterRenderer).Internal_GetPropertyBlock(_propBlock);
			MaterialPropertyBlock propBlock = _propBlock;
			if (_propBlock != null)
			{
				bool flag = propBlock.m_Ptr == (IntPtr)0;
				Color value = default(Color);
				MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, RenderingExtensions.TintFillColor, ref value);
				RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: true);
				MaterialPropertyBlock characterRenderer = (MaterialPropertyBlock)(object)_CharacterRenderer;
				if ((object)_CharacterRenderer != null)
				{
					MaterialPropertyBlock propBlock2 = _propBlock;
					bool flag2 = characterRenderer.m_Ptr == (IntPtr)0;
					bool flag3 = _propBlock == null;
					MaterialPropertyBlock materialPropertyBlock = null;
					if (!flag3)
					{
						materialPropertyBlock = (MaterialPropertyBlock)(nint)propBlock2.m_Ptr;
					}
					Renderer.Internal_SetPropertyBlock_Injected(characterRenderer.m_Ptr, (IntPtr)materialPropertyBlock);
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if ((object)_CharacterRenderer != null)
					{
						Transform transform = _CharacterRenderer.transform;
						if (array != null)
						{
							if ((object)transform != null)
							{
								nint num = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								bool flag4 = obj == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.duration = 750f;
								tweenConfig.ease = Ease.Linear;
								tweenConfig.scaleX = (float?)(object)1;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if ((object)_CharacterRenderer != null)
								{
									Transform transform2 = _CharacterRenderer.transform;
									if (array2 != null)
									{
										if ((object)transform2 != null)
										{
											nint num2 = (nint)array2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj2 = default(object);
											bool flag5 = obj2 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig2 != null)
										{
											tweenConfig2.targets = array2;
											tweenConfig2.scaleX = (float?)(object)1;
											tweenConfig2.delay = 750f;
											tweenConfig2.duration = 100f;
											tweenConfig2.ease = Ease.Linear;
											MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
											TweenConfig tweenConfig3 = new TweenConfig();
											object[] array3 = new object[1];
											if ((object)_CharacterRenderer != null)
											{
												Transform transform3 = _CharacterRenderer.transform;
												if (array3 != null)
												{
													if ((object)transform3 != null)
													{
														nint num3 = (nint)array3;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj3 = default(object);
														bool flag6 = obj3 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig3 != null)
													{
														tweenConfig3.targets = array3;
														tweenConfig3.scaleY = (float?)(object)1;
														tweenConfig3.duration = 750f;
														tweenConfig3.ease = Ease.Linear;
														MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
														TweenConfig tweenConfig4 = new TweenConfig();
														object[] array4 = new object[1];
														if ((object)_CharacterRenderer != null)
														{
															Transform transform4 = _CharacterRenderer.transform;
															if (array4 != null)
															{
																if ((object)transform4 != null)
																{
																	nint num4 = (nint)array4;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj4 = default(object);
																	bool flag7 = obj4 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig4 != null)
																{
																	tweenConfig4.targets = array4;
																	tweenConfig4.delay = 750f;
																	tweenConfig4.duration = 100f;
																	tweenConfig4.ease = Ease.Linear;
																	tweenConfig4.scaleY = (float?)(object)1;
																	TweenCallback onStart = _003C_003Ec._003C_003E9__6_1;
																	if (_003C_003Ec._003C_003E9__6_1 == null)
																	{
																		onStart = (_003C_003Ec._003C_003E9__6_1 = delegate
																		{
																			//IL_003d: Expected O, but got I4
																			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																			soundConfig.Volume = (float?)(object)1;
																			soundConfig.Rate = 1f;
																			float time = default(float);
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory2, soundConfig, 0f, 10, time);
																		});
																	}
																	tweenConfig4.onStart = onStart;
																	MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
																	bool flag8 = (object)_damageVfx == null;
																	Transform transform5 = _damageVfx.transform;
																	bool flag9 = (object)transform5 == null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v90 (UnityEngine.Transform)+10]");
																	bool flag10 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v90 (UnityEngine.Transform)+10]");
																	Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
																	bool flag11 = (object)_damageVfx == null;
																	_damageVfx.Play(withChildren: true);
																	Action onComplete = delegate
																	{
																		_damageVfx.Stop();
																	};
																	bool useRealTime = default(bool);
																	MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																	int repeat = default(int);
																	TimerType type = default(TimerType);
																	Timer timer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																	base.ScheduleDeathConsequences();
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
		throw new NullReferenceException();
	}

	private void _003COnGetDamaged_003Eb__5_0()
	{
		_receivingDamage = false;
		if (!_isInvul)
		{
			base.RestoreTint();
		}
		_damageVfx.Stop();
	}

	private void _003COnDeath_003Eb__6_0()
	{
		_damageVfx.Stop();
	}
}
