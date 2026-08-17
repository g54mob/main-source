using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMinHealth : EnemyController
{
	private Sequence _onEnterTween;

	private int _lives = 1;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_023d: Expected O, but got Ref
		//IL_013b: Invalid comparison between F4 and I4
		//IL_0154: Expected F4, but got I4
		//IL_010f: Expected I4, but got O
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected I4, but got Unknown
		//IL_0198: Expected F4, but got I4
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		base.InitEnemy(enemyType, asRemote);
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		Sequence onEnterTween = DOTween.Sequence();
		_onEnterTween = onEnterTween;
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 0.3f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_onEnterTween, (Tween)t, false))
		{
			Sequence sequence = Sequence.DoInsert(_onEnterTween, (Tween)t, 0f);
		}
		Sequence onEnterTween2 = _onEnterTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		onEnterTween2.stringId = "DefaultGameTweenId";
		EnemyData currentEnemyData = _currentEnemyData;
		if ((object)currentEnemyData._003Clives_003Ek__BackingField != null)
		{
			if ((object)currentEnemyData._003Clives_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			int lives = (object?)currentEnemyData._003Clives_003Ek__BackingField >> 32;
			_lives = lives;
		}
		float num = (float)_lives * currentEnemyData._003CmaxHp_003Ek__BackingField;
		if (num > _maxHp)
		{
			_maxHp = num;
		}
		GameManager core = GM.Core;
		bool flag = core._003CSurvivedSeconds_003Ek__BackingField == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018773505Bh\"");
		float num2 = 0f;
		if (!flag)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			int num3 = (int)(config._003CRunEnemies_003Ek__BackingField / core._003CSurvivedSeconds_003Ek__BackingField);
			num2 = num3;
		}
		if (!(1f > num2))
		{
			object obj = 1f & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_02b4;
			}
		}
		num2 = 1f;
		goto IL_02b4;
		IL_02b4:
		_hp = (_maxHp = num2 * _maxHp);
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}
}
