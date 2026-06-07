using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.Scripts.Craft.Parts.Modifiers.Variables
{
	public class VariableOutputDefinition
	{
		private static readonly Dictionary<Type, List<VariableOutputDefinition>> _typeLookup = new Dictionary<Type, List<VariableOutputDefinition>>();

		private MethodInfo _getMethod;

		public int DefaultOutputPriority { get; private set; }

		public string DefaultOutputVariable { get; private set; }

		public string DescriptiveName { get; private set; }

		public string Id { get; private set; }

		public VariableOutputDefinition(PropertyInfo property, VariableOutputAttribute attribute)
		{
			Id = property.Name;
			DescriptiveName = attribute.DisplayName;
			DefaultOutputVariable = attribute.DefaultOutputVariable;
			DefaultOutputPriority = attribute.DefaultOutputPriority;
			_getMethod = property.GetMethod;
		}

		public static List<VariableOutputDefinition> GetDefinitionsForType(Type type)
		{
			if (type == null)
			{
				return new List<VariableOutputDefinition>();
			}
			if (_typeLookup.TryGetValue(type, out var value))
			{
				return value;
			}
			value = new List<VariableOutputDefinition>();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType == typeof(float))
				{
					VariableOutputAttribute customAttribute = propertyInfo.GetCustomAttribute<VariableOutputAttribute>(inherit: true);
					if (customAttribute != null)
					{
						value.Add(new VariableOutputDefinition(propertyInfo, customAttribute));
					}
				}
			}
			_typeLookup.Add(type, value);
			return value;
		}

		public Func<float> GetGetter(object modifier)
		{
			return (Func<float>)Delegate.CreateDelegate(typeof(Func<float>), modifier, _getMethod);
		}
	}
}
