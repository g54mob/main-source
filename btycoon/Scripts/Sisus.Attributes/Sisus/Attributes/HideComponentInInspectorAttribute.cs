using System;
using UnityEngine;

namespace Sisus.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class HideComponentInInspectorAttribute : Attribute, IComponentModifiedCallbackReceiver<Component>
	{
		public void OnComponentAdded(Component attributeHolder, Component addedComponent)
		{
			if (addedComponent == attributeHolder)
			{
				addedComponent.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;
			}
		}

		public void OnComponentModified(Component attributeHolder, Component modifiedComponent)
		{
			if (modifiedComponent == attributeHolder)
			{
				Debug.LogWarning(attributeHolder.GetType().Name + " requires that " + modifiedComponent.GetType().Name + " remains hidden.");
				modifiedComponent.hideFlags = HideFlags.HideInInspector | HideFlags.NotEditable;
			}
		}
	}
}
