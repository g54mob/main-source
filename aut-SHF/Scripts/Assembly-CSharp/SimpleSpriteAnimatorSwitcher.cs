using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpriteAnimatorSwitcher : MonoBehaviour
{
	[Serializable]
	public struct AnimatorInfo
	{
		public int number;

		public SimpleSpriteAnimator animator;
	}

	public int defaultNumber;

	public List<AnimatorInfo> animatorInfos;

	public void Awake()
	{
	}

	public void Switch(int number)
	{
	}
}
