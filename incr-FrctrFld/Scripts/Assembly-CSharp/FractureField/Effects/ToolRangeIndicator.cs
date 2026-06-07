using UnityEngine;

namespace FractureField.Effects
{
	public class ToolRangeIndicator : MonoBehaviour
	{
		[Header("Range Indicator Settings")]
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private float duration;

		[SerializeField]
		private AnimationCurve alphaCurve;

		[SerializeField]
		private Color indicatorColor;

		private float timer;

		private float targetRadius;

		private void Awake()
		{
		}

		private void CreateDefaultCircleSprite()
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
	}
}
