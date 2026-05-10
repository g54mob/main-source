using System.Collections.Generic;
using System.Linq;

public class TupleNode : Node
{
	public override string NodeName => "tuple";

	public TupleNode(CodeWindow func, int startIndex, int endIndex)
		: base(func, startIndex, endIndex)
	{
	}

	public TupleNode(BoxedNodeParams boxedParams)
		: base(boxedParams)
	{
	}

	public override IEnumerable<double> Execute(ProgramState state, Execution execution, int depth)
	{
		ErrorsAndBreakpoints(state, execution, depth);
		foreach (double item in slots[0].Execute(state, execution, depth + 1))
		{
			yield return item;
		}
		List<IPyObject> elements = ((InternalPySequence)state.ReturnValue).elements.ToList();
		state.ReturnValue = new PyTuple(elements);
		state.IsExpressionStatic = false;
		if (CheckIncrementOpCount(state, execution, 1.0))
		{
			yield return 0.0;
		}
	}

	public override Node DeepCopy(Dictionary<object, object> copies)
	{
		if (copies.TryGetValue(this, out var value))
		{
			return (Node)value;
		}
		copies[this] = new TupleNode(boxedParams)
		{
			slots = slots.Select((Node s) => s.DeepCopy(copies)).ToList()
		};
		return (Node)copies[this];
	}
}
