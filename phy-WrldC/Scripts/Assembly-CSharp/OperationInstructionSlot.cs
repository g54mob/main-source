using System;
using TMPro;
using UnityEngine.UI;

public class OperationInstructionSlot : InstructionSlotBase
{
	private TMP_InputField valueInput;

	private IOButton valueIOButton;

	private IOButton ioButton;

	private Button typeButton;

	private TMP_Dropdown operationTypeDropdown;

	private OperationInstruction operationInstruction;

	public event Action OnValueIOButtonClickedEvent;

	public event Action OnIOButtonClickedEvent;

	public event Action<SocketIO, bool> OnBlockHighlightChangedEvent;

	protected override void Awake()
	{
		base.Awake();
		valueInput = base.transform.FindComponent<TMP_InputField>("InputField", isRecursively: true);
		valueIOButton = base.transform.FindComponent<IOButton>("ValueIOButton", isRecursively: true);
		ioButton = base.transform.FindComponent<IOButton>("IOButton", isRecursively: true);
		typeButton = base.transform.FindComponent<Button>("TypeButton", isRecursively: true);
		operationTypeDropdown = base.transform.FindComponent<TMP_Dropdown>("OperationTypeDropdown", isRecursively: true);
		valueInput.onEndEdit.AddListener(EndEditHandler);
		valueIOButton.OnButtonClickedEvent += delegate
		{
			this.OnValueIOButtonClickedEvent?.Invoke();
		};
		valueIOButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(operationInstruction.SocketValueIO, isHighlighted);
		};
		ioButton.OnButtonClickedEvent += delegate
		{
			this.OnIOButtonClickedEvent?.Invoke();
		};
		ioButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(operationInstruction.SocketInput, isHighlighted);
		};
		typeButton.onClick.AddListener(TypeButtonHandler);
		operationTypeDropdown.onValueChanged.AddListener(delegate(int index)
		{
			operationInstruction.OperationType = (OperationInstruction.OperationTypeEnum)index;
		});
	}

	private void EndEditHandler(string value)
	{
		if (float.TryParse(value, out var result))
		{
			operationInstruction.Value = result;
		}
		else
		{
			valueInput.SetTextWithoutNotify(operationInstruction.Value.ToString());
		}
	}

	private void TypeButtonHandler()
	{
		if (valueInput.transform.parent.gameObject.activeSelf)
		{
			operationInstruction.ValueType = OperationInstruction.ValueTypeEnum.IO;
		}
		else
		{
			operationInstruction.ValueType = OperationInstruction.ValueTypeEnum.Constant;
		}
		RefreshValues();
	}

	public void Initialize(OperationInstruction instruction)
	{
		operationInstruction = instruction;
		RefreshValues();
	}

	public void AttachValueLogicIO(LogicIO logicIO)
	{
		if (logicIO != null)
		{
			operationInstruction.SocketValueIO.AttachIO(logicIO);
			RefreshValues();
		}
	}

	public void AttachLogicIO(LogicIO logicIO)
	{
		if (logicIO != null && logicIO.Direction == LogicIODirection.Input)
		{
			operationInstruction.SocketInput.AttachIO(logicIO);
			RefreshValues();
		}
	}

	private void RefreshValues()
	{
		bool flag = operationInstruction.ValueType == OperationInstruction.ValueTypeEnum.IO;
		valueInput.SetTextWithoutNotify(operationInstruction.Value.ToString());
		valueIOButton.gameObject.SetActive(flag);
		valueInput.transform.parent.gameObject.SetActive(!flag);
		if (flag)
		{
			valueIOButton.SetLogicIO(operationInstruction.SocketValueIO.LogicIO, isOnlyInput: false);
		}
		ioButton.SetLogicIO(operationInstruction.SocketInput.LogicIO, isOnlyInput: true);
		operationTypeDropdown.SetValueWithoutNotify((int)operationInstruction.OperationType);
	}

	public override Instruction GetInstruction()
	{
		return operationInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		this.OnValueIOButtonClickedEvent = null;
		this.OnIOButtonClickedEvent = null;
		this.OnBlockHighlightChangedEvent = null;
		operationInstruction = null;
		ioButton.SetLogicIO(null, isOnlyInput: true);
	}
}
