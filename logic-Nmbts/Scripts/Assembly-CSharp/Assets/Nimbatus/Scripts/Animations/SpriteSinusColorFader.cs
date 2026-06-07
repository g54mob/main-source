using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class SpriteSinusColorFader : MonoBehaviour
	{
		public Color colorA;

		public Color colorB;

		public float frequency = 1f;

		public bool randomStart = true;

		private SpriteRenderer spriteRenderer;

		private float time;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			if (randomStart)
			{
				time = Random.Range(0f, 3.1415f);
			}
			else
			{
				time = 0f;
			}
		}

		public void Update()
		{
			if (spriteRenderer != null)
			{
				time += Time.deltaTime;
				spriteRenderer.color = Color.Lerp(colorA, colorB, (Mathf.Cos(time * frequency * 3.1415f) + 1f) / 2f);
			}
		}

		public void SetTime(float t)
		{
			Mathf.Clamp(t, 0f, 1f);
			time = t * 3.1415f;
		}
	}
}
