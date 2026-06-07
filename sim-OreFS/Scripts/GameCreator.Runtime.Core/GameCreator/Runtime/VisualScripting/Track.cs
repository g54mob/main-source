using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public abstract class Track : ITrack
	{
		public virtual int TrackOrder => 1;

		public virtual TrackType TrackType => TrackType.Single;

		public virtual TrackAddType AllowAdd => TrackAddType.Allow;

		public virtual TrackRemoveType AllowRemove => TrackRemoveType.Allow;

		public abstract IClip[] Clips { get; }

		public virtual Color ColorConnectionLeftNormal => default(Color);

		public virtual Color ColorConnectionMiddleNormal => default(Color);

		public virtual Color ColorConnectionRightNormal => default(Color);

		public virtual Color ColorConnectionLeftSelect => default(Color);

		public virtual Color ColorConnectionMiddleSelect => default(Color);

		public virtual Color ColorConnectionRightSelect => default(Color);

		public virtual bool IsConnectionLeftThin => false;

		public virtual bool IsConnectionMiddleThin => false;

		public virtual bool IsConnectionRightThin => false;

		public virtual float TransitionRange => 0f;

		public virtual Color ColorClipNormal => ColorTheme.Get(ColorTheme.Type.TextLight);

		public virtual Color ColorClipSelect => ColorTheme.Get(ColorTheme.Type.TextNormal);

		public virtual Texture CustomClipIconNormal => null;

		public virtual Texture CustomClipIconSelect => null;

		public virtual bool HasInspector => true;

		void ITrack.OnStart(ISequence sequence, Args args)
		{
			IClip[] clips = Clips;
			for (int i = 0; i < clips.Length; i++)
			{
				clips[i]?.Reset(this, args);
			}
		}

		void ITrack.OnComplete(ISequence sequence, Args args)
		{
			IClip[] clips = Clips;
			foreach (IClip clip in clips)
			{
				if (!clip.IsComplete)
				{
					clip.Complete(this, args);
				}
			}
		}

		void ITrack.OnCancel(ISequence sequence, Args args)
		{
			IClip[] clips = Clips;
			for (int i = 0; i < clips.Length; i++)
			{
				clips[i]?.Cancel(this, args);
			}
		}

		void ITrack.OnUpdate(ISequence sequence, Args args)
		{
			float t = sequence.T;
			IClip[] clips = Clips;
			foreach (IClip clip in clips)
			{
				float num = sequence.Dilate(clip.TimeStart);
				float num2 = sequence.Dilate(clip.TimeEnd);
				if (t >= num)
				{
					if (!clip.IsStart)
					{
						clip.Start(this, args);
						clip.Update(this, args, CalculateT(clip, sequence, t));
					}
					else if (t <= num2)
					{
						clip.Update(this, args, CalculateT(clip, sequence, t));
					}
					else if (!clip.IsComplete)
					{
						clip.Complete(this, args);
					}
				}
			}
		}

		private float CalculateT(IClip clip, ISequence sequence, float t)
		{
			float num = sequence.Dilate(clip.TimeStart);
			float num2 = sequence.Dilate(clip.TimeEnd);
			if (num >= num2)
			{
				return 1f;
			}
			return (t - num) / (num2 - num);
		}
	}
}
