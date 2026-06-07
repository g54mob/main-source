using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Rotation")]
	public abstract class PropertyTypeGetRotation : TPropertyTypeGet<Quaternion>
	{
		protected enum RotationSpace
		{
			Local = 0,
			Global = 1
		}
	}
}
