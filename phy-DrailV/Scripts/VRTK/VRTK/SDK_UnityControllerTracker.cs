using System;
using UnityEngine;
using UnityEngine.XR;

namespace VRTK
{
	public class SDK_UnityControllerTracker : MonoBehaviour
	{
		[Tooltip("The Unity VRNode to track.")]
		public XRNode nodeType;

		[Tooltip("The unique index to assign to the controller.")]
		public uint index;

		[Tooltip("The Unity Input name for the trigger axis.")]
		public string triggerAxisName = "";

		[Tooltip("The Unity Input name for the grip axis.")]
		public string gripAxisName = "";

		[Tooltip("The Unity Input name for the touchpad horizontal axis.")]
		public string touchpadHorizontalAxisName = "";

		[Tooltip("The Unity Input name for the touchpad vertical axis.")]
		public string touchpadVerticalAxisName = "";

		protected virtual void OnEnable()
		{
			CheckAxisIsValid(triggerAxisName, "triggerAxisName");
			CheckAxisIsValid(gripAxisName, "gripAxisName");
			CheckAxisIsValid(touchpadHorizontalAxisName, "touchpadHorizontalAxisName");
			CheckAxisIsValid(touchpadVerticalAxisName, "touchpadVerticalAxisName");
		}

		protected virtual string GetVarName<T>(T item) where T : class
		{
			return VRTK_SharedMethods.GetPropertyFirstName<T>();
		}

		protected virtual void CheckAxisIsValid(string axisName, string varName)
		{
			try
			{
				Input.GetAxis(axisName);
			}
			catch (ArgumentException ex)
			{
				VRTK_Logger.Warn(ex.Message + " on index [" + index + "] variable [" + varName + "]");
			}
		}

		protected virtual void FixedUpdate()
		{
			base.transform.localPosition = InputTracking.GetLocalPosition(nodeType);
			base.transform.localRotation = InputTracking.GetLocalRotation(nodeType);
		}
	}
}
