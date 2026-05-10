using System.Collections.Generic;
using System.Linq;

public class ReturnNode : Node
{
	public override string NodeName => "return";

	public ReturnNode(CodeWindow func, int startIndex, int endIndex)
		: base(func, startIndex, endIndex)
	{
	}

	public ReturnNode(BoxedNodeParams boxedParams)
		: base(boxedParams)
	{
	}

	public override IEnumerable<double> Execute(ProgramState state, Execution execution, int depth)
	{
		ErrorsAndBreakpoints(state, execution, depth);
		if (slots.Count > 0)
		{
			foreach (double item in slots[0].Execute(state, execution, depth + 1))
			{
				yield return item;
			}
		}
		else
		{
			state.ReturnValue = new PyNone();
		}
		Blink(state, execution);
		if (CheckIncrementOpCount(state, execution, 0.0))
		{
			yield return 0.0;
		}
		state.CurrentExecutingNode = this;
		throw new ReturnStatement(boxedParams.wordStart, boxedParams.wordEnd);
	}

	public override Node DeepCopy(Dictionary<object, object> copies)
	{
		if (copies.TryGetValue(this, out var value))
		{
			return (Node)value;
		}
		copies[this] = new ReturnNode(boxedParams)
		{
			slots = slots.Select((Node s) => s.DeepCopy(copies)).ToList()
		};
		return (Node)copies[this];
	}
}
