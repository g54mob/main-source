using System.Reflection;

namespace RoslynCSharp
{
	public class ScriptFieldDataProxy : IScriptDataProxy
	{
		private ScriptType scriptType;

		private ScriptProxy scriptProxy;

		private bool isStatic;

		private bool throwOnError = true;

		public object this[string name]
		{
			get
			{
				return GetValue(name);
			}
			set
			{
				SetValue(name, value);
			}
		}

		public ScriptFieldDataProxy(ScriptType type, ScriptProxy proxy, bool isStatic, bool throwOnError)
		{
			scriptType = type;
			scriptProxy = proxy;
			this.isStatic = isStatic;
			this.throwOnError = throwOnError;
		}

		public virtual object GetValue(string name)
		{
			try
			{
				FieldInfo fieldInfo = scriptType.FindCachedField(name, isStatic);
				if (fieldInfo == null)
				{
					throw new TargetException($"Type '{scriptType}' does not define a field called '{name}'");
				}
				object obj = ((scriptProxy != null) ? scriptProxy.Instance : null);
				return fieldInfo.GetValue(obj);
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
			}
			return null;
		}

		public virtual void SetValue(string name, object value)
		{
			try
			{
				FieldInfo fieldInfo = scriptType.FindCachedField(name, isStatic);
				if (fieldInfo == null)
				{
					throw new TargetException($"Type '{scriptType}' does not define a field called '{name}'");
				}
				object obj = ((scriptProxy != null) ? scriptProxy.Instance : null);
				fieldInfo.SetValue(obj, value);
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
			}
		}
	}
}
