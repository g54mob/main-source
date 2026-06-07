using System;
using TMPro;
using UnityEngine.UI;

public class AccumulatorInstructionSlot : InstructionSlotBase
{
	private TMP_InputField valueInput;

	private IOButton valueIOButton;

	private IOButton ioButton;

	private Button typeButton;

	private AccumulatorInstruction accumulatorInstruction;

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
		valueInput.onEndEdit.AddListener(EndEditHandler);
		valueIOButton.OnButtonClickedEvent += delegate
		{
			this.OnValueIOButtonClickedEvent?.Invoke();
		};
		valueIOButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(accumulatorInstruction.SocketValueIO, isHighlighted);
		};
		ioButton.OnButtonClickedEvent += delegate
		{
			this.OnIOButtonClickedEvent?.Invoke();
		};
		ioButton.OnBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(accumulatorInstruction.SocketInput, isHighlighted);
		};
		typeButton.onClick.AddListener(TypeButtonHandler);
	}

	private void EndEditHandler(string value)
	{
		if (float.TryParse(value, out var result))
		{
			accumulatorInstruction.Value = result;
		}
		else
		{
			valueInput.SetTextWithoutNotify(accumulatorInstruction.Value.ToString());
		}
	}

	private void TypeButtonHandler()
	{
		if (valueInput.transform.parent.gameObject.activeSelf)
		{
			accumulatorInstruction.ValueType = AccumulatorInstruction.ValueTypeEnum.IO;
		}
		else
		{
			accumulatorInstruction.ValueType = AccumulatorInstruction.ValueTypeEnum.Constant;
		}
		RefreshValues();
	}

	public void Initialize(AccumulatorInstruction instruction)
	{
		accumulatorInstruction = instruction;
		RefreshValues();
	}

	public void AttachValueLogicIO(LogicIO logicIO)
	{
		if (logicIO != null)
		{
			accumulatorInstruction.SocketValueIO.AttachIO(logicIO);
			RefreshValues();
		}
	}

	public void AttachLogicIO(LogicIO logicIO)
	{
		if (logicIO != null && logicIO.Direction == LogicIODirection.Input)
		{
			accumulatorInstruction.SocketInput.AttachIO(logicIO);
			RefreshValues();
		}
	}

	private void RefreshValues()
	{
		bool flag = accumulatorInstruction.ValueType == AccumulatorInstruction.ValueTypeEnum.IO;
		valueInput.SetTextWithoutNotify(accumulatorInstruction.Value.ToString());
		valueIOButton.gameObject.SetActive(flag);
		valueInput.transform.parent.gameObject.SetActive(!flag);
		if (flag)
		{
			valueIOButton.SetLogicIO(accumulatorInstruction.SocketValueIO.LogicIO, isOnlyInput: false);
		}
		ioButton.SetLogicIO(accumulatorInstruction.SocketInput.LogicIO, isOnlyInput: true);
	}

	public override Instruction GetInstruction()
	{
		return accumulatorInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		this.OnValueIOButtonClickedEvent = null;
		this.OnIOButtonClickedEvent = null;
		this.OnBlockHighlightChangedEvent = null;
		accumulatorInstruction = null;
		ioButton.SetLogicIO(null, isOnlyInput: true);
	}
}
