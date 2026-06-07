using System.Collections.Generic;

public interface INavigatorPath
{
	ITarget Target { get; }

	bool AllowIncompletePath { get; }

	bool PathPending { get; }

	bool Navigating { get; }

	bool NoPathFound { get; }

	bool NeedRecalculation { get; }

	List<PathfindingNode> Path { get; }

	void ClearPath();
}
