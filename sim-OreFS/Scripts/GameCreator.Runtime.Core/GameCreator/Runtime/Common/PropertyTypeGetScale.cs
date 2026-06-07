using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scale")]
	public abstract class PropertyTypeGetScale : TPropertyTypeGet<Vector3>
	{
		protected enum ScaleSpace
		{
			Local = 0,
			Global = 1
		}
	}
}
