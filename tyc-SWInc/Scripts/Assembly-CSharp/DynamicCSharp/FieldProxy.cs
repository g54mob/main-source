using System.Reflection;

namespace DynamicCSharp
{
	public sealed class FieldProxy : IMemberProxy
	{
		private ScriptProxy owner;

		public object this[string name]
		{
			get
			{
				FieldInfo fieldInfo = owner.ScriptType.FindCachedField(name);
				if (fieldInfo == null)
				{
					throw new TargetException(string.Format("Type '{0}' does not define a field called '{1}'", owner.ScriptType, name));
				}
				return fieldInfo.GetValue(owner.Instance);
			}
			set
			{
				FieldInfo fieldInfo = owner.ScriptType.FindCachedField(name);
				if (fieldInfo == null)
				{
					throw new TargetException(string.Format("Type '{0}' does not define a field called '{1}'", owner.ScriptType, name));
				}
				fieldInfo.SetValue(owner.Instance, value);
			}
		}

		internal FieldProxy(ScriptProxy owner)
		{
			this.owner = owner;
		}
	}
}
