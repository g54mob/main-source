using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_SpawnHigh : EnemyController
{
	private Sequence _onEnterTween;

	private Timer _cullableGraceTimer;

	protected override void OnRecycleEnemy()
	{
		base.OnRecycleEnemy();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (stageData._003CisRacingStage_003Ek__BackingField)
		{
			float2 float5 = base.position;
			float2 float6 = default(float2);
			base.position = float6;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0184: Expected O, but got Ref
		base.InitEnemy(enemyType, asRemote);
		Transform cachedTransform = _cachedTransform;
		base._003CIsCullable_003Ek__BackingField = false;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		Sequence onEnterTween = DOTween.Sequence();
		_onEnterTween = onEnterTween;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.3f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_onEnterTween, (Tween)t, false))
		{
			Sequence sequence = Sequence.DoInsert(_onEnterTween, (Tween)t, 0f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag2 = _onEnterTween == null;
		Action onComplete = delegate
		{
			base._003CIsCullable_003Ek__BackingField = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer cullableGraceTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_cullableGraceTimer = cullableGraceTimer;
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_cullableGraceTimer != null)
		{
			_cullableGraceTimer.Cancel();
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_cullableGraceTimer != null)
		{
			_cullableGraceTimer.Cancel();
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	private void KillTweens()
	{
		if (_cullableGraceTimer != null)
		{
			_cullableGraceTimer.Cancel();
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	private void _003CInitEnemy_003Eb__3_0()
	{
		base._003CIsCullable_003Ek__BackingField = true;
	}
}
