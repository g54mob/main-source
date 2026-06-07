using UnityEngine;

namespace Motorways.Views
{
	public interface IOnScreenToolManager
	{
		bool IsPointInsideTool(Vector2 coordinates);
	}
}
