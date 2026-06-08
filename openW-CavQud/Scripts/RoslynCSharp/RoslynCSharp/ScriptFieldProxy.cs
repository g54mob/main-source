using System;
using System.Reflection;

namespace RoslynCSharp
{
	public sealed class ScriptFieldProxy : IScriptMemberProxy
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
					FieldInfo fieldInfo = type.FindCachedField(name, isStatic);
					if (fieldInfo == null)
					{
						throw new TargetException($"Type '{type}' does not define a field called '{name}'");
					}
					object obj = ((owner != null) ? owner.Instance : null);
					return fieldInfo.GetValue(obj);
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
					FieldInfo fieldInfo = type.FindCachedField(name, isStatic);
					if (fieldInfo == null)
					{
						throw new TargetException($"Type '{type}' does not define a field called '{name}'");
					}
					object obj = ((owner != null) ? owner.Instance : null);
					fieldInfo.SetValue(obj, value);
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

		internal ScriptFieldProxy(bool isStatic, ScriptType type, ScriptProxy owner = null)
		{
			this.isStatic = isStatic;
			this.type = type;
			this.owner = owner;
		}
	}
}
