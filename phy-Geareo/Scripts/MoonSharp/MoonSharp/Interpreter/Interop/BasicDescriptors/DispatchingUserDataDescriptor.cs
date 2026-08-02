using System;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop.BasicDescriptors
{
	public abstract class DispatchingUserDataDescriptor : IUserDataDescriptor, IOptimizableDescriptor
	{
		private int m_ExtMethodsVersion;

		private Dictionary<string, IMemberDescriptor> m_MetaMembers;

		private Dictionary<string, IMemberDescriptor> m_Members;

		protected const string SPECIALNAME_INDEXER_GET = "get_Item";

		protected const string SPECIALNAME_INDEXER_SET = "set_Item";

		protected const string SPECIALNAME_CAST_EXPLICIT = "op_Explicit";

		protected const string SPECIALNAME_CAST_IMPLICIT = "op_Implicit";

		public string Name { get; private set; }

		public Type Type { get; private set; }

		public string FriendlyName { get; private set; }

		public IEnumerable<string> MemberNames => null;

		public IEnumerable<KeyValuePair<string, IMemberDescriptor>> Members => null;

		public IEnumerable<string> MetaMemberNames => null;

		public IEnumerable<KeyValuePair<string, IMemberDescriptor>> MetaMembers => null;

		protected DispatchingUserDataDescriptor(Type type, string friendlyName = null)
		{
		}

		public void AddMetaMember(string name, IMemberDescriptor desc)
		{
		}

		public void AddDynValue(string name, DynValue value)
		{
		}

		public void AddMember(string name, IMemberDescriptor desc)
		{
		}

		public IMemberDescriptor FindMember(string memberName)
		{
			return null;
		}

		public void RemoveMember(string memberName)
		{
		}

		public IMemberDescriptor FindMetaMember(string memberName)
		{
			return null;
		}

		public void RemoveMetaMember(string memberName)
		{
		}

		private void AddMemberTo(Dictionary<string, IMemberDescriptor> members, string name, IMemberDescriptor desc)
		{
		}

		public virtual DynValue Index(Script script, object obj, DynValue index, bool isDirectIndexing)
		{
			return null;
		}

		private DynValue TryIndexOnExtMethod(Script script, object obj, string indexName)
		{
			return null;
		}

		public bool HasMember(string exactName)
		{
			return false;
		}

		public bool HasMetaMember(string exactName)
		{
			return false;
		}

		protected virtual DynValue TryIndex(Script script, object obj, string indexName)
		{
			return null;
		}

		public virtual bool SetIndex(Script script, object obj, DynValue index, DynValue value, bool isDirectIndexing)
		{
			return false;
		}

		protected virtual bool TrySetIndex(Script script, object obj, string indexName, DynValue value)
		{
			return false;
		}

		void IOptimizableDescriptor.Optimize()
		{
		}

		protected static string Camelify(string name)
		{
			return null;
		}

		protected static string UpperFirstLetter(string name)
		{
			return null;
		}

		public virtual string AsString(object obj)
		{
			return null;
		}

		protected virtual DynValue ExecuteIndexer(IMemberDescriptor mdesc, Script script, object obj, DynValue index, DynValue value)
		{
			return null;
		}

		public virtual DynValue MetaIndex(Script script, object obj, string metaname)
		{
			return null;
		}

		private int PerformComparison(object obj, object p1, object p2)
		{
			return 0;
		}

		private DynValue MultiDispatchLessThanOrEqual(Script script, object obj)
		{
			return null;
		}

		private DynValue MultiDispatchLessThan(Script script, object obj)
		{
			return null;
		}

		private DynValue TryDispatchLength(Script script, object obj)
		{
			return null;
		}

		private DynValue MultiDispatchEqual(Script script, object obj)
		{
			return null;
		}

		private bool CheckEquality(object obj, object p1, object p2)
		{
			return false;
		}

		private DynValue DispatchMetaOnMethod(Script script, object obj, string methodName)
		{
			return null;
		}

		private DynValue TryDispatchToNumber(Script script, object obj)
		{
			return null;
		}

		private DynValue TryDispatchToBool(Script script, object obj)
		{
			return null;
		}

		public virtual bool IsTypeCompatible(Type type, object obj)
		{
			return false;
		}
	}
}
