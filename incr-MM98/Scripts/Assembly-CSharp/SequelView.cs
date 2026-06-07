using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class SequelView : MonoBehaviour, IMainView
{
	[SerializeField]
	private TMP_InputField sequelNameField;

	[SerializeField]
	private Button randomizeSequelNameButton;

	[SerializeField]
	private Button newBoxArtButton;

	[SerializeField]
	private Button customBoxArtButton;

	[SerializeField]
	private Button releaseButton;

	[SerializeField]
	private Button abandonButton;

	[SerializeField]
	private Button developButton;

	[SerializeField]
	private SegmentedLoadingBar developProgressBar;

	[SerializeField]
	private GameObject progressGroup;

	[SerializeField]
	private ReactiveSequel progressDisplays;

	[SerializeField]
	private LocalizedString releaseSequelConfirmationTitle;

	[SerializeField]
	private LocalizedString releaseSequelConfirmationMessage;

	[SerializeField]
	private LocalizedString releaseSequelResultsTitle;

	[SerializeField]
	private LocalizedString releaseSequelResultsMessage;

	[SerializeField]
	private LocalizedString abandonSequelConfirmationTitle;

	[SerializeField]
	private LocalizedString abandonSequelConfirmationMessage;

	private IDisposable _disposableAbandonment;

	public void Initialize()
	{
		Initializer.Context(randomizeSequelNameButton).AddListener(delegate
		{
			Database.Commands.Sequel.RandomizeName();
		}).Context(newBoxArtButton)
			.AddListener(delegate
			{
				Database.Commands.Sequel.RandomizeBoxArt();
			})
			.Context(customBoxArtButton)
			.AddListener(delegate
			{
				CustomBoxArtUtility.Select(delegate
				{
					Database.State.Sequel.BoxArt.OnNext(BoxArt.Custom);
				});
			})
			.Context(releaseButton)
			.AddListener(HandleRelease)
			.Context(abandonButton)
			.AddListener(HandleAbandonment)
			.Context(developButton)
			.AddListener(EventHub.Scene.Publish<DevelopmentAttempted>)
			.Invoke(Hide);
		DisposableBag bag = default(DisposableBag);
		Database.State.Sequel.Name.DistinctUntilChanged().Where(sequelNameField, (string x, TMP_InputField field) => field.text != x).Subscribe(delegate(string x)
		{
			sequelNameField.SetTextWithoutNotify(x);
		})
			.AddTo(ref bag);
		Database.State.Sequel.Name.Select((string x) => !string.IsNullOrEmpty(x)).CombineLatest(Database.State.Sequel.Developing, (bool x, bool developing) => x && !developing).CombineLatest(Database.State.Sequel.Round, (bool x, int rounds) => x && rounds > 0)
			.SubscribeToInteractable(releaseButton)
			.AddTo(ref bag);
		Database.State.Sequel.Developing.Select((bool x) => !x).SubscribeToInteractable(developButton).AddTo(ref bag);
		Database.State.Sequel.NormalizedTime.Subscribe(developProgressBar, delegate(float t, SegmentedLoadingBar bar)
		{
			bar.SetNormalizedValue(t);
		}).AddTo(ref bag);
		Database.State.Sequel.Round.Select((int x) => x > 0).SubscribeToSetActive(progressGroup).AddTo(ref bag);
		Database.State.Sequel.Name.Select((string x) => !string.IsNullOrEmpty(x)).SubscribeToInteractable(abandonButton).AddTo(ref bag);
		sequelNameField.OnValueChangedAsObservable().Debounce(TimeSpan.FromMilliseconds(100.0)).Subscribe(delegate(string text)
		{
			Database.State.Sequel.Name.Value = text;
		})
			.AddTo(ref bag);
		bag.AddTo(this);
		ObserveAbandonmentState();
	}

	private void OnDestroy()
	{
		_disposableAbandonment?.Dispose();
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.sequel.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.sequel.Clear();
	}

	private void HandleRelease()
	{
		UI.Registry.popup.generic.ShowCancellable(releaseSequelConfirmationTitle, releaseSequelConfirmationMessage, delegate
		{
			ReleaseSequel(abandoned: false);
		});
	}

	private void HandleAbandonment()
	{
		UI.Registry.popup.generic.ShowCancellable(releaseSequelConfirmationTitle, releaseSequelConfirmationMessage, delegate
		{
			ReleaseSequel(abandoned: true);
		});
	}

	private void ReleaseSequel(bool abandoned)
	{
		Database.Commands.Sequel.Prestige(abandoned);
		UI.Registry.popup.generic.ShowConfirmation(releaseSequelResultsTitle, releaseSequelResultsMessage);
		ObserveAbandonmentState();
	}

	private void ObserveAbandonmentState()
	{
		_disposableAbandonment?.Dispose();
		IDisposable disposable = Database.State.Sequel.Round.CombineLatest(Database.State.Sequel.Developing, (int round, bool developing) => round >= 1 || developing).IsTrue().Take(1)
			.Subscribe(delegate
			{
				_disposableAbandonment?.Dispose();
				abandonButton.gameObject.SetActive(value: false);
			});
		IDisposable disposable2 = Database.State.Game.Time.CombineLatest(Database.State.Resources.Money, Database.State.Resources.MoneyPerSecond, Database.State.Sequel.Cost, (double time, double money, double moneyPerSecond, double cost) => time >= 60.0 && money < cost && moneyPerSecond < 1.0).SubscribeToSetActive(abandonButton.gameObject);
		_disposableAbandonment = Disposable.Combine(disposable, disposable2);
	}
}
