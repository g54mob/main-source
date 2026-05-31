using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Controller Transition/Base", order = 415)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/ControllerTransitionAsset")]
	public class ControllerTransitionAsset : AnimancerTransitionAsset<ControllerTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<ControllerTransitionAsset, ControllerTransition, ControllerState>, ControllerState.ITransition, ITransition<ControllerState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
