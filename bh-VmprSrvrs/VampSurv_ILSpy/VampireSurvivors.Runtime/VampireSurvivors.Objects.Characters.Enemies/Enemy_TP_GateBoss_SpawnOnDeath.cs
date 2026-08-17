using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_GateBoss_SpawnOnDeath : Enemy_TP_GateBoss
{
	public EnemyType ToSpawnOnDeath;

	public override void Despawn()
	{
		//IL_003d: Expected F4, but got I4
		float2 float5 = base.position;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Salamander, 1000f, 1, 0f, volume, rate, detune, loop, 1f);
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v9+10]");
			if ((nint)0 != 0)
			{
				_ = 257;
				_ = 1;
			}
		}
		if (base.animTimer != null)
		{
			base.animTimer.Cancel();
		}
		if (base.relicDropTimer != null)
		{
			base.relicDropTimer.Cancel();
		}
		if (base.posterTween != null)
		{
			TweenExtensions.Kill(base.posterTween);
		}
		if (scaleTween != null)
		{
			scaleTween.Kill();
		}
		if (base.exploTimer1 != null)
		{
			base.exploTimer1.Cancel();
		}
		if (base.exploTimer2 != null)
		{
			base.exploTimer2.Cancel();
		}
		if (base.deathTimer1 != null)
		{
			base.deathTimer1.Cancel();
		}
		if (base.deathTimer2 != null)
		{
			base.deathTimer2.Cancel();
		}
		if (base.screamTween != null)
		{
			base.screamTween.Kill();
		}
		((EnemyController)this).Despawn();
	}

	protected override void DoDeathAnimation()
	{
		//IL_0074: Expected I, but got O
		//IL_00ca: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_012c: Expected I, but got O
		if (!_isRunningDeathAnimation)
		{
			((EnemyController)this)._003CIsDead_003Ek__BackingField = true;
			_isRunningDeathAnimation = true;
			if (scaleTween != null)
			{
				scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.scaleX = (float?)(object)1;
			float num2 = base.scale;
			tweenConfig.ease = Ease.InOutBounce;
			tweenConfig.duration = 1800f;
			tweenConfig.scaleY = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_GateBoss_SpawnOnDeath>)+3A0]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			scaleTween = multiTargetTween;
		}
	}

	private void SpawnNewEnemy(float2 position)
	{
		//IL_0033: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Salamander, 1000f, 1, 0f, volume, rate, detune, loop, 1f);
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v8+10]");
			if ((nint)0 != 0)
			{
				_ = 257;
				_ = 1;
			}
		}
	}
}
