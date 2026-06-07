using System.Collections.Generic;
using UnityEngine;

namespace SaintsField
{
	public class AnimatorStateChanged
	{
		public int layerIndex;

		public AnimationClip animationClip;

		public IReadOnlyList<string> subStateMachineNameChain;
	}
}
