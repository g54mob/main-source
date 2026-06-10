namespace NSMedieval.Pathfinding
{
	public static class CompleteModeConditions
	{
		public static bool IsCompleteModeFulfilled(Vec3Int agent, Vec3Int target, PathCompleteMode mode)
		{
			return mode switch
			{
				PathCompleteMode.ExactPosition => agent == target, 
				PathCompleteMode.Touch => Vec3Int.Distance(in agent, in target) <= 2f, 
				PathCompleteMode.Partial => Vec3Int.Distance(in agent, in target) <= 2f, 
				PathCompleteMode.NeverFail => true, 
				_ => false, 
			};
		}
	}
}
