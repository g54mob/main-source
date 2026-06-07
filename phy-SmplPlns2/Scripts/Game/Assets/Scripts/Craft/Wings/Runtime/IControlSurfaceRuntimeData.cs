using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Runtime
{
	public interface IControlSurfaceRuntimeData
	{
		int InputCount { get; }

		void GetInputRanges(Span<float2> ranges);

		ControlSurfaceRuntimeUpdateFunction GetUpdateFunction(List<IntPtr> mallocPtrs);
	}
}
