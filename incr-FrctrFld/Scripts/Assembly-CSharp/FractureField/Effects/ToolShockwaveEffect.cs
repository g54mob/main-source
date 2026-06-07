using UnityEngine;

namespace FractureField.Effects
{
	public class ToolShockwaveEffect : MonoBehaviour
	{
		[Header("Shockwave Settings")]
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private float duration;

		[SerializeField]
		private AnimationCurve scaleCurve;

		[SerializeField]
		private AnimationCurve alphaCurve;

		[SerializeField]
		private Color shockwaveColor;

		[SerializeField]
		private float ringThickness;

		private float timer;

		private float targetRadius;

		private Material shockwaveMaterial;

		private void Awake()
		{
		}

		private void CreateDefaultShockwaveSprite()
		{
		}

		private void DrawRing(Texture2D texture, Vector2 center, float radius, float thickness, float intensity)
		{
		}

		public void SetRadius(float radius)
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
