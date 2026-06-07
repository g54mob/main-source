using UnityEngine;

namespace VampireSurvivors.Framework.Geom
{
	public class PolygonGroupComponent : MonoBehaviour
	{
		private Rect? _computedBounds;

		public Rect Bounds => default(Rect);
	}
}
