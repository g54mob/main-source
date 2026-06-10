using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	public struct VolumeInjectionShape
	{
		[SerializeField]
		public VolumeType shape;

		[SerializeField]
		public VolumeGradient fading;
	}
}
