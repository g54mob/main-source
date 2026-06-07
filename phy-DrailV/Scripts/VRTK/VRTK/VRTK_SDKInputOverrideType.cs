using System;
using UnityEngine;

namespace VRTK
{
	[Serializable]
	public class VRTK_SDKInputOverrideType
	{
		[Header("SDK settings")]
		[Tooltip("An optional SDK Setup to use to determine when to modify the transform.")]
		public VRTK_SDKSetup loadedSDKSetup;

		[Tooltip("An optional SDK controller type to use to determine when to modify the transform.")]
		public SDK_BaseController.ControllerType controllerType;
	}
}
