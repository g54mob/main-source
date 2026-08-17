using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class TP_ADV_MINION_SwarmBat : EnemyController
{
	private TP_ADV_BOSS_PhantomBat phantomBatReference;

	private Tween _fadeTween;

	private bool _isInvulnerable;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1876D6AF0\"");
	}

	private void FadeIn()
	{
		_isInvulnerable = true;
		base._003CSpeed_003Ek__BackingField = 0f;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 0f);
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_EnemyRenderer, 1f, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			base._003CSpeed_003Ek__BackingField = _defaultSpeed;
			_isInvulnerable = false;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_fadeTween = tweenerCore;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		if (!_isInvulnerable)
		{
			base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
		}
	}

	public void SetPhantomBatReference(TP_ADV_BOSS_PhantomBat phantomBat)
	{
		phantomBatReference = phantomBat;
	}

	protected override void Die()
	{
		base.Die();
		TP_ADV_BOSS_PhantomBat tP_ADV_BOSS_PhantomBat = phantomBatReference;
		if ((object)phantomBatReference != null && ((UnityEngine.Object)tP_ADV_BOSS_PhantomBat).m_CachedPtr != (IntPtr)0)
		{
			phantomBatReference.BatInSwarmKilled(this);
		}
	}

	public override void Despawn()
	{
		if (_fadeTween != null)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		base.Despawn();
	}

	private void _003CFadeIn_003Eb__4_0()
	{
		base._003CSpeed_003Ek__BackingField = _defaultSpeed;
		_isInvulnerable = false;
	}
}
