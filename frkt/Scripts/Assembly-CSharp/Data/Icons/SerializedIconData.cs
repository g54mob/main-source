using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Icons
{
	[CreateAssetMenu(fileName = "SerializedIconData", menuName = "FRUKT/IconData")]
	public class SerializedIconData : SerializedScriptableObject, bjo
	{
		[SerializeField]
		private Sprite m_sprite;

		[SerializeField]
		private Vector2 m_offset;

		[SerializeField]
		private Vector2 m_scale;

		[SerializeField]
		private Color m_color;

		public Sprite tck => null;

		public Vector2 tcl => default(Vector2);

		public Vector2 tcm => default(Vector2);

		public Color tcn => default(Color);
	}
}
