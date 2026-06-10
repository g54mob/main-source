using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	public struct VolumeInjectionColorParameters
	{
		public VolumeInjectionCommonParameters injectionParameters;

		[SerializeField]
		[ColorCircularPicker(false)]
		public Color color;
	}
}
