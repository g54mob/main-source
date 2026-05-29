using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Mixer Transition/Linear", order = 413)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/LinearMixerTransitionAsset")]
	public class LinearMixerTransitionAsset : AnimancerTransitionAsset<LinearMixerTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<LinearMixerTransitionAsset, LinearMixerTransition, LinearMixerState>, LinearMixerState.ITransition, ITransition<LinearMixerState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
