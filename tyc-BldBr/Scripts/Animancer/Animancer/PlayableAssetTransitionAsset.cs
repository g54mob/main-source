using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Playable Asset Transition", order = 419)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/PlayableAssetTransitionAsset")]
	public class PlayableAssetTransitionAsset : AnimancerTransitionAsset<PlayableAssetTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<PlayableAssetTransitionAsset, PlayableAssetTransition, PlayableAssetState>, PlayableAssetState.ITransition, ITransition<PlayableAssetState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
