using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.Engine.UI;
using I2.Loc;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Platforms;
using Zenject;

namespace VampireSurvivors.UI;

public class WarningPage : BaseUIPage
{
	public static bool Corrupt;

	private float WaitDuration;

	private CanvasGroup Content;

	private float FadeDuration;

	private bool _DebugCorruptPage;

	private bool _isWaiting;

	private float _currentTime;

	private SignalBus _signalBus;

	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	protected override void Awake()
	{
		//IL_00bf: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_023d->IL023d: Incompatible stack heights: 2 vs 0
		base.Awake();
		if (AppWarningState.HasShown && !Corrupt)
		{
			UIView view = View;
			UIViewBehavior showBehavior = view.ShowBehavior;
			showBehavior.InstantAnimation = true;
			UIView view2 = View;
			UIViewBehavior hideBehavior = view2.HideBehavior;
			hideBehavior.InstantAnimation = true;
		}
		if (_DebugCorruptPage || Corrupt)
		{
			TextMeshProUGUI[] componentsInChildren = GetComponentsInChildren<TextMeshProUGUI>();
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			while ((nint)obj2 < componentsInChildren.Length)
			{
				Localize component = componentsInChildren[obj].GetComponent<Localize>();
				bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				Behaviour.set_enabled_Injected(((UnityEngine.Object)component).m_CachedPtr, false);
				Transform transform = componentsInChildren[obj].transform;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				string text = componentsInChildren[obj].text;
				string text2 = VampireSurvivors.App.Tools.Extensions.Shuffle(text);
				componentsInChildren[obj].text = text2;
				obj++;
				obj2 = obj;
			}
			BackgroundPage._hasPlayedSong = false;
			Corrupt = false;
		}
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		if (!AppWarningState.HasShown)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(Content, 1f, FadeDuration);
			_isWaiting = true;
		}
	}

	protected override void OnHideStart(GameObject g)
	{
		if (!AppWarningState.HasShown)
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(Content, 0f, FadeDuration);
		}
	}

	protected override void OnHideFinish(GameObject g)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		base.OnHideFinish(g);
		if (!AppWarningState.HasShown)
		{
			_isWaiting = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		}
	}

	protected override void Update()
	{
		//IL_008b: Expected O, but got F4
		base.Update();
		if (!_isWaiting)
		{
			return;
		}
		object obj = Time.deltaTime;
		object obj2 = default(object);
		if ((_currentTime = (float)obj2 + _currentTime) > WaitDuration)
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			IBaseAccount currentSystem = sInstance.m_CurrentSystem;
			if (VampireSurvivors.App.Tools.Extensions.AnyDown(currentSystem.m_Player))
			{
				View.Hide();
			}
		}
	}

	private void Complete()
	{
		View.Hide();
	}
}
