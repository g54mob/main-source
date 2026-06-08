using UnityEngine;

namespace Kitchen
{
	public class Jitter : MonoBehaviour
	{
		public float Distance = 0.1f;

		private void Start()
		{
			Vector2 vector = Random.insideUnitCircle * Distance;
			base.transform.localPosition += new Vector3(vector.x, 0f, vector.y);
		}
	}
}
