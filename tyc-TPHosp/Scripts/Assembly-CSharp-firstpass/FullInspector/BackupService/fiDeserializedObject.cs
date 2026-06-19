using System;
using System.Collections.Generic;
using FullInspector.Internal;
using FullSerializer.Internal;

namespace FullInspector.BackupService
{
	public class fiDeserializedObject
	{
		public List<fiDeserializedMember> Members;

		public fiDeserializedObject(fiSerializedObject serializedState)
		{
			Type type = serializedState.Target.Target.GetType();
			fiSerializationOperator serializationOperator = new fiSerializationOperator
			{
				SerializedObjects = serializedState.ObjectReferences
			};
			BaseSerializer baseSerializer = (BaseSerializer)fiSingletons.Get(BehaviorTypeToSerializerTypeMap.GetSerializerType(type));
			InspectedType inspectedType = InspectedType.Get(type);
			Members = new List<fiDeserializedMember>();
			foreach (fiSerializedMember member in serializedState.Members)
			{
				InspectedProperty propertyByName = inspectedType.GetPropertyByName(member.Name);
				if (propertyByName != null)
				{
					object value = baseSerializer.Deserialize(fsPortableReflection.AsMemberInfo(propertyByName.StorageType), member.Value, serializationOperator);
					Members.Add(new fiDeserializedMember
					{
						InspectedProperty = propertyByName,
						Value = value,
						ShouldRestore = member.ShouldRestore
					});
				}
			}
		}
	}
}
