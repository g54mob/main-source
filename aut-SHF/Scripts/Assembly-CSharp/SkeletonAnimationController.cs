using System.Collections.Generic;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class SkeletonAnimationController : MonoBehaviour
{
	public SkeletonAnimation UseSkeleton { get; private set; }

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

	public Sequence GetPlaySequence(int trackIndex, string animationName, bool loop, float loopSecond = -1f, bool withStop = false)
	{
		return null;
	}
}
