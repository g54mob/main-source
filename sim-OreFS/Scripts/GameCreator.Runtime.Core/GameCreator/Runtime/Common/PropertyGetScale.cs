using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetScale : TPropertyGet<PropertyTypeGetScale, Vector3>
	{
		public PropertyGetScale()
			: base((PropertyTypeGetScale)new GetScaleVector3())
		{
		}

		public PropertyGetScale(Vector3 scale)
			: base((PropertyTypeGetScale)new GetScaleVector3(scale))
		{
		}

		public PropertyGetScale(PropertyTypeGetScale defaultType)
			: base(defaultType)
		{
		}
	}
}
