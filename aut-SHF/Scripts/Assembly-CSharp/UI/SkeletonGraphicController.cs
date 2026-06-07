using System.Collections.Generic;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;

namespace UI
{
	[RequireComponent(typeof(SkeletonGraphic))]
	public class SkeletonGraphicController : MonoBehaviour
	{
		public SkeletonGraphic UseSkeleton { get; private set; }

		public string NowPlayAnimationName { get; private set; }

		public Dictionary<string, float> DurationMap { get; private set; }

		public bool IsInitialize { get; private set; }

		private void Awake()
		{
		}

		public void Init()
		{
		}

		private void SetDuration()
		{
		}

		public void Stop()
		{
		}

		public void Play(int trackIndex, string animationName, bool loop)
		{
		}

		public Sequence GetPlaySeqiuence(int trackIndex, string animationName, bool loop, float increase = 1f)
		{
			return null;
		}
	}
}
