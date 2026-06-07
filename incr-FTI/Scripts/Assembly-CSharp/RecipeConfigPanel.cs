using System.Text;
using TMPro;
using UnityEngine.EventSystems;

public class RecipeConfigPanel : MenuPanel, IPointerDownHandler, IEventSystemHandler
{
	public PauseRegion pauseRegion;

	public PriorityRegion priorityRegion;

	public ProductionTargetRegion productionLimitRegion;

	public TextMeshProUGUI pauseRegionKeyLabel;

	public TextMeshProUGUI pauseRegionValueLabel;

	public TextMeshProUGUI priorityRegionKeyLabel;

	public TextMeshProUGUI priorityRegionValueLabel;

	public TextMeshProUGUI limitRegionKeyLabel;

	public TextMeshProUGUI limitRegionValueLabel;

	private StateManager state;

	public override void Initialize()
	{
		base.Initialize();
		priorityRegion.Initialize(OnPriorityChanged);
		pauseRegion.Initialize(OnPauseChanged);
		productionLimitRegion.InitializeAsStandaloneButton();
		productionLimitRegion.onLimitChangedDelegate = OnProductionLimitChanged;
		productionLimitRegion.onPauseChangedDelegate = OnPauseChanged;
	}

	public void DisplayForStateManager(StateManager sm)
	{
		state = sm;
		priorityRegion.displayedSettings = state.localSettings;
		productionLimitRegion.displayedSettings = state.localSettings;
		pauseRegion.displayedSettings = state.localSettings;
		ReloadLabels();
		Show();
		header.headerIcon.sprite = IconManager.SpriteForState(sm);
		if (sm.producingBuilding != null)
		{
			header.headerText.text = string.Format(TextDisplay.LocalizedKeyValueFormat(), TextDisplay.LabelForBuilding(sm.producingBuilding.type), TextDisplay.LabelForEntity(sm.AsEntity()));
		}
		else
		{
			header.headerText.text = TextDisplay.LabelForEntity(sm.AsEntity());
		}
		priorityRegion.gameObject.SetActive(state.parentTown.AllowPriority());
		productionLimitRegion.gameObject.SetActive(!state.localSettings.productionLimit.restrictOptions);
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		if (state != null)
		{
			UpdatePriorityDisplay();
			UpdatePauseDisplay();
			UpdateProductionLimitDisplay();
			priorityRegionKeyLabel.text = "Priority".Localized();
			pauseRegionKeyLabel.text = "Pause".Localized();
			limitRegionKeyLabel.text = "ProductionTarget".Localized();
		}
	}

	public override void UpdatePriorityDisplay()
	{
		base.UpdatePriorityDisplay();
		if (state != null)
		{
			priorityRegion.SetPriorityImage(state.localSettings.priority.value);
			priorityRegionValueLabel.text = TextDisplay.LabelForPriority(state.localSettings.priority.value);
		}
	}

	public override void UpdatePauseDisplay()
	{
		base.UpdatePauseDisplay();
		if (state != null)
		{
			pauseRegion.SetLocalPauseDisplay(state.localSettings.pause.value);
			pauseRegionValueLabel.text = TextDisplay.LabelforPauseState(state.localSettings.pause.value);
		}
	}

	public override void UpdateProductionLimitDisplay()
	{
		base.UpdateProductionLimitDisplay();
		productionLimitRegion.SetTargetImage();
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		productionLimitRegion.AppendStatusString(pooledStringBuilder, state.localSettings.productionLimit);
		limitRegionValueLabel.SetText(pooledStringBuilder);
		GameUtility.ReturnToPool(pooledStringBuilder);
	}

	private void OnPauseChanged()
	{
		state.CalcAppliedPauseState();
		MenuManager.Instance.FlagAllPauseStale();
	}

	private void OnPriorityChanged()
	{
		UpdatePriorityDisplay();
		state.parentTown.OnPriorityChanged(state);
		MenuManager.Instance.FlagAllPriorityStale();
	}

	private void OnProductionLimitChanged()
	{
		state.CalcAppliedProductionLimit();
		MenuManager.Instance.FlagAllProductionLimitsStale();
		UpdateProductionLimitDisplay();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
