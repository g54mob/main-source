using System.Reflection;

namespace RoslynCSharp
{
	public class ScriptPropertyDataProxy : IScriptDataProxy
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

		public ScriptPropertyDataProxy(ScriptType type, ScriptProxy proxy, bool isStatic, bool throwOnError)
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
				PropertyInfo propertyInfo = scriptType.FindCachedProperty(name, isStatic);
				if (propertyInfo == null)
				{
					throw new TargetException($"Type '{scriptType}' does not define a property called '{name}'");
				}
				object obj = ((scriptProxy != null) ? scriptProxy.Instance : null);
				return propertyInfo.GetValue(obj);
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
				PropertyInfo propertyInfo = scriptType.FindCachedProperty(name, isStatic);
				if (propertyInfo == null)
				{
					throw new TargetException($"Type '{scriptType}' does not define a property called '{name}'");
				}
				object obj = ((scriptProxy != null) ? scriptProxy.Instance : null);
				propertyInfo.SetValue(obj, value);
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
