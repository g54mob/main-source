using System.Collections.Generic;
using System.Linq;

public class LiteralNode : Node
{
	public IPyObject value;

	public override string NodeName => "literal";

	public LiteralNode(IPyObject value, CodeWindow func, int startIndex, int endIndex)
		: base(func, startIndex, endIndex)
	{
		this.value = value;
	}

	public LiteralNode(IPyObject value, BoxedNodeParams boxedParams)
		: base(boxedParams)
	{
		this.value = value;
	}

	public override IEnumerable<double> Execute(ProgramState state, Execution execution, int depth)
	{
		ErrorsAndBreakpoints(state, execution, depth);
		Blink(state, execution);
		state.ReturnValue = value;
		state.IsExpressionStatic = false;
		yield break;
	}

	public override Node DeepCopy(Dictionary<object, object> copies)
	{
		if (copies.TryGetValue(this, out var obj))
		{
			return (Node)obj;
		}
		copies[this] = new LiteralNode(value, boxedParams)
		{
			slots = slots.Select((Node s) => s.DeepCopy(copies)).ToList()
		};
		return (Node)copies[this];
	}
}
