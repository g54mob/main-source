using System.Collections.Generic;
using System.Linq;

public class DefNode : Node
{
	public string funcName;

	private bool isStatic;

	public override string NodeName => "def";

	public DefNode(string funcName, bool isStatic, CodeWindow func, int startIndex, int endIndex)
		: base(func, startIndex, endIndex)
	{
		this.funcName = funcName;
		this.isStatic = isStatic;
	}

	public DefNode(string funcName, bool isStatic, BoxedNodeParams boxedParams)
		: base(boxedParams)
	{
		this.funcName = funcName;
		this.isStatic = isStatic;
	}

	public override IEnumerable<double> Execute(ProgramState state, Execution execution, int depth)
	{
		ErrorsAndBreakpoints(state, execution, depth);
		Blink(state, execution);
		state.CurrentScope.SetVar(funcName, new PyFunction(funcName, slots[0], state.CurrentScope), checkShadow: true, isStatic);
		state.ReturnValue = new PyNone();
		if (CheckIncrementOpCount(state, execution, 1.0))
		{
			yield return 0.0;
		}
	}

	public override void CheckDependencies(ProgramState state, Execution execution)
	{
		state.currentDependencies.Add(("functions", boxedParams.wordStart, boxedParams.wordEnd));
	}

	public override Node DeepCopy(Dictionary<object, object> copies)
	{
		if (copies.TryGetValue(this, out var value))
		{
			return (Node)value;
		}
		copies[this] = new DefNode(funcName, isStatic, boxedParams)
		{
			slots = slots.Select((Node s) => s.DeepCopy(copies)).ToList()
		};
		return (Node)copies[this];
	}
}
