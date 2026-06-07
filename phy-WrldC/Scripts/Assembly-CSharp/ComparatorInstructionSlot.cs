using System;
using TMPro;

public class ComparatorInstructionSlot : IfElseInstructionSlot
{
	private IOButton firstIOButton;

	private IOButton secondIOButton;

	private TMP_InputField secondInput;

	private TMP_Dropdown typeDropdown;

	private ComparatorInstruction comparatorInstruction;

	public event Action OnFirstIOButtonClickedEvent;

	public event Action OnSecondIOButtonClickedEvent;

	public event Action<bool> OnFirstBlockHighlightChangedEvent;

	public event Action<bool> OnSecondBlockHighlightChangedEvent;

	protected override void Awake()
	{
		base.Awake();
		firstIOButton = base.transform.FindComponent<IOButton>("FirstIOButton", isRecursively: true);
		secondIOButton = base.transform.FindComponent<IOButton>("SecondIOButton", isRecursively: true);
		secondInput = base.transform.FindComponent<TMP_InputField>("InputField", isRecursively: true);
		typeDropdown = base.transform.FindComponent<TMP_Dropdown>("TypeDropdown", isRecursively: true);
		firstIOButton.OnButtonClickedEvent += delegate
		{
			this.OnFirstIOButtonClickedEvent?.Invoke();
		};
		firstIOButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnFirstBlockHighlightChangedEvent?.Invoke(isHighlighted);
		};
		secondIOButton.OnButtonClickedEvent += delegate
		{
			this.OnSecondIOButtonClickedEvent?.Invoke();
		};
		secondIOButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnSecondBlockHighlightChangedEvent?.Invoke(isHighlighted);
		};
		secondInput.onEndEdit.AddListener(SecondValueEndEditHandler);
		typeDropdown.onValueChanged.AddListener(TypeDropdownValueChangedHandler);
	}

	private void SecondValueEndEditHandler(string value)
	{
		if (float.TryParse(value, out var result))
		{
			comparatorInstruction.Value = result;
		}
		else
		{
			secondInput.SetTextWithoutNotify(comparatorInstruction.Value.ToString());
		}
	}

	private void TypeDropdownValueChangedHandler(int index)
	{
		comparatorInstruction.ComparatorValue = ((index > 5) ? ComparatorValue.Constant : ComparatorValue.LogicIO);
		comparatorInstruction.ComparatorType = (ComparatorType)((index <= 5) ? index : (index - 6));
		int num = ConvertComparatorTypeToDropdownIndex();
		secondIOButton.gameObject.SetActive(num <= 5);
		secondInput.gameObject.SetActive(num > 5);
	}

	public void Initialize(ComparatorInstruction instruction)
	{
		InternalInitialize(instruction);
	}

	protected override void InternalInitialize(Instruction instruction)
	{
		base.InternalInitialize(instruction);
		comparatorInstruction = instruction as ComparatorInstruction;
		firstIOButton.SetLogicIO(comparatorInstruction.FirstSocketIO.LogicIO, isOnlyInput: false);
		secondIOButton.SetLogicIO(comparatorInstruction.SecondSocketIO.LogicIO, isOnlyInput: false);
		secondInput.SetTextWithoutNotify(comparatorInstruction.Value.ToString());
		int num = ConvertComparatorTypeToDropdownIndex();
		typeDropdown.SetValueWithoutNotify(num);
		secondIOButton.gameObject.SetActive(num <= 5);
		secondInput.gameObject.SetActive(num > 5);
	}

	public void AttachFirstLogicIO(LogicIO logicIO)
	{
		if (logicIO != null)
		{
			comparatorInstruction.FirstSocketIO.AttachIO(logicIO);
			firstIOButton.SetLogicIO(logicIO, isOnlyInput: false);
		}
	}

	public void AttachSecondLogicIO(LogicIO logicIO)
	{
		if (logicIO != null)
		{
			comparatorInstruction.SecondSocketIO.AttachIO(logicIO);
			secondIOButton.SetLogicIO(logicIO, isOnlyInput: false);
		}
	}

	private int ConvertComparatorTypeToDropdownIndex()
	{
		int comparatorType = (int)comparatorInstruction.ComparatorType;
		if (comparatorInstruction.ComparatorValue != ComparatorValue.LogicIO)
		{
			return comparatorType + 6;
		}
		return comparatorType;
	}

	public override Instruction GetInstruction()
	{
		return comparatorInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		this.OnFirstIOButtonClickedEvent = null;
		this.OnSecondIOButtonClickedEvent = null;
		this.OnFirstBlockHighlightChangedEvent = null;
		this.OnSecondBlockHighlightChangedEvent = null;
		comparatorInstruction = null;
		firstIOButton.SetLogicIO(null, isOnlyInput: false);
		secondIOButton.SetLogicIO(null, isOnlyInput: false);
	}
}
