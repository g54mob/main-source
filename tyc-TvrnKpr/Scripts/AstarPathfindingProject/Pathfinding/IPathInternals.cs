using System.Text;

namespace Pathfinding
{
	internal interface IPathInternals
	{
		bool Pooled { get; set; }

		void AdvanceState(PathState s);

		void OnEnterPool();

		void Reset();

		void ReturnPath();

		void PrepareBase(PathHandler handler);

		void Prepare(ref Path.SearchContext ctx);

		void Cleanup(ref Path.SearchContext ctx);

		void CalculateStep(ref Path.SearchContext ctx, long targetTick);

		void DebugString(StringBuilder builder, PathLog logMode);
	}
}
