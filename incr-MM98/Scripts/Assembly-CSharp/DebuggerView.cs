using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using MessagePipe;
using ObservableCollections;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebuggerView : MonoBehaviour, IMainView
{
	[SerializeField]
	private SegmentedLoadingBar refreshLoadingBar;

	[SerializeField]
	private Transform hexContainer;

	[SerializeField]
	private HexVisualizer hexPrefab;

	[SerializeField]
	private RectTransform stagingPanel;

	[SerializeField]
	private Transform stagingContainer;

	[SerializeField]
	private SegmentedLoadingBar stagingProgressBar;

	[SerializeField]
	private TMP_Text stagingProgressText;

	[SerializeField]
	private TMP_Text stagingBugValueText;

	[SerializeField]
	private AudioDataType addToStagingSfx;

	[SerializeField]
	private AudioDataType automatedToStagingSfx;

	[SerializeField]
	private AudioDataType stagingFullSfx;

	[SerializeField]
	private Button pushHotfixButton;

	[SerializeField]
	private Button compilePatchButton;

	[SerializeField]
	private Toggle compilePatchToggle;

	[SerializeField]
	private ResearchNode compilePatchToggleRequirement;

	[SerializeField]
	private SegmentedLoadingBar actionLoadingBar;

	private BehaviourPool<HexVisualizer> _stagedHexPool;

	private readonly List<HexVisualizer> _hexes = new List<HexVisualizer>();

	public void Initialize()
	{
		R3.DisposableBag bag = default(R3.DisposableBag);
		_stagedHexPool = new BehaviourPool<HexVisualizer>(hexPrefab, stagingContainer).AddTo(ref bag);
		_stagedHexPool.Prewarm(7);
		Initializer.Context(pushHotfixButton).AddListener(delegate
		{
			Database.Commands.Debugger.PushHotfix();
		}).Context(compilePatchButton)
			.AddListener(delegate
			{
				Database.Commands.Debugger.CompilePatch();
			})
			.Invoke(ClearStaging)
			.Invoke(InitializeHexValues)
			.Invoke(Hide);
		(from y in Database.Modifiers.ObserveAsInt(ModifierType.DebuggerMaxStaging)
			select 80 + (y + 7 - 1) / 7 * 55).Subscribe(stagingPanel, delegate(int y, RectTransform panel)
		{
			panel.sizeDelta = new Vector2(panel.sizeDelta.x, y);
		}).AddTo(ref bag);
		Database.State.Research.Unlocked.ObserveContains(compilePatchToggleRequirement).DistinctUntilChanged().Subscribe(compilePatchToggle, ToggleToggle)
			.AddTo(ref bag);
		Database.State.Debugger.RefreshTimer.ThrottleLastTenthSecond().SubscribeToLoadingBar(refreshLoadingBar).AddTo(ref bag);
		(from x in Database.State.Debugger.RefreshTimer.Select((TimerData t) => t.IsDone).DistinctUntilChanged()
			where x
			select x).Subscribe(delegate
		{
			RefreshHexes();
		}).AddTo(ref bag);
		Database.State.Debugger.Progress.ThrottleLastTenthSecond().SubscribeToLoadingBar(actionLoadingBar).AddTo(ref bag);
		(from x in Database.State.Debugger.ObserveInProgress.DistinctUntilChanged()
			where !x
			select x).Subscribe(delegate
		{
			ClearStaging();
		}).AddTo(ref bag);
		Database.State.Debugger.ObserveInProgress.DistinctUntilChanged().Invert().SubscribeToInteractable(pushHotfixButton, compilePatchButton, compilePatchToggle)
			.AddTo(ref bag);
		Database.State.Debugger.ObserveStagedBugs.DistinctUntilChanged().Prepend(Database.State.Debugger.StagedBugs).SubscribeToText(stagingBugValueText)
			.AddTo(ref bag);
		Observable<(int count, float max)> source = Database.State.Debugger.Staged.ObserveCountChanged().CombineLatest(Database.Modifiers.ObserveAsFloat(ModifierType.DebuggerMaxStaging), (int count, float max) => (count: count, max: max)).Share();
		(int, int) tuple = (Database.State.Debugger.Staged.Count, ModifierType.DebuggerMaxStaging.Int());
		(int, int) tuple2 = tuple;
		(from state in source.Prepend((tuple2.Item1, tuple2.Item2))
			select (float)state.count / state.max).SubscribeToLoadingBar(stagingProgressBar).AddTo(ref bag);
		tuple2 = tuple;
		(from state in source.Prepend((tuple2.Item1, tuple2.Item2))
			select ZString.Format("{0}/{1}", state.count, state.max)).SubscribeToText(stagingProgressText).AddTo(ref bag);
		tuple2 = tuple;
		(from state in source.Prepend((tuple2.Item1, tuple2.Item2))
			where Mathf.Approximately(state.count, state.max)
			select state).Subscribe(delegate
		{
			Database.State.Debugger.Automated.RemoveAll();
		}).AddTo(ref bag);
		tuple2 = tuple;
		(from x in source.Prepend((tuple2.Item1, tuple2.Item2)).CombineLatest(compilePatchToggle.OnValueChangedAsObservable(), ((int count, float max) state, bool toggled) => toggled && Mathf.Approximately(state.count, state.max))
			where x
			select x).Subscribe(delegate
		{
			compilePatchButton.onClick.Invoke();
		}).AddTo(ref bag);
		(from ctx in Database.State.Debugger.Glitched.ObserveAdd()
			select ctx.Value).Subscribe(delegate(int x)
		{
			_hexes[x].SetGlitched();
		}).AddTo(ref bag);
		(from ctx in Database.State.Debugger.Glitched.ObserveRemove()
			select ctx.Value).Subscribe(delegate(int x)
		{
			Database.State.Debugger.Automated.Remove(x);
		}).AddTo(ref bag);
		EventHub.Scene.Subscribe(delegate
		{
			HandlePrestige();
		}, Array.Empty<MessageHandlerFilter<Prestiged>>()).AddTo(ref bag);
		bag.AddTo(this);
		InitializeStaging();
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.debugger.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.debugger.Clear();
	}

	private void RefreshHexes()
	{
		Database.State.Debugger.RefreshTimer.ResetTimer();
		RefreshHexesAsync(this.GetCancellationTokenOnDestroy()).Forget();
	}

	private void HandlePrestige()
	{
		ClearStaging();
		RefreshHexes();
		foreach (HexVisualizer hex in _hexes)
		{
			hex.SetNormal();
		}
	}

	private void InitializeHexValues()
	{
		for (int i = 0; i < ModifierType.DebuggerHexCount.Int(); i++)
		{
			HexVisualizer hexVisualizer = UnityEngine.Object.Instantiate(hexPrefab, hexContainer);
			hexVisualizer.Setup(i);
			hexVisualizer.Selected += StageHex;
			_hexes.Add(hexVisualizer);
		}
	}

	private void InitializeStaging()
	{
		foreach (int item in Database.State.Debugger.Staged)
		{
			HexVisualizer hexVisualizer = _stagedHexPool.Rent();
			hexVisualizer.SetHexValue(item);
			hexVisualizer.SetSelected();
		}
	}

	private void StageHex(int index, int hex, bool automated)
	{
		if (!Database.Commands.Debugger.StageHex(index, hex, automated))
		{
			if (Database.State.Debugger.Staged.Count >= ModifierType.DebuggerMaxStaging.Int())
			{
				Audio.PlaySfx(stagingFullSfx);
			}
			return;
		}
		HexVisualizer hexVisualizer = _hexes[index];
		CopyHex(hexVisualizer);
		hexVisualizer.SetNormal();
		hexVisualizer.RandomizeHex();
		float pitch = ((Database.State.Debugger.Staged.Count >= ModifierType.DebuggerMaxStaging.Int()) ? 1.15f : 1f);
		if (!automated)
		{
			Audio.PlaySfx(addToStagingSfx, pitch);
		}
		else if (base.gameObject.activeSelf)
		{
			Audio.PlaySfx(automatedToStagingSfx, pitch);
		}
	}

	private void CopyHex(HexVisualizer hex)
	{
		HexVisualizer hexVisualizer = _stagedHexPool.Rent();
		hexVisualizer.transform.SetAsLastSibling();
		hexVisualizer.SetHexValue(hex.HexValue);
		hexVisualizer.SetSelected();
		hexVisualizer.AnimateToStaging(hex.transform.position, hexVisualizer.GetCancellationTokenOnDestroy()).Forget();
	}

	private void ClearStaging()
	{
		_stagedHexPool.ReturnAll();
		actionLoadingBar.SetNormalizedValue(0f);
	}

	private void ToggleToggle(bool x, Toggle toggle)
	{
		if (!x)
		{
			toggle.isOn = false;
		}
		toggle.gameObject.SetActive(x);
	}

	private async UniTaskVoid RefreshHexesAsync(CancellationToken token)
	{
		int index = 0;
		int num = 0;
		while (!token.IsCancellationRequested && index < _hexes.Count)
		{
			_hexes[index++].RandomizeHex();
			num++;
			if (num >= 3)
			{
				await UniTask.NextFrame(token, cancelImmediately: true);
				num = 0;
			}
		}
	}
}
