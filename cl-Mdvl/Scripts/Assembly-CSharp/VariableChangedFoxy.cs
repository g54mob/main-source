using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

[Name("On Variable Changed Foxy", 0)]
[Category("✫ Blackboard")]
public class VariableChangedFoxy : ConditionTask
{
	[BlackboardOnly]
	public BBObjectParameter targetVariable;

	private bool wasChanged;

	protected override string info => targetVariable?.ToString() + " Changed.";

	protected override string OnInit()
	{
		if (targetVariable.isNone)
		{
			return "Blackboard Variable not set.";
		}
		return null;
	}

	protected override void OnEnable()
	{
		targetVariable.varRef.onValueChanged += OnValueChanged;
	}

	protected override void OnDisable()
	{
		targetVariable.varRef.onValueChanged -= OnValueChanged;
	}

	protected override bool OnCheck()
	{
		if (!wasChanged)
		{
			return false;
		}
		wasChanged = false;
		return true;
	}

	private void OnValueChanged(object varValue)
	{
		wasChanged = true;
	}
}
