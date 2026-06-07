using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Graphics
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteAnimation : BaseSpriteAnimation
	{
		private SpriteRenderer _spriteRenderer;

		private ArcadeSprite _arcadeSpriteToUpdate;

		private float2 _originalSpriteSize;

		protected override void Awake()
		{
		}

		public void ForceInit()
		{
		}

		protected override void ApplySpriteFrame(Sprite sprite)
		{
		}

		public void SetOriginalSpriteSize(float2 spriteSize)
		{
		}

		public void AddAnimation(string animName, SpriteAnimationData spriteAnimation, int fps, bool shouldLoop, bool startRandomFrame = false, Action onComplete = null, bool autoSetAnimation = true)
		{
		}
	}
}
