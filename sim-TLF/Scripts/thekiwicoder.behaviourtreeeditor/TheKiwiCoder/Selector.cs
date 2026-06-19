using System;

namespace TheKiwiCoder
{
	[Serializable]
	public class Selector : CompositeNode
	{
		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			for (int i = 0; i < children.Count; i++)
			{
				switch (children[i].Update())
				{
				case State.Running:
					return State.Running;
				case State.Success:
					return State.Success;
				}
			}
			return State.Failure;
		}
	}
}
