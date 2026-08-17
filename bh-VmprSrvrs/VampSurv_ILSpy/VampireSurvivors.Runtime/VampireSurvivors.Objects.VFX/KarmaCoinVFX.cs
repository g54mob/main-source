using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.VFX;

public class KarmaCoinVFX : PoolableMonoBehaviour
{
	private float AngelStartSize;

	private float KarmaCoinDamageDelay;

	public MeshRenderer AngelRenderer;

	public ParticleSystem AngelFeathersFX;

	private float AngelFeathersFXDelay;

	public ParticleSystem HeadsFX;

	public ParticleSystem TailsFX;

	public ParticleSystem FlareFX;

	private float HoldTime;

	private Timer _holdTimer;

	private Timer _karmaTimer;

	private Timer _featherDelayTimer;

	private MultiTargetTween _tweenMaterialAnim;

	private MultiTargetTween _tweenScale;

	public float _animT;

	private Action _callback;

	public void PlaySequence(Action action, float pLuck)
	{
		//IL_02ea: Expected O, but got I8
		//IL_009a: Expected O, but got I4
		//IL_02f8: Expected O, but got F4
		//IL_024c: Expected O, but got I4
		//IL_039e: Expected O, but got I
		//IL_0337: Expected O, but got I
		//IL_0561: Expected I4, but got F4
		//IL_03d6: Expected O, but got I
		//IL_04be: Expected I4, but got F4
		//IL_05b2: Expected I4, but got F4
		//IL_05cb: Expected O, but got I
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_044d: Expected I4, but got F4
		//IL_04d5: Expected O, but got I4
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_01db: Expected O, but got I4
		//IL_010f->IL0460: Incompatible stack heights: 1 vs 0
		//IL_0297->IL0519: Incompatible stack heights: 1 vs 0
		//IL_028c->IL056a: Incompatible stack heights: 1 vs 0
		//IL_02d3->IL0403: Incompatible stack heights: 1 vs 0
		_callback = action;
		object obj = 6603577472L;
		Transform component = AngelRenderer.transform;
		Transform transform = RenderingExtensions.SetScale(component, AngelStartSize);
		_animT = 0f;
		Material material = ((Renderer)AngelRenderer).GetMaterial();
		int num = Shader.PropertyToID("_NormalisedAnim");
		material.SetFloatImpl(num, 0f);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin2, soundConfig, 200f, 1, num2);
		ParticleSystem particleSystem = TailsFX;
		object obj2 = UnityEngine.Random.value;
		float num3 = pLuck * 0.5f;
		float num4 = default(float);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool flag3;
		int num6;
		bool flag4;
		bool flag5;
		object obj11;
		if (num3 > num4)
		{
			particleSystem = HeadsFX;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag = obj3 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v781 @ rax_v86 (should have been resolved before IL gen)");
			Action onComplete = AngelFeathersFX.Play;
			float num5 = AngelFeathersFXDelay + num4;
			Timer featherDelayTimer = Timers.Register(num5, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag2 = (nint)0 == 0;
			_featherDelayTimer = featherDelayTimer;
			num4 = num5;
			flag3 = true;
			num6 = 0;
			if (!flag2)
			{
				object obj4 = this + 128;
				object obj5 = obj4 >> 12;
				object obj6 = obj5 & 0x1FFFFF;
				object obj7 = obj6 >> 6;
				object obj8 = obj6 & 0x3F;
				nint num8;
				do
				{
					object obj9 = 1 << (int)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r15_v1+462E0+v1112 @ rdx_v45*8]");
					object obj10 = 0 | obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r15_v1+462E0+v1112 @ rdx_v45*8]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r15_v1+462E0+v1112 @ rdx_v45*8]");
					if (num7 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r15_v1+462E0+v1112 @ rdx_v45*8]");
					num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r15_v1+462E0+v1112 @ rdx_v45*8]");
				}
				while (num8 != 0);
				particleSystem.Play(withChildren: true);
				num4 = num5;
				flag4 = false;
				flag5 = true;
				obj11 = 0;
				goto IL_038e;
			}
		}
		else
		{
			flag3 = false;
			num6 = 1;
		}
		particleSystem.Play(withChildren: true);
		flag4 = (byte)num6 != 0;
		flag5 = true;
		obj11 = 0;
		if (flag3)
		{
			goto IL_038e;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag6 = obj12 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1044 @ rax_v37 (should have been resolved before IL gen)");
		Action onComplete2 = base.Release;
		Timer timer = Timers.Register(num4, onComplete2, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_038e:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag7 = obj13 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1081 @ rax_v51 (should have been resolved before IL gen)");
		Action onComplete3 = delegate
		{
			//IL_0262: Expected O, but got I4
			//IL_0047: Expected O, but got I4
			//IL_00a1: Expected I, but got O
			//IL_012f: Expected I, but got O
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			soundConfig2.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin3, soundConfig2, 200f, 1, time);
			TweenConfig tweenConfig = new TweenConfig();
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.duration = 500f;
			object[] array = new object[1];
			Transform transform2 = AngelRenderer.transform;
			if ((object)transform2 != null)
			{
				nint num9 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj15 = default(object);
				if (obj15 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			MultiTargetTween tweenScale = Tweens.Add(tweenConfig);
			_tweenScale = tweenScale;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num10 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj16 = default(object);
			if (obj16 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value = default(object);
				bool flag9 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary;
				TweenCallback onUpdate = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Material material2 = ((Renderer)AngelRenderer).GetMaterial();
					int num11 = Shader.PropertyToID("_NormalisedAnim");
					material2.SetFloatImpl(num11, _animT);
				};
				tweenConfig2.onUpdate = onUpdate;
				tweenConfig2.duration = 500f;
				TweenCallback onComplete4 = delegate
				{
					FlareFX.Play(withChildren: true);
					Action onComplete5 = delegate
					{
						//IL_0262: Expected O, but got I4
						//IL_0047: Expected O, but got I4
						//IL_00a1: Expected I, but got O
						//IL_012f: Expected I, but got O
						SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
						soundConfig3.Rate = 1f;
						soundConfig3.Volume = (float?)(object)1;
						float time2 = default(float);
						PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin4, soundConfig3, 200f, 1, time2);
						TweenConfig tweenConfig3 = new TweenConfig();
						tweenConfig3.scale = (float?)(object)1;
						tweenConfig3.duration = 1000f;
						object[] array3 = new object[1];
						Transform transform3 = AngelRenderer.transform;
						if ((object)transform3 != null)
						{
							nint num11 = (nint)array3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj17 = default(object);
							if (obj17 == null)
							{
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig3.targets = array3;
						MultiTargetTween tweenScale2 = Tweens.Add(tweenConfig3);
						_tweenScale = tweenScale2;
						TweenConfig tweenConfig4 = new TweenConfig();
						object[] array4 = new object[1];
						nint num12 = (nint)array4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj18 = default(object);
						if (obj18 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							tweenConfig4.targets = array4;
							Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object value2 = default(object);
							bool flag10 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_animT", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							tweenConfig4.custom = dictionary2;
							TweenCallback onUpdate2 = delegate
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FF]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								Material material2 = ((Renderer)AngelRenderer).GetMaterial();
								int num13 = Shader.PropertyToID("_NormalisedAnim");
								material2.SetFloatImpl(num13, _animT);
							};
							tweenConfig4.onUpdate = onUpdate2;
							tweenConfig4.duration = 1000f;
							TweenCallback onComplete6 = delegate
							{
								Action onComplete7 = base.Release;
								bool useRealTime2 = default(bool);
								MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
								int repeat3 = default(int);
								TimerType type3 = default(TimerType);
								Timer timer2 = Timers.Register(1f, onComplete7, null, isLooped: false, useRealTime2, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
							};
							tweenConfig4.onComplete = onComplete6;
							MultiTargetTween tweenMaterialAnim2 = Tweens.Add(tweenConfig4);
							_tweenMaterialAnim = tweenMaterialAnim2;
							return;
						}
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					};
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer holdTimer2 = Timers.Register(HoldTime, onComplete5, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					_holdTimer = holdTimer2;
				};
				tweenConfig2.onComplete = onComplete4;
				MultiTargetTween tweenMaterialAnim = Tweens.Add(tweenConfig2);
				_tweenMaterialAnim = tweenMaterialAnim;
				return;
			}
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		};
		Timer holdTimer = Timers.Register(num4, onComplete3, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_holdTimer = holdTimer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag8 = obj14 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1335 @ rax_v60 (should have been resolved before IL gen)");
		float duration = num4 + KarmaCoinDamageDelay;
		Timer karmaTimer = Timers.Register(duration, _callback, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_karmaTimer = karmaTimer;
	}

	protected override void OnDestroy()
	{
		if (_featherDelayTimer != null)
		{
			_featherDelayTimer.Cancel();
		}
		if (_karmaTimer != null)
		{
			_karmaTimer.Cancel();
		}
		if (_holdTimer != null)
		{
			_holdTimer.Cancel();
		}
		if (_tweenScale != null)
		{
			_tweenScale.Kill();
		}
		if (_tweenMaterialAnim != null)
		{
			_tweenMaterialAnim.Kill();
		}
	}

	public KarmaCoinVFX()
	{
		//IL_0036: Expected I, but got O
		AngelStartSize = 4f;
		HoldTime = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CPlaySequence_003Eb__16_0()
	{
		//IL_0262: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_00a1: Expected I, but got O
		//IL_012f: Expected I, but got O
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin3, soundConfig, 200f, 1, time);
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 500f;
		object[] array = new object[1];
		Transform transform = AngelRenderer.transform;
		if ((object)transform != null)
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
		MultiTargetTween tweenScale = Tweens.Add(tweenConfig);
		_tweenScale = tweenScale;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num2 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			TweenCallback onUpdate = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Material material = ((Renderer)AngelRenderer).GetMaterial();
				int num3 = Shader.PropertyToID("_NormalisedAnim");
				material.SetFloatImpl(num3, _animT);
			};
			tweenConfig2.onUpdate = onUpdate;
			tweenConfig2.duration = 500f;
			TweenCallback onComplete = delegate
			{
				FlareFX.Play(withChildren: true);
				Action onComplete2 = delegate
				{
					//IL_0262: Expected O, but got I4
					//IL_0047: Expected O, but got I4
					//IL_00a1: Expected I, but got O
					//IL_012f: Expected I, but got O
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					soundConfig2.Rate = 1f;
					soundConfig2.Volume = (float?)(object)1;
					float time2 = default(float);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin4, soundConfig2, 200f, 1, time2);
					TweenConfig tweenConfig3 = new TweenConfig();
					tweenConfig3.scale = (float?)(object)1;
					tweenConfig3.duration = 1000f;
					object[] array3 = new object[1];
					Transform transform2 = AngelRenderer.transform;
					if ((object)transform2 != null)
					{
						nint num3 = (nint)array3;
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
					MultiTargetTween tweenScale2 = Tweens.Add(tweenConfig3);
					_tweenScale = tweenScale2;
					TweenConfig tweenConfig4 = new TweenConfig();
					object[] array4 = new object[1];
					nint num4 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig4.targets = array4;
						Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						object value2 = default(object);
						bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_animT", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig4.custom = dictionary2;
						TweenCallback onUpdate2 = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FF]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							Material material = ((Renderer)AngelRenderer).GetMaterial();
							int num5 = Shader.PropertyToID("_NormalisedAnim");
							material.SetFloatImpl(num5, _animT);
						};
						tweenConfig4.onUpdate = onUpdate2;
						tweenConfig4.duration = 1000f;
						TweenCallback onComplete3 = delegate
						{
							Action onComplete4 = base.Release;
							bool useRealTime2 = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							Timer timer = Timers.Register(1f, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
						};
						tweenConfig4.onComplete = onComplete3;
						MultiTargetTween tweenMaterialAnim2 = Tweens.Add(tweenConfig4);
						_tweenMaterialAnim = tweenMaterialAnim2;
						return;
					}
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				};
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer holdTimer = Timers.Register(HoldTime, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_holdTimer = holdTimer;
			};
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween tweenMaterialAnim = Tweens.Add(tweenConfig2);
			_tweenMaterialAnim = tweenMaterialAnim;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void _003CPlaySequence_003Eb__16_1()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material = ((Renderer)AngelRenderer).GetMaterial();
		int num = Shader.PropertyToID("_NormalisedAnim");
		material.SetFloatImpl(num, _animT);
	}

	private void _003CPlaySequence_003Eb__16_2()
	{
		FlareFX.Play(withChildren: true);
		Action onComplete = delegate
		{
			//IL_0262: Expected O, but got I4
			//IL_0047: Expected O, but got I4
			//IL_00a1: Expected I, but got O
			//IL_012f: Expected I, but got O
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin4, soundConfig, 200f, 1, time);
			TweenConfig tweenConfig = new TweenConfig();
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.duration = 1000f;
			object[] array = new object[1];
			Transform transform = AngelRenderer.transform;
			if ((object)transform != null)
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
			MultiTargetTween tweenScale = Tweens.Add(tweenConfig);
			_tweenScale = tweenScale;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value = default(object);
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary;
				TweenCallback onUpdate = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FF]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Material material = ((Renderer)AngelRenderer).GetMaterial();
					int num3 = Shader.PropertyToID("_NormalisedAnim");
					material.SetFloatImpl(num3, _animT);
				};
				tweenConfig2.onUpdate = onUpdate;
				tweenConfig2.duration = 1000f;
				TweenCallback onComplete2 = delegate
				{
					Action onComplete3 = base.Release;
					bool useRealTime2 = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer timer = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				};
				tweenConfig2.onComplete = onComplete2;
				MultiTargetTween tweenMaterialAnim = Tweens.Add(tweenConfig2);
				_tweenMaterialAnim = tweenMaterialAnim;
				return;
			}
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer holdTimer = Timers.Register(HoldTime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_holdTimer = holdTimer;
	}

	private void _003CPlaySequence_003Eb__16_3()
	{
		//IL_0262: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_00a1: Expected I, but got O
		//IL_012f: Expected I, but got O
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_KarmaCoin4, soundConfig, 200f, 1, time);
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 1000f;
		object[] array = new object[1];
		Transform transform = AngelRenderer.transform;
		if ((object)transform != null)
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
		MultiTargetTween tweenScale = Tweens.Add(tweenConfig);
		_tweenScale = tweenScale;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num2 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			TweenCallback onUpdate = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FF]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Material material = ((Renderer)AngelRenderer).GetMaterial();
				int num3 = Shader.PropertyToID("_NormalisedAnim");
				material.SetFloatImpl(num3, _animT);
			};
			tweenConfig2.onUpdate = onUpdate;
			tweenConfig2.duration = 1000f;
			TweenCallback onComplete = delegate
			{
				Action onComplete2 = base.Release;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			};
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween tweenMaterialAnim = Tweens.Add(tweenConfig2);
			_tweenMaterialAnim = tweenMaterialAnim;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void _003CPlaySequence_003Eb__16_4()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39FF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material = ((Renderer)AngelRenderer).GetMaterial();
		int num = Shader.PropertyToID("_NormalisedAnim");
		material.SetFloatImpl(num, _animT);
	}

	private void _003CPlaySequence_003Eb__16_5()
	{
		Action onComplete = base.Release;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}
}
