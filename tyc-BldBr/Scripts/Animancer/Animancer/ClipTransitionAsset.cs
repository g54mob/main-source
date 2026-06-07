using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Clip Transition", order = 411)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/ClipTransitionAsset")]
	public class ClipTransitionAsset : AnimancerTransitionAsset<ClipTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<ClipTransitionAsset, ClipTransition, ClipState>, ClipState.ITransition, ITransition<ClipState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
