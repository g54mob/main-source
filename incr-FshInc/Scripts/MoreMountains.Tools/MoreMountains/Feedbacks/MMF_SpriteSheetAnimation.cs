using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("A feedback used to quickly animate a sprite renderer or an image using a list of sprites, looping or not, at a specified frame rate, with an optional random offset.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Animation/Sprite Sheet Animation")]
	public class MMF_SpriteSheetAnimation : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Targets", true, 13, true, false)]
		[Tooltip("the list of SpriteRenderers to animate")]
		public List<SpriteRenderer> TargetSpriteRenderers;

		[Tooltip("the the list of Images to animate")]
		public List<Image> TargetImages;

		[MMFInspectorGroup("Animation", true, 12, true, false)]
		[Tooltip("a list of sprites to use as the sequential animation")]
		public List<Sprite> AnimationSprites;

		[Tooltip("the number of frames per second to use for the animation")]
		public int FrameRate = 12;

		[Tooltip("the minimum and maximum random offset to apply to the animation, useful to create a bit of variety in the animation")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2Int RandomOffset = Vector2Int.zero;

		[Tooltip("whether the animation should loop or not once it reaches the last sprite in the AnimationSprites list")]
		public bool Loop;

		protected Coroutine _animationCoroutine;

		protected List<int> _spriteRendererOffsets;

		protected List<int> _imageOffsets;

		protected List<Sprite> _spriteRendererInitialSprites;

		protected List<Sprite> _imageInitialSprites;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DetermineDuration());
			}
			set
			{
			}
		}

		protected virtual float DetermineDuration()
		{
			if (AnimationSprites == null)
			{
				return 0f;
			}
			if (AnimationSprites.Count > 0)
			{
				return (float)AnimationSprites.Count / (float)FrameRate;
			}
			return 0f;
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			_spriteRendererInitialSprites = new List<Sprite>();
			if (TargetSpriteRenderers == null)
			{
				TargetSpriteRenderers = new List<SpriteRenderer>();
			}
			if (TargetImages == null)
			{
				TargetImages = new List<Image>();
			}
			foreach (SpriteRenderer targetSpriteRenderer in TargetSpriteRenderers)
			{
				if (targetSpriteRenderer == null)
				{
					_spriteRendererInitialSprites.Add(null);
				}
				else
				{
					_spriteRendererInitialSprites.Add(targetSpriteRenderer.sprite);
				}
			}
			_imageInitialSprites = new List<Sprite>();
			foreach (Image targetImage in TargetImages)
			{
				if (targetImage == null)
				{
					_imageInitialSprites.Add(null);
				}
				else
				{
					_imageInitialSprites.Add(targetImage.sprite);
				}
			}
			_spriteRendererOffsets = new List<int>();
			foreach (SpriteRenderer targetSpriteRenderer2 in TargetSpriteRenderers)
			{
				_ = targetSpriteRenderer2;
				int item = Random.Range(RandomOffset.x, RandomOffset.y + 1);
				_spriteRendererOffsets.Add(item);
			}
			_imageOffsets = new List<int>();
			foreach (Image targetImage2 in TargetImages)
			{
				_ = targetImage2;
				int item2 = Random.Range(RandomOffset.x, RandomOffset.y + 1);
				_imageOffsets.Add(item2);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			base.CustomRestoreInitialValues();
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			StopAnimationCoroutine();
			for (int i = 0; i < TargetSpriteRenderers.Count; i++)
			{
				if (!(TargetSpriteRenderers[i] == null))
				{
					TargetSpriteRenderers[i].sprite = _spriteRendererInitialSprites[i];
				}
			}
			for (int j = 0; j < TargetImages.Count; j++)
			{
				if (!(TargetImages[j] == null))
				{
					TargetImages[j].sprite = _imageInitialSprites[j];
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				StopAnimationCoroutine();
				_animationCoroutine = Owner.StartCoroutine(AnimateSprites());
			}
		}

		protected virtual IEnumerator AnimateSprites()
		{
			if (AnimationSprites == null || AnimationSprites.Count == 0)
			{
				yield break;
			}
			float delay = 1f / (float)FrameRate;
			int index = 0;
			while (true)
			{
				SetSprite(index);
				index = (index + 1) % AnimationSprites.Count;
				if (!Loop && index == 0)
				{
					break;
				}
				yield return WaitFor(delay);
			}
		}

		protected virtual void SetSprite(int index)
		{
			int num = index;
			for (int i = 0; i < TargetSpriteRenderers.Count; i++)
			{
				num = index + _spriteRendererOffsets[i];
				if (Loop || num < AnimationSprites.Count)
				{
					if (Loop && num >= AnimationSprites.Count)
					{
						num %= AnimationSprites.Count;
					}
					SpriteRenderer spriteRenderer = TargetSpriteRenderers[i];
					if (!(spriteRenderer == null))
					{
						spriteRenderer.sprite = AnimationSprites[num];
					}
				}
			}
			for (int j = 0; j < TargetImages.Count; j++)
			{
				num = index + _imageOffsets[j];
				if (Loop || num < AnimationSprites.Count)
				{
					if (Loop && num >= AnimationSprites.Count)
					{
						num %= AnimationSprites.Count;
					}
					Image image = TargetImages[j];
					if (!(image == null))
					{
						image.sprite = AnimationSprites[num];
					}
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				StopAnimationCoroutine();
			}
		}

		protected virtual void StopAnimationCoroutine()
		{
			if (_animationCoroutine != null)
			{
				Owner.StopCoroutine(_animationCoroutine);
				_animationCoroutine = null;
			}
		}
	}
}
