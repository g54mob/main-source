using System;
using System.Collections.Generic;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop
{
	public class OverloadedMethodMemberDescriptor : IOptimizableDescriptor, IMemberDescriptor, IWireableDescriptor
	{
		private class OverloadableMemberDescriptorComparer : IComparer<IOverloadableMemberDescriptor>
		{
			public int Compare(IOverloadableMemberDescriptor x, IOverloadableMemberDescriptor y)
			{
				return 0;
			}
		}

		private class OverloadCacheItem
		{
			public bool HasObject;

			public IOverloadableMemberDescriptor Method;

			public List<DataType> ArgsDataType;

			public List<Type> ArgsUserDataType;

			public int HitIndexAtLastHit;
		}

		private const int CACHE_SIZE = 5;

		private List<IOverloadableMemberDescriptor> m_Overloads;

		private List<IOverloadableMemberDescriptor> m_ExtOverloads;

		private bool m_Unsorted;

		private OverloadCacheItem[] m_Cache;

		private int m_CacheHits;

		private int m_ExtensionMethodVersion;

		public bool IgnoreExtensionMethods { get; set; }

		public string Name { get; private set; }

		public Type DeclaringType { get; private set; }

		public int OverloadCount => 0;

		public bool IsStatic => false;

		public MemberDescriptorAccess MemberAccess => default(MemberDescriptorAccess);

		public OverloadedMethodMemberDescriptor(string name, Type declaringType)
		{
		}

		public OverloadedMethodMemberDescriptor(string name, Type declaringType, IOverloadableMemberDescriptor descriptor)
		{
		}

		public OverloadedMethodMemberDescriptor(string name, Type declaringType, IEnumerable<IOverloadableMemberDescriptor> descriptors)
		{
		}

		internal void SetExtensionMethodsSnapshot(int version, List<IOverloadableMemberDescriptor> extMethods)
		{
		}

		public void AddOverload(IOverloadableMemberDescriptor overload)
		{
		}

		private DynValue PerformOverloadedCall(Script script, object obj, ScriptExecutionContext context, CallbackArguments args)
		{
			return null;
		}

		private void Cache(bool hasObject, CallbackArguments args, IOverloadableMemberDescriptor bestOverload)
		{
		}

		private bool CheckMatch(bool hasObject, CallbackArguments args, OverloadCacheItem overloadCacheItem)
		{
			return false;
		}

		private int CalcScoreForOverload(ScriptExecutionContext context, CallbackArguments args, IOverloadableMemberDescriptor method, bool isExtMethod)
		{
			return 0;
		}

		private static int CalcScoreForSingleArgument(ParameterDescriptor desc, Type parameterType, DynValue arg, bool isOptional)
		{
			return 0;
		}

		public Func<ScriptExecutionContext, CallbackArguments, DynValue> GetCallback(Script script, object obj)
		{
			return null;
		}

		void IOptimizableDescriptor.Optimize()
		{
		}

		public CallbackFunction GetCallbackFunction(Script script, object obj = null)
		{
			return null;
		}

		public DynValue GetValue(Script script, object obj)
		{
			return null;
		}

		public void SetValue(Script script, object obj, DynValue value)
		{
		}

		public void PrepareForWiring(Table t)
		{
		}
	}
}
