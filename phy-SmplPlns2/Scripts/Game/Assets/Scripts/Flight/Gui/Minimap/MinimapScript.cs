using UnityEngine;

namespace Assets.Scripts.Flight.Gui.Minimap
{
	public class MinimapScript : MonoBehaviour
	{
		public enum MiniMapUpateType
		{
			RealTime = 0,
			Manual = 1,
			EdgeUpdate = 2
		}

		public RenderTexture MapTexture;

		public RenderTexture PoiTexture;

		public float Size = 15000f;

		public MiniMapUpateType UpdateType = MiniMapUpateType.EdgeUpdate;
	}
}
