using Unity.Profiling;

namespace Pathfinding.Drawing
{
	internal static class CommandBuilderSamplers
	{
		internal static readonly ProfilerMarker MarkerConvert;

		internal static readonly ProfilerMarker MarkerSetLayout;

		internal static readonly ProfilerMarker MarkerUpdateVertices;

		internal static readonly ProfilerMarker MarkerUpdateIndices;

		internal static readonly ProfilerMarker MarkerSubmesh;

		internal static readonly ProfilerMarker MarkerUpdateBuffer;

		internal static readonly ProfilerMarker MarkerProcessCommands;

		internal static readonly ProfilerMarker MarkerCreateTriangles;
	}
}
