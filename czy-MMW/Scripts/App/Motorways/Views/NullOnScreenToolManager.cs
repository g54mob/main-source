using UnityEngine;

namespace Motorways.Views
{
	public class NullOnScreenToolManager : IOnScreenToolManager
	{
		public bool IsPointInsideTool(Vector2 coordinates)
		{
			return false;
		}
	}
}
