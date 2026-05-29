using System;
using UnityEngine;

namespace Animancer
{
	[CreateAssetMenu(menuName = "Animancer/Controller Transition/Float 2", order = 417)]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/Float2ControllerTransitionAsset")]
	public class Float2ControllerTransitionAsset : AnimancerTransitionAsset<Float2ControllerTransition>
	{
		[Serializable]
		public new class UnShared : UnShared<Float2ControllerTransitionAsset, Float2ControllerTransition, Float2ControllerState>, Float2ControllerState.ITransition, ITransition<Float2ControllerState>, ITransition, IHasKey, IPolymorphic
		{
		}
	}
}
