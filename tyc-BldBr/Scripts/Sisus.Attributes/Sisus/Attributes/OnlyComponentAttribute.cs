using System;
using UnityEngine;

namespace Sisus.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class OnlyComponentAttribute : Attribute, IComponentModifiedCallbackReceiver<Component>
	{
		public void OnComponentAdded(Component attributeHolder, Component addedComponent)
		{
			DestroyComponentIfNotAttributeHolderOrTransform(attributeHolder, addedComponent);
		}

		public void OnComponentModified(Component attributeHolder, Component modifiedComponent)
		{
			DestroyComponentIfNotAttributeHolderOrTransform(attributeHolder, modifiedComponent);
		}

		private void DestroyComponentIfNotAttributeHolderOrTransform(Component attributeHolder, Component target)
		{
			if (target == attributeHolder)
			{
				Component[] components = attributeHolder.gameObject.GetComponents<Component>();
				for (int num = components.Length - 1; num >= 0; num--)
				{
					Component component = components[num];
					if (component != attributeHolder && !(component is Transform))
					{
						Debug.LogWarning("Removing existing component " + target.GetType().Name + " because " + attributeHolder.GetType().Name + " does not allow additional components to exist on the same GameObject.");
						UnityEngine.Object.Destroy(component);
					}
				}
			}
			else if (!(target is Transform))
			{
				Debug.LogWarning("Cannot add component " + target.GetType().Name + " because " + attributeHolder.GetType().Name + " does not allow additional components to exist on the same GameObject.");
				UnityEngine.Object.Destroy(target);
			}
		}
	}
}
