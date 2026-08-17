using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyTheEnderRash : EnemyTheEnder
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		_isImmuneToModification = true;
		base.ShieldTime = 45000f;
		_attacksDurationMultiplier = 0.6f;
		base.InitEnemy(enemyType, asRemote);
	}

	public override void Disappear()
	{
		Die();
	}

	protected override void Die()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0311: Expected O, but got I4
		//IL_0339: Expected O, but got F4
		//IL_00a4: Invalid comparison between F4 and I4
		//IL_0103: Expected O, but got F4
		//IL_01de: Expected O, but got F4
		//IL_03b1->IL027f: Incompatible stack heights: 1 vs 0
		//IL_0112->IL0112: Incompatible stack heights: 1 vs 0
		//IL_0405->IL027f: Incompatible stack heights: 1 vs 0
		//IL_01ee->IL01ee: Incompatible stack heights: 1 vs 0
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		EnemyData currentEnemyData = _currentEnemyData;
		((EnemyController)this)._003CIsDead_003Ek__BackingField = true;
		Vector3 ret;
		float num9 = default(float);
		if (_currentEnemyData != null)
		{
			float num = currentEnemyData._003CdeathKB_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			float num2 = GameManager.EnemySpeed * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
			float num3 = num2 * (float)obj;
			float num4 = num3 * ((EnemyController)this)._003CSlow_003Ek__BackingField;
			float xVel = num4 * (float)_currentDirection;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyTheEnderRash)+1E4]");
			float num6 = num5 * 0f;
			setVelocity(xVel, (float?)(object)1);
			if (_blinkTimeout != null)
			{
				_blinkTimeout.Cancel();
			}
			object obj2 = UnityEngine.Random.value;
			EnemyData currentEnemyData2 = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				float num7 = num6 + 0.5f;
				float num8 = num7 * currentEnemyData2._003Cxp_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				if (!(num8 > 0f))
				{
					goto IL_0112;
				}
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v13 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v13 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)GM.Core != null)
					{
						GM.Core.MakeGem((Vector2)num9, num8);
						num8 = num9;
						goto IL_0112;
					}
				}
			}
		}
		goto IL_027f;
		IL_0112:
		if (_treasure == null)
		{
			goto IL_01ee;
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			int num10 = core._stage.SetTreasureLevelFromChance(_treasure);
			object cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rbx_v12 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rbx_v12 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				if ((object)GM.Core != null)
				{
					TreasureChest treasureChest = GM.Core.MakeTreasure((Vector2)num9, _treasure);
					_treasure = null;
					goto IL_01ee;
				}
			}
		}
		goto IL_027f;
		IL_01ee:
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			_playerOptions.TrackEnemyKill(_enemyType, config);
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			if ((object)_SpriteAnimation != null)
			{
				((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
				DeathScream();
				SpecialDeathAnimation();
				return;
			}
		}
		goto IL_027f;
		IL_027f:
		throw new NullReferenceException();
	}

	protected override void SpecialDeathAnimation()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.duration = 2000f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.ease = Ease.InOutBounce;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}
}
