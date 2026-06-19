using System.Collections.Generic;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class SimpleSpriteAnimationLoop : MonoBehaviour
	{
		[HideInInspector]
		public float frameOffset;

		public float frameTime = 0.2f;

		public List<Sprite> animationFrames;

		private SpriteRenderer spriteRenderer;

		private float resetTime;

		public List<SpriteRenderer> optionalAdditionalRenderers;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void LateUpdate()
		{
			float num = Time.time - resetTime;
			if ((double)num < 0.001)
			{
				spriteRenderer.sprite = animationFrames[0];
				{
					foreach (SpriteRenderer optionalAdditionalRenderer in optionalAdditionalRenderers)
					{
						optionalAdditionalRenderer.sprite = animationFrames[0];
					}
					return;
				}
			}
			int num2 = Mathf.RoundToInt((num + frameOffset) / frameTime);
			spriteRenderer.sprite = animationFrames[num2 % animationFrames.Count];
			foreach (SpriteRenderer optionalAdditionalRenderer2 in optionalAdditionalRenderers)
			{
				optionalAdditionalRenderer2.sprite = animationFrames[num2 % animationFrames.Count];
			}
		}

		public void ResetTimer()
		{
			resetTime = Time.time;
		}

		public void SetAlpha(float alpha)
		{
			spriteRenderer.SetAlpha(alpha);
			foreach (SpriteRenderer optionalAdditionalRenderer in optionalAdditionalRenderers)
			{
				optionalAdditionalRenderer.SetAlpha(alpha);
			}
		}
	}
}
