using System.Collections.Generic;
using System.Linq;

public class ValueNode : Node
{
	public string value;

	public override string NodeName => "value";

	public ValueNode(string value, CodeWindow func, int startIndex, int endIndex)
		: base(func, startIndex, endIndex)
	{
		this.value = value;
	}

	public ValueNode(string value, BoxedNodeParams boxedParams)
		: base(boxedParams)
	{
		this.value = value;
	}

	public override IEnumerable<double> Execute(ProgramState state, Execution execution, int depth)
	{
		ErrorsAndBreakpoints(state, execution, depth);
		Blink(state, execution);
		(state.ReturnValue, state.IsExpressionStatic) = state.CurrentScope.Evaluate(value, boxedParams.codeWindow.fileName);
		yield break;
	}

	public override Node DeepCopy(Dictionary<object, object> copies)
	{
		if (copies.TryGetValue(this, out var obj))
		{
			return (Node)obj;
		}
		copies[this] = new ValueNode(value, boxedParams)
		{
			slots = slots.Select((Node s) => s.DeepCopy(copies)).ToList()
		};
		return (Node)copies[this];
	}
}
