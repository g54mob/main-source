using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPile1 : EnemyController
{
	private float _fireTime;

	protected EnemyType _bulletType = EnemyType.BULLET_1;

	private Sequence _onEnterTween;

	private Tween _onFireTimer;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0057: Expected I4, but got O
		//IL_04b1: Expected I, but got O
		//IL_04ee: Expected O, but got Ref
		//IL_0527: Expected O, but got I4
		//IL_00c2: Expected F4, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_0147: Expected F4, but got I4
		//IL_0150: Expected O, but got I4
		//IL_017f: Expected F4, but got I4
		//IL_0188: Expected O, but got I4
		//IL_0262: Expected F4, but got O
		//IL_0550: Expected I, but got O
		base.InitEnemy(enemyType, asRemote);
		float num;
		if (!(GameManager.EnemySpeed > 0.231f))
		{
			num = 2000f;
		}
		else
		{
			float num2 = GameManager.EnemySpeed - 0.231f;
			float num3 = num2 * 2000f;
			num = 2000f - num3;
		}
		base._003CSpeed_003Ek__BackingField = num;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v2 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v2 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			EnemyData currentEnemyData = _currentEnemyData;
			_fireTime = 0f;
			EnemyType bulletType = (((object)currentEnemyData._003CbulletType_003Ek__BackingField == null) ? EnemyType.BULLET_1 : ((EnemyType)((object?)currentEnemyData._003CbulletType_003Ek__BackingField >> 32)));
			_bulletType = bulletType;
			if (_onEnterTween != null)
			{
				TweenExtensions.Kill(_onEnterTween);
			}
			Sequence onEnterTween = DOTween.Sequence();
			_onEnterTween = onEnterTween;
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float val = 0f * _scaleMul;
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 0.3f);
			bool flag = TweenSettingsExtensions.ValidateAddToSequence(_onEnterTween, (Tween)t, false);
			bool flag2 = !flag;
			float num6 = 0.3f;
			object obj = 0;
			if (!flag2)
			{
				Sequence sequence = Sequence.DoInsert(_onEnterTween, (Tween)t, 0f);
				num6 = 0f;
				obj = 0;
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyPile1)(object)dOSetter)._003CInitEnemy_003Eb__4_1(val);
			TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter, dOSetter, 0f, 0.3f);
			bool flag3 = TweenSettingsExtensions.ValidateAddToSequence(_onEnterTween, (Tween)t2, false);
			bool flag4 = !flag3;
			float num7 = 0f;
			object obj2 = 0;
			if (!flag4)
			{
				Sequence sequence2 = Sequence.DoInsert(_onEnterTween, (Tween)t2, 0f);
				num7 = 0f;
				obj2 = 0;
			}
			Sequence onEnterTween2 = _onEnterTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			onEnterTween2.stringId = "DefaultGameTweenId";
			if (_onFireTimer != null)
			{
				TweenExtensions.Kill(_onFireTimer);
			}
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((EnemyPile1)(object)dOSetter2)._003CInitEnemy_003Eb__4_3(val);
			float num8 = FireDelay();
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter2, dOSetter2, 1f, (float)Vector3.oneVector);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyPile1>)+4C0]");
			TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
			nint num9 = (nint)this;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_onFireTimer = tweenerCore;
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_onFireTimer != null)
		{
			TweenExtensions.Kill(_onFireTimer);
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_onFireTimer != null)
		{
			TweenExtensions.Kill(_onFireTimer);
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	private void KillTweens()
	{
		if (_onFireTimer != null)
		{
			TweenExtensions.Kill(_onFireTimer);
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	protected virtual float FireDelay()
	{
		EnemyData currentEnemyData = _currentEnemyData;
		object obj = default(object);
		if ((object)currentEnemyData._003CfireDelay_003Ek__BackingField != null)
		{
			return (float)obj * 0.001f;
		}
		return 2000f * 0.001f;
	}

	protected virtual void Fire()
	{
		//IL_00a3->IL005d: Incompatible stack heights: 1 vs 0
		if (!base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField)
		{
			Transform cachedTransform = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 spawnPos = default(Vector2);
			base.FireEnemyAsBullet(spawnPos, _bulletType);
		}
	}

	private float _003CInitEnemy_003Eb__4_0()
	{
		return base._003CSpeed_003Ek__BackingField;
	}

	private void _003CInitEnemy_003Eb__4_1(float val)
	{
		base._003CSpeed_003Ek__BackingField = val;
	}

	private float _003CInitEnemy_003Eb__4_2()
	{
		return _fireTime;
	}

	private void _003CInitEnemy_003Eb__4_3(float val)
	{
		_fireTime = val;
	}
}
