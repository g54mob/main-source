using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public struct ConstantShakeLayer
{
	public Vector2 Frequency;

	public float AmplitudeHorizontal;

	public float AmplitudeVertical;

	public float AmplitudeDepth;
}
