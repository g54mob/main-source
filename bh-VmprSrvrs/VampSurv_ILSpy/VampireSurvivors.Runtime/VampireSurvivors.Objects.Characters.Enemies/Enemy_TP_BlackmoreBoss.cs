using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_BlackmoreBoss : Enemy_TP_GateBoss
{
	private PhaserSprite _shadowSprite;

	private SpriteAnimation _shadowAnim;

	private Vector2 _shadowPos;

	private Sequence _fadeOutShadowTween;

	private readonly Vector2 _shadowOffset;

	protected override void Awake()
	{
		//IL_005d: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_Blackmore_Shadow_i", "TP_enemies");
		PhaserSprite phaserSprite = _shadowSprite.setFrame(sprite);
		PhaserSprite shadowSprite = _shadowSprite;
		PhaserSprite phaserSprite2 = _shadowSprite.setOrigin(shadowSprite._originX, (float?)(object)1);
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_shadowSprite, 1.5f);
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("TP_Blackmore_Shadow_i", 1, 5, "TP_enemies", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_shadowAnim.AddAnimation("idle", animation, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
		Tween fadeOutShadowTween = _fadeOutShadowTween;
		if (_fadeOutShadowTween != null && fadeOutShadowTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeOutShadowTween);
		}
		PhaserSprite phaserSprite2 = _shadowSprite.setTint(_saveTint);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 154 Invalid \"Jump target not found in method: 0x1876ADBF0\"");
		throw new NullReferenceException();
	}

	public override void SetFlipX(bool flip)
	{
		PhaserSprite phaserSprite = _shadowSprite.setFlipX(flip);
		base.SetFlipX(flip);
	}

	public override void Disappear()
	{
		if (!base._hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			KillGateBoss();
		}
		FadeOutShadow();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1876ADBF0\"");
	}

	protected override void Die()
	{
		if (!base._hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			KillGateBoss();
		}
		FadeOutShadow();
	}

	private unsafe void UpdatePincerTransforms()
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0172: Expected O, but got I
		//IL_008b->IL0177: Incompatible stack heights: 2 vs 0
		//IL_0177->IL0217: Incompatible stack heights: 10 vs 2
		if ((object)_EnemyRenderer != null)
		{
			Transform transform = _EnemyRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret2);
				Transform shadowSprite = (Transform)(object)_shadowSprite;
				if ((object)_shadowSprite == null || ((UnityEngine.Object)shadowSprite).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)_shadowSprite != null)
				{
					Transform transform2 = _shadowSprite.transform;
					Vector2 shadowPos = ret2 * _shadowOffset;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_BlackmoreBoss)+3CC]");
					object obj2 = default(object);
					object obj = obj2 * 0;
					_shadowPos = shadowPos;
					bool flag3 = (object)transform2 == null;
					bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
					object cachedTransform = _cachedTransform;
					bool flag5 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rsi_v19 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rsi_v19 (System.Object)+10]");
					Transform.get_rotation_Injected((IntPtr)0, out *(Quaternion*)(&ret2));
					bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)(&ret));
					Transform shadowSprite2 = (Transform)(object)_shadowSprite;
					bool flag8 = (object)_shadowSprite == null;
					bool flag9 = (object)_EnemyRenderer == null;
					int sortingOrder = _EnemyRenderer.sortingOrder;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rdi_v19 (UnityEngine.Transform)+28]");
					bool flag10 = (nint)0 == 0;
					int sortingOrder2 = sortingOrder - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rdi_v19 (UnityEngine.Transform)+28]");
					((Renderer)0).sortingOrder = sortingOrder2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOutShadow()
	{
		Tween fadeOutShadowTween = _fadeOutShadowTween;
		if (_fadeOutShadowTween != null && fadeOutShadowTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeOutShadowTween);
		}
		Sequence fadeOutShadowTween2 = DOTween.Sequence();
		_fadeOutShadowTween = fadeOutShadowTween2;
		Transform target = _shadowSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, 0f, 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_fadeOutShadowTween, (Tween)t, false))
		{
			Sequence sequence = Sequence.DoInsert(_fadeOutShadowTween, (Tween)t, 0f);
		}
		Sequence fadeOutShadowTween3 = _fadeOutShadowTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		fadeOutShadowTween3.stringId = "DefaultGameTweenId";
	}

	public Enemy_TP_BlackmoreBoss()
	{
		//IL_000b: Expected O, but got I4
		_shadowOffset = (Vector2)0;
		base._002Ector();
	}
}
