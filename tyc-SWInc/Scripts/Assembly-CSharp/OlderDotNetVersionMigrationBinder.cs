using System;
using System.Runtime.Serialization;

public class OlderDotNetVersionMigrationBinder : SerializationBinder
{
	public override Type BindToType(string assemblyName, string typeName)
	{
		if (typeName.StartsWith("System.Collections.Generic.Dictionary"))
		{
			Type type = Type.GetType(typeName);
			return typeof(OldSaveDataDictionary<, >).MakeGenericType(type.GenericTypeArguments);
		}
		return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
	}
}
