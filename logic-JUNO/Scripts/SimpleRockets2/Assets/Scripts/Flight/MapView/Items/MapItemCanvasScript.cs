using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapItemCanvasScript : MonoBehaviour
	{
		public Canvas Canvas { get; private set; }

		public MapItem MapItem { get; private set; }

		public void Initialize(MapItem mapItem, Canvas canvas)
		{
			MapItem = mapItem;
			Canvas = canvas;
		}
	}
}
