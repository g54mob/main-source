using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using Febucci.TextAnimatorForUnity;
using Febucci.TextAnimatorForUnity.TextMeshPro;
using LitMotion;
using LitMotion.Extensions;
using ObservableCollections;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HexVisualizer : MonoBehaviour
{
	[SerializeField]
	private RectTransform visuals;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private TMP_Text hexText;

	[SerializeField]
	private TextAnimator_TMP animator;

	[SerializeField]
	private TypewriterComponent typewriter;

	[SerializeField]
	private Button button;

	[SerializeField]
	private AnimatorSettingsScriptable normalAnimation;

	[SerializeField]
	private AnimatorSettingsScriptable glitchedAnimation;

	[SerializeField]
	private AnimatorSettingsScriptable selectedAnimation;

	[SerializeField]
	private Image automationProgress;

	[SerializeField]
	private Color defaultColor = Color.black;

	[SerializeField]
	private Color kernelDebuggerColor = Color.red;

	private int _index;

	private int _hex;

	private DisposableBag _subscription;

	public int HexValue => _hex;

	public event Action<int, int, bool> Selected;

	public void Setup(int index)
	{
		_index = index;
		button.onClick.AddListener(delegate
		{
			this.Selected?.Invoke(_index, _hex, arg3: false);
		});
		RandomizeHex();
		if (Database.State.Debugger.Glitched.Contains(_index))
		{
			SetGlitched();
		}
		else
		{
			SetNormal();
		}
		(from x in Database.State.Debugger.Automated.ObserveAdd()
			select x.Value).Where(_index, (KeyValuePair<int, ReactiveProperty<TimerData>> x, int i) => x.Key == i).Subscribe(HandleAutomationStart).AddTo(this);
		(from x in Database.State.Debugger.Automated.ObserveRemove()
			select x.Value).Where(_index, (KeyValuePair<int, ReactiveProperty<TimerData>> x, int i) => x.Key == i).Subscribe(delegate
		{
			HandleAutomationStop(complete: false);
		}).AddTo(this);
	}

	private void HandleAutomationStart(KeyValuePair<int, ReactiveProperty<TimerData>> kvp)
	{
		_subscription.Clear();
		_subscription.Add(kvp.Value.Subscribe(automationProgress, delegate(TimerData t, Image progress)
		{
			progress.fillAmount = t.Normalized;
		}));
		_subscription.Add(kvp.Value.Where((TimerData t) => t.IsDone).Subscribe(delegate
		{
			HandleAutomationStop(complete: true);
		}));
		automationProgress.fillAmount = 0f;
		automationProgress.gameObject.SetActive(value: true);
	}

	private void HandleAutomationStop(bool complete)
	{
		_subscription.Clear();
		automationProgress.gameObject.SetActive(value: false);
		if (complete)
		{
			this.Selected?.Invoke(_index, _hex, arg3: true);
		}
	}

	private void OnDestroy()
	{
		_subscription.Dispose();
	}

	public void SetHexValue(int hex)
	{
		_hex = hex;
		typewriter.ShowText(ZString.Format("{0:X2}", _hex));
	}

	public void RandomizeHex()
	{
		_hex = UnityEngine.Random.Range(0, 256);
		typewriter.ShowText(ZString.Format("{0:X2}", _hex));
	}

	public void SetNormal()
	{
		Configure(normalAnimation, glitched: false);
	}

	public void SetGlitched()
	{
		Configure(glitchedAnimation, glitched: true);
	}

	public void SetSelected()
	{
		Configure(selectedAnimation, glitched: false);
	}

	private void Configure(AnimatorSettingsScriptable settings, bool glitched)
	{
		animator.sharedSettings = settings;
		animator.ResetState();
		button.interactable = glitched;
		if (glitched && Database.State.Research.IsUnlocked(ResearchNode.KernelDebugger))
		{
			hexText.color = kernelDebuggerColor;
		}
		else
		{
			hexText.color = defaultColor;
		}
	}

	public async UniTaskVoid AnimateToStaging(Vector3 worldPosition, CancellationToken token)
	{
		canvasGroup.alpha = 0f;
		await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate, token);
		RectTransform rect = base.transform as RectTransform;
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(UI.Registry.cameras.main, worldPosition);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, UI.Registry.cameras.main, out var localPoint);
		visuals.anchoredPosition = localPoint;
		visuals.localScale = Vector3.one * 0.7f;
		canvasGroup.alpha = 0.5f;
		UniTask uniTask = LMotion.Create(localPoint, Vector2.zero, 0.25f).WithEase(Ease.OutCubic).BindToAnchoredPosition(visuals)
			.ToUniTask(token);
		UniTask uniTask2 = LMotion.Create(visuals.localScale, Vector3.one, 0.25f).WithEase(Ease.OutElastic).BindToLocalScale(visuals)
			.ToUniTask(token);
		UniTask uniTask3 = LMotion.Create(canvasGroup.alpha, 1f, 0.125f).WithEase(Ease.OutQuad).BindToAlpha(canvasGroup)
			.ToUniTask(token);
		await UniTask.WhenAll(uniTask, uniTask2, uniTask3);
		visuals.anchoredPosition = Vector2.zero;
		visuals.localScale = Vector3.one;
		canvasGroup.alpha = 1f;
	}
}
