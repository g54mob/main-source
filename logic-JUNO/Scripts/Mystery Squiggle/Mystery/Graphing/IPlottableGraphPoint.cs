using UnityEngine;

namespace Mystery.Graphing
{
	public interface IPlottableGraphPoint
	{
		object ValueX { get; }

		object ValueY { get; }

		Color Color { get; }
	}
}
