using System;
using System.Linq;
using System.Reflection;

namespace MessagePipe
{
	internal class ServiceProviderType
	{
		private readonly Type type;

		private readonly ConstructorInfo ctor;

		private readonly ParameterInfo[] parameters;

		public ServiceProviderType(Type type)
		{
			var anon = (from x in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
				select new
				{
					ctor = x,
					parameters = x.GetParameters()
				} into x
				orderby x.parameters.Length descending
				select x).FirstOrDefault();
			if (!type.IsValueType && anon == null)
			{
				throw new InvalidOperationException("ConsturoctorInfo is not found, is stripped? Type:" + type.FullName);
			}
			this.type = type;
			ctor = anon?.ctor;
			parameters = anon?.parameters;
		}

		public object Instantiate(BuiltinContainerBuilderServiceProvider provider, int depth)
		{
			if (ctor == null)
			{
				return Activator.CreateInstance(type);
			}
			if (parameters.Length == 0)
			{
				return ctor.Invoke(Array.Empty<object>());
			}
			if (depth > 15)
			{
				throw new InvalidOperationException("Parameter too recursively: " + type.FullName);
			}
			object[] array = new object[parameters.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = provider.GetService(parameters[i].ParameterType, depth + 1);
			}
			return ctor.Invoke(array);
		}
	}
}
