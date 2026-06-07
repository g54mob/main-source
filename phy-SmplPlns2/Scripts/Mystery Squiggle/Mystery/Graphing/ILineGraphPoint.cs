using UnityEngine;

namespace Mystery.Graphing
{
	public interface ILineGraphPoint
	{
		object ValueX { get; }

		object ValueY { get; }

		Color Color { get; }
	}
}
