using System.Reflection;

namespace DynamicCSharp
{
	public sealed class PropertyProxy : IMemberProxy
	{
		private ScriptProxy owner;

		public object this[string name]
		{
			get
			{
				PropertyInfo propertyInfo = owner.ScriptType.FindCachedProperty(name);
				if (propertyInfo == null)
				{
					throw new TargetException(string.Format("Type '{0}' does not define a property called '{1}'", owner.ScriptType, name));
				}
				if (!propertyInfo.CanRead)
				{
					throw new TargetException(string.Format("The property '{0}' was found but it does not define a get accessor", name));
				}
				return propertyInfo.GetValue(owner.Instance, null);
			}
			set
			{
				PropertyInfo propertyInfo = owner.ScriptType.FindCachedProperty(name);
				if (propertyInfo == null)
				{
					throw new TargetException(string.Format("Type '{0}' does not define a property called '{1}'", owner.ScriptType, name));
				}
				if (!propertyInfo.CanWrite)
				{
					throw new TargetException(string.Format("The property '{0}' was found but it does not define a set accessor", name));
				}
				propertyInfo.SetValue(owner.Instance, value, null);
			}
		}

		internal PropertyProxy(ScriptProxy owner)
		{
			this.owner = owner;
		}
	}
}
