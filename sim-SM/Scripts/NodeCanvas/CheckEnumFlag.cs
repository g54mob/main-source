using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

[Category("✫ Blackboard")]
public class CheckEnumFlag : ConditionTask
{
	[BlackboardOnly]
	[RequiredField]
	public readonly BBObjectParameter Variable;

	public readonly BBObjectParameter Flag;

	protected override string info => null;

	protected override bool OnCheck()
	{
		return false;
	}
}
