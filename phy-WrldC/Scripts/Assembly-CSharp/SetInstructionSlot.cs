using System;
using TMPro;
using UnityEngine.UI;

public class SetInstructionSlot : InstructionSlotBase
{
	private TMP_InputField valueInput;

	private TMP_Dropdown valueDropdown;

	private IOButton valueIOButton;

	private IOButton ioButton;

	private Button typeButton;

	private SetInstruction setInstruction;

	public event Action OnValueIOButtonClickedEvent;

	public event Action OnIOButtonClickedEvent;

	public event Action<SocketIO, bool> OnBlockHighlightChangedEvent;

	protected override void Awake()
	{
		base.Awake();
		valueInput = base.transform.FindComponent<TMP_InputField>("InputField", isRecursively: true);
		valueDropdown = base.transform.FindComponent<TMP_Dropdown>("ValueDropdown", isRecursively: true);
		valueIOButton = base.transform.FindComponent<IOButton>("ValueIOButton", isRecursively: true);
		ioButton = base.transform.FindComponent<IOButton>("IOButton", isRecursively: true);
		typeButton = base.transform.FindComponent<Button>("TypeButton", isRecursively: true);
		valueInput.onEndEdit.AddListener(EndEditHandler);
		valueDropdown.onValueChanged.AddListener(ValueDropdownChangedHandler);
		valueIOButton.OnButtonClickedEvent += delegate
		{
			this.OnValueIOButtonClickedEvent?.Invoke();
		};
		valueIOButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(setInstruction.SocketValueIO, isHighlighted);
		};
		ioButton.OnButtonClickedEvent += delegate
		{
			this.OnIOButtonClickedEvent?.Invoke();
		};
		ioButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(setInstruction.SocketInput, isHighlighted);
		};
		typeButton.onClick.AddListener(TypeButtonHandler);
	}

	private void EndEditHandler(string value)
	{
		if (float.TryParse(value, out var result))
		{
			setInstruction.Value = result;
		}
		else
		{
			valueInput.SetTextWithoutNotify(setInstruction.Value.ToString());
		}
	}

	private void ValueDropdownChangedHandler(int index)
	{
		setInstruction.ValueType = ((index == 2) ? SetValueType.Toggle : SetValueType.Normal);
		if (index != 2)
		{
			setInstruction.Value = ((index == 0) ? 0f : 1f);
		}
	}

	private void TypeButtonHandler()
	{
		if (valueInput.transform.parent.gameObject.activeSelf || valueDropdown.gameObject.activeSelf)
		{
			setInstruction.ValueType = SetValueType.IO;
		}
		else
		{
			setInstruction.ValueType = ((valueDropdown.value == 2) ? SetValueType.Toggle : SetValueType.Normal);
		}
		RefreshValues();
	}

	public void Initialize(SetInstruction instruction)
	{
		setInstruction = instruction;
		RefreshValues();
	}

	public void AttachValueLogicIO(LogicIO logicIO)
	{
		if (logicIO != null)
		{
			setInstruction.SocketValueIO.AttachIO(logicIO);
			RefreshValues();
		}
	}

	public void AttachLogicIO(LogicIO logicIO)
	{
		if (logicIO != null && logicIO.Direction == LogicIODirection.Input)
		{
			setInstruction.SocketInput.AttachIO(logicIO);
			RefreshValues();
		}
	}

	private void RefreshValues()
	{
		bool flag = setInstruction.ValueType == SetValueType.IO;
		bool flag2 = setInstruction.SocketInput.LogicIO != null && setInstruction.SocketInput.LogicIO.Type == LogicIOType.Bool;
		bool flag3 = setInstruction.ValueType == SetValueType.Toggle;
		valueInput.SetTextWithoutNotify(setInstruction.Value.ToString());
		if (flag2)
		{
			valueDropdown.value = (flag3 ? 2 : ((setInstruction.Value > 0.5f) ? 1 : 0));
		}
		valueIOButton.gameObject.SetActive(flag);
		valueInput.transform.parent.gameObject.SetActive(!flag2 && !flag);
		valueDropdown.gameObject.SetActive(flag2 && !flag);
		if (flag)
		{
			valueIOButton.SetLogicIO(setInstruction.SocketValueIO.LogicIO, isOnlyInput: false);
		}
		ioButton.SetLogicIO(setInstruction.SocketInput.LogicIO, isOnlyInput: true);
	}

	public override Instruction GetInstruction()
	{
		return setInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		this.OnValueIOButtonClickedEvent = null;
		this.OnIOButtonClickedEvent = null;
		this.OnBlockHighlightChangedEvent = null;
		setInstruction = null;
		ioButton.SetLogicIO(null, isOnlyInput: true);
	}
}
