using System;

namespace PugMod
{
	public interface IReflection
	{
		Type[] AllTypes();

		Type[] GetTypes(long modId);

		Type[] GetTypesFromCurrentAssembly();

		object Invoke(MemberInfo memberInfo, object obj, params object[] parameters);

		object GetValue(MemberInfo memberInfo, object obj);

		void SetValue(MemberInfo memberInfo, object obj, object value);
	}
}
