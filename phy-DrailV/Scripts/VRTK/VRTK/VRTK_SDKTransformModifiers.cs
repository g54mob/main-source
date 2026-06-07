using System;
using UnityEngine;

namespace VRTK
{
	[Serializable]
	public class VRTK_SDKTransformModifiers
	{
		[Header("SDK settings")]
		[Tooltip("An optional SDK Setup to use to determine when to modify the transform.")]
		public VRTK_SDKSetup loadedSDKSetup;

		[Tooltip("An optional SDK controller type to use to determine when to modify the transform.")]
		public SDK_BaseController.ControllerType controllerType;

		[Header("Transform Override Settings")]
		[Tooltip("The new local position to change the transform to.")]
		public Vector3 position = Vector3.zero;

		[Tooltip("The new local rotation in eular angles to change the transform to.")]
		public Vector3 rotation = Vector3.zero;

		[Tooltip("The new local scale to change the transform to.")]
		public Vector3 scale = Vector3.one;
	}
}
