using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_SDKTransformModify")]
	public class VRTK_SDKTransformModify : VRTK_SDKControllerReady
	{
		[Tooltip("The target Transform to modify on enable. If this is left blank then the Transform the script is attached to will be used.")]
		public Transform target;

		[Tooltip("If this is checked then the target Transform will be reset to the original orientation when this script is disabled.")]
		public bool resetOnDisable = true;

		[Tooltip("A collection of SDK Transform overrides to change the given target Transform for each specified SDK.")]
		public List<VRTK_SDKTransformModifiers> sdkOverrides = new List<VRTK_SDKTransformModifiers>();

		protected Vector3 originalPosition;

		protected Quaternion originalRotation;

		protected Vector3 originalScale;

		public bool Applied { get; protected set; }

		public virtual void UpdateTransform(VRTK_ControllerReference controllerReference = null)
		{
			if (!(target == null))
			{
				VRTK_SDKTransformModifiers selectedModifier = GetSelectedModifier(controllerReference);
				if (selectedModifier != null)
				{
					target.localPosition = selectedModifier.position;
					target.localEulerAngles = selectedModifier.rotation;
					target.localScale = selectedModifier.scale;
					Applied = true;
				}
			}
		}

		public virtual void SetOrigins()
		{
			if (target != null)
			{
				originalPosition = target.position;
				originalRotation = target.rotation;
				originalScale = target.localScale;
			}
		}

		protected override void OnEnable()
		{
			target = ((target != null) ? target : base.transform);
			SetOrigins();
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (resetOnDisable)
			{
				target.position = originalPosition;
				target.rotation = originalRotation;
				target.localScale = originalScale;
				Applied = false;
			}
		}

		protected override void ControllerReady(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_SDKManager.GetLoadedSDKSetup() != null && base.gameObject.activeInHierarchy)
			{
				UpdateTransform(controllerReference);
			}
		}

		protected virtual VRTK_SDKTransformModifiers GetSelectedModifier(VRTK_ControllerReference controllerReference)
		{
			VRTK_SDKTransformModifiers vRTK_SDKTransformModifiers = sdkOverrides.FirstOrDefault((VRTK_SDKTransformModifiers item) => item.loadedSDKSetup == VRTK_SDKManager.GetLoadedSDKSetup());
			if (vRTK_SDKTransformModifiers == null)
			{
				SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(controllerReference);
				vRTK_SDKTransformModifiers = sdkOverrides.FirstOrDefault((VRTK_SDKTransformModifiers item) => item.controllerType == currentControllerType);
			}
			return vRTK_SDKTransformModifiers;
		}
	}
}
