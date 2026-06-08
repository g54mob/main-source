using UnityEngine;

namespace Kitchen
{
	public class Scale : MonoBehaviour
	{
		public float Min = 0.75f;

		public float Max = 1.25f;

		private void Start()
		{
			base.transform.localScale = Vector3.one * Random.Range(Min, Max);
		}
	}
}
