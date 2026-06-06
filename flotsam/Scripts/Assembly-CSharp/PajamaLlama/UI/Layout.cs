using UnityEngine;

namespace PajamaLlama.UI
{
	public class Layout : MonoBehaviour
	{
		public static Vector2 ReturnPositionInGrid(Vector2 grid, int index)
		{
			float y = Mathf.Floor((float)index / grid.x);
			return new Vector2((float)index % grid.x, y);
		}
	}
}
