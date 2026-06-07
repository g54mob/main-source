using UnityEngine;

namespace Ludiq
{
	public interface IMachine : IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
	{
		IGraphData graphData { get; set; }

		GameObject threadSafeGameObject { get; }
	}
}
