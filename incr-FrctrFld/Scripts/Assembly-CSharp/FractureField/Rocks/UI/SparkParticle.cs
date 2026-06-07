using UnityEngine;

namespace FractureField.Rocks.UI
{
	public class SparkParticle : MonoBehaviour
	{
		private Vector3 velocity;

		private float lifetime;

		private float maxLifetime;

		[SerializeField]
		private SpriteRenderer spriteRenderer;

		private float gravity;

		private float fadeStartTime;

		private float releaseTime;

		private bool isReleasing;

		private float rotationSpeed;

		public void Initialize(Vector3 initialVelocity, Color color, float sparkLifetime)
		{
		}

		private void Update()
		{
		}
	}
}
