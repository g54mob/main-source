using System;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class TrebuchetGoapAgent : Agent
	{
		public TrebuchetGoapAgent(IGoapAgentOwner owner)
			: base(owner)
		{
		}

		public override AnimatedAgentView GetView()
		{
			throw new NotImplementedException();
		}
	}
}
