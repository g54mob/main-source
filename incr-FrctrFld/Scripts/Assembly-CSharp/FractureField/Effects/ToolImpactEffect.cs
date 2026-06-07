using UnityEngine;

namespace FractureField.Effects
{
	public class ToolImpactEffect : MonoBehaviour
	{
		[Header("Effect Settings")]
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private float duration;

		[SerializeField]
		private AnimationCurve scaleCurve;

		[SerializeField]
		private AnimationCurve alphaCurve;

		[SerializeField]
		private Color impactColor;

		private float timer;

		private Vector3 originalScale;

		private void Awake()
		{
		}

		private void CreateDefaultImpactSprite()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
