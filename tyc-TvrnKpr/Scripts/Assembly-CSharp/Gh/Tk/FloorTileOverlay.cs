using UnityEngine;

namespace Gh.Tk
{
	public class FloorTileOverlay : MonoBehaviour
	{
		public enum VisualizationMode
		{
			ColorRooms = 0,
			ShowAreaEffect = 1
		}

		public static VisualizationMode DisplayMode;

		public static string AreaEffectToDisplay;

		public TileData tileData;

		private Renderer _renderer;

		public void Awake()
		{
		}

		public void UpdateColor(Color color)
		{
		}

		public void UpdateRoomColor()
		{
		}

		private Color GetColorForRoom(Room room)
		{
			return default(Color);
		}

		private void UpdateEffectIntensityColor(int intensity)
		{
		}
	}
}
