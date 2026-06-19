using System;

namespace TheKiwiCoder
{
	[Serializable]
	public class Parallel : CompositeNode
	{
		public int successThreshold = 1;

		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			int count = children.Count;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < count; i++)
			{
				switch (children[i].Update())
				{
				case State.Success:
					num++;
					break;
				case State.Failure:
					num2++;
					break;
				}
			}
			if (num >= successThreshold)
			{
				return State.Success;
			}
			if (num2 > count - successThreshold)
			{
				return State.Failure;
			}
			return State.Running;
		}
	}
}
