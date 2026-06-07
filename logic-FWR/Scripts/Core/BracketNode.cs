using System.Collections.Generic;
using System.Linq;

public class BracketNode : Node
{
	public override string NodeName => "bracket";

	public BracketNode(CodeWindow func, int startIndex, int endIndex)
		: base(func, startIndex, endIndex)
	{
	}

	public BracketNode(BoxedNodeParams boxedParams)
		: base(boxedParams)
	{
	}

	public override IEnumerable<double> Execute(ProgramState state, Execution execution, int depth)
	{
		return slots[0].Execute(state, execution, depth + 1);
	}

	public override Node DeepCopy(Dictionary<object, object> copies)
	{
		if (copies.TryGetValue(this, out var value))
		{
			return (Node)value;
		}
		copies[this] = new BracketNode(boxedParams)
		{
			slots = slots.Select((Node s) => s.DeepCopy(copies)).ToList()
		};
		return (Node)copies[this];
	}
}
