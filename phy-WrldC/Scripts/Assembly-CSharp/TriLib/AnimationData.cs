using UnityEngine;

namespace TriLib
{
	public class AnimationData
	{
		public string Name;

		public bool Legacy;

		public float Length;

		public float FrameRate;

		public WrapMode WrapMode;

		public AnimationChannelData[] ChannelData;

		public MorphChannelData[] MorphData;

		public AnimationClip AnimationClip;
	}
}
