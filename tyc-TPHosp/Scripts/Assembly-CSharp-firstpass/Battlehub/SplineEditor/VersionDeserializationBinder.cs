using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Battlehub.SplineEditor
{
	public sealed class VersionDeserializationBinder : SerializationBinder
	{
		public override Type BindToType(string assemblyName, string typeName)
		{
			if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
			{
				assemblyName = Assembly.GetExecutingAssembly().FullName;
				return Type.GetType($"{typeName}, {assemblyName}");
			}
			return null;
		}
	}
}
