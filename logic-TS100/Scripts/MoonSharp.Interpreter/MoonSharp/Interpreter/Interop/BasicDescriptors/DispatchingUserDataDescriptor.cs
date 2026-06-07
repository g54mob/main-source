using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter.Interop.Converters;

namespace MoonSharp.Interpreter.Interop.BasicDescriptors
{
	public abstract class DispatchingUserDataDescriptor : IUserDataDescriptor, IOptimizableDescriptor
	{
		protected const string SPECIALNAME_INDEXER_GET = "get_Item";

		protected const string SPECIALNAME_INDEXER_SET = "set_Item";

		protected const string SPECIALNAME_CAST_EXPLICIT = "op_Explicit";

		protected const string SPECIALNAME_CAST_IMPLICIT = "op_Implicit";

		private int m_ExtMethodsVersion;

		private Dictionary<string, IMemberDescriptor> m_MetaMembers = new Dictionary<string, IMemberDescriptor>();

		private Dictionary<string, IMemberDescriptor> m_Members = new Dictionary<string, IMemberDescriptor>();

		public string Name { get; private set; }

		public Type Type { get; private set; }

		public string FriendlyName { get; private set; }

		protected DispatchingUserDataDescriptor(Type type, string friendlyName = null)
		{
			Type = type;
			Name = type.FullName;
			FriendlyName = friendlyName ?? type.Name;
		}

		public void AddMetaMember(string name, IMemberDescriptor desc)
		{
			if (desc != null)
			{
				AddMemberTo(m_MetaMembers, name, desc);
			}
		}

		public void AddDynValue(string name, DynValue value)
		{
			DynValueMemberDescriptor desc = new DynValueMemberDescriptor(name, value);
			AddMemberTo(m_Members, name, desc);
		}

		public void AddMember(string name, IMemberDescriptor desc)
		{
			if (desc != null)
			{
				AddMemberTo(m_Members, name, desc);
			}
		}

		private void AddMemberTo(Dictionary<string, IMemberDescriptor> members, string name, IMemberDescriptor desc)
		{
			IOverloadableMemberDescriptor overloadableMemberDescriptor = desc as IOverloadableMemberDescriptor;
			if (overloadableMemberDescriptor != null)
			{
				if (members.ContainsKey(name))
				{
					OverloadedMethodMemberDescriptor overloadedMethodMemberDescriptor = members[name] as OverloadedMethodMemberDescriptor;
					if (overloadedMethodMemberDescriptor == null)
					{
						throw new ArgumentException(string.Format("Multiple members named {0} are being added to type {1} and one or more of these members do not support overloads.", name, Type.FullName));
					}
					overloadedMethodMemberDescriptor.AddOverload(overloadableMemberDescriptor);
				}
				else
				{
					members.Add(name, new OverloadedMethodMemberDescriptor(name, Type, overloadableMemberDescriptor));
				}
			}
			else
			{
				if (members.ContainsKey(name))
				{
					throw new ArgumentException(string.Format("Multiple members named {0} are being added to type {1} and one or more of these members do not support overloads.", name, Type.FullName));
				}
				members.Add(name, desc);
			}
		}

		public virtual DynValue Index(Script script, object obj, DynValue index, bool isDirectIndexing)
		{
			if (!isDirectIndexing)
			{
				IMemberDescriptor memberDescriptor = m_Members.GetOrDefault("get_Item").WithAccessOrNull(MemberDescriptorAccess.CanExecute);
				if (memberDescriptor != null)
				{
					return ExecuteIndexer(memberDescriptor, script, obj, index, null);
				}
			}
			index = index.ToScalar();
			if (index.Type != DataType.String)
			{
				throw ScriptRuntimeException.BadArgument(1, string.Format("userdata<{0}>.__index", Name), "string", index.Type.ToLuaTypeString(), false);
			}
			DynValue dynValue = TryIndex(script, obj, index.String);
			if (dynValue == null)
			{
				dynValue = TryIndex(script, obj, UpperFirstLetter(index.String));
			}
			if (dynValue == null)
			{
				dynValue = TryIndex(script, obj, Camelify(index.String));
			}
			if (dynValue == null)
			{
				dynValue = TryIndex(script, obj, UpperFirstLetter(Camelify(index.String)));
			}
			if (dynValue == null && m_ExtMethodsVersion < UserData.GetExtensionMethodsChangeVersion())
			{
				m_ExtMethodsVersion = UserData.GetExtensionMethodsChangeVersion();
				dynValue = TryIndexOnExtMethod(script, obj, index.String);
				if (dynValue == null)
				{
					dynValue = TryIndexOnExtMethod(script, obj, UpperFirstLetter(index.String));
				}
				if (dynValue == null)
				{
					dynValue = TryIndexOnExtMethod(script, obj, Camelify(index.String));
				}
				if (dynValue == null)
				{
					dynValue = TryIndexOnExtMethod(script, obj, UpperFirstLetter(Camelify(index.String)));
				}
			}
			return dynValue;
		}

		private DynValue TryIndexOnExtMethod(Script script, object obj, string indexName)
		{
			List<IOverloadableMemberDescriptor> list = (from d in UserData.GetExtensionMethodsByName(indexName)
				where d.ExtensionMethodType != null && d.ExtensionMethodType.IsAssignableFrom(Type)
				select d).ToList();
			if (list != null && list.Count > 0)
			{
				OverloadedMethodMemberDescriptor overloadedMethodMemberDescriptor = new OverloadedMethodMemberDescriptor(indexName, Type);
				overloadedMethodMemberDescriptor.SetExtensionMethodsSnapshot(UserData.GetExtensionMethodsChangeVersion(), list);
				m_Members.Add(indexName, overloadedMethodMemberDescriptor);
				return DynValue.NewCallback(overloadedMethodMemberDescriptor.GetCallback(script, obj));
			}
			return null;
		}

		public bool HasMember(string exactName)
		{
			return m_Members.ContainsKey(exactName);
		}

		public bool HasMetaMember(string exactName)
		{
			return m_MetaMembers.ContainsKey(exactName);
		}

		protected virtual DynValue TryIndex(Script script, object obj, string indexName)
		{
			IMemberDescriptor value;
			if (m_Members.TryGetValue(indexName, out value))
			{
				return value.GetValue(script, obj);
			}
			return null;
		}

		public virtual bool SetIndex(Script script, object obj, DynValue index, DynValue value, bool isDirectIndexing)
		{
			if (!isDirectIndexing)
			{
				IMemberDescriptor memberDescriptor = m_Members.GetOrDefault("set_Item").WithAccessOrNull(MemberDescriptorAccess.CanExecute);
				if (memberDescriptor != null)
				{
					ExecuteIndexer(memberDescriptor, script, obj, index, value);
					return true;
				}
			}
			index = index.ToScalar();
			if (index.Type != DataType.String)
			{
				throw ScriptRuntimeException.BadArgument(1, string.Format("userdata<{0}>.__setindex", Name), "string", index.Type.ToLuaTypeString(), false);
			}
			bool flag = TrySetIndex(script, obj, index.String, value);
			if (!flag)
			{
				flag = TrySetIndex(script, obj, UpperFirstLetter(index.String), value);
			}
			if (!flag)
			{
				flag = TrySetIndex(script, obj, Camelify(index.String), value);
			}
			if (!flag)
			{
				flag = TrySetIndex(script, obj, UpperFirstLetter(Camelify(index.String)), value);
			}
			return flag;
		}

		protected virtual bool TrySetIndex(Script script, object obj, string indexName, DynValue value)
		{
			IMemberDescriptor orDefault = m_Members.GetOrDefault(indexName);
			if (orDefault != null)
			{
				orDefault.SetValue(script, obj, value);
				return true;
			}
			return false;
		}

		void IOptimizableDescriptor.Optimize()
		{
			foreach (IOptimizableDescriptor item in m_MetaMembers.Values.OfType<IOptimizableDescriptor>())
			{
				item.Optimize();
			}
			foreach (IOptimizableDescriptor item2 in m_Members.Values.OfType<IOptimizableDescriptor>())
			{
				item2.Optimize();
			}
		}

		protected static string Camelify(string name)
		{
			StringBuilder stringBuilder = new StringBuilder(name.Length);
			bool flag = false;
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i] == '_' && i != 0)
				{
					flag = true;
					continue;
				}
				if (flag)
				{
					stringBuilder.Append(char.ToUpperInvariant(name[i]));
				}
				else
				{
					stringBuilder.Append(name[i]);
				}
				flag = false;
			}
			return stringBuilder.ToString();
		}

		protected static string UpperFirstLetter(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				return char.ToUpperInvariant(name[0]) + name.Substring(1);
			}
			return name;
		}

		public virtual string AsString(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.ToString();
		}

		protected virtual DynValue ExecuteIndexer(IMemberDescriptor mdesc, Script script, object obj, DynValue index, DynValue value)
		{
			IList<DynValue> list;
			if (index.Type != DataType.Tuple)
			{
				list = ((value != null) ? new DynValue[2] { index, value } : new DynValue[1] { index });
			}
			else if (value == null)
			{
				list = index.Tuple;
			}
			else
			{
				list = new List<DynValue>(index.Tuple);
				list.Add(value);
			}
			CallbackArguments arg = new CallbackArguments(list, false);
			ScriptExecutionContext arg2 = script.CreateDynamicExecutionContext();
			DynValue value2 = mdesc.GetValue(script, obj);
			if (value2.Type != DataType.ClrFunction)
			{
				throw new ScriptRuntimeException("a clr callback was expected in member {0}, while a {1} was found", mdesc.Name, value2.Type);
			}
			return value2.Callback.ClrCallback(arg2, arg);
		}

		public virtual DynValue MetaIndex(Script script, object obj, string metaname)
		{
			IMemberDescriptor orDefault = m_MetaMembers.GetOrDefault(metaname);
			if (orDefault != null)
			{
				return orDefault.GetValue(script, obj);
			}
			switch (metaname)
			{
			case "__add":
				return DispatchMetaOnMethod(script, obj, "op_Addition");
			case "__sub":
				return DispatchMetaOnMethod(script, obj, "op_Subtraction");
			case "__mul":
				return DispatchMetaOnMethod(script, obj, "op_Multiply");
			case "__div":
				return DispatchMetaOnMethod(script, obj, "op_Division");
			case "__mod":
				return DispatchMetaOnMethod(script, obj, "op_Modulus");
			case "__unm":
				return DispatchMetaOnMethod(script, obj, "op_UnaryNegation");
			case "__eq":
				return MultiDispatchEqual(script, obj);
			case "__lt":
				return MultiDispatchLessThan(script, obj);
			case "__le":
				return MultiDispatchLessThanOrEqual(script, obj);
			case "__len":
				return TryDispatchLength(script, obj);
			case "__tonumber":
				return TryDispatchToNumber(script, obj);
			case "__tobool":
				return TryDispatchToBool(script, obj);
			case "__iterator":
				return ClrToScriptConversions.EnumerationToDynValue(script, obj);
			default:
				return null;
			}
		}

		private int PerformComparison(object obj, object p1, object p2)
		{
			IComparable comparable = (IComparable)obj;
			if (comparable != null)
			{
				if (object.ReferenceEquals(obj, p1))
				{
					return comparable.CompareTo(p2);
				}
				if (object.ReferenceEquals(obj, p2))
				{
					return -comparable.CompareTo(p1);
				}
			}
			throw new InternalErrorException("unexpected case");
		}

		private DynValue MultiDispatchLessThanOrEqual(Script script, object obj)
		{
			IComparable comparable = obj as IComparable;
			if (comparable != null)
			{
				return DynValue.NewCallback((ScriptExecutionContext context, CallbackArguments args) => DynValue.NewBoolean(PerformComparison(obj, args[0].ToObject(), args[1].ToObject()) <= 0));
			}
			return null;
		}

		private DynValue MultiDispatchLessThan(Script script, object obj)
		{
			IComparable comparable = obj as IComparable;
			if (comparable != null)
			{
				return DynValue.NewCallback((ScriptExecutionContext context, CallbackArguments args) => DynValue.NewBoolean(PerformComparison(obj, args[0].ToObject(), args[1].ToObject()) < 0));
			}
			return null;
		}

		private DynValue TryDispatchLength(Script script, object obj)
		{
			if (obj == null)
			{
				return null;
			}
			IMemberDescriptor orDefault = m_Members.GetOrDefault("Length");
			if (orDefault != null && orDefault.CanRead() && !orDefault.CanExecute())
			{
				return orDefault.GetGetterCallbackAsDynValue(script, obj);
			}
			IMemberDescriptor orDefault2 = m_Members.GetOrDefault("Count");
			if (orDefault2 != null && orDefault2.CanRead() && !orDefault2.CanExecute())
			{
				return orDefault2.GetGetterCallbackAsDynValue(script, obj);
			}
			return null;
		}

		private DynValue MultiDispatchEqual(Script script, object obj)
		{
			return DynValue.NewCallback((ScriptExecutionContext context, CallbackArguments args) => DynValue.NewBoolean(CheckEquality(obj, args[0].ToObject(), args[1].ToObject())));
		}

		private bool CheckEquality(object obj, object p1, object p2)
		{
			if (obj != null)
			{
				if (object.ReferenceEquals(obj, p1))
				{
					return obj.Equals(p2);
				}
				if (object.ReferenceEquals(obj, p2))
				{
					return obj.Equals(p1);
				}
			}
			if (p1 != null)
			{
				return p1.Equals(p2);
			}
			if (p2 != null)
			{
				return p2.Equals(p1);
			}
			return true;
		}

		private DynValue DispatchMetaOnMethod(Script script, object obj, string methodName)
		{
			IMemberDescriptor orDefault = m_Members.GetOrDefault(methodName);
			if (orDefault != null)
			{
				return orDefault.GetValue(script, obj);
			}
			return null;
		}

		private DynValue TryDispatchToNumber(Script script, object obj)
		{
			Type[] numericTypesOrdered = NumericConversions.NumericTypesOrdered;
			foreach (Type type in numericTypesOrdered)
			{
				string conversionMethodName = type.GetConversionMethodName();
				DynValue dynValue = DispatchMetaOnMethod(script, obj, conversionMethodName);
				if (dynValue != null)
				{
					return dynValue;
				}
			}
			return null;
		}

		private DynValue TryDispatchToBool(Script script, object obj)
		{
			string conversionMethodName = typeof(bool).GetConversionMethodName();
			DynValue dynValue = DispatchMetaOnMethod(script, obj, conversionMethodName);
			if (dynValue != null)
			{
				return dynValue;
			}
			return DispatchMetaOnMethod(script, obj, "op_True");
		}

		public virtual bool IsTypeCompatible(Type type, object obj)
		{
			return type.IsInstanceOfType(obj);
		}
	}
}
