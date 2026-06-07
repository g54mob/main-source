using System;
using UnityEngine;

namespace VRTK
{
	[Serializable]
	public class VRTK_SDKVector2AxisInputOverrideType : VRTK_SDKInputOverrideType
	{
		[Header("Vector2 Axis Override")]
		[Tooltip("The Vector2 axis to override to.")]
		public VRTK_ControllerEvents.Vector2AxisAlias overrideAxis;
	}
}
