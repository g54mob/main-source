using System;
using UnityEngine;

namespace Sisus.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class HideTransformInInspectorAttribute : Attribute, IComponentModifiedCallbackReceiver<Transform>
	{
		public void OnComponentAdded(Component attributeHolder, Transform addedComponent)
		{
			addedComponent.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;
			addedComponent.localPosition = Vector3.zero;
			addedComponent.localEulerAngles = Vector3.zero;
			addedComponent.localScale = Vector3.one;
		}

		public void OnComponentModified(Component attributeHolder, Transform modifiedComponent)
		{
			if (modifiedComponent.localPosition != Vector3.zero || modifiedComponent.localEulerAngles != Vector3.zero || modifiedComponent.localScale != Vector3.one || modifiedComponent.hideFlags != (HideFlags.HideInInspector | HideFlags.NotEditable))
			{
				Debug.LogWarning(attributeHolder.GetType().Name + " requires that " + modifiedComponent.GetType().Name + " remains hidden and at default state.");
				modifiedComponent.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;
				modifiedComponent.localPosition = Vector3.zero;
				modifiedComponent.localEulerAngles = Vector3.zero;
				modifiedComponent.localScale = Vector3.one;
			}
		}
	}
}
