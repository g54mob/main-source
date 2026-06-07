using System.Collections.Generic;
using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	public delegate void UpdateGroupDebugCallback(string name, bool parallel, int executionOrder, IEnumerable<IGameLoopItem> items);
}
