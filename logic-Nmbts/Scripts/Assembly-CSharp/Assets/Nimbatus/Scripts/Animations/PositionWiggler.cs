using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class PositionWiggler : MonoBehaviour
	{
		public float Size;

		public float Speed;

		private float _seeker;

		public void Start()
		{
			_seeker = Random.Range(0f, 100f);
		}

		public void Update()
		{
			_seeker += Time.deltaTime * Speed;
			float num = (Mathf.PerlinNoise(_seeker, 0f) - 0.5f) * 2f;
			float num2 = (Mathf.PerlinNoise(0f, _seeker) - 0.5f) * 2f;
			Vector3 vector = Vector3.right * num * Size + Vector3.up * num2 * Size;
			base.transform.position = base.transform.parent.position + vector;
		}
	}
}
