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

public class Enemy_TP_BrachyuraBoss : Enemy_TP_GateBoss
{
	private PhaserSprite _pincerSpriteL;

	private PhaserSprite _pincerSpriteR;

	private SpriteAnimation _pincerLAnim;

	private SpriteAnimation _pincerRAnim;

	private Vector2 _leftPincerPos;

	private Vector2 _rightPincerPos;

	private Sequence _fadeOutPincersTween;

	private readonly Vector2 _leftOffset;

	private readonly Vector2 _rightOffset;

	protected override void Awake()
	{
		//IL_008d: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_BrachyuraClawL_i", "TP_enemies");
		PhaserSprite phaserSprite = _pincerSpriteL.setFrame(sprite);
		Sprite sprite2 = SpriteManager.GetSprite("TP_BrachyuraClawR_i", "TP_enemies");
		PhaserSprite phaserSprite2 = _pincerSpriteR.setFrame(sprite2);
		PhaserSprite pincerSpriteL = _pincerSpriteL;
		PhaserSprite phaserSprite3 = _pincerSpriteL.setOrigin(pincerSpriteL._originX, (float?)(object)1);
		PhaserSprite pincerSpriteR = _pincerSpriteR;
		PhaserSprite phaserSprite4 = _pincerSpriteR.setOrigin(pincerSpriteR._originX, (float?)(object)1);
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_pincerSpriteL, 1.5f);
		PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_pincerSpriteR, 1f);
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("TP_BrachyuraClawL_i", 1, 3, "TP_enemies", flag);
		List<Sprite> animation2 = SpriteManager.GetAnimation("TP_BrachyuraClawR_i", 1, 3, "TP_enemies", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_pincerLAnim.AddAnimation("idle", animation, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
		_pincerRAnim.AddAnimation("idle", animation2, 8, flag, startRandomFrame, onComplete, autoSetAnimation);
		Tween fadeOutPincersTween = _fadeOutPincersTween;
		if (_fadeOutPincersTween != null && fadeOutPincersTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeOutPincersTween);
		}
		PhaserSprite phaserSprite3 = _pincerSpriteL.setTint(_saveTint);
		PhaserSprite phaserSprite4 = _pincerSpriteR.setTint(_saveTint);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 208 Invalid \"Jump target not found in method: 0x1876AE6D0\"");
		throw new NullReferenceException();
	}

	public override void SetFlipX(bool flip)
	{
	}

	public override void Disappear()
	{
		if (!base._hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			KillGateBoss();
		}
		FadeOutPincers();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1876AE6D0\"");
	}

	protected override void Die()
	{
		if (!base._hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			KillGateBoss();
		}
		FadeOutPincers();
	}

	private unsafe void UpdatePincerTransforms()
	{
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00dd: Expected O, but got I
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0249: Expected O, but got I
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected O, but got Unknown
		//IL_008b->IL0318: Incompatible stack heights: 2 vs 0
		//IL_01f7->IL0318: Incompatible stack heights: 2 vs 0
		//IL_04d3->IL03e0: Incompatible stack heights: 10 vs 2
		//IL_05d6->IL04f7: Incompatible stack heights: 10 vs 2
		if ((object)_EnemyRenderer != null)
		{
			Transform transform = _EnemyRenderer.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = obj2 - 64;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				Transform pincerSpriteL = (Transform)(object)_pincerSpriteL;
				if ((object)_pincerSpriteL != null && ((UnityEngine.Object)pincerSpriteL).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_pincerSpriteL == null)
					{
						goto IL_0318;
					}
					Transform transform2 = _pincerSpriteL.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
					Vector2 leftPincerPos = 0 * _leftOffset;
					_leftPincerPos = leftPincerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_BrachyuraBoss)+3E4]");
					object obj4 = num * 0;
					bool flag3 = (object)transform2 == null;
					_ = 0;
					bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj5 = obj2 - 48;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj5);
					PhaserSprite pincerSpriteL2 = _pincerSpriteL;
					bool flag5 = (object)_pincerSpriteL == null;
					bool flag6 = (object)_EnemyRenderer == null;
					int sortingOrder = _EnemyRenderer.sortingOrder;
					bool flag7 = (object)pincerSpriteL2._spriteRenderer == null;
					int sortingOrder2 = sortingOrder + 1;
					pincerSpriteL2._spriteRenderer.sortingOrder = sortingOrder2;
					object cachedTransform = _cachedTransform;
					bool flag8 = (object)_cachedTransform == null;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rsi_v30 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					object obj6 = obj2 - 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rsi_v30 (System.Object)+10]");
					Transform.get_rotation_Injected((IntPtr)0, out *(Quaternion*)obj6);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
					_ = 0;
					bool flag10 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj7 = obj2 - 48;
					Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)obj7);
				}
				Transform pincerSpriteR = (Transform)(object)_pincerSpriteR;
				if ((object)_pincerSpriteR == null || ((UnityEngine.Object)pincerSpriteR).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)_pincerSpriteR != null)
				{
					Transform transform3 = _pincerSpriteR.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
					Vector2 rightPincerPos = 0 * _rightOffset;
					_rightPincerPos = rightPincerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_BrachyuraBoss)+3EC]");
					object obj8 = num2 * 0;
					bool flag11 = (object)transform3 == null;
					_ = 0;
					bool flag12 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					object obj9 = obj2 - 48;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj9);
					PhaserSprite pincerSpriteR2 = _pincerSpriteR;
					bool flag13 = (object)_pincerSpriteR == null;
					bool flag14 = (object)_EnemyRenderer == null;
					int sortingOrder3 = _EnemyRenderer.sortingOrder;
					bool flag15 = (object)pincerSpriteR2._spriteRenderer == null;
					int sortingOrder4 = sortingOrder3 + 1;
					pincerSpriteR2._spriteRenderer.sortingOrder = sortingOrder4;
					Enemy_TP_BrachyuraBoss cachedTransform2 = (Enemy_TP_BrachyuraBoss)(object)_cachedTransform;
					bool flag16 = (object)_cachedTransform == null;
					_ = 0;
					bool flag17 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					object obj10 = obj2 - 32;
					Transform.get_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Quaternion*)obj10);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
					_ = 0;
					bool flag18 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					object obj11 = obj2 - 48;
					Transform.set_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Quaternion*)obj11);
					return;
				}
			}
		}
		goto IL_0318;
		IL_0318:
		throw new NullReferenceException();
	}

	private void FadeOutPincers()
	{
		Tween fadeOutPincersTween = _fadeOutPincersTween;
		if (_fadeOutPincersTween != null && fadeOutPincersTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeOutPincersTween);
		}
		Sequence fadeOutPincersTween2 = DOTween.Sequence();
		_fadeOutPincersTween = fadeOutPincersTween2;
		Transform target = _pincerSpriteL.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, 0f, 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_fadeOutPincersTween, (Tween)t, false))
		{
			Sequence sequence = Sequence.DoInsert(_fadeOutPincersTween, (Tween)t, 0f);
		}
		Transform target2 = _pincerSpriteR.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target2, 0f, 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_fadeOutPincersTween, (Tween)t2, false))
		{
			Sequence sequence2 = Sequence.DoInsert(_fadeOutPincersTween, (Tween)t2, 0f);
		}
		Sequence fadeOutPincersTween3 = _fadeOutPincersTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		fadeOutPincersTween3.stringId = "DefaultGameTweenId";
	}

	public Enemy_TP_BrachyuraBoss()
	{
		//IL_000f: Expected O, but got I8
		//IL_0020: Expected O, but got I4
		_leftOffset = (Vector2)3205287117L;
		_ = 1056964608;
		_rightOffset = (Vector2)1057803469;
		_ = 1056964608;
		base._002Ector();
	}
}
