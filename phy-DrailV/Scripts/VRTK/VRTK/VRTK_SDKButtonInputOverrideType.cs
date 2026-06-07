using System;
using UnityEngine;

namespace VRTK
{
	[Serializable]
	public class VRTK_SDKButtonInputOverrideType : VRTK_SDKInputOverrideType
	{
		[Header("Button Override")]
		[Tooltip("The button to override to.")]
		public VRTK_ControllerEvents.ButtonAlias overrideButton;
	}
}
