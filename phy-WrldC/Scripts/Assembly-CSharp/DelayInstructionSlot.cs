using TMPro;

public class DelayInstructionSlot : InstructionSlotBase
{
	private TMP_InputField valueInput;

	private DelayInstruction delayInstruction;

	protected override void Awake()
	{
		base.Awake();
		valueInput = base.transform.FindComponent<TMP_InputField>("InputField", isRecursively: true);
		valueInput.onEndEdit.AddListener(EndEditHandler);
	}

	private void EndEditHandler(string value)
	{
		if (int.TryParse(value, out var result))
		{
			if (result >= 0 && result != delayInstruction.Time)
			{
				delayInstruction.Time = result;
			}
			else
			{
				valueInput.SetTextWithoutNotify(delayInstruction.Time.ToString());
			}
		}
		else
		{
			valueInput.SetTextWithoutNotify(delayInstruction.Time.ToString());
		}
	}

	public void Initialize(DelayInstruction instruction)
	{
		delayInstruction = instruction;
		valueInput.SetTextWithoutNotify(delayInstruction.Time.ToString());
	}

	public override Instruction GetInstruction()
	{
		return delayInstruction;
	}

	public override void OnUnistantiation()
	{
		base.OnUnistantiation();
		delayInstruction = null;
	}
}
