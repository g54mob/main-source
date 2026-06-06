using System;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.UI;

public class OperationVisualizer : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private LocalizeStringHandler labelHandler;

	private OperationData _data;

	private DoubleVariable _costVariable;

	private FloatVariable _durationVariable;

	[field: SerializeField]
	public Tooltip Tooltip { get; private set; }

	public void Setup(OperationData data)
	{
		Initializer.Assign(data, out _data).Context(button).AddListener(delegate
		{
			Database.Commands.Operations.StartOperation(_data);
		})
			.Context(labelHandler)
			.SetLocalized(data.TitleLocalized)
			.Invoke(InitializeHighlight)
			.Invoke(InitializeTooltip)
			.Invoke(HandlePrestige)
			.SceneEvents()
			.Subscribe(delegate(OperationUnlocked ctx)
			{
				HandleOperationUnlockedLocked(ctx.Operation);
			})
			.Subscribe(delegate(OperationLocked ctx)
			{
				HandleOperationUnlockedLocked(ctx.Operation);
			})
			.Subscribe(delegate(OperationStarted ctx)
			{
				HandleOperationStartFinish(ctx.Operation);
			})
			.Subscribe(delegate(OperationFinished ctx)
			{
				HandleOperationStartFinish(ctx.Operation);
			})
			.Subscribe(delegate
			{
				HandlePrestige();
			}, Array.Empty<MessageHandlerFilter<Prestiged>>())
			.Build(UI.Registry.footer.operations);
		Database.Modifiers.ObserveAsInt(ModifierType.OperationConcurrentAmount).Subscribe(this, delegate(int _, OperationVisualizer x)
		{
			x.RefreshAvailability();
		}).AddTo(this);
	}

	private void HandlePrestige()
	{
		HandleOperationUnlockedLocked(_data);
	}

	private void HandleOperationUnlockedLocked(Operation operation)
	{
		if (operation == (Operation)_data)
		{
			base.gameObject.SetActive(Database.State.Operations.IsUnlocked(_data));
			RefreshAvailability();
		}
	}

	private void HandleOperationStartFinish(Operation operation)
	{
		if (operation == (Operation)_data)
		{
			RefreshTooltip();
		}
		RefreshAvailability();
	}

	private void InitializeHighlight()
	{
		(GnormanAction, int)? tuple = null;
		if (_data.ID == Operation.ReleaseGame)
		{
			tuple = (GnormanAction.ATutorialIntroduction, 6);
		}
		if (_data.ID == Operation.BuyServerNode)
		{
			tuple = (GnormanAction.BTutorialServerload, 3);
		}
		if (tuple.HasValue)
		{
			GnormanHighlighting component = GetComponent<GnormanHighlighting>();
			component.Configure(tuple.Value.Item1, tuple.Value.Item2);
			component.enabled = true;
		}
	}

	private void InitializeTooltip()
	{
		if (_costVariable == null)
		{
			_costVariable = new DoubleVariable();
		}
		if (_durationVariable == null)
		{
			_durationVariable = new FloatVariable();
		}
		(string, IVariable)[] variablesDescription = new(string, IVariable)[3]
		{
			("operation_description", _data.DescriptionLocalized),
			("operation_cost", _costVariable),
			("operation_duration", _durationVariable)
		};
		Tooltip.SetVariableTitle("operation_title", _data.TitleLocalized);
		Tooltip.SetVariablesDescription(variablesDescription);
	}

	private void RefreshAvailability()
	{
		button.interactable = Database.Commands.Operations.CanStartOperation(_data);
	}

	public void RefreshTooltip()
	{
		if (_data.ID == Operation.LineOfCredit)
		{
			RefreshLineOfCreditTooltip();
			return;
		}
		_costVariable.Value = Database.Commands.Operations.CalculateCost(_data);
		_durationVariable.Value = Database.Commands.Operations.CalculateDuration(_data);
	}

	private void RefreshLineOfCreditTooltip()
	{
		_costVariable.Value = ModifierType.OperationLineOfCreditLoan.Float();
		_durationVariable.Value = ModifierType.OperationLineOfCreditLoan.Float() * ModifierType.OperationLineOfCreditInterest.Float();
	}
}
