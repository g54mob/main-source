using System;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[Serializable]
	public class FootstepTagEffect
	{
		[Tooltip("The effect tag of this footstep effect - is used by footsteppers with a matching effect tag.")]
		public string tag = "";

		[Tooltip("The footstep effect of this effect tag.")]
		public FootstepEffect effect = new FootstepEffect();
	}
}
