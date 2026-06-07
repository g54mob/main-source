using LitMotion;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveSequel : MonoBehaviour
{
	[SerializeField]
	private ValueNumericDisplay developCostDisplay;

	[SerializeField]
	private Slider gameDesignProgressSlider;

	[SerializeField]
	private Slider artProgressSlider;

	[SerializeField]
	private Slider netcodeProgressSlider;

	[SerializeField]
	private Slider marketingProgressSlider;

	[SerializeField]
	private Slider qaProgressSlider;

	[SerializeField]
	private LocalizeStringHandler dataPreviewHandler;

	[SerializeField]
	private GameObject notEnoughStorageWarning;

	private void Awake()
	{
		DisposableBag bag = default(DisposableBag);
		Database.State.Sequel.Cost.SubscribeToValueDisplay(developCostDisplay, NumericFormat.Currency, 0.5f).AddTo(ref bag);
		Database.State.Sequel.Progress.GameDesign.Subscribe(gameDesignProgressSlider, delegate(float x, Slider slider)
		{
			LMotion.Create(slider.normalizedValue, x, 0.5f).BindToSliderNormalized(slider);
		}).AddTo(ref bag);
		Database.State.Sequel.Progress.Art.Subscribe(artProgressSlider, delegate(float x, Slider slider)
		{
			LMotion.Create(slider.normalizedValue, x, 0.5f).BindToSliderNormalized(slider);
		}).AddTo(ref bag);
		Database.State.Sequel.Progress.Netcode.Subscribe(netcodeProgressSlider, delegate(float x, Slider slider)
		{
			LMotion.Create(slider.normalizedValue, x, 0.5f).BindToSliderNormalized(slider);
		}).AddTo(ref bag);
		Database.State.Sequel.Progress.Marketing.Subscribe(marketingProgressSlider, delegate(float x, Slider slider)
		{
			LMotion.Create(slider.normalizedValue, x, 0.5f).BindToSliderNormalized(slider);
		}).AddTo(ref bag);
		Database.State.Sequel.Progress.Qa.Subscribe(qaProgressSlider, delegate(float x, Slider slider)
		{
			LMotion.Create(slider.normalizedValue, x, 0.5f).BindToSliderNormalized(slider);
		}).AddTo(ref bag);
		Database.State.Sequel.Progress.FactorRange.Subscribe((dataPreviewHandler, notEnoughStorageWarning), delegate(Vector2 _, (LocalizeStringHandler dataPreviewHandler, GameObject notEnoughStorageWarning) state)
		{
			UpdateDataPreviewVariables(state.dataPreviewHandler, state.notEnoughStorageWarning);
		}).AddTo(ref bag);
		dataPreviewHandler.OnEnableAsObservable().Subscribe((dataPreviewHandler, notEnoughStorageWarning), delegate(Unit _, (LocalizeStringHandler dataPreviewHandler, GameObject notEnoughStorageWarning) state)
		{
			UpdateDataPreviewVariables(state.dataPreviewHandler, state.notEnoughStorageWarning);
		}).AddTo(ref bag);
		bag.AddTo(this);
	}

	private static void UpdateDataPreviewVariables(LocalizeStringHandler handler, GameObject warning)
	{
		var (value, num) = Database.Commands.Sequel.PreviewDataGain();
		handler.SetValue("minimum", value);
		handler.SetValue("maximum", num);
		warning.SetActive(Database.State.Prestige.Data.CurrentValue + num >= Database.Derived.DataCapacity.CurrentValue);
	}
}
