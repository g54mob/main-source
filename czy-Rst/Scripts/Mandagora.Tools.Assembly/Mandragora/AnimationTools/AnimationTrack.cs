using UnityEngine;

namespace Mandragora.AnimationTools
{
	public class AnimationTrack
	{
		public Animation animation;

		private int currentFrame;

		public int CurrentFrame
		{
			get
			{
				return currentFrame;
			}
			set
			{
				currentFrame = value;
				if (animation != null)
				{
					if (currentFrame < 0)
					{
						currentFrame = animation.frames.Length - 1;
					}
					if (currentFrame > animation.frames.Length - 1)
					{
						currentFrame = 0;
					}
				}
				else
				{
					currentFrame = 0;
				}
			}
		}

		public static bool IsNullOrEmpty(AnimationTrack track)
		{
			if (track != null)
			{
				return track.animation == null;
			}
			return true;
		}

		public void Set(Animation animation)
		{
			Clear();
			this.animation = animation;
		}

		public void SetRandomStartFrame()
		{
			int num = Random.Range(0, animation.frames.Length);
			CurrentFrame = num;
		}

		public void NextFrame()
		{
			CurrentFrame++;
		}

		public void PrevFrame()
		{
			CurrentFrame--;
		}

		public Frame GetCurrentFrame()
		{
			CurrentFrame = Mathf.Clamp(CurrentFrame, 0, animation.frames.Length - 1);
			return animation.frames[CurrentFrame];
		}

		public void Clear()
		{
			animation = null;
			CurrentFrame = 0;
		}
	}
}
