using UnityEngine;

namespace GRP
{
	public class SpringVisual : MonoBehaviour
	{
		public LineRenderer line;

		public int points;

		private void Start()
		{
		}

		public void Build(float length, float turns, float radius, float spring)
		{
		}

		public void Build(SpringVisualOptions options)
		{
		}

		public Vector3 GetCurvePoint(SpringVisualOptions options, float t)
		{
			return default(Vector3);
		}

		public Vector3 GetCurveNormal(SpringVisualOptions options, float t)
		{
			return default(Vector3);
		}

		public void SetColor(Color color)
		{
		}
	}
}
