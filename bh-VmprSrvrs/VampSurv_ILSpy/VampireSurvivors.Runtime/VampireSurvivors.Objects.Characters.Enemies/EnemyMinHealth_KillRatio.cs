using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMinHealth_KillRatio : EnemyController
{
	private Sequence _onEnterTween;

	private int _lives = 1;

	private TweenerCore<float, float, FloatOptions> _003CAccelTween_003Ek__BackingField;

	public TweenerCore<float, float, FloatOptions> AccelTween
	{
		get
		{
			return _003CAccelTween_003Ek__BackingField;
		}
		set
		{
			_003CAccelTween_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_03b6: Expected O, but got Ref
		//IL_0146: Invalid comparison between F4 and I4
		//IL_0110: Expected I4, but got O
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected I4, but got Unknown
		//IL_0458: Expected F4, but got I4
		//IL_01ed: Expected F4, but got I4
		//IL_02cb: Expected O, but got I
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_048f: Expected O, but got F4
		//IL_04bc: Expected O, but got I4
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		base.InitEnemy(enemyType, asRemote);
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
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
				goto IL_0429;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187735510h\"");
		int num2 = default(int);
		if (core._003CSurvivedSeconds_003Ek__BackingField == 0f)
		{
			num2 = 0;
		}
		else
		{
			PlayerOptionsData config = core._playerOptions.Config;
			num2 = (int)(config._003CRunEnemies_003Ek__BackingField / core._003CSurvivedSeconds_003Ek__BackingField);
		}
		goto IL_0429;
		IL_0429:
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		bool flag = (object)stage._fancyBg == null;
		float num3 = num2;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
			num3 = num2;
			if (!flag2)
			{
				float killRatio = stage._fancyBg.GetKillRatio();
				num3 = core._003CSurvivedSeconds_003Ek__BackingField;
			}
		}
		float maxHp = num3 * _maxHp;
		_maxHp = maxHp;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(num3, null, currentInfo);
		string message = "KR:" + text;
		Debug.Log(message);
		_hp = _maxHp;
		float2 float5 = base.position;
		GameManager core3 = GM.Core;
		GameSessionData gameSessionData = core3._gameSessionData;
		float2 float6 = gameSessionData._activeCharacter.position;
		object obj = default(object);
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			object obj3 = (nint)0 ^ (nint)0;
			object obj4 = 0 & obj3;
			bool flag3 = (nint)obj4 < 0;
			bool flag4 = (nint)0 < (nint)0;
			bool flag5 = (nint)0 == 0;
			object obj5 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm2\"");
			bool flag6 = flag4 == flag3;
			object obj6 = !flag6;
			object obj7 = obj6 | flag5;
			if (obj7 == null)
			{
				GameManager core4 = GM.Core;
				GameSessionData gameSessionData2 = core4._gameSessionData;
				float2 float7 = gameSessionData2._activeCharacter.position;
				float2 float8 = base.position;
				float2 float9 = base.position;
				float2 float10 = default(float2);
				base.position = float10;
			}
		}
	}

	public override void OnTeleportOnCull()
	{
		if (_003CAccelTween_003Ek__BackingField != null)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = _003CAccelTween_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+110]");
				if ((nint)0 != 0)
				{
					return;
				}
			}
			else if (Debugger._logPriority > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DAF]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Debugger.LogWarning("This Tween has been killed and is now invalid");
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 99 Invalid \"Jump target not found in method: 0x187735900\"");
				goto IL_00b7;
			}
			goto IL_00ac;
		}
		goto IL_00b7;
		IL_00b7:
		Accelerate();
		goto IL_00ac;
		IL_00ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 107 Invalid \"Jump target not found in method: 0x187735900\"");
	}

	private void Accelerate()
	{
		base._003CSpeed_003Ek__BackingField = 400f;
		if (_003CAccelTween_003Ek__BackingField != null)
		{
			TweenExtensions.Kill(_003CAccelTween_003Ek__BackingField);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((EnemyMinHealth_KillRatio)(object)dOSetter)._003CAccelerate_003Eb__8_1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 100f, 2f);
		_003CAccelTween_003Ek__BackingField = tweenerCore;
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

	private float _003CAccelerate_003Eb__8_0()
	{
		return base._003CSpeed_003Ek__BackingField;
	}

	private void _003CAccelerate_003Eb__8_1(float x)
	{
		base._003CSpeed_003Ek__BackingField = x;
	}
}
