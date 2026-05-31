using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Mixer Transition/Manual", order = 412)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/ManualMixerTransitionAsset")]
	public class ManualMixerTransitionAsset : AnimancerTransitionAsset<ManualMixerTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<ManualMixerTransitionAsset, ManualMixerTransition, ManualMixerState>, ManualMixerState.ITransition, ITransition<ManualMixerState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
