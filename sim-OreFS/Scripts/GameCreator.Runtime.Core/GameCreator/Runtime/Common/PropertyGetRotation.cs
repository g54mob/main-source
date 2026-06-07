using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetRotation : TPropertyGet<PropertyTypeGetRotation, Quaternion>
	{
		public PropertyGetRotation()
			: base((PropertyTypeGetRotation)new GetRotationTowardsDirection())
		{
		}

		public PropertyGetRotation(Quaternion rotation)
			: base((PropertyTypeGetRotation)new GetRotationEuler(rotation.eulerAngles))
		{
		}

		public PropertyGetRotation(PropertyTypeGetRotation defaultType)
			: base(defaultType)
		{
		}
	}
}
