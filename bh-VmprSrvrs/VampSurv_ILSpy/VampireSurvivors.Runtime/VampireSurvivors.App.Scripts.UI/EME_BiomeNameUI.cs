using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.UI;

public class EME_BiomeNameUI : MonoBehaviour
{
	private enum ShowState
	{
		Hidden,
		FadeIn,
		Showing,
		FadeOut
	}

	private RectTransform _rectTransform;

	private TMP_Text _biomeNameText;

	private CanvasGroup _canvasGroup;

	private float _fadeInDuration;

	private AnimationCurve _fadeInCurve;

	private float _showDuration;

	private float _fadeOutDuration;

	private AnimationCurve _fadeOutCurve;

	private ShowState _currentState;

	private float _stateTimer;

	public RectTransform GetRectTransform => _rectTransform;

	public void Show(string biomeName)
	{
		_biomeNameText.text = biomeName;
		_currentState = ShowState.FadeIn;
	}

	public void HideImmediate()
	{
		_currentState = ShowState.Hidden;
		_canvasGroup.alpha = 0f;
	}

	private void SetState(ShowState newState)
	{
		//IL_0040: Expected O, but got I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		_currentState = newState;
		_stateTimer = 0f;
		bool flag = newState == ShowState.Hidden;
		if (!flag)
		{
			object obj = newState - 1;
			if (flag)
			{
				return;
			}
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
			}
			else
			{
				_canvasGroup.alpha = 1f;
			}
		}
		else
		{
			_canvasGroup.alpha = 0f;
		}
	}

	public void UpdateNameUi(float deltaTime)
	{
		//IL_004f: Expected O, but got I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0256: Invalid comparison between I4 and F4
		//IL_02a1: Expected F4, but got I4
		//IL_02c2: Invalid comparison between I4 and F4
		//IL_030d: Expected F4, but got I4
		//IL_01dc: Expected F4, but got I4
		//IL_00e2: Invalid comparison between I4 and F4
		//IL_012d: Expected F4, but got I4
		//IL_014e: Invalid comparison between I4 and F4
		//IL_0199: Expected F4, but got I4
		if (_currentState != ShowState.Hidden)
		{
			float stateTimer = deltaTime + _stateTimer;
			_stateTimer = stateTimer;
		}
		bool flag = _currentState == ShowState.Hidden;
		if (flag)
		{
			return;
		}
		object obj = _currentState - 1;
		CanvasGroup canvasGroup;
		float alpha;
		float num4;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				if (!(_stateTimer < _showDuration))
				{
					_currentState = ShowState.FadeOut;
				}
				return;
			}
			if ((nint)obj2 != 1)
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
			canvasGroup = _canvasGroup;
			if (!(_stateTimer < _fadeOutDuration))
			{
				_currentState = ShowState.Hidden;
				alpha = 0f;
				goto IL_036e;
			}
			float num = _stateTimer / _fadeOutDuration;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			float num2 = _fadeOutCurve.Evaluate(num);
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			float num3 = num2 * -1f;
			num4 = num3 + 1f;
		}
		else
		{
			canvasGroup = _canvasGroup;
			if (!(_stateTimer < _fadeInDuration))
			{
				_currentState = ShowState.Showing;
				alpha = 1f;
				goto IL_036e;
			}
			float num5 = _stateTimer / _fadeInDuration;
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			num4 = _fadeInCurve.Evaluate(num5);
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
		}
		alpha = num4;
		goto IL_036e;
		IL_036e:
		canvasGroup.alpha = alpha;
	}

	public EME_BiomeNameUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
