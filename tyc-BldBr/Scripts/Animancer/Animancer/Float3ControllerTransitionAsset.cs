using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Controller Transition/Float 3", order = 418)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/Float3ControllerTransitionAsset")]
	public class Float3ControllerTransitionAsset : AnimancerTransitionAsset<Float3ControllerTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<Float3ControllerTransitionAsset, Float3ControllerTransition, Float3ControllerState>, Float3ControllerState.ITransition, ITransition<Float3ControllerState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
