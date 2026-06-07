using System;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class UIAnimation
	{
		public AnimationType AnimationType;

		public Move Move;

		public Rotate Rotate;

		public Scale Scale;

		public Fade Fade;

		public bool Enabled => false;

		public float StartDelay => 0f;

		public float TotalDuration => 0f;

		public UIAnimation(AnimationType animationType)
		{
		}

		public UIAnimation(AnimationType animationType, Move move, Rotate rotate, Scale scale, Fade fade)
		{
		}

		public void Reset(AnimationType animationType)
		{
		}

		public UIAnimation Copy()
		{
			return null;
		}
	}
}
