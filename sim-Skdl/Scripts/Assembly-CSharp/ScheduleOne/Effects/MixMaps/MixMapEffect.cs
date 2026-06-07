using UnityEngine;

namespace ScheduleOne.Effects.MixMaps
{
	public class MixMapEffect : MonoBehaviour
	{
		public Effect Property;

		[Range(0.05f, 3f)]
		public float Radius;

		public Vector2 Position => default(Vector2);

		public void OnValidate()
		{
		}
	}
}
