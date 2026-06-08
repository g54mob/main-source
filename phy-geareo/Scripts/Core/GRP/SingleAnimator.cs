using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace GRP
{
	public class SingleAnimator : MonoBehaviour, IAnimationClipSource
	{
		public AnimationClip clip;

		private Animator animator;

		private PlayableGraph graph;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Play()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void GetAnimationClips(List<AnimationClip> results)
		{
		}
	}
}
