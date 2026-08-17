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

public class HeartRefreshVFX : PoolableMonoBehaviour
{
	public MeshRenderer _banner;

	public ParticleSystem _flash;

	public ParticleSystem _HeartVfx;

	public float _animT;

	private MultiTargetTween _tween;

	private Timer _flashTimer;

	private void Start()
	{
		ParticleSystem flash = _flash;
		int cycleCount = default(int);
		if ((object)_flash != null && ((UnityEngine.Object)flash).m_CachedPtr != (IntPtr)0)
		{
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"blur128");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			RenderingExtensions.SetFrames(_flash, list, "vfx", clearExistingFrames: true, cycleCount);
		}
		ParticleSystem heartVfx = _HeartVfx;
		if ((object)_HeartVfx != null && ((UnityEngine.Object)heartVfx).m_CachedPtr != (IntPtr)0)
		{
			List<string> list2 = new List<string>();
			int version2 = list2._version + 1;
			list2._version = version2;
			string[] items2 = list2._items;
			if (list2._size >= items2.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"HeartRefresh");
			}
			else
			{
				int size2 = list2._size + 1;
				list2._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			RenderingExtensions.SetFrames(_HeartVfx, list2, "ThosePeople", clearExistingFrames: true, cycleCount);
		}
	}

	public void PlaySequence()
	{
		//IL_01d0: Expected O, but got I4
		//IL_0098: Expected I, but got O
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_HeartRefresh3, soundConfig, 500f, 1, time);
		_animT = 0f;
		Material material = ((Renderer)_banner).GetMaterial();
		int num = Shader.PropertyToID("_NormalisedAnim");
		material.SetFloatImpl(num, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			TweenCallback onUpdate = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39F2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Material material2 = ((Renderer)_banner).GetMaterial();
				int num3 = Shader.PropertyToID("_NormalisedAnim");
				material2.SetFloatImpl(num3, _animT);
			};
			tweenConfig.onUpdate = onUpdate;
			tweenConfig.duration = 1000f;
			TweenCallback onComplete = delegate
			{
				//IL_0071: Expected O, but got I
				_flash.Play(withChildren: true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj2 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v193 @ rax_v11 (should have been resolved before IL gen)");
				Action onComplete2 = delegate
				{
					//IL_0027: Expected I, but got O
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					if ((object)this != null)
					{
						nint num3 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj3 = default(object);
						if (obj3 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig2.targets = array2;
					Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value2 = default(object);
					bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_animT", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig2.custom = dictionary2;
					TweenCallback onUpdate2 = delegate
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39F5]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						Material material2 = ((Renderer)_banner).GetMaterial();
						int num4 = Shader.PropertyToID("_NormalisedAnim");
						material2.SetFloatImpl(num4, _animT);
					};
					tweenConfig2.onUpdate = onUpdate2;
					tweenConfig2.duration = 1000f;
					TweenCallback onComplete3 = base.Release;
					tweenConfig2.onComplete = onComplete3;
					MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
					_tween = tween2;
				};
				float duration = default(float);
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer flashTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_flashTimer = flashTimer;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween = tween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected override void OnDestroy()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_flashTimer != null)
		{
			_flashTimer.Cancel();
		}
	}

	public HeartRefreshVFX()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CPlaySequence_003Eb__7_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39F2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material = ((Renderer)_banner).GetMaterial();
		int num = Shader.PropertyToID("_NormalisedAnim");
		material.SetFloatImpl(num, _animT);
	}

	private void _003CPlaySequence_003Eb__7_1()
	{
		//IL_0071: Expected O, but got I
		_flash.Play(withChildren: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v193 @ rax_v11 (should have been resolved before IL gen)");
		Action onComplete = delegate
		{
			//IL_0027: Expected I, but got O
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)this != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			TweenCallback onUpdate = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39F5]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Material material = ((Renderer)_banner).GetMaterial();
				int num2 = Shader.PropertyToID("_NormalisedAnim");
				material.SetFloatImpl(num2, _animT);
			};
			tweenConfig.onUpdate = onUpdate;
			tweenConfig.duration = 1000f;
			TweenCallback onComplete2 = base.Release;
			tweenConfig.onComplete = onComplete2;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween = tween;
		};
		float duration = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer flashTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_flashTimer = flashTimer;
	}

	private void _003CPlaySequence_003Eb__7_2()
	{
		//IL_0027: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_animT", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		TweenCallback onUpdate = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39F5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Material material = ((Renderer)_banner).GetMaterial();
			int num2 = Shader.PropertyToID("_NormalisedAnim");
			material.SetFloatImpl(num2, _animT);
		};
		tweenConfig.onUpdate = onUpdate;
		tweenConfig.duration = 1000f;
		TweenCallback onComplete = base.Release;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween = tween;
	}

	private void _003CPlaySequence_003Eb__7_3()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A39F5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material = ((Renderer)_banner).GetMaterial();
		int num = Shader.PropertyToID("_NormalisedAnim");
		material.SetFloatImpl(num, _animT);
	}
}
