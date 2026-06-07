using System;

namespace Pathfinding.ECS
{
	public class ManagedMovementOverrideBeforeControl : ManagedMovementOverride<BeforeControlDelegate>, ICloneable
	{
		public object Clone()
		{
			return null;
		}
	}
}
