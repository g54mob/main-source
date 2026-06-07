using UnityEngine;

namespace VampireSurvivors.Framework.Geom
{
	public class PolygonComponent : MonoBehaviour
	{
		public Polygon _polygon;

		public float _rotationAngle;

		public bool _fallRegion;

		public Polygon GetWorldSpacePolygon()
		{
			return null;
		}
	}
}
