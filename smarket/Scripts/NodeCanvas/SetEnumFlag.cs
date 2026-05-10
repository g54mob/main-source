using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

[Category("✫ Blackboard")]
public class SetEnumFlag : ActionTask
{
	[BlackboardOnly]
	[RequiredField]
	public readonly BBObjectParameter Variable;

	public readonly BBObjectParameter Flag;

	public readonly BBParameter<bool> Clear;

	protected override string info => null;

	protected override void OnExecute()
	{
	}
}
