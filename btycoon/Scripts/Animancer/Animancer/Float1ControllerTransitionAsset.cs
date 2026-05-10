using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Controller Transition/Float 1", order = 416)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/Float1ControllerTransitionAsset")]
	public class Float1ControllerTransitionAsset : AnimancerTransitionAsset<Float1ControllerTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<Float1ControllerTransitionAsset, Float1ControllerTransition, Float1ControllerState>, Float1ControllerState.ITransition, ITransition<Float1ControllerState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
