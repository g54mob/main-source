using System.Collections.Generic;

namespace Shapes
{
	internal interface IDashable
	{
		List<float> dashSize { get; }

		List<float> dashType { get; }

		List<float> dashShapeModifier { get; }

		List<float> dashSpace { get; }

		List<float> dashSnap { get; }

		List<float> dashOffset { get; }

		List<float> dashSpacing { get; }
	}
}
