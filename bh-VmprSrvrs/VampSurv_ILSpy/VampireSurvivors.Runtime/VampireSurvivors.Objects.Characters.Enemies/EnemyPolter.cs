using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyPolter : EnemyController
{
	private Sequence _onEnterTween;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_01f1: Expected I, but got O
		//IL_022e: Expected O, but got Ref
		//IL_025e: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_006b: Expected F4, but got I4
		base.InitEnemy(enemyType, asRemote);
		if (_onEnterTween != null)
		{
			TweenExtensions.Restart(_onEnterTween);
		}
		else
		{
			Sequence onEnterTween = DOTween.Sequence();
			_onEnterTween = onEnterTween;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float val = 0f * _scaleMul;
			Vector3 vector = default(Vector3);
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 0.3f);
			bool flag = TweenSettingsExtensions.ValidateAddToSequence(_onEnterTween, (Tween)t, false);
			bool flag2 = !flag;
			object obj = 0;
			float num3 = 0.3f;
			if (!flag2)
			{
				Sequence sequence = Sequence.DoInsert(_onEnterTween, (Tween)t, 0f);
				obj = 0;
				num3 = 0f;
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((EnemyPolter)(object)dOSetter)._003CInitEnemy_003Eb__1_1(val);
			TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter, dOSetter, 0f, 0.3f);
			if (TweenSettingsExtensions.ValidateAddToSequence(_onEnterTween, (Tween)t2, false))
			{
				Sequence sequence2 = Sequence.DoInsert(_onEnterTween, (Tween)t2, 0f);
			}
			Sequence onEnterTween2 = _onEnterTween;
			if (_onEnterTween != null && ((Tween)onEnterTween2)._003Cactive_003Ek__BackingField && !((Tween)onEnterTween2).creationLocked)
			{
				((Tween)onEnterTween2).autoKill = false;
			}
			Sequence onEnterTween3 = _onEnterTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			onEnterTween3.stringId = "DefaultGameTweenId";
		}
		base._003CSelfDestDistance_003Ek__BackingField = 10000f;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		Transform transform = _EnemyRenderer.transform;
		bool flag2 = (object)transform == null;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value2 = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
	}

	private float _003CInitEnemy_003Eb__1_0()
	{
		return base._003CSpeed_003Ek__BackingField;
	}

	private void _003CInitEnemy_003Eb__1_1(float val)
	{
		base._003CSpeed_003Ek__BackingField = val;
	}
}
