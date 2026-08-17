using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyJellyfish : EnemyController
{
	private float _sineF = 1f;

	private Tween _onEnterTween;

	private Tween _sineTween;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_000f: Expected I4, but got O
		//IL_0294: Expected I, but got O
		//IL_02d1: Expected O, but got Ref
		//IL_0306: Expected I4, but got O
		//IL_0351: Expected I4, but got O
		//IL_030f->IL022a: Incompatible stack heights: 1 vs 0
		//IL_035a->IL022a: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			bool flag = (byte)(int)_cachedTransform != 0;
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			_sineF = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbx_v5 (System.Boolean)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbx_v5 (System.Boolean)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			if (_onEnterTween != null)
			{
				TweenExtensions.Kill(_onEnterTween);
			}
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v23 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float val = 0f * _scaleMul;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&value), 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((int)(~tweenerCore) == 0)
			{
				_onEnterTween = tweenerCore;
				if (_sineTween != null)
				{
					TweenExtensions.Kill(_sineTween);
				}
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((EnemyJellyfish)(object)dOSetter)._003CInitEnemy_003Eb__3_1(val);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, -1f, 4f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if ((int)(~tweenerCore2) == 0)
				{
					_sineTween = tweenerCore2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_sineTween != null)
		{
			TweenExtensions.Kill(_sineTween);
		}
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
	}

	protected override void OnUpdate()
	{
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
	}

	private float _003CInitEnemy_003Eb__3_0()
	{
		return _sineF;
	}

	private void _003CInitEnemy_003Eb__3_1(float val)
	{
		_sineF = val;
	}
}
