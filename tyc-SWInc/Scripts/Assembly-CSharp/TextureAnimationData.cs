using System;
using UnityEngine;

public class TextureAnimationData : ScriptableObject
{
	[Serializable]
	public class AnimationData
	{
		public string Name;

		public int StartFrame;

		public int EndFrame;

		public AnimationData(string name, int startFrame, int endFrame)
		{
			Name = name;
			StartFrame = startFrame;
			EndFrame = endFrame;
		}
	}

	public AnimationData[] Animations;
}
