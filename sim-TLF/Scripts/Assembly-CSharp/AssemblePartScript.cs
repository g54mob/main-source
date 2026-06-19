using System;
using TheKiwiCoder;

[Serializable]
public class AssemblePartScript : CompositeNode
{
	protected override void OnStart()
	{
	}

	protected override void OnStop()
	{
	}

	protected override State OnUpdate()
	{
		return State.Success;
	}
}
