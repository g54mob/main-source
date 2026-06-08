using System;
using System.Reflection;

namespace RoslynCSharp
{
	public sealed class ScriptPropertyProxy : IScriptMemberProxy
	{
		private bool isStatic;

		private ScriptType type;

		private ScriptProxy owner;

		internal bool throwOnError = true;

		public object this[string name]
		{
			get
			{
				try
				{
					PropertyInfo propertyInfo = type.FindCachedProperty(name, isStatic);
					if (propertyInfo == null)
					{
						throw new TargetException($"Type '{type}' does not define a property called '{name}'");
					}
					if (!propertyInfo.CanRead)
					{
						throw new TargetException($"The property '{name}' was found but it does not define a get accessor");
					}
					object obj = ((owner != null) ? owner.Instance : null);
					return propertyInfo.GetValue(obj, null);
				}
				catch (Exception ex)
				{
					if (throwOnError)
					{
						throw ex;
					}
				}
				return null;
			}
			set
			{
				try
				{
					PropertyInfo propertyInfo = type.FindCachedProperty(name, isStatic);
					if (propertyInfo == null)
					{
						throw new TargetException($"Type '{type}' does not define a property called '{name}'");
					}
					if (!propertyInfo.CanWrite)
					{
						throw new TargetException($"The property '{name}' was found but it does not define a set accessor");
					}
					object obj = ((owner != null) ? owner.Instance : null);
					propertyInfo.SetValue(obj, value, null);
				}
				catch (Exception ex)
				{
					if (throwOnError)
					{
						throw ex;
					}
				}
			}
		}

		internal ScriptPropertyProxy(bool isStatic, ScriptType type, ScriptProxy owner = null)
		{
			this.isStatic = isStatic;
			this.type = type;
			this.owner = owner;
		}
	}
}
