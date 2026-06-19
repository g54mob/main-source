using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace RoslynCSharp.Implementation
{
	internal sealed class ScriptTypeImpl : ScriptType
	{
		private ScriptAssembly assembly;

		private ScriptType parentType;

		private ScriptType[] nestedTypes;

		private Type systemType;

		private ICollection<object> customAttributes;

		public override ScriptAssembly Assembly => assembly;

		public override ScriptType Parent => parentType;

		public override Type SystemType => systemType;

		public override bool IsNestedType => parentType != null;

		public override bool HasNestedTypes => nestedTypes.Length != 0;

		public override ScriptType[] NestedTypes => nestedTypes;

		public override ICollection<object> CustomAttributes
		{
			get
			{
				if (customAttributes == null)
				{
					customAttributes = new HashSet<object>(systemType.GetCustomAttributes(inherit: false));
				}
				return customAttributes;
			}
		}

		protected override void ConstructInstance(ScriptAssembly assembly, ScriptType parent, ScriptType[] nestedTypes, Type systemType)
		{
			this.assembly = assembly;
			parentType = parent;
			this.nestedTypes = nestedTypes;
			this.systemType = systemType;
		}

		protected override ScriptProxy CreateInstanceImpl(object[] args)
		{
			object obj = null;
			try
			{
				obj = Activator.CreateInstance(systemType, BindingFlags.Default, null, args, null);
			}
			catch (MissingMethodException)
			{
				if (args.Length != 0)
				{
					return null;
				}
				obj = FormatterServices.GetUninitializedObject(SystemType);
			}
			if (obj != null)
			{
				return ScriptProxy.CreateScriptProxy<ScriptProxyImpl>(this, obj);
			}
			return null;
		}

		protected override ScriptProxy CreateMonoBehaviourInstanceImpl(GameObject parent)
		{
			if (parent == null)
			{
				throw new InvalidOperationException("A non-destroyed game object instance must be provided for MonoBehaviour components");
			}
			object obj = parent.AddComponent(systemType);
			if (obj != null)
			{
				return ScriptProxy.CreateScriptProxy<ScriptProxyImpl>(this, obj);
			}
			return null;
		}

		protected override ScriptProxy CreateScriptableObjectInstanceImpl()
		{
			ScriptableObject scriptableObject = ScriptableObject.CreateInstance(systemType);
			if (scriptableObject != null)
			{
				return ScriptProxy.CreateScriptProxy<ScriptProxyImpl>(this, scriptableObject);
			}
			return null;
		}

		protected override EventInfo FindEventImpl(string name, BindingFlags bindingAttrib)
		{
			return systemType.GetEvent(name, bindingAttrib);
		}

		protected override FieldInfo FindFieldImpl(string name, BindingFlags bindingAttrib)
		{
			return systemType.GetField(name, bindingAttrib);
		}

		protected override MethodInfo FindMethodImpl(string name, BindingFlags bindingAttrib)
		{
			return systemType.GetMethod(name, bindingAttrib);
		}

		protected override PropertyInfo FindPropertyImpl(string name, BindingFlags bindingAttrib)
		{
			return systemType.GetProperty(name, bindingAttrib);
		}
	}
}
