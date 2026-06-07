using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[Serializable]
	[CreateAssetMenu(menuName = "ProCamera2D/Constant Shake Preset")]
	public class ConstantShakePreset : ScriptableObject
	{
		public float Intensity;

		public List<ConstantShakeLayer> Layers;
	}
}
