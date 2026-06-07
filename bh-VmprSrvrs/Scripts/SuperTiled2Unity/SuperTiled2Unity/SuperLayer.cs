using UnityEngine;

namespace SuperTiled2Unity
{
	public class SuperLayer : MonoBehaviour
	{
		[ReadOnly]
		public string m_TiledName;

		[ReadOnly]
		public float m_OffsetX;

		[ReadOnly]
		public float m_OffsetY;

		[ReadOnly]
		public float m_ParallaxX;

		[ReadOnly]
		public float m_ParallaxY;

		[ReadOnly]
		public float m_Opacity;

		[ReadOnly]
		public Color m_TintColor;

		[ReadOnly]
		public bool m_Visible;

		public Color CalculateColor()
		{
			return default(Color);
		}

		public float CalculateOpacity()
		{
			return 0f;
		}
	}
}
