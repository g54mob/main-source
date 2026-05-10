using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Mixer Transition/2D", order = 414)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/MixerTransition2DAsset")]
	public class MixerTransition2DAsset : AnimancerTransitionAsset<MixerTransition2D>
	{
		[Serializable]
		public new class UnShared : UnShared<MixerTransition2DAsset, MixerTransition2D, MixerState<Vector2>>, ManualMixerState.ITransition2D, ITransition<MixerState<Vector2>>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
