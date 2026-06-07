using System.Collections.Generic;
using HumanAPI;

public class SafetyFirstAchievement : Node
{
	public NodeInput hooksBeingUsedCorrectly;

	public NodeInput[] inputs;

	public NodeOutput output;

	public List<Carryable> ziplineHooks = new List<Carryable>();

	protected override void CollectAllSockets(List<NodeSocket> sockets)
	{
		base.CollectAllSockets(sockets);
		if (inputs != null && inputs.Length > 0)
		{
			for (int i = 0; i < inputs.Length; i++)
			{
				inputs[i].node = this;
				inputs[i].name = string.Format("Zipline {0}", i.ToString());
				sockets.Add(inputs[i]);
			}
		}
	}

	public override void Process()
	{
		if (hooksBeingUsedCorrectly.value < 2f)
		{
			return;
		}
		int i = 0;
		List<Carryable> list = ziplineHooks.FindAll((Carryable x) => inputs[i++].value >= 1f);
		for (i = 0; i < list.Count; i++)
		{
			for (int num = i + 1; num < list.Count; num++)
			{
				if (list[i].CurrentlyCarriedBy == list[num].CurrentlyCarriedBy)
				{
					output.SetValue(1f);
					return;
				}
			}
		}
		output.SetValue(0f);
	}
}
