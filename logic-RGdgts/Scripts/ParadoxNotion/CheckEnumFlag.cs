using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

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
