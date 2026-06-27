using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public sealed class InteractiveObjectAdditionalProperties : ICloneable
	{
		[SerializeField]
		private List<InteractiveObjectAdditionalProperty> properties = new List<InteractiveObjectAdditionalProperty>();

		public IReadOnlyCollection<InteractiveObjectAdditionalProperty> GetAllProperties()
		{
			return properties;
		}

		public InteractiveObjectAdditionalProperties(params InteractiveObjectAdditionalProperty[] additionalProperties)
		{
			properties.Clear();
			properties.AddRange(additionalProperties);
		}

		public bool TryToAddProperty(InteractiveObjectAdditionalProperty propertyToAdd)
		{
			foreach (InteractiveObjectAdditionalProperty property in properties)
			{
				if (property.GetType() == propertyToAdd.GetType())
				{
					return false;
				}
			}
			properties.Add(propertyToAdd);
			return true;
		}

		public void RemoveProperty(InteractiveObjectAdditionalProperty propertyToRemove)
		{
			properties.Remove(propertyToRemove);
		}

		public void RemoveProperty<T>() where T : InteractiveObjectAdditionalProperty
		{
			for (int num = properties.Count - 1; num >= 0; num--)
			{
				if (properties[num].GetType() == typeof(T))
				{
					properties.RemoveAt(num);
					break;
				}
			}
		}

		public bool ContainsProperty<T>() where T : InteractiveObjectAdditionalProperty
		{
			foreach (InteractiveObjectAdditionalProperty property in properties)
			{
				if (property is T)
				{
					return true;
				}
			}
			return false;
		}

		public bool TryToGetProperty<T>(out T foundProperty) where T : class
		{
			foreach (InteractiveObjectAdditionalProperty property in properties)
			{
				if (property is T val)
				{
					foundProperty = val;
					return true;
				}
			}
			foundProperty = null;
			return false;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
