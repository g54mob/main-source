using System;
using System.Collections.Generic;
using System.Linq;
using MessagePipe;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.UI;

public class WorldView : MonoBehaviour, IMainView
{
	[SerializeField]
	private List<DatacenterVisualizer> nodes;

	[SerializeField]
	private BezierConnections connections;

	[SerializeField]
	private GameObject detailsPanel;

	[SerializeField]
	private GameObject purchasePanel;

	[SerializeField]
	private TMP_Text priceField;

	[SerializeField]
	private Button unlockButton;

	[SerializeField]
	private SegmentedLoadingBar constructionLoadingbar;

	[SerializeField]
	private GameObject operationsPanel;

	[SerializeField]
	private Button reprovisionButton;

	[SerializeField]
	private Button hireEngineerButton;

	[SerializeField]
	private SegmentedLoadingBar reprovisionLoadingBar;

	[SerializeField]
	private AudioDataType reprovisionAudio;

	[SerializeField]
	private AudioDataType constructionCompleteAudio;

	[SerializeField]
	private AudioDataType reprovisionCompleteAudio;

	[SerializeField]
	private LocalizeStringHandler locationHandler;

	[SerializeField]
	private LocalizeStringHandler stateHandler;

	[SerializeField]
	private LocalizeStringHandler engineerHandler;

	[SerializeField]
	private GenericTooltip hireTooltip;

	public static Datacenter SelectedDatacenter => Database.State.Datacenters.Selected.CurrentValue;

	public void Initialize()
	{
		Initializer.Context(unlockButton).AddListener(delegate
		{
			Database.Commands.Datacenters.Unlock(SelectedDatacenter);
		}).Context(reprovisionButton)
			.AddListener(ManualReprovision)
			.Context(hireEngineerButton)
			.AddListener(delegate
			{
				Database.Commands.Datacenters.HireEngineer(SelectedDatacenter);
			})
			.Context(detailsPanel)
			.SetActive(active: false)
			.Each(nodes, delegate(DatacenterVisualizer node)
			{
				node.Setup();
			})
			.Invoke(CreateConnections)
			.Invoke(InitializeTooltip)
			.Invoke(Hide);
		R3.DisposableBag bag = default(R3.DisposableBag).AddTo(this);
		Database.State.Datacenters.Selected.Subscribe(HandleDatacenterSelected).AddTo(ref bag);
		Database.State.Datacenters.StateChanged.Subscribe(RefreshConnections).AddTo(ref bag);
		Database.State.Datacenters.StateChanged.Where((Datacenter dc) => dc == SelectedDatacenter).Subscribe(RefreshPanel).AddTo(ref bag);
		Database.State.Datacenters.ReprovisionChanged.Where((Datacenter dc) => dc == SelectedDatacenter).Subscribe(RefreshReprovisionProgress).AddTo(ref bag);
		Database.State.Resources.UptimePercentage.ThrottleLastHalfSecond().SubscribeToValueDisplay(UI.Registry.resources.uptime, NumericFormat.PercentageDetailed, 0.5f).AddTo(ref bag);
		EventHub.Scene.Subscribe(delegate
		{
			HandlePrestige();
		}, Array.Empty<MessageHandlerFilter<Prestiged>>()).AddTo(ref bag);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		UI.Registry.taskbar.world.ForcePressed();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
		UI.Registry.taskbar.world.Clear();
	}

	public void TriggerPacket(float speed, float length = 0.1f)
	{
		connections.SendRandomPulse(speed, length);
	}

	private void ManualReprovision()
	{
		float num = Database.Commands.Datacenters.ManualReprovision(SelectedDatacenter);
		Audio.PlaySfx(reprovisionAudio.Value(), 0.6f + num * 0.5f);
	}

	private void HandlePrestige()
	{
		foreach (DatacenterVisualizer node in nodes)
		{
			node.CheckState();
		}
		EnumUtility.GetValuesSkipNone<Datacenter>().Each(delegate(Datacenter dc)
		{
			connections.UpdateState(dc, DatacenterState.Unprovisioned);
		});
	}

	private void HandleDatacenterSelected(Datacenter datacenter)
	{
		if (datacenter == Datacenter.None)
		{
			detailsPanel.SetActive(value: false);
			return;
		}
		detailsPanel.SetActive(value: true);
		DatacenterData datacenterData = SelectedDatacenter.Data();
		priceField.SetText(NumericFormat.Currency.Format(datacenterData.cost));
		locationHandler.SetLocalizedString(datacenterData.TitleLocalized);
		RefreshPanel(datacenter);
	}

	private void RefreshPanel(Datacenter datacenter)
	{
		DatacenterState state = Database.State.Datacenters.GetState(SelectedDatacenter);
		RefreshPanelShared(state);
		if (state == DatacenterState.Unprovisioned || state == DatacenterState.Construction)
		{
			RefreshPanelPurchase(state);
		}
		else
		{
			RefreshPanelOperations(state);
		}
	}

	private void RefreshPanelShared(DatacenterState state)
	{
		stateHandler.SetLocalizedString(LocalizationUtility.For(state));
		stateHandler.Text.color = state.Value();
	}

	private void RefreshPanelPurchase(DatacenterState state)
	{
		purchasePanel.SetActive(value: true);
		operationsPanel.SetActive(value: false);
		unlockButton.gameObject.SetActive(state == DatacenterState.Unprovisioned);
		constructionLoadingbar.gameObject.SetActive(state == DatacenterState.Construction);
	}

	private void RefreshPanelOperations(DatacenterState state)
	{
		purchasePanel.SetActive(value: false);
		operationsPanel.SetActive(value: true);
		reprovisionButton.interactable = state == DatacenterState.Degraded || state == DatacenterState.Critical;
	}

	private void RefreshReprovisionProgress(Datacenter datacenter)
	{
		DatacenterDetails details = Database.State.Datacenters.GetDetails(datacenter);
		if (details != null)
		{
			if (details.State.Value == DatacenterState.Construction)
			{
				constructionLoadingbar.SetNormalizedValue(details.ReprovisionProgress.Value);
			}
			else
			{
				reprovisionLoadingBar.SetNormalizedValue(details.ReprovisionProgress.Value);
			}
		}
	}

	private void RefreshConnections(Datacenter datacenter)
	{
		DatacenterState state = Database.State.Datacenters.GetState(datacenter);
		connections.UpdateState(datacenter, state);
	}

	private void CreateConnections()
	{
		foreach (DatacenterData datacenter in from data in EnumUtility.GetValuesSkipNone<Datacenter>()
			select data.Data())
		{
			if (datacenter.prerequisite != Datacenter.None)
			{
				DatacenterVisualizer datacenterVisualizer = nodes.First((DatacenterVisualizer n) => n.datacenter == datacenter.prerequisite);
				DatacenterVisualizer to = nodes.First((DatacenterVisualizer n) => n.datacenter == (Datacenter)datacenter);
				connections.AddConnection(datacenterVisualizer, to);
			}
		}
	}

	private void InitializeTooltip()
	{
		IntVariable intVariable = new IntVariable();
		engineerHandler.AssetReference["datacenter_hiredengineers"] = intVariable;
		(from dc in Database.State.Datacenters.Selected.Merge(Database.State.Datacenters.HireChanged)
			where dc != Datacenter.None
			select dc).Subscribe(intVariable, delegate(Datacenter dc, IntVariable variable)
		{
			variable.Value = Database.State.Datacenters.GetDetails(dc)?.Engineers.Value ?? 0;
		}).AddTo(this);
		DoubleVariable doubleVariable = new DoubleVariable();
		hireTooltip.Tooltip.SetVariable("datacenter_costengineer", doubleVariable);
		(from dc in Database.State.Datacenters.Selected.Merge(Database.State.Datacenters.HireChanged).MergeTrigger(Database.Modifiers.ObserveMultiple(ModifierType.EngineerCost, ModifierType.EngineerCostScale))
			where dc != Datacenter.None
			select dc).Subscribe(doubleVariable, delegate(Datacenter dc, DoubleVariable variable)
		{
			variable.Value = Database.Commands.Datacenters.CalculateCostEngineer(dc);
		}).AddTo(this);
	}
}
