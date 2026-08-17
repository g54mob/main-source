using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public class ConstantShakePreset : ScriptableObject
{
	public float Intensity = 0.3f;

	public List<ConstantShakeLayer> Layers;
}
