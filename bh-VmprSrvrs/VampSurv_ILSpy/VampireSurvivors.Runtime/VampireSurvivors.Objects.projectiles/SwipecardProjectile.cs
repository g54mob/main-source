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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SwipecardProjectile : Projectile
{
	private float _volume;

	private float _timer;

	private int _swipeCounter;

	private int _minimumSwipes;

	private float _swipeSpeed;

	private bool _resettingSwipe;

	private bool _isFinished;

	private List<SfxType> _swipeSounds;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0033: Expected F4, but got I4
		//IL_007d: Expected O, but got I4
		//IL_00ca: Expected I, but got O
		//IL_013d: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_CardOut, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		_isCullable = false;
		_timer = 0f;
		_minimumSwipes = index;
		_swipeSpeed = 1f;
		_resettingSwipe = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setAlpha(0f);
		UpdatePosition();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num2 = _weapon.PArea();
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = PlayRandomSwipe;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			float num3 = (float)((Equipment)weapon)._003CLevel_003Ek__BackingField * 0.03f;
			float volume2 = 0.45f - num3;
			_volume = volume2;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void PlayRandomSwipe()
	{
		//IL_0087: Expected O, but got I4
		//IL_001a: Expected O, but got I
		//IL_0059: Expected F4, but got I4
		List<SfxType> swipeSounds = _swipeSounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		object obj = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		bool flag = (nint)obj >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v11+20+v67 @ rax_v13*4]");
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.None, 500f, 2, 0f, volume, rate, detune, loop, 1f);
	}

	private void UpdatePosition()
	{
		float num = _weapon.PSpeed();
		float2 float5 = base.displaySize;
		Weapon weapon = _weapon;
		float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float7 = default(float2);
		base.position = float7;
	}

	public override void InternalUpdate()
	{
		//IL_0175: Invalid comparison between I4 and F4
		//IL_0246: Expected F4, but got I4
		//IL_0113: Expected F4, but got I4
		//IL_039a: Expected O, but got I4
		//IL_027f: Expected I, but got O
		//IL_01cb: Expected O, but got I
		//IL_02cc: Expected O, but got I4
		//IL_02e8: Expected O, but got I4
		//IL_020a: Expected F4, but got I4
		//IL_0213->IL0349: Incompatible stack heights: 1 vs 0
		//IL_0327->IL03bd: Incompatible stack heights: 1 vs 0
		if (_isFinished)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		if (!_resettingSwipe)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * _swipeSpeed;
			float timer = num2 + _timer;
			_timer = timer;
		}
		else
		{
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * _swipeSpeed;
			float num4 = num3 * 4f;
			if (0f > (_timer -= num4))
			{
				_timer = 0f;
				_resettingSwipe = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				List<SfxType> swipeSounds = _swipeSounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rbx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
				object obj = UnityEngine.Random.RandomRangeInt(0, 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rbx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
				bool flag = (nint)obj >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rbx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rcx_v37+20+v399 @ rax_v48*4]");
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.None, 500f, 2, 0f, volume, rate, detune, loop, 1f);
			}
		}
		UpdatePosition();
		if (!(_timer > 1f))
		{
			return;
		}
		float swipeSpeed = _swipeSpeed * 1.5f;
		int num5 = _swipeCounter + 1;
		_timer = 1f;
		_swipeCounter = num5;
		_swipeSpeed = swipeSpeed;
		if (num5 < _minimumSwipes)
		{
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_CardDeny, 500f, 2, 0f, volume, rate, detune, loop, 1f);
			_resettingSwipe = true;
			return;
		}
		PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_CardAccept, 500f, 5, 0f, volume, rate, detune, loop, 1f);
		_isFinished = true;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num6 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		bool flag2 = obj3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			base.Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public SwipecardProjectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01bf: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_0156: Expected O, but got I
		_volume = 0.45f;
		_swipeSpeed = 1f;
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
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)166);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 166;
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
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)167);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 167;
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
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)168);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 168;
		}
		_swipeSounds = list;
		base._002Ector();
	}

	private void _003CInternalUpdate_003Eb__11_0()
	{
		base.Despawn();
	}
}
